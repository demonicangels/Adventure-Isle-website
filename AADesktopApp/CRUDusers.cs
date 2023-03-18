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
    public partial class CRUDusers : Form
    {
        OUser userData;
        string conStr;
        public CRUDusers()
        {
            InitializeComponent();
            conStr = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            userData = new OUser(conStr);
            
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            var sql = "INSERT INTO Users (username, password, email) VALUES (@username, @password, @email)";
            userData.Insert(sql, usernameUsertxt.Text, passwordUsertxt.Text, emailUsertxt.Text);
            MessageBox.Show("Succesful insert of data.");
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var sql = "DELETE FROM Users WHERE username = @username";
            userData.Delete(sql, userScreen.SelectedItem.ToString());
            userScreen.Items.Remove(userScreen.SelectedItem);
            MessageBox.Show("Successful delete");
        }

        private void getAll_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var sql = "SELECT * FROM Users";
            var users = userData.GetAll(sql);
            for(int i =0; i < users.Count; i++)
            {
                userScreen.Items.Add(users[i]);
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var sql = "SELECT * FROM Users WHERE Id = @Id";
            var usr = userData.GetById(sql, int.Parse(searchByIdtxt.Text));
            userScreen.Items.Add(usr);
        }

        private void userScreen_Click(object sender, EventArgs e)
        {
            var sql = "SELECT * FROM Users WHERE username = @username";
            var user = userData.Selected(sql, userScreen.SelectedItem.ToString());
            MessageBox.Show(user.ToString());
        }
    }
}
