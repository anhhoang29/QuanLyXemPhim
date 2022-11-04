using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private static List<String> maVe = new List<string>();
        private static float totalPrice = 0;

        public object Of { get; private set; }

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
                    int col = count % 10;
                    int row = (count / 10) + 65;
                    Button btn = new Button() { Width = 80, Height = 30 };
                    btn.Text = Convert.ToChar(row).ToString() + " - " + col.ToString();
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
            Button btn = (sender as Button);
            String id = (btn.Tag as Ve).Id.ToString();
            if (btn.BackColor == Color.Yellow)
            {
                btn.BackColor = Color.LightGoldenrodYellow;
                maVe.Remove(id);
                totalPrice -= getSingleTicketPrice(Convert.ToInt32(id));
            }
            else
            {
                btn.BackColor = Color.Yellow;
                maVe.Add(id);
                totalPrice += getSingleTicketPrice(Convert.ToInt32(id));
            }

            txtTotal.Text = totalPrice.ToString() + " VNĐ";

            Debug.WriteLine("/n");
            foreach (String mv in maVe)
            {
                Debug.Write(mv + " ");
            }
                
        }

       

        // lấy giá của một vế
        private float getSingleTicketPrice(int maVe)
        {
            return VeBUS.Instance.getPriceOfTicketBUS(maVe);
        }
      
        // thanh toán
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (VeBUS.Instance.updateListTicket(maVe))
            {
                MessageBox.Show("Đặt vé thành công");
            }
            else
            {
                MessageBox.Show("Đặt vé thất bại");
            }

            totalPrice = 0;
            maVe.Clear();
            flpSeat.Controls.Clear();
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            flpSeat.Controls.Clear();
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
            maVe.Clear();
            totalPrice = 0;

            txtTotal.ResetText();
        }
    }
}
               