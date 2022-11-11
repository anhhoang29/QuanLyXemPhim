using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXemPhim
{
    public partial class frmTheatre : Form
    {
        private string maCaChieu;
        public frmTheatre(string maCaChieu)
        {
            InitializeComponent();
            this.maCaChieu = maCaChieu;
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
        }
        
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.ShowDialog();
        }

        public void hienThiDanhSachChoNgoiTheoMaCaChieu(string maCaChieu)
        {
            int count = 0;
            List<Ve> danhSachVe = VeBUS.Instance.hienthiVe(maCaChieu);
            
            if(danhSachVe != null)
            {
                foreach (Ve ve in danhSachVe)
                {
                    int col = count % 10 + 1;
                    int row = (count / 10) + 65;
                    Button btn = new Button() { Width = 80, Height = 30 };
                    btn.Text = ve.MaCaChieu;
                    //btn.Text = Convert.ToChar(row).ToString() + " - " + col.ToString();
                    btn.Font = new Font("Arial", (float)10.5);
                    btn.Click += btn_Click;
                    btn.Tag = ve;

                    if (ve.TrangThai == 0)
                    {
                        btn.BackColor = Color.LightGoldenrodYellow;
                    }
                    else
                    {
                        btn.BackColor = Color.Gray;
                        btn.ForeColor = Color.White;
                    }

                    flpSeat.Controls.Add(btn);
                    count++;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string id = ((sender as Button).Tag as Ve).Id.ToString();
            MessageBox.Show("Id: " + id);
        }
    }
}
