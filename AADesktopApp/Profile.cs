using BusinessLogic;

namespace DesktopApp
{
    public partial class Profile : Form
    {
        IUserRepository _userRepository;
        UserDTO user = new UserDTO();
        public Profile(UserDTO loggedInusr)
        {
            InitializeComponent();
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
