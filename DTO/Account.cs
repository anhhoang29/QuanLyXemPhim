using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public Account(string TenDangNhap, string staffID, int MaVaiTro, string MaKhau = null)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MaKhau;
            this.MaVaiTro = MaVaiTro;
            this.StaffID = staffID;
        }

        public int MaVaiTro { get; set; }

        public string MatKhau { get; set; }

        public string StaffID { get; set; }

        public string TenDangNhap { get; set; }

    }
}
