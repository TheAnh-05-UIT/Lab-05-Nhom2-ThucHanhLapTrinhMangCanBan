namespace Bai06_Lab05
{
    partial class FormSend
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
            this.txtto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbody = new System.Windows.Forms.RichTextBox();
            this.chkhtml = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstattach = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtto
            // 
            this.txtto.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtto.Location = new System.Drawing.Point(146, 20);
            this.txtto.Name = "txtto";
            this.txtto.Size = new System.Drawing.Size(628, 43);
            this.txtto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject:";
            // 
            // txtsubject
            // 
            this.txtsubject.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubject.Location = new System.Drawing.Point(146, 75);
            this.txtsubject.Name = "txtsubject";
            this.txtsubject.Size = new System.Drawing.Size(628, 43);
            this.txtsubject.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Body:";
            // 
            // txtbody
            // 
            this.txtbody.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbody.Location = new System.Drawing.Point(31, 220);
            this.txtbody.Name = "txtbody";
            this.txtbody.Size = new System.Drawing.Size(743, 320);
            this.txtbody.TabIndex = 5;
            this.txtbody.Text = "";
            // 
            // chkhtml
            // 
            this.chkhtml.AutoSize = true;
            this.chkhtml.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkhtml.Location = new System.Drawing.Point(146, 132);
            this.chkhtml.Name = "chkhtml";
            this.chkhtml.Size = new System.Drawing.Size(123, 36);
            this.chkhtml.TabIndex = 6;
            this.chkhtml.Text = "HTML";
            this.chkhtml.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 558);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Attachments:";
            // 
            // lstattach
            // 
            this.lstattach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstattach.FormattingEnabled = true;
            this.lstattach.ItemHeight = 32;
            this.lstattach.Location = new System.Drawing.Point(31, 596);
            this.lstattach.Name = "lstattach";
            this.lstattach.Size = new System.Drawing.Size(520, 132);
            this.lstattach.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(579, 596);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(195, 45);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add file...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(579, 654);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(195, 45);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(579, 711);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(195, 50);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FormSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 786);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstattach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkhtml);
            this.Controls.Add(this.txtbody);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtto);
            this.Name = "FormSend";
            this.Text = "FormSend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtbody;
        private System.Windows.Forms.CheckBox chkhtml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstattach;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSend;
    }
}
