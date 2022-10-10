using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoai
    {
        private string maTheLoai;
        private string tenTheLoai;

        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }

        public TheLoai() { }

        public TheLoai(DataRow row)
        {
            MaTheLoai = row["MaLoaiPhim"].ToString();
            TenTheLoai = row["TenTheLoai"].ToString();
        }
    }
}
