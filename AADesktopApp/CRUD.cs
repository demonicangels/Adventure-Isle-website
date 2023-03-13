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
    public partial class CRUD : Form
    {
        
        public CRUD()
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
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Destinations (Country, Name, Currency, History) VALUES (@Country, @Name, @Currency, @History)", con);
            cmd.Parameters.AddWithValue("@Country", CountryDestxt.Text);
            cmd.Parameters.AddWithValue("@Name", nameDestxt.Text);
            cmd.Parameters.AddWithValue("@Currency", currencyDestxt.Text);
            cmd.Parameters.AddWithValue("@History", descriptionDestxt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success");
            Clear();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Destinations where Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", desScreen.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            desScreen.Items.Remove(desScreen.SelectedItem);
            MessageBox.Show("Succesful delete");
            Clear();

        }

        private void Get_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Destinations WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(searchByIdtxt.Text));
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string des = reader["Name"] + "-" + reader["Country"] + "" + "Currency: " + reader["Currency"];
                desScreen.Items.Add(des);
            }
            Clear();
        }

        private void GetAll_btn_Click(object sender, EventArgs e)
        {
            desScreen.Items.Clear();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Destinations", con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var des = reader["Name"];
                desScreen.Items.Add(des);
            }
            reader.Close();
            con.Close();

        }

        private void desScreen_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Destinations WHERE Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", desScreen.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var des = reader["Country"] + ":" +" "+ reader["Name"]+ ", " + "Curency: " + reader["Currency"].ToString() + " - " + reader["History"].ToString();
                MessageBox.Show(des.ToString());
            }
            reader.Close();
            con.Close();
        }
    }
}
