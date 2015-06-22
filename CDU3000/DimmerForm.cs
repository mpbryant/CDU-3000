using System;
using System.Drawing;
using System.Windows.Forms;

namespace CDU3000
{
    public partial class DimmerForm : Form
    {

        private int locX;
        private int locY;

        public int DimmerLocX
        {
            set
            {
                locX = value;//set from the mainform 
                UpdateLoc ( );//causes the form to reposition with the mainform
            }
        }

        public int DimmerLocY
        {
            set
            {
                locY = value;//set from the mainform 
                UpdateLoc ( );//causes the form to reposition with the mainform
            }
        }

        private void UpdateLoc( )
        {
            this.Location = new Point (locX, locY);//from DimmerLocx and y
        }

        public DimmerForm( )
        {
            InitializeComponent ( );
        }

        private void DimmerForm_Load(object sender, EventArgs e)
        {

        }


    }
}
