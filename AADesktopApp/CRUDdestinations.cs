using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class CRUDDestinations : Form
    {
        string conStr;
        DestinationService data = new DestinationService();
        public CRUDDestinations()
        {
            InitializeComponent();
             
        }

        public void Clear()
        {
            nameDestxt.Text = string.Empty;
            CountryDestxt.Text = string.Empty;
            currencyDestxt.Text = string.Empty;
            descriptionDestxt.Text = string.Empty;
            searchByIdtxt.Text = string.Empty;
        }
        private void Put_btn_Click(object sender, EventArgs e) // insert button 
        {
            DestinationDTO des = new DestinationDTO();
            des.Name = nameDestxt.Text;
            des.Country = CountryDestxt.Text;
            des.Currency = currencyDestxt.Text;
            des.BriefDescription = descriptionDestxt.Text;
            data.InsertDestination(des);
            MessageBox.Show("Successful insert");
            Clear();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
            data.DeleteDestination(desScreen.SelectedItem.ToString());
            desScreen.Items.Remove(desScreen.SelectedItem);
            MessageBox.Show("Successful delete");
            Clear();

        }

        private void Get_btn_Click(object sender, EventArgs e)
        {
            desScreen.Items.Clear();
            var des = data.GetDestinationByName(searchByIdtxt.Text.ToString());
            desScreen.Items.Add(des);
            Clear();
        }

        private void GetAll_btn_Click(object sender, EventArgs e)
        {
            desScreen.Items.Clear();
            var sqlGetAll = "SELECT * FROM Destinations";
            var des = data.GetAllDestinations();
            for(int i = 0; i < des.Count; i++)
            {
                desScreen.Items.Add(des[i].Name);
            }
            
        }

        private void desScreen_Click(object sender, EventArgs e)
        {
            var des = data.GetDestinationByName(desScreen.SelectedItem.ToString());
            MessageBox.Show(des.ToString());
            
        }

        private void accDbFormbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CRUDusers usr = new CRUDusers();
            usr.Show();

        }
    }
}
