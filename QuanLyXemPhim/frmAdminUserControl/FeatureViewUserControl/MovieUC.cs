using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXemPhim.frmAdminUserControl.FeatureViewUserControl
{
    public partial class MovieUC : UserControl
    {
        BindingSource movieList = new BindingSource();

        public MovieUC()
        {
            InitializeComponent();
            dtgvMovie.DataSource = movieList;
            hienThiDanhSachPhim();
        }

        private void btnAddMovie_Click_1(object sender, EventArgs e)
        {

        }

        public void bindingMovie()
        {
            txtMovieID.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "MaPhim", true, DataSourceUpdateMode.Never));
            txtMovieName.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "TenPhim", true, DataSourceUpdateMode.Never));
            txtMovieDesc.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "MoTa", true, DataSourceUpdateMode.Never));
            txtMovieLength.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "ThoiLuong", true, DataSourceUpdateMode.Never));
            dtmMovieStart.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "NgayKhoiChieu", true, DataSourceUpdateMode.Never));
            dtmMovieEnd.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "NgayKetThuc", true, DataSourceUpdateMode.Never));
            txtMovieCountry.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "QuocGia", true, DataSourceUpdateMode.Never));
            txtMovieActor.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "DaoDien", true, DataSourceUpdateMode.Never));
            txtMovieYearLimit.DataBindings.Add(new Binding("Text", dtgvMovie.DataSource, "GioiHanTuoi", true, DataSourceUpdateMode.Never));
        }
        
        public void hienThiDanhSachPhim()
        {
            PhimBUS.Instance.hienThiPhim(movieList);
            bindingMovie();
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            string MaPhim = dtgvMovie.SelectedCells[0].OwningRow.Cells["MaPhim"].Value.ToString();
            string TenPhim = txtMovieName.Text;
            string MoTa = txtMovieDesc.Text;
            double ThoiLuong = Convert.ToDouble(txtMovieLength.Text);
            DateTime NgayBatDau = dtmMovieStart.Value;
            DateTime NgayKetThuc = dtmMovieEnd.Value;
            string QuocGia = txtMovieCountry.Text;
            string DienVien = txtMovieActor.Text;
            int GioiHanTuoi = Convert.ToInt32(txtMovieYearLimit.Text);

            PhimBUS.Instance.suaDanhSachPhim(MaPhim, TenPhim, MoTa, ThoiLuong, NgayBatDau, NgayKetThuc,
                QuocGia, DienVien, GioiHanTuoi);
            PhimBUS.Instance.hienThiPhim(movieList);
        }
    }
}
