using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05_Lab05
{
    public partial class DishUserControl : UserControl
    {
        public Dish Dish { get; set; }

        public DishUserControl(Dish dish)
        {
            InitializeComponent();
            Dish = dish;
            if (Dish != null) 
            {
                LoadData();
            }
        }

        private async void LoadData()
        {
            if (Dish == null) return; 

            lblName.Text = Dish.Name;
            lblPrice.Text = Dish.Price.ToString("C0");
            lblAddress.Text = Dish.Address;
            lblContributor.Text = $"{Dish.Contributor ?? "Không xác định"}";
            if (!string.IsNullOrEmpty(Dish.Image))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        byte[] imageBytes = await client.GetByteArrayAsync(Dish.Image);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            picImage.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception)
                {
                    picImage.Image = null; 
                }
            }
            
        }
    }
}