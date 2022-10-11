using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QuanLyXemPhim
{
    public partial class frmStaff : Form
    {
        public frmStaff()
        {
            InitializeComponent();
        }
        private void LoadMovie()
        {

        }
        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Load lại form để cập nhật cơ sở dữ liệu
            this.OnLoad(null);
        }
        private void frmStaff_Load(object sender, EventArgs e)
        {
            LoadMovie();
            timer1.Start();
        }
        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                frmTheatre frm = new frmTheatre();
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }
        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void labelX_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChonVe_Click(object sender, EventArgs e)
        {
            frmTheatre frmTheatre = new frmTheatre();
            frmTheatre.ShowDialog();
        }
    }
}
