using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CaChieu
    {
        private string maCaChieu;
        private DateTime thoiGianChieu;
        private DateTime thoiGianKetThuc;
        private string maPhong;
        private string maPhim;
        private int giaVe;
        private int trangThai;

        public string MaCaChieu { get => maCaChieu; set => maCaChieu = value; }
        public DateTime ThoiGianChieu { get => thoiGianChieu; set => thoiGianChieu = value; }
        public DateTime ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string MaPhim { get => maPhim; set => maPhim = value; }
        public int GiaVe { get => giaVe; set => giaVe = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public CaChieu() { }

        public CaChieu(DataRow row)
        {
            MaCaChieu = row["MaCaChieu"].ToString();
            ThoiGianChieu = (DateTime)row["ThoiGianChieu"];
            ThoiGianKetThuc = (DateTime)row["ThoiGianKetThuc"];
            MaPhong = row["MaPhong"].ToString();
            MaPhim = row["MaPhim"].ToString();
            GiaVe = (int)row["GiaVe"];
            TrangThai = (int)row["TrangThai"];
        }
    }
}
