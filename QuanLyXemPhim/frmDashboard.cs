using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QuanLyXemPhim
{
    public partial class frmDashboard : Form
    {
        public frmDashboard(Account acc)
        {
        }
        private void btnSeller_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStaff frm = new frmStaff();
            frm.ShowDialog();
            this.Show();
        }
        private void btnAccountSetting_Click(object sender, EventArgs e)
        {
            frmAccountSetting frm = new frmAccountSetting (loginAccount);
            frm.ShowDialog();
            this.Show();
        }
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return LoginAccount; } 
            set { LoginAccount = value; } 
        }
        

        void ChangeAccount(int type)
        {
            
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmin frm = new frmAdmin();
            frm.ShowDialog();
            this.Show();
        }
    }
}
