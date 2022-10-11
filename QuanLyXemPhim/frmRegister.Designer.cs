
namespace QuanLyXemPhim
{
    partial class frmRegister
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
            this.resUsername = new System.Windows.Forms.Label();
            this.resSdt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxRole = new System.Windows.Forms.ComboBox();
            this.txtUsername_Resgister = new System.Windows.Forms.TextBox();
            this.txtResSDT = new System.Windows.Forms.TextBox();
            this.txtBorn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DangKy = new System.Windows.Forms.Button();
            this.Re_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resUsername
            // 
            this.resUsername.AutoSize = true;
            this.resUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resUsername.Location = new System.Drawing.Point(73, 50);
            this.resUsername.Name = "resUsername";
            this.resUsername.Size = new System.Drawing.Size(83, 25);
            this.resUsername.TabIndex = 0;
            this.resUsername.Text = "Họ Tên:";
            // 
            // resSdt
            // 
            this.resSdt.AutoSize = true;
            this.resSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resSdt.Location = new System.Drawing.Point(73, 108);
            this.resSdt.Name = "resSdt";
            this.resSdt.Size = new System.Drawing.Size(143, 25);
            this.resSdt.TabIndex = 1;
            this.resSdt.Text = "Số Điện Thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm Sinh:";
            // 
            // boxRole
            // 
            this.boxRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxRole.FormattingEnabled = true;
            this.boxRole.Location = new System.Drawing.Point(221, 225);
            this.boxRole.Name = "boxRole";
            this.boxRole.Size = new System.Drawing.Size(168, 33);
            this.boxRole.TabIndex = 3;
            // 
            // txtUsername_Resgister
            // 
            this.txtUsername_Resgister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername_Resgister.Location = new System.Drawing.Point(221, 45);
            this.txtUsername_Resgister.Name = "txtUsername_Resgister";
            this.txtUsername_Resgister.Size = new System.Drawing.Size(308, 30);
            this.txtUsername_Resgister.TabIndex = 4;
            // 
            // txtResSDT
            // 
            this.txtResSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResSDT.Location = new System.Drawing.Point(221, 105);
            this.txtResSDT.Name = "txtResSDT";
            this.txtResSDT.Size = new System.Drawing.Size(308, 30);
            this.txtResSDT.TabIndex = 5;
            // 
            // txtBorn
            // 
            this.txtBorn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorn.Location = new System.Drawing.Point(221, 167);
            this.txtBorn.Name = "txtBorn";
            this.txtBorn.Size = new System.Drawing.Size(308, 30);
            this.txtBorn.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nghề Nghiệp:";
            // 
            // DangKy
            // 
            this.DangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangKy.Location = new System.Drawing.Point(152, 299);
            this.DangKy.Name = "DangKy";
            this.DangKy.Size = new System.Drawing.Size(99, 34);
            this.DangKy.TabIndex = 8;
            this.DangKy.Text = "Đăng Ký";
            this.DangKy.UseVisualStyleBackColor = true;
            // 
            // Re_Thoat
            // 
            this.Re_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Re_Thoat.Location = new System.Drawing.Point(318, 299);
            this.Re_Thoat.Name = "Re_Thoat";
            this.Re_Thoat.Size = new System.Drawing.Size(112, 34);
            this.Re_Thoat.TabIndex = 9;
            this.Re_Thoat.Text = "Thoát";
            this.Re_Thoat.UseVisualStyleBackColor = true;
            this.Re_Thoat.Click += new System.EventHandler(this.Re_Thoat_Click);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(701, 373);
            this.Controls.Add(this.Re_Thoat);
            this.Controls.Add(this.DangKy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBorn);
            this.Controls.Add(this.txtResSDT);
            this.Controls.Add(this.txtUsername_Resgister);
            this.Controls.Add(this.boxRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resSdt);
            this.Controls.Add(this.resUsername);
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Thành Viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resUsername;
        private System.Windows.Forms.Label resSdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxRole;
        private System.Windows.Forms.TextBox txtUsername_Resgister;
        private System.Windows.Forms.TextBox txtResSDT;
        private System.Windows.Forms.TextBox txtBorn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DangKy;
        private System.Windows.Forms.Button Re_Thoat;
    }
}