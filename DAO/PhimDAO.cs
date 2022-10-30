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

        // Lấy tên Phim 
        public static List<Phim> GetPhim()
        {
            List<Phim> MovieList = new List<Phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery(@"USP_Show_Phim");
            foreach (DataRow item in data.Rows)
            {
                Phim MovieName = new Phim(item);
                MovieList.Add(MovieName);
            }
            return MovieList;
        }

    }
}
