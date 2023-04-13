using BusinessLogic;
using DAL;

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

            UserService.InsertUser(user);
            MessageBox.Show("Succesful insert of data.");
            Clear();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            UserService.DeleteUser(userScreen.SelectedItem.ToString());
            userScreen.Items.Remove(userScreen.SelectedItem);
            MessageBox.Show("Successful delete");
        }

        private void getAll_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var users = UserService.GetUsers();
            for (int i = 0; i < users.Length; i++)
            {
                userScreen.Items.Add(users[i].email);
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            userScreen.Items.Clear();
            var usr = UserService.GetUserByEmail(searchByIdtxt.Text);
            userScreen.MultiColumn = true;
            userScreen.Items.Add(usr.Username);
            Clear();
        }

        private void userScreen_Click(object sender, EventArgs e)
        {
            var user = UserService.GetUserByEmail(userScreen.SelectedItem.ToString());
            MessageBox.Show(user.UserInfo());
        }
    }
}
