using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05_Lab05
{
    public partial class uc_RandomContribute : UserControl
    {
        private BindingSource bindingSource1 = new BindingSource();

        public uc_RandomContribute()
        {
            InitializeComponent();
        }
        /*
         * private void HienThiHinhAnhTuLinkAsync(string urlHinhAnh)
            {
                try
                {
                    if (string.IsNullOrEmpty(urlHinhAnh))
                    {
                        MessageBox.Show("URL hình ảnh không được rỗng.");
                        return;
                    }

                    // Đặt một hình ảnh "Loading..." tạm thời (tùy chọn)
                    // pictureBoxMonAn.Image = Properties.Resources.LoadingIcon; 
        
                    // Sử dụng phương thức LoadAsync của PictureBox
                    pictureBoxMonAn.LoadAsync(urlHinhAnh);
        
                    // Có thể thêm sự kiện xử lý khi tải xong hoặc lỗi (tùy chọn)
                    pictureBoxMonAn.LoadCompleted += PictureBoxMonAn_LoadCompleted;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Lỗi khởi tạo tải hình ảnh: {ex.Message}");
                }
            }

            // Xử lý sự kiện khi việc tải hình ảnh hoàn tất (cả thành công và thất bại)
            private void PictureBoxMonAn_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                // Kiểm tra xem có lỗi xảy ra trong quá trình tải không
                if (e.Error != null)
                {
                    MessageBox.Show($"Tải hình ảnh thất bại: {e.Error.Message}");
                    // Đặt lại hình ảnh lỗi (nếu cần)
                    // pictureBoxMonAn.Image = Properties.Resources.ErrorImage; 
                }
                // Nếu không có lỗi, hình ảnh đã được hiển thị thành công.
            }

            // Cách gọi hàm:
            string link = "https://cdn.tgdd.vn/2020/12/content/2-800x500-10.jpg";
            HienThiHinhAnhTuLinkAsync(link);
         */
        private void LoadImageAsync(string urlImage)
        {
            try
            {
                if(string.IsNullOrEmpty(urlImage))
                {
                    MessageBox.Show("URL hình ảnh không được rỗng.");
                    return;
                }
                ptbImage.LoadAsync(urlImage);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi tải hình ảnh: " + ex.Message);
            }
        }
        public void LoadData(DataTable dataTable)
        {
            if(dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }
            bindingSource1.DataSource = dataTable;
            lblCachLam.DataBindings.Clear();
            lblId.DataBindings.Clear();
            lblNameFood.DataBindings.Clear();
            lblNguoiDongGop.DataBindings.Clear();
            lblNguyenLieu.DataBindings.Clear();
            ptbImage.DataBindings.Clear();

            lblCachLam.DataBindings.Add("Text", bindingSource1, "CachLam");
            lblId.DataBindings.Add("Text", bindingSource1, "Id");
            lblNameFood.DataBindings.Add("Text", bindingSource1, "TenMonAn");
            lblNguoiDongGop.DataBindings.Add("Text", bindingSource1, "NguoiDongGop");
            lblNguyenLieu.DataBindings.Add("Text", bindingSource1, "NguyenLieu");
            if (bindingSource1.Current is DataRowView rowView)
            {
                string urlImage = rowView["HinhAnh"].ToString();
                LoadImageAsync(urlImage);
            }
            bindingSource1.MoveFirst();
        }

        private void uc_RandomContribute_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
