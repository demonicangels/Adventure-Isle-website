using BusinessLogic;



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
