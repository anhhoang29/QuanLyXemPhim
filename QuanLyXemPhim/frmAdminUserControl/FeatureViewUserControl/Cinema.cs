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
    public partial class Cinema : UserControl
    {
        BindingSource cinemaList = new BindingSource();
        public Cinema()
        {
            InitializeComponent();
            LoadCinema();
        }

        void LoadCinema()
        {
            
        }
        void LoadCinemaList()
        {
            
        }
        void AddCinemaBinding()
        {
            
        }
        void LoadScreenTypeIntoComboBox(ComboBox cbo)
        {
            
        }
        private void txtCinemaID_TextChanged(object sender, EventArgs e)
        //Use this to bind data between dtgv and cbo because cbo can't be applied DataBindings normally
        {
            
        }

        void InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
           
        }
        private void btnInsertCinema_Click(object sender, EventArgs e)
        {
            
        }

        void UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            
        }
        private void btnUpdateCinema_Click(object sender, EventArgs e)
        {
            
        }

        void DeleteCinema(string id)
        {
           
        }
        private void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            
        }
    }
}
