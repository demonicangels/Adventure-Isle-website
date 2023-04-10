using BusinessLogic.Entities;
using DAL;
using DAL.DTOs;
using DAL.Interfaces;
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
            UserDTO user = new UserDTO()
            {
                username = usernameUsertxt.Text,
                password = passwordUsertxt.Text,
                email = emailUsertxt.Text,
                birthday = birthdayDtp.Value,
            };
            
            User.InsertUser(user);
            MessageBox.Show("Succesful insert of data.");
            Clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            User.DeleteUser(userScreen.SelectedItem.ToString());
            userScreen.Items.Remove(userScreen.SelectedItem);
            MessageBox.Show("Successful delete");
        }

        private void getAll_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var users = User.GetUsers();
            for (int i = 0; i < users.Length; i++)
            {
                userScreen.Items.Add(users[i].email);
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var usr = User.GetUserByEmail(searchByIdtxt.Text);
            userScreen.MultiColumn = true;
            userScreen.Items.Add(usr.Username);
            Clear();
        }

        private void userScreen_Click(object sender, EventArgs e)
        {
            var user = User.GetUserByEmail(userScreen.SelectedItem.ToString());
            MessageBox.Show(user.UserInfo());
        }
    }
}
