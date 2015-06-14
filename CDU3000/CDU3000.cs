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

		//To create a new page, add a page method to the page region. Segregate the CDU3000 and CDU7000 methods. Make sure to add a erence to the PopulateNames method
		//Next, add the names of the buttons to the switch statement in the PopulateNames method
		//Finally, add to the switch statement in the PageSelection method to jump to the correct page. Make sure to segregate the CDU3000 and CDU7000 switch statements

		#region Fields

		//Button text
		string l0text = null;
		string l1text = null;
		string l2text = null;
		string l3text = null;
		string l4text = null;
		string l5text = null;
		string l6text = null;

		string r1text = null;
		string r2text = null;
		string r3text = null;
		string r4text = null;
		string r5text = null;
		string r6text = null;

        


		//tracksthe last button pressed
		string btnPressed = null;


		//scratchpad variable
		string scratchpad = null;
			
		

		//variables used for moving the form
		Boolean drag;
		int mousex;
		int mousey;
		
		//variables used to define  TextBox locations on screen
		int row0=51, row1=81, row2=110, row3=140, row4=170, row5=200, row6=232, row7=262, row8=293, row9=323, row10=353, row11=383, row12=414, row13=444, row14=474, row15=504;
		int col1=137, col2=169, col3=201, col4=233, col5=265, col6=297, col7=329, col8=361, col9=393, col10=425, col11=457, col12=489, col13=521, col14=553, col15=600, col16=607, col17=639;
		
		
		
		private int tbCount;//test to see if counting the number of  TextBoxes will help in disposing the TextBoxes
		private string currentPageTitle;//stores the current page title
		private int currentPageNumber;//stores the current page number

		private bool initialLoad = true;//used to track if this is the initial load of the program (status page tried to load every time the mouse was clicked off the application and then clicked back on the form)
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
		
		private void ActiveLegsPage1()
		{

			currentPageTitle = "leg";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB(title, col2, row0, "ACT LEGS");

			TextBox page = new TextBox();
			TB(page, col14, row0, "1/6");

			TextBox sequence = new TextBox();
			TB(sequence, col11, row1, "SEQUENCE");

			TextBox l1 = new TextBox();
			l1text="KICT";
			TB(l1, col1, row2, l1text);

			TextBox l1B = new TextBox();
			TB(l1B, col2, row3, "309" + (char)176, Color.Green);

			TextBox l1Bdistance = new TextBox();
			TB(l1Bdistance, col5, row3, "12NM", Color.Green);
			l1Bdistance.TextAlign = HorizontalAlignment.Right;

			TextBox l2 = new TextBox();
			l2text="ICT";
			TB(l2, col1, row4, l2text, Color.Green);

			TextBox l2b = new TextBox();
			TB(l2b, col2, row5, "307" + (char)176, Color.White);

			TextBox l2Bdistance = new TextBox();
			TB(l2Bdistance, col5, row5, "9.2NM", Color.White);
			l2Bdistance.TextAlign = HorizontalAlignment.Right;

			TextBox l3 = new TextBox();
			l3text="MUGER";
			TB(l3, col1, row6, l3text, Color.White);

			TextBox l3b = new TextBox();
			TB(l3b, col2, row7, "307" + (char)176, Color.White);

			TextBox l3Bdistance = new TextBox();
			TB(l3Bdistance, col5, row7, "3.3NM", Color.White);
			l3Bdistance.TextAlign = HorizontalAlignment.Right;

			TextBox l4 = new TextBox();
			l4text="WUKOL";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l4b = new TextBox();
			TB( l4b, col2, row9, "307" + (char)176, Color.White);

			TextBox l4Bdistance = new TextBox();
			TB( l4Bdistance, col5, row9, "0.5NM", Color.White);
			l4Bdistance.TextAlign = HorizontalAlignment.Right;

			TextBox l5 = new TextBox();
			l5text="WUKUS";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox r1 = new TextBox();
			r1text = "AUTO";
			TB( r1, col9, row2, r1text, Color.Green);
			r1.TextAlign = HorizontalAlignment.Right;

			TextBox r1right = new TextBox();
			TB( r1right, col12, row2, "/INHIBIT", Color.White);


			TextBox r2 = new TextBox();
			r2text="- - - / - - - - -";
			TB( r2, col15, row4, r2text, Color.DeepPink);

			TextBox r3 = new TextBox();
			r3text="- - - / - - - - -";
			TB( r3, col15, row6, r3text, Color.DeepPink);

			TextBox r4 = new TextBox();
			r4text="- - - / - - - - -";
			TB(r4, col15, row8, r4text, Color.DeepPink);

			TextBox r5 = new TextBox();
			r5text="- - - / - - - - -";
			TB( r5, col15, row10, r5text, Color.DeepPink);

			TextBox divider = new TextBox();
			TB( divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox r6 = new TextBox();
			r6text="LEG WIND";
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");

		   
		}
		
		private void DirPage1()
		{

			currentPageTitle = "direct";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB(title, col2, row0, "ACT DIRECT-TO");

			TextBox page = new TextBox();
			TB(page, col14, row0, "1/1");

			TextBox titleb = new TextBox();
			TB(titleb, col6, row1, "HISTORY");
			titleb.TextAlign = HorizontalAlignment.Right;

			TextBox l2b = new TextBox();
			TB( l2b, col2, row5, "250" + (char)176);

			TextBox l3 = new TextBox();
			l3text = "<(6935)";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l3b = new TextBox();
			TB( l3b, col2, row7, "215" + (char)176);

			TextBox l4 = new TextBox();
			l4text = "<(6935)";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l4b = new TextBox();
			TB( l4b, col2, row9, "R322" + (char)176);

			TextBox l5 = new TextBox();
			l5text = "<KIRLE";
			TB( l5, col1, row10, l5text, Color.White);
			
			TextBox divider = new TextBox();
			TB( divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void FixPage1()
		{
			currentPageTitle = "fix";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB(title, col2, row0, "FIX INFO");
			CenterMe(title);

			TextBox page = new TextBox();
			TB(page, col14, row0, "1/1");

			TextBox l1title = new TextBox();
			TB(l1title, col1, row1, "REF");

			TextBox l1 = new TextBox();
			l1text = "SGF";
			TB(l1, col1, row2, l1text, Color.White);
			
			TextBox l2title = new TextBox();
			TB(l2title, col1, row3, "RAD CROSS");

			TextBox l2 = new TextBox();
			l2text = "002°";
			TB(l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB(l3title, col1, row5, "DIS CROSS");

			TextBox l3 = new TextBox();
			l3text = "63.3";
			TB(l3, col1, row6, l3text, Color.White);

			TextBox l4 = new TextBox();
			l4text = "< ABEAM REF";
			TB(l4, col1, row8, l4text, Color.White);

			TextBox l5 = new TextBox();
			l5text = "ABEAM REF";
			TB(l5, col1, row10, l5text, Color.White);
			CenterMe(l5);

			TextBox r2title = new TextBox();
			TB(r2title, col15, row3, "LAT CROSS");

			TextBox r2 = new TextBox();
			r2text="- - - ° - - . - -";
			TB(r2, col15, row4, r2text, Color.White);

			TextBox r3title = new TextBox();
			TB(r3title, col15, row5, "LON CROSS");

			TextBox r3 = new TextBox();
			r3text="- - - - ° - - . - -";
			TB(r3, col15, row6, r3text, Color.White);

			TextBox crs = new TextBox();
			TB(crs, col1, row11, "CRS");

			TextBox crsData = new TextBox();
			TB(crsData, col1, row12, "     ", Color.White);

			TextBox dist = new TextBox();
			TB(dist, col5, row11, "DIST");

			TextBox distData = new TextBox();
			TB(distData, col4+10, row12, "95.4NM", Color.White);

			TextBox ete = new TextBox();
			TB(ete, col10, row11, "ETE");

			TextBox eteData = new TextBox();
			TB(eteData, col10, row12, "0:16", Color.White);

			TextBox fuel = new TextBox();
			TB(fuel, col15, row11, "FUEL");

			TextBox fuelData = new TextBox();
			TB(fuelData, col15, row12, "480", Color.White);

			
			TextBox l6b = new TextBox();
			TB(l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB(r6b, col16, row13, "]");
		}

		private void FmsControlPage()
		{
			PopulateNames("FmsControlPage");

			currentPageTitle = "FMS CONTROL"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox subtitle = new TextBox();
			TB( subtitle, col1, row1, "DISPLAY MODE");
			
			TextBox l1 = new TextBox();
			l1text = "<KIRLE";
			TB( l1, col1, row2, l1text, Color.Green);

			TextBox l1slash = new TextBox();
			TB( l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

			TextBox l1TRUE = new TextBox();
			TB( l1TRUE, l1slash.Location.X + l1slash.Width, row2, "TRUE",Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "FMS COORD MODE");

			TextBox l2 = new TextBox();
			l2text = "<KIRLE";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l2slash = new TextBox();
			TB( l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

			TextBox l2INDEP = new TextBox();
			TB( l2INDEP, l2slash.Location.X + l2slash.Width, row4, "INDEP", Color.Green);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}
				
		private void FPLNpage1()
		{

			currentPageTitle = "flightplan";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col2, row0, "ACT FPLN");

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/4");

			TextBox origin = new TextBox();
			TB( origin, col2, row1, "ORIGIN");

			TextBox dist = new TextBox();
			TB( dist, col7, row1, "DIST");
			dist.TextAlign = HorizontalAlignment.Right;

			TextBox dest = new TextBox();
			TB( dest, col13, row1, "DEST");

			TextBox l1 = new TextBox();
			l1text = "KICT";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox nm = new TextBox();
			TB( nm, col8, row2, "452", Color.White);

			TextBox r1 = new TextBox();
			r1text = "KDEN";
			TB( r1, col15, row2, r1text, Color.White);
			
			TextBox route = new TextBox();
			TB( route, col2, row3, "ROUTE");

			TextBox altn = new TextBox();
			TB( altn, col13, row3, "ALTN");

			TextBox l2 = new TextBox();
			l2text = "PLANT2";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "KAPA";
			TB( r2, col15, row4, r2text, Color.White);
			
			TextBox r2b = new TextBox();
			TB( r2b, col11, row5, "ORIG RWY");

			TextBox via = new TextBox();
			TB( via, col2, row7, "VIA");

			TextBox to = new TextBox();
			TB( to, col14, row7, "TO");
			to.TextAlign = HorizontalAlignment.Right;

			TextBox l4 = new TextBox();
			l4text = "DIRECT";
			TB( l4, col1, row8, l4text, Color.Green);

			TextBox r4 = new TextBox();
			r4text = "ICT";
			TB( r4, col15, row8, r4text, Color.Green);
			
			TextBox divider = new TextBox();
			TB( divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l5 = new TextBox();
			l5text = "<COPY ACTIVE";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			l6text = "<SEC FPLN";
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r6 = new TextBox();
			r6text = "PERF INIT";
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void FrequencyDataPage1()
		{
			PopulateNames("FrequencyDataPage1");

			currentPageTitle = "FREQUENCY DATA"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/2");

			TextBox l1title = new TextBox();
			TB( l1title, col1, row1, "SEL APT");

			TextBox l1 = new TextBox();
			l1text = "KCID";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l1slash1 = new TextBox();
			TB( l1slash1, l1.Location.X + l1.Width, row2, "/", Color.White);

			TextBox l1Loc2 = new TextBox();
			TB( l1Loc2, l1slash1.Location.X + l1slash1.Width, row2, "KMSP", Color.Green);

			TextBox l1slash2 = new TextBox();
			TB( l1slash2, l1Loc2.Location.X + l1Loc2.Width, row2, "/", Color.White);

			TextBox l1Loc3 = new TextBox();
			TB( l1Loc3, l1slash2.Location.X + l1slash2.Width, row2, "KORD", Color.White);

			TextBox l1slash3 = new TextBox();
			TB( l1slash3, l1Loc3.Location.X + l1Loc3.Width, row2, "/", Color.White);

			TextBox l1Loc4 = new TextBox();
			TB( l1Loc4, l1slash3.Location.X + l1slash3.Width, row2, "KDFW", Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "ATIS");

			TextBox l2 = new TextBox();
			l2text = "133.25";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "AWAS");

			TextBox l3 = new TextBox();
			l3text = "121.900";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4title = new TextBox();
			TB( l4title, col1, row7, "GND");

			TextBox l4 = new TextBox();
			l4text = "134.000";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "TCA");

			TextBox l5 = new TextBox();
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "AIRLIFT CP");

			TextBox r2 = new TextBox();
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox r3title = new TextBox();
			TB( r3title, col15, row5, "RDR");

			TextBox r3 = new TextBox();
			r3text = "160.00";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4title = new TextBox();
			TB( r4title, col15, row7, "GPS");

			TextBox r4 = new TextBox();
			r4text = "10120.00";
			TB( r4, col15, row8, r4text, Color.White);

			TextBox r5title = new TextBox();
			TB( r5title, col15, row9, "RFSS");

			TextBox r5 = new TextBox();
			r5text = "110.155";
			TB( r5, col15, row10, r5text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		#region GNSS pages
		private void GNSScontrolPage()
		{
			PopulateNames("GNSS CTL");

			currentPageTitle = "GNSS CTL"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "FMS1 GNSS CONTROL");

			TextBox l1 = new TextBox();
			l1text = "<ENABLED> GNSS1";
			TB( l1, col1, row2, l1text, Color.Green);

			TextBox l2 = new TextBox();
			l2text = "<ENABLED> GNSS2";
			TB( l2, col1, row4, l2text, Color.Green);

			TextBox l5 = new TextBox();
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r1 = new TextBox();
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox r2 = new TextBox();
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox r5title = new TextBox();
			TB( r5title, col15, row9, "3 / 3 ENABLED", Color.Green);

			TextBox r5 = new TextBox();
			TB( r5, col15, row10, r5text, Color.White);

			TextBox r5right = new TextBox();
			TB( r5right, col16, row10, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void GNSS1statusPage1()
		{
			PopulateNames("GNSS1 STATUS");

			currentPageTitle = "GNSS1 STATUS"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "GNSS1 STATUS");

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/2");

			TextBox l1title = new TextBox();
			TB( l1title, col1, row1, "GNSS1 POS");

			TextBox l1 = new TextBox();
			l1text = "N38°10.14 W097°01.29";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "TRK / SPD");

			TextBox l2 = new TextBox();
			l2text = "081° / 331 KT";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "SAT FAULT");

			TextBox l3 = new TextBox();
			l3text = "NO";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4title = new TextBox();
			TB( l4title, col1, row7, "MODE");

			TextBox l4 = new TextBox();
			l4text = "SBAS PA";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "FMS1 POS DIFF");

			TextBox l5 = new TextBox();
			l5text = "081° / 00.05 NM";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "GNSS HEIGHT");

			TextBox r2 = new TextBox();
			r2text = "13400 FT";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3title = new TextBox();
			TB( r3title, col15, row5, "GNSS ALT");

			TextBox r3 = new TextBox();
			r3text = "13300 FT";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4title = new TextBox();
			TB( r4title, col15, row7, "SATELLITES");

			TextBox r4 = new TextBox();
			r4text = "8";
			TB( r4, col15, row8, r4text, Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void GNSS1statusPage2()
		{
			PopulateNames("GNSS1statusPage2");

			currentPageTitle = "GNSS1 STATUS"; //page title and number used for navigating
			currentPageNumber = 2;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox page = new TextBox();
			TB( page, col14, row0, "2/2");

			TextBox l1title = new TextBox();
			TB( l1title, col1, row1, "HAL");

			TextBox l1 = new TextBox();
			l1text = "7409 M / 4.00 NM";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "HPL");

			TextBox l2 = new TextBox();
			l2text = "18 M";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "HFOM");

			TextBox l3 = new TextBox();
			l3text = "6 M";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4title = new TextBox();
			TB( l4title, col1, row7, "HUL");

			TextBox l4 = new TextBox();
			l4text = "12 M";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "SERVICE IN USE");

			TextBox l5 = new TextBox();
			l5text = "WASS     EGNOS";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r1title = new TextBox();
			TB( r1title, col15, row1, "APPR VAL");

			TextBox r1 = new TextBox();
			r1text = "N / A";
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "VPL");

			TextBox r2 = new TextBox();
			r2text = "30 M";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3title = new TextBox();
			TB( r3title, col15, row5, "VFOM");

			TextBox r3 = new TextBox();
			r3text = "12 M";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4title = new TextBox();
			TB( r4title, col15, row7, "GNSS UNITS");

			TextBox r4meters = new TextBox();
			TB( r4meters, col8 + 10, row8, "METERS", Color.Green);

			TextBox r4slash = new TextBox();
			TB( r4slash, r4meters.Location.X + r4meters.Width, row8, "/", Color.White);

			TextBox r4feet = new TextBox();
			TB( r4feet, col15, row8, "FEET", Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void GNSS2statusPage1()
		{
			PopulateNames("GNSS2 STATUS");

			currentPageTitle = "GNSS2 STATUS"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "GNSS2 STATUS");

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/2");

			TextBox l1title = new TextBox();
			TB( l1title, col1, row1, "GNSS2 POS");

			TextBox l1 = new TextBox();
			l1text = "N38°10.14 W097°01.29";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "TRK / SPD");

			TextBox l2 = new TextBox();
			l2text = "081° / 331 KT";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "SAT FAULT");

			TextBox l3 = new TextBox();
			l3text = "NO";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4title = new TextBox();
			TB( l4title, col1, row7, "MODE");

			TextBox l4 = new TextBox();
			l4text = "SBAS PA";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "FMS1 POS DIFF");

			TextBox l5 = new TextBox();
			l5text = "081° / 00.05 NM";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "GNSS HEIGHT");

			TextBox r2 = new TextBox();
			r2text = "13400 FT";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3title = new TextBox();
			TB( r3title, col15, row5, "GNSS ALT");

			TextBox r3 = new TextBox();
			r3text = "13300 FT";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4title = new TextBox();
			TB( r4title, col15, row7, "SATELLITES");

			TextBox r4 = new TextBox();
			r4text = "8";
			TB( r4, col15, row8, r4text, Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void GNSS2statusPage2()
		{
			PopulateNames("GNSS2statusPage2");

			currentPageTitle = "GNSS2 STATUS"; //page title and number used for navigating
			currentPageNumber = 2;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox page = new TextBox();
			TB( page, col14, row0, "2/2");

			TextBox l1title = new TextBox();
			TB( l1title, col1, row1, "HAL");

			TextBox l1 = new TextBox();
			l1text = "7409 M / 4.00 NM";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "HPL");

			TextBox l2 = new TextBox();
			l2text = "18 M";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "HFOM");

			TextBox l3 = new TextBox();
			l3text = "6 M";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4title = new TextBox();
			TB( l4title, col1, row7, "HUL");

			TextBox l4 = new TextBox();
			l4text = "12 M";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "SERVICE IN USE");

			TextBox l5 = new TextBox();
			l5text = "WASS     EGNOS";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r1title = new TextBox();
			TB( r1title, col15, row1, "APPR VAL");

			TextBox r1 = new TextBox();
			r1text = "N / A";
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "VPL");

			TextBox r2 = new TextBox();
			r2text = "30 M";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3title = new TextBox();
			TB( r3title, col15, row5, "VFOM");

			TextBox r3 = new TextBox();
			r3text = "12 M";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4title = new TextBox();
			TB( r4title, col15, row7, "GNSS UNITS");

			TextBox r4meters = new TextBox();
			TB( r4meters, col8 + 10, row8, "METERS", Color.Green);

			TextBox r4slash = new TextBox();
			TB( r4slash, r4meters.Location.X + r4meters.Width, row8, "/", Color.White);

			TextBox r4feet = new TextBox();
			TB( r4feet, col15, row8, "FEET", Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}
		#endregion

        private void HoldPage1()
        {
            currentPageTitle = "hold";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col2, row0, "ACT LEGS");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/4");

            TextBox sequence = new TextBox();
            TB(sequence, col11, row1, "SEQUENCE");

            TextBox l1 = new TextBox();
            l1text = "PEABO";
            TB(l1, col1, row2, l1text);

            TextBox l1B = new TextBox();
            TB(l1B, col2, row3, "079" + (char)176, Color.Green);

            TextBox l1Bdistance = new TextBox();
            TB(l1Bdistance, col5, row3, "115NM", Color.Green);
            l1Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l2 = new TextBox();
            l2text = "BUM";
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2b = new TextBox();
            TB(l2b, col2, row5, "077" + (char)176, Color.White);

            TextBox l2Bdistance = new TextBox();
            TB(l2Bdistance, col5, row5, "131NM", Color.White);
            l2Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l3 = new TextBox();
            l3text = "TRAKE";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "089" + (char)176, Color.White);

            TextBox l3Bdistance = new TextBox();
            TB(l3Bdistance, col5, row7, "25.2NM", Color.White);
            l3Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            l4text = "KAYLA";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "085" + (char)176, Color.White);

            TextBox l4Bdistance = new TextBox();
            TB(l4Bdistance, col5, row9, "11.2NM", Color.White);
            l4Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l5 = new TextBox();
            l5text = "FTZ";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit, Color.White);

            TextBox r1 = new TextBox();
            r1text = "AUTO";
            TB(r1, col9, row2, r1text, Color.Green);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            TB(r1right, col12, row2, "/INHIBIT", Color.White);


            TextBox r2 = new TextBox();
            r2text = "- - - / FL290";
            TB(r2, col15, row4, r2text, Color.DeepPink);

            TextBox r3 = new TextBox();
            r3text = "- - - / FL200";
            TB(r3, col15, row6, r3text, Color.DeepPink);

            TextBox r4 = new TextBox();
            r4text = "- - - / 12000";
            TB(r4, col15, row8, r4text, Color.DeepPink);

            TextBox r4Degree = new TextBox();
            TB(r4Degree, col11, row7, "3.0°", Color.DeepPink);

            TextBox r5 = new TextBox();
            r5text = "- - - /  9000";
            TB(r5, col15, row10, r5text, Color.DeepPink);

            TextBox r5Degree = new TextBox();
            TB(r5Degree, col11, row9, "1.7°", Color.DeepPink);

            TextBox holdAt = new TextBox();
            TB(holdAt, col8, row11, "HOLD AT");
            holdAt.TextAlign = HorizontalAlignment.Center;
            CenterMe(holdAt);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            
            TextBox r6 = new TextBox();
            r6text = "PPOS";
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

		#region Index Pages

		private void IdxPage1()
		{

			PopulateNames("IdxPage1");


			currentPageTitle = "index";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col7, row0, "INDEX");

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/3");

			TextBox l1 = new TextBox();
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2 = new TextBox();
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3 = new TextBox();
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4 = new TextBox();
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l4b = new TextBox();
			TB( l4b, col2, row9, "FMS1", Color.White);

			TextBox l5 = new TextBox();
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col2, row11, "FMS1", Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r1 = new TextBox();
			TB( r1, col15, row2, r1text, Color.White);
			r1.TextAlign = HorizontalAlignment.Right;

			TextBox r2 = new TextBox();
			TB( r2, col15, row4, r2text, Color.White);
			r2.TextAlign = HorizontalAlignment.Right;

			TextBox r3 = new TextBox();
			TB( r3, col15, row6, r3text, Color.White);
			r3.TextAlign = HorizontalAlignment.Right;

			TextBox r4 = new TextBox();
			TB( r4, col15, row8, r4text, Color.White);
			r4.TextAlign = HorizontalAlignment.Right;

			TextBox r5 = new TextBox();
			TB( r5, col15, row10, r5text, Color.White);
			r5.TextAlign = HorizontalAlignment.Right;

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);
			r6.TextAlign = HorizontalAlignment.Right;

			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox r3right = new TextBox();
			TB( r3right, col16, row6, ">", Color.White);

			TextBox r4right = new TextBox();
			TB( r4right, col16, row8, ">", Color.White);

			TextBox r5right = new TextBox();
			TB( r5right, col16, row10, ">", Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");

		}

		private void IdxPage2()
		{
			PopulateNames("IdxPage2");


			currentPageTitle = "index";
			currentPageNumber = 2;

			TextBox title = new TextBox();
			TB( title, col7, row0, "INDEX");

			TextBox page = new TextBox();
			TB( page, col14, row0, "2/3");

			TextBox l1 = new TextBox();
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2 = new TextBox();
			TB( l2, col1, row4, l2text, Color.White);

			TextBox r1 = new TextBox();
			TB( r1, col15, row2, r1text, Color.White);
			r1.TextAlign = HorizontalAlignment.Right;

			TextBox r2 = new TextBox();
			TB( r2, col15, row4, r2text, Color.White);
			r2.TextAlign = HorizontalAlignment.Right;

			TextBox r3 = new TextBox();
			TB( r3, col15, row6, r3text, Color.White);
			r3.TextAlign = HorizontalAlignment.Right;

			TextBox r4 = new TextBox();
			TB( r4, col15, row8, r4text, Color.White);
			r4.TextAlign = HorizontalAlignment.Right;

			TextBox r5 = new TextBox();
			TB( r5, col15, row10, r5text, Color.White);
			r5.TextAlign = HorizontalAlignment.Right;

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);
			r6.TextAlign = HorizontalAlignment.Right;

			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox r3right = new TextBox();
			TB( r3right, col16, row6, ">", Color.White);

			TextBox r4right = new TextBox();
			TB( r4right, col16, row8, ">", Color.White);

			TextBox r5right = new TextBox();
			TB( r5right, col16, row10, ">", Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void IdxPage3()
		{
			PopulateNames("IdxPage3");


			currentPageTitle = "index";
			currentPageNumber = 3;

			TextBox title = new TextBox();
			TB( title, col7, row0, "INDEX");

			TextBox page = new TextBox();
			TB( page, col14, row0, "3/3");


			TextBox r1 = new TextBox();
			TB( r1, col15, row2, r1text, Color.White);
			r1.TextAlign = HorizontalAlignment.Right;

			TextBox r2 = new TextBox();
			TB( r2, col15, row4, r2text, Color.White);
			r2.TextAlign = HorizontalAlignment.Right;

			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		#endregion
		
		private void IRSctlPage()
		{
			PopulateNames("IRS CTL");

			currentPageTitle = "FMS1 IRS CONTROL"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "FMS1 IRS CONTROL");

			TextBox l2 = new TextBox();
			l2text = "IRS  <ENABLED>";
			TB( l2, col1, row4, l2text, Color.Green);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "POS DIFF");

			TextBox r2 = new TextBox();
			r2text = "- - -° / - . -";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox drift = new TextBox();
			TB( drift, col7, row5, "DRIFT");

			TextBox driftData = new TextBox();
			TB( driftData, col10, row5, " - . - ", Color.White);

			TextBox NMperHR = new TextBox();
			TB( NMperHR, col15, row5, "NM / HR", Color.White);

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void MCDU()
		{
			PopulateNames("MCDU");

			currentPageTitle = "mcdu";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col6, row0, "MCDU MENU");

			TextBox l1 = new TextBox();
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2 = new TextBox();
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3 = new TextBox();
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4 = new TextBox();
			TB( l4, col1, row8, l4text, Color.White);

			TextBox r1 = new TextBox();
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void NonPrecisionApprRaimPage()
		{
			PopulateNames("NonPrecisionApprRaimPage");

			currentPageTitle = "NON PRECISION"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox subtitle = new TextBox();
			TB( subtitle, col1, row1, "APPROACH RAIM");
			CenterMe(subtitle);

			TextBox l2title = new TextBox();
			TB( l2title, col1, row3, "DEST");

			TextBox l2titleCenter = new TextBox();
			TB( l2titleCenter, col3, row3, "NPA RAIM");
			CenterMe(l2titleCenter);

			TextBox l2center = new TextBox();
			TB( l2center, col3, row4, "AVAILABLE",Color.White);
			CenterMe(l2center);

			TextBox l2 = new TextBox();
			l2text = "KORD";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3title = new TextBox();
			TB( l3title, col1, row5, "SATELLITE DESELECT");
			CenterMe(l3title);

			TextBox l3 = new TextBox();
			l3text = "1    5   10  13  24";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r2title = new TextBox();
			TB( r2title, col15, row3, "ETA");

			TextBox r2 = new TextBox();
			r2text = "07:05";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		#region  PosInit Pages

		private void PosInitPage1()
		{

			PopulateNames("PosInitPage1");

			currentPageTitle = "posinit";
			currentPageNumber = 1;

			TextBox title = new TextBox();            
			TB( title, col7, row0, "POS INIT");

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/2");

			TextBox l1Title = new TextBox();
			TB( l1Title, col2, row1, "FMS POS");

			TextBox l1 = new TextBox();
			l1text = "N00°00.00 E000°00.00";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2Title = new TextBox();
			TB( l2Title, col2, row3, "AIRPORT");

			TextBox l2 = new TextBox();
			l2text = "KNEL";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3Title = new TextBox();
			TB( l3Title, col2, row5, "PILOT/ WPT");

			TextBox l3 = new TextBox();
			l3text = "- - - - -";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "N40°02.0 W074°21.2";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r5Title = new TextBox();
			TB( r5Title, col8, row9, "SET POS");

			TextBox r5 = new TextBox();
			r5text = emptyLatLong;
			TB( r5, col15, row10, r5text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox r6 = new TextBox();
			r6text = "FPLN";
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6 = new TextBox();
			l6text = "< INDEX";
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}
		

		private void PosInitPage2()
		{
			PopulateNames("PosInitPage2");

			currentPageTitle = "posinit";
			currentPageNumber = 2;

			TextBox title = new TextBox();
			TB( title, col7, row0, "POS INIT");

			TextBox page = new TextBox();
			TB( page, col14, row0, "2/2");

			TextBox l1Title = new TextBox();
			TB( l1Title, col2, row1, "FMS POS");

			TextBox l1 = new TextBox();
			l1text = "N38°15.59 W094°52.82";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2Title = new TextBox();
			TB( l2Title, col2, row3, "GNSS1");

			TextBox l2 = new TextBox();
			l2text = "N38°15.58 W094°52.87";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3Title = new TextBox();
			TB( l3Title, col2, row5, "GNSS2");

			TextBox l3 = new TextBox();
			l3text = "N38°15.57 W094°52.84";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col2, row9, "UPDATE FROM", Color.White);

			TextBox l5 = new TextBox();
			l5text = "< NAVAID";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox r1title = new TextBox();
			TB( r1title, col15, row1, "GS");

			TextBox r1 = new TextBox();
			r1text = "406";
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "406";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3 = new TextBox();
			r3text = "406";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r5Title = new TextBox();
			TB( r5Title, col15, row9, "NAVAID");

			TextBox r5 = new TextBox();
			r5text = "BUM";
			TB( r5, col15, row10, r5text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox r6 = new TextBox();
			r6text = "FPLN";
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l6 = new TextBox();
			l6text="< INDEX";
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		#endregion

        private void ProgressPage1()
        {
            currentPageTitle = "progress";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col2, row0, "PROGRESS");
            CenterMe(title);

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, " LAST");

            TextBox dist = new TextBox();
            TB(dist, col5, row1, "DIST");

            TextBox ete = new TextBox();
            TB(ete, col9, row1, "ETE");

            TextBox fuel = new TextBox();
            TB(fuel, col15, row1, "FUEL-LB");


            TextBox l1 = new TextBox();
            l1text = "PEABO";
            TB(l1, col1, row2, l1text);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, " TO");

            TextBox l2 = new TextBox();
            l2text = "BUM";
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, " NEXT");

            TextBox l3 = new TextBox();
            l3text = "TRAKE";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, " DEST");

            TextBox l4 = new TextBox();
            l4text = "KSTL";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, " ALTN");

            TextBox l5 = new TextBox();
            l5text = "KBLV";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6title = new TextBox();
            TB(l6title, col1, row11, " NAVIGATION");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, "GNSS1", Color.Green);
            CenterMe(l6);

            TextBox l1dist = new TextBox();
            TB(l1dist, col5, row2, "53.2");
            
            TextBox l2dist = new TextBox();
            TB(l2dist, col5, row4, "83.4", Color.Green);

            TextBox l3dist = new TextBox();
            TB(l3dist, col5, row6, "214",Color.White);

            TextBox l4dist = new TextBox();
            TB(l4dist, col5, row8, "299", Color.White);

            TextBox l5dist = new TextBox();
            TB(l5dist, col5, row10, "326", Color.White);


            TextBox l2ete = new TextBox();
            TB(l2ete, col9, row4, "0:11", Color.Green);

            TextBox l3ete = new TextBox();
            TB(l3ete, col9, row6, "0:28", Color.White);

            TextBox l4ete = new TextBox();
            TB(l4ete, col9, row8, "0:40", Color.White);

            TextBox l5ete = new TextBox();
            TB(l5ete, col9, row10, "0:42", Color.White);



            TextBox l1fuel = new TextBox();
            TB(l1fuel, col15, row2, "2280");

            TextBox l2fuel = new TextBox();
            TB(l2fuel, col15, row4, "1710",Color.Green);

            TextBox l3fuel = new TextBox();
            TB(l3fuel, col15, row6, "1140", Color.White);

            TextBox l4fuel = new TextBox();
            TB(l4fuel, col15, row8, "730", Color.White);

            TextBox l5fuel = new TextBox();
            TB(l5fuel, col15, row10, "570", Color.White);


            

            


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

		private void SBASpage()
		{
			PopulateNames("SBASpage");

			currentPageTitle = "SBAS"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, currentPageTitle);

			TextBox subtitle = new TextBox();
			TB( subtitle, col1, row1, "SERVICE PROVIDERS");
			CenterMe(subtitle);

			TextBox l1 = new TextBox();
			l1text = "WASS   <ENABLED>";
			TB( l1, col1, row2, l1text, Color.Green);

			TextBox l2 = new TextBox();
			l2text = "EGNOS <ENABLED>";
			TB( l2, col1, row4, l2text, Color.Green);

			TextBox l3 = new TextBox();
			l3text = "MSAS   <ENABLED>";
			TB( l3, col1, row6, l3text, Color.Green);

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);

			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

        private void SECFPLNpage1()
        {

            l2text = "LINDYHOP";


            PopulateNames("SECFPLNpage1");

            currentPageTitle = "SEC FPLN"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col2, row0, currentPageTitle+" "+l2text);

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/3");

            TextBox origin = new TextBox();
            TB(origin, col2, row1, "ORIGIN");

            TextBox dist = new TextBox();
            TB(dist, col8, row1, "DIST");

            TextBox l1dist = new TextBox();
            TB(l1dist, col8, row2, "249", Color.White);

            TextBox dest = new TextBox ();
            TB(dest, col15, row1, "DEST");
            

            TextBox l1 = new TextBox();
            l1text = "KSTL";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col2, row3, "ROUTE");

            TextBox l2 = new TextBox();
            
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col2, row7, "VIA");

            TextBox l4 = new TextBox();
            l4text = "CARDS6.CAP";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l6 = new TextBox();
            l6text = "< SEC LEGS";
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            l1text = "KCID";
            TB(r1, col15, row2, l1text, Color.White);

            TextBox altn = new TextBox();
            TB(altn, col15, row3, "ALTN");

            TextBox r2 = new TextBox();
            l2text = "KDVN";
            TB(r2, col15, row4, l2text, Color.White);

            TextBox origRwy = new TextBox();
            TB(origRwy, col15, row5, "ORIG RWY");

            TextBox r3 = new TextBox();
            l3text = "RW12R";
            TB(r3, col15, row6, l3text, Color.White);

            TextBox to = new TextBox();
            TB(to, col15, row7, "TO");

            TextBox r4 = new TextBox();
            r4text = "CAP";
            TB(r4, col15, row8, r4text, Color.Green);

            TextBox r5 = new TextBox();
            r5text = "ACTIVATE";
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r5right = new TextBox();
            TB(r5right, col16, row10, ">", Color.White);

            TextBox l5 = new TextBox();
            l5text = "< ROUTE MENU";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

		private void StatusPage()
		{

			PopulateNames("StatusPage");

			currentPageTitle = "status"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "STATUS");

			TextBox navData = new TextBox();
			TB( navData, col2, row1, "NAV DATA");

			TextBox l1 = new TextBox();
			l1text = "WORLD";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l1b = new TextBox();
			TB( l1b, col2, row3, "ACTIVE DATA BASE");

			TextBox l2 = new TextBox();
			l2text = "09JAN15 05FEB15";
			TB( l2, col1, row4, l2text, Color.Yellow);

			TextBox l2b = new TextBox();
			TB( l2b, col2, row5, "SEC DATA BASE");

			TextBox l3 = new TextBox();
			l3text = "06SEP15 03OCT15";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l3b = new TextBox();
			TB( l3b, col2, row7, "UTC");

			TextBox l4 = new TextBox();
			l4text = "12:00";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox l4b = new TextBox();
			TB( l4b, col2, row9, "PROGRAM");

			TextBox l5 = new TextBox();
			l5text="SCID D 001 CNN107";
			TB( l5, col1, row10, l5text, Color.White);

			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r3b = new TextBox();
			TB( r3b, col13, row7, " DATE");

			TextBox r4 = new TextBox();
			r4text="12MAY15";
			TB( r4, col15, row8, r4text, Color.White);

			TextBox r6 = new TextBox();
			TB( r6, col15, row12, r6text, Color.White);


			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);

			

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void TunPage1()
		{
			currentPageTitle = "tune";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col7, row0, "TUNE");

			TextBox com1 = new TextBox();
			TB( com1, col2, row1, "COM1", Color.White);

			TextBox com2 = new TextBox();
			TB( com2, col13, row1, "COM2", Color.White);

			TextBox page = new TextBox();
			TB( page, col14, row0, "1/2");

			TextBox l1 = new TextBox();
			l1text = "122.875";
			TB( l1, col1, row2, l1text, Color.Green);

			TextBox l1b = new TextBox();
			TB( l1b, col2, row3, "RECALL", Color.White);

			TextBox l2 = new TextBox();
			l2text = "134.250";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l2b = new TextBox();
			TB( l2b, col2, row5, "NAV1", Color.White);

			TextBox l3 = new TextBox();
			l3text = "113.80/ICT";
			TB( l3, col1, row6, l3text, Color.Green);

			TextBox l3b = new TextBox();
			TB( l3b, col2, row7, "DME1", Color.White);

			TextBox l4 = new TextBox();
			l4text = "HOLD";
			TB( l4, col1, row8, l4text);

			TextBox l4right = new TextBox();
			TB( l4right, col4, row8, "116.80", Color.Green);

			TextBox l4b = new TextBox();
			TB( l4b, col2, row9, "ATC1", Color.White);

			TextBox l5 = new TextBox();
			l5text = "3144";
			TB( l5, col1, row10, l5text, Color.Green);


			TextBox l5b = new TextBox();
			TB( l5b, col2, row11, "ADF", Color.White);

			TextBox l6 = new TextBox();
			l6text = "412.5";
			TB( l6, col1, row12, l6text, Color.Green);

			TextBox r1 = new TextBox();
			r1text = "121.700";
			TB( r1, col15, row2, r1text, Color.Green);
			//r1.TextAlign = HorizontalAlignment.Left;


			TextBox r1b = new TextBox();
			TB( r1b, col12, row3, "RECALL", Color.White);

			TextBox r2 = new TextBox();
			r2text = "123.875";
			TB( r2, col15, row4, r2text, Color.White);
			//r2.TextAlign = HorizontalAlignment.Left;

			TextBox r2b = new TextBox();
			TB( r2b, col10, row5, "MK-HI");

			TextBox r2bright = new TextBox();
			TB( r2bright, col13, row5, " NAV2", Color.White);

			TextBox r3 = new TextBox();
			r3text = "110.30";
			TB( r3, col15, row6, r3text, Color.Green);
			//r3.TextAlign = HorizontalAlignment.Right;

			TextBox r3b = new TextBox();
			TB( r3b, col13, row7, " DME2", Color.White);

			TextBox r4 = new TextBox();
			r4text = " HOLD";
			TB( r4, col15, row8, r4text, Color.White);
			//r4.TextAlign = HorizontalAlignment.Right;


			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		private void VorDmeCtlPage()
		{
			PopulateNames("VORDME CTL");

			currentPageTitle = "VORDME CTL"; //page title and number used for navigating
			currentPageNumber = 1;

			TextBox title = new TextBox();//displayed top center of screen
			TB( title, col7, row0, "FMS1 VOR/DME CONTROL");

			TextBox l1 = new TextBox();
			l1text = "IOW";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2 = new TextBox();
			l2text = "- - -";
			TB( l2, col1, row4, l2text, Color.White);
						
			TextBox r2title = new TextBox();
			TB( r2title, col1, row3, "NAVAID INHIBIT");
			CenterMe(r2title);

			TextBox l3 = new TextBox();
			l3text = "- - -";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4 = new TextBox();
			l4text = "- - -";
			TB( l4, col1, row8, l4text, Color.White);

			TextBox r1 = new TextBox();
			r1text = "- - -";
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "- - -";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3 = new TextBox();
			r3text = "- - -";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4 = new TextBox();
			r4text = "- - -";
			TB( r4, col15, row8, r4text, Color.White);

			TextBox l5title = new TextBox();
			TB( l5title, col1, row9, "VOR - USAGE");

			TextBox r5title = new TextBox();
			TB( r5title, col15, row9, "DME - USAGE");

			TextBox l5YES = new TextBox();
			TB( l5YES, col1, row10, "YES", Color.White);

			TextBox l5slash = new TextBox();
			TB( l5slash, col1 + l5YES.Width, row10, "/", Color.White);

			TextBox l5NO = new TextBox();
			TB( l5NO, col1 + l5YES.Width +l5slash.Width , row10, "NO", Color.Green);

			TextBox r5YES = new TextBox();
			TB( r5YES, col11 + 10, row10, "YES", Color.Green);

			TextBox r5slash = new TextBox();
			TB( r5slash, r5YES.Location.X + r5YES.Width, row10, "/", Color.White);

			TextBox r5NO = new TextBox();
			TB( r5NO, col15, row10, "NO", Color.White);
			
			TextBox l5b = new TextBox();
			TB( l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

			TextBox l6 = new TextBox();
			TB( l6, col1, row12, l6text, Color.White);

			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");


			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		


		#region CDU7000 pages

		private void MissionPage()
		{
			CDU7000Page = true;
			currentPageTitle = "mission";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col7, row0, "INDEX");


			TextBox l1 = new TextBox();
			l1text = "< START INIT";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l2 = new TextBox();
			l2text = "< LOAD SAVE";
			TB( l2, col1, row4, l2text, Color.White);

			TextBox l3 = new TextBox();
			l3text = "< ERASE";
			TB( l3, col1, row6, l3text, Color.White);

			TextBox l4 = new TextBox();
			l4text = "< COM";
			TB( l4, col1, row8, l4text, Color.White);


			TextBox l5 = new TextBox();
			l5text = "< TACAN";
			TB( l5, col1, row10, l5text, Color.White);


			TextBox l6 = new TextBox();
			l6text = "< MSG";
			TB( l6, col1, row12, l6text, Color.White);

			TextBox r1 = new TextBox();
			r1text = "GPS SA/AS";
			TB( r1, col15, row2, r1text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "STATUS";
			TB( r2, col15, row4, r2text, Color.White);

			TextBox r3 = new TextBox();
			r3text = " ZEROIZE";
			TB( r3, col15, row6, r3text, Color.White);

			TextBox r4 = new TextBox();
			r4text = " SURV";
			TB( r4, col15, row8, r4text, Color.White);


			TextBox r1right = new TextBox();
			TB( r1right, col16, row2, ">", Color.White);

			TextBox r2right = new TextBox();
			TB( r2right, col16, row4, ">", Color.White);

			TextBox r3right = new TextBox();
			TB( r3right, col16, row6, ">", Color.White);

			TextBox r4right = new TextBox();
			TB( r4right, col16, row8, ">", Color.White);


			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
		}

		//Communication Pages

		#region Comm Page

		private void COMpage()
		{
			CDU7000Page = true;
			currentPageTitle = "comm";
			currentPageNumber = 1;

			TextBox title = new TextBox();
			TB( title, col7, row0, "COMM");

			TextBox l0 = new TextBox();
			l0text = "!";
			TB( l0, col1, row1, l0text, Color.Orange);

			TextBox l0right = new TextBox();
			TB( l0right, col2, row1, "V/U1");


			TextBox l1 = new TextBox();
			l1text = "<";
			TB( l1, col1, row2, l1text, Color.White);

			TextBox l1right = new TextBox();
			TB( l1right, col2, row2, "20  TOWERS  C17", Color.White);

			TextBox lb = new TextBox();
			TB( lb, col2, row3, "V/U2");


			TextBox l2 = new TextBox();
			TB( l2, col1, row4, "<", Color.White);

			TextBox l2b = new TextBox();
			TB( l2b, col1, row5, "!", Color.Orange);

			TextBox l2bright = new TextBox();
			TB( l2bright, col2, row5, "HF1 -BASIC-");

			TextBox l3 = new TextBox();
			TB( l3, col1, row6, "<", Color.White);


			TextBox r1 = new TextBox();
			r1text = "45.100";
			TB( r1, col17, row2, r1text, Color.White);

			TextBox r2 = new TextBox();
			r2text = "F136.075";
			TB( r2, col17, row4, r2text, Color.White);

			TextBox r3 = new TextBox();
			r3text = "17.0075";
			TB( r3, col17, row6, r3text, Color.White);

			TextBox r6 = new TextBox();
			r6text = "RETURN";
			TB( r6, col15, row12, r6text, Color.White);



			TextBox r6right = new TextBox();
			TB( r6right, col16, row12, ">", Color.White);


			TextBox l6b = new TextBox();
			TB( l6b, col1, row13, "[");

			TextBox r6b = new TextBox();
			TB( r6b, col16, row13, "]");
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
			btnPressed = "l1";
			PageSelection(l1text);
		}

		private void l2Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "l2";
			PageSelection(l2text);
		}

		private void l3Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "l3";
			PageSelection(l3text);
		}

		private void l4Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "l4";
			PageSelection(l4text);
		}

		private void l5Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "l5";
			PageSelection(l5text);
		}

		private void l6Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "l6";
			PageSelection(l6text);
		}



		private void r1Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r1";
			PageSelection(r1text);
		}

		private void r2Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r2";
			PageSelection(r2text);
		}

		private void r3Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r3";
			PageSelection(r3text);
		}

		private void r4Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r4";            
			PageSelection(r4text);
		}

		private void r5Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r5";
			PageSelection(r5text);
		}

		private void r6Btn_Click(object sender, EventArgs e)
		{
			btnPressed = "r6";
			PageSelection(r6text);
		} 

		#endregion
		
		#region Fixed Buttons

		private void nextBtn_Click(object sender, EventArgs e)
		{
			#region GNSS1 pages

			if (currentPageTitle == "GNSS1 STATUS" & currentPageNumber == 2)
			{
				StartFresh();
				GNSS1statusPage1();
				UpdateDisplay();
			}
			else
				if (currentPageTitle == "GNSS1 STATUS" & currentPageNumber == 1)
				{
					StartFresh();
					GNSS1statusPage2();
					UpdateDisplay();
				}

			#endregion

			#region GNSS2 pages

			if (currentPageTitle == "GNSS2 STATUS" & currentPageNumber == 2)
			{
				StartFresh();
				GNSS2statusPage1();
				UpdateDisplay();
			}
			else
				if (currentPageTitle == "GNSS2 STATUS" & currentPageNumber == 1)
				{
					StartFresh();
					GNSS2statusPage2();
					UpdateDisplay();
				}

			#endregion

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
			#region GNSS1 pages

			if (currentPageTitle == "GNSS1 STATUS" & currentPageNumber == 2)
			{
				StartFresh();
				GNSS1statusPage1();
				UpdateDisplay();
			}
			else
				if (currentPageTitle == "GNSS1 STATUS" & currentPageNumber == 1)
				{
					StartFresh();
					GNSS1statusPage2();
					UpdateDisplay();
				}

			#endregion

			#region GNSS2 pages

			if (currentPageTitle == "GNSS2 STATUS" & currentPageNumber == 2)
			{
				StartFresh();
				GNSS2statusPage1();
				UpdateDisplay();
			}
			else
				if (currentPageTitle == "GNSS2 STATUS" & currentPageNumber == 1)
				{
					StartFresh();
					GNSS2statusPage2();
					UpdateDisplay();
				}

			#endregion

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

		private void clrDelBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (scratchpad.Length != 0)//deletes one character per button push
				{
					scratchpad = scratchpad.Remove(scratchpad.Length - 1);
					sPad.Text = scratchpad;
				}
			}
			catch (Exception)
			{
				
				
			}
		}

		#region Delete Button and Timer
		private void clrDelBtn_MouseDown(object sender, MouseEventArgs e)
		{
			DeleteBtnTimer.Start();
		}

		private void clrDelBtn_MouseUp(object sender, MouseEventArgs e)
		{
			DeleteBtnTimer.Stop();
		}

		private void DeleteBtnTimer_Tick(object sender, EventArgs e)
		{
			scratchpad = null;
			sPad.Text = scratchpad;
			DeleteBtnTimer.Stop();
		} 
		#endregion



		
		#region Letters
		private void btnA_Click(object sender, EventArgs e)
		{
			Scratch("A");
		}

		private void btnB_Click(object sender, EventArgs e)
		{
			Scratch("B");
		}

		private void btnC_Click(object sender, EventArgs e)
		{
			Scratch("C");
		}

		private void btnD_Click(object sender, EventArgs e)
		{
			Scratch("D");
		}

		private void btnE_Click(object sender, EventArgs e)
		{
			Scratch("E");
		}

		private void btnF_Click(object sender, EventArgs e)
		{
			Scratch("F");
		}

		private void btnG_Click(object sender, EventArgs e)
		{
			Scratch("G");
		}

		private void btnH_Click(object sender, EventArgs e)
		{
			Scratch("H");
		}

		private void btnI_Click(object sender, EventArgs e)
		{
			Scratch("I");
		}

		private void btnJ_Click(object sender, EventArgs e)
		{
			Scratch("J");
		}

		private void btnK_Click(object sender, EventArgs e)
		{
			Scratch("K");
		}

		private void btnL_Click(object sender, EventArgs e)
		{
			Scratch("L");
		}

		private void btnM_Click(object sender, EventArgs e)
		{
			Scratch("M");
		}

		private void btnN_Click(object sender, EventArgs e)
		{
			Scratch("N");
		}

		private void btnO_Click(object sender, EventArgs e)
		{
			Scratch("O");
		}

		private void btnP_Click(object sender, EventArgs e)
		{
			Scratch("P");
		}

		private void btnQ_Click(object sender, EventArgs e)
		{
			Scratch("Q");
		}

		private void btnR_Click(object sender, EventArgs e)
		{
			Scratch("R");
		}

		private void btnS_Click(object sender, EventArgs e)
		{
			Scratch("S");
		}

		private void btnT_Click(object sender, EventArgs e)
		{
			Scratch("T");
		}

		private void btnU_Click(object sender, EventArgs e)
		{
			Scratch("U");
		}

		private void btnV_Click(object sender, EventArgs e)
		{
			Scratch("V");
		}

		private void btnW_Click(object sender, EventArgs e)
		{
			Scratch("W");
		}

		private void btnX_Click(object sender, EventArgs e)
		{
			Scratch("X");
		}

		private void btnY_Click(object sender, EventArgs e)
		{
			Scratch("Y");
		}

		private void btnZ_Click(object sender, EventArgs e)
		{
			Scratch("Z");
		}

		private void btnSP_Click(object sender, EventArgs e)
		{

		}

		private void btnSlash_Click(object sender, EventArgs e)
		{
			Scratch("/");
		} 
		#endregion

		#region Numbers
		private void btn1_Click(object sender, EventArgs e)
		{
			Scratch("1");
		}

		private void btn2_Click(object sender, EventArgs e)
		{
			Scratch("2");
		}

		private void btn3_Click(object sender, EventArgs e)
		{
			Scratch("3");
		}

		private void btn4_Click(object sender, EventArgs e)
		{
			Scratch("4");
		}

		private void btn5_Click(object sender, EventArgs e)
		{
			Scratch("5");
		}

		private void btn6_Click(object sender, EventArgs e)
		{
			Scratch("6");
		}

		private void btn7_Click(object sender, EventArgs e)
		{
			Scratch("7");
		}

		private void btn8_Click(object sender, EventArgs e)
		{
			Scratch("8");
		}

		private void btn9_Click(object sender, EventArgs e)
		{
			Scratch("9");
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			Scratch("0");
		}

		private void btnPeriod_Click(object sender, EventArgs e)
		{
			Scratch(".");
		}

		private void btnPlusMinus_Click(object sender, EventArgs e)
		{

		} 
		#endregion



		#endregion
				
		#endregion


		
		#region TextBox manipulation

		private int TbWidth( TextBox tb)
		{
			Size size = TextRenderer.MeasureText(tb.Text, tb.Font);
			return size.Width;

		}



		private void PopulateNames(string pageName)
		{
			switch(pageName)
			{
				#region FMS1 GNSS Control Pages
				case "GNSS CTL":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "< NPA RAIM";
					l6text = "< INDEX";
					r1text = "STATUS";
					r2text = "STATUS";
					r3text = "";
					r4text = "";
					r5text = "SELECT SBAS";
					r6text = "";
					break; 
				#endregion

				#region FMS1 GNSS1 STATUS Pages
				case "GNSS1 STATUS":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "GNSS CTL";
					break;
				#endregion

				#region GNSS1statusPage2
				case "GNSS1statusPage2":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "GNSS CTL";
					break;
				#endregion

				#region FmsControlPage
				case "FmsControlPage":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break;
				#endregion

				#region FMS1 GNSS2 STATUS Pages
				case "GNSS2 STATUS":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "GNSS CTL";
					break;
				#endregion

				#region FMS1 IRS Control pages
				case "IRS CTL":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break;
				#endregion

				#region FrequencyDataPage1
				case "FrequencyDataPage1":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "< MULTIPLE";
					l6text = "< INDEX";
					r1text = "";
					r2text = "MULTIPLE";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break;
				#endregion

				#region Index pages
				case "IdxPage1":
					l1text = "< MCDU MENU";
					l2text = "< DATALINK";
					l3text = "< STATUS";
					l4text = "< POS INIT";
					l5text = "< IRS CTL";
					l6text = "< VORDME CTL";
					r1text = "FREQUENCY";
					r2text = "GNSS1 POS";
					r3text = "FIX";
					r4text = "HOLD";
					r5text = "PROG";
					r6text = "SEC FPLN";
					break;

				case "IdxPage2":
					l1text = "< GNSS CTL";
					l2text = "< FMS CTL";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "";
					r1text = "ROUTE MENU";
					r2text = "DATA BASE";
					r3text = "DB DISK OPS";
					r4text = "DEFAULTS";
					r5text = "ARR DATA";
					r6text = "SEARCH";
					break;

				case "IdxPage3":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "";
					r1text = "MARK POINTS";
					r2text = "TEMP COMP";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break;
				#endregion

				#region NonPrecisionApprRaimPage
				case "NonPrecisionApprRaimPage":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "GNSS CTL";
					break;
				#endregion

				#region Pos Init pages
				case "PosInitPage1":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "FPLN";
					break;

				case "PosInitPage2":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "< NAVAID";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "FPLN";
					break; 
				#endregion

				#region SBASpage
				case "SBASpage":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "GNSS CTL";
					break;
				#endregion

				#region Status pages
				case "StatusPage":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "POS INIT";
					break; 
				#endregion

				#region MCDU pages
				case "MCDU":
					l1text = "< FMS 1";
					l2text = "< DL";
					l3text = "< DBU";
					l4text = "< MISSION";
					l5text = "";
					l6text = "";
					r1text = "GPS 1 POS";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break; 
				#endregion

				#region VORDME Control pages
				case "VORDME CTL":
					l1text = "";
					l2text = "";
					l3text = "";
					l4text = "";
					l5text = "";
					l6text = "< INDEX";
					r1text = "";
					r2text = "";
					r3text = "";
					r4text = "";
					r5text = "";
					r6text = "";
					break;
				#endregion
			}
		}


		private int CenterMe(TextBox tb)    //centers the text on the screen
		{
			tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth( tb) / 2), tb.Location.Y);
			return tb.Location.X;
		}

		
		private void JustifyTBs( TextBox tb)
		{
			if (tb.Location.X==col15)
			{
				tb.Location = new Point(tb.Location.X - TbWidth( tb), tb.Location.Y);
				tb.TextAlign = HorizontalAlignment.Right;
			}

			if (tb.Location.X == col17 & tb.Text != ">")
			{
				tb.Location = new Point(tb.Location.X - TbWidth( tb), tb.Location.Y);
				//tb.TextAlign = HorizontalAlignment.Right;
			}

			if (tb.Location.X == col7 & tb.Location.Y == row0)
			{
				CenterMe(tb);//tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth( tb) / 2), tb.Location.Y);
			}
			
		}

		private void TB( TextBox myName, int col, int row, string tbText, Color? charColor = null, Color? backgroundColor = null, string fontType = "Arial", int fontSize = 20, FontStyle fstyle = FontStyle.Regular, BorderStyle bstyle = BorderStyle.None)
		{
			myName.Location = new Point(col, row);

			
			
			myName.Text = tbText;
		   
			myName.Font = new Font(fontType, fontSize, fstyle);
			myName.Width = TbWidth( myName);
			JustifyTBs( myName);

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


		//used to dispose of all the existing  TextBoxes before creating new ones
		private void StartFresh()
		{
			try
			{
				for (int i = 0; i < tbCount; i++)//iterates through all  TextBoxes on the form
				{
					foreach (Control c in this.Controls)
					{

						if (c.GetType() == typeof(TextBox))
						{
							if (c.Name != "sPad")
							{
								c.Dispose();
							}
							
						}

					}
				}
				tbCount = 0;//resets tbCount to zero for the next page
				CDU7000Page = false;//resets the bool to false, indicating a CDU3000 page

				//the following three lines will erase the scratchpad entries whenever a page changes. 
				//I do not believe this is the correct operation of the unit:

				//scratchpad = null;
				//sPad.Text = scratchpad;
				//sPad.Visible = false;
			}
			catch (Exception)
			{
				
				//throw;
			}

			l1text = "";
			l2text = "";
			l3text = "";
			l4text = "";
			l5text = "";
			l6text = "";

			r1text = "";
			r2text = "";
			r3text = "";
			r4text = "";
			r5text = "";
			r6text = "";
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


					//check current input string
					switch (trimmedString)
					{
						//MCDU page 1
						case "MCDU MENU":
							StartFresh();//clears all  TextBoxes before writing new page
							MCDU();
							break;

						//FmsControlPage
						case "FMS CTL":
							StartFresh();//clears all  TextBoxes before writing new page
							FmsControlPage();
							break;

						//FrequencyDataPage1
						case "FREQUENCY":
							StartFresh();//clears all  TextBoxes before writing new page
							FrequencyDataPage1();
							break;

						//FixPage1
						case "FIX":
							StartFresh();

							FixPage1();
							break;

                        //GNSS1 Pos Page
                        case"GNSS1 POS":
                            StartFresh();
                            GNSS1statusPage1();
                            break;

						//GNSS Control Page
						case "GNSS CTL":
							StartFresh();//clears all  TextBoxes before writing new page
							GNSScontrolPage();
							break;

                        //HOLD page1
                        case "HOLD":
                            StartFresh();
                            HoldPage1();
                            break;

						//INDEX page 1
						case "INDEX":
							StartFresh();//clears all  TextBoxes before writing new page
							IdxPage1();
							break;

						//IRS CTL page 1
						case "IRS CTL":
							StartFresh();//clears all  TextBoxes before writing new page
							IRSctlPage();
							break;

						//MISSION page
						case "MISSION":
							StartFresh();//clears all  TextBoxes before writing new page
							MissionPage();
							break;

						//NPA RAIM page
						case "NPA RAIM":
							StartFresh();//clears all  TextBoxes before writing new page
							NonPrecisionApprRaimPage();
							break;

						//POS INIT page
						case "POS INIT":
							StartFresh();//clears all  TextBoxes before writing new page
							PosInitPage1();
							break;

                        //PROG page1
                        case "PROG":
                            StartFresh();//clears all  TextBoxes before writing new page
                            ProgressPage1();
                            break;

                        //SEC page
                        case "SEC FPLN":
                            StartFresh();//clears all  TextBoxes before writing new page
                            SECFPLNpage1();
                            break;

						//SBASpage
						case "SELECT SBAS":
							StartFresh();//clears all  TextBoxes before writing new page
							SBASpage();
							break;

						//MCDU page 1
						case "STATUS":
							StartFresh();//clears all  TextBoxes before writing new page

							#region Multiple STATUS cases available
							if (currentPageTitle == "GNSS CTL")
							{
								if (btnPressed == "r1")
								{
									GNSS1statusPage1();
								}else
									if (btnPressed == "r2")
									{
										GNSS2statusPage1();
									}
								
							}
							else
							{
								StatusPage();
							} 
							#endregion
							
							break;

						//FPLN page 1
						case "FPLN":
							StartFresh();//clears all  TextBoxes before writing new page
							FPLNpage1();
							break;

						//VORDME CTL page
						case "VORDME CTL":
							StartFresh();//clears all  TextBoxes before writing new page
							VorDmeCtlPage();
							break;

						//default to scratchpad
						default:
							try
							{
								if (scratchpad!=null)//if the scratchpad is not null
								{
									TransferScratch();//transfer the scratchpad data to the textbox adjacent to the button pushed
								}
								else
								{
									Scratch(trimmedString,e);//add text tothe scratchpad
								}
							}
							catch (Exception)
							{
								
							   
							}
							break;


					}
					break;

				case true://CDU7000 pages are here

					
					//insert cdu7000 switch statements here
					switch (trimmedString)
					{
						//COMM page
						case "COM":
							StartFresh();//clears all  TextBoxes before writing new page
							COMpage();
							break;


						//default to scratchpad
						default:
							try
							{
								if (scratchpad != null)
								{
									TransferScratch();
								}
								else
								{
									Scratch(trimmedString, e);
								}
							}
							catch (Exception)
							{


							}
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




		private void Scratch(string e, string fullText = "")  //Updates scratchpad info when buttons are pressed 
		{
			bool isPresent = false;

			if (btnPressed == "l1" || btnPressed == "l2" || btnPressed == "l3" || btnPressed == "l4" || btnPressed == "l5" || btnPressed == "l6" ) //determine pushed button
			{
				if (fullText.Contains("<")||(fullText.Contains("-"))) //check if < or > exist next to that button
				{
					//exit scratch if true
				}
				
				else
				{
					scratchpad += e;    //adds the last button press to the scratchpad string
					sPad.Visible = true;
					sPad.Text = scratchpad;
				}

			}
			else
				if (btnPressed == "r1" || btnPressed == "r2" || btnPressed == "r3" || btnPressed == "r4" || btnPressed == "r5" || btnPressed == "r6")
				{
					isPresent = FindPushedButon(btnPressed);

					if (!isPresent & (fullText.Contains("-")==false))
					{
						scratchpad += e;    //adds the last button press to the scratchpad string
						sPad.Visible = true;
						sPad.Text = scratchpad;
						btnPressed = "";
					}
				}
				else
				{
					btnPressed = e;
					scratchpad += e;    //adds the last button press to the scratchpad string
					sPad.Visible = true;
					sPad.Text = scratchpad;
				}
			
			


			

		}



		private void TransferScratch()//transfers the scratchpad information into a line
		{
			int myRow=0 ;//declare which row to put data in
			string mySide = "";//stores the button side

				switch (btnPressed)//gets the name of the last pressed button
				{
					case "l1"://determines the case
						mySide = "left";
						myRow = row2;//represents the row that the button is on
						l1text = scratchpad;//assigns scratchpad information to the button variable
						break;

					case "l2":
						mySide = "left";
						myRow = row4;
						l2text = scratchpad;
						break;

					case "l3":
						mySide = "left";
						myRow=row6;
						l3text = scratchpad;
						break;

					case "l4":
						mySide = "left";
						myRow=row8;
						l4text = scratchpad;
						break;

					case "l5":
						mySide = "left";
						myRow=row10;
						l5text = scratchpad;
						break;

					case "l6":
						mySide = "left";
						myRow=row12;
						l6text = scratchpad;
						break;


					case "r1":
						mySide = "right";
						myRow=row2;
						r1text = scratchpad;
						break;

					case "r2":
						mySide = "right";
						myRow=row4;
						r2text = scratchpad;
						break;

					case "r3":
						mySide = "right";
						myRow=row6;
						r3text = scratchpad;
						break;

					case "r4":
						mySide = "right";
						myRow=row8;
						r4text = scratchpad;
						break;

					case "r5":
						mySide = "right";
						myRow=row10;
						r5text = scratchpad;
						break;

					case "r6":
						mySide = "right";
						myRow=row12;
						r6text = scratchpad;
						break;
				}

				try
				{
					for (int i = 0; i < tbCount; i++)//iterates through all  TextBoxes on the form
					{
						foreach (Control c in this.Controls)
						{

							if (c.GetType() == typeof(TextBox))
							{
								if (c.Location.Y == myRow & c.Location.X < col3 & mySide=="left")
								{
									c.Text = scratchpad;
                                    Size size = TextRenderer.MeasureText(c.Text, c.Font);
                                    c.Size = size;
									
								}else
									if (c.Location.Y == myRow & ((c.Location.X +c.Width)>col14) & mySide == "right")
									{
										c.Text = scratchpad;
                                        Size size = TextRenderer.MeasureText(c.Text, c.Font);
                                        c.Size = size;
									}

							}

						}
					}

				}
				catch (Exception)
				{

				}
			
			
			scratchpad = null;
			sPad.Text = scratchpad;
		}

		private bool FindPushedButon(string e)  //locates the pushed button textbox 
		{
			bool value = false;
			int myRow = 0;

			switch (e)
			{
				case "r1":
					myRow = row2;
					break;

				case "r2":
					myRow = row4;
					break;

				case "r3":
					myRow = row6;
					break;

				case "r4":
					myRow = row8;
					break;

				case "r5":
					myRow = row10;
					break;

				case "r6":
					myRow = row12;
					break;
					  
			}

			try
			{
				for (int i = 0; i < tbCount; i++)//iterates through all  TextBoxes on the form
				{
					foreach (Control c in this.Controls)
					{

						if (c.GetType() == typeof(TextBox))
						{
							if (c.Location.Y == myRow & c.Location.X == col16)
							{
								if (c.Text.Contains(">"))
								{
									value = true;
								}
							}

						}

					}
				}
				
			}
			catch (Exception)
			{

				//throw;
			}

			return value;
			
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

		//used to update the textboxes on the face of the unit afterscratchpad paste
		private void UpdateDisplay()
		{
		   
		}

		#endregion

		

		
		

		

		

		

		

		
		
		#endregion

	   








	}


}
