using BusinessLogic;

namespace DesktopApp
{
    public partial class Home : Form
    {
        UserDTO user;
        public Home(UserDTO loggedIn)
        {
            InitializeComponent();
            user = loggedIn;
            if (loggedIn != null)
            {
                profileBtn.Visible = true;
                profileBtn.Enabled = true;
                loginRegisterBtn.Visible = false;
                loginRegisterBtn.Enabled = false;
            }
        }
        public Home()
        {
            InitializeComponent();
        }

        private void loginRegisterBtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            Profile p = new Profile(user);
            this.Close();
            p.Show();
        }
    }
}
