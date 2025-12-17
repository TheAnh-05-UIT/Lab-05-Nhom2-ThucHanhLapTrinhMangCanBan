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
using MailKit.Net.Imap;

namespace Bai02_Lab05
{
    public partial class Form1 : Form
    {
        string username, apppassword;
        public Form1()
        {
            InitializeComponent();
            lstview.View = View.Details;
            lstview.FullRowSelect = true;
            lstview.GridLines = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtusername.Text.Trim();
            apppassword = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(apppassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            lstview.Columns.Clear();
            lstview.Items.Clear();

            lstview.Columns.Add("Email", 250);
            lstview.Columns.Add("From", 250);
            lstview.Columns.Add("Thời gian", 150);

            try
            {
                var client = new ImapClient();

                client.Connect("imap.gmail.com", 993, true);

                client.Authenticate(username, apppassword);

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                for (int i = inbox.Count - 1; i >= Math.Max(0, inbox.Count - 20); i--)
                {
                    var message = inbox.GetMessage(i);

                    ListViewItem item = new ListViewItem(message.Subject);
                    item.SubItems.Add(message.From.ToString());
                    item.SubItems.Add(
                        message.Date.LocalDateTime.ToString("dd/MM/yyyy HH:mm")
                    );

                    lstview.Items.Add(item);
                }

                client.Disconnect(true);
            }
            catch (MailKit.Security.AuthenticationException)
            {
                MessageBox.Show("Sai email hoặc mật khẩu ứng dụng!",
                                "Lỗi đăng nhập",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (MailKit.Net.Imap.ImapProtocolException)
            {
                MessageBox.Show("Lỗi giao thức IMAP!",
                                "Lỗi kết nối",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
