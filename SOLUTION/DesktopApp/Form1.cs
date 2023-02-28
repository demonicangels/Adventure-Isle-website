using AAClasslibrary;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        Data d = new Data();

        public Form1()
        {
            InitializeComponent();
            InitComboDes();
        }
        public void InitComboDes()
        {
            foreach(Destination d in d.GetData())
            {
                destinationsCb.Items.Add(d.name);
            }
        }
        private void review_tab_Click(object sender, EventArgs e)
        {
            

        }
    }
}