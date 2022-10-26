using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class CaChieuBUS
    {
        private static CaChieuBUS instance;
        public static CaChieuBUS Instance
        {
            get { if (instance == null) instance = new CaChieuBUS(); return CaChieuBUS.instance; }
            private set { CaChieuBUS.instance = value; }
        }

        public void hienThiCaChieu(BindingSource source)
        {
            source.DataSource = CaChieuDAO.Instance.hienThiCaChieu();
        }
    }
}
