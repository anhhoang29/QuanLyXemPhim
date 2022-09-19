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
    public partial class FormatMovieUC : UserControl
    {
        BindingSource formatList = new BindingSource();

        public FormatMovieUC()
        {
            InitializeComponent();
            LoadFormatMovie();
        }

        void LoadFormatMovie()
        {
           
        }
        void LoadMovieIDIntoCombobox(ComboBox comboBox)
        {
            
        }
        private void cboFormat_MovieID_SelectedValueChanged(object sender, EventArgs e)
        //Display the MovieName when MovieID changed
        {
           
        }
        void LoadScreenIDIntoCombobox(ComboBox comboBox)
        {
           
        }
        private void cboFormat_ScreenID_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
        void LoadFormatMovieList()
        {
            
        }

        void AddFormatBinding()
        {
           
        }
        private void txtFormatID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnShowFormat_Click(object sender, EventArgs e)
        {
            
        }

        void InsertFormat(string id, string idMovie, string idScreen)
        {
            
        }
        private void btnInsertFormat_Click(object sender, EventArgs e)
        {
           
        }

        void UpdateFormat(string id, string idMovie, string idScreen)
        {
            
        }
        private void btnUpdateFormat_Click(object sender, EventArgs e)
        {
            
        }

        void DeleteFormat(string id)
        {
            
        }
        private void btnDeleteFormat_Click(object sender, EventArgs e)
        {
           
        }
    }
}
