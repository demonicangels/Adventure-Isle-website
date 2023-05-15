using BusinessLogic;
using Factory;

namespace DesktopApp
{
    public partial class CRUDDestinations : Form
    {
        string dbTable = "";
        DestinationService desi;
        private int amount;
        bool result; 
        

        public CRUDDestinations()
        {
            InitializeComponent();
            desi = serviceObjects.destinationServiceObject();
        }

        public void Clear()
        {
            nameDestxt.Text = string.Empty;
            countriesCb.Text = string.Empty;
            currencyDestxt.Text = string.Empty;
            descriptionDestxt.Text = string.Empty;
            searchByIdtxt.Text = string.Empty;
            climatetxt.Text = string.Empty;
        }
        private void Put_btn_Click(object sender, EventArgs e) // insert button 
        {
                result = int.TryParse(nameDestxt.Text, out amount);
                var result2 = int.TryParse(currencyDestxt.Text, out amount);
                var result3 = int.TryParse(climatetxt.Text, out amount);

				if (result == true || result2 == true || result3 == true)
                {
					MessageBox.Show("Invalid information. Operation failed.");
					Clear();
				}
                else
                {
                    DestinationDTO des = new DestinationDTO();
                    des.Name = nameDestxt.Text;
                    des.Country = countriesCb.SelectedItem.ToString();
                    des.Currency = currencyDestxt.Text;
                    des.BriefDescription = descriptionDestxt.Text;
                    des.Climate = climatetxt.Text;
			        desi.InsertDestination(des);
                    MessageBox.Show("Successful insert");
					Clear();
				}
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
			desi.DeleteDestination(desScreen.SelectedItem.ToString());
            desScreen.Items.Remove(desScreen.SelectedItem);
            MessageBox.Show("Successful delete");
            Clear();

        }

        private void Get_btn_Click(object sender, EventArgs e)
        {
			desScreen.Items.Clear();

            result = int.TryParse(searchByIdtxt.Text, out amount);

            if (result == true)
            {
				MessageBox.Show("Invalid search. Please try again");
				Clear();
			}
            else
            {
                var des = desi.GetDestinationByName(searchByIdtxt.Text.ToString());
                foreach (var item in des)
                {
                    desScreen.Items.Add(item.Name);
                }
				Clear();
            }
        }

        private void GetAll_btn_Click(object sender, EventArgs e)
        {
			desScreen.Items.Clear();
            var des = desi.GetAllDestinationsByCountry(countriesCb.SelectedItem.ToString());
            for (int i = 0; i < des.Count; i++)
            {
                desScreen.Items.Add(des[i].Name);
            }

        }

        private void desScreen_Click(object sender, EventArgs e)
        {
			var des = desi.GetDestinationByName(desScreen.SelectedItem.ToString());
            MessageBox.Show(des.FirstOrDefault().DesInfo());
        }

        private void accDbFormbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CRUDusers usr = new CRUDusers();
            usr.Show();
        }
    }
}
