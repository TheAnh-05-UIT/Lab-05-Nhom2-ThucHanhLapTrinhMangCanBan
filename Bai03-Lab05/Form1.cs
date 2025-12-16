using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Pop3;

namespace Bai03_Lab05
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

        private void lstview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstview.SelectedItems.Count == 0) return;

            int mailIndex = (int)lstview.SelectedItems[0].Tag;

            Form2 f = new Form2(username, apppassword, mailIndex);

            f.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtusername.Text;
            apppassword = txtpassword.Text.Replace(" ", "");


            lstview.View = View.Details;
            lstview.Columns.Clear();
            lstview.Items.Clear();

            lstview.Columns.Add("Tiêu đề", 300);
            lstview.Columns.Add("Người gửi", 200);
            lstview.Columns.Add("Thời gian", 200);

            
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(username, apppassword);

            for (int i = client.Count - 1; i >= Math.Max(0, client.Count - 20); i--)
            { 
                var message = client.GetMessage(i);

                ListViewItem item = new ListViewItem(message.Subject);
                item.SubItems.Add(message.From.ToString());
                item.SubItems.Add(message.Date.LocalDateTime.ToString("dd/MM/yyyy HH:mm"));

                item.Tag = i;
                lstview.Items.Add(item);
            }

            client.Disconnect(true);
        }
    }
}
