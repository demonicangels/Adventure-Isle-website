using AAClasslibrary.Entities;
using AAClasslibrary.Enums;
using DAL;
using System.Data.SqlClient;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
       
        List<User> users = new List<User>();
        List<Destination> destinations = new List<Destination>();
        User usr = new User("", "", "");
        TravelList travel = new TravelList();
        List<Review> reviews = new List<Review>();
        Destination paris;
        Destination rome;


        public Form1()
        {
            InitializeComponent();
            GenerateDestinations();
            InitComboDes();
            InitTravelLabels();
            review_btn.Enabled = false;
            travellist_tab.Enabled = false;
            
        }
        public void GenerateDestinations()
        {
            paris = new Destination("Paris", "France", "Paris is the capital of France", "euro", "moderate");
            rome = new Destination("Rome", "Italy", "Rome is the capital of Italy", "euro", "moderate");
            destinations.Add(paris);
            destinations.Add(rome);
        }
        public void InitComboDes()
        {
            try
            {
                foreach (Destination des in destinations)
                {
                    destinationsCb.Items.Add(des.Name);
                }
            }
            catch (Exception ex) { }

        }
        public void InitTravelLabels()
        {
            checkBox1.Text = Necessities.Passport.ToString();
            checkBox2.Text = Necessities.Id.ToString();
            checkBox3.Text = Necessities.Sunglasses.ToString();
            checkBox4.Text = Necessities.Towels.ToString();
            checkBox5.Text = Necessities.Camera.ToString();
        }
        public void Clear()
        {
            loginUsernametxt.Text = string.Empty;
            loginPasswordtxt.Text = string.Empty;
            usernametxt.Text = string.Empty;
            passwordtxt.Text = string.Empty;
            emailtxt.Text = string.Empty;
            ReviewtxtBox.Text = string.Empty;
            ratingtxt.Text = string.Empty;
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            usr = new User(usernametxt.Text, passwordtxt.Text, emailtxt.Text);
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetUserName.Contains(usernametxt.Text) == true)
                {
                    MessageBox.Show("A user with such username already exists.");
                }
            }
            users.Add(usr);
            Clear();

        }

        private void login_button_Click(object sender, EventArgs e)
        {

            foreach (User u in users)
            {
                if (loginUsernametxt.Text == u.GetUserName && loginPasswordtxt.Text == u.GetPassword)
                {
                    MessageBox.Show($"Succesful login. Welcome back {u.GetUserName}!");
                    label10.Text = u.GetUserName;
                    usr.LoggedInAccount = u;
                }
                else
                {
                    if (usr.GetUserName.Contains(loginUsernametxt.Text) == false)
                    {
                        MessageBox.Show($"Account with username {loginUsernametxt.Text} doesn't exist.");
                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect");
                    }

                }
            }
            Clear();

        }
        private void review_btn_Click(object sender, EventArgs e)
        {

            Review rev = new Review(usr.LoggedInAccount, destinationsCb.SelectedItem.ToString(), Convert.ToDouble(ratingtxt.Text), ReviewtxtBox.Text);
            if (destinationsCb.SelectedItem.ToString() == "Paris")
            {
                paris.AddRating(Convert.ToDouble(ratingtxt.Text));
                paris.AvgRating = paris.CalculateAverage();
                Reviews_screen.Items.Add($"{rev.GetReview(paris.AvgRating)}");
                paris.AddReview(rev);
                //Reviews_screen.Items.Add(rev.GetReview(Paris.AvgRating).ToString());
            }
            else if (destinationsCb.SelectedItem.ToString() == "Rome")
            {
                rome.AddRating(Convert.ToDouble(ratingtxt.Text));
                rome.AvgRating = rome.CalculateAverage();
                rome.AddReview(rev);
                Reviews_screen.Items.Add(rev.GetReview(rome.AvgRating));

            }
            Clear();


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                travellistScreen.Items.Add(checkBox1.Text);
                travel.AddToTravelList(checkBox1.Text);
            }
            if (checkBox2.Checked == true)
            {
                travellistScreen.Items.Add(checkBox2.Text);
                travel.AddToTravelList(checkBox2.Text);
            }
            if (checkBox3.Checked == true)
            {
                travellistScreen.Items.Add(checkBox3.Text);
                travel.AddToTravelList(checkBox3.Text);
            }
            if (checkBox4.Checked == true)
            {
                travellistScreen.Items.Add(checkBox4.Text);
                travel.AddToTravelList(checkBox4.Text);
            }
            if (checkBox5.Checked == true)
            {
                travellistScreen.Items.Add(checkBox5.Text);
                travel.AddToTravelList(checkBox5.Text);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usr.LoggedInAccount != null)
            {
                review_btn.Enabled = true;
                travellist_tab.Enabled = true;
            }

        }

        private void Reviews_screen_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDDestinations data = new CRUDDestinations();
            this.Hide();
            data.Show();
        }
    }
}