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

namespace QuanLyXemPhim.frmAdminUserControl
{
    public partial class AccountUC : UserControl
    {
        BindingSource accountList = new BindingSource();

        public AccountUC()
        {
            InitializeComponent();
            dtgvAccount.DataSource = accountList;
            LoadAccount();
        }

        void LoadAccount()
        {
            TaiKhoanBUS.Instance.hienThiTaiKhoan(accountList);
            bindingTaiKhoang();
        }
        void LoadAccountList()
        {
            
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        public void bindingTaiKhoang()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txt_Pass.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Pass", true, DataSourceUpdateMode.Never));
            nudAccountType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "LoaiTK", true, DataSourceUpdateMode.Never));
            txt_idNV.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "idNV", true, DataSourceUpdateMode.Never));
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
            string UserName = txtUsername.Text;
            string Pass = txt_Pass.Text;
            int LoaiTK = Convert.ToInt32(nudAccountType.Text);
            string idNV = txt_idNV.Text;
            //PhimBUS.Instance.suaDanhSachPhim(MaPhim, TenPhim, MoTa, ThoiLuong, NgayBatDau, NgayKetThuc,
            //    QuocGia, DienVien, GioiHanTuoi);
            //PhimBUS.Instance.hienThiPhim(movieList);
            TaiKhoanBUS.Instance.themDanhSachTaiKhoan(UserName, Pass, LoaiTK, idNV);
            TaiKhoanBUS.Instance.hienThiTaiKhoan(accountList);
        }

        void UpdateAccount(string username, int accountType)
        {
            
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string Pass = txt_Pass.Text;
            int LoaiTK = Convert.ToInt32(nudAccountType.Text);
            string idNV = txt_idNV.Text;
            TaiKhoanBUS.Instance.suaDanhSachTaiKhoan(UserName, Pass, LoaiTK, idNV);
            TaiKhoanBUS.Instance.hienThiTaiKhoan(accountList);
        }

        void DeleteAccount(string username)
        {
            
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string idNV = dtgvAccount.SelectedCells[0].OwningRow.Cells["idNV"].Value.ToString();
            TaiKhoanBUS.Instance.xoaDanhSachTaiKhoan(idNV);
            TaiKhoanBUS.Instance.hienThiTaiKhoan(accountList);
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

        private void grpAccount_Enter(object sender, EventArgs e)
        {

        }

        private void Show_MK_CheckedChanged(object sender, EventArgs e)
        {
            if(Show_MK.Checked)
            {
                txt_Pass.UseSystemPasswordChar = true;
            }
            else
            {
                txt_Pass.UseSystemPasswordChar = false;
            }
        }

        private void lblStaffName_Account_Click(object sender, EventArgs e)
        {

        }

        private void lblStaffID_Account_Click(object sender, EventArgs e)
        {

        }

        private void lblStaffID_Account_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_idNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
