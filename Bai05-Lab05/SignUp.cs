using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json;
namespace Bai05_Lab05
{
    public partial class SignUp : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public SignUp()
        {
            InitializeComponent();
        }
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string firstname = txtFirstname.Text.Trim();
            string birthdate = dtpBirthday.Value.ToString("yyyy-MM-dd");
            string language = cobLanguage.SelectedItem?.ToString() ?? "";
            int sex = rabtnMale.Checked ? 0 : rabtnFemale.Checked ? 1 : 2;
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập/ mật khẩu/ email", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = new
            {
                username,
                password,
                email,
                firstname,
                lastname,
                phone,
                birthdate,
                sex,
                language
            };
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/user/signup", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Đăng ký thành công!" , "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = "Đăng ký thất bại. Mã lỗi: " + response.StatusCode;
                    try
                    {
                        var errorJson = JsonDocument.Parse(errorBody);
                        var detail = errorJson.RootElement.GetProperty("detail").GetString();
                        if (detail.Contains("username"))
                            errorMessage += "\nLỗi: Username đã tồn tại.";
                        else if (detail.Contains("password"))
                            errorMessage += "\nLỗi: Mật khẩu không hợp lệ.";
                        else if (detail.Contains("email"))
                            errorMessage += "\nLỗi: Email không hợp lệ hoặc đã tồn tại.";
                        else
                            errorMessage += "\nChi tiết: " + detail;
                    }
                    catch
                    {
                        errorMessage += "\nChi tiết: " + errorBody;
                    }
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            dtpBirthday.Value = DateTime.Now;
            cobLanguage.SelectedIndex = -1;
            rabtnFemale.Checked = false;
            rabtnMale.Checked = false;
        }
    }
}
