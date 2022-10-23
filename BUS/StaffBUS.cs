using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class StaffBUS
    {
        private static StaffBUS instance;
        public static StaffBUS Instance
        {
            get { if (instance == null) instance = new StaffBUS(); return StaffBUS.instance; }
            private set { StaffBUS.instance = value; }
        }


        public DataTable getListStaff()
        {
            return StaffDAO.Instance.readAllStaff();
        }

    }
}
