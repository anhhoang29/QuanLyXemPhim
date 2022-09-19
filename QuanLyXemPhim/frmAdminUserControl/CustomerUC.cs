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
            dtgvCustomer.DataSource = customerList;
            LoadCustomerList();
            AddCustomerBinding();
        }

        void LoadCustomerList()
        {
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        void AddCustomerBinding()
        {
           
        }

        void InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            
        }

        void UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {

        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            
        }

        void DeleteCustomer(string id)
        {
            
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string cusID = txtCusID.Text;
            DeleteCustomer(cusID);
            LoadCustomerList();
        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void NgheNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
