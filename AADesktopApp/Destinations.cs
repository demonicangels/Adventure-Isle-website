using BusinessLogic;

namespace DesktopApp
{
    public partial class Destinations : Form
    {
        IDestinationRepository destinationRepository;
        List<DestinationDTO> desList = new List<DestinationDTO>();
        public Destinations()
        {
            //desList = destinationRepository.GetAllDestinations();
            //for (int i = 0; i < desList.Count; i++)
            //{
            //
            //}
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // paris
        {

        }
    }
}
