using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXemPhim.frmAdminUserControl
{
    public partial class AccountUC : UserControl
    {
        BindingSource accountList = new BindingSource();

        public AccountUC()
        {
            InitializeComponent();
            LoadAccount();
        }

        void LoadAccount()
        {
           
        }
        void LoadAccountList()
        {
            
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        void AddAccountBinding()
        {
            
        }
        void LoadStaffIntoComboBox(ComboBox cbo)
        {
            
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void cboStaffID_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void InsertAccount(string username, int accountType, string idStaff)
        {
            
        }
        private void btnInsertAccount_Click(object sender, EventArgs e)
        {
            
        }

        void UpdateAccount(string username, int accountType)
        {
            
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {

        }

        void DeleteAccount(string username)
        {
            
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            
        }

        void ResetPassword(string username)
        {
           
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearchAccount_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
