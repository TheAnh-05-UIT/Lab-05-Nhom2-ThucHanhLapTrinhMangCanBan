namespace Bai05_Lab05
{
    partial class DishUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPriceT = new System.Windows.Forms.Label();
            this.lblAddressT = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblContributorT = new System.Windows.Forms.Label();
            this.lblContributor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(145, 125);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblName.Location = new System.Drawing.Point(186, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // lblPriceT
            // 
            this.lblPriceT.AutoSize = true;
            this.lblPriceT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceT.Location = new System.Drawing.Point(187, 41);
            this.lblPriceT.Name = "lblPriceT";
            this.lblPriceT.Size = new System.Drawing.Size(30, 17);
            this.lblPriceT.TabIndex = 2;
            this.lblPriceT.Text = "Giá:";
            // 
            // lblAddressT
            // 
            this.lblAddressT.AutoSize = true;
            this.lblAddressT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressT.Location = new System.Drawing.Point(187, 68);
            this.lblAddressT.Name = "lblAddressT";
            this.lblAddressT.Size = new System.Drawing.Size(54, 17);
            this.lblAddressT.TabIndex = 3;
            this.lblAddressT.Text = "Địa chỉ: ";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(287, 68);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 17);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "label3";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(287, 41);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "label4";
            // 
            // lblContributorT
            // 
            this.lblContributorT.AutoSize = true;
            this.lblContributorT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContributorT.Location = new System.Drawing.Point(187, 96);
            this.lblContributorT.Name = "lblContributorT";
            this.lblContributorT.Size = new System.Drawing.Size(75, 17);
            this.lblContributorT.TabIndex = 6;
            this.lblContributorT.Text = "Đóng góp: ";
            // 
            // lblContributor
            // 
            this.lblContributor.AutoSize = true;
            this.lblContributor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContributor.Location = new System.Drawing.Point(287, 96);
            this.lblContributor.Name = "lblContributor";
            this.lblContributor.Size = new System.Drawing.Size(43, 17);
            this.lblContributor.TabIndex = 7;
            this.lblContributor.Text = "label6";
            // 
            // DishUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContributor);
            this.Controls.Add(this.lblContributorT);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblAddressT);
            this.Controls.Add(this.lblPriceT);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picImage);
            this.Name = "DishUserControl";
            this.Size = new System.Drawing.Size(479, 125);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPriceT;
        private System.Windows.Forms.Label lblAddressT;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblContributorT;
        private System.Windows.Forms.Label lblContributor;
    }
}
