
namespace QuanLyXemPhim.frmAdminUserControl.FeatureViewUserControl
{
    partial class FormatMovieUC
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboFormat_MovieID = new System.Windows.Forms.ComboBox();
            this.lblFormat_MovieName = new System.Windows.Forms.Label();
            this.lblFormat_MovieID = new System.Windows.Forms.Label();
            this.lblFormatID = new System.Windows.Forms.Label();
            this.txtFormat_MovieName = new System.Windows.Forms.TextBox();
            this.txtFormatID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowFormat = new System.Windows.Forms.Button();
            this.btnUpdateFormat = new System.Windows.Forms.Button();
            this.btnDeleteFormat = new System.Windows.Forms.Button();
            this.btnInsertFormat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvFormat = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboFormat_MovieID);
            this.panel3.Controls.Add(this.lblFormat_MovieName);
            this.panel3.Controls.Add(this.lblFormat_MovieID);
            this.panel3.Controls.Add(this.lblFormatID);
            this.panel3.Controls.Add(this.txtFormat_MovieName);
            this.panel3.Controls.Add(this.txtFormatID);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(821, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 639);
            this.panel3.TabIndex = 0;
            // 
            // cboFormat_MovieID
            // 
            this.cboFormat_MovieID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat_MovieID.FormattingEnabled = true;
            this.cboFormat_MovieID.Location = new System.Drawing.Point(170, 78);
            this.cboFormat_MovieID.Name = "cboFormat_MovieID";
            this.cboFormat_MovieID.Size = new System.Drawing.Size(249, 24);
            this.cboFormat_MovieID.TabIndex = 21;
            // 
            // lblFormat_MovieName
            // 
            this.lblFormat_MovieName.AutoSize = true;
            this.lblFormat_MovieName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_MovieName.Location = new System.Drawing.Point(12, 112);
            this.lblFormat_MovieName.Name = "lblFormat_MovieName";
            this.lblFormat_MovieName.Size = new System.Drawing.Size(94, 23);
            this.lblFormat_MovieName.TabIndex = 17;
            this.lblFormat_MovieName.Text = "Tên phim:";
            // 
            // lblFormat_MovieID
            // 
            this.lblFormat_MovieID.AutoSize = true;
            this.lblFormat_MovieID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_MovieID.Location = new System.Drawing.Point(12, 79);
            this.lblFormat_MovieID.Name = "lblFormat_MovieID";
            this.lblFormat_MovieID.Size = new System.Drawing.Size(90, 23);
            this.lblFormat_MovieID.TabIndex = 18;
            this.lblFormat_MovieID.Text = "Mã phim:";
            // 
            // lblFormatID
            // 
            this.lblFormatID.AutoSize = true;
            this.lblFormatID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatID.Location = new System.Drawing.Point(12, 17);
            this.lblFormatID.Name = "lblFormatID";
            this.lblFormatID.Size = new System.Drawing.Size(130, 23);
            this.lblFormatID.TabIndex = 19;
            this.lblFormatID.Text = "Mã định dạng:";
            // 
            // txtFormat_MovieName
            // 
            this.txtFormat_MovieName.Location = new System.Drawing.Point(170, 111);
            this.txtFormat_MovieName.Name = "txtFormat_MovieName";
            this.txtFormat_MovieName.ReadOnly = true;
            this.txtFormat_MovieName.Size = new System.Drawing.Size(249, 22);
            this.txtFormat_MovieName.TabIndex = 13;
            // 
            // txtFormatID
            // 
            this.txtFormatID.Location = new System.Drawing.Point(170, 16);
            this.txtFormatID.Name = "txtFormatID";
            this.txtFormatID.Size = new System.Drawing.Size(249, 22);
            this.txtFormatID.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowFormat);
            this.panel1.Controls.Add(this.btnUpdateFormat);
            this.panel1.Controls.Add(this.btnDeleteFormat);
            this.panel1.Controls.Add(this.btnInsertFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 64);
            this.panel1.TabIndex = 4;
            // 
            // btnShowFormat
            // 
            this.btnShowFormat.Location = new System.Drawing.Point(328, 4);
            this.btnShowFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowFormat.Name = "btnShowFormat";
            this.btnShowFormat.Size = new System.Drawing.Size(100, 57);
            this.btnShowFormat.TabIndex = 11;
            this.btnShowFormat.Text = "Xem";
            this.btnShowFormat.UseVisualStyleBackColor = true;
            // 
            // btnUpdateFormat
            // 
            this.btnUpdateFormat.Location = new System.Drawing.Point(220, 4);
            this.btnUpdateFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateFormat.Name = "btnUpdateFormat";
            this.btnUpdateFormat.Size = new System.Drawing.Size(100, 57);
            this.btnUpdateFormat.TabIndex = 10;
            this.btnUpdateFormat.Text = "Sửa";
            this.btnUpdateFormat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFormat
            // 
            this.btnDeleteFormat.Location = new System.Drawing.Point(112, 4);
            this.btnDeleteFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFormat.Name = "btnDeleteFormat";
            this.btnDeleteFormat.Size = new System.Drawing.Size(100, 57);
            this.btnDeleteFormat.TabIndex = 9;
            this.btnDeleteFormat.Text = "Xóa";
            this.btnDeleteFormat.UseVisualStyleBackColor = true;
            // 
            // btnInsertFormat
            // 
            this.btnInsertFormat.Location = new System.Drawing.Point(4, 4);
            this.btnInsertFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertFormat.Name = "btnInsertFormat";
            this.btnInsertFormat.Size = new System.Drawing.Size(100, 57);
            this.btnInsertFormat.TabIndex = 8;
            this.btnInsertFormat.Text = "Thêm";
            this.btnInsertFormat.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvFormat);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 639);
            this.panel2.TabIndex = 5;
            // 
            // dtgvFormat
            // 
            this.dtgvFormat.AllowUserToAddRows = false;
            this.dtgvFormat.AllowUserToDeleteRows = false;
            this.dtgvFormat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFormat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvFormat.Location = new System.Drawing.Point(0, 0);
            this.dtgvFormat.Name = "dtgvFormat";
            this.dtgvFormat.ReadOnly = true;
            this.dtgvFormat.RowHeadersWidth = 51;
            this.dtgvFormat.Size = new System.Drawing.Size(821, 639);
            this.dtgvFormat.TabIndex = 9;
            // 
            // FormatMovieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormatMovieUC";
            this.Size = new System.Drawing.Size(1271, 639);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFormat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboFormat_MovieID;
        private System.Windows.Forms.Label lblFormat_MovieName;
        private System.Windows.Forms.Label lblFormat_MovieID;
        private System.Windows.Forms.Label lblFormatID;
        private System.Windows.Forms.TextBox txtFormat_MovieName;
        private System.Windows.Forms.TextBox txtFormatID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowFormat;
        private System.Windows.Forms.Button btnUpdateFormat;
        private System.Windows.Forms.Button btnDeleteFormat;
        private System.Windows.Forms.Button btnInsertFormat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvFormat;
    }
}
