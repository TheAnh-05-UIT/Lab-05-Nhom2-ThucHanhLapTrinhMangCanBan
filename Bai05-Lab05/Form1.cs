using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MimeKit.Tnef;

namespace Bai05_Lab05
{
    public partial class frm_Contribute : Form
    {
        string dbPath;
        string cs;
        SQLiteConnection conn;

        public frm_Contribute()
        {
            InitializeComponent();
            dbPath = Path.Combine(Application.StartupPath, "Contribute.db");
            cs = $"Data Source={dbPath};Version=3;";
            conn = new SQLiteConnection(cs);
            //conn.Open();
            try
            {
                conn.Open();
                MessageBox.Show("Kết nối thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void LoadData()
        {
            string query = "SELECT * FROM MonAn";
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvData.DataSource = dt;
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task TaiDongGopMoi()
        {
            string imapHost = "imap.gmail.com";
            int imapPort = 993;
            string emailUser = "phamphuquang06@gmail.com";
            string emailPass = "tyvlzpiwflwfrfsp";
            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync(imapHost, imapPort, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(emailUser, emailPass);
                    await client.Inbox.OpenAsync(FolderAccess.ReadWrite);
                    var query = SearchQuery.SubjectContains("Đóng góp món ăn").And(SearchQuery.NotSeen);
                    var uids = await client.Inbox.SearchAsync(query);
                    int soMonAnMoi = 0;
                    foreach(var uid in uids)
                    {
                        var message = await client.Inbox.GetMessageAsync(uid);
                        if(PhanTichVaLuuDB(message))
                        {
                            await client.Inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                            ++soMonAnMoi;
                        }

                    }
                    await client.DisconnectAsync(true);
                    MessageBox.Show($"Đã tải {soMonAnMoi} món ăn mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải đóng góp mới: " + ex.Message);
            }
        }
        private bool PhanTichVaLuuDB(MimeMessage message)
        {
            string nguoiGui = "Người ẩn danh";
            string emailGoc = string.Empty;
            var fromAddress = message.From.Mailboxes.FirstOrDefault();
            if(fromAddress != null)
            {
                nguoiGui = string.IsNullOrWhiteSpace(fromAddress.Name) ? "Người ẩn danh" : fromAddress.Name;
                emailGoc = fromAddress.Address;
            }
            string bodyText = message.TextBody;
            if(string.IsNullOrWhiteSpace(bodyText))
            {
                return false;
            }
            string[] parts = bodyText
                            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => p.Trim())
                            .Where(p => !string.IsNullOrEmpty(p))
                            .ToArray();
            if(parts.Length < 4)
            {
                return false;
            }
            string tenMonAn = parts[0];
            string checkQuery = "SELECT COUNT(*) FROM MonAn WHERE TenMonAn = @tenMonAn";
             SQLiteCommand cmd = new SQLiteCommand(checkQuery, conn);
            cmd.Parameters.AddWithValue("@tenMonAn", tenMonAn);
            long count = (long)cmd.ExecuteScalar();
            if(count > 0)
            {
                return false;
            }
            string idQuery = "SELECT COUNT(*) FROM MonAn"; 
            SQLiteCommand cmd1 = new SQLiteCommand(idQuery, conn);
            object result = cmd1.ExecuteScalar();
            int size = 0;
            if (result != null)
            {
                size = Convert.ToInt32(result);
                size++;
            }
            else
            {
                size = 1;
            }
            string insertQuery = "INSERT INTO MonAn (Id, TenMonAn, NguyenLieu, CachLam, HinhAnh, NguoiDongGop, EmailDongGop)" +
                "VALUES (@id, @tenmonan,  @nguyenlieu, @cachlam, @hinhanh, @tendonggop, @emaildonggop)";
            SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn);
            insertCmd.Parameters.AddWithValue("@id", size);
            insertCmd.Parameters.AddWithValue("@tenmonan", tenMonAn);
            insertCmd.Parameters.AddWithValue("@nguyenlieu", parts[1]);
            insertCmd.Parameters.AddWithValue("@cachlam", parts[2]);
            insertCmd.Parameters.AddWithValue("@hinhanh", parts[3]);
            insertCmd.Parameters.AddWithValue("@tendonggop", nguoiGui);
            insertCmd.Parameters.AddWithValue("@emaildonggop", emailGoc);
            insertCmd.ExecuteNonQuery();
            return true;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDongGopMoi();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {

        }
    }
}
