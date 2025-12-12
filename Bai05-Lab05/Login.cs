using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05_Lab05
{
    public partial class Login : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Login()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập username và password.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var formContent = new MultipartFormDataContent
            {
                { new StringContent(username), "username" },
                { new StringContent(password), "password" }
            };

            try
            {
                var response = await client.PostAsync("https://nt106.uitiot.vn/auth/token", formContent);

                if (response.IsSuccessStatusCode) 
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonDoc = JsonDocument.Parse(responseBody);
                    string tokenType = jsonDoc.RootElement.GetProperty("token_type").GetString();
                    string accessToken = jsonDoc.RootElement.GetProperty("access_token").GetString();
                    AuthToken.TokenType = tokenType;
                    AuthToken.AccessToken = accessToken;

                    MessageBox.Show($"Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    frm_Main mainFrm = new frm_Main();
                    mainFrm.lblWelcome_Change(username); 
                    mainFrm.Show(); 
                    this.Hide();


                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = "Đăng nhập thất bại. Mã lỗi: " + response.StatusCode;
                    try
                    {
                        var errorJson = JsonDocument.Parse(errorBody);
                        var detail = errorJson.RootElement.GetProperty("detail").GetString();
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

        private void linklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}