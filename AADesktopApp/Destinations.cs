using BusinessLogic;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Destinations : Form
    {
        DestinationService desData = new DestinationService("");
        List<DestinationDTO> desList = new List<DestinationDTO>();
        public Destinations()
        {
            desList = desData.GetAllDestinations();
            for (int i = 0; i < desList.Count; i++)
            {

            }
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // paris
        {

        }
    }
}
