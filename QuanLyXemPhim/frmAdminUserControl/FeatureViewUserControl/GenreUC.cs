using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QuanLyXemPhim.frmAdminUserControl.FeatureViewUserControl
{
    public partial class GenreUC : UserControl
    {
        BindingSource genreList = new BindingSource();

        public GenreUC()
        {
            InitializeComponent();
            LoadGenre();
        }

        void LoadGenre()
        {
            
        }
        void LoadGenreList()
        {
           
        }
        void AddGenreBinding()
        {
          
        }
        private void btnShowGenre_Click(object sender, EventArgs e)
        {
            
        }

        void InsertGenre(string id, string name, string desc)
        {
            
        }
        private void btnInsertGenre_Click(object sender, EventArgs e)
        {
            
        }

        void UpdateGenre(string id, string name, string desc)
        {
           
        }
        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            
        }

        void DeleteGenre(string id)
        {
           
        }
        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            
        }
    }
}
