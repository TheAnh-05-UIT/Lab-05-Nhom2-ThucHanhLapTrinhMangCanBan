using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Text.Json.JsonSerializer;

namespace Bai05_Lab05
{
    public partial class Addfood : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Addfood()
        {
            InitializeComponent();
        }

        public class MonAnResponse
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("ten_mon_an")]
            public string TenMonAn { get; set; }
            [JsonPropertyName("gia")]
            public decimal Gia { get; set; }
            [JsonPropertyName("mo_ta")]
            public string MoTa { get; set; }
            [JsonPropertyName("hinh_anh")]
            public string HinhAnh { get; set; }
            [JsonPropertyName("dia_chi")]
            public string DiaChi { get; set; }
            [JsonPropertyName("nguoi_dong_gop")]
            public string NguoiDongGop { get; set; }
        }

        public class Pagination
        {
            public int current { get; set; }
            public int pageSize { get; set; }
            public int total { get; set; }
        }
 
        public class ApiResponse<T> 
        {
            public List<T> data { get; set; } 
            public Pagination pagination { get; set; }
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
    
            if (string.IsNullOrEmpty(AuthToken.AccessToken))
            {
                MessageBox.Show("Vui lòng đăng nhập trước để lấy access_token.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            var name = txtNameFood.Text.Trim();
            var address = txtAddress.Text.Trim();
            var image = txtImage.Text.Trim();
            var description = richtxtMoTa.Text.Trim();

         
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên món ăn, giá và địa chỉ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out var price))
            {
                MessageBox.Show("Giá món ăn phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Giá phải là số lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var data = new
            {
                ten_mon_an = name, 
                gia = price, 
                dia_chi = address, 
                hinh_anh = image, 
                mo_ta = description 
            };
           
            var jsonContent = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            try
            {
             
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken.AccessToken);
               
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/add", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    
                    var result = JsonSerializer.Deserialize<MonAnResponse>(responseBody);
                    if (result != null) 
                    {
                        MessageBox.Show($"Thêm món ăn thành công!\nID: {result.Id}, Tên: {result.TenMonAn}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm món ăn thành công, nhưng không đọc được phản hồi chi tiết.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine("--- RESPONSE ERROR BODY ---");
                    System.Diagnostics.Debug.WriteLine(errorBody);
                    System.Diagnostics.Debug.WriteLine("---------------------------");
                    string errorMessage = "Thêm món ăn thất bại. Mã lỗi: " + response.StatusCode;
              
                    var contentType = response.Content.Headers.ContentType;
                  
                    if (contentType != null && contentType.MediaType == "application/json")
                    {
                        try
                        {
                            var errorJson = JsonDocument.Parse(errorBody);
                  
                            if (errorJson.RootElement.TryGetProperty("detail", out var detailElement))
                            {
                                errorMessage += "\nChi tiết: " + detailElement.GetString();
                            }
                            else
                            {
                          
                                errorMessage += "\nChi tiết (JSON): " + errorBody;
                            }
                        }
                        catch (JsonException)
                        {
                            
                            errorMessage += "\nChi tiết: API trả về JSON lỗi, nhưng không đọc được nội dung chi tiết.";
                        }
                    }
                    else
                    {
                      
                        errorMessage += "\nChi tiết (Non-JSON): " + errorBody;
                    }
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
              
                client.DefaultRequestHeaders.Authorization = null;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Clear();
            txtImage.Clear();
            txtNameFood.Clear();
            txtPrice.Clear();
            richtxtMoTa.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}