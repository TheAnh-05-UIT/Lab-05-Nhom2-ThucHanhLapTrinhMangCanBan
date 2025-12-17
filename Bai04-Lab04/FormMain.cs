using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Bai04_Lab04
{


    public partial class FormMain : Form
    {
        List<Phim> dsPhim = new List<Phim>();

        Dictionary<int, List<string>> gheDaBan = new Dictionary<int, List<string>>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DocFileJson();
            gheDaBan.Add(1, new List<string>());
            gheDaBan.Add(2, new List<string>());
            gheDaBan.Add(3, new List<string>());

            prgTienDo.Minimum = 0;
            prgTienDo.Step = 1;

            if (File.Exists("data_phim.json"))
            {
                LoadJsonData();
            }
        }

        // Ghi dữ liệu từ danh sách xuống file JSON
        private void LuuFileJson()
        {
            try
            {
                // Chuyển List<Phim> thành chuỗi JSON
                string json = JsonConvert.SerializeObject(dsPhim, Formatting.Indented);

                // Ghi đè chuỗi này vào file "data_phim.json" nằm cạnh file .exe
                File.WriteAllText("data_phim.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
            }
        }

        // Đọc dữ liệu từ file JSON lên danh sách
        private void DocFileJson()
        {
            try
            {
                // Kiểm tra xem file có tồn tại không
                if (File.Exists("data_phim.json"))
                {
                    // Đọc toàn bộ nội dung file
                    string json = File.ReadAllText("data_phim.json");

                    // Chuyển chuỗi JSON ngược lại thành List<Phim>
                    dsPhim = JsonConvert.DeserializeObject<List<Phim>>(json);

                    // Cập nhật giao diện sau khi đọc xong
                    HienThiGiaoDien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
            }
        }

        private void HienThiGiaoDien()
        {
            // Cập nhật ComboBox
            cbPhim.DataSource = null;
            cbPhim.DataSource = dsPhim;
            cbPhim.DisplayMember = "TenPhim";

            // Cập nhật danh sách Poster
            flpDanhSachPhim.Controls.Clear();

            foreach (var phim in dsPhim)
            {
                Panel pnl = new Panel { Width = 150, Height = 230, Margin = new Padding(10), BackColor = Color.WhiteSmoke };

                PictureBox pic = new PictureBox
                {
                    Width = 140,
                    Height = 180,
                    Top = 5,
                    Left = 5,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };

                try { if (!string.IsNullOrEmpty(phim.UrlHinhAnh)) pic.LoadAsync(phim.UrlHinhAnh); } catch { }

                // Khi Click vào ảnh -> Hiện mô tả & Tự chọn phim trên ComboBox
                pic.Click += (s, e) =>
                {
                    //  Hiển thị mô tả lên RichTextBox
                    if (rtbMoTaPhim != null)
                    {
                        // Nếu không có mô tả thì hiện thông báo mặc định
                        rtbMoTaPhim.Text = string.IsNullOrEmpty(phim.MoTa) ? "Đang cập nhật..." : phim.MoTa;
                    }
                    cbPhim.SelectedItem = phim;
                };

                Label lbl = new Label
                {
                    Text = phim.TenPhim,
                    Top = 190,
                    Left = 5,
                    Width = 140,
                    Height = 40,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopCenter
                };

                pnl.Controls.Add(pic);
                pnl.Controls.Add(lbl);
                flpDanhSachPhim.Controls.Add(pnl);
            }
        }

        private void LoadJsonData()
        {
            try
            {
                string json = File.ReadAllText("data_phim.json");
                dsPhim = JsonConvert.DeserializeObject<List<Phim>>(json);
                HienThiGiaoDien();
            }
            catch { }
        }

        private async void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (string.IsNullOrEmpty(url)) return;

            try
            {
                HtmlWeb web = new HtmlWeb();

                var doc = await web.LoadFromWebAsync(url);

                var nodes = doc.DocumentNode.SelectNodes("//div[@id='tab-1']//div[contains(@class,'row')]/div");

                if (nodes == null || nodes.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu! Có thể cấu trúc web đã đổi.");
                    return;
                }

                dsPhim.Clear();
                prgTienDo.Value = 0;
                prgTienDo.Maximum = nodes.Count;
                foreach (var node in nodes)
                {
                    Phim p = new Phim();

                    // LẤY TÊN VÀ LINK CHI TIẾT
                    var linkNode = node.SelectSingleNode(".//h3/a");
                    if (linkNode != null)
                    {
                        p.TenPhim = linkNode.InnerText.Trim();
                        string href = linkNode.GetAttributeValue("href", "");
                        p.UrlChiTiet = href.StartsWith("http") ? href : "https://betacinemas.vn" + href;
                    }
                    else { continue; }

                    // LẤY ẢNH
                    var imgNode = node.SelectSingleNode(".//img");
                    if (imgNode != null)
                    {
                        string src = imgNode.GetAttributeValue("src", "");
                        p.UrlHinhAnh = src.StartsWith("http") ? src : "https://betacinemas.vn" + src;
                    }

                    try
                    {
                        var docChiTiet = await web.LoadFromWebAsync(p.UrlChiTiet);

                        var nodeMoTaChiTiet = docChiTiet.DocumentNode.SelectSingleNode("//div[@class='tab-content']//p");

                        if (nodeMoTaChiTiet != null)
                        {
                            p.MoTa = nodeMoTaChiTiet.InnerText.Trim();
                        }
                        else
                        {
                            p.MoTa = "Không tìm thấy mô tả chi tiết.";
                        }
                    }
                    catch
                    {
                        p.MoTa = "Lỗi khi tải mô tả.";
                    }

                    bool daTonTai = dsPhim.Any(x => x.TenPhim == p.TenPhim);

                    if (!daTonTai)
                    {
                        dsPhim.Add(p);
                    }

                    p.GiaVeChuan = 50000 + (new Random().Next(0, 4) * 10000);

                    prgTienDo.PerformStep();
                }

                prgTienDo.Value = prgTienDo.Maximum;

                if (prgTienDo.Value > 0)
                {
                    prgTienDo.Value = prgTienDo.Value - 1;
                    prgTienDo.Value = prgTienDo.Maximum;
                }



                string json = JsonConvert.SerializeObject(dsPhim, Formatting.Indented);
                File.WriteAllText("data_phim.json", json);

                LuuFileJson();

                HienThiGiaoDien();
                MessageBox.Show($"Đã cập nhật thành công {dsPhim.Count} bộ phim!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Biến lưu danh sách các ghế đang được chọn (để tính tiền)
        List<Button> danhSachGheChon = new List<Button>();

        private void LoadGhe(int phong)
        {
            // Xóa sạch ghế cũ trên giao diện
            flpGhe.Controls.Clear();
            danhSachGheChon.Clear(); // Reset danh sách chọn

            // Lấy dữ liệu ghế đã bán
            List<string> daBan = new List<string>();
            if (gheDaBan.ContainsKey(phong))
            {
                daBan = gheDaBan[phong];
            }

            // Cấu hình kích thước ghế
            int gheWidth = 50;
            int gheHeight = 50;
            int khoangCach = 5;

            string[] hang = { "A", "B", "C" };

            // Vòng lặp tạo ghế
            foreach (var h in hang)
            {
                FlowLayoutPanel rowPanel = new FlowLayoutPanel();
                rowPanel.Width = flpGhe.Width;
                rowPanel.Height = gheHeight + khoangCach;
                rowPanel.FlowDirection = FlowDirection.LeftToRight;
                rowPanel.Margin = new Padding(0);

                for (int i = 1; i <= 5; i++)
                {
                    string tenGhe = h + i;

                    // TẠO NÚT BẤM (Đại diện cho 1 ghế)
                    Button btn = new Button();
                    btn.Text = tenGhe;
                    btn.Name = tenGhe;
                    btn.Width = gheWidth;
                    btn.Height = gheHeight;
                    btn.Margin = new Padding(khoangCach);

                    // TÔ MÀU PHÂN LOẠI GHẾ
                    // Ghế Vớt (Rìa): A1, A5, C1, C5 -> Màu Xanh Nhạt
                    if (tenGhe == "A1" || tenGhe == "A5" || tenGhe == "C1" || tenGhe == "C5")
                        btn.BackColor = Color.LightBlue;
                    // Ghế VIP (Giữa): B2, B3, B4 -> Màu Hồng Nhạt
                    else if (tenGhe == "B2" || tenGhe == "B3" || tenGhe == "B4")
                        btn.BackColor = Color.Pink;
                    // Ghế Thường -> Màu Trắng
                    else
                        btn.BackColor = Color.White;

                    // XỬ LÝ GHẾ ĐÃ BÁN
                    if (daBan.Contains(tenGhe))
                    {
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;        
                        btn.Text += "\nSold"; 
                    }
                    else
                    {
                        btn.Click += Ghe_Click;
                    }

                    rowPanel.Controls.Add(btn);
                }
                // Thêm hàng vào giao diện chính
                flpGhe.Controls.Add(rowPanel);
            }
        }

        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Kiểm tra màu để biết đang chọn hay bỏ chọn
            if (btn.BackColor == Color.Yellow)
            {
                // TRƯỜNG HỢP HỦY CHỌN:
                // Trả lại màu gốc của nó
                string tenGhe = btn.Text;
                if (tenGhe == "A1" || tenGhe == "A5" || tenGhe == "C1" || tenGhe == "C5")
                    btn.BackColor = Color.LightBlue;
                else if (tenGhe == "B2" || tenGhe == "B3" || tenGhe == "B4")
                    btn.BackColor = Color.Pink;
                else
                    btn.BackColor = Color.White;

                danhSachGheChon.Remove(btn);
            }
            else
            {
                btn.BackColor = Color.Yellow; 
                danhSachGheChon.Add(btn); 
            }
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedItem is Phim p)
            {
                cbPhong.DataSource = null;
                cbPhong.DataSource = p.PhongChieu;

                flpGhe.Controls.Clear();
                danhSachGheChon.Clear();

                if (rtbMoTaPhim != null)
                {
                    rtbMoTaPhim.Text = p.MoTa;
                }
            }
        }

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhong.SelectedItem == null) return;
            int phong = (int)cbPhong.SelectedItem;
            LoadGhe(phong);
        }

        private async void btnDatVe_Click(object sender, EventArgs e)
        {
            // KIỂM TRA NHẬP LIỆU
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!"); return;
            }
            // Thêm kiểm tra Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email để nhận vé!"); return;
            }
            if (cbPhim.SelectedItem == null || cbPhong.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn phim hoặc phòng!"); return;
            }
            if (danhSachGheChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 ghế!"); return;
            }

            //  XỬ LÝ DỮ LIỆU & TÍNH TIỀN 
            Phim phim = cbPhim.SelectedItem as Phim;
            int phong = (int)cbPhong.SelectedItem;

            double tongTien = 0;
            List<string> gheMua = new List<string>(); 
            List<string> gheHienThi = new List<string>();

            // Duyệt qua các ghế đang chọn (Màu vàng)
            foreach (Button btn in danhSachGheChon)
            {
                string tenGhe = btn.Name;

                // Kiểm tra lần cuối xem ghế có bị ai mua chưa
                if (gheDaBan.ContainsKey(phong) && gheDaBan[phong].Contains(tenGhe))
                {
                    MessageBox.Show($"Ghế {tenGhe} đã bị người khác mua! Vui lòng chọn lại.");
                    LoadGhe(phong);
                    return;
                }

                double gia = TinhTien(tenGhe, phim.GiaVeChuan);
                tongTien += gia;

                gheMua.Add(tenGhe);
                gheHienThi.Add($"{tenGhe} ({gia:N0}đ)");
            }

            List<string> gheInHoaDon = new List<string>();

            List<string> gheCanLuu = new List<string>();

            foreach (Button btn in danhSachGheChon)
            {
                string tenGhe = btn.Name;
                double giaGheNay = TinhTien(tenGhe, phim.GiaVeChuan);
                gheInHoaDon.Add($"{tenGhe} ({giaGheNay:N0})");
                gheCanLuu.Add(tenGhe);
            }


            if (!gheDaBan.ContainsKey(phong))

            {

                gheDaBan.Add(phong, new List<string>());

            }

            gheDaBan[phong].AddRange(gheCanLuu);

            // GỬI EMAIL XÁC NHẬN 
            try
            {
                this.Enabled = false;
                this.Text = "Đang xử lý đặt vé và gửi mail...";

                string strGhe = string.Join(", ", gheMua);

                string linkAnh = !string.IsNullOrEmpty(phim.UrlHinhAnh) ? phim.UrlHinhAnh : "https://via.placeholder.com/800x600?text=No+Poster";

                await GuiMailXacNhan(txtHoTen.Text, txtEmail.Text, phim.TenPhim, linkAnh, strGhe, tongTien);

                if (!gheDaBan.ContainsKey(phong))
                {
                    gheDaBan.Add(phong, new List<string>());
                }
                gheDaBan[phong].AddRange(gheMua);

                rtbKetQua.Text = "";

                rtbKetQua.AppendText("           HÓA ĐƠN THANH TOÁN           \n");

                rtbKetQua.AppendText("----------------------------------------\n");

                rtbKetQua.AppendText($"Khách hàng: {txtHoTen.Text}\n");

                rtbKetQua.AppendText($"Phim: {phim.TenPhim}\n");

                rtbKetQua.AppendText($"Phòng: {phong}\n");

                rtbKetQua.AppendText("Chi tiết ghế:\n");

                foreach (var g in gheInHoaDon)

                {

                    rtbKetQua.AppendText($"  + {g} VNĐ\n");

                }
                rtbKetQua.AppendText("----------------------------------------\n");
                rtbKetQua.AppendText($"TỔNG TIỀN: {tongTien:N0} VNĐ\n");
                rtbKetQua.AppendText("Đã gửi vé điện tử qua Email!");

                MessageBox.Show("Đặt vé thành công! Vui lòng kiểm tra Email.");

                danhSachGheChon.Clear();
                LoadGhe(phong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Text = "Quản lý phòng vé";
            }
        }

        private double TinhTien(string ghe, double giaChuan)
        {
            if (ghe == "A1" || ghe == "A5" || ghe == "C1" || ghe == "C5")
                return giaChuan * 0.25;

            if (ghe == "B2" || ghe == "B3" || ghe == "B4")
                return giaChuan * 2.0;

            return giaChuan;
        }

        // Hàm gửi mail xác nhận (Chạy ngầm - Async)
        private async Task GuiMailXacNhan(string hoTen, string emailKhach, string tenPhim, string urlPoster, string gheDaChon, double tongTien)
        {
            string fromEmail = "theanh.03535@gmail.com";
            string appPassword = "iqhv znvm ttai ihld";

            try
            {
                string noiDungHtml = $@"
        <html>
            <body style='font-family: Arial, sans-serif; margin: 0; padding: 0;'>
                <div style='
                    background-image: url(""{urlPoster}"");
                    background-size: cover;
                    background-position: center;
                    padding: 60px 20px;
                    text-align: center;'>

                    <div style='
                        background-color: rgba(255, 255, 255, 0.95);
                        border-radius: 10px;
                        max-width: 600px;
                        margin: 0 auto;
                        padding: 40px;
                        box-shadow: 0 5px 15px rgba(0,0,0,0.3);'>

                        <h2 style='color: #e74c3c; margin-top: 0;'>XÁC NHẬN ĐẶT VÉ THÀNH CÔNG</h2>
                        <p>Xin chào <b>{hoTen}</b>,</p>
                        <p>Cảm ơn bạn đã lựa chọn Beta Cinemas. Đây là vé điện tử của bạn:</p>
                        
                        <hr style='border: 1px dashed #ccc; margin: 20px 0;'>

                        <table style='width: 100%; text-align: left; border-collapse: collapse;'>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><b>Phim:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee; font-size: 16px;'>{tenPhim}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><b>Rạp:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>Beta Cinemas - Phòng 01</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><b>Ghế:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee; color: #e74c3c; font-weight: bold; font-size: 18px;'>{gheDaChon}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px;'><b>Thanh toán:</b></td>
                                <td style='padding: 10px; font-weight: bold;'>{tongTien:N0} VNĐ</td>
                            </tr>
                        </table>

                        <hr style='border: 1px dashed #ccc; margin: 20px 0;'>
                        
                        <p style='font-style: italic; color: #7f8c8d; font-size: 14px;'>
                            ""Chúc bạn có những giây phút trải nghiệm điện ảnh tuyệt vời!""
                        </p>
                        <div style='margin-top: 30px; font-size: 12px; color: #95a5a6;'>
                            Vui lòng đưa email này cho nhân viên tại quầy soát vé.
                        </div>
                    </div>
                </div>
            </body>
        </html>";

                // 2. Cấu hình gửi mail (SMTP)
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true, // Bắt buộc
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail, appPassword)
                };

                // 3. Tạo đối tượng MailMessage
                using (var message = new MailMessage(new MailAddress(fromEmail, "Vé Phim Online"), new MailAddress(emailKhach)))
                {
                    message.Subject = $"[Vé Điện Tử] Xác nhận đặt vé phim: {tenPhim}";
                    message.Body = noiDungHtml;
                    message.IsBodyHtml = true; // Quan trọng: Cho phép đọc mã HTML

                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi (mất mạng, sai pass...) thì ném lỗi ra ngoài để hàm chính bắt
                throw new Exception("Lỗi gửi mail: " + ex.Message);
            }
        }
    }
}


public class Phim
{
    public string TenPhim { get; set; }
    public string UrlHinhAnh { get; set; }
    public string UrlChiTiet { get; set; }
    public double GiaVeChuan { get; set; }
    public List<int> PhongChieu { get; set; }

    public string MoTa { get; set; }

    public Phim()
    {
        PhongChieu = new List<int> { 1, 2, 3 };
        MoTa = "Đang cập nhật...";
    }
}