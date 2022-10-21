﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhongChieuDAO
    {
        private static PhongChieuDAO instance;
        public static PhongChieuDAO Instance
        {
            get { if (instance == null) instance = new PhongChieuDAO(); return PhongChieuDAO.instance; }
            private set { PhongChieuDAO.instance = value; }
        }

        public List<PhongChieu> hienThiPhongChieu() 
        {
            List<PhongChieu> danhSahcPhongChieu = new List<PhongChieu>();
            string query = @"USP_Show_Phong_Chieu";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in table.Rows)
            {
                PhongChieu phongChieu = new PhongChieu(row);
                danhSahcPhongChieu.Add(phongChieu);
            }
            return danhSahcPhongChieu;
        }

        public int themPhongChieu (string MaPhong, string TenPhong, int SoChoNgoi, int TinhTrang, int SoHangGhe, int SoGheMotHang)
        {
            try
            {
                string query = @"USP_Add_Phong_Chieu @MaPhong , @TenPhong , @SoChoNgoi , @TinhTrang , @SoHangGhe , @SoGheMotHang ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaPhong, TenPhong.ToUpper(), SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang });
                return kq;
            }
            catch
            {
                return 0;
            }
        }

        public int xoaPhongChieu(string MaPhong)
        {
            try
            {
                string query = @"USP_Xoa_Phong_Chieu @MaPhong ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaPhong});
                return kq;
            }
            catch
            {
                return 0;
            }
        }

        public int capNhatPhongChieu(string MaPhong, string TenPhong, int SoChoNgoi, int TinhTrang, int SoHangGhe, int SoGheMotHang)
        {
            try
            {
                string query = @"USP_Update_Phong_Chieu @MaPhong , @TenPhong , @SoChoNgoi , @TinhTrang , @SoHangGhe , @SoGheMotHang ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaPhong, TenPhong.ToUpper(), SoChoNgoi, TinhTrang, SoHangGhe, SoGheMotHang });
                return kq;
            }
            catch
            {
                return 0;
            }
        }
    }
}