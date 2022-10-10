using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ve
    {
        private int id;
        private int loaiVe;
        private string maCaChieu;
        private string maGheNgoi;
        private int maKhachHang;
        private int trangThai;
        private int tienBanVe;

        public int Id { get => id; set => id = value; }
        public int LoaiVe { get => loaiVe; set => loaiVe = value; }
        public string MaCaChieu { get => maCaChieu; set => maCaChieu = value; }
        public string MaGheNgoi { get => maGheNgoi; set => maGheNgoi = value; }
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public int TienBanVe { get => tienBanVe; set => tienBanVe = value; }

        public Ve() { }

        public Ve(DataRow row)
        {
            Id = (int)row["id"];
            LoaiVe = (int)row["LoaiVe"];
            MaCaChieu = row["MaCaChieu"].ToString();
            MaGheNgoi = row["MaGheNgoi"].ToString();
            MaKhachHang = (int)row["MaKhachHang"];
            TrangThai = (int)row["TrangThai"];
            TienBanVe = (int)row["TienBanVe"];
        }
    }
}
