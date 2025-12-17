using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Bai01_Lab05
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo đối tượng MimeMessage
                var message = new MimeMessage();

                // Người gửi (From)
                message.From.Add(new MailboxAddress("Sender Name", txtFrom.Text.Trim()));

                // Người nhận (To)
                message.To.Add(new MailboxAddress("", txtTo.Text.Trim()));

                // Tiêu đề (Subject)
                message.Subject = txtSubject.Text;

                // Nội dung (Body)
                message.Body = new TextPart("plain")
                {
                    Text = rtbBody.Text
                };

                // Cấu hình SmtpClient
                using (var client = new SmtpClient())
                {
                    // Kết nối đến Mail Server (Ví dụ dùng Gmail)
                    // Server: smtp.gmail.com, Port: 587 (TLS) hoặc 465 (SSL)
                    // Cấu hình cho Gmail
                    client.Connect("smtp.gmail.com", 587, false); // Port 587 + false (StartTLS)

                    // Lấy email từ ô From và mật khẩu từ ô Password
                    string emailFrom = txtFrom.Text.Trim();
                    string passwordApp = "drzo ygdb rdnr viyz"; // Nhập mã 16 số Google cấp vào đây

                    client.Authenticate(emailFrom, passwordApp);

                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Gửi mail thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
