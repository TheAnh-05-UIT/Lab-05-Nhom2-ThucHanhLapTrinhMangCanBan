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
            username = txtusername.Text;
            apppassword = txtpassword.Text;

            lstview.Columns.Clear();
            lstview.Items.Clear();

            lstview.Columns.Add("Email", 250);
            lstview.Columns.Add("From", 250);
            lstview.Columns.Add("Thời gian", 100);

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
                item.SubItems.Add(message.Date.LocalDateTime.ToString("dd/MM/yyyy HH:mm"));
                lstview.Items.Add(item);
            }
            client.Disconnect(true);
        }
    }
}
