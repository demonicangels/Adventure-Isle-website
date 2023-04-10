using BusinessLogic;
using BusinessLogic.Entities;
using DAL.DTOs;
using DAL.Interfaces;
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
    public partial class Profile : Form
    {
        IUserRepository _userRepository;
        UserDTO user = new UserDTO();
        public Profile(UserDTO loggedInusr)
        {
            InitializeComponent();
            _userRepository = User.GetDAO();
            if (loggedInusr != null)
            {
                user = _userRepository.GetUserByEmail(loggedInusr.email);
                label6.Text = user.username.ToString();
                label7.Text = user.email.ToString();
                label8.Text = user.birthday.ToString();
                label10.Text = user.userSince.ToString();
                label11.Text = user.Bio.ToString();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
