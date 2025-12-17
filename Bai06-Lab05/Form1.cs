using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MimeKit;

namespace Bai06_Lab05
{
    public partial class Form1 : Form
    {
        private EmailService _svc;
        private UniqueId _currentUid;
        private MimeMessage _currentMsg;
        public Form1()
        {
            InitializeComponent();
            lstview.View = View.Details;
            lstview.FullRowSelect = true;
            lstview.GridLines = true;
            lstview.Columns.Clear();
            lstview.Columns.Add("From", 240);
            lstview.Columns.Add("Subject", 300);
            lstview.Columns.Add("Date", 140);
            SetUiLoggedIn(false);
        }
        private void SetUiLoggedIn(bool ok)
        {
            btnLogout.Enabled = ok;
            btnRefresh.Enabled = ok;
            btnCompose.Enabled = ok;
            btnReply.Enabled = ok;
            btnLogin.Enabled = !ok;
            txtusername.Enabled = !ok;
            txtpassword.Enabled = !ok;
        }
        private void SetBusy(bool busy)
        {
            btnRefresh.Enabled = !busy;
            btnCompose.Enabled = !busy;
            btnReply.Enabled = !busy;
            lstview.Enabled = !busy;
            btnLogout.Enabled = !busy;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    string email = txtusername.Text.Trim();
                    string appPass = txtpassword.Text.Trim();
                    string imapHost = string.IsNullOrWhiteSpace(txtImapHost.Text) ? "imap.gmail.com" : txtImapHost.Text.Trim();
                    string smtpHost = string.IsNullOrWhiteSpace(txtSmtpHost.Text) ? "smtp.gmail.com" : txtSmtpHost.Text.Trim();
                    if (!int.TryParse(txtImapPort.Text.Trim(), out int imapPort)) imapPort = 993;
                    if (!int.TryParse(txtSmtpPort.Text.Trim(), out int smtpPort)) smtpPort = 465;
                    var svc = new EmailService();
                    svc.Login(email, appPass, imapHost, imapPort, smtpHost, smtpPort);

                    Invoke(new Action(() =>
                    {
                        _svc?.Dispose();
                        _svc = svc;
                        SetUiLoggedIn(true);
                        btnLogin.Enabled = true;
                        MessageBox.Show("Login OK!");
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        btnLogin.Enabled = true;
                        MessageBox.Show("Login lỗi: " + ex.Message);
                        SetUiLoggedIn(false);
                    }));
                }
            });
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try { _svc?.Logout(); } catch { }

                Invoke(new Action(() =>
                {
                    lstview.Items.Clear();
                    lblFrom.Text = "-";
                    lblSubject.Text = "-";
                    txtBody.Clear();
                    _currentMsg = null;
                    SetUiLoggedIn(false);
                    MessageBox.Show("Đã đăng xuất!");
                }));
            });
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_svc == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập.");
                return;
            }
            SetBusy(true);
            lstview.Items.Clear();
            Task.Run(() =>
            {
                try
                {
                    var list = _svc.LoadInbox(50);
                    Invoke(new Action(() =>
                    {
                        foreach (var s in list)
                        {
                            var from = s.Envelope?.From?.ToString() ?? "";
                            var subject = s.Envelope?.Subject ?? "";
                            var date = s.InternalDate?.LocalDateTime.ToString("dd/MM/yyyy HH:mm") ?? "";

                            var item = new ListViewItem(new string[] { from, subject, date });
                            item.Tag = s.UniqueId;
                            lstview.Items.Add(item);
                        }
                        SetBusy(false);
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        SetBusy(false);
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }));
                }
            });
        }
        private void lstview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_svc == null) return;
            if (lstview.SelectedItems.Count == 0) return;
            var uid = (UniqueId)lstview.SelectedItems[0].Tag;
            SetBusy(true);
            Task.Run(() =>
            {
                try
                {
                    var msg = _svc.GetMessage(uid);
                    Invoke(new Action(() =>
                    {
                        _currentUid = uid;
                        _currentMsg = msg;

                        lblFrom.Text = msg.From.ToString();
                        lblSubject.Text = msg.Subject ?? "";
                        var html = msg.HtmlBody ?? msg.GetTextBody(MimeKit.Text.TextFormat.Html);
                        if (!string.IsNullOrEmpty(html))
                        {
                            webBody.Visible = true;
                            txtBody.Visible = false;
                            webBody.DocumentText =
                                "<html><head><meta charset='utf-8'></head><body>" +
                                html +
                                "</body></html>";
                        }
                        else
                        {
                            webBody.Visible = false;
                            txtBody.Visible = true;
                            txtBody.Text = msg.TextBody ?? msg.GetTextBody(MimeKit.Text.TextFormat.Plain) ?? "";
                        }
                        SetBusy(false);
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        SetBusy(false);
                        MessageBox.Show("Đọc mail lỗi: " + ex.Message);
                    }));
                }
            });
        }
        private void btnCompose_Click(object sender, EventArgs e)
        {
            if (_svc == null) { MessageBox.Show("Bạn chưa đăng nhập."); return; }
            var f = new FormSend(_svc);
            f.ShowDialog();
        }
        private void btnReply_Click(object sender, EventArgs e)
        {
            if (_svc == null) { MessageBox.Show("Bạn chưa đăng nhập."); return; }
            if (_currentMsg == null) { MessageBox.Show("Chọn 1 email để reply."); return; }
            var f = new FormSend(_svc, _currentMsg);
            f.ShowDialog();
        }
    }
}
