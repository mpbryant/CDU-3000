using System;
using System.Windows.Forms;

namespace CDU3000
{
    public partial class Readme : Form
    {
        #region Fields

        //creates a new instanceof the CDU3000 class
        CDU3000 myCDU = new CDU3000 ( );

        #endregion





        #region Initializes the Readme and CDU3000 forms

        public Readme( )
        {
            //Initializes the Readme form
            InitializeComponent ( );

            //Initializes the CDU3000 form
            myCDU.Show ( );



        }

        #endregion

        #region Change CDU3000 Border and Buttons

        private void windowBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Checks the forms border style and swaps between NONE and Fixed3D 
            //Also shows or hides the CLOSE and MOVE buttons on the form
            if (myCDU.FormBorderStyle == FormBorderStyle.None)
            {
                myCDU.FormBorderStyle = FormBorderStyle.Fixed3D;
                myCDU.HideFormBtns ( );
            }
            else
            {
                myCDU.FormBorderStyle = FormBorderStyle.None;
                myCDU.ShowFormBtns ( );
            }

        }

        #endregion

    }
}
