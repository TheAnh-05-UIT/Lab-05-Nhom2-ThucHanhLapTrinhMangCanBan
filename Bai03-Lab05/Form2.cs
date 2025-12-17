using MailKit.Net.Pop3;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03_Lab05
{
    public partial class Form2 : Form
    {
        public Form2(string username, string password, int index)
        {
            InitializeComponent();
            LoadMail(username, password, index);
        }
        private void LoadMail(string username, string password, int index)
        {
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(username, password);

            MimeMessage message = client.GetMessage(index);

            txtFrom.Text = message.From.ToString();
            txtSubject.Text = message.Subject;

            if (!string.IsNullOrEmpty(message.HtmlBody))
                webBrowser1.DocumentText = message.HtmlBody;
            else
                webBrowser1.DocumentText = "<pre>" + message.TextBody + "</pre>";

            client.Disconnect(true);
        }
    }
}
