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
    public partial class MovieUC : UserControl
    {
        BindingSource movieList = new BindingSource();

        public MovieUC()
        {
            InitializeComponent();
            LoadMovie();
        }

        void LoadMovie()
        {
            dtgvMovie.DataSource = movieList;
            LoadMovieList();
            AddMovieBinding();
        }
        void LoadMovieList()
        {
            
        }
        private void btnShowMovie_Click(object sender, EventArgs e)
        {
            LoadMovieList();
        }
        void AddMovieBinding()
        {
          
        }
        void LoadGenreIntoCheckedList(CheckedListBox checkedList)
        {
            
        }
        private void txtMovieID_TextChanged(object sender, EventArgs e)
        //Use to binding the CheckedListBox Genre of Movie and picture of Movie
        {
            
        }

        void InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            
        }
        void InsertMovie_Genre(string movieID, CheckedListBox checkedListBox)
        //Insert into table 'PhanLoaiPhim'
        {
            
        }

        private void btnUpLoadPictureFilm_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            
        }

        void UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            
        }
        void UpdateMovie_Genre(string movieID, CheckedListBox checkedListBox)
        {
            
        }
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            
        }

        void DeleteMovie(string id)
        {
           
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMovieYearLimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
