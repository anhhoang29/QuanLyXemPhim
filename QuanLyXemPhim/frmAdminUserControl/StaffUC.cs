using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QuanLyXemPhim.frmAdminUserControl
{
    public partial class StaffUC : UserControl
    {
        BindingSource staffList = new BindingSource();

        public StaffUC()
        {
            InitializeComponent();
            LoadStaff();
        }
        void LoadStaff()
        {
            DataTable dt = StaffBUS.Instance.getListStaff();
            if (dt == null)
            {
                MessageBox.Show("Error when load data");
            }
            else
            {
                dtgvStaff.DataSource = dt;
            }
        }
      
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
           
        }

        
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
           
        }

        private void dtgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvStaff.SelectedRows)
            {
              txtStaffId.Text = row.Cells[0].Value.ToString();
              txtStaffName.Text = row.Cells[1].Value.ToString();
              txtStaffBirth.Text = row.Cells[2].Value.ToString();
              txtStaffAddress.Text = row.Cells[3].Value.ToString();
              txtStaffPhone.Text = row.Cells[4].Value.ToString();
              txtStaffINumber.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}
