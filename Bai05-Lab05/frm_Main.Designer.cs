namespace Bai05_Lab05
{
    partial class frm_Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAnGiGio = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemMonAn = new Guna.UI2.WinForms.Guna2Button();
            this.tabControlMain = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPageAll = new System.Windows.Forms.TabPage();
            this.flpAll = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageDongGop = new System.Windows.Forms.TabPage();
            this.flpMy = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cobPage = new System.Windows.Forms.ComboBox();
            this.cobPageSize = new System.Windows.Forms.ComboBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnContributeGmail = new Guna.UI2.WinForms.Guna2Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageAll.SuspendLayout();
            this.tabPageDongGop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // btnAnGiGio
            // 
            this.btnAnGiGio.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAnGiGio.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAnGiGio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAnGiGio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAnGiGio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAnGiGio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnGiGio.ForeColor = System.Drawing.Color.Black;
            this.btnAnGiGio.Location = new System.Drawing.Point(341, 50);
            this.btnAnGiGio.Name = "btnAnGiGio";
            this.btnAnGiGio.Size = new System.Drawing.Size(128, 45);
            this.btnAnGiGio.TabIndex = 1;
            this.btnAnGiGio.Text = "Ăn gì giờ?";
            this.btnAnGiGio.Click += new System.EventHandler(this.btnAnGiGio_Click);
            // 
            // btnThemMonAn
            // 
            this.btnThemMonAn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMonAn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMonAn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemMonAn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemMonAn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnThemMonAn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMonAn.ForeColor = System.Drawing.Color.Black;
            this.btnThemMonAn.Location = new System.Drawing.Point(475, 50);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(128, 45);
            this.btnThemMonAn.TabIndex = 2;
            this.btnThemMonAn.Text = "Thêm món ăn";
            this.btnThemMonAn.Click += new System.EventHandler(this.btnThemMonAn_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPageAll);
            this.tabControlMain.Controls.Add(this.tabPageDongGop);
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.Location = new System.Drawing.Point(18, 101);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(723, 300);
            this.tabControlMain.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonHoverState.FillColor = System.Drawing.Color.RosyBrown;
            this.tabControlMain.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControlMain.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tabControlMain.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonIdleState.FillColor = System.Drawing.Color.LightGray;
            this.tabControlMain.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonIdleState.ForeColor = System.Drawing.Color.Black;
            this.tabControlMain.TabButtonIdleState.InnerColor = System.Drawing.Color.Black;
            this.tabControlMain.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonSelectedState.FillColor = System.Drawing.Color.LightGray;
            this.tabControlMain.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tabControlMain.TabButtonSelectedState.InnerColor = System.Drawing.Color.Black;
            this.tabControlMain.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.TabMenuBackColor = System.Drawing.Color.LightGray;
            // 
            // tabPageAll
            // 
            this.tabPageAll.AutoScroll = true;
            this.tabPageAll.Controls.Add(this.flpAll);
            this.tabPageAll.ForeColor = System.Drawing.Color.Coral;
            this.tabPageAll.Location = new System.Drawing.Point(184, 4);
            this.tabPageAll.Name = "tabPageAll";
            this.tabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAll.Size = new System.Drawing.Size(535, 292);
            this.tabPageAll.TabIndex = 0;
            this.tabPageAll.Text = "All";
            this.tabPageAll.UseVisualStyleBackColor = true;
            // 
            // flpAll
            // 
            this.flpAll.AutoScroll = true;
            this.flpAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAll.Location = new System.Drawing.Point(3, 3);
            this.flpAll.Name = "flpAll";
            this.flpAll.Size = new System.Drawing.Size(529, 286);
            this.flpAll.TabIndex = 0;
            // 
            // tabPageDongGop
            // 
            this.tabPageDongGop.AutoScroll = true;
            this.tabPageDongGop.Controls.Add(this.flpMy);
            this.tabPageDongGop.ForeColor = System.Drawing.Color.Coral;
            this.tabPageDongGop.Location = new System.Drawing.Point(184, 4);
            this.tabPageDongGop.Name = "tabPageDongGop";
            this.tabPageDongGop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDongGop.Size = new System.Drawing.Size(535, 292);
            this.tabPageDongGop.TabIndex = 1;
            this.tabPageDongGop.Text = "Tôi đóng góp";
            this.tabPageDongGop.UseVisualStyleBackColor = true;
            // 
            // flpMy
            // 
            this.flpMy.AutoScroll = true;
            this.flpMy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMy.Location = new System.Drawing.Point(3, 3);
            this.flpMy.Name = "flpMy";
            this.flpMy.Size = new System.Drawing.Size(529, 286);
            this.flpMy.TabIndex = 0;
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelLogout.Location = new System.Drawing.Point(154, 476);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(44, 13);
            this.linkLabelLogout.TabIndex = 4;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "Logout";
            this.linkLabelLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogout_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(204, 476);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(104, 20);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblWelcome.Location = new System.Drawing.Point(48, 476);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(95, 13);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.Text = "Welcome, Quang";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(377, 435);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(32, 13);
            this.lblPage.TabIndex = 7;
            this.lblPage.Text = "Page";
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageSize.Location = new System.Drawing.Point(511, 435);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(54, 13);
            this.lblPageSize.TabIndex = 8;
            this.lblPageSize.Text = "Page size";
            // 
            // cobPage
            // 
            this.cobPage.FormattingEnabled = true;
            this.cobPage.Location = new System.Drawing.Point(423, 432);
            this.cobPage.Name = "cobPage";
            this.cobPage.Size = new System.Drawing.Size(44, 21);
            this.cobPage.TabIndex = 9;
            // 
            // cobPageSize
            // 
            this.cobPageSize.FormattingEnabled = true;
            this.cobPageSize.Location = new System.Drawing.Point(580, 432);
            this.cobPageSize.Name = "cobPageSize";
            this.cobPageSize.Size = new System.Drawing.Size(44, 21);
            this.cobPageSize.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(609, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 45);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnContributeGmail
            // 
            this.btnContributeGmail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnContributeGmail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnContributeGmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContributeGmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnContributeGmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnContributeGmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContributeGmail.ForeColor = System.Drawing.Color.Black;
            this.btnContributeGmail.Location = new System.Drawing.Point(207, 50);
            this.btnContributeGmail.Name = "btnContributeGmail";
            this.btnContributeGmail.Size = new System.Drawing.Size(128, 45);
            this.btnContributeGmail.TabIndex = 12;
            this.btnContributeGmail.Text = "Đóng góp gmail";
            this.btnContributeGmail.Click += new System.EventHandler(this.btnContributeGmail_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 508);
            this.Controls.Add(this.btnContributeGmail);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cobPageSize);
            this.Controls.Add(this.cobPage);
            this.Controls.Add(this.lblPageSize);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.linkLabelLogout);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.btnThemMonAn);
            this.Controls.Add(this.btnAnGiGio);
            this.Controls.Add(this.lblTitle);
            this.Name = "frm_Main";
            this.Text = "Hôm nay ăn gì?";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAll.ResumeLayout(false);
            this.tabPageDongGop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnAnGiGio;
        private Guna.UI2.WinForms.Guna2Button btnThemMonAn;
        private Guna.UI2.WinForms.Guna2TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageAll;
        private System.Windows.Forms.TabPage tabPageDongGop;
        private System.Windows.Forms.LinkLabel linkLabelLogout;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cobPage;
        private System.Windows.Forms.ComboBox cobPageSize;
        private System.Windows.Forms.FlowLayoutPanel flpAll;
        private System.Windows.Forms.FlowLayoutPanel flpMy;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnContributeGmail;
    }
}

