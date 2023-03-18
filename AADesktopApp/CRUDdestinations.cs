using AAClasslibrary.Operations;
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
        ODestination data;
        public CRUDDestinations()
        {
            InitializeComponent();
            conStr = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            data = new ODestination(conStr);
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
            string sqlCmd = "INSERT INTO Destinations (Country, Name, Currency, History) VALUES (@Country, @Name, @Currency, @History)";
            data.Insert(sqlCmd, CountryDestxt.Text,nameDestxt.Text,currencyDestxt.Text,descriptionDestxt.Text);
            MessageBox.Show("Successful insert");
            Clear();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            var sqlInsert = "DELETE FROM Destinations WHERE NAME = @NAME";
            data.Delete(sqlInsert, desScreen.SelectedItem.ToString());
            desScreen.Items.Remove(desScreen.SelectedItem);
            MessageBox.Show("Successful delete");
            Clear();

        }

        private void Get_btn_Click(object sender, EventArgs e)
        {
            desScreen.Items.Clear();
            var sqlGetById = "SELECT * FROM Destinations WHERE ID = @ID";
            var des = data.GetById(sqlGetById, int.Parse(searchByIdtxt.Text));
            desScreen.Items.Add(des);
            Clear();
        }

        private void GetAll_btn_Click(object sender, EventArgs e)
        {
            desScreen.Items.Clear();
            var sqlGetAll = "SELECT * FROM Destinations";
            var des = data.GetAll(sqlGetAll);
            for(int i = 0; i < des.Count; i++)
            {
                desScreen.Items.Add(des[i]);
            }
            
        }

        private void desScreen_Click(object sender, EventArgs e)
        {
            var sqlSelected = "SELECT * FROM Destinations WHERE Name = @Name";
            var des = data.Selected(sqlSelected, desScreen.SelectedItem.ToString());
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
