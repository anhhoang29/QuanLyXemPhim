using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TheLoaiDAO
    {
        private static TheLoaiDAO instance;
        public static TheLoaiDAO Instance
        {
            get { if (instance == null) instance = new TheLoaiDAO(); return TheLoaiDAO.instance; }
            private set { TheLoaiDAO.instance = value; }
        }

        public List<TheLoai> hienThiTheLoaiPhim()
        {
            List<TheLoai> theLoais = new List<TheLoai>();
            string query = @"USP_Show_The_Loai_Phim";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in table.Rows)
            {
                TheLoai theLoai = new TheLoai(row);
                theLoais.Add(theLoai);
            }

            return theLoais;
        }

        public int themTheLoai(string MaLoaiPhim, string TenTheLoai)
        {
            try
            {
                string query = @"USP_Add_The_Loai_Phim @MaLoaiPhim , @TenTheLoai ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaLoaiPhim, TenTheLoai });
                return kq;
            }
            catch
            {
                return 0;
            }
        }

        public int xoaTheLoai(string MaLoaiPhim)
        {
            try
            {
                string query = @"USP_Delete_The_Loai_Phim @MaLoaiPhim ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaLoaiPhim});
                return kq;
            }
            catch
            {
                return 0;
            }
        }

        public int suaTheLoai(string MaLoaiPhim, string TenTheLoai)
        {
            try
            {
                string query = @"USP_Update_The_Loai_Phim @MaLoaiPhim , @TenTheLoai ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaLoaiPhim, TenTheLoai });
                return kq;
            }
            catch
            {
                return 0;
            }
        }
    }
}
