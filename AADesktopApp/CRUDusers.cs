using AAClasslibrary.DAL__Operations_;
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
        UserOperation userData = new UserOperation();
        
        public CRUDusers()
        {
            InitializeComponent();

        }

        public void Clear()
        {
            usernameUsertxt.Text = string.Empty;
            passwordUsertxt.Text = string.Empty;
            emailUsertxt.Text = string.Empty;
            searchByIdtxt.Text = string.Empty;
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            var sql = "INSERT INTO Users (username, password, email) VALUES (@username, @password, @email)";
            UserDTO user = new UserDTO();
            user.username = usernameUsertxt.Text;
            user.password = passwordUsertxt.Text;
            user.email = emailUsertxt.Text;
            userData.Insert(sql, user);
            MessageBox.Show("Succesful insert of data.");
            Clear();
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
            var sql = $"SELECT * FROM Users WHERE username LIKE '{searchByIdtxt.Text}%'";
            var usr = userData.Search(sql);
            userScreen.Items.Add(usr);
            Clear();
        }

        private void userScreen_Click(object sender, EventArgs e)
        {
            var sql = "SELECT * FROM Users WHERE username = @username";
            var user = userData.Selected(sql, userScreen.SelectedItem.ToString());
            MessageBox.Show(user.ToString());
        }
    }
}
