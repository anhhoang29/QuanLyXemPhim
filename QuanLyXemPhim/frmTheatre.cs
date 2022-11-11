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
        private static float finalPrice = 0;
        private static int bonus = 0;
        

        public frmTheatre(string maCaChieu)
        {
            InitializeComponent();
            this.maCaChieu = maCaChieu;
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
        }
        
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer(this);
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
                    btn.Text = ve.MaGheNgoi;
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
                bonus--;
            }
            else
            {
                btn.BackColor = Color.Yellow;
                maVe.Add(id);
                totalPrice += getSingleTicketPrice(Convert.ToInt32(id));
                bonus++;
            }

            txtTotal.Text = totalPrice.ToString() + " VNĐ";
            finalPrice = totalPrice;
            txtPayment.Text = finalPrice.ToString() + " VNĐ";
            txtPlusPoint.Text = bonus.ToString();
                
        }

       

        // lấy giá của một vế
        private float getSingleTicketPrice(int maVe)
        {
            return VeBUS.Instance.getPriceOfTicketBUS(maVe);
        }
      
        // thanh toán
        private void btnPayment_Click(object sender, EventArgs e)
        {


            if (maVe.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé");
                return;
            }
            if (VeBUS.Instance.updateListTicket(maVe))
            {
                MessageBox.Show("Đặt vé thành công");
                if (txtCustomerName.Text != "" || txtCustomerName.Text != null)
                {
                    updatePoint(frmCustomer.phoneNumber.Trim(), Int32.Parse(txtPlusPoint.Text));
                }
            }
            else
            {
                MessageBox.Show("Đặt vé thất bại");
            }

            totalPrice = 0;
            finalPrice = 0;
            bonus = 0;
            maVe.Clear();
            flpSeat.Controls.Clear();
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
            resetPanels();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtPoint.Text != "" && txtPoint.Text != null)
            {
                CustomerBUS.Instance.rollbackPoint(Int32.Parse(txtPoint.Text), frmCustomer.phoneNumber);
            }
            
            flpSeat.Controls.Clear();
            hienThiDanhSachChoNgoiTheoMaCaChieu(this.maCaChieu);
            maVe.Clear();
            totalPrice = 0;
            finalPrice = 0;
            bonus = 0;
            resetPanels();
        }

        private void resetPanels()
        {
            txtTotal.ResetText();
            txtCustomerName.ResetText();
            txtPoint.ResetText();
            txtPlusPoint.ResetText();
            txtDiscount.ResetText();
            txtPayment.ResetText();
            btnUsePoint.Enabled = true;
        }

       
        public void loadDataCustomer()
        {
            if (frmCustomer.phoneNumber != "")
            {
                DataTable customer = CustomerBUS.Instance.getCustomer(frmCustomer.phoneNumber.Trim());
                if (customer != null)
                {
                    DataRow row = customer.Rows[0];
                    txtCustomerName.Text = row["TenKhachHang"].ToString();
                    txtPoint.Text = row["DiemTichLuy"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng");
                }
            }
        }

        private void frmTheatre_FormClosing(object sender, FormClosingEventArgs e)
        {
            resetPanels();
            maVe.Clear();
        }

        private void updatePoint (string phoneNumber, int bonus)
        {
            
            if (!CustomerBUS.Instance.updatePointBUS(phoneNumber, bonus))
            {
                MessageBox.Show("Cập nhật điểm không thành công");
            }
        }

        private void btnUsePoint_Click(object sender, EventArgs e)
        {
           if (txtPoint.Text == "" || txtPoint.Text == null)
            {
                MessageBox.Show("Vui lòng điền thông tin khách hàng");
                return;
            }

           if (maVe.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé");
                return;
            }

           if (CustomerBUS.Instance.usePointBUS(frmCustomer.phoneNumber))
            {
                int percent = Convert.ToInt32(txtPoint.Text);
                float discountAmount = totalPrice * ((float)percent / 100);
                finalPrice = totalPrice - discountAmount;

                txtDiscount.Text = discountAmount.ToString() + " VNĐ";
                //txtPoint.Text = "0";
                txtPayment.Text = finalPrice.ToString() + " VNĐ";
                btnUsePoint.Enabled = false;
            }
            else
            {
                Debug.WriteLine("result is false");
            }
        }
    }
}
               