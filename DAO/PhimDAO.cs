using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhimDAO
    {
        private static PhimDAO instance;
        public static PhimDAO Instance
        {
            get { if (instance == null) instance = new PhimDAO(); return PhimDAO.instance; }
            private set { PhimDAO.instance = value; }
        }

        public List<Phim> hienThiPhim()
        {
            try
            {
                string query = @"USP_Show_Phim";
                List<Phim> danhSachPhim = new List<Phim>();
                DataTable table = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow row in table.Rows)
                {
                    Phim phim = new Phim(row);
                    danhSachPhim.Add(phim);
                }
                return danhSachPhim;
            }
            catch
            {
                return null;
            }
        }

        public int themDanhSachTaiKhoan(string userName, string pass, int loaiTK, string idNV)
        {
            throw new NotImplementedException();
        }

        public int suaDanhSachPhim(string MaPhim, string TenPhim, string MoTa, double ThoiLuong,
            DateTime NgayBatDau, DateTime NgayKetThuc, string QuocGia, string DienVien, int GioiHanTuoi)
        {
           try
           {
                string query = @"USP_Update_Phim @MaPhim , @TenPhim , @MoTa , @ThoiLuong , @NgayKhoiChieu ,
                        @NgayKetThuc , @QuocGia , @DaoDien , @GioiHanTuoi ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] {MaPhim, TenPhim,MoTa, ThoiLuong,
                        NgayBatDau, NgayKetThuc, QuocGia, DienVien, GioiHanTuoi });
                return kq;
           }
           catch
           {
                return 0;
           }
        }
        public int themDanhSachPhim(string MaPhim, string TenPhim, string MoTa, double ThoiLuong,
            DateTime NgayBatDau, DateTime NgayKetThuc, string QuocGia, string DienVien, int GioiHanTuoi)
        {
            try
            {
                string query = @"USP_Add_Phim @MaPhim , @TenPhim , @MoTa , @ThoiLuong , @NgayKhoiChieu ,
                        @NgayKetThuc , @QuocGia , @DaoDien , @GioiHanTuoi ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] {MaPhim, TenPhim,MoTa, ThoiLuong,
                        NgayBatDau, NgayKetThuc, QuocGia, DienVien, GioiHanTuoi });
                return kq;
            }
            catch
            {
                return 0;
            }
        }
        public int xoaDanhSachPhim(string MaPhim)
        {
            try
            {
                string query = @"USP_Delete_Phim_Phim_PhanLoaiPhim_CaChieu @MaPhim ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaPhim});
                return kq;
            }
            catch
            {
                return 0;
            }
        }
        //public int xoaTheLoai(string MaLoaiPhim)
        //{
        //    try
        //    {
        //        string query = @"USP_Delete_The_Loai_Phim @MaLoaiPhim ";
        //        int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaLoaiPhim });
        //        return kq;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}
