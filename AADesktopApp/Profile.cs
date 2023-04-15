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
                user = _userRepository.GetUserByEmail(loggedInusr.Email);
                label6.Text = user.Username.ToString();
                label7.Text = user.Email.ToString();
                label8.Text = user.Birthday.ToString();
                label10.Text = user.UserSince.ToString();
                label11.Text = user.Bio.ToString();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
