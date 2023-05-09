using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using Factory;

namespace DesktopApp
{
    public partial class CRUDusers : Form
    {
       Security sec = new Security();

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
            var us = serviceObjects.userServiceObject();
            UserDTO user = new UserDTO()
            {
                Username = usernameUsertxt.Text,
                Password = passwordUsertxt.Text,
                Email = emailUsertxt.Text,
                Birthday = birthdayDtp.Value,
                Bio = biotxt.Text
            };

            var salt = sec.CreateSalt();
            var hash = sec.CreateHash(salt, passwordUsertxt.Text);
            us.InsertUser(user, salt, hash);
            MessageBox.Show("Succesful insert of data.");
            Clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
			var us = serviceObjects.userServiceObject();
			us.DeleteUser(userScreen.SelectedItem.ToString());
            userScreen.Items.Remove(userScreen.SelectedItem);
            MessageBox.Show("Successful delete");
        }

        private void getAll_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var users = UserService.GetUsers();
            for (int i = 0; i < users.Length; i++)
            {
                userScreen.Items.Add(users[i].Email);
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
			var us = serviceObjects.userServiceObject();
			userScreen.Items.Clear();
            var usr = us.GetUserByEmail(searchByIdtxt.Text);
            userScreen.MultiColumn = true;
            userScreen.Items.Add(usr.Username);
            Clear();
        }

        private void userScreen_Click(object sender, EventArgs e)
        {
            //var usr = UserService.GetUserByEmail(userScreen.SelectedItem.ToString());
            //var user = UserService.FromDTO(usr);
            //MessageBox.Show(user.UserInfo());
        }
    }
}
