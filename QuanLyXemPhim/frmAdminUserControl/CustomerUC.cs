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
using BUS;

namespace QuanLyXemPhim.frmAdminUserControl
{
    public partial class CustomerUC : UserControl
    {
        BindingSource customerList = new BindingSource();
        public CustomerUC()
        {
            InitializeComponent();
            LoadCustomer();
        }

        void LoadCustomer()
        {

            DataTable dt = CustomerBUS.Instance.getListCustomer();
            if (dt == null)
            {
                MessageBox.Show("Error when load data");
            }
            else
            {
                dtgvCustomer.DataSource = dt;
            }
           
        }
  
        
        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            String name = txtCusName.Text;
            int birth = Int32.Parse(txtCusBirth.Text);
            String phoneNumber = txtCusPhone.Text;
            int point = (int)nudPoint.Value;
            String address = txtAddress.Text;

            if (CustomerBUS.Instance.addCustomer(name, birth, phoneNumber, point, address))
            {
                LoadCustomer();
                txtCusName.Clear();
                txtAddress.Clear();
                txtCusBirth.Clear();
                txtCusPhone.Clear();
                nudPoint.Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
    }
}
