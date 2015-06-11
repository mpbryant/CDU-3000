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
    
    public partial class CDU3000 : Form
    {

        //NOTES

        //To create a new page, add a page method to the page region. Segregate the CDU3000 and CDU7000 methods. Make sure to add a reference to the PopulateNames method
        //Next, add the names of the buttons to the switch statement in the PopulateNames method
        //Finally, add to the switch statement in the PageSelection method to jump to the correct page. Make sure to segregate the CDU3000 and CDU7000 switch statements

        #region Fields

        //Button names
        string l0name = null;
        string l1name = null;
        string l2name = null;
        string l3name = null;
        string l4name = null;
        string l5name = null;
        string l6name = null;

        string r1name = null;
        string r2name = null;
        string r3name = null;
        string r4name = null;
        string r5name = null;
        string r6name = null;

        

        //variables used for moving the form
        Boolean drag;
        int mousex;
        int mousey;
        
        //variables used to define ref TextBox locations on screen
        int row0=51, row1=81, row2=110, row3=140, row4=170, row5=200, row6=232, row7=262, row8=293, row9=323, row10=353, row11=383, row12=414, row13=444, row14=474, row15=504;
        int col1=137, col2=169, col3=201, col4=233, col5=265, col6=297, col7=329, col8=361, col9=393, col10=425, col11=457, col12=489, col13=521, col14=553, col15=600, col16=607, col17=639;
        
        
        
        private int tbCount;//test to see if counting the number of ref TextBoxes will help in disposing the TextBoxes
        private string currentPageTitle;//stores the current page title
        private int currentPageNumber;//stores the current page number

        private bool initialLoad = true;//used to track if this is the initial load of the program (status page tried to load every                                                                                 time the mouse was clicked off the application and then clicked back on the form)
        private bool CDU7000Page = false;//used to diferentiate between CDU3000 and CDU7000 pages

        private char c = '\uE000';//character used for empty placeholders
        private string emptyDigit = ('\uE000').ToString();
        private string emptyLatLong = ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\u00B0').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + "." + ('\uE000').ToString() + ('\uE000').ToString() +"  "+ ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\u00B0').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + "." + ('\uE000').ToString() + ('\uE000').ToString();
        

        #endregion


        //ADD SEARCH FUNCTION

        #region Form Load and Display First Page

        public CDU3000()
        {
            InitializeComponent();
        }

        private void InitialPageLoad(object sender, EventArgs e) //loads the initial page seen on the CDU
        {
            if (initialLoad == true)//if this is the initial load of the program
            {
                StatusPage();//load the status page
                initialLoad = false;//change the initialLoad state to false
            }
            
            
        }
        
        #endregion

        
        #region Form Close Items

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            ActiveForm.Close();
        }

        #endregion
        
                
        #region Pages

        
        #region Index Pages

        private void IdxPage1()
        {

            PopulateNames("IdxPage1");


            currentPageTitle = "index";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/3");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, l2name, Color.White);

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, l3name, Color.White);

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, l4name, Color.White);

            TextBox l4b = new TextBox();
            CreateTB(ref l4b, col2, row9, "FMS1", Color.White);

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, l5name, Color.White);

            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col2, row11, "FMS1", Color.White);

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, l6name, Color.White);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, r1name, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, r2name, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, r3name, Color.White);
            r3.TextAlign = HorizontalAlignment.Right;

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, r4name, Color.White);
            r4.TextAlign = HorizontalAlignment.Right;

            TextBox r5 = new TextBox();
            CreateTB(ref r5, col15, row10, r5name, Color.White);
            r5.TextAlign = HorizontalAlignment.Right;

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, r6name, Color.White);
            r6.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            CreateTB(ref r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            CreateTB(ref r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            CreateTB(ref r4right, col16, row8, ">", Color.White);

            TextBox r5right = new TextBox();
            CreateTB(ref r5right, col16, row10, ">", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");

        }

        private void IdxPage2()
        {
            PopulateNames("IdxPage2");


            currentPageTitle = "index";
            currentPageNumber = 2;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "2/3");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, l2name, Color.White);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, r1name, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, r2name, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, r3name, Color.White);
            r3.TextAlign = HorizontalAlignment.Right;

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, r4name, Color.White);
            r4.TextAlign = HorizontalAlignment.Right;

            TextBox r5 = new TextBox();
            CreateTB(ref r5, col15, row10, r5name, Color.White);
            r5.TextAlign = HorizontalAlignment.Right;

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, r6name, Color.White);
            r6.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            CreateTB(ref r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            CreateTB(ref r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            CreateTB(ref r4right, col16, row8, ">", Color.White);

            TextBox r5right = new TextBox();
            CreateTB(ref r5right, col16, row10, ">", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        private void IdxPage3()
        {
            PopulateNames("IdxPage3");


            currentPageTitle = "index";
            currentPageNumber = 3;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "3/3");


            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, r1name, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, r2name, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            CreateTB(ref r2right, col16, row4, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        } 

        #endregion

        #region  PosInit Pages

        private void PosInitPage1()
        {

            PopulateNames("PosInitPage1");

            currentPageTitle = "posinit";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "POS INIT");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/2");

            TextBox l1Title = new TextBox();
            CreateTB(ref l1Title, col2, row1, "FMS POS");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "N00°00.00 E000°00.00", Color.White);

            TextBox l2Title = new TextBox();
            CreateTB(ref l2Title, col2, row3, "AIRPORT");

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "KNEL", Color.White);

            TextBox l3Title = new TextBox();
            CreateTB(ref l3Title, col2, row5, "PILOT/REF WPT");

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "- - - - -", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "N40°02.0 W074°21.2", Color.White);

            TextBox r5Title = new TextBox();
            CreateTB(ref r5Title, col8, row9, "SET POS");

            TextBox r5 = new TextBox();
            CreateTB(ref r5, col15, row10, emptyLatLong, Color.White);

            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, "FPLN", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, "< INDEX", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        } 

        private void PosInitPage2()
        {
            PopulateNames("PosInitPage2");

            currentPageTitle = "posinit";
            currentPageNumber = 2;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "POS INIT");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "2/2");

            TextBox l1Title = new TextBox();
            CreateTB(ref l1Title, col2, row1, "FMS POS");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "N38°15.59 W094°52.82", Color.White);

            TextBox l2Title = new TextBox();
            CreateTB(ref l2Title, col2, row3, "GNSS1");

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "N38°15.58 W094°52.87", Color.White);

            TextBox l3Title = new TextBox();
            CreateTB(ref l3Title, col2, row5, "GNSS2");

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "N38°15.57 W094°52.84", Color.White);

            TextBox l5title = new TextBox();
            CreateTB(ref l5title, col2, row9, "UPDATE FROM", Color.White);

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "< NAVAID", Color.White);

            TextBox r1title = new TextBox();
            CreateTB(ref r1title, col15, row1, "GS");

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, "406", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "406", Color.White);

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, "406", Color.White);

            TextBox r5Title = new TextBox();
            CreateTB(ref r5Title, col15, row9, "NAVAID");

            TextBox r5 = new TextBox();
            CreateTB(ref r5, col15, row10, "BUM", Color.White);

            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, "FPLN", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, "< INDEX", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        #endregion

        private void StatusPage() 
        {

            PopulateNames("StatusPage");

            currentPageTitle = "status"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            CreateTB(ref title, col7, row0, "STATUS");

            TextBox navData = new TextBox();
            CreateTB(ref navData, col2, row1, "NAV DATA");

            TextBox l1 = new TextBox();
            l1name = "WORLD";
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l1b = new TextBox();
            CreateTB(ref l1b, col2, row3, "ACTIVE DATA BASE");

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "09JAN15 05FEB15", Color.Yellow);

            TextBox l2b = new TextBox();
            CreateTB(ref l2b, col2, row5, "SEC DATA BASE");

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "06SEP15 03OCT15", Color.White);

            TextBox l3b = new TextBox();
            CreateTB(ref l3b, col2, row7, "UTC");

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "12:00", Color.White);

            TextBox l4b = new TextBox();
            CreateTB(ref l4b, col2, row9, "PROGRAM");

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "SCID D 001 CNN107", Color.White);
            
            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, l6name, Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r3b = new TextBox();
            CreateTB(ref r3b, col13, row7, " DATE");

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, "12MAY15", Color.White);
            
            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, r6name, Color.White);
            

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);
            
            
            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        private void TunPage1()
        {
            currentPageTitle = "tune";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "TUNE");

            TextBox com1 = new TextBox();
            CreateTB(ref com1, col2, row1, "COM1", Color.White);

            TextBox com2 = new TextBox();
            CreateTB(ref com2, col13, row1, "COM2", Color.White);

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/2");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "122.875", Color.Green);

            TextBox l1b = new TextBox();
            CreateTB(ref l1b, col2, row3, "RECALL", Color.White);
                        
            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "134.250", Color.White);

            TextBox l2b = new TextBox();
            CreateTB(ref l2b, col2, row5, "NAV1", Color.White);

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "113.80/ICT", Color.Green);

            TextBox l3b = new TextBox();
            CreateTB(ref l3b, col2, row7, "DME1", Color.White);

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "HOLD");

            TextBox l4right = new TextBox();
            CreateTB(ref l4right, col4, row8, "116.80", Color.Green);

            TextBox l4b = new TextBox();
            CreateTB(ref l4b, col2, row9, "ATC1", Color.White);

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "3144", Color.Green);


            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col2, row11, "ADF", Color.White);

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, "412.5", Color.Green);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, "121.700", Color.Green);
            //r1.TextAlign = HorizontalAlignment.Left;
            

            TextBox r1b = new TextBox();
            CreateTB(ref r1b, col12, row3, "RECALL", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "123.875", Color.White);
            //r2.TextAlign = HorizontalAlignment.Left;

            TextBox r2b = new TextBox();
            CreateTB(ref r2b, col10, row5, "MK-HI");

            TextBox r2bright = new TextBox();
            CreateTB(ref r2bright, col13, row5, " NAV2", Color.White);

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, "110.30", Color.Green);
            //r3.TextAlign = HorizontalAlignment.Right;

            TextBox r3b = new TextBox();
            CreateTB(ref r3b, col13, row7, " DME2", Color.White);
            
            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, " HOLD", Color.White);
            //r4.TextAlign = HorizontalAlignment.Right;
                       
            
            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }
        
        private void MCDU()
        {
            PopulateNames("MCDU");

            currentPageTitle = "mcdu";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col6, row0, "MCDU MENU");
                       
            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, l2name, Color.White);

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, l3name, Color.White);

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, l4name, Color.White);
                        
            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, r1name, Color.White);
                        
            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col16, row2, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }
        
        
        
        private void DirPage1()
        {

            currentPageTitle = "direct";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col2, row0, "ACT DIRECT-TO");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/1");

            TextBox titleb = new TextBox();
            CreateTB(ref titleb, col6, row1, "HISTORY");
            titleb.TextAlign = HorizontalAlignment.Right;

            TextBox l2b = new TextBox();
            CreateTB(ref l2b, col2, row5, "250" + (char)176);

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "<(6935)", Color.White);

            TextBox l3b = new TextBox();
            CreateTB(ref l3b, col2, row7, "215" + (char)176);

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "<SXW152", Color.White);

            TextBox l4b = new TextBox();
            CreateTB(ref l4b, col2, row9, "R322" + (char)176);

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "<KIRLE", Color.White);
            
            TextBox divider = new TextBox();
            CreateTB(ref divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }
                
        private void FPLNpage1()
        {

            currentPageTitle = "flightplan";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col2, row0, "ACT FPLN");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/4");

            TextBox origin = new TextBox();
            CreateTB(ref origin, col2, row1, "ORIGIN");

            TextBox dist = new TextBox();
            CreateTB(ref dist, col7, row1, "DIST");
            dist.TextAlign = HorizontalAlignment.Right;

            TextBox dest = new TextBox();
            CreateTB(ref dest, col13, row1, "DEST");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "KICT", Color.White);

            TextBox nm = new TextBox();
            CreateTB(ref nm, col8, row2, "452", Color.White);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, "KDEN", Color.White);
            
            TextBox route = new TextBox();
            CreateTB(ref route, col2, row3, "ROUTE");

            TextBox altn = new TextBox();
            CreateTB(ref altn, col13, row3, "ALTN");

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "PLANT2", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "KAPA", Color.White);
            
            TextBox r2b = new TextBox();
            CreateTB(ref r2b, col11, row5, "ORIG RWY");

            TextBox via = new TextBox();
            CreateTB(ref via, col2, row7, "VIA");

            TextBox to = new TextBox();
            CreateTB(ref to, col14, row7, "TO");
            to.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "DIRECT", Color.Green);

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, "ICT", Color.Green);
            
            TextBox divider = new TextBox();
            CreateTB(ref divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "<COPY ACTIVE", Color.White);

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, "<SEC FPLN", Color.White);

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, "PERF INIT", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }
        
        private void ActiveLegsPage1()
        {

            currentPageTitle = "leg";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col2, row0, "ACT LEGS");

            TextBox page = new TextBox();
            CreateTB(ref page, col14, row0, "1/6");

            TextBox sequence = new TextBox();
            CreateTB(ref sequence, col11, row1, "SEQUENCE");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "KICT");

            TextBox l1B = new TextBox();
            CreateTB(ref l1B, col2, row3, "309" + (char)176, Color.Green);

            TextBox l1Bdistance = new TextBox();
            CreateTB(ref l1Bdistance, col5, row3, "12NM", Color.Green);
            l1Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "ICT", Color.Green);

            TextBox l2b = new TextBox();
            CreateTB(ref l2b, col2, row5, "307" + (char)176, Color.White);

            TextBox l2Bdistance = new TextBox();
            CreateTB(ref l2Bdistance, col5, row5, "9.2NM", Color.White);
            l2Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "MUGER", Color.White);

            TextBox l3b = new TextBox();
            CreateTB(ref l3b, col2, row7, "307" + (char)176, Color.White);

            TextBox l3Bdistance = new TextBox();
            CreateTB(ref l3Bdistance, col5, row7, "3.3NM", Color.White);
            l3Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "WUKOL", Color.White);

            TextBox l4b = new TextBox();
            CreateTB(ref l4b, col2, row9, "307" + (char)176, Color.White);

            TextBox l4Bdistance = new TextBox();
            CreateTB(ref l4Bdistance, col5, row9, "0.5NM", Color.White);
            l4Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l5 = new TextBox();
            CreateTB(ref l5, col1, row10, "WUKUS", Color.White);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col9, row2, "AUTO", Color.Green);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col12, row2, "/INHIBIT", Color.White);


            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "- - - / - - - - -", Color.DeepPink);

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, "- - - / - - - - -", Color.DeepPink);

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, "- - - / - - - - -", Color.DeepPink);

            TextBox r5 = new TextBox();
            CreateTB(ref r5, col15, row10, "- - - / - - - - -", Color.DeepPink);

            TextBox divider = new TextBox();
            CreateTB(ref divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, "LEG WIND", Color.White);

            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");


        }

        private void IRSctlPage()
        {
            PopulateNames("IRS CTL");

            currentPageTitle = "FMS1 IRS CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            CreateTB(ref title, col7, row0, "FMS1 IRS CONTROL");

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "IRS  <ENABLED>", Color.Green);

            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, l6name, Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r2title = new TextBox();
            CreateTB(ref r2title, col15, row3, "POS DIFF");

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "- - -° / - . -", Color.White);

            TextBox drift = new TextBox();
            CreateTB(ref drift, col7, row5, "DRIFT");

            TextBox driftData = new TextBox();
            CreateTB(ref driftData, col10, row5, " - . - ", Color.White);

            TextBox NMperHR = new TextBox();
            CreateTB(ref NMperHR, col15, row5, "NM / HR", Color.White);

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        private void VorDmeCtlPage()
        {
            PopulateNames("VORDME CTL");

            currentPageTitle = "VORDME CTL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            CreateTB(ref title, col7, row0, "FMS1 VOR/DME CONTROL ");

            TextBox l1 = new TextBox();
            CreateTB(ref l1, col1, row2, "IOW", Color.White);

            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "- - -", Color.White);
                        
            TextBox r2title = new TextBox();
            CreateTB(ref r2title, col1, row3, "NAVAID INHIBIT");
            CenterMe(r2title);

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "- - -", Color.White);

            TextBox l4 = new TextBox();
            CreateTB(ref l4, col1, row8, "- - -", Color.White);

            TextBox r1 = new TextBox();
            CreateTB(ref r1, col15, row2, "- - -", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col15, row4, "- - -", Color.White);

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col15, row6, "- - -", Color.White);

            TextBox r4 = new TextBox();
            CreateTB(ref r4, col15, row8, "- - -", Color.White);

            TextBox l5title = new TextBox();
            CreateTB(ref l5title, col1, row9, "VOR - USAGE");

            TextBox r5title = new TextBox();
            CreateTB(ref r5title, col15, row9, "DME - USAGE");

            TextBox l5YES = new TextBox();
            CreateTB(ref l5YES, col1, row10, "YES", Color.White);

            TextBox l5slash = new TextBox();
            CreateTB(ref l5slash, col1 + l5YES.Width, row10, "/", Color.White);

            TextBox l5NO = new TextBox();
            CreateTB(ref l5NO, col1 + l5YES.Width +l5slash.Width , row10, "NO", Color.Green);

            TextBox r5YES = new TextBox();
            CreateTB(ref r5YES, col11 + 10, row10, "YES", Color.Green);

            TextBox r5slash = new TextBox();
            CreateTB(ref r5slash, r5YES.Location.X + r5YES.Width, row10, "/", Color.White);

            TextBox r5NO = new TextBox();
            CreateTB(ref r5NO, col15, row10, "NO", Color.White);
            
            TextBox l5b = new TextBox();
            CreateTB(ref l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            CreateTB(ref l6, col1, row12, l6name, Color.White);

            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }


        #region CDU7000 pages

        private void MissionPage()
        {
            CDU7000Page = true;
            currentPageTitle = "mission";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "INDEX");


            TextBox l1 = new TextBox();
            l1name = "< START INIT";
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l2 = new TextBox();
            l2name = "< LOAD SAVE";
            CreateTB(ref l2, col1, row4, l2name, Color.White);

            TextBox l3 = new TextBox();
            l3name = "< ERASE";
            CreateTB(ref l3, col1, row6, l3name, Color.White);

            TextBox l4 = new TextBox();
            l4name = "< COM";
            CreateTB(ref l4, col1, row8, l4name, Color.White);


            TextBox l5 = new TextBox();
            l5name = "< TACAN";
            CreateTB(ref l5, col1, row10, l5name, Color.White);


            TextBox l6 = new TextBox();
            l6name = "< MSG";
            CreateTB(ref l6, col1, row12, l6name, Color.White);

            TextBox r1 = new TextBox();
            r1name = "GPS SA/AS";
            CreateTB(ref r1, col15, row2, r1name, Color.White);

            TextBox r2 = new TextBox();
            r2name = "STATUS";
            CreateTB(ref r2, col15, row4, r2name, Color.White);

            TextBox r3 = new TextBox();
            r3name = " ZEROIZE";
            CreateTB(ref r3, col15, row6, r3name, Color.White);

            TextBox r4 = new TextBox();
            r4name = " SURV";
            CreateTB(ref r4, col15, row8, r4name, Color.White);


            TextBox r1right = new TextBox();
            CreateTB(ref r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            CreateTB(ref r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            CreateTB(ref r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            CreateTB(ref r4right, col16, row8, ">", Color.White);


            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        //Communication Pages

        #region Comm Page

        private void COMpage()
        {
            CDU7000Page = true;
            currentPageTitle = "comm";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            CreateTB(ref title, col7, row0, "COMM");

            TextBox l0 = new TextBox();
            l0name = "!";
            CreateTB(ref l0, col1, row1, l0name, Color.Orange);

            TextBox l0right = new TextBox();
            CreateTB(ref l0right, col2, row1, "V/U1");


            TextBox l1 = new TextBox();
            l1name = "<";
            CreateTB(ref l1, col1, row2, l1name, Color.White);

            TextBox l1right = new TextBox();
            CreateTB(ref l1right, col2, row2, "20  TOWERS  C17", Color.White);

            TextBox lb = new TextBox();
            CreateTB(ref lb, col2, row3, "V/U2");


            TextBox l2 = new TextBox();
            CreateTB(ref l2, col1, row4, "<", Color.White);

            TextBox l2b = new TextBox();
            CreateTB(ref l2b, col1, row5, "!", Color.Orange);

            TextBox l2bright = new TextBox();
            CreateTB(ref l2bright, col2, row5, "HF1 -BASIC-");

            TextBox l3 = new TextBox();
            CreateTB(ref l3, col1, row6, "<", Color.White);


            TextBox r1 = new TextBox();
            CreateTB(ref r1, col17, row2, "45.100", Color.White);

            TextBox r2 = new TextBox();
            CreateTB(ref r2, col17, row4, "F136.075", Color.White);

            TextBox r3 = new TextBox();
            CreateTB(ref r3, col17, row6, "17.0075", Color.White);

            TextBox r6 = new TextBox();
            CreateTB(ref r6, col15, row12, "RETURN", Color.White);



            TextBox r6right = new TextBox();
            CreateTB(ref r6right, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            CreateTB(ref l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            CreateTB(ref r6b, col16, row13, "]");
        }

        #endregion

        #region HFControl Pages

        private void HFcontrolPage1()
        {
            CDU7000Page = true;
        }

        private void HFcontrolPage2()
        {
            CDU7000Page = true;
        }

        private void HFcontrolPage3()
        {
            CDU7000Page = true;
        }

        private void HFpresetChannelsPage()
        {
            CDU7000Page = true;
        }

        private void ALEscanListsPage()
        {
            CDU7000Page = true;
        }

        private void HFALEfunctionPage1()
        {
            CDU7000Page = true;
        }

        private void HFALEfunctionPage2()
        {
            CDU7000Page = true;
        }

        private void HFstandbyFunctionsPage()
        {
            CDU7000Page = true;
        }

        private void ALEaddressPage()
        {
            CDU7000Page = true;
        }

        private void ALEnetAddressPage()
        {
            CDU7000Page = true;
        }

        private void ALEgroupAddressPage()
        {
            CDU7000Page = true;
        }

        #endregion

        #region ARC231 #1 Pages

        private void VU1controlPage1()
        {
            CDU7000Page = true;
        }

        private void VU1controlPage2()
        {
            CDU7000Page = true;
        }

        private void VU1comsecControlPage()
        {
            CDU7000Page = true;
        }

        private void VU1comsecVarPage1()
        {
            CDU7000Page = true;
        }

        private void VU1comsecVarPage2()
        {
            CDU7000Page = true;
        }

        private void VU1sincgarsControlPage()
        {
            CDU7000Page = true;
        }

        private void VU1lockoutsPage()
        {
            CDU7000Page = true;
        }

        private void VU1maintenancePage()
        {
            CDU7000Page = true;
        }

        private void VU1uhfPresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU1vhfFMpresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU1vhfAMpresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU1satcomPrestsPage1()
        {
            CDU7000Page = true;
        }

        private void VU1hopsetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU1loopbackTestPage()
        {
            CDU7000Page = true;
        }

        private void VU1clearNVMPage()
        {
            CDU7000Page = true;
        }

        private void VU1fillPage()
        {
            CDU7000Page = true;
        }

        private void VU1sincgarsFillPage()
        {
            CDU7000Page = true;
        }

        private void VU1transecFillPage()
        {
            CDU7000Page = true;
        }

        private void VU1comsecFillPage()
        {
            CDU7000Page = true;
        }

        private void VU1comsecStatesPage1()
        {
            CDU7000Page = true;
        }

        private void VU1comsecStatesPage2()
        {
            CDU7000Page = true;
        }



        #endregion

        #region ARC231 #2 Pages

        private void VU2controlPage1()
        {
            CDU7000Page = true;
        }

        private void VU2controlPage2()
        {
            CDU7000Page = true;
        }

        private void VU2comsecControlPage()
        {
            CDU7000Page = true;
        }

        private void VU2comsecVarPage1()
        {
            CDU7000Page = true;
        }

        private void VU2comsecVarPage2()
        {
            CDU7000Page = true;
        }

        private void VU2sincgarsControlPage()
        {
            CDU7000Page = true;
        }

        private void VU2lockoutsPage()
        {
            CDU7000Page = true;
        }

        private void VU2maintenancePage()
        {
            CDU7000Page = true;
        }

        private void VU2uhfPresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU2vhfFMpresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU2vhfAMpresetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU2satcomPrestsPage1()
        {
            CDU7000Page = true;
        }

        private void VU2hopsetsPage1()
        {
            CDU7000Page = true;
        }

        private void VU2loopbackTestPage()
        {
            CDU7000Page = true;
        }

        private void VU2clearNVMPage()
        {
            CDU7000Page = true;
        }

        private void VU2fillPage()
        {
            CDU7000Page = true;
        }

        private void VU2sincgarsFillPage()
        {
            CDU7000Page = true;
        }

        private void VU2transecFillPage()
        {
            CDU7000Page = true;
        }

        private void VU2comsecFillPage()
        {
            CDU7000Page = true;
        }

        private void VU2comsecStatesPage1()
        {
            CDU7000Page = true;
        }

        private void VU2comsecStatesPage2()
        {
            CDU7000Page = true;
        }

        #endregion

        //Surveillance Pages

        #region IFF Pages

        private void IFFcontrolPage1()
        {
            CDU7000Page = true;
        }

        private void IFFcontrolPage2()
        {
            CDU7000Page = true;
        }

        private void IFFcontrolPage3()
        {
            CDU7000Page = true;
        }

        #endregion
        

        #endregion

        


        
        
        #endregion

        
        #region button events

        #region left and right buttons

        private void l1Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l1name);
        }

        private void l2Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l2name);
        }

        private void l3Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l3name);
        }

        private void l4Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l4name);
        }

        private void l5Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l5name);
        }

        private void l6Btn_Click(object sender, EventArgs e)
        {
            PageSelection(l6name);
        }



        private void r1Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r1name);
        }

        private void r2Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r2name);
        }

        private void r3Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r3name);
        }

        private void r4Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r4name);
        }

        private void r5Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r5name);
        }

        private void r6Btn_Click(object sender, EventArgs e)
        {
            PageSelection(r6name);
        } 

        #endregion
        
        #region Fixed Buttons

        private void nextBtn_Click(object sender, EventArgs e)
        {
            #region Index pages
            if (currentPageTitle == "index" & currentPageNumber == 1)
            {
                StartFresh();
                IdxPage2();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "index" & currentPageNumber == 2)
                {
                    StartFresh();
                    IdxPage3();
                    UpdateDisplay();
                }
                else
                    if (currentPageTitle == "index" & currentPageNumber == 3)
                    {
                        StartFresh();
                        IdxPage1();
                        UpdateDisplay();
                    }

            #endregion

            #region PosInit pages

            if (currentPageTitle == "posinit" & currentPageNumber == 2)
            {
                StartFresh();
                PosInitPage1();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "posinit" & currentPageNumber == 1)
                {
                    StartFresh();
                    PosInitPage2();
                    UpdateDisplay();
                }
                
            #endregion
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            #region Index pages
            if (currentPageTitle == "index" & currentPageNumber == 3)
            {
                StartFresh();
                IdxPage2();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "index" & currentPageNumber == 1)
                {
                    StartFresh();
                    IdxPage3();
                    UpdateDisplay();
                }
                else
                    if (currentPageTitle == "index" & currentPageNumber == 2)
                    {
                        StartFresh();
                        IdxPage1();
                        UpdateDisplay();
                    }

            #endregion

            #region PosInit pages

            if (currentPageTitle == "posinit" & currentPageNumber == 2)
            {
                StartFresh();
                PosInitPage1();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "posinit" & currentPageNumber == 1)
                {
                    StartFresh();
                    PosInitPage2();
                    UpdateDisplay();
                }

            #endregion
        }

        private void tunBtn_Click(object sender, EventArgs e)
        {
            StartFresh();
            TunPage1();
            UpdateDisplay();
        }
                
        private void idxBtn_Click(object sender, EventArgs e)
        {
            StartFresh();
            IdxPage1();
            UpdateDisplay();
        }
        
        private void dirBtn_Click(object sender, EventArgs e)
        {
            StartFresh();
            DirPage1();
            UpdateDisplay();
        }
        
        private void legsBtn_Click(object sender, EventArgs e)
        {
            StartFresh();
            ActiveLegsPage1();
            UpdateDisplay();
        }

        private void fplnBtn_Click(object sender, EventArgs e)
        {
            StartFresh();
            FPLNpage1();
            UpdateDisplay();
        }

        #endregion
                
        #endregion


        
        #region TextBox manipulation

        private int TbWidth(ref TextBox tb)
        {
            Size size = TextRenderer.MeasureText(tb.Text, tb.Font);
            return size.Width;

        }



        private void PopulateNames(string pageName)
        {
            switch(pageName)
            {
                #region FMS1 IRS Control pages
                case "IRS CTL":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "< INDEX";
                    r1name = "";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "";
                    break;
                #endregion

                #region Index pages
                case "IdxPage1":
                    l1name = "< MCDU MENU";
                    l2name = "< DATALINK";
                    l3name = "< STATUS";
                    l4name = "< POS INIT";
                    l5name = "< IRS CTL";
                    l6name = "< VORDME CTL";
                    r1name = "FREQUENCY";
                    r2name = "GNSS1 POS";
                    r3name = "FIX";
                    r4name = "HOLD";
                    r5name = "PROG";
                    r6name = "SEC FPLN";
                    break;

                case "IdxPage2":
                    l1name = "< GNSS CTL";
                    l2name = "< FMS CTL";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "";
                    r1name = "ROUTE MENU";
                    r2name = "DATA BASE";
                    r3name = "DB DISK OPS";
                    r4name = "DEFAULTS";
                    r5name = "ARR DATA";
                    r6name = "SEARCH";
                    break;

                case "IdxPage3":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "";
                    r1name = "MARK POINTS";
                    r2name = "TEMP COMP";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "";
                    break;
                #endregion
                
                #region Pos Init pages
                case "PosInitPage1":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "< INDEX";
                    r1name = "";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "FPLN";
                    break;

                case "PosInitPage2":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "< NAVAID";
                    l6name = "< INDEX";
                    r1name = "";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "FPLN";
                    break; 
                #endregion

                #region Status pages
                case "StatusPage":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "< INDEX";
                    r1name = "";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "POS INIT";
                    break; 
                #endregion

                #region MCDU pages
                case "MCDU":
                    l1name = "< FMS 1";
                    l2name = "< DL";
                    l3name = "< DBU";
                    l4name = "< MISSION";
                    l5name = "";
                    l6name = "";
                    r1name = "GPS 1 POS";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "";
                    break; 
                #endregion

                #region VORDME Control pages
                case "VORDME CTL":
                    l1name = "";
                    l2name = "";
                    l3name = "";
                    l4name = "";
                    l5name = "";
                    l6name = "< INDEX";
                    r1name = "";
                    r2name = "";
                    r3name = "";
                    r4name = "";
                    r5name = "";
                    r6name = "";
                    break;
                #endregion
            }
        }


        private int CenterMe(TextBox tb)    //centers the text on the screen
        {
            tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth(ref tb) / 2), tb.Location.Y);
            return tb.Location.X;
        }

        
        private void JustifyTBs(ref TextBox tb)
        {
            if (tb.Location.X==col15)
            {
                tb.Location = new Point(tb.Location.X - TbWidth(ref tb), tb.Location.Y);
                tb.TextAlign = HorizontalAlignment.Right;
            }

            if (tb.Location.X == col17 & tb.Text != ">")
            {
                tb.Location = new Point(tb.Location.X - TbWidth(ref tb), tb.Location.Y);
                //tb.TextAlign = HorizontalAlignment.Right;
            }

            if (tb.Location.X == col7 & tb.Location.Y == row0)
            {
                CenterMe(tb);//tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth(ref tb) / 2), tb.Location.Y);
            }
            
        }

        private void CreateTB(ref TextBox myName, int col, int row, string tbText, Color? charColor = null, Color? backgroundColor = null, string fontType = "Arial", int fontSize = 20, FontStyle fstyle = FontStyle.Regular, BorderStyle bstyle = BorderStyle.None)
        {
            
            myName.Location = new Point(col, row);
            
            myName.Text = tbText;
           
            myName.Font = new Font(fontType, fontSize, fstyle);
            myName.Width = TbWidth(ref myName);
            JustifyTBs(ref myName);

            if (charColor == null)
            {
                myName.ForeColor = Color.Cyan;
            }
            else
            {
                myName.ForeColor = (Color)charColor;
            }


            if (backgroundColor == null)
            {
                myName.BackColor = Color.Black;
            }
            else
            {
                myName.BackColor = (Color)backgroundColor;
            }

            myName.BorderStyle = bstyle;
            myName.ReadOnly = true;


            try
            {
                this.Controls.Add(myName);
            }
            catch (Exception)
            {
                
               //throw;
            }

            tbCount++;

        }


        //used to dispose of all the existing ref TextBoxes before creating new ones
        private void StartFresh()
        {
            try
            {
                for (int i = 0; i < tbCount; i++)//iterates through all ref TextBoxes on the form
                {
                    foreach (Control c in this.Controls)
                    {

                        if (c.GetType() == typeof(TextBox))
                        {
                            c.Dispose();
                        }

                    }
                }
                tbCount = 0;//resets tbCount to zero for the next page
                CDU7000Page = false;//resets the bool to false, indicating a CDU3000 page
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        #endregion

        

        #region Select Cases

        private void PageSelection(String e) //used to select the proper Page from the input string
        {
            string trimmedString = TrimSelection(e);   //holds the trimmed version of the passed string argument

            //TrimSelection(e);//trim unnessesary characters from the selection string

            switch (CDU7000Page)//determines if the current page is a CDU 7000 page
            {
                case false://CDU3000 pages are here


                    StartFresh();//clears all ref TextBoxes before writing new page

                    //check current input string
                    switch (trimmedString)
                    {
                        //MCDU page 1
                        case "MCDU MENU":
                            MCDU();
                            break;

                        //INDEX page 1
                        case "INDEX":
                            IdxPage1();
                            break;

                        //IRS CTL page 1
                        case "IRS CTL":
                            IRSctlPage();
                            break;

                        //MISSION page
                        case "MISSION":
                            MissionPage();
                            break;

                        //POS INIT page
                        case "POS INIT":
                            PosInitPage1();
                            break;

                        //MCDU page 1
                        case "STATUS":
                            StatusPage();
                            break;

                        //FPLN page 1
                        case "FPLN":
                            FPLNpage1();
                            break;

                        //VORDME CTL page
                        case "VORDME CTL":
                            VorDmeCtlPage();
                            break;


                    }
                    break;

                case true://CDU7000 pages are here

                    StartFresh();//clears all ref TextBoxes before writing new page


                    //insert cdu7000 switch statements here
                    switch (trimmedString)
                    {
                        //COMM page
                        case "COM":
                            COMpage();
                            break;

                    }
               

                    break;

            }

            UpdateDisplay(); //updates the display after writing the page

        }

        #endregion




        #region Background methods  //backgroundworkers that handle needed tasks not seen by the user


        private string TrimSelection(string e)    //takes input string and reduces it to text only
        {
            char[] charsToTrim = { '<', ' ' };  //defines the dhars to trim
            e = e.Trim(charsToTrim);    //stores the new string
            return e;
        }


        #region Move Form without border

        public void ShowFormBtns()
        {
            closeBtn.Visible = true;
            moveBtn.Visible = true;
        }

        public void HideFormBtns()
        {
            closeBtn.Visible = false;
            moveBtn.Visible = false;
        }

        private void moveBtn_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - this.Left;
            mousey = Cursor.Position.Y - this.Top;

        }

        private void moveBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mousey;
                this.Left = Cursor.Position.X - mousex;
            }
        }

        private void moveBtn_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        #endregion


        #region Development Tools

        //used to update the helper labels on the face of the unit
        private void UpdateDisplay()
        {
            //label3.Text = currentPageTitle;
            //label4.Text = currentPageNumber.ToString();

        }

        #endregion

        

        
        
        #endregion








    }
}
