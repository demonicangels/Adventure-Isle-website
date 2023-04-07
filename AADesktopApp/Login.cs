using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Login : Form
    {
        IUserRepository _userRepository;
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO();
            user.username = emailtxt.Text;
            user.password = passwordtxt.Text;
            if (_userRepository.Authentication(user) == true)
            {
                Home home = new Home(user);
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
    }
}
