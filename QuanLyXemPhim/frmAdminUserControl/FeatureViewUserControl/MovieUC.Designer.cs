
namespace QuanLyXemPhim.frmAdminUserControl.FeatureViewUserControl
{
    partial class MovieUC
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
            this.btnUpLoadPictureFilm = new System.Windows.Forms.Button();
            this.picFilm = new System.Windows.Forms.PictureBox();
            this.clbMovieGenre = new System.Windows.Forms.CheckedListBox();
            this.dtmMovieEnd = new System.Windows.Forms.DateTimePicker();
            this.dtmMovieStart = new System.Windows.Forms.DateTimePicker();
            this.txtMovieYearLimit = new System.Windows.Forms.TextBox();
            this.txtMovieActor = new System.Windows.Forms.TextBox();
            this.txtMovieCountry = new System.Windows.Forms.TextBox();
            this.dtgvMovie = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMovieLength = new System.Windows.Forms.TextBox();
            this.lblMovieEndDate = new System.Windows.Forms.Label();
            this.lblMovieStartDate = new System.Windows.Forms.Label();
            this.lblMovieLength = new System.Windows.Forms.Label();
            this.txtMovieDesc = new System.Windows.Forms.TextBox();
            this.lblMovieYearLimit = new System.Windows.Forms.Label();
            this.lblMovieGenre = new System.Windows.Forms.Label();
            this.lblMovieActor = new System.Windows.Forms.Label();
            this.lblMovieCountry = new System.Windows.Forms.Label();
            this.lblMovieDesc = new System.Windows.Forms.Label();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.txtMovieID = new System.Windows.Forms.TextBox();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.btnUpdateMovie = new System.Windows.Forms.Button();
            this.btnDeleteMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.panel47 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpLoadPictureFilm
            // 
            this.btnUpLoadPictureFilm.Location = new System.Drawing.Point(1094, 289);
            this.btnUpLoadPictureFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpLoadPictureFilm.Name = "btnUpLoadPictureFilm";
            this.btnUpLoadPictureFilm.Size = new System.Drawing.Size(143, 51);
            this.btnUpLoadPictureFilm.TabIndex = 56;
            this.btnUpLoadPictureFilm.Text = "Chọn hình ảnh";
            this.btnUpLoadPictureFilm.UseVisualStyleBackColor = true;
            // 
            // picFilm
            // 
            this.picFilm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFilm.Location = new System.Drawing.Point(1061, 2);
            this.picFilm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picFilm.Name = "picFilm";
            this.picFilm.Size = new System.Drawing.Size(209, 271);
            this.picFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilm.TabIndex = 55;
            this.picFilm.TabStop = false;
            // 
            // clbMovieGenre
            // 
            this.clbMovieGenre.CheckOnClick = true;
            this.clbMovieGenre.FormattingEnabled = true;
            this.clbMovieGenre.Location = new System.Drawing.Point(18, 188);
            this.clbMovieGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbMovieGenre.MultiColumn = true;
            this.clbMovieGenre.Name = "clbMovieGenre";
            this.clbMovieGenre.Size = new System.Drawing.Size(374, 119);
            this.clbMovieGenre.TabIndex = 54;
            // 
            // dtmMovieEnd
            // 
            this.dtmMovieEnd.CustomFormat = "yyyy/MM/dd";
            this.dtmMovieEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmMovieEnd.Location = new System.Drawing.Point(763, 106);
            this.dtmMovieEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtmMovieEnd.Name = "dtmMovieEnd";
            this.dtmMovieEnd.Size = new System.Drawing.Size(226, 26);
            this.dtmMovieEnd.TabIndex = 53;
            // 
            // dtmMovieStart
            // 
            this.dtmMovieStart.CustomFormat = "yyyy/MM/dd";
            this.dtmMovieStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmMovieStart.Location = new System.Drawing.Point(763, 61);
            this.dtmMovieStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtmMovieStart.Name = "dtmMovieStart";
            this.dtmMovieStart.Size = new System.Drawing.Size(226, 26);
            this.dtmMovieStart.TabIndex = 52;
            // 
            // txtMovieYearLimit
            // 
            this.txtMovieYearLimit.Location = new System.Drawing.Point(763, 249);
            this.txtMovieYearLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieYearLimit.Name = "txtMovieYearLimit";
            this.txtMovieYearLimit.Size = new System.Drawing.Size(226, 26);
            this.txtMovieYearLimit.TabIndex = 50;
            // 
            // txtMovieActor
            // 
            this.txtMovieActor.Location = new System.Drawing.Point(763, 206);
            this.txtMovieActor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieActor.Name = "txtMovieActor";
            this.txtMovieActor.Size = new System.Drawing.Size(226, 26);
            this.txtMovieActor.TabIndex = 49;
            // 
            // txtMovieCountry
            // 
            this.txtMovieCountry.Location = new System.Drawing.Point(763, 160);
            this.txtMovieCountry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieCountry.Name = "txtMovieCountry";
            this.txtMovieCountry.Size = new System.Drawing.Size(226, 26);
            this.txtMovieCountry.TabIndex = 48;
            // 
            // dtgvMovie
            // 
            this.dtgvMovie.AllowUserToAddRows = false;
            this.dtgvMovie.AllowUserToDeleteRows = false;
            this.dtgvMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMovie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvMovie.Location = new System.Drawing.Point(0, 428);
            this.dtgvMovie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvMovie.Name = "dtgvMovie";
            this.dtgvMovie.ReadOnly = true;
            this.dtgvMovie.RowHeadersWidth = 51;
            this.dtgvMovie.Size = new System.Drawing.Size(1430, 371);
            this.dtgvMovie.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpLoadPictureFilm);
            this.panel2.Controls.Add(this.picFilm);
            this.panel2.Controls.Add(this.clbMovieGenre);
            this.panel2.Controls.Add(this.dtmMovieEnd);
            this.panel2.Controls.Add(this.dtmMovieStart);
            this.panel2.Controls.Add(this.txtMovieYearLimit);
            this.panel2.Controls.Add(this.txtMovieActor);
            this.panel2.Controls.Add(this.txtMovieCountry);
            this.panel2.Controls.Add(this.txtMovieLength);
            this.panel2.Controls.Add(this.lblMovieEndDate);
            this.panel2.Controls.Add(this.lblMovieStartDate);
            this.panel2.Controls.Add(this.lblMovieLength);
            this.panel2.Controls.Add(this.txtMovieDesc);
            this.panel2.Controls.Add(this.lblMovieYearLimit);
            this.panel2.Controls.Add(this.lblMovieGenre);
            this.panel2.Controls.Add(this.lblMovieActor);
            this.panel2.Controls.Add(this.lblMovieCountry);
            this.panel2.Controls.Add(this.lblMovieDesc);
            this.panel2.Controls.Add(this.txtMovieName);
            this.panel2.Controls.Add(this.lblMovieName);
            this.panel2.Controls.Add(this.txtMovieID);
            this.panel2.Controls.Add(this.lblMovieID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1430, 348);
            this.panel2.TabIndex = 0;
            // 
            // txtMovieLength
            // 
            this.txtMovieLength.Location = new System.Drawing.Point(763, 20);
            this.txtMovieLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieLength.Name = "txtMovieLength";
            this.txtMovieLength.Size = new System.Drawing.Size(226, 26);
            this.txtMovieLength.TabIndex = 47;
            // 
            // lblMovieEndDate
            // 
            this.lblMovieEndDate.AutoSize = true;
            this.lblMovieEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieEndDate.Location = new System.Drawing.Point(568, 106);
            this.lblMovieEndDate.Name = "lblMovieEndDate";
            this.lblMovieEndDate.Size = new System.Drawing.Size(111, 26);
            this.lblMovieEndDate.TabIndex = 44;
            this.lblMovieEndDate.Text = "Ngày KT:";
            // 
            // lblMovieStartDate
            // 
            this.lblMovieStartDate.AutoSize = true;
            this.lblMovieStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieStartDate.Location = new System.Drawing.Point(568, 62);
            this.lblMovieStartDate.Name = "lblMovieStartDate";
            this.lblMovieStartDate.Size = new System.Drawing.Size(115, 26);
            this.lblMovieStartDate.TabIndex = 42;
            this.lblMovieStartDate.Text = "Ngày KC:";
            // 
            // lblMovieLength
            // 
            this.lblMovieLength.AutoSize = true;
            this.lblMovieLength.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieLength.Location = new System.Drawing.Point(568, 18);
            this.lblMovieLength.Name = "lblMovieLength";
            this.lblMovieLength.Size = new System.Drawing.Size(133, 26);
            this.lblMovieLength.TabIndex = 35;
            this.lblMovieLength.Text = "Thời lượng:";
            // 
            // txtMovieDesc
            // 
            this.txtMovieDesc.Location = new System.Drawing.Point(165, 112);
            this.txtMovieDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieDesc.Multiline = true;
            this.txtMovieDesc.Name = "txtMovieDesc";
            this.txtMovieDesc.Size = new System.Drawing.Size(226, 26);
            this.txtMovieDesc.TabIndex = 46;
            // 
            // lblMovieYearLimit
            // 
            this.lblMovieYearLimit.AutoSize = true;
            this.lblMovieYearLimit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieYearLimit.Location = new System.Drawing.Point(567, 249);
            this.lblMovieYearLimit.Name = "lblMovieYearLimit";
            this.lblMovieYearLimit.Size = new System.Drawing.Size(199, 32);
            this.lblMovieYearLimit.TabIndex = 41;
            this.lblMovieYearLimit.Text = "Giới Hạn Tuổi:";
            // 
            // lblMovieGenre
            // 
            this.lblMovieGenre.AutoSize = true;
            this.lblMovieGenre.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieGenre.Location = new System.Drawing.Point(12, 154);
            this.lblMovieGenre.Name = "lblMovieGenre";
            this.lblMovieGenre.Size = new System.Drawing.Size(123, 32);
            this.lblMovieGenre.TabIndex = 40;
            this.lblMovieGenre.Text = "Thể loại:";
            // 
            // lblMovieActor
            // 
            this.lblMovieActor.AutoSize = true;
            this.lblMovieActor.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieActor.Location = new System.Drawing.Point(567, 201);
            this.lblMovieActor.Name = "lblMovieActor";
            this.lblMovieActor.Size = new System.Drawing.Size(152, 32);
            this.lblMovieActor.TabIndex = 39;
            this.lblMovieActor.Text = "Diễn Viên: ";
            // 
            // lblMovieCountry
            // 
            this.lblMovieCountry.AutoSize = true;
            this.lblMovieCountry.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieCountry.Location = new System.Drawing.Point(567, 154);
            this.lblMovieCountry.Name = "lblMovieCountry";
            this.lblMovieCountry.Size = new System.Drawing.Size(141, 32);
            this.lblMovieCountry.TabIndex = 38;
            this.lblMovieCountry.Text = "Quốc Gia:";
            // 
            // lblMovieDesc
            // 
            this.lblMovieDesc.AutoSize = true;
            this.lblMovieDesc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieDesc.Location = new System.Drawing.Point(12, 106);
            this.lblMovieDesc.Name = "lblMovieDesc";
            this.lblMovieDesc.Size = new System.Drawing.Size(98, 32);
            this.lblMovieDesc.TabIndex = 37;
            this.lblMovieDesc.Text = "Mô tả:";
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(165, 68);
            this.txtMovieName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(226, 26);
            this.txtMovieName.TabIndex = 51;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieName.Location = new System.Drawing.Point(12, 61);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(143, 32);
            this.lblMovieName.TabIndex = 36;
            this.lblMovieName.Text = "Tên phim:";
            // 
            // txtMovieID
            // 
            this.txtMovieID.Location = new System.Drawing.Point(165, 20);
            this.txtMovieID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovieID.Name = "txtMovieID";
            this.txtMovieID.Size = new System.Drawing.Size(226, 26);
            this.txtMovieID.TabIndex = 45;
            // 
            // lblMovieID
            // 
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieID.Location = new System.Drawing.Point(12, 14);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(138, 32);
            this.lblMovieID.TabIndex = 43;
            this.lblMovieID.Text = "Mã phim:";
            // 
            // btnUpdateMovie
            // 
            this.btnUpdateMovie.Location = new System.Drawing.Point(248, 5);
            this.btnUpdateMovie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdateMovie.Name = "btnUpdateMovie";
            this.btnUpdateMovie.Size = new System.Drawing.Size(112, 71);
            this.btnUpdateMovie.TabIndex = 2;
            this.btnUpdateMovie.Text = "Sửa";
            this.btnUpdateMovie.UseVisualStyleBackColor = true;
            this.btnUpdateMovie.Click += new System.EventHandler(this.btnUpdateMovie_Click);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Location = new System.Drawing.Point(126, 7);
            this.btnDeleteMovie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(112, 69);
            this.btnDeleteMovie.TabIndex = 1;
            this.btnDeleteMovie.Text = "Xóa";
            this.btnDeleteMovie.UseVisualStyleBackColor = true;
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(4, 5);
            this.btnAddMovie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(112, 71);
            this.btnAddMovie.TabIndex = 0;
            this.btnAddMovie.Text = "Thêm";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click_1);
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.btnUpdateMovie);
            this.panel47.Controls.Add(this.btnDeleteMovie);
            this.panel47.Controls.Add(this.btnAddMovie);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel47.Location = new System.Drawing.Point(0, 348);
            this.panel47.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(1430, 80);
            this.panel47.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvMovie);
            this.panel1.Controls.Add(this.panel47);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1430, 799);
            this.panel1.TabIndex = 12;
            // 
            // MovieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MovieUC";
            this.Size = new System.Drawing.Size(1430, 799);
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMovie)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpLoadPictureFilm;
        private System.Windows.Forms.PictureBox picFilm;
        private System.Windows.Forms.CheckedListBox clbMovieGenre;
        private System.Windows.Forms.DateTimePicker dtmMovieEnd;
        private System.Windows.Forms.DateTimePicker dtmMovieStart;
        private System.Windows.Forms.TextBox txtMovieYearLimit;
        private System.Windows.Forms.TextBox txtMovieActor;
        private System.Windows.Forms.TextBox txtMovieCountry;
        private System.Windows.Forms.DataGridView dtgvMovie;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMovieLength;
        private System.Windows.Forms.Label lblMovieEndDate;
        private System.Windows.Forms.Label lblMovieStartDate;
        private System.Windows.Forms.Label lblMovieLength;
        private System.Windows.Forms.TextBox txtMovieDesc;
        private System.Windows.Forms.Label lblMovieYearLimit;
        private System.Windows.Forms.Label lblMovieGenre;
        private System.Windows.Forms.Label lblMovieActor;
        private System.Windows.Forms.Label lblMovieCountry;
        private System.Windows.Forms.Label lblMovieDesc;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.TextBox txtMovieID;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.Button btnUpdateMovie;
        private System.Windows.Forms.Button btnDeleteMovie;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Panel panel1;
    }
}
