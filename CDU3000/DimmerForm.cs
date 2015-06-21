using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                locX = value;
                UpdateLoc ( );
            }
        }

        public int DimmerLocY
        {
            set
            {
                locY = value;
                UpdateLoc ( );
            }
        }

        private void UpdateLoc( )
        {
            this.Location = new Point (locX, locY);
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
