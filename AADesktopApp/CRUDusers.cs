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
    public partial class CRUDusers : Form
    {
        UserRepository userData = new UserRepository();

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
            UserDTO user = new UserDTO();
            user.username = usernameUsertxt.Text;
            user.password = passwordUsertxt.Text;
            user.email = emailUsertxt.Text;
            user.birthday = birthdayDtp.Value;
            userData.InsertUser(user);
            MessageBox.Show("Succesful insert of data.");
            Clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            userData.DeleteUser(userScreen.SelectedItem.ToString());
            userScreen.Items.Remove(userScreen.SelectedItem);
            MessageBox.Show("Successful delete");
        }

        private void getAll_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var users = userData.GetAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                userScreen.Items.Add(users[i].username);
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var usr = userData.GetUserByName(searchByIdtxt.Text);
            userScreen.Items.Add(usr.UserInfo());
            Clear();
        }

        private void userScreen_Click(object sender, EventArgs e)
        {

            var user = userData.GetUserByName(userScreen.SelectedItem.ToString());
            MessageBox.Show(user.UserInfo());
        }
    }
}
