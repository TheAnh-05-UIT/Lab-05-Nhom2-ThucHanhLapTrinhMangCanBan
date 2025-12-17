using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using MimeKit;


namespace Bai06_Lab05
{
    public partial class FormSend : Form
    {
        private readonly EmailService _svc;
        private readonly List<string> _attachPaths = new List<string>();
        private readonly MimeMessage _replyTo;
        public FormSend(EmailService svc)
        {
            InitializeComponent();
            _svc = svc;
            _replyTo = null;
        }
        public FormSend(EmailService svc, MimeMessage original)
        {
            InitializeComponent();
            _svc = svc;
            _replyTo = original;
            var to = (original.ReplyTo.Count > 0 ? original.ReplyTo : original.From).ToString();
            txtto.Text = to;

            txtsubject.Text = original.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase)
                ? original.Subject
                : "Re: " + original.Subject;
            txtbody.Text = "\n\n----- Original message -----\n" + (original.TextBody ?? "");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var p in ofd.FileNames)
                    {
                        if (!_attachPaths.Contains(p))
                        {
                            _attachPaths.Add(p);
                            lstattach.Items.Add(p);
                        }
                    }
                }
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstattach.SelectedItem == null) return;

            var p = lstattach.SelectedItem.ToString();
            _attachPaths.Remove(p);
            lstattach.Items.Remove(p);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    var msg = new MimeMessage();
                    msg.From.Add(MailboxAddress.Parse(_svc.MyEmail));
                    msg.To.Add(MailboxAddress.Parse(txtto.Text.Trim()));
                    msg.Subject = txtsubject.Text.Trim();

                    var builder = new BodyBuilder();
                    builder.TextBody = txtbody.Text;
                    foreach (var path in _attachPaths)
                        builder.Attachments.Add(path);

                    msg.Body = builder.ToMessageBody();
                    _svc.Send(msg);

                    Invoke(new Action(() =>
                    {
                        btnSend.Enabled = true;
                        MessageBox.Show("Sent!");
                        Close();
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        btnSend.Enabled = true;
                        MessageBox.Show("Gửi lỗi: " + ex.Message);
                    }));
                }
            });
        }

    }
}
