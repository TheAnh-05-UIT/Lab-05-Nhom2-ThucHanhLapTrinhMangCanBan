using Newtonsoft.Json;
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
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Bai05_Lab05
{

    public partial class frm_Main : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalItems = 0;
        private int totalPages = 1;

        public frm_Main()
        {
            InitializeComponent();
            cobPageSize.Items.AddRange(new[] { "5", "10", "20" });
            cobPageSize.SelectedIndex = 1; 
            cobPageSize.SelectedIndexChanged += CobPageSize_SelectedIndexChanged;
            cobPage.SelectedIndexChanged += CobPage_SelectedIndexChanged;
            tabControlMain.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            this.Load += Form1_Load; 
        }
       
        private async void Form1_Load(object sender, EventArgs e)
        {
            currentPage = 1;
            await LoadDishes();
        }

        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            await LoadDishes();
        }

        private async void CobPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobPage.SelectedItem != null)
            {
                currentPage = int.Parse(cobPage.SelectedItem.ToString());
                await LoadDishes();
            }
        }

        private async void CobPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse(cobPageSize.SelectedItem.ToString());
            currentPage = 1;  
            await LoadDishes();
        }

        private async Task LoadDishes()
        {
            if (string.IsNullOrEmpty(AuthToken.AccessToken))
            {
                MessageBox.Show("Vui lòng đăng nhập trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            FlowLayoutPanel flp = tabControlMain.SelectedTab == tabPageAll ? flpAll : flpMy;

            if (flp == null)
            {
                MessageBox.Show("Lỗi nội bộ: FlowLayoutPanel không được khởi tạo.", "Lỗi");
                return;
            }

            flp.Controls.Clear();

            string url = tabControlMain.SelectedTab == tabPageAll
                ? "https://nt106.uitiot.vn/api/v1/monan/all"
                : "https://nt106.uitiot.vn/api/v1/monan/my-dishes";
            var bodyData = new
            {
                current = currentPage,
                pageSize
            };
            var jsonContent = JsonConvert.SerializeObject(bodyData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken.AccessToken);

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var dishResponse = JsonConvert.DeserializeObject<DishResponse>(responseBody);
                    if (dishResponse?.Pagination == null || dishResponse.Data == null)
                    {
                        totalItems = 0;
                        totalPages = 1;
                        cobPage.Items.Clear();
                        cobPage.Items.Add("1");
                        cobPage.SelectedItem = "1";
                        return;
                    }

                    totalItems = dishResponse.Pagination.Total;
                    totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                    cobPage.SelectedIndexChanged -= CobPage_SelectedIndexChanged;
                    cobPage.Items.Clear();
                    for (int i = 1; i <= totalPages; i++)
                    {
                        cobPage.Items.Add(i.ToString());
                    }
                    if (currentPage > totalPages && totalPages > 0)
                    {
                        currentPage = totalPages;
                    }
                    else if (totalPages == 0)
                    {
                        currentPage = 1;
                    }

                    string pageStr = currentPage.ToString();
                    if (cobPage.Items.Contains(pageStr))
                    {
                        cobPage.SelectedItem = pageStr;
                    }
                    else if (cobPage.Items.Count > 0)
                    {
                        cobPage.SelectedItem = cobPage.Items[0];
                    }
                    cobPage.SelectedIndexChanged += CobPage_SelectedIndexChanged;
                    foreach (var dish in dishResponse.Data)
                    {
                        var uc = new DishUserControl(dish);
                        uc.Size = new System.Drawing.Size(flp.Width - 20, 150);
                        flp.Controls.Add(uc);
                    }
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lấy danh sách thất bại. Mã lỗi: {response.StatusCode}\nChi tiết: {errorBody}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
                client.DefaultRequestHeaders.Authorization = null;
            }
        }
        private async void btnAnGiGio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AuthToken.AccessToken))
            {
                MessageBox.Show("Vui lòng đăng nhập trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            string url = "https://nt106.uitiot.vn/api/v1/monan/all"; 

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken.AccessToken);
                var bodyData = new { current = 1, pageSize = 1 };
                var jsonContent = JsonConvert.SerializeObject(bodyData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lấy danh sách thất bại. Mã lỗi: {response.StatusCode}\nChi tiết: {errorBody}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                var dishResponse = JsonConvert.DeserializeObject<DishResponse>(responseBody);

                if (dishResponse?.Pagination == null || dishResponse.Data == null)
                {
                    MessageBox.Show("Không có dữ liệu món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int totalItems = dishResponse.Pagination.Total;

                if (totalItems == 0)
                {
                    MessageBox.Show("Không có món ăn nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, totalItems);
                const int tempPageSize = 10;
                int randomPage = (randomIndex / tempPageSize) + 1;
                int position = randomIndex % tempPageSize;
                bodyData = new { current = randomPage, pageSize = tempPageSize };
                jsonContent = JsonConvert.SerializeObject(bodyData);
                content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lấy món ăn ngẫu nhiên thất bại. Mã lỗi: {response.StatusCode}\nChi tiết: {errorBody}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                responseBody = await response.Content.ReadAsStringAsync();
                dishResponse = JsonConvert.DeserializeObject<DishResponse>(responseBody);

                if (dishResponse.Data == null || dishResponse.Data.Count <= position)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu món ăn ngẫu nhiên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var randomDish = dishResponse.Data[position];
                var popupForm = new Form
                {
                    Text = "Món ăn gợi ý ngẫu nhiên",
                    Size = new Size(400, 300), 
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var uc = new DishUserControl(randomDish);
                uc.Dock = DockStyle.Fill;
                uc.BackColor = Color.LightYellow; 

                popupForm.Controls.Add(uc);
                popupForm.ShowDialog(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
                client.DefaultRequestHeaders.Authorization = null;
            }
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            Addfood f = new Addfood();
            f.Show();

        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthToken.AccessToken = null;

            Login f = new Login();
            this.Hide();    

            if (f.ShowDialog() == DialogResult.OK)
            {
                currentPage = 1;
                _ = LoadDishes();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
        public void lblWelcome_Change(string username)
        {
            lblWelcome.Text = $"Chào, {username}";
        }
        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContributeGmail_Click(object sender, EventArgs e)
        {
            frm_Contribute f = new frm_Contribute();
            //this.Hide();
            f.Show();
        }
    }
}