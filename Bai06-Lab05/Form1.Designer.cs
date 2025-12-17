namespace Bai06_Lab05
{
    partial class Form1
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
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lstview = new System.Windows.Forms.ListView();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCompose = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImapHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImapPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.webBody = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(109, 10);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(261, 30);
            this.txtusername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(109, 44);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(261, 30);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // lstview
            // 
            this.lstview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstview.FullRowSelect = true;
            this.lstview.GridLines = true;
            this.lstview.HideSelection = false;
            this.lstview.Location = new System.Drawing.Point(805, 12);
            this.lstview.Margin = new System.Windows.Forms.Padding(2);
            this.lstview.MultiSelect = false;
            this.lstview.Name = "lstview";
            this.lstview.Size = new System.Drawing.Size(469, 596);
            this.lstview.TabIndex = 5;
            this.lstview.UseCompatibleStateImageBehavior = false;
            this.lstview.View = System.Windows.Forms.View.Details;
            this.lstview.SelectedIndexChanged += new System.EventHandler(this.lstview_SelectedIndexChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(387, 14);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(131, 26);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(522, 14);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(131, 26);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(387, 49);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 26);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh Inbox";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCompose
            // 
            this.btnCompose.Location = new System.Drawing.Point(522, 48);
            this.btnCompose.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(131, 26);
            this.btnCompose.TabIndex = 9;
            this.btnCompose.Text = "Compose/Send";
            this.btnCompose.UseVisualStyleBackColor = true;
            this.btnCompose.Click += new System.EventHandler(this.btnCompose_Click);
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(657, 14);
            this.btnReply.Margin = new System.Windows.Forms.Padding(2);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(123, 60);
            this.btnReply.TabIndex = 10;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "IMAP:";
            // 
            // txtImapHost
            // 
            this.txtImapHost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImapHost.Location = new System.Drawing.Point(84, 79);
            this.txtImapHost.Margin = new System.Windows.Forms.Padding(2);
            this.txtImapHost.Name = "txtImapHost";
            this.txtImapHost.Size = new System.Drawing.Size(168, 27);
            this.txtImapHost.TabIndex = 12;
            this.txtImapHost.Text = "imap.gmail.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(259, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Port:";
            // 
            // txtImapPort
            // 
            this.txtImapPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImapPort.Location = new System.Drawing.Point(303, 79);
            this.txtImapPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtImapPort.Name = "txtImapPort";
            this.txtImapPort.Size = new System.Drawing.Size(67, 27);
            this.txtImapPort.TabIndex = 14;
            this.txtImapPort.Text = "993";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "SMTP:";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmtpHost.Location = new System.Drawing.Point(453, 79);
            this.txtSmtpHost.Margin = new System.Windows.Forms.Padding(2);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(168, 27);
            this.txtSmtpHost.TabIndex = 16;
            this.txtSmtpHost.Text = "smtp.gmail.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(627, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Port:";
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmtpPort.Location = new System.Drawing.Point(671, 79);
            this.txtSmtpPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(85, 27);
            this.txtSmtpPort.TabIndex = 18;
            this.txtSmtpPort.Text = "465";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "From:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(77, 117);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(15, 20);
            this.lblFrom.TabIndex = 20;
            this.lblFrom.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Subject:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(93, 141);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(15, 20);
            this.lblSubject.TabIndex = 22;
            this.lblSubject.Text = "-";
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(435, 173);
            this.txtBody.Margin = new System.Windows.Forms.Padding(2);
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.Size = new System.Drawing.Size(321, 321);
            this.txtBody.TabIndex = 23;
            this.txtBody.Text = "";
            // 
            // webBody
            // 
            this.webBody.Location = new System.Drawing.Point(21, 173);
            this.webBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBody.Name = "webBody";
            this.webBody.Size = new System.Drawing.Size(759, 435);
            this.webBody.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 632);
            this.Controls.Add(this.webBody);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSmtpPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSmtpHost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImapPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtImapHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.btnCompose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lstview);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtusername);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Bai06 - Email Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.ListView lstview;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImapHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImapPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.WebBrowser webBody;
    }
}
