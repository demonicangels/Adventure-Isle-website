using BusinessLogic;

namespace DesktopApp
{
    public partial class CRUDDestinations : Form
    {
        string dbTable = "";
        IDestinationRepository _desRepository = new DestinationRepository();

        public CRUDDestinations()
        {
            InitializeComponent();
            //_desRepository = User.GetDAO();
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
            
            DestinationDTO des = new DestinationDTO();
            des.Name = nameDestxt.Text;
            des.Country = countriesCb.SelectedItem.ToString();
            des.Currency = currencyDestxt.Text;
            des.BriefDescription = descriptionDestxt.Text;
            des.Climate = climatetxt.Text;
            _desRepository.InsertDestination(des);
            MessageBox.Show("Successful insert");
            Clear();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {

            _desRepository.DeleteDestination(desScreen.SelectedItem.ToString());
            desScreen.Items.Remove(desScreen.SelectedItem);
            MessageBox.Show("Successful delete");
            Clear();

        }

        private void Get_btn_Click(object sender, EventArgs e)
        {

            desScreen.Items.Clear();
            var des = _desRepository.GetDestinationByName(searchByIdtxt.Text.ToString());
            desScreen.Items.Add(des);
            Clear();
        }

        private void GetAll_btn_Click(object sender, EventArgs e)
        {
            
            desScreen.Items.Clear();
            var des = _desRepository.GetAllDestinationsByCountry(countriesCb.SelectedItem.ToString());
            for (int i = 0; i < des.Count; i++)
            {
                desScreen.Items.Add(des[i].Name);
            }

        }

        private void desScreen_Click(object sender, EventArgs e)
        {
            var des = _desRepository.GetDestinationByName(desScreen.SelectedItem.ToString());
            //MessageBox.Show(des.DesInfo());

        }

        private void accDbFormbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CRUDusers usr = new CRUDusers();
            usr.Show();

        }
    }
}
