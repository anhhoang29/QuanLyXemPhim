using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXemPhim.frmAdminUserControl.FeatureViewUserControl
{
    public partial class ShowTimesUC : UserControl
    {
        BindingSource showtimeList = new BindingSource();
        public ShowTimesUC()
        {
            InitializeComponent();
            LoadShowtime();
        }

        void LoadShowtime()
        {
            dtgvShowtime.DataSource = showtimeList;
            LoadShowtimeList();
            LoadFormatMovieIntoComboBox();
            AddShowtimeBinding();
        }
        void LoadShowtimeList()
        {
            
        }
        private void btnShowShowtime_Click(object sender, EventArgs e)
        {
            LoadShowtimeList();
        }

        //Binding
        void AddShowtimeBinding()
        {
       
        }
        void LoadFormatMovieIntoComboBox()
        {
          
        }
        private void cboFormatID_Showtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void txtShowtimeID_TextChanged(object sender, EventArgs e)
        {
            
        }

        //Insert
        void InsertShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
        {
           
        }
        private void btnInsertShowtime_Click(object sender, EventArgs e)
        {
            
        }

        //Update
        void UpdateShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
        {
           
        }
        private void btnUpdateShowtime_Click(object sender, EventArgs e)
        {
            
        }

        //Delete
        void DeleteShowtime(string id)
        {
           
        }
        private void btnDeleteShowtime_Click(object sender, EventArgs e)
        {
           
        }

        //Search
        private void btnSearchShowtime_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSearchShowtime_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
