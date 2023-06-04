using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using Factory;

namespace DesktopApp
{
	public partial class CRUDusers : Form
	{
		Security sec = new Security();
		UserService us;
		bool result;

		public CRUDusers()
		{
			InitializeComponent();
			us = serviceObjects.userServiceObject();

		}

		public void Clear()
		{
			usernameUsertxt.Text = string.Empty;
			passwordUsertxt.Text = string.Empty;
			emailUsertxt.Text = string.Empty;
			searchByIdtxt.Text = string.Empty;
			biotxt.Text = string.Empty;
		}

		private void insert_btn_Click(object sender, EventArgs e)
		{
			result = us.InfoValidation(usernameUsertxt.Text, emailUsertxt.Text);
			
			if (result == true)
			{
				MessageBox.Show("Invalid information. Please try again.");
				Clear();
			}
			else
			{
				UserDTO user = new UserDTO(0, emailUsertxt.Text, passwordUsertxt.Text)
				{
					Username = usernameUsertxt.Text,
					Birthday = birthdayDtp.Value,
					Bio = biotxt.Text
				};

				var salt = sec.CreateSalt();
				var hash = sec.CreateHash(salt, passwordUsertxt.Text);
				us.InsertUser(user, salt, hash);
				MessageBox.Show("Succesful insert of data.");
				Clear();
			}

		}

		private void delete_btn_Click(object sender, EventArgs e)
		{
			us.DeleteUser(userScreen.SelectedItem.ToString());
			userScreen.Items.Remove(userScreen.SelectedItem);
			MessageBox.Show("Successful delete");
		}

		private void getAll_btn_Click(object sender, EventArgs e)
		{
			userScreen.Items.Clear();
			var users = us.GetUsers();
			for (int i = 0; i < users.Length; i++)
			{
				userScreen.Items.Add(users[i].Email);
			}
		}

		private void get_btn_Click(object sender, EventArgs e)
		{
			userScreen.Items.Clear();

			result = us.SearchValidation(searchByIdtxt.Text);

			if (result == true)
			{
				MessageBox.Show("Invalid information. Please try again.");
				Clear();
			}
			else
			{
				var usr = us.GetUserByEmail(searchByIdtxt.Text);
				userScreen.MultiColumn = true;
				userScreen.Items.Add(usr.Username);
				Clear();
			}
		}

		private void userScreen_Click(object sender, EventArgs e)
		{
			var usr = us.GetUserByEmail(userScreen.SelectedItem.ToString());
			MessageBox.Show(usr.UserInfo());
		}
	}
}
