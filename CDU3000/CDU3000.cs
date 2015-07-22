﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace CDU3000
{

    public partial class CDU3000 : Form
    {

        //NOTES

        //To create a new page, add a page method to the page region. Segregate the CDU3000 and CDU7000 methods. Make sure to add a erence to the PopulateNames method
        //Next, add the names of the buttons to the switch statement in the PopulateNames method
        //Finally, add to the switch statement in the PageSelection method to jump to the correct page. Make sure to segregate the CDU3000 and CDU7000 switch statements

        //ADD SEARCH FUNCTION


        #region Fields

        #region MyRegion
        //Button text
        string l0text = null;
        string l1text = null;
        string l1centerText = null;
        string l2text = null;
        string l2centerText = null;
        string l3text = null;
        string l3centerText = null;
        string l4text = null;
        string l4centerText = null;
        string l5text = null;
        string l5centerText = null;
        string l6text = null;
        string l6centerText = null;

        string r1text = null;
        string r2text = null;
        string r3text = null;
        string r4text = null;
        string r5text = null;
        string r6text = null;

        string l1tText = null;
        string l2tText = null;
        string l3tText = null;
        string l4tText = null;
        string l5tText = null;
        string l6tText = null;
        string r1tText = null;
        string r2tText = null;
        string r3tText = null;
        string r4tText = null;
        string r5tText = null;
        string r6tText = null;

        Button pushedButton = null;

        //used to switch colors when pages are updated by the UTC timer on IFF STATUS page 1
        Color switchColor1 = Color.Green;
        Color switchColor2 = Color.White;


        //tracksthe last button pressed
        string btnPressed = null;


        //scratchpad variable
        string scratchpad = null;



        //variables used for moving the form
        Boolean drag;
        int mousex;
        int mousey;

        //variables used to define  TextBox locations on screen
        int row0 = 51, row1 = 81, row2 = 110, row3 = 140, row4 = 170, row5 = 200, row6 = 232, row7 = 262, row8 = 293, row9 = 323, row10 = 353, row11 = 383, row12 = 414, row13 = 444, row14 = 474, row15 = 504;
        int col1 = 137, col2 = 169, col3 = 201, col4 = 233, col5 = 265, col6 = 297, col7 = 329, col8 = 361, col9 = 393, col10 = 425, col11 = 457, col12 = 489, col13 = 521, col14 = 553, col15 = 600, col16 = 607, col17 = 639;



        private int tbCount;//test to see if counting the number of  TextBoxes will help in disposing the TextBoxes
        private string currentPageTitle;//stores the current page title
        private int currentPageNumber;//stores the current page number

        private bool initialLoad = true;//used to track if this is the initial load of the program (status page tried to load every time the mouse was clicked off the application and then clicked back on the form)
        private bool CDU7000Page = false;//used to diferentiate between CDU3000 and CDU7000 pages

        private char c = '\uE000';//character used for empty placeholders
        private string emptyDigit = ('\uE000').ToString();
        private string emptyLatLong = ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\u00B0').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + "." + ('\uE000').ToString() + ('\uE000').ToString() + "  " + ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + ('\u00B0').ToString() + ('\uE000').ToString() + ('\uE000').ToString() + "." + ('\uE000').ToString() + ('\uE000').ToString();

        private double alpha = .20;//dimmer form alpha
        DimmerForm DM = new DimmerForm();

        //creates a new controller form
        Controller myCont = new Controller();
        #endregion

        //NAV fields
        private string _navStatus;

        //POWER page fields
        #region MyRegion
        private string CDUIFFpower = "OFF";
        private string CDUVU1power = "OFF";
        private string CDUVU2power = "OFF";
        #endregion

        //START INIT fields
        private string actInactToggle = ">";

        //TACAN specific fields
        #region MyRegion
        private string _tacanPowerState;
        private string _tcnStatus;
        #endregion

        //EGI specific fields
        #region MyRegion
        private string _egiStatus;
        private string _egiPowerState = "ON";
        private DateTime egiDateTime = DateTime.UtcNow;
        private DateTime egiDate = DateTime.Now;
        private string formattedTime = "12 : 00 : 00";  //leave initialized
        private string formattedDate = "01 JAN 15"; //leave initialized 
        #endregion

        //EGI INU specific fields
        #region MyRegion
        private string _egiInuStatus;
        private string _EgiAlignmentStatus = "> COMMAND";
        private string _InitiateAlign = "> INITIATE";
        private string _AlignCEP = "1.2";
        private string _AlignMode = "GC ALIGN";
        private string _AlignTime = "00:03.6";
        #endregion

        //EGI GPS specific fields
        #region MyRegion
        private string _egiGpsPowerState;
        private string _egiGpsStatus;
        #endregion

        //EGI MAINTENANCE specific
        #region MyRegion
        private string initialX;
        private string initialY;
        private string initialZ;
        private string updatedX;
        private string updatedY;
        private string updatedZ;
        #endregion

        //GNSS1 specific fields
        private string gnss1Status = "NGO";

        //IFF specific fields
        #region MyRegion
        private string _IFFPowerState;
        private string _IFFstatus = "GO";
        private string mode1code = "1234";
        private string mode2code = "1234";
        private string mode3code = "1234";
        private string m5pin = "01234";
        private string ntlOrg = "0101";
        #endregion

        //SURVEILLANCE specific fields
        private string _survStatus = "GO";

        //TCAS specific fields
        private string _TCASstatus = "GO";

        //COM specific fields
        private string _comStatus = "GO";
        private string vu1Warning = "!";
        private string vu2Warning = "!";
        private string hf1Warning = "!";

        private string currentVU1chan = "01";
        private string currentVU1name = "AIRSPT";
        private string currentVU1freq = "260.675";
        private string currentVU1ComsecVar = "C1";

        private string currentVU2chan = "01";
        private string currentVU2name = "AIRSPT";
        private string currentVU2freq = "260.675";
        private string currentVU2ComsecVar = "C1";

        private string VU1activeBand = "U";
        private string VU2activeBand = "U";

        enum activeBand
        {
            UHF,
            FM,
            SATCOM,
            AM,
            HOPSETS
        };

        activeBand VU1band;
        activeBand VU2band;



        //VU1 specific fields
        #region VU1 fields
        private string _VU1status = "GO";
        private string _vu1PowerState;
        string _VU1freq = "V136.000";
        string _VU1preset = "P2";
        string _VU1channel = "0";
        string _VU1mode = "TR";
        string _VU1squelch = "1";
        string _VU1power = "HIGH";
        string _VU1guard = "OFF";

        private string SatcomPre1Name = "AIRSPT";
        private string SatcomPre1Chan = "< 01";
        private string SatcomPre1Uplink = "317.145";
        private string SatcomPre1Downlink = "245.045";
        private string SatcomPre1SATchan = "215";
        private string SatcomPre1NetVar = "P2";

        private string SatcomPre2Name = "TOWER";
        private string SatcomPre2Chan = "< 02";
        private string SatcomPre2Uplink = "244.000";
        private string SatcomPre2Downlink = "245.045";
        private string SatcomPre2SATchan = "215";
        private string SatcomPre2NetVar = "C12";

        private string VU1SatcomPre1Name = "AIRSPT";
        private string VU1SatcomPre1Chan = "< 01";
        private string VU1SatcomPre1Comsec = "P2";
        private string VU1SatcomPre1Uplink = "317.145";
        private string VU1SatcomPre1Downlink = "245.045";
        private string VU1SatcomPre1SATchan = "215";


        private string VU1SatcomPre2Name = "TOWER";
        private string VU1SatcomPre2Chan = "< 02";
        private string VU1SatcomPre2Uplink = "244.000";
        private string VU1SatcomPre2Downlink = "245.045";
        private string VU1SatcomPre2SATchan = "215";
        private string VU1SatcomPre2Comsec = "C12";
        private string recallVU1Satcomfreq;
        private string recallVU1Satcomname;
        private string recallVU1Satcomchan;

        private string VU1AMpre1Chan = "< 01";
        private string VU1AMpre2Chan = "< 02";
        private string VU1AMpre3Chan = "< 03";
        private string VU1AMpre4Chan = "< 04";
        private string VU1AMpre5Chan = "< 05";
        private string VU1AMpre1Name = "AIRSPT";
        private string VU1AMpre2Name = "REDNET";
        private string VU1AMpre3Name = "TOWER";
        private string VU1AMpre4Name = "PACMAN";
        private string VU1AMpre5Name = "GRNLDR";
        private string VU1AMpre1Freq = "110.675";
        private string VU1AMpre2Freq = "141.950";
        private string VU1AMpre3Freq = "128.100";
        private string VU1AMpre4Freq = "109.025";
        private string VU1AMpre5Freq = "140.475";
        private string VU1AMpre1Comsec = "C1";
        private string VU1AMpre2Comsec = "C2";
        private string VU1AMpre3Comsec = "P4";
        private string VU1AMpre4Comsec = "C3";
        private string VU1AMpre5Comsec = "P1";


        private string VU1HOPpre1Chan = "< CS";
        private string VU1HOPpre2Chan = "< CU";
        private string VU1HOPpre3Chan = "< 01";
        private string VU1HOPpre4Chan = "< 02";
        private string VU1HOPpre5Chan = "< 03";
        private string VU1HOPpre1Name = "COLD";
        private string VU1HOPpre2Name = "CUE";
        private string VU1HOPpre3Name = "STLWTR";
        private string VU1HOPpre4Name = "TOWER1";
        private string VU1HOPpre5Name = "BRIDGE";
        private string VU1HOPpre1Freq = "50.075";
        private string VU1HOPpre2Freq = "42.225";
        private string VU1HOPpre3Freq = "F412";
        private string VU1HOPpre4Freq = "F113";
        private string VU1HOPpre5Freq = "F611";
        private string VU1HOPpre1Comsec = "P6";
        private string VU1HOPpre2Comsec = "P6";
        private string VU1HOPpre3Comsec = "C1";
        private string VU1HOPpre4Comsec = "P6";
        private string VU1HOPpre5Comsec = "C3";
        private string recallVU1HOPchan;
        private string recallVU1HOPfreq;
        private string recallVU1HOPname;
        private string recallVU1AMchan;
        private string recallVU1AMfreq;
        private string recallVU1AMname;



        #endregion

        //VU2 specific fields
        #region VU2 fields
        private string _VU2status = "GO";
        private string _vu2PowerState;
        string VU2freq = "V136.000";
        string VU2preset = "P2";
        string VU2channel = "0";
        string VU2mode = "TR";
        string VU2squelch = "1";
        string VU2power = "HIGH";
        string VU2guard = "OFF";
        string _VU21553 = "GO";
        string _VU2transmitter = "GO";
        string _VU2modem = "GO";
        string _VU2pwrSupply = "GO";
        string _VU2rt = "GO";
        string _VU2comsec = "GO";

        private string VU2AMpre1Chan;
        private string VU2AMpre2Chan;
        private string VU2AMpre3Chan;
        private string VU2AMpre4Chan;
        private string VU2AMpre5Chan;

        private string VU2HOPpre1Chan;
        private string VU2HOPpre2Chan;
        private string VU2HOPpre3Chan;
        private string VU2HOPpre4Chan;
        private string VU2HOPpre5Chan;

        private string VU2FMpre1Name = "AIRSPT";
        private string VU2FMpre1Freq = "60.675";
        private string VU2FMpre1Chan = "< 01";
        private string VU2FMpre1Comsec = "C1";
        private string VU2FMpre2Chan = "< 02";
        private string VU2FMpre2Name = "REDNET";
        private string VU2FMpre2Freq = "41.950";
        private string VU2FMpre2Comsec = "C2";
        private string VU2FMpre3Name = "TOWER";
        private string VU2FMpre3Freq = "130.100";
        private string VU2FMpre3Comsec = "P4";
        private string VU2FMpre3Chan = "< 03";
        private string VU2FMpre4Chan = "< 04";
        private string VU2FMpre4Name = "PACMAN";
        private string VU2FMpre4Freq = "42.025";
        private string VU2FMpre4Comsec = "C3";
        private string VU2FMpre5Chan = "< 05";
        private string VU2FMpre5Name = "GRNLDR";
        private string VU2FMpre5Freq = "40.475";
        private string VU2FMpre5Comsec = "P1";


        #endregion

        //Combined level status specific fields
        private string overallComStatus;
        private string com1Status;

        //Messaging specific fields
        #region Messaging
        private string scratchMessage;//used for overriding the scratchpad during CDU message transmission
        private string scratchBackup;//temporary storage of the scratchpad data

        #endregion

        //HF specific fields
        #region MyRegion
        private string _HF1status = "GO";
        private string hfMode = "STBY";//stores the mode of operation, used to determine what to display on the form
        private string hfSubMode = "MAN";//stores the submode of operation, used to determine what to display on the form
        Color l1color = Color.Green;
        Color l1ccolor = Color.White;
        Color l1ecolor = Color.White;
        Color l1gcolor = Color.White;
        private string l3Var = "NONE";
        private string r2Var = "STBY FUNC";
        private string r3Var = "- - ";
        private string basSelChanVar = "";
        private string r3TitleVar;
        private Color l3color = Color.White;
        private Color l3ccolor = Color.Green;
        private Color l3ecolor = Color.Green;
        private string hfAircraftID = "- - - - - - - ";
        private string hfTime = "0000 : 00";
        private string hfDate = "01 / 01 / 96";
        private string gpsSync = "";
        private string manualTime = "0000 : 00";
        private string manualDate = "01 / 01 / 96";

        //Preset Channels
        private string HFpre1Chan = "< 01";
        private string HFpre2Chan = "< 02";
        private string HFpre3Chan = "< 03";
        private string HFpre4Chan = "< 04";
        private string HFpre5Chan = "< 05";

        private string HFpre1Name = "ONENAM";
        private string HFpre2Name = "BBCBBC";
        private string HFpre3Name = "STILHO";
        private string HFpre4Name = "ALPHA1";
        private string HFpre5Name = "BRAVO2";

        private string HFpre1Freq = "12.0000";
        private string HFpre2Freq = "26.9624";
        private string HFpre3Freq = "18.1212";
        private string HFpre4Freq = "24.0202";
        private string HFpre5Freq = "22.7324";

        private string ALEpre1Name = "FIRST";
        private string ALEpre2Name = "CLDXYZ";
        private string ALEpre3Name = "HTWOOH";
        private string ALEpre4Name = "SECOND";
        private string ALEpre5Name = "ABCDEF";

        private string ALEpre1Chan = "< 01";
        private string ALEpre2Chan = "< 02";
        private string ALEpre3Chan = "< 03";
        private string ALEpre4Chan = "< 04";
        private string ALEpre5Chan = "< 05";

        private string ALEpre1Freq = "12.0000";
        private string ALEpre2Freq = "26.0202";
        private string ALEpre3Freq = "2.0011";
        private string ALEpre4Freq = "14.0000";
        private string ALEpre5Freq = "26.0022";
        private string aleChanVar = "";

        private string currentHFchan = "01";
        private string currentHFchanName = "ONENAM";
        private string currentHFfreq = "12.0000";
        private string hfRecallFreq = "12.0000";
        private string hfRecallName = "ONENAM";
        private string hfRecallChan = "01";

        private string currentALEchan = "01";
        private string currentALEname = "FIRST";
        private string currentALEfreq = "12.0000";
        private string ALERecallFreq = "12.0000";
        private string ALERecallName = "FIRST";
        private string ALERecallChan = "01";



        //VU1 UHF
        private string currentVU1UHFchan = "01";
        private string currentVU1UHFname = "AIRSPT";
        private string currentVU1UHFfreq = "260.675";
        private string recallVU1UHFchan = "01";
        private string recallVU1UHFname = "AIRSPT";
        private string recallVU1UHFfreq = "260.675";


        private string VU1UHFpre1Name = "AIRSPT";
        private string VU1UHFpre2Name = "REDNET";
        private string VU1UHFpre3Name = "TOWER";
        private string VU1UHFpre4Name = "PACMAN";
        private string VU1UHFpre5Name = "GRNLDR";

        private string VU1UHFpre1Chan = "< 01";
        private string VU1UHFpre2Chan = "< 02";
        private string VU1UHFpre3Chan = "< 03";
        private string VU1UHFpre4Chan = "< 04";
        private string VU1UHFpre5Chan = "< 05";

        private string VU1UHFpre1Freq = "260.675";
        private string VU1UHFpre2Freq = "241.950";
        private string VU1UHFpre3Freq = "258.100";
        private string VU1UHFpre4Freq = "342.025";
        private string VU1UHFpre5Freq = "330.475";

        private string VU1UHFpre1Comsec = "C1";
        private string VU1UHFpre2Comsec = "C2";
        private string VU1UHFpre3Comsec = "P4";
        private string VU1UHFpre4Comsec = "C3";
        private string VU1UHFpre5Comsec = "P1";
        private string recallVU1Comsec = "C1";

        private string recallVU2UHFchan = "01";
        private string recallVU2UHFname = "AIRSPT";
        private string recallVU2UHFfreq = "260.675";
        private string recallVU2Comsec = "C1";

        private string VU2UHFpre1Name = "AIRSPT";
        private string VU2UHFpre2Name = "REDNET";
        private string VU2UHFpre3Name = "TOWER";
        private string VU2UHFpre4Name = "PACMAN";
        private string VU2UHFpre5Name = "GRNLDR";

        private string VU2UHFpre1Chan = "< 01";
        private string VU2UHFpre2Chan = "< 02";
        private string VU2UHFpre3Chan = "< 03";
        private string VU2UHFpre4Chan = "< 04";
        private string VU2UHFpre5Chan = "< 05";

        private string VU2UHFpre1Freq = "260.675";
        private string VU2UHFpre2Freq = "241.950";
        private string VU2UHFpre3Freq = "258.100";
        private string VU2UHFpre4Freq = "342.025";
        private string VU2UHFpre5Freq = "330.475";

        private string VU2UHFpre1Comsec = "C1";
        private string VU2UHFpre2Comsec = "C2";
        private string VU2UHFpre3Comsec = "P4";
        private string VU2UHFpre4Comsec = "C3";
        private string VU2UHFpre5Comsec = "P1";
        private string VU1FMpre1Name = "AIRSPT";
        private string VU1FMpre1Freq = "60.675";
        private string VU1FMpre1Chan = "< 01";
        private string VU1FMpre1Comsec = "C1";
        private string VU1FMpre2Chan = "< 02";
        private string VU1FMpre2Name = "REDNET";
        private string VU1FMpre2Freq = "41.950";
        private string VU1FMpre2Comsec = "C2";
        private string VU1FMpre3Name = "TOWER";
        private string VU1FMpre3Freq = "130.100";
        private string VU1FMpre3Comsec = "P4";
        private string VU1FMpre3Chan = "< 03";
        private string VU1FMpre4Chan = "< 04";
        private string VU1FMpre4Name = "PACMAN";
        private string VU1FMpre4Freq = "42.025";
        private string VU1FMpre4Comsec = "C3";
        private string VU1FMpre5Chan = "< 05";
        private string VU1FMpre5Name = "GRNLDR";
        private string VU1FMpre5Freq = "40.475";
        private string VU1FMpre5Comsec = "P1";
        private string recallVU1FMchan;
        private string recallVU1FMname;
        private string recallVU1FMfreq;
        private string vu1Band;




        #endregion

        #endregion


        #region Pages

        private void Baseline()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "";
            l4tText = "";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

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

            currentPageTitle = "?????????????"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region CDU7000 pages

        //Communication Pages

        #region Comm Page

        private void COMpage()
        {
            CDU7000Page = true;

            CheckStatus();

            currentPageTitle = "comm";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col7, row0, "COMM");

            TextBox l0 = new TextBox();
            l0text = vu1Warning;
            TB(l0, col1, row1, l0text, Color.Orange);

            TextBox l0right = new TextBox();
            TB(l0right, col2, row1, "V/U1");


            TextBox l1 = new TextBox();
            l1text = "<";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1right = new TextBox();
            TB(l1right, col2, row2, currentVU1chan + "   " + currentVU1name, Color.White);//"20  TOWERS"

            TextBox comsecVar = new TextBox();
            TB(comsecVar, col8, row2, currentVU1ComsecVar, Color.White);

            TextBox vu2Warn = new TextBox();
            TB(vu2Warn, col1, row3, vu2Warning, Color.Orange);

            TextBox lb = new TextBox();
            TB(lb, col2, row3, "V/U2");


            TextBox l2 = new TextBox();
            TB(l2, col1, row4, "<", Color.White);

            TextBox l2r = new TextBox();
            TB(l2r, col2, row4, currentVU2chan + "   " + currentVU2name, Color.White);

            TextBox comsecVar2 = new TextBox();
            TB(comsecVar2, col8, row4, currentVU2ComsecVar, Color.White);

            TextBox l2b = new TextBox();
            TB(l2b, col1, row5, hf1Warning, Color.Orange);

            TextBox l2bright = new TextBox();
            TB(l2bright, col2, row5, "HF1 -" + hfMode + "-");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, "<", Color.White);

            TextBox l3r = new TextBox();


            if (hfMode == "ALE")
            {
                TB(l3r, col2, row6, currentALEchan + "    " + currentALEname, Color.White);
                r3text = currentALEfreq;
            }
            else
            {
                TB(l3r, col2, row6, currentHFchan + "    " + currentHFchanName, Color.White);
                r3text = currentHFfreq;
            }


            l3r.TextAlign = HorizontalAlignment.Left;



            string band = BandSelection(currentVU1freq, "VU1");

            TextBox r1 = new TextBox();
            r1text = band + currentVU1freq;
            TB(r1, col17, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            r2text = BandSelection(currentVU2freq, "VU2") + currentVU2freq;
            TB(r2, col17, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col17, row6, r3text, Color.White);

            TextBox r6 = new TextBox();
            r6text = "RETURN";
            TB(r6, col15, row12, r6text, Color.White);



            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #endregion

        #region HFControl Pages

        private void HFcontrolPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            if (hfMode == "SEL" & hfSubMode == "SCAN")
            {
                hfSubMode = "MAN";
            }



            switch (hfMode)
            {
                case "STBY":
                    l1color = Color.Green;
                    l1ccolor = Color.White;
                    l1ecolor = Color.White;
                    l1gcolor = Color.White;
                    l3color = Color.White;
                    r3TitleVar = "";
                    r3Var = "";
                    r2Var = "STBY FUNC";
                    l3Var = "NONE";
                    break;

                case "BAS":
                    l1color = Color.White;
                    l1ccolor = Color.Green;
                    l1ecolor = Color.White;
                    l1gcolor = Color.White;
                    r3TitleVar = "CHANNELS";
                    r3Var = "";
                    r2Var = "";
                    l3Var = "MAN";
                    break;

                case "ALE":
                    l1color = Color.White;
                    l1ccolor = Color.White;
                    l1ecolor = Color.Green;
                    l1gcolor = Color.White;
                    l3color = Color.White;
                    r3TitleVar = "SCANLIST";
                    r3Var = "";
                    r2Var = "ALE FCTN";
                    l3Var = "MAN";
                    break;

                case "SEL":

                    l1color = Color.White;
                    l1ccolor = Color.White;
                    l1ecolor = Color.White;
                    l1gcolor = Color.Green;
                    r3TitleVar = "CHANNELS";
                    r3Var = "";
                    r2Var = "";
                    l3Var = "MAN";
                    break;
            }

            if (hfMode == "BAS" || hfMode == "SEL")
            {
                switch (hfSubMode)
                {
                    case "MAN":
                        l3color = Color.Green;
                        l3ccolor = Color.White;
                        r3TitleVar = "";
                        r3Var = "";
                        break;

                    case "PRST":
                        l3ccolor = Color.Green;
                        l3color = Color.White;
                        r3TitleVar = "CHANNELS";
                        r3Var = basSelChanVar;
                        break;
                }
            }

            if (hfMode == "ALE")
            {
                switch (hfSubMode)
                {
                    case "MAN":
                        r3TitleVar = "";
                        break;

                    case "PRST":
                        r3TitleVar = "CHANNELS";
                        break;

                    case "SCAN":
                        r3TitleVar = "SCANLIST";
                        break;
                }
            }


            #region MyRegion
            l1tText = "MODE";
            l2tText = "";
            l3tText = "SUB - MODE";
            l4tText = "";
            l5tText = "";
            l6tText = "SILENT";
            r1tText = "";
            r2tText = "";
            r3tText = r3TitleVar;
            r4tText = "A / C ID";
            r5tText = "";
            r6tText = "";

            l1text = "STBY";
            l2text = "";
            l3text = l3Var;
            l4text = "";
            l5text = "";
            l6text = "ON";
            r1text = "";
            r2text = r2Var;
            r3text = r3Var;
            r4text = hfAircraftID;
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, l1color);

            TextBox l1b = new TextBox();
            TB(l1b, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1c = new TextBox();
            TB(l1c, l1b.Location.X + l1b.Width, row2, "BAS", l1ccolor);

            TextBox l1d = new TextBox();
            TB(l1d, l1c.Location.X + l1c.Width, row2, "/", Color.White);

            TextBox l1e = new TextBox();
            TB(l1e, l1d.Location.X + l1d.Width, row2, "ALE", l1ecolor);

            TextBox l1f = new TextBox();
            TB(l1f, l1e.Location.X + l1e.Width, row2, "/", Color.White);

            TextBox l1g = new TextBox();
            TB(l1g, l1f.Location.X + l1f.Width, row2, "SEL", l1gcolor);


            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, l3color);

            if (hfMode == "BAS" || hfMode == "ALE" || hfMode == "SEL")
            {
                TextBox l3b = new TextBox();
                TB(l3b, l3.Location.X + l3.Width, row6, "/", Color.White);

                TextBox l3c = new TextBox();
                TB(l3c, l3b.Location.X + l3b.Width, row6, "PRST", l3ccolor);

                if (hfMode == "ALE")
                {

                    if (hfSubMode == "MAN")
                    {
                        l3color = Color.Green;
                        l3ccolor = Color.White;
                        l3ecolor = Color.White;
                        r3text = "";
                    }
                    else
                        if (hfSubMode == "PRST")
                        {
                            l3color = Color.White;
                            l3ccolor = Color.Green;
                            l3ecolor = Color.White;
                        }
                        else
                            if (hfSubMode == "SCAN")
                            {
                                l3color = Color.White;
                                l3ccolor = Color.White;
                                l3ecolor = Color.Green;
                            }
                    l3.ForeColor = l3color;
                    l3c.ForeColor = l3ccolor;
                    TextBox l3d = new TextBox();
                    TB(l3d, l3c.Location.X + l3c.Width, row6, "/", Color.White);

                    TextBox l3e = new TextBox();
                    TB(l3e, l3d.Location.X + l3d.Width, row6, "SCAN", l3ecolor);
                }

            }



            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, l6.Location.X + l6.Width, row12, "/", Color.White);

            TextBox l6c = new TextBox();
            TB(l6c, l6b.Location.X + l6b.Width, row12, "OFF", Color.Green);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, r3tText);
            TypeLeft(r3t);

            //add preset number if selected
            if (hfMode == "BAS" & hfSubMode == "PRST" & basSelChanVar == "")
            {
                if (r3Var == "")
                {
                    r3Var = currentHFchan;
                    r3text = r3Var;
                }
            }
            else
                if (hfMode == "ALE" & hfSubMode == "PRST" & aleChanVar == "")
                {
                    if (r3Var == "")
                    {
                        r3Var = currentALEchan;
                        r3text = r3Var;
                    }
                }
                else
                    if (hfMode == "SEL" & hfSubMode == "PRST" & basSelChanVar == "")
                    {
                        if (r3Var == "")
                        {
                            r3Var = currentHFchan;
                            r3text = r3Var;
                        }
                    }
                    else
                        if (hfMode == "BAS" & hfSubMode == "PRST" & basSelChanVar != "")
                        {
                            r3Var = currentHFchan;
                            r3text = r3Var;
                        }
                        else
                            if (hfMode == "ALE" & hfSubMode == "PRST" & aleChanVar != "")
                            {
                                r3Var = currentALEchan;
                                r3text = r3Var;
                            }
                            else
                                if (hfMode == "SEL" & hfSubMode == "PRST" & basSelChanVar != "")
                                {
                                    r3Var = currentHFchan;
                                    r3text = r3Var;
                                }


            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3Var, Color.White);

            //currentHFchan = r3Var;

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, r4tText);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l7b = new TextBox();
            TB(l7b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFstandbyFunctionPage()
        {
            CDU7000Page = true;

            CheckStatus();


            if (gnss1Status == "GO")
            {
                UTCupdateTimer.Start();
                if (pushedButton == l1Btn || gpsSync == "GPS")
                {
                    hfTime = DateTime.UtcNow.ToString("HHmm : ss");
                    hfDate = DateTime.UtcNow.ToString("dd / MM / yy");
                    gpsSync = "GPS";
                }
            }
            else
                if (pushedButton == l1Btn)
                {
                    UTCupdateTimer.Stop();
                    scratchMessage = "GPS NOT AVAILABLE";
                    CheckValidity();
                }

            #region MyRegion
            l1tText = "";
            l2tText = "TIME";
            l3tText = "DATE";
            l4tText = "";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "> GPS SYNC";
            l2text = "> " + hfTime;
            l3text = "> " + hfDate;
            l4text = "> DATA LOAD";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 STANDBY FCTN"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox gpsSynced = new TextBox();
            TB(gpsSynced, col7, row5, gpsSync);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFcontrolPage2()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "FREQ";
            l3tText = "POWER";
            l4tText = "SQUELCH";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "AUDIO";
            r3tText = "";
            r4tText = "";
            r5tText = "MODULATION";
            r6tText = "";

            l1text = "";
            l2text = "> 29.9999";
            l3text = "HIGH";
            l4text = "OFF";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "DATA";
            r3text = "";
            r4text = "";
            r5text = "CW";
            r6text = "RETURN";

            currentPageTitle = "HF1 CONTROL"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l3b = new TextBox();
            TB(l3b, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox l3bb = new TextBox();
            TB(l3bb, l3b.Location.X + l3b.Width, row6, "MED", Color.White);

            TextBox l3bc = new TextBox();
            TB(l3bc, l3bb.Location.X + l3bb.Width, row6, "/", Color.White);

            TextBox l3bd = new TextBox();
            TB(l3bd, l3bc.Location.X + l3bc.Width, row6, "LOW", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, r2tText);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.Green);

            TextBox r2b = new TextBox();
            TB(r2b, col9 + 10, row4, "VOICE", Color.White);

            TextBox r2c = new TextBox();
            TB(r2c, r2b.Location.X + r2b.Width, row4, "/", Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, r5tText);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r5a = new TextBox();
            TB(r5a, col2 + 20, row10, "USB", Color.Green);

            TextBox r5b = new TextBox();
            TB(r5b, r5a.Location.X + r5a.Width, row10, "/", Color.White);

            TextBox r5c = new TextBox();
            TB(r5c, r5b.Location.X + r5b.Width, row10, "LSB", Color.White);

            TextBox r5d = new TextBox();
            TB(r5d, r5c.Location.X + r5c.Width, row10, "/", Color.White);

            TextBox r5e = new TextBox();
            TB(r5e, r5d.Location.X + r5d.Width, row10, "ISB", Color.White);

            TextBox r5f = new TextBox();
            TB(r5f, r5e.Location.X + r5e.Width, row10, "/", Color.White);

            TextBox r5g = new TextBox();
            TB(r5g, r5f.Location.X + r5f.Width, row10, "AME", Color.White);

            TextBox r5h = new TextBox();
            TB(r5h, r5g.Location.X + r5g.Width, row10, "/", Color.White);



            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFcontrolPage3()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "LBT";
            l2tText = "MODEM";
            l3tText = "";
            l4tText = "RATE";
            l5tText = "RCV SNR";
            l6tText = "";
            r1tText = "SEL ADRS";
            r2tText = "MODEM MODE";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "ON";
            l2text = "> 1";
            l3text = "";
            l4text = "1200 RX";
            l5text = "-10";
            l6text = "";
            r1text = "AJKS";
            r2text = "PROGFSK";
            r3text = "";
            r4text = "TX 2400";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 CONTROL"; //page title and number used for navigating
            currentPageNumber = 3;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1b = new TextBox();
            TB(l1b, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1c = new TextBox();
            TB(l1c, l1b.Location.X + l1b.Width, row2, "OFF", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, l4tText);
            CenterMe(l4t);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, r2tText);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFpresetChannelsPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = HFpre1Name;
            l2tText = HFpre2Name;
            l3tText = HFpre3Name;
            l4tText = HFpre4Name;
            l5tText = HFpre5Name;
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            if (HFpre1Chan.Trim('<', ' ') == currentHFchan)
            {
                HFpre1Chan = HFpre1Chan.Replace('<', '*');
                HFpre2Chan = HFpre2Chan.Replace('*', '<');
                HFpre3Chan = HFpre3Chan.Replace('*', '<');
                HFpre4Chan = HFpre4Chan.Replace('*', '<');
                HFpre5Chan = HFpre5Chan.Replace('*', '<');
            }
            if (HFpre2Chan.Trim('<', ' ') == currentHFchan)
            {
                HFpre2Chan = HFpre2Chan.Replace('<', '*');
                HFpre1Chan = HFpre1Chan.Replace('*', '<');
                HFpre3Chan = HFpre3Chan.Replace('*', '<');
                HFpre4Chan = HFpre4Chan.Replace('*', '<');
                HFpre5Chan = HFpre5Chan.Replace('*', '<');
            }
            if (HFpre3Chan.Trim('<', ' ') == currentHFchan)
            {
                HFpre3Chan = HFpre3Chan.Replace('<', '*');
                HFpre2Chan = HFpre2Chan.Replace('*', '<');
                HFpre1Chan = HFpre1Chan.Replace('*', '<');
                HFpre4Chan = HFpre4Chan.Replace('*', '<');
                HFpre5Chan = HFpre5Chan.Replace('*', '<');
            }
            if (HFpre4Chan.Trim('<', ' ') == currentHFchan)
            {
                HFpre4Chan = HFpre4Chan.Replace('<', '*');
                HFpre3Chan = HFpre3Chan.Replace('*', '<');
                HFpre2Chan = HFpre2Chan.Replace('*', '<');
                HFpre1Chan = HFpre1Chan.Replace('*', '<');
                HFpre5Chan = HFpre5Chan.Replace('*', '<');
            }
            if (HFpre5Chan.Trim('<', ' ') == currentHFchan)
            {
                HFpre5Chan = HFpre5Chan.Replace('<', '*');
                HFpre4Chan = HFpre4Chan.Replace('*', '<');
                HFpre3Chan = HFpre3Chan.Replace('*', '<');
                HFpre2Chan = HFpre2Chan.Replace('*', '<');
                HFpre1Chan = HFpre1Chan.Replace('*', '<');

            }

            l1text = HFpre1Chan;
            l2text = HFpre2Chan;
            l3text = HFpre3Chan;
            l4text = HFpre4Chan;
            l5text = HFpre5Chan;
            l6text = "";
            r1text = HFpre1Freq;
            r2text = HFpre2Freq;
            r3text = HFpre3Freq;
            r4text = HFpre4Freq;
            r5text = HFpre5Freq;
            r6text = "RETURN";

            currentPageTitle = "HF1 PRESET CHANNELS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/7");

            TextBox l1t = new TextBox();
            TB(l1t, col5, row2, l1tText, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col5, row4, l2tText, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col5, row6, l3tText, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col5, row8, l4tText, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col5, row10, l5tText, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);





            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void ALEscanListsPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "SCANLS";
            l2tText = "SECLST";
            l3tText = "THRLST";
            l4tText = "FOULST";
            l5tText = "FIFLST";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "< 01";
            l2text = "< 02";
            l3text = "< 03";
            l4text = "< 04";
            l5text = "< 05";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 ALE SCAN LISTS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1t = new TextBox();
            TB(l1t, col5, row2, l1tText, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col5, row4, l2tText, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col5, row6, l3tText, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col5, row8, l4tText, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col5, row10, l5tText, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);





            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEfunctionPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "";
            l4tText = "";
            l5tText = "CALL ALERT";
            l6tText = "";
            r1tText = "ADDRESS";
            r2tText = "";
            r3tText = "LP";
            r4tText = "";
            r5tText = "XMT LP LVL";
            r6tText = "";

            l1text = "> CALL";
            l2text = "> HOLD";
            l3text = "* ABORT";
            l4text = "";
            l5text = "ON";
            l6text = "";
            r1text = "FIRSTALEA";
            r2text = "";
            r3text = "OFF";
            r4text = "";
            r5text = "2";
            r6text = "RETURN";

            currentPageTitle = "HF1 ALE FCTN"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, l5.Location.X + l5.Width, row10, "/", Color.White);

            TextBox l5c = new TextBox();
            TB(l5c, l5b.Location.X + l5b.Width, row10, "OFF", Color.Green);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, r3tText);
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col11 + 10, row6, "ON", Color.White);

            TextBox r3b = new TextBox();
            TB(r3b, r3.Location.X + r3.Width, row6, "/", Color.White);

            TextBox r3c = new TextBox();
            TB(r3c, col15, row6, r3text, Color.Green);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, r5tText);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col11 + 20, row10, "0", Color.White);

            TextBox r5a = new TextBox();
            TB(r5a, r5.Location.X + r5.Width, row10, "/", Color.White);

            TextBox r5b = new TextBox();
            TB(r5b, r5a.Location.X + r5a.Width, row10, "1", Color.White);

            TextBox r5c = new TextBox();
            TB(r5c, r5b.Location.X + r5b.Width, row10, "/", Color.White);

            TextBox r5d = new TextBox();
            TB(r5d, col15, row10, r5text, Color.Green);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            //if (r5text != "")
            //{
            //    TextBox r5r = new TextBox ( );
            //    TB (r5r, col16, row10, ">", Color.White);
            //}


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEfunctionPage2()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "LBC";
            l4tText = "";
            l5tText = "SELF ADDRESS";
            l6tText = "";
            r1tText = "SOUND";
            r2tText = "";
            r3tText = "RESPONSE";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "> MAN SOUND";
            l2text = "";
            l3text = "ON";
            l4text = "";
            l5text = "> OWNADRS";
            l6text = "";
            r1text = "OFF";
            r2text = "";
            r3text = "SILENT";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 ALE FCTN"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3a = new TextBox();
            TB(l3a, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, l3a.Location.X + l3a.Width, row6, "OFF", Color.Green);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1a = new TextBox();
            TB(r1a, col11 + 10, row2, "ON", Color.White);

            TextBox r1b = new TextBox();
            TB(r1b, r1a.Location.X + r1a.Width, row2, "/", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.Green);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, r3tText);
            TypeLeft(r3t);

            TextBox r3a = new TextBox();
            TB(r3a, col9, row6, "AUTO", Color.White);

            TextBox r3b = new TextBox();
            TB(r3b, r3a.Location.X + r3a.Width, row6, "/", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.Green);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEaddressPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "";
            l4tText = "";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "< ANY";
            l2text = "< ALL";
            l3text = "< FIRSTALEADDRESS";
            l4text = "< SECONDALEADDRESS";
            l5text = "< THIRDALEADDRESS";
            l6text = "< FOURTHALEADDRESS";
            r1text = "GROUP";
            r2text = "NET";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 ALE ADDRESS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/17");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEnetAddressPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "";
            l4tText = "";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "< NETADDRESS1";
            l2text = "< NETADDRESS2";
            l3text = "< NETADDRESS3";
            l4text = "< NETADDRESS4";
            l5text = "< NETADDRESS5";
            l6text = "< NETADDRESS6";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 NET ADDRESS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEpresetChannelsPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = ALEpre1Name;
            l2tText = ALEpre2Name;
            l3tText = ALEpre3Name;
            l4tText = ALEpre4Name;
            l5tText = ALEpre5Name;
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            if (ALEpre1Chan.Trim('<', ' ') == currentALEchan)
            {
                ALEpre1Chan = ALEpre1Chan.Replace('<', '*');
                ALEpre2Chan = ALEpre2Chan.Replace('*', '<');
                ALEpre3Chan = ALEpre3Chan.Replace('*', '<');
                ALEpre4Chan = ALEpre4Chan.Replace('*', '<');
                ALEpre5Chan = ALEpre5Chan.Replace('*', '<');
            }
            if (ALEpre2Chan.Trim('<', ' ') == currentALEchan)
            {
                ALEpre2Chan = ALEpre2Chan.Replace('<', '*');
                ALEpre1Chan = ALEpre1Chan.Replace('*', '<');
                ALEpre3Chan = ALEpre3Chan.Replace('*', '<');
                ALEpre4Chan = ALEpre4Chan.Replace('*', '<');
                ALEpre5Chan = ALEpre5Chan.Replace('*', '<');
            }
            if (ALEpre3Chan.Trim('<', ' ') == currentALEchan)
            {
                ALEpre3Chan = ALEpre3Chan.Replace('<', '*');
                ALEpre2Chan = ALEpre2Chan.Replace('*', '<');
                ALEpre1Chan = ALEpre1Chan.Replace('*', '<');
                ALEpre4Chan = ALEpre4Chan.Replace('*', '<');
                ALEpre5Chan = ALEpre5Chan.Replace('*', '<');
            }
            if (ALEpre4Chan.Trim('<', ' ') == currentALEchan)
            {
                ALEpre4Chan = ALEpre4Chan.Replace('<', '*');
                ALEpre3Chan = ALEpre3Chan.Replace('*', '<');
                ALEpre2Chan = ALEpre2Chan.Replace('*', '<');
                ALEpre1Chan = ALEpre1Chan.Replace('*', '<');
                ALEpre5Chan = ALEpre5Chan.Replace('*', '<');
            }
            if (ALEpre5Chan.Trim('<', ' ') == currentALEchan)
            {
                ALEpre5Chan = ALEpre5Chan.Replace('<', '*');
                ALEpre4Chan = ALEpre4Chan.Replace('*', '<');
                ALEpre3Chan = ALEpre3Chan.Replace('*', '<');
                ALEpre2Chan = ALEpre2Chan.Replace('*', '<');
                ALEpre1Chan = ALEpre1Chan.Replace('*', '<');

            }

            l1text = ALEpre1Chan;
            l2text = ALEpre2Chan;
            l3text = ALEpre3Chan;
            l4text = ALEpre4Chan;
            l5text = ALEpre5Chan;
            l6text = "";
            r1text = ALEpre1Freq;
            r2text = ALEpre2Freq;
            r3text = ALEpre3Freq;
            r4text = ALEpre4Freq;
            r5text = ALEpre5Freq;
            r6text = "RETURN";

            currentPageTitle = "HF1 ALE PRESET CHAN"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/7");

            TextBox l1t = new TextBox();
            TB(l1t, col5, row2, l1tText, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col5, row4, l2tText, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col5, row6, l3tText, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col5, row8, l4tText, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col5, row10, l5tText, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);





            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void HFALEgroupAddressPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1tText = "";
            l2tText = "";
            l3tText = "";
            l4tText = "";
            l5tText = "";
            l6tText = "";
            r1tText = "";
            r2tText = "";
            r3tText = "";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "< GROUPADDRESS1";
            l2text = "< GROUPADDRESS2";
            l3text = "< GROUPADDRESS3";
            l4text = "< GROUPADDRESS4";
            l5text = "< GROUPADDRESS5";
            l6text = "< GROUPADDRESS6";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 GROUP ADDRESS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, r1tText);
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, r2tText);
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, r3tText);
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, r4tText);
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, r5tText);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, r6tText);
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region HF Status Page

        private void HFStatusPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1text = "ON";
            l2text = myCont.HF1Ampl;
            l3text = myCont.HF1Eqpt;
            l4text = myCont.HF1Tune;
            l5text = "123-4537-890";
            l6text = "< FAULT HIST";
            r1text = "- - - ";
            r2text = "- - ";
            r3text = myCont.HF1VSWR;
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "HF1 STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();




            TB(status, title.Location.X + title.Width, row0, _HF1status, Color.White);


            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);



            TextBox l1slash = new TextBox();
            TB(l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1off = new TextBox();
            TB(l1off, l1slash.Location.X + l1slash.Width, row2, "OFF", Color.White);

            TextBox l1c = new TextBox();
            TB(l1c, col7, row1, "1553 BUS");
            CenterMe(l1c);

            TextBox bus = new TextBox();
            TB(bus, col9, row2, myCont.HF11553, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "AMPL");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox hitemp = new TextBox();
            TB(hitemp, col5, row3, "HITEMP");

            TextBox subGo = new TextBox();
            TB(subGo, col6, row4, myCont.HF1HiTemp, Color.White);

            TextBox CPLR = new TextBox();
            TB(CPLR, col9, row3, "CPLR");

            TextBox trmGo = new TextBox();
            TB(trmGo, col9 + 20, row4, myCont.HF1Cplr, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "EQPT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox RT = new TextBox();
            TB(RT, col10 + 20, row5, "RT");

            TextBox pwrGo = new TextBox();
            TB(pwrGo, col10 + 20, row6, myCont.HF1RT, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "TUNE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox OVRVLT = new TextBox();
            TB(OVRVLT, col5, row7, "OVRVLT");

            TextBox ramGo = new TextBox();
            TB(ramGo, col6, row8, myCont.HF1OverVlt, Color.White);

            TextBox FIBER = new TextBox();
            TB(FIBER, col9, row7, "FIBER");

            TextBox romGo = new TextBox();
            TB(romGo, col9 + 20, row8, myCont.HF1Fiber, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "VSN");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox tun = new TextBox ( );
            //TB (tun, col6, row9, "TUN");

            //TextBox tunGo = new TextBox ( );
            //TB (tunGo, col6, row10, myCont.TacanTun, Color.White);

            TextBox rcv = new TextBox();
            TB(rcv, col5, row5, "RCV-OVRLD");

            TextBox rcvGo = new TextBox();
            TB(rcvGo, col6 + 10, row6, myCont.HF1RcvOvrld, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "FLTS");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 30, row5, "VSWR");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox ( );
            //TB (r4t, col14 + 20, row7, "DPRAM");
            //TypeLeft (r4t);

            //TextBox r4 = new TextBox ( );
            //TB (r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            //TextBox r5 = new TextBox ( );
            //TB (r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox ( );
            //    TB (r4r, col16, row8, ">", Color.White);
            //}

            //if (r5text != "")
            //{
            //    TextBox r5r = new TextBox ( );
            //    TB (r5r, col16, row10, ">", Color.White);
            //}


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

            myCont.HF1ValueChanged = false;
            #endregion
        }

        #endregion

        #region ARC231 #1 Pages

        private void VU1controlPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< " + currentVU1chan;
            l2text = "TR";
            l3text = "0";
            l4text = "HIGH";
            l5text = "";
            l6text = "< COMSEC";
            r1text = BandSelection(currentVU1freq, "VU1") + currentVU1freq;
            r2text = "UHF";
            r3text = "";
            r4text = "";
            r5text = "PRESETS";
            r6text = "RETURN";



            currentPageTitle = "V/U1 CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col4, row2, currentVU1name, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2slash = new TextBox();
            TB(l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox trg = new TextBox();
            TB(trg, l2slash.Location.X + l2slash.Width, row4, "TR+G", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "SQUELCH");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3slash1 = new TextBox();
            TB(l3slash1, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox l31 = new TextBox();
            TB(l31, l3slash1.Location.X + l3slash1.Width, row6, "1", Color.Green);

            TextBox l3slash2 = new TextBox();
            TB(l3slash2, l31.Location.X + l31.Width, row6, "/", Color.White);

            TextBox l32 = new TextBox();
            TB(l32, l3slash2.Location.X + l3slash2.Width, row6, "2", Color.White);

            TextBox l3slash3 = new TextBox();
            TB(l3slash3, l32.Location.X + l32.Width, row6, "/", Color.White);

            TextBox l33 = new TextBox();
            TB(l33, l3slash3.Location.X + l3slash3.Width, row6, "3", Color.White);

            TextBox l3slash4 = new TextBox();
            TB(l3slash4, l33.Location.X + l33.Width, row6, "/", Color.White);

            TextBox l34 = new TextBox();
            TB(l34, l3slash4.Location.X + l3slash4.Width, row6, "4", Color.White);

            TextBox l3slash5 = new TextBox();
            TB(l3slash5, l34.Location.X + l34.Width, row6, "/", Color.White);

            TextBox l35 = new TextBox();
            TB(l35, l3slash5.Location.X + l3slash5.Width, row6, "5", Color.White);



            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "POWER");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox l4slash1 = new TextBox();
            TB(l4slash1, l4.Location.X + l4.Width, row8, "/", Color.White);

            TextBox med = new TextBox();
            TB(med, l4slash1.Location.X + l4slash1.Width, row8, "MED", Color.White);

            TextBox l4slash2 = new TextBox();
            TB(l4slash2, med.Location.X + med.Width, row8, "/", Color.White);

            TextBox low = new TextBox();
            TB(low, l4slash2.Location.X + l4slash2.Width, row8, "LOW", Color.White);



            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox comsec = new TextBox();
            TB(comsec, col9, row2, currentVU1ComsecVar, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col12, row3, "GUARD");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox off = new TextBox();
            TB(off, col8, row4, "OFF", Color.Green);

            TextBox r2slash1 = new TextBox();
            TB(r2slash1, off.Location.X + off.Width, row4, "/", Color.White);

            TextBox vhf = new TextBox();
            TB(vhf, r2slash1.Location.X + r2slash1.Width, row4, "VHF", Color.White);

            TextBox r2slash2 = new TextBox();
            TB(r2slash2, vhf.Location.X + vhf.Width, row4, "/", Color.White);



            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox();
            //    TB(r2r, col16, row4, ">", Color.White);
            //}

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1controlPage2()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "NOR";
            l2text = "[15]";
            l3text = "";
            l4text = "< MAINTENANCE";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "SINCGARS";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 CONTROL"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "CHAN MODE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1slash1 = new TextBox();
            TB(l1slash1, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox nar = new TextBox();
            TB(nar, l1slash1.Location.X + l1slash1.Width, row2, "NAR", Color.White);

            TextBox l1slash2 = new TextBox();
            TB(l1slash2, nar.Location.X + nar.Width, row2, "/", Color.White);

            TextBox atc = new TextBox();
            TB(atc, l1slash2.Location.X + l1slash2.Width, row2, "ATC", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "SIDETONE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row1, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row1, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1comsecControlPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 12 VINSON";
            l2text = "PLAIN";
            l3text = "DATA";
            l4text = "VINSON";
            l5text = "1.2K";
            l6text = "";
            r1text = "GET KEYS <";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 COMSEC CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "COMSEC MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2slash = new TextBox();
            TB(l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox cipher = new TextBox();
            TB(cipher, l2slash.Location.X + l2slash.Width, row4, "CIPHER", Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row1, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l3slash = new TextBox();
            TB(l3slash, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox voice = new TextBox();
            TB(voice, l3slash.Location.X + l3slash.Width, row6, "VOICE", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "KEY TYPE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "BAUD");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5slash1 = new TextBox();
            TB(l5slash1, l5.Location.X + l5.Width, row10, "/", Color.White);

            TextBox k24 = new TextBox();
            TB(k24, l5slash1.Location.X + l5slash1.Width, row10, "2.4K", Color.White);

            TextBox l5slash2 = new TextBox();
            TB(l5slash2, k24.Location.X + k24.Width, row10, "/", Color.White);

            TextBox k96 = new TextBox();
            TB(k96, l5slash2.Location.X + l5slash2.Width, row10, "9.6K", Color.White);

            TextBox l5slash3 = new TextBox();
            TB(l5slash3, k96.Location.X + k96.Width, row10, "/", Color.White);

            TextBox k12 = new TextBox();
            TB(k12, l5slash3.Location.X + l5slash3.Width, row10, "12K", Color.White);

            TextBox l5slash4 = new TextBox();
            TB(l5slash4, k12.Location.X + k12.Width, row10, "/", Color.White);

            TextBox k16 = new TextBox();
            TB(k16, l5slash4.Location.X + l5slash4.Width, row10, "16K", Color.Green);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);
            r1.Location = new Point(r1.Location.X + 24, r1.Location.Y);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox ( );
            //    TB (r1r, col16, row2, "<", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1comsecVarPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "< 2";
            l3text = "< 3";
            l4text = "< 4";
            l5text = "< 5";
            l6text = "";
            r1text = "6";
            r2text = "7";
            r3text = "8";
            r4text = "9";
            r5text = "10";
            r6text = "RETURN";

            currentPageTitle = "V/U1 COMSEC VAR"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col3, row2, "VINSON", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col3, row4, "ANDVT", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col3, row6, "1-KG84", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col3, row8, "3-KG84", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col3, row10, "VINSON", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14, row2, "FASCIN", Color.White);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14, row4, "FASCIN", Color.White);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14, row6, "VINSON", Color.White);
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14, row8, "VINSON", Color.White);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14, row10, "ANDVT", Color.White);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1comsecVarPage2()
        {
            CDU7000Page = true;
        }

        private void VU1sincgarsControlPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = ": RECV HOP";
            l2text = "NO FILL";
            l3text = ": [1]";
            l4text = "";
            l5text = "[01/15:29]";
            l6text = "< LOCKOUTS";
            r1text = "ERF";
            r2text = "OFF";
            r3text = "H2";
            r4text = "LATE ENTRY";
            r5text = "GPS TIME";
            r6text = "RETURN";

            currentPageTitle = "V/U1 SINCGARS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "RECV / SEND MODE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "CHANNEL STATUS");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "CHANNEL");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "CS COLD");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "TOD");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "MASTER");
            TypeLeft(r2t);

            TextBox r2on = new TextBox();
            TB(r2on, col11 + 10, row4, "ON", Color.White);

            TextBox r2slash = new TextBox();
            TB(r2slash, r2on.Location.X + r2on.Width, row4, "/", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.Green);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "FH MODE");
            TypeLeft(r3t);

            TextBox r3h1 = new TextBox();
            TB(r3h1, col12, row6, "H1", Color.Green);

            TextBox r3slash = new TextBox();
            TB(r3slash, r3h1.Location.X + r3h1.Width, row6, "/", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "P1      F   50.075");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1lockoutsPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "L1";
            l2text = "L217";
            l3text = "L3";
            l4text = "L488";
            l5text = "L562";
            l6text = "L6 - -";
            r1text = "L7 - -";
            r2text = "L8 - -";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 LOCKOUTS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox ( );
            //    TB (r1r, col16, row2, ">", Color.White);
            //}

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox ( );
            //    TB (r4r, col16, row8, ">", Color.White);
            //}

            //if (r5text != "")
            //{
            //    TextBox r5r = new TextBox ( );
            //    TB (r5r, col16, row10, ">", Color.White);
            //}


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region VU1 MX Pages

        private void VU1maintenancePage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< LOOPBACK";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "CLEAR";
            r2text = "FILL";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 MAINTENANCE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1ClearNVM()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> CLEAR ALL";
            l2text = "> CLEAR BIT FAULTS";
            l3text = "> CLEAR PRESETS";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 CLEAR NVM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1Fill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< COMSEC";
            l2text = "";
            l3text = "< TRANSEC";
            l4text = "< SINCGARS";
            l5text = "";
            l6text = "";
            r1text = "LOAD ALL";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);


            TextBox r1r = new TextBox();
            TB(r1r, col16, row2, "<", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1SincgarsFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> FILL";
            l2text = "> FILL";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "[ 1]";
            r2text = "[1]";
            r3text = "SET F2";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 SINCGARS FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1center = new TextBox();
            TB(l1center, col5, row2, "HOP=256", Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2center = new TextBox();
            TB(l2center, col5, row4, "LOCK=202", Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "CHANNEL");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "CHANNEL");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);


            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ":", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ":", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1TransecFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "[08]";
            l2text = "> LOAD";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "SET F2";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 TRANSEC FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3center = new TextBox();
            TB(l3center, col1, row6, "1  2  3  4  -  -  -  -", Color.White);
            CenterMe(l3center);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);


            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1LoopbackTest()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> TEST";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "239";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 LOOPBACK TEST"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col5, row2, "- - - -", Color.White);

            TextBox l2center = new TextBox();
            TB(l2center, col1, row4, "RSS=234", Color.White);
            CenterMe(l2center);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "CHANNEL");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1ComsecFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "[19]";
            l2text = "> LOAD";
            l3text = "> UPDATE=99";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "VINSON";
            r2text = "STATES";
            r3text = "SET F1";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 COMSEC FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1r = new TextBox();
            TB(r1r, col16, row2, ":", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3r = new TextBox();
            TB(r3r, col16, row6, "<", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1ComsecStatesPage1()
        {
            CDU7000Page = true;

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "V/U1 COMSEC STATES"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1 = new TextBox();
            TB(l1, col2, row2, "1", Color.White);
            TypeLeft(l1);

            TextBox l2 = new TextBox();
            TB(l2, col2, row3, "2", Color.White);
            TypeLeft(l2);

            TextBox l3 = new TextBox();
            TB(l3, col2, row4, "3", Color.White);
            TypeLeft(l3);

            TextBox l4 = new TextBox();
            TB(l4, col2, row5, "4", Color.White);
            TypeLeft(l4);

            TextBox l5 = new TextBox();
            TB(l5, col2, row6, "5", Color.White);
            TypeLeft(l5);

            TextBox l6 = new TextBox();
            TB(l6, col2, row7, "6", Color.White);
            TypeLeft(l6);

            TextBox l7 = new TextBox();
            TB(l7, col2, row8, "7", Color.White);
            TypeLeft(l7);

            TextBox l8 = new TextBox();
            TB(l8, col2, row9, "8", Color.White);
            TypeLeft(l8);

            TextBox l9 = new TextBox();
            TB(l9, col2, row10, "9", Color.White);
            TypeLeft(l9);

            TextBox l10 = new TextBox();
            TB(l10, col2, row11, "10", Color.White);
            TypeLeft(l10);



            TextBox l1key = new TextBox();
            TB(l1key, col4, row2, "TEK", Color.White);


            TextBox l2key = new TextBox();
            TB(l2key, col4, row3, "TEK", Color.White);


            TextBox l3key = new TextBox();
            TB(l3key, col4, row4, "TEK", Color.White);


            TextBox l4key = new TextBox();
            TB(l4key, col4, row5, "TEK", Color.White);


            TextBox l5key = new TextBox();
            TB(l5key, col4, row6, "- - -", Color.White);


            TextBox l6key = new TextBox();
            TB(l6key, col4, row7, "- - -", Color.White);


            TextBox l7key = new TextBox();
            TB(l7key, col4, row8, "- - -", Color.White);


            TextBox l8key = new TextBox();
            TB(l8key, col4, row9, "- - -", Color.White);


            TextBox l9key = new TextBox();
            TB(l9key, col4, row10, "- - -", Color.White);


            TextBox l10key = new TextBox();
            TB(l10key, col4, row11, "- - -", Color.White);




            TextBox l1num = new TextBox();
            TB(l1num, col7, row2, "76", Color.White);


            TextBox l2num = new TextBox();
            TB(l2num, col7, row3, "23", Color.White);


            TextBox l3num = new TextBox();
            TB(l3num, col7, row4, "10", Color.White);


            TextBox l4num = new TextBox();
            TB(l4num, col7, row5, "03", Color.White);


            TextBox l5num = new TextBox();
            TB(l5num, col7, row6, "- -", Color.White);


            TextBox l6num = new TextBox();
            TB(l6num, col7, row7, "- -", Color.White);


            TextBox l7num = new TextBox();
            TB(l7num, col7, row8, "- -", Color.White);


            TextBox l8num = new TextBox();
            TB(l8num, col7, row9, "- -", Color.White);


            TextBox l9num = new TextBox();
            TB(l9num, col7, row10, "- -", Color.White);


            TextBox l10num = new TextBox();
            TB(l10num, col7, row11, "- -", Color.White);





            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1ComsecStatesPage2()
        {
            CDU7000Page = true;

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "V/U1 COMSEC STATES"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1 = new TextBox();
            TB(l1, col2, row2, "1", Color.White);
            TypeLeft(l1);

            TextBox l2 = new TextBox();
            TB(l2, col2, row3, "2", Color.White);
            TypeLeft(l2);

            TextBox l3 = new TextBox();
            TB(l3, col2, row4, "3", Color.White);
            TypeLeft(l3);

            TextBox l4 = new TextBox();
            TB(l4, col2, row5, "4", Color.White);
            TypeLeft(l4);

            TextBox l5 = new TextBox();
            TB(l5, col2, row6, "5", Color.White);
            TypeLeft(l5);

            TextBox l6 = new TextBox();
            TB(l6, col2, row7, "6", Color.White);
            TypeLeft(l6);

            TextBox l7 = new TextBox();
            TB(l7, col2, row8, "7", Color.White);
            TypeLeft(l7);

            TextBox l8 = new TextBox();
            TB(l8, col2, row9, "8", Color.White);
            TypeLeft(l8);

            TextBox l9 = new TextBox();
            TB(l9, col2, row10, "9", Color.White);
            TypeLeft(l9);

            TextBox l10 = new TextBox();
            TB(l10, col2, row11, "10", Color.White);
            TypeLeft(l10);



            TextBox l1key = new TextBox();
            TB(l1key, col4, row2, "- - -", Color.White);


            TextBox l2key = new TextBox();
            TB(l2key, col4, row3, "- - -", Color.White);


            TextBox l3key = new TextBox();
            TB(l3key, col4, row4, "- - -", Color.White);


            TextBox l4key = new TextBox();
            TB(l4key, col4, row5, "- - -", Color.White);


            TextBox l5key = new TextBox();
            TB(l5key, col4, row6, "- - -", Color.White);


            TextBox l6key = new TextBox();
            TB(l6key, col4, row7, "- - -", Color.White);


            TextBox l7key = new TextBox();
            TB(l7key, col4, row8, "- - -", Color.White);


            TextBox l8key = new TextBox();
            TB(l8key, col4, row9, "- - -", Color.White);


            TextBox l9key = new TextBox();
            TB(l9key, col4, row10, "- - -", Color.White);


            TextBox l10key = new TextBox();
            TB(l10key, col4, row11, "- - -", Color.White);




            TextBox l1num = new TextBox();
            TB(l1num, col7, row2, "- -", Color.White);


            TextBox l2num = new TextBox();
            TB(l2num, col7, row3, "- -", Color.White);


            TextBox l3num = new TextBox();
            TB(l3num, col7, row4, "- -", Color.White);


            TextBox l4num = new TextBox();
            TB(l4num, col7, row5, "- -", Color.White);


            TextBox l5num = new TextBox();
            TB(l5num, col7, row6, "- -", Color.White);


            TextBox l6num = new TextBox();
            TB(l6num, col7, row7, "- -", Color.White);


            TextBox l7num = new TextBox();
            TB(l7num, col7, row8, "- -", Color.White);


            TextBox l8num = new TextBox();
            TB(l8num, col7, row9, "- -", Color.White);


            TextBox l9num = new TextBox();
            TB(l9num, col7, row10, "- -", Color.White);


            TextBox l10num = new TextBox();
            TB(l10num, col7, row11, "- -", Color.White);





            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }


        #endregion

        private void VU1uhfPresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion


            if (VU1UHFpre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('<', '*');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
                VU1band = activeBand.UHF;
            }
            if (VU1UHFpre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('<', '*');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
                VU1band = activeBand.UHF;
            }
            if (VU1UHFpre3Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('<', '*');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
                VU1band = activeBand.UHF;
            }
            if (VU1UHFpre4Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('<', '*');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
                VU1band = activeBand.UHF;
            }
            if (VU1UHFpre5Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('<', '*');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1band = activeBand.UHF;

            }





            l1text = VU1UHFpre1Chan;
            l2text = VU1UHFpre2Chan;
            l3text = VU1UHFpre3Chan;
            l4text = VU1UHFpre4Chan;
            l5text = VU1UHFpre5Chan;
            l6text = "";
            r1text = VU1UHFpre1Freq;
            r2text = VU1UHFpre2Freq;
            r3text = VU1UHFpre3Freq;
            r4text = VU1UHFpre4Freq;
            r5text = VU1UHFpre5Freq;
            r6text = "RETURN";


            currentPageTitle = "V/U1 UHF"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU1UHFpre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU1UHFpre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU1UHFpre1Freq, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, VU1UHFpre2Name, Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, VU1UHFpre2Comsec, Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU1UHFpre2Freq, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU1UHFpre3Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, VU1UHFpre3Comsec, Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU1UHFpre3Freq, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, VU1UHFpre4Name, Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, VU1UHFpre4Comsec, Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU1UHFpre4Freq, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, VU1UHFpre5Name, Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, VU1UHFpre5Comsec, Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, VU1UHFpre5Freq, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);



            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1vhfFMpresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion

            if (VU1FMpre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1FMpre1Chan = VU1FMpre1Chan.Replace('<', '*');
                VU1FMpre2Chan = VU1FMpre2Chan.Replace('*', '<');
                VU1FMpre3Chan = VU1FMpre3Chan.Replace('*', '<');
                VU1FMpre4Chan = VU1FMpre4Chan.Replace('*', '<');
                VU1FMpre5Chan = VU1FMpre5Chan.Replace('*', '<');
                VU1band = activeBand.FM;
            }
            if (VU1FMpre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1FMpre2Chan = VU1FMpre2Chan.Replace('<', '*');
                VU1FMpre1Chan = VU1FMpre1Chan.Replace('*', '<');
                VU1FMpre3Chan = VU1FMpre3Chan.Replace('*', '<');
                VU1FMpre4Chan = VU1FMpre4Chan.Replace('*', '<');
                VU1FMpre5Chan = VU1FMpre5Chan.Replace('*', '<');
                VU1band = activeBand.FM;
            }
            if (VU1FMpre3Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1FMpre3Chan = VU1FMpre3Chan.Replace('<', '*');
                VU1FMpre2Chan = VU1FMpre2Chan.Replace('*', '<');
                VU1FMpre1Chan = VU1FMpre1Chan.Replace('*', '<');
                VU1FMpre4Chan = VU1FMpre4Chan.Replace('*', '<');
                VU1FMpre5Chan = VU1FMpre5Chan.Replace('*', '<');
                VU1band = activeBand.FM;
            }
            if (VU1FMpre4Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1FMpre4Chan = VU1FMpre4Chan.Replace('<', '*');
                VU1FMpre3Chan = VU1FMpre3Chan.Replace('*', '<');
                VU1FMpre2Chan = VU1FMpre2Chan.Replace('*', '<');
                VU1FMpre1Chan = VU1FMpre1Chan.Replace('*', '<');
                VU1FMpre5Chan = VU1FMpre5Chan.Replace('*', '<');
                VU1band = activeBand.FM;
            }
            if (VU1FMpre5Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1FMpre5Chan = VU1FMpre5Chan.Replace('<', '*');
                VU1FMpre4Chan = VU1FMpre4Chan.Replace('*', '<');
                VU1FMpre3Chan = VU1FMpre3Chan.Replace('*', '<');
                VU1FMpre2Chan = VU1FMpre2Chan.Replace('*', '<');
                VU1FMpre1Chan = VU1FMpre1Chan.Replace('*', '<');
                VU1band = activeBand.FM;

            }

            l1text = VU1FMpre1Chan;
            l2text = VU1FMpre2Chan;
            l3text = VU1FMpre3Chan;
            l4text = VU1FMpre4Chan;
            l5text = VU1FMpre5Chan;
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 VHF-FM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU1FMpre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU1FMpre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU1FMpre1Freq, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, VU1FMpre2Name, Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, VU1FMpre2Comsec, Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU1FMpre2Freq, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU1FMpre3Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, VU1FMpre3Comsec, Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU1FMpre3Freq, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, VU1FMpre4Name, Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, VU1FMpre4Comsec, Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU1FMpre4Freq, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, VU1FMpre5Name, Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, VU1FMpre5Comsec, Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, VU1FMpre5Freq, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1vhfAMpresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion

            if (VU1AMpre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1AMpre1Chan = VU1AMpre1Chan.Replace('<', '*');
                VU1AMpre2Chan = VU1AMpre2Chan.Replace('*', '<');
                VU1AMpre3Chan = VU1AMpre3Chan.Replace('*', '<');
                VU1AMpre4Chan = VU1AMpre4Chan.Replace('*', '<');
                VU1AMpre5Chan = VU1AMpre5Chan.Replace('*', '<');
                VU1band = activeBand.AM;
            }
            if (VU1AMpre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1AMpre2Chan = VU1AMpre2Chan.Replace('<', '*');
                VU1AMpre1Chan = VU1AMpre1Chan.Replace('*', '<');
                VU1AMpre3Chan = VU1AMpre3Chan.Replace('*', '<');
                VU1AMpre4Chan = VU1AMpre4Chan.Replace('*', '<');
                VU1AMpre5Chan = VU1AMpre5Chan.Replace('*', '<');
                VU1band = activeBand.AM;
            }
            if (VU1AMpre3Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1AMpre3Chan = VU1AMpre3Chan.Replace('<', '*');
                VU1AMpre2Chan = VU1AMpre2Chan.Replace('*', '<');
                VU1AMpre1Chan = VU1AMpre1Chan.Replace('*', '<');
                VU1AMpre4Chan = VU1AMpre4Chan.Replace('*', '<');
                VU1AMpre5Chan = VU1AMpre5Chan.Replace('*', '<');
                VU1band = activeBand.AM;
            }
            if (VU1AMpre4Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1AMpre4Chan = VU1AMpre4Chan.Replace('<', '*');
                VU1AMpre3Chan = VU1AMpre3Chan.Replace('*', '<');
                VU1AMpre2Chan = VU1AMpre2Chan.Replace('*', '<');
                VU1AMpre1Chan = VU1AMpre1Chan.Replace('*', '<');
                VU1AMpre5Chan = VU1AMpre5Chan.Replace('*', '<');
                VU1band = activeBand.AM;
            }
            if (VU1AMpre5Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1AMpre5Chan = VU1AMpre5Chan.Replace('<', '*');
                VU1AMpre4Chan = VU1AMpre4Chan.Replace('*', '<');
                VU1AMpre3Chan = VU1AMpre3Chan.Replace('*', '<');
                VU1AMpre2Chan = VU1AMpre2Chan.Replace('*', '<');
                VU1AMpre1Chan = VU1AMpre1Chan.Replace('*', '<');
                VU1band = activeBand.AM;

            }

            l1text = VU1AMpre1Chan;
            l2text = VU1AMpre2Chan;
            l3text = VU1AMpre3Chan;
            l4text = VU1AMpre4Chan;
            l5text = VU1AMpre5Chan;
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 VHF-AM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU1AMpre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU1AMpre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU1AMpre1Freq, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, VU1AMpre2Name, Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, VU1AMpre2Comsec, Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU1AMpre2Freq, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU1AMpre3Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, VU1AMpre3Comsec, Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU1AMpre3Freq, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, VU1AMpre4Name, Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, VU1AMpre4Comsec, Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU1AMpre4Freq, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, VU1AMpre5Name, Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, VU1AMpre5Comsec, Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, VU1AMpre5Freq, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1satcomPresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion

            if (VU1SatcomPre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1SatcomPre1Chan = VU1SatcomPre1Chan.Replace('<', '*');
                VU1SatcomPre2Chan = VU1SatcomPre2Chan.Replace('*', '<');
                VU1band = activeBand.SATCOM;
            }
            if (VU1SatcomPre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1SatcomPre2Chan = VU1SatcomPre2Chan.Replace('<', '*');
                VU1SatcomPre1Chan = VU1SatcomPre1Chan.Replace('*', '<');
                VU1band = activeBand.SATCOM;
            }


            l1text = VU1SatcomPre1Chan;
            l2text = "[" + VU1SatcomPre1SATchan + "]";
            l3text = VU1SatcomPre2Chan;
            l4text = "[" + VU1SatcomPre2SATchan + "]";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 SATCOM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/10");


            TextBox l1t = new TextBox();
            TB(l1t, col14 + 25, row1, "UPLINK");
            TypeLeft(l1t);

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU1SatcomPre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU1SatcomPre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU1SatcomPre1Uplink, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "CHANNEL");

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU1SatcomPre1Downlink, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU1SatcomPre2Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, VU1SatcomPre2Comsec, Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU1SatcomPre2Uplink, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "CHANNEL");

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU1SatcomPre2Downlink, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5callsign = new TextBox ( );
            //TB (l5callsign, col4, row10, "GRNLDR", Color.White);

            //TextBox l5comsec = new TextBox ( );
            //TB (l5comsec, col9, row10, "P1", Color.White);

            //TextBox l5freq = new TextBox ( );
            //TB (l5freq, col15, row10, "40.475", Color.White);

            //TextBox l5 = new TextBox ( );
            //TB (l5, col1, row10, l5text, Color.White);

            ////TextBox l6t = new TextBox();
            ////TB(l6t, col2, row1, "IDENT");

            //TextBox l6 = new TextBox ( );
            //TB (l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 25, row3, "DOWNLINK");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 25, row5, "UPLINK");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 25, row7, "DOWNLINK");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU1hopsetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion

            if (VU1HOPpre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1HOPpre1Chan = VU1HOPpre1Chan.Replace('<', '*');
                VU1HOPpre2Chan = VU1HOPpre2Chan.Replace('*', '<');
                VU1HOPpre3Chan = VU1HOPpre3Chan.Replace('*', '<');
                VU1HOPpre4Chan = VU1HOPpre4Chan.Replace('*', '<');
                VU1HOPpre5Chan = VU1HOPpre5Chan.Replace('*', '<');
                VU1band = activeBand.HOPSETS;
            }
            if (VU1HOPpre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1HOPpre2Chan = VU1HOPpre2Chan.Replace('<', '*');
                VU1HOPpre1Chan = VU1HOPpre1Chan.Replace('*', '<');
                VU1HOPpre3Chan = VU1HOPpre3Chan.Replace('*', '<');
                VU1HOPpre4Chan = VU1HOPpre4Chan.Replace('*', '<');
                VU1HOPpre5Chan = VU1HOPpre5Chan.Replace('*', '<');
                VU1band = activeBand.HOPSETS;
            }
            if (VU1HOPpre3Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1HOPpre3Chan = VU1HOPpre3Chan.Replace('<', '*');
                VU1HOPpre2Chan = VU1HOPpre2Chan.Replace('*', '<');
                VU1HOPpre1Chan = VU1HOPpre1Chan.Replace('*', '<');
                VU1HOPpre4Chan = VU1HOPpre4Chan.Replace('*', '<');
                VU1HOPpre5Chan = VU1HOPpre5Chan.Replace('*', '<');
                VU1band = activeBand.HOPSETS;
            }
            if (VU1HOPpre4Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1HOPpre4Chan = VU1HOPpre4Chan.Replace('<', '*');
                VU1HOPpre3Chan = VU1HOPpre3Chan.Replace('*', '<');
                VU1HOPpre2Chan = VU1HOPpre2Chan.Replace('*', '<');
                VU1HOPpre1Chan = VU1HOPpre1Chan.Replace('*', '<');
                VU1HOPpre5Chan = VU1HOPpre5Chan.Replace('*', '<');
                VU1band = activeBand.HOPSETS;
            }
            if (VU1HOPpre5Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1HOPpre5Chan = VU1HOPpre5Chan.Replace('<', '*');
                VU1HOPpre4Chan = VU1HOPpre4Chan.Replace('*', '<');
                VU1HOPpre3Chan = VU1HOPpre3Chan.Replace('*', '<');
                VU1HOPpre2Chan = VU1HOPpre2Chan.Replace('*', '<');
                VU1HOPpre1Chan = VU1HOPpre1Chan.Replace('*', '<');
                VU1band = activeBand.HOPSETS;

            }

            l1text = VU1HOPpre1Chan;
            l2text = VU1HOPpre2Chan;
            l3text = VU1HOPpre3Chan;
            l4text = VU1HOPpre4Chan;
            l5text = VU1HOPpre5Chan;
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U1 HOPSETS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU1HOPpre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU1HOPpre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU1HOPpre1Freq, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, VU1HOPpre2Name, Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, VU1HOPpre2Comsec, Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU1HOPpre2Freq, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU1HOPpre3Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, VU1HOPpre3Comsec, Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU1HOPpre3Freq, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, VU1HOPpre4Name, Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, VU1HOPpre4Comsec, Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU1HOPpre4Freq, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, VU1HOPpre5Name, Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, VU1HOPpre5Comsec, Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, VU1HOPpre5Freq, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }




        #endregion

        #region ARC231 #2 Pages

        private void VU2controlPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< " + currentVU2chan;
            l2text = "TR";
            l3text = "0";
            l4text = "HIGH";
            l5text = "";
            l6text = "< COMSEC";
            r1text = BandSelection(currentVU2freq, "VU2") + currentVU2freq;
            r2text = "UHF";
            r3text = "";
            r4text = "";
            r5text = "PRESETS";
            r6text = "RETURN";



            currentPageTitle = "V/U2 CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col4, row2, currentVU2name, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2slash = new TextBox();
            TB(l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox trg = new TextBox();
            TB(trg, l2slash.Location.X + l2slash.Width, row4, "TR+G", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "SQUELCH");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3slash1 = new TextBox();
            TB(l3slash1, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox l31 = new TextBox();
            TB(l31, l3slash1.Location.X + l3slash1.Width, row6, "1", Color.Green);

            TextBox l3slash2 = new TextBox();
            TB(l3slash2, l31.Location.X + l31.Width, row6, "/", Color.White);

            TextBox l32 = new TextBox();
            TB(l32, l3slash2.Location.X + l3slash2.Width, row6, "2", Color.White);

            TextBox l3slash3 = new TextBox();
            TB(l3slash3, l32.Location.X + l32.Width, row6, "/", Color.White);

            TextBox l33 = new TextBox();
            TB(l33, l3slash3.Location.X + l3slash3.Width, row6, "3", Color.White);

            TextBox l3slash4 = new TextBox();
            TB(l3slash4, l33.Location.X + l33.Width, row6, "/", Color.White);

            TextBox l34 = new TextBox();
            TB(l34, l3slash4.Location.X + l3slash4.Width, row6, "4", Color.White);

            TextBox l3slash5 = new TextBox();
            TB(l3slash5, l34.Location.X + l34.Width, row6, "/", Color.White);

            TextBox l35 = new TextBox();
            TB(l35, l3slash5.Location.X + l3slash5.Width, row6, "5", Color.White);



            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "POWER");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox l4slash1 = new TextBox();
            TB(l4slash1, l4.Location.X + l4.Width, row8, "/", Color.White);

            TextBox med = new TextBox();
            TB(med, l4slash1.Location.X + l4slash1.Width, row8, "MED", Color.White);

            TextBox l4slash2 = new TextBox();
            TB(l4slash2, med.Location.X + med.Width, row8, "/", Color.White);

            TextBox low = new TextBox();
            TB(low, l4slash2.Location.X + l4slash2.Width, row8, "LOW", Color.White);



            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox comsec = new TextBox();
            TB(comsec, col9, row2, currentVU2ComsecVar, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col12, row3, "GUARD");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox off = new TextBox();
            TB(off, col8, row4, "OFF", Color.Green);

            TextBox r2slash1 = new TextBox();
            TB(r2slash1, off.Location.X + off.Width, row4, "/", Color.White);

            TextBox vhf = new TextBox();
            TB(vhf, r2slash1.Location.X + r2slash1.Width, row4, "VHF", Color.White);

            TextBox r2slash2 = new TextBox();
            TB(r2slash2, vhf.Location.X + vhf.Width, row4, "/", Color.White);



            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox();
            //    TB(r2r, col16, row4, ">", Color.White);
            //}

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2controlPage2()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "NOR";
            l2text = "[15]";
            l3text = "";
            l4text = "< MAINTENANCE";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "SINCGARS";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 CONTROL"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "CHAN MODE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1slash1 = new TextBox();
            TB(l1slash1, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox nar = new TextBox();
            TB(nar, l1slash1.Location.X + l1slash1.Width, row2, "NAR", Color.White);

            TextBox l1slash2 = new TextBox();
            TB(l1slash2, nar.Location.X + nar.Width, row2, "/", Color.White);

            TextBox atc = new TextBox();
            TB(atc, l1slash2.Location.X + l1slash2.Width, row2, "ATC", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "SIDETONE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row1, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row1, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2comsecControlPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 12 VINSON";
            l2text = "PLAIN";
            l3text = "DATA";
            l4text = "VINSON";
            l5text = "1.2K";
            l6text = "";
            r1text = "GET KEYS <";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 COMSEC CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "COMSEC MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2slash = new TextBox();
            TB(l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox cipher = new TextBox();
            TB(cipher, l2slash.Location.X + l2slash.Width, row4, "CIPHER", Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row1, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l3slash = new TextBox();
            TB(l3slash, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox voice = new TextBox();
            TB(voice, l3slash.Location.X + l3slash.Width, row6, "VOICE", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "KEY TYPE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "BAUD");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5slash1 = new TextBox();
            TB(l5slash1, l5.Location.X + l5.Width, row10, "/", Color.White);

            TextBox k24 = new TextBox();
            TB(k24, l5slash1.Location.X + l5slash1.Width, row10, "2.4K", Color.White);

            TextBox l5slash2 = new TextBox();
            TB(l5slash2, k24.Location.X + k24.Width, row10, "/", Color.White);

            TextBox k96 = new TextBox();
            TB(k96, l5slash2.Location.X + l5slash2.Width, row10, "9.6K", Color.White);

            TextBox l5slash3 = new TextBox();
            TB(l5slash3, k96.Location.X + k96.Width, row10, "/", Color.White);

            TextBox k12 = new TextBox();
            TB(k12, l5slash3.Location.X + l5slash3.Width, row10, "12K", Color.White);

            TextBox l5slash4 = new TextBox();
            TB(l5slash4, k12.Location.X + k12.Width, row10, "/", Color.White);

            TextBox k16 = new TextBox();
            TB(k16, l5slash4.Location.X + l5slash4.Width, row10, "16K", Color.Green);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);
            r1.Location = new Point(r1.Location.X + 24, r1.Location.Y);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox ( );
            //    TB (r1r, col16, row2, "<", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2comsecVarPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "< 2";
            l3text = "< 3";
            l4text = "< 4";
            l5text = "< 5";
            l6text = "";
            r1text = "6";
            r2text = "7";
            r3text = "8";
            r4text = "9";
            r5text = "10";
            r6text = "RETURN";

            currentPageTitle = "V/U2 COMSEC VAR"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col3, row2, "VINSON", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col3, row4, "ANDVT", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col3, row6, "1-KG84", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col3, row8, "3-KG84", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col3, row10, "VINSON", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14, row2, "FASCIN", Color.White);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14, row4, "FASCIN", Color.White);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14, row6, "VINSON", Color.White);
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14, row8, "VINSON", Color.White);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14, row10, "ANDVT", Color.White);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2comsecVarPage2()
        {
            CDU7000Page = true;
        }

        private void VU2sincgarsControlPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = ": RECV HOP";
            l2text = "NO FILL";
            l3text = ": [1]";
            l4text = "";
            l5text = "[01/15:29]";
            l6text = "< LOCKOUTS";
            r1text = "ERF";
            r2text = "OFF";
            r3text = "H2";
            r4text = "LATE ENTRY";
            r5text = "GPS TIME";
            r6text = "RETURN";

            currentPageTitle = "V/U2 SINCGARS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "RECV / SEND MODE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "CHANNEL STATUS");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "CHANNEL");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "CS COLD");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "TOD");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "MASTER");
            TypeLeft(r2t);

            TextBox r2on = new TextBox();
            TB(r2on, col11 + 10, row4, "ON", Color.White);

            TextBox r2slash = new TextBox();
            TB(r2slash, r2on.Location.X + r2on.Width, row4, "/", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.Green);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "FH MODE");
            TypeLeft(r3t);

            TextBox r3h1 = new TextBox();
            TB(r3h1, col12, row6, "H1", Color.Green);

            TextBox r3slash = new TextBox();
            TB(r3slash, r3h1.Location.X + r3h1.Width, row6, "/", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "P1      F   50.075");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, "<", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2lockoutsPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "L1";
            l2text = "L217";
            l3text = "L3";
            l4text = "L488";
            l5text = "L562";
            l6text = "L6 - -";
            r1text = "L7 - -";
            r2text = "L8 - -";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 LOCKOUTS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox ( );
            //    TB (r1r, col16, row2, ">", Color.White);
            //}

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox ( );
            //    TB (r4r, col16, row8, ">", Color.White);
            //}

            //if (r5text != "")
            //{
            //    TextBox r5r = new TextBox ( );
            //    TB (r5r, col16, row10, ">", Color.White);
            //}


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region VU2 MX Pages

        private void VU2maintenancePage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< LOOPBACK";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "CLEAR";
            r2text = "FILL";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 MAINTENANCE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2ClearNVM()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> CLEAR ALL";
            l2text = "> CLEAR BIT FAULTS";
            l3text = "> CLEAR PRESETS";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 CLEAR NVM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2Fill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< COMSEC";
            l2text = "";
            l3text = "< TRANSEC";
            l4text = "< SINCGARS";
            l5text = "";
            l6text = "";
            r1text = "LOAD ALL";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);


            TextBox r1r = new TextBox();
            TB(r1r, col16, row2, "<", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2SincgarsFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> FILL";
            l2text = "> FILL";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "[ 1]";
            r2text = "[1]";
            r3text = "SET F2";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 SINCGARS FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1center = new TextBox();
            TB(l1center, col5, row2, "HOP=256", Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2center = new TextBox();
            TB(l2center, col5, row4, "LOCK=202", Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "CHANNEL");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "CHANNEL");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);


            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ":", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ":", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2TransecFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "[08]";
            l2text = "> LOAD";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "SET F2";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 TRANSEC FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3center = new TextBox();
            TB(l3center, col1, row6, "1  2  3  4  -  -  -  -", Color.White);
            CenterMe(l3center);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);


            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2LoopbackTest()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> TEST";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "239";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 LOOPBACK TEST"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col5, row2, "- - - -", Color.White);

            TextBox l2center = new TextBox();
            TB(l2center, col1, row4, "RSS=234", Color.White);
            CenterMe(l2center);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "CHANNEL");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2ComsecFill()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "[19]";
            l2text = "> LOAD";
            l3text = "> UPDATE=99";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "VINSON";
            r2text = "STATES";
            r3text = "SET F1";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 COMSEC FILL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1r = new TextBox();
            TB(r1r, col16, row2, ":", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3r = new TextBox();
            TB(r3r, col16, row6, "<", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2ComsecStatesPage1()
        {
            CDU7000Page = true;

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "V/U2 COMSEC STATES"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1 = new TextBox();
            TB(l1, col2, row2, "1", Color.White);
            TypeLeft(l1);

            TextBox l2 = new TextBox();
            TB(l2, col2, row3, "2", Color.White);
            TypeLeft(l2);

            TextBox l3 = new TextBox();
            TB(l3, col2, row4, "3", Color.White);
            TypeLeft(l3);

            TextBox l4 = new TextBox();
            TB(l4, col2, row5, "4", Color.White);
            TypeLeft(l4);

            TextBox l5 = new TextBox();
            TB(l5, col2, row6, "5", Color.White);
            TypeLeft(l5);

            TextBox l6 = new TextBox();
            TB(l6, col2, row7, "6", Color.White);
            TypeLeft(l6);

            TextBox l7 = new TextBox();
            TB(l7, col2, row8, "7", Color.White);
            TypeLeft(l7);

            TextBox l8 = new TextBox();
            TB(l8, col2, row9, "8", Color.White);
            TypeLeft(l8);

            TextBox l9 = new TextBox();
            TB(l9, col2, row10, "9", Color.White);
            TypeLeft(l9);

            TextBox l10 = new TextBox();
            TB(l10, col2, row11, "10", Color.White);
            TypeLeft(l10);



            TextBox l1key = new TextBox();
            TB(l1key, col4, row2, "TEK", Color.White);


            TextBox l2key = new TextBox();
            TB(l2key, col4, row3, "TEK", Color.White);


            TextBox l3key = new TextBox();
            TB(l3key, col4, row4, "TEK", Color.White);


            TextBox l4key = new TextBox();
            TB(l4key, col4, row5, "TEK", Color.White);


            TextBox l5key = new TextBox();
            TB(l5key, col4, row6, "- - -", Color.White);


            TextBox l6key = new TextBox();
            TB(l6key, col4, row7, "- - -", Color.White);


            TextBox l7key = new TextBox();
            TB(l7key, col4, row8, "- - -", Color.White);


            TextBox l8key = new TextBox();
            TB(l8key, col4, row9, "- - -", Color.White);


            TextBox l9key = new TextBox();
            TB(l9key, col4, row10, "- - -", Color.White);


            TextBox l10key = new TextBox();
            TB(l10key, col4, row11, "- - -", Color.White);




            TextBox l1num = new TextBox();
            TB(l1num, col7, row2, "76", Color.White);


            TextBox l2num = new TextBox();
            TB(l2num, col7, row3, "23", Color.White);


            TextBox l3num = new TextBox();
            TB(l3num, col7, row4, "10", Color.White);


            TextBox l4num = new TextBox();
            TB(l4num, col7, row5, "03", Color.White);


            TextBox l5num = new TextBox();
            TB(l5num, col7, row6, "- -", Color.White);


            TextBox l6num = new TextBox();
            TB(l6num, col7, row7, "- -", Color.White);


            TextBox l7num = new TextBox();
            TB(l7num, col7, row8, "- -", Color.White);


            TextBox l8num = new TextBox();
            TB(l8num, col7, row9, "- -", Color.White);


            TextBox l9num = new TextBox();
            TB(l9num, col7, row10, "- -", Color.White);


            TextBox l10num = new TextBox();
            TB(l10num, col7, row11, "- -", Color.White);





            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2ComsecStatesPage2()
        {
            CDU7000Page = true;

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "V/U2 COMSEC STATES"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1 = new TextBox();
            TB(l1, col2, row2, "1", Color.White);
            TypeLeft(l1);

            TextBox l2 = new TextBox();
            TB(l2, col2, row3, "2", Color.White);
            TypeLeft(l2);

            TextBox l3 = new TextBox();
            TB(l3, col2, row4, "3", Color.White);
            TypeLeft(l3);

            TextBox l4 = new TextBox();
            TB(l4, col2, row5, "4", Color.White);
            TypeLeft(l4);

            TextBox l5 = new TextBox();
            TB(l5, col2, row6, "5", Color.White);
            TypeLeft(l5);

            TextBox l6 = new TextBox();
            TB(l6, col2, row7, "6", Color.White);
            TypeLeft(l6);

            TextBox l7 = new TextBox();
            TB(l7, col2, row8, "7", Color.White);
            TypeLeft(l7);

            TextBox l8 = new TextBox();
            TB(l8, col2, row9, "8", Color.White);
            TypeLeft(l8);

            TextBox l9 = new TextBox();
            TB(l9, col2, row10, "9", Color.White);
            TypeLeft(l9);

            TextBox l10 = new TextBox();
            TB(l10, col2, row11, "10", Color.White);
            TypeLeft(l10);



            TextBox l1key = new TextBox();
            TB(l1key, col4, row2, "- - -", Color.White);


            TextBox l2key = new TextBox();
            TB(l2key, col4, row3, "- - -", Color.White);


            TextBox l3key = new TextBox();
            TB(l3key, col4, row4, "- - -", Color.White);


            TextBox l4key = new TextBox();
            TB(l4key, col4, row5, "- - -", Color.White);


            TextBox l5key = new TextBox();
            TB(l5key, col4, row6, "- - -", Color.White);


            TextBox l6key = new TextBox();
            TB(l6key, col4, row7, "- - -", Color.White);


            TextBox l7key = new TextBox();
            TB(l7key, col4, row8, "- - -", Color.White);


            TextBox l8key = new TextBox();
            TB(l8key, col4, row9, "- - -", Color.White);


            TextBox l9key = new TextBox();
            TB(l9key, col4, row10, "- - -", Color.White);


            TextBox l10key = new TextBox();
            TB(l10key, col4, row11, "- - -", Color.White);




            TextBox l1num = new TextBox();
            TB(l1num, col7, row2, "- -", Color.White);


            TextBox l2num = new TextBox();
            TB(l2num, col7, row3, "- -", Color.White);


            TextBox l3num = new TextBox();
            TB(l3num, col7, row4, "- -", Color.White);


            TextBox l4num = new TextBox();
            TB(l4num, col7, row5, "- -", Color.White);


            TextBox l5num = new TextBox();
            TB(l5num, col7, row6, "- -", Color.White);


            TextBox l6num = new TextBox();
            TB(l6num, col7, row7, "- -", Color.White);


            TextBox l7num = new TextBox();
            TB(l7num, col7, row8, "- -", Color.White);


            TextBox l8num = new TextBox();
            TB(l8num, col7, row9, "- -", Color.White);


            TextBox l9num = new TextBox();
            TB(l9num, col7, row10, "- -", Color.White);


            TextBox l10num = new TextBox();
            TB(l10num, col7, row11, "- -", Color.White);





            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox ( );
            //TB (divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }


        #endregion

        private void VU2uhfPresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion


            if (VU2UHFpre1Chan.Trim('<', ' ') == currentVU2chan)
            {
                VU2UHFpre1Chan = VU2UHFpre1Chan.Replace('<', '*');
                VU2UHFpre2Chan = VU2UHFpre2Chan.Replace('*', '<');
                VU2UHFpre3Chan = VU2UHFpre3Chan.Replace('*', '<');
                VU2UHFpre4Chan = VU2UHFpre4Chan.Replace('*', '<');
                VU2UHFpre5Chan = VU2UHFpre5Chan.Replace('*', '<');
            }
            if (VU2UHFpre2Chan.Trim('<', ' ') == currentVU2chan)
            {
                VU2UHFpre2Chan = VU2UHFpre2Chan.Replace('<', '*');
                VU2UHFpre1Chan = VU2UHFpre1Chan.Replace('*', '<');
                VU2UHFpre3Chan = VU2UHFpre3Chan.Replace('*', '<');
                VU2UHFpre4Chan = VU2UHFpre4Chan.Replace('*', '<');
                VU2UHFpre5Chan = VU2UHFpre5Chan.Replace('*', '<');
            }
            if (VU2UHFpre3Chan.Trim('<', ' ') == currentVU2chan)
            {
                VU2UHFpre3Chan = VU2UHFpre3Chan.Replace('<', '*');
                VU2UHFpre2Chan = VU2UHFpre2Chan.Replace('*', '<');
                VU2UHFpre1Chan = VU2UHFpre1Chan.Replace('*', '<');
                VU2UHFpre4Chan = VU2UHFpre4Chan.Replace('*', '<');
                VU2UHFpre5Chan = VU2UHFpre5Chan.Replace('*', '<');
            }
            if (VU2UHFpre4Chan.Trim('<', ' ') == currentVU2chan)
            {
                VU2UHFpre4Chan = VU2UHFpre4Chan.Replace('<', '*');
                VU2UHFpre3Chan = VU2UHFpre3Chan.Replace('*', '<');
                VU2UHFpre2Chan = VU2UHFpre2Chan.Replace('*', '<');
                VU2UHFpre1Chan = VU2UHFpre1Chan.Replace('*', '<');
                VU2UHFpre5Chan = VU2UHFpre5Chan.Replace('*', '<');
            }
            if (VU2UHFpre5Chan.Trim('<', ' ') == currentVU2chan)
            {
                VU2UHFpre5Chan = VU2UHFpre5Chan.Replace('<', '*');
                VU2UHFpre4Chan = VU2UHFpre4Chan.Replace('*', '<');
                VU2UHFpre3Chan = VU2UHFpre3Chan.Replace('*', '<');
                VU2UHFpre2Chan = VU2UHFpre2Chan.Replace('*', '<');
                VU2UHFpre1Chan = VU2UHFpre1Chan.Replace('*', '<');

            }





            l1text = VU2UHFpre1Chan;
            l2text = VU2UHFpre2Chan;
            l3text = VU2UHFpre3Chan;
            l4text = VU2UHFpre4Chan;
            l5text = VU2UHFpre5Chan;
            l6text = "";
            r1text = VU2UHFpre1Freq;
            r2text = VU2UHFpre2Freq;
            r3text = VU2UHFpre3Freq;
            r4text = VU2UHFpre4Freq;
            r5text = VU2UHFpre5Freq;
            r6text = "RETURN";


            currentPageTitle = "V/U2 UHF"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, VU2UHFpre1Name, Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, VU2UHFpre1Comsec, Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, VU2UHFpre1Freq, Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, VU2UHFpre2Name, Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, "C2", Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, VU2UHFpre2Freq, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, VU2UHFpre3Name, Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, "P4", Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, VU2UHFpre3Freq, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, VU2UHFpre4Name, Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, "C3", Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, VU2UHFpre4Freq, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, VU2UHFpre5Name, Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, "P1", Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, VU2UHFpre5Freq, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);



            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2vhfFMpresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "< 2";
            l3text = "< 3";
            l4text = "< 4";
            l5text = "< 5";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 VHF-FM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, "AIRSPT", Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, "C1", Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, "60.675", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, "REDNET", Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, "C2", Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, "41.950", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, "TOWER", Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, "P4", Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, "130.100", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, "PACMAN", Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, "C3", Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, "42.025", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, "GRNLDR", Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, "P1", Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, "40.475", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2vhfAMpresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "< 2";
            l3text = "< 3";
            l4text = "< 4";
            l5text = "< 5";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 VHF-AM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, "AIRSPT", Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, "C1", Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, "110.675", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, "REDNET", Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, "C2", Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, "141.950", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, "TOWER", Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, "P4", Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, "128.100", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, "PACMAN", Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, "C3", Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, "109.025", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, "GRNLDR", Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, "P1", Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, "140.475", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2satcomPresetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "[215]";
            l3text = "< 2";
            l4text = "[215]";
            l5text = "< 5";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 SATCOM"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/10");


            TextBox l1t = new TextBox();
            TB(l1t, col14 + 25, row1, "UPLINK");
            TypeLeft(l1t);

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, "AIRSPT", Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, "P2", Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, "317.145", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "CHANNEL");

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, "245.045", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, "TOWER", Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, "C12", Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, "244.000", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "CHANNEL");

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, "245.045", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5callsign = new TextBox ( );
            //TB (l5callsign, col4, row10, "GRNLDR", Color.White);

            //TextBox l5comsec = new TextBox ( );
            //TB (l5comsec, col9, row10, "P1", Color.White);

            //TextBox l5freq = new TextBox ( );
            //TB (l5freq, col15, row10, "40.475", Color.White);

            //TextBox l5 = new TextBox ( );
            //TB (l5, col1, row10, l5text, Color.White);

            ////TextBox l6t = new TextBox();
            ////TB(l6t, col2, row1, "IDENT");

            //TextBox l6 = new TextBox ( );
            //TB (l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 25, row3, "DOWNLINK");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 25, row5, "UPLINK");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 25, row7, "DOWNLINK");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void VU2hopsetsPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "< 1";
            l2text = "< 2";
            l3text = "< 3";
            l4text = "< 4";
            l5text = "< 5";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "V/U2 HOPSETS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/2");

            TextBox l1callsign = new TextBox();
            TB(l1callsign, col4, row2, "AIRSPT", Color.White);

            TextBox l1comsec = new TextBox();
            TB(l1comsec, col9, row2, "C1", Color.White);

            TextBox l1freq = new TextBox();
            TB(l1freq, col15, row2, "60.675", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2callsign = new TextBox();
            TB(l2callsign, col4, row4, "REDNET", Color.White);

            TextBox l2comsec = new TextBox();
            TB(l2comsec, col9, row4, "C2", Color.White);

            TextBox l2freq = new TextBox();
            TB(l2freq, col15, row4, "41.950", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3callsign = new TextBox();
            TB(l3callsign, col4, row6, "TOWER", Color.White);

            TextBox l3comsec = new TextBox();
            TB(l3comsec, col9, row6, "P4", Color.White);

            TextBox l3freq = new TextBox();
            TB(l3freq, col15, row6, "130.100", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4callsign = new TextBox();
            TB(l4callsign, col4, row8, "PACMAN", Color.White);

            TextBox l4comsec = new TextBox();
            TB(l4comsec, col9, row8, "C3", Color.White);

            TextBox l4freq = new TextBox();
            TB(l4freq, col15, row8, "42.025", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5callsign = new TextBox();
            TB(l5callsign, col4, row10, "GRNLDR", Color.White);

            TextBox l5comsec = new TextBox();
            TB(l5comsec, col9, row10, "P1", Color.White);

            TextBox l5freq = new TextBox();
            TB(l5freq, col15, row10, "40.475", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }



        #endregion

        #region VU1 & VU2 Status Pages

        private void VU1StatusPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1text = "ON";
            l2text = ">";
            l3text = myCont.VU1Transmitter;
            l4text = myCont.VU1PowerSupply;
            l5text = "123-4567-890";
            l6text = "< FAULT HIST";
            r1text = "- - - <";
            r2text = "- - <";
            r3text = myCont.VU1Modem;
            r4text = myCont.VU1RT;
            r5text = myCont.VU1Comsec;
            r6text = "RETURN";

            currentPageTitle = "V/U1 STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col12, row0, com1Status, Color.White);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1r = new TextBox();
            TB(l1r, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1OFF = new TextBox();
            TB(l1OFF, l1r.Location.X + l1r.Width, row2, "OFF", Color.White);

            TextBox center = new TextBox();
            TB(center, col7, row1, "1553 BUS");
            CenterMe(center);

            TextBox bus = new TextBox();
            TB(bus, col7, row2, myCont.VU11553, Color.White);
            CenterMe(bus);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "RED PATTERN");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2r = new TextBox();
            TB(l2r, col2, row4, "- - -", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "TRANSMITTER");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l3r = new TextBox ( );
            //TB (l3r, col2, row6, "GO", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "PWR SUPPLY");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l4r = new TextBox ( );
            //TB (l4r, col2, row8, "NGO", Color.Yellow);


            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "VSN");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "FLTS");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "MODEM");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "R/T");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "COMSEC");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion

            myCont.VU1ValueChanged = false;
        }

        private void VU2StatusPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "ON";
            l2text = ">";
            l3text = myCont.VU2Transmitter;
            l4text = myCont.VU2PowerSupply;
            l5text = "123-4567-890";
            l6text = "< FAULT HIST";
            r1text = "- - - <";
            r2text = "- - <";
            r3text = myCont.VU2Modem;
            r4text = myCont.VU2RT;
            r5text = myCont.VU2Comsec;
            r6text = "RETURN";

            currentPageTitle = "V/U2 STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col12, row0, _VU2status, Color.White);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1r = new TextBox();
            TB(l1r, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1OFF = new TextBox();
            TB(l1OFF, l1r.Location.X + l1r.Width, row2, "OFF", Color.White);

            TextBox center = new TextBox();
            TB(center, col7, row1, "1553 BUS");
            CenterMe(center);

            TextBox bus = new TextBox();
            TB(bus, col7, row2, myCont.VU21553, Color.White);
            CenterMe(bus);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "RED PATTERN");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2r = new TextBox();
            TB(l2r, col2, row4, "- - -", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "TRANSMITTER");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l3r = new TextBox ( );
            //TB (l3r, col2, row6, "GO", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "PWR SUPPLY");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l4r = new TextBox ( );
            //TB (l4r, col2, row8, "NGO", Color.Yellow);


            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "VSN");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "FLTS");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "MODEM");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "R/T");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "COMSEC");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

            myCont.VU2ValueChanged = false;

            #endregion
        }

        #endregion

        private void MissionPage()
        {
            CDU7000Page = true;
            currentPageTitle = "mission";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col7, row0, "INDEX");


            TextBox l1 = new TextBox();
            l1text = "< START INIT";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            l2text = "< LOAD SAVE";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            l3text = "< ERASE";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            l4text = "< COM";
            TB(l4, col1, row8, l4text, Color.White);


            TextBox l5 = new TextBox();
            l5text = "< TACAN";
            TB(l5, col1, row10, l5text, Color.White);


            TextBox l6 = new TextBox();
            l6text = "< MSG";
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            r1text = "EGI SA/AS";
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            r2text = "STATUS";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            r3text = " ZEROIZE";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            r4text = " SURV";
            TB(r4, col15, row8, r4text, Color.White);


            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            TB(r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            TB(r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            TB(r4right, col16, row8, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #region Mission Status Pages

        private void MissionStatusPage1()
        {
            CheckStatus();

            CDU7000Page = true;

            #region MyRegion
            l1text = "<";
            l2text = "<";
            l3text = "<";
            l4text = "<";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "SYSTEM STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2 + 10, row1, "IMS");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col2, row2, "GO", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2 + 10, row3, "NAV");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);


            TextBox l2r = new TextBox();
            TB(l2r, col2, row4, _navStatus, Color.White);


            TextBox l3t = new TextBox();
            TB(l3t, col2 + 10, row5, "SURV");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3r = new TextBox();
            TB(l3r, col2, row6, _survStatus, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2 + 10, row7, "COM");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4r = new TextBox();
            TB(l4r, col2, row8, _comStatus, Color.White);
            overallComStatus = l4r.Text;

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region Com Status Page

        private void ComStatusPage1()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1text = "<";
            l2text = "<";
            l3text = "<";
            l4text = "<";
            l5text = "";
            l6text = "< FAULT HIST";
            r1text = "GO";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "COM STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col12, row0, _comStatus, Color.White);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "V/U1");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col2, row2, _VU1status, Color.White);
            com1Status = l1r.Text;

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "V/U2");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2r = new TextBox();
            TB(l2r, col2, row4, _VU2status, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "HF1");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3r = new TextBox();
            TB(l3r, col2, row6, _HF1status, Color.White);

            //TextBox l4t = new TextBox ( );
            //TB (l4t, col2, row7, "COM");

            //TextBox l4 = new TextBox ( );
            //TB (l4, col1, row8, l4text, Color.White);

            //TextBox l4r = new TextBox ( );
            //TB (l4r, col2, row8, "NGO", Color.Yellow);
            //comStatus = l4r.Text;

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row1, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col15, row1, "ICS");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region EGI CONTROL page

        private void EGIcontrolPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = _EgiAlignmentStatus;
            l2text = "GC";
            l3text = _InitiateAlign;
            l4text = "";
            l5text = "";
            l6text = "< RETURN";
            r1text = _AlignMode;
            r2text = _AlignCEP;
            r3text = _AlignTime;
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "EGI CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);


            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "INIT GPS");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "ALN TYPE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2s = new TextBox();
            TB(l2s, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox l2air = new TextBox();
            TB(l2air, l2s.Location.X + l2s.Width, row4, "AIR", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "ALN INIT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "MODE");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "ALN CEP");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "ALN TIME");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");





            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region EGI Maintenance page

        private void EgiMaintenancePage()
        {
            CDU7000Page = true;

            #region MyRegion

            //
            initialX = emptyDigit + emptyDigit + emptyDigit + emptyDigit;
            initialY = emptyDigit + emptyDigit + emptyDigit + emptyDigit;
            initialZ = emptyDigit + emptyDigit + emptyDigit + emptyDigit;
            string dashes = " - - - ";

            l1text = "";

            if (_egiPowerState == "ON")
            {
                #region Updates the textboxes when ENTER is clicked
                if (updatedX == null || updatedX == initialX)
                {
                    l2text = initialX;
                    r2text = "90 IN";
                }
                else
                {
                    l2text = initialX;
                    r2text = updatedX + " IN";
                }


                if (updatedY == null || updatedY == initialY)
                {
                    l3text = initialY;
                    r3text = "213 IN";
                }
                else
                {
                    l3text = initialY;
                    r3text = updatedY + " IN";
                }


                if (updatedZ == null || updatedZ == initialZ)
                {
                    l4text = initialZ;
                    r4text = "76 IN";
                }
                else
                {
                    l4text = initialZ;
                    r4text = updatedZ + " IN";
                }
                #endregion
            }
            else
            {
                l2text = initialX;
                l3text = initialY;
                l4text = initialZ;
                r2text = dashes;
                r3text = dashes;
                r4text = dashes;
            }

            l5text = "> ENTER";
            l6text = "";
            r1text = "";

            r5text = "CANCEL";
            r6text = "RETURN";

            currentPageTitle = "INU LEVER ARMS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "ENTER  -  INU     X -");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox L2R = new TextBox();
            TB(L2R, l2.Location.X + l2.Width, row4, "IN", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "ENTER  -  INU     Y -");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox L3R = new TextBox();
            TB(L3R, l3.Location.X + l3.Width, row6, "IN", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "ENTER  -  INU     Z -");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox L4R = new TextBox();
            TB(L4R, l4.Location.X + l4.Width, row8, "IN", Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "CURRENT");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "CURRENT");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "CURRENT");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, "<", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region EGI SA/AS

        private void EGIsaAsPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "0";
            l2text = "Y-ONLY";
            l3text = "NO KEYS";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "EGI SA/AS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "KEY DAYS");

            TextBox l1 = new TextBox();
            TB(l1, col2 + 20, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "EGI MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2s = new TextBox();
            TB(l2s, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox l2mix = new TextBox();
            TB(l2mix, l2s.Location.X + l2s.Width, row4, "MIX", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "KEY STATUS");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region EGI STATUS Page

        private void EGIstatusPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
            l1text = "ON";
            l2text = myCont.EGIsub;
            l3text = myCont.EGIcaic;
            l4text = "213100-AS1R4";
            l5text = myCont.EGIinu;
            l6text = "< FAULT HIST";
            r1text = "- - - ";
            r2text = myCont.EGIio;
            r3text = myCont.EGIpwr;
            r4text = myCont.EGIproc;
            r5text = myCont.EGIgps;
            r6text = "RETURN";

            currentPageTitle = "EGI STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();




            TB(status, title.Location.X + title.Width, row0, _egiStatus, Color.White);



            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1slash = new TextBox();
            TB(l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1off = new TextBox();
            TB(l1off, l1slash.Location.X + l1slash.Width, row2, "OFF", Color.White);

            TextBox l1c = new TextBox();
            TB(l1c, col7, row1, "1553 BUS");
            CenterMe(l1c);

            TextBox bus = new TextBox();
            TB(bus, col9 - 5, row2, myCont.EGI1553, Color.White);//

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "SUB");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox trm = new TextBox ( );
            //TB (trm, col6, row3, "TRM");

            //TextBox trmGo = new TextBox ( );
            //TB (trmGo, col6, row4, myCont.EGItrm , Color.White);

            TextBox trm = new TextBox();
            TB(trm, col10 + 4, row3, "TRM");
            TypeLeft(trm);


            TextBox ioGo = new TextBox();
            TB(ioGo, col9 - 5, row4, myCont.EGItrm, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "CAIC");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, myCont.EGIcaic, Color.White);

            TextBox tempc = new TextBox();
            TB(tempc, col10 + 4, row5, "IE/TEMPC");
            TypeLeft(tempc);

            TextBox tempGo = new TextBox();
            TB(tempGo, col9 - 5, row6, myCont.EGIieTempc, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "VSN");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox ram = new TextBox ( );
            //TB (ram, col6, row7, "RAM");

            //TextBox ramGo = new TextBox ( );
            //TB (ramGo, col6, row8, myCont.TacanRam, Color.White);

            //TextBox rom = new TextBox ( );
            //TB (rom, col9, row7, "ROM");

            //TextBox romGo = new TextBox ( );
            //TB (romGo, col9, row8, myCont.TacanRom, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "INU");

            TextBox l5l = new TextBox();
            TB(l5l, col1, row10, "<", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, l5l.Location.X + l5l.Width, row10, _egiInuStatus, Color.White);

            //TextBox tun = new TextBox ( );
            //TB (tun, col6, row9, "TUN");

            //TextBox tunGo = new TextBox ( );
            //TB (tunGo, col6, row10, myCont.TacanTun, Color.White);

            //TextBox rcv = new TextBox ( );
            //TB (rcv, col9, row9, "RCV");

            //TextBox rcvGo = new TextBox ( );
            //TB (rcvGo, col9, row10, myCont.TacanRcv, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "I/O");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, myCont.EGIio, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "POWER");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, myCont.EGIpwr, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "PROCESSOR");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, myCont.EGIproc, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "GPS");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, _egiGpsStatus, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox ( );
            //    TB (r4r, col16, row8, ">", Color.White);
            //}

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

            myCont.EGIvalueChanged = false;
            #endregion
        }

        #endregion

        #region EGI GPS STATUS page

        private void EgiGpsStatusPage()
        {
            CDU7000Page = true;
            CheckStatus();

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "EGI GPS STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, title.Location.X + title.Width, row0, _egiGpsStatus, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "BATTERY");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, myCont.EgiGpsBattery, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "RPU");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, myCont.EgiGpsRpu, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "EGR");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, myCont.EgiGpsEgr, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

            myCont.EgiGpsValueChanged = false;

            #endregion

        }

        #endregion

        #region EGI INU STATUS page

        private void EGIINUstatusPage()
        {
            CDU7000Page = true;

            CheckStatus();

            #region MyRegion
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
            r6text = "RETURN";

            currentPageTitle = "EGI INU STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, title.Location.X + title.Width, row0, _egiInuStatus, Color.White);

            //TextBox l1t = new TextBox ( );
            //TB (l1t, col2, row1, "SENS REF");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "SENS REF");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, myCont.EgiInuSensRef, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "R ACCEL");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, myCont.EgiInuRaccel, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "S ACCEL");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, myCont.EgiInuSaccel, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "T ACCEL");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, myCont.EgiInuTaccel, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "U GYRO");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, myCont.EgiInuUgyro, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "V GYRO");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, myCont.EgiInuVgyro, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "W GYRO");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, myCont.EgiInuWgyro, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion

            myCont.EgiInuValueChanged = false;
        }

        #endregion

        #region NAV Status page

        private void NAVstatusPage()
        {
            CheckStatus();

            CDU7000Page = true;

            #region MyRegion
            l1text = "";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "< FAULT HIST";
            r1text = _navStatus;
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "EGI MAINT";
            r6text = "RETURN";

            currentPageTitle = "NAV STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();
            TB(status, title.Location.X + title.Width, row0, _navStatus, Color.White);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "EGI");

            TextBox l1l = new TextBox();
            TB(l1l, col1, row2, "<", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col2, row2, _egiStatus, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TACAN");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, _tcnStatus, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region TACAN Status page

        private void TACANstatusPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "ON";
            l2text = myCont.TacanNVRAM;
            l3text = myCont.TacanMicro;
            l4text = myCont.TacanAudio;
            l5text = myCont.TacanRt;
            l6text = "< FAULT HIST";
            r1text = "- - - ";
            r2text = myCont.TacanSynth;
            r3text = myCont.TacanDpdat;
            r4text = myCont.TacanDpram;
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "TACAN STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();


            if (myCont.TacanNVRAM == "GO" & myCont.TacanMicro == "GO" & myCont.Tacan1553 == "GO" & myCont.TacanAudio == "GO" & myCont.TacanDpdat == "GO" & myCont.TacanDpram == "GO" & myCont.TacanPwr == "GO" & myCont.TacanRam == "GO" & myCont.TacanRcv == "GO" & myCont.TacanRom == "GO" & myCont.TacanRt == "GO" & myCont.TacanSub == "GO" & myCont.TacanSynth == "GO" & myCont.TacanTrm == "GO" & myCont.TacanTun == "GO")
            {
                _tcnStatus = "GO";
            }
            else
            {
                _tcnStatus = "NGO";
            }

            TB(status, title.Location.X + title.Width, row0, _tcnStatus, Color.White);


            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);



            TextBox l1slash = new TextBox();
            TB(l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1off = new TextBox();
            TB(l1off, l1slash.Location.X + l1slash.Width, row2, "OFF", Color.White);

            TextBox l1c = new TextBox();
            TB(l1c, col7, row1, "1553 BUS");
            CenterMe(l1c);

            TextBox bus = new TextBox();
            TB(bus, col9, row2, myCont.Tacan1553, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "NVRAM");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox sub = new TextBox();
            TB(sub, col6, row3, "SUB");

            TextBox subGo = new TextBox();
            TB(subGo, col6, row4, myCont.TacanSub, Color.White);

            TextBox trm = new TextBox();
            TB(trm, col9, row3, "TRM");

            TextBox trmGo = new TextBox();
            TB(trmGo, col9, row4, myCont.TacanTrm, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "MICRO");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox pwr = new TextBox();
            TB(pwr, col9, row5, "PWR");

            TextBox pwrGo = new TextBox();
            TB(pwrGo, col9, row6, myCont.TacanPwr, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "AUDIO");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox ram = new TextBox();
            TB(ram, col6, row7, "RAM");

            TextBox ramGo = new TextBox();
            TB(ramGo, col6, row8, myCont.TacanRam, Color.White);

            TextBox rom = new TextBox();
            TB(rom, col9, row7, "ROM");

            TextBox romGo = new TextBox();
            TB(romGo, col9, row8, myCont.TacanRom, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "RT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox tun = new TextBox();
            TB(tun, col6, row9, "TUN");

            TextBox tunGo = new TextBox();
            TB(tunGo, col6, row10, myCont.TacanTun, Color.White);

            TextBox rcv = new TextBox();
            TB(rcv, col9, row9, "RCV");

            TextBox rcvGo = new TextBox();
            TB(rcvGo, col9, row10, myCont.TacanRcv, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "SYNTH");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "DPDAT");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "DPRAM");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox ( );
            //    TB (r3r, col16, row6, ">", Color.White);
            //}

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox ( );
            //    TB (r4r, col16, row8, ">", Color.White);
            //}

            //if (r5text != "")
            //{
            //    TextBox r5r = new TextBox ( );
            //    TB (r5r, col16, row10, ">", Color.White);
            //}


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

            myCont.TCNvalueChanged = false;
            #endregion
        }

        #endregion

        #region TACAN Control Page

        private void TacanControlPage()
        {
            #region MyRegion
            l1text = "";
            l2text = "";
            l3text = "TR";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "17X";
            r2text = "17X";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "TACAN CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "TACAN MODE");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l3slash1 = new TextBox();
            TB(l3slash1, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox r = new TextBox();
            TB(r, l3slash1.Location.X + l3slash1.Width, row6, "R", Color.White);

            TextBox l3slash2 = new TextBox();
            TB(l3slash2, r.Location.X + r.Width, row6, "/", Color.White);

            TextBox aatr = new TextBox();
            TB(aatr, l3slash2.Location.X + l3slash2.Width, row6, "AATR", Color.White);

            TextBox l3slash3 = new TextBox();
            TB(l3slash3, aatr.Location.X + aatr.Width, row6, "/", Color.White);

            TextBox aar = new TextBox();
            TB(aar, l3slash3.Location.X + l3slash3.Width, row6, "AAR", Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TACAN CHAN");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "STBY CHAN");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed


            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region PowerPage

        private void PowerPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "ON";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "OFF";
            r2text = "OFF";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            Color color1;
            Color color2;
            Color color3;
            Color color4;
            Color color5;
            Color color6;

            if (CDUIFFpower == "OFF")
            {
                color1 = Color.White;
                color2 = Color.Green;
            }
            else
            {
                color1 = Color.Green;
                color2 = Color.White;
            }

            if (CDUVU1power == "OFF")
            {
                color3 = Color.White;
                color4 = Color.Green;
            }
            else
            {
                color3 = Color.Green;
                color4 = Color.White;
            }

            if (CDUVU2power == "OFF")
            {
                color5 = Color.White;
                color6 = Color.Green;
            }
            else
            {
                color5 = Color.Green;
                color6 = Color.White;
            }

            currentPageTitle = "POWER"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "IFF");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, color1);

            TextBox l1slash = new TextBox();
            TB(l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1off = new TextBox();
            TB(l1off, l1slash.Location.X + l1slash.Width, row2, "OFF", color2);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "V/U1");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, color4);

            TextBox r1on = new TextBox();
            TB(r1on, col11 + 10, row2, "ON", color3);

            TextBox r1slash = new TextBox();
            TB(r1slash, r1on.Location.X + r1on.Width, row2, "/", Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "V/U2");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, color6);

            TextBox r2on = new TextBox();
            TB(r2on, col11 + 10, row4, "ON", color5);

            TextBox r2slash = new TextBox();
            TB(r2slash, r2on.Location.X + r2on.Width, row4, "/", Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region Start Init page

        private void StartInitPage()
        {
            CDU7000Page = true;
            string latlon1;
            string latlon2 = LatLonFormat("N51°28.600W000°27.800");

            #region MyRegion
            if (_egiPowerState == "ON")
            {
                latlon1 = LatLonFormat("N51°28.600W000°27.800");
                l1text = latlon1;
                l3text = formattedTime;
                r3text = formattedDate;
            }
            else
            {
                l1text = " - - - ";
                l3text = "13:26:35";
                r3text = "26MAY15";
            }
            l2text = "";

            l4text = actInactToggle;
            l5text = "< EGI CTRL";
            l6text = "";
            r1text = "";
            r2text = "";

            r4text = "";
            r5text = "POWER";
            r6text = "RETURN";

            currentPageTitle = "START INIT"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "EGI PPOS");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "UTC");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1 - 10, row8, l4text, Color.White);

            TextBox l4r = new TextBox();
            TB(l4r, l4.Location.X + l4.Width, row8, latlon2, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "DATE");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "INIT POS");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed


            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region Zeroize page

        private void ZeroizePage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "> ZEROIZE ALL";
            l2text = "> EGI KEYS";
            l3text = "> DATA CARDS";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "COM PRESETS";
            r3text = "COM KEYS";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "ZEROIZE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox ( );
            //TB (page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col14+20, row1, "IDENT");
            //TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, "<", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion



        //Surveillance Pages

        #region Surveillance Status Page

        private void SurvStatusPage()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "<";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "< FAULT HIST";
            r1text = _TCASstatus;
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "SURV STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();
            TB(status, title.Location.X + title.Width, row0, _survStatus, Color.White);

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "IFF");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col2, row2, _IFFstatus, Color.White);



            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row5, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "IDENT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TCAS");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col14+20, row3, "IDENT");
            //TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col14+20, row5, "IDENT");
            //TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col14+20, row7, "IDENT");
            //TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col14+20, row9, "PILOT", Color.White);
            //TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion

        #region IFF Pages

        private void IFFcontrolPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1tText = "MASTER";
            l2tText = "MODE 1";
            l3tText = "MODE 2";
            l4tText = "MODE 3A";
            l5tText = "ALT REPORT";
            l6tText = "MODE S";
            r1tText = "EMERGENCY";
            r2tText = "";
            r3tText = "MODE 4";
            r4tText = "MODE 5";
            r5tText = "ANTENNA";
            r6tText = "";

            l1text = "STBY";
            l2text = "ON";
            l3text = "ON";
            l4text = "ON";
            l5text = "ON";
            l6text = "ON";
            r1text = "OFF";
            r2text = "IDENT";
            r3text = "OFF";
            r4text = "OFF ";
            r5text = "DIV";
            r6text = "RETURN";

            currentPageTitle = "IFF"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox s1 = new TextBox();
            TB(s1, l1.Location.X + l1.Width, l1.Location.Y, "/", Color.White);

            TextBox s2 = new TextBox();
            TB(s2, s1.Location.X + s1.Width, s1.Location.Y, "NORM", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox s3 = new TextBox();
            TB(s3, l2.Location.X + l2.Width, l2.Location.Y, "/", Color.White);

            TextBox s4 = new TextBox();
            TB(s4, s3.Location.X + s3.Width, s3.Location.Y, "OFF", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox s5 = new TextBox();
            TB(s5, l3.Location.X + l3.Width, l3.Location.Y, "/", Color.White);

            TextBox s6 = new TextBox();
            TB(s6, s5.Location.X + s5.Width, s5.Location.Y, "OFF", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox s7 = new TextBox();
            TB(s7, l4.Location.X + l4.Width, l4.Location.Y, "/", Color.White);

            TextBox s8 = new TextBox();
            TB(s8, s7.Location.X + s7.Width, s7.Location.Y, "OFF", Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.Green);

            TextBox s9 = new TextBox();
            TB(s9, l5.Location.X + l5.Width, l5.Location.Y, "/", Color.White);

            TextBox s10 = new TextBox();
            TB(s10, s9.Location.X + s9.Width, s9.Location.Y, "OFF", Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.Green);

            TextBox s11 = new TextBox();
            TB(s11, l6.Location.X + l6.Width, l6.Location.Y, "/", Color.White);

            TextBox s12 = new TextBox();
            TB(s12, s11.Location.X + s11.Width, s11.Location.Y, "OFF", Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.Green);

            TextBox t1 = new TextBox();
            TB(t1, col11 + 10, row2, "ON", Color.White);

            TextBox t1s = new TextBox();
            TB(t1s, t1.Location.X + t1.Width, row2, "/", Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, r2tText);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, r3tText);
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.Green);

            TextBox t2 = new TextBox();
            TB(t2, col11 + 10, row6, "ON", Color.White);

            TextBox t2s = new TextBox();
            TB(t2s, t2.Location.X + t2.Width, row6, "/", Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, r4tText);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col14 - 8, row8, r4text, Color.Green);

            TextBox t4 = new TextBox();
            TB(t4, col9 + 15, row8, "L1", Color.White);

            TextBox t4s = new TextBox();
            TB(t4s, t4.Location.X + t4.Width, row8, "/", Color.White);

            TextBox t5 = new TextBox();
            TB(t5, t4s.Location.X + t4s.Width, row8, "L2", Color.White);

            TextBox t5s = new TextBox();
            TB(t5s, t5.Location.X + t5.Width, row8, "/", Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, r5tText);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.Green);

            TextBox t6 = new TextBox();
            TB(t6, col8 + 8, row10, "TOP", Color.White);

            TextBox t6s = new TextBox();
            TB(t6s, t6.Location.X + t6.Width, row10, "/", Color.White);

            TextBox t7 = new TextBox();
            TB(t7, t6s.Location.X + t6s.Width, row10, "BOT", Color.White);

            TextBox t7s = new TextBox();
            TB(t7s, t7.Location.X + t7.Width, row10, "/", Color.White);

            TextBox r6t = new TextBox();
            TB(r6t, col14 + 20, row11, r6tText);
            TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox m1code = new TextBox();
            TB(m1code, col6, row4, "[" + mode1code + "]", Color.White);

            TextBox m2code = new TextBox();
            TB(m2code, col6, row6, "[" + mode2code + "]", Color.White);

            TextBox m3code = new TextBox();
            TB(m3code, col6, row8, "[" + mode3code + "]", Color.White);





            #region Add Arrows if Needed
            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, "<", Color.White);
            }

            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void IFFcontrolPage2()
        {
            CDU7000Page = true;

            #region MyRegion
            l1tText = "M4 AUDIO";
            l2tText = "M4 / 5 RPY LT";
            l3tText = "M4 / 5 TOD";
            l4tText = "M4 CODE";
            l5tText = "";
            l6tText = "";
            r1tText = "M5 PIN";
            r2tText = "M5 NTL ORG";
            r3tText = "";
            r4tText = "M5 L2 SQTR";
            r5tText = "REMOTE - IDENT";
            r6tText = "";

            l1text = "ON";
            l2text = "ON";
            l3text = "MAN";
            l4text = "A";
            l5text = "";
            l6text = "> M4 / 5 RAD TST";
            r1text = m5pin;
            r2text = ntlOrg;
            r3text = "";
            r4text = "OFF";
            r5text = "OFF";
            r6text = "RETURN";

            currentPageTitle = "IFF"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle + " MODE 4/5");

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox s1 = new TextBox();
            TB(s1, l1.Location.X + l1.Width, l1.Location.Y, "/", Color.White);

            TextBox s2 = new TextBox();
            TB(s2, s1.Location.X + s1.Width, s1.Location.Y, "OFF", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox s3 = new TextBox();
            TB(s3, l2.Location.X + l2.Width, l2.Location.Y, "/", Color.White);

            TextBox s4 = new TextBox();
            TB(s4, s3.Location.X + s3.Width, s3.Location.Y, "OFF", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox s5 = new TextBox();
            TB(s5, l3.Location.X + l3.Width, l3.Location.Y, "/", Color.White);

            TextBox s6 = new TextBox();
            TB(s6, s5.Location.X + s5.Width, s5.Location.Y, "AUTO", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox s7 = new TextBox();
            TB(s7, l4.Location.X + l4.Width, l4.Location.Y, "/", Color.White);

            TextBox s8 = new TextBox();
            TB(s8, s7.Location.X + s7.Width, s7.Location.Y, "B", Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            //TextBox l5 = new TextBox ( );
            //TB (l5, col1, row10, l5text, Color.Green);

            //TextBox s9 = new TextBox ( );
            //TB (s9, l5.Location.X + l5.Width, l5.Location.Y, "/", Color.White);

            //TextBox s10 = new TextBox ( );
            //TB (s10, s9.Location.X + s9.Width, s9.Location.Y, "OFF", Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox s11 = new TextBox ( );
            //TB (s11, l6.Location.X + l6.Width, l6.Location.Y, "/", Color.White);

            //TextBox s12 = new TextBox ( );
            //TB (s12, s11.Location.X + s11.Width, s11.Location.Y, "OFF", Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, "[" + r1text + "]", Color.White);

            //TextBox t1 = new TextBox ( );
            //TB (t1, col11 + 10, row2, "ON", Color.White);

            //TextBox t1s = new TextBox ( );
            //TB (t1s, t1.Location.X + t1.Width, row2, "/", Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, r2tText);
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, "[" + r2text + "]", Color.White);

            //TextBox r3t = new TextBox ( );
            //TB (r3t, col14 + 20, row5, r3tText);
            //TypeLeft (r3t);

            //TextBox r3 = new TextBox ( );
            //TB (r3, col15, row6, r3text, Color.Green);

            //TextBox t2 = new TextBox ( );
            //TB (t2, col11 + 10, row6, "ON", Color.White);

            //TextBox t2s = new TextBox ( );
            //TB (t2s, t2.Location.X + t2.Width, row6, "/", Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, r4tText);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.Green);

            //TextBox t4 = new TextBox ( );
            //TB (t4, col9 + 15, row8, "L1", Color.White);

            //TextBox t4s = new TextBox ( );
            //TB (t4s, t4.Location.X + t4.Width, row8, "/", Color.White);

            TextBox t5 = new TextBox();
            TB(t5, col11, row8, "ON", Color.White);

            TextBox t5s = new TextBox();
            TB(t5s, t5.Location.X + t5.Width, row8, "/", Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, r5tText);
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.Green);

            //TextBox t6 = new TextBox ( );
            //TB (t6, col8 + 8, row10, "TOP", Color.White);

            //TextBox t6s = new TextBox ( );
            //TB (t6s, t6.Location.X + t6.Width, row10, "/", Color.White);

            TextBox t7 = new TextBox();
            TB(t7, col11, row10, "ON", Color.White);

            TextBox t7s = new TextBox();
            TB(t7s, t7.Location.X + t7.Width, row10, "/", Color.White);

            TextBox r6t = new TextBox();
            TB(r6t, col14 + 20, row11, r6tText);
            TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox m1code = new TextBox ( );
            //TB (m1code, col6, row4, "[" + mode1code + "]", Color.White);

            //TextBox m2code = new TextBox ( );
            //TB (m2code, col6, row6, "[" + mode2code + "]", Color.White);

            //TextBox m3code = new TextBox ( );
            //TB (m3code, col6, row8, "[" + mode3code + "]", Color.White);





            #region Add Arrows if Needed
            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, "<", Color.White);
            //}

            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void IFFcontrolPage3()
        {
            CDU7000Page = true;

            #region MyRegion
            l1tText = "";
            l2tText = "ADDRESS";
            l3tText = "ADDRESS FMT";
            l4tText = "FLIGHT ID";
            l5tText = "MODE S LEVEL";
            l6tText = "";
            r1tText = "TCAS MODE";
            r2tText = "";
            r3tText = "ENVELOPE";
            r4tText = "";
            r5tText = "";
            r6tText = "";

            l1text = "";
            l2text = "[01234567]";
            l3text = "OCT";
            l4text = "[ABCD1234]";
            l5text = "EHS";
            l6text = "";
            r1text = "TA+RA";
            r2text = "";
            r3text = "NORM";
            r4text = "";
            r5text = "OFF";
            r6text = "RETURN";

            currentPageTitle = "IFF"; //page title and number used for navigating
            currentPageNumber = 3;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "MODE S / TCAS");

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, l1tText);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, l2tText);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);


            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, l3tText);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox s5 = new TextBox();
            TB(s5, l3.Location.X + l3.Width, l3.Location.Y, "/", Color.White);

            TextBox s6 = new TextBox();
            TB(s6, s5.Location.X + s5.Width, s5.Location.Y, "HEX", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, l4tText);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, l5tText);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.Green);

            TextBox s9 = new TextBox();
            TB(s9, l5.Location.X + l5.Width, l5.Location.Y, "/", Color.White);

            TextBox s10 = new TextBox();
            TB(s10, s9.Location.X + s9.Width, s9.Location.Y, "ELS", Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, l6tText);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox s11 = new TextBox ( );
            //TB (s11, l6.Location.X + l6.Width, l6.Location.Y, "/", Color.White);

            //TextBox s12 = new TextBox ( );
            //TB (s12, s11.Location.X + s11.Width, s11.Location.Y, "OFF", Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, r1tText);
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox t1 = new TextBox();
            TB(t1, col7 + 5, row2, "STBY", Color.White);

            TextBox t1s = new TextBox();
            TB(t1s, t1.Location.X + t1.Width, row2, "/", Color.White);

            TextBox t1B = new TextBox();
            TB(t1B, t1s.Location.X + t1s.Width, row2, "TA", Color.White);

            TextBox t1sB = new TextBox();
            TB(t1sB, t1B.Location.X + t1B.Width, row2, "/", Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, r2tText);
            TypeLeft(r2t);

            //TextBox r2 = new TextBox ( );
            //TB (r2, col15, row4, "[" + r2text + "]", Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, r3tText);
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.Green);

            TextBox t2 = new TextBox();
            TB(t2, col7, row6, "ABV", Color.White);

            TextBox t2s = new TextBox();
            TB(t2s, t2.Location.X + t2.Width, row6, "/", Color.White);

            TextBox t2B = new TextBox();
            TB(t2B, t2s.Location.X + t2s.Width, row6, "BLW", Color.White);

            TextBox t2sB = new TextBox();
            TB(t2sB, t2B.Location.X + t2B.Width, row6, "/", Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, r4tText);
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.Green);

            //TextBox t4 = new TextBox ( );
            //TB (t4, col9 + 15, row8, "L1", Color.White);

            //TextBox t4s = new TextBox ( );
            //TB (t4s, t4.Location.X + t4.Width, row8, "/", Color.White);

            //TextBox t5 = new TextBox ( );
            //TB (t5, col11, row8, "ON", Color.White);

            //TextBox t5s = new TextBox ( );
            //TB (t5s, t5.Location.X + t5.Width, row8, "/", Color.White);

            //TextBox r5t = new TextBox ( );
            //TB (r5t, col14 + 20, row9, r5tText);
            //TypeLeft (r5t);

            //TextBox r5 = new TextBox ( );
            //TB (r5, col15, row10, r5text, Color.Green);

            //TextBox t6 = new TextBox ( );
            //TB (t6, col8 + 8, row10, "TOP", Color.White);

            //TextBox t6s = new TextBox ( );
            //TB (t6s, t6.Location.X + t6.Width, row10, "/", Color.White);

            //TextBox t7 = new TextBox ( );
            //TB (t7, col11+10, row8, "ON", Color.White);

            //TextBox t7s = new TextBox ( );
            //TB (t7s, t7.Location.X + t7.Width, row8, "/", Color.White);

            TextBox r6t = new TextBox();
            TB(r6t, col14 + 20, row11, r6tText);
            TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox m1code = new TextBox ( );
            //TB (m1code, col6, row4, "[" + mode1code + "]", Color.White);

            //TextBox m2code = new TextBox ( );
            //TB (m2code, col6, row6, "[" + mode2code + "]", Color.White);

            //TextBox m3code = new TextBox ( );
            //TB (m3code, col6, row8, "[" + mode3code + "]", Color.White);





            #region Add Arrows if Needed
            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox ( );
            //    TB (r2r, col16, row4, "<", Color.White);
            //}

            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void IFFstatusPage1()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "ON";
            l1centerText = "NGO-A";
            l2text = "GO";
            l3text = "GO";
            l4text = "GO";
            l5text = "GO";
            l5centerText = formattedTime;
            l6text = "GO";
            l6centerText = "GO";
            r1text = "- - -";
            r2text = "34268723";
            r3text = "GO";
            r4text = "NGO";
            r5text = "GO";
            r6text = "RETURN";

            currentPageTitle = "IFF STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();
            TB(status, title.Location.X + title.Width, row0, _IFFstatus, Color.White);

            TextBox page = new TextBox();
            TB(page, status.Location.X + status.Width + 20, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ALERT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, switchColor1);

            TextBox l1slash1 = new TextBox();
            TB(l1slash1, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox r = new TextBox();
            TB(r, l1slash1.Location.X + l1slash1.Width, row2, "OFF", switchColor2);

            TextBox l1ct = new TextBox();
            TB(l1ct, col7, row1, "1553 BUS");
            CenterMe(l1ct);

            TextBox l1center = new TextBox();
            TB(l1center, col7, row2, l1centerText, Color.White);
            CenterMe(l1center);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "ANT");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "MODE 1");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "MODE 2");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "MODE 3A");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5ct = new TextBox();
            TB(l5ct, col7, row9, "TOD");
            CenterMe(l5ct);

            TextBox l5center = new TextBox();
            TB(l5center, col7, row10, l5centerText, Color.White);
            CenterMe(l5center);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, "MODE 5");


            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6ct = new TextBox();
            TB(l6ct, col7, row11, "TOD STAT");
            CenterMe(l6ct);

            TextBox l6center = new TextBox();
            TB(l6center, col7, row12, l6centerText, Color.White);
            CenterMe(l6center);


            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "TEST");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "XP SW VSN");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "MODE C");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "MODE 4");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "MODE S");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, "<", Color.White);
            }




            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void IFFstatusPage2()
        {
            CDU7000Page = true;

            #region MyRegion
            l1text = "13453 HR";
            l1centerText = "GO";
            l2text = "GO";
            l2centerText = "GO";
            l3text = "GO";
            l3centerText = "[ 01 / 13 ]";
            l4text = "NGO";
            l4centerText = "NONE";
            l5text = "GO";
            l5centerText = "BOTH";
            l6text = "< FAULT HIST";
            l6centerText = "GO";
            r1text = "OK";
            r2text = "[ N / Y ]";
            r3text = "GO";
            r4text = "NGO";
            r5text = "GO";
            r6text = "RETURN";

            currentPageTitle = "IFF STATUS"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox status = new TextBox();
            TB(status, title.Location.X + title.Width, row0, _IFFstatus, Color.White);

            TextBox page = new TextBox();
            TB(page, status.Location.X + status.Width + 20, row0, currentPageNumber + "/2");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "ETI");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1ct = new TextBox();
            TB(l1ct, col7, row1, "XP");
            CenterMe(l1ct);

            TextBox l1center = new TextBox();
            TB(l1center, col7, row2, l1centerText, Color.White);
            CenterMe(l1center);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "PWR SPLY");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "ALTM");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "UP ANT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "LO ANT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5ct = new TextBox();
            TB(l5ct, col7, row9, "M 4 / 5 RPLY");
            CenterMe(l5ct);

            TextBox l5center = new TextBox();
            TB(l5center, col7, row10, l5centerText, Color.White);
            CenterMe(l5center);

            TextBox l2ct = new TextBox();
            TB(l2ct, col7, row3, "RT");
            CenterMe(l2ct);

            TextBox l2center = new TextBox();
            TB(l2center, col7, row4, l2centerText, Color.White);
            CenterMe(l2center);

            TextBox l3ct = new TextBox();
            TB(l3ct, col7, row5, "M 4 / 5 KEYS");
            CenterMe(l3ct);

            TextBox l3center = new TextBox();
            TB(l3center, col7, row6, l3centerText, Color.White);
            CenterMe(l3center);

            TextBox l4ct = new TextBox();
            TB(l4ct, col7, row7, "M 4 / 5 CAUT");
            CenterMe(l4ct);

            TextBox l4center = new TextBox();
            TB(l4center, col7, row8, l4centerText, Color.White);
            CenterMe(l4center);


            TextBox r1t = new TextBox();
            TB(r1t, col14 + 20, row1, "BATT");
            TypeLeft(r1t);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col14 + 20, row3, "AEK / KEK");
            TypeLeft(r2t);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col14 + 20, row5, "SBC");
            TypeLeft(r3t);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col14 + 20, row7, "ECM");
            TypeLeft(r4t);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col14 + 20, row9, "SP");
            TypeLeft(r5t);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col14+20, row11, "IDENT");
            //TypeLeft(r6t);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            #region Add Arrows if Needed

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #endregion


        #endregion CDU7000

        #region CDU3000pages

        #region A pages
        private void ActiveLegsPage1()
        {
            l1text = "KICT";
            l2text = "ICT";
            l3text = "MUGER";
            l4text = "WUKOL";
            l5text = "WUKUS";
            r1text = "INHIBIT";
            r2text = "- - - / - - - - -";
            r3text = "- - - / - - - - -";
            r4text = "- - - / - - - - -";
            r5text = "- - - / - - - - -";
            r6text = "LEG WIND";

            currentPageTitle = "leg";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col2, row0, "ACT LEGS");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/6");

            TextBox sequence = new TextBox();
            TB(sequence, col11, row1, "SEQUENCE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text);

            TextBox l1B = new TextBox();
            TB(l1B, col2, row3, "309" + (char)176, Color.Green);

            TextBox l1Bdistance = new TextBox();
            TB(l1Bdistance, col5, row3, "12NM", Color.Green);
            l1Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2b = new TextBox();
            TB(l2b, col2, row5, "307" + (char)176, Color.White);

            TextBox l2Bdistance = new TextBox();
            TB(l2Bdistance, col5, row5, "9.2NM", Color.White);
            l2Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "307" + (char)176, Color.White);

            TextBox l3Bdistance = new TextBox();
            TB(l3Bdistance, col5, row7, "3.3NM", Color.White);
            l3Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "307" + (char)176, Color.White);

            TextBox l4Bdistance = new TextBox();
            TB(l4Bdistance, col5, row9, "0.5NM", Color.White);
            l4Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);


            TextBox r1left = new TextBox();
            TB(r1left, col8 + 20, row2, "AUTO", Color.Green);
            r1left.TextAlign = HorizontalAlignment.Right;

            TextBox slash = new TextBox();
            TB(slash, r1left.Location.X + r1left.Width + 10, row2, "/", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.DeepPink);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.DeepPink);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.DeepPink);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.DeepPink);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");


        }

        private void ArrivalDataPage1()
        {
            #region MyRegion
            l1text = "ILS 09L";
            l2text = "660 FT";
            l3text = "090T";
            l4text = "";
            l5text = "";
            l6text = "< INDEX";
            r1text = "YES";
            r2text = "110.50";
            r3text = "3.0°";
            r4text = "";
            r5text = "";
            r6text = "ARRIVAL";

            currentPageTitle = "ACT KAIR ARRIVAL DATA"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);


            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "APPROACH");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "RWY ELEV");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox L3t = new TextBox();
            TB(L3t, col2, row5, "LOC BRG");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col12 - 10, row1, "WGS-84");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2t = new TextBox();
            TB(r2t, col13 - 10, row3, "FREQ");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3t = new TextBox();
            TB(r3t, col11 - 5, row5, "GS ANGLE");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            //if (r2text != "")
            //{
            //    TextBox r2r = new TextBox();
            //    TB(r2r, col16, row4, ">", Color.White);
            //}

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox();
            //    TB(r3r, col16, row6, ">", Color.White);
            //}

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }
        #endregion

        private void CirclePage1()
        {
            #region MyRegion
            l1text = emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit; ;
            l2text = emptyDigit + emptyDigit + emptyDigit + "° /L TURN";
            l3text = "";
            l4text = "4.0 NM";
            l5text = "";
            l6text = "< FPLN INSERT";
            r1text = "ORIGIN";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "RESET";
            r6text = "SEARCH";

            currentPageTitle = "CIRCLE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "FIX");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "REF CRS / DIR");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);


            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "RADIUS");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col11 + 10, row1, "FIX TYPE");

            TextBox center = new TextBox();
            TB(center, col7 + 25, row2, "CENTER", Color.Green);

            TextBox slash = new TextBox();
            TB(slash, center.Location.X + center.Width, row2, "/", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);


            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox();
            //    TB(r4r, col16, row8, ">", Color.White);
            //}

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region D pages
        private void DataBasePage1()
        {
            l1text = emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit;
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "< INDEX";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "WPT LIST";
            r6text = "DEFINE WPT";

            currentPageTitle = "DATA BASE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - -");



            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void DbDiskOps()
        {
            #region MyRegion
            l1text = "";
            l2text = "";
            l3text = "";
            l4text = "< READ DISK";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "WRITE RTES";
            r5text = "WRITE WPTS";
            r6text = "INDEX";

            currentPageTitle = "DATA BASE DISK OPS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, "INSERT DISKETTE", Color.White);
            CenterMe(l1);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "INTO DISK DRIVE", Color.White);
            CenterMe(l2t);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row5, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region Defaults pages
        private void DefaultsPage1()
        {
            #region MyRegion
            l1text = "8430";
            l2text = "170";
            l3text = "200";
            l4text = "";
            l5text = "";
            l6text = "40";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "DEFAULTS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1t = new TextBox();
            TB(l1t, col1, row1, "BOW");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1r = new TextBox();
            TB(l1r, col4, row2, "LB", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col1, row3, "AVG PASS WT");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2r = new TextBox();
            TB(l2r, col4, row4, "LB", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col1, row5, "RESERVE FUEL");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3r = new TextBox();
            TB(l3r, col4, row6, "LB", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col1, row11, "MAX MAP SYMB");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void DefaultsPage2()
        {
            #region MyRegion
            l1text = "290/.70";
            l2text = "300/.74";
            l3text = ".70/290";
            l4text = "3.0°";
            l5text = "250/10000";
            l6text = "FL180";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "DEFAULTS"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "CLIMB SPEED");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "CRUISE SPEED");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "DESCENT SPEED");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "DESCENT ANGLE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col2, row9, "SPD/ALT LIMIT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, "FL/TRANS ALT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void DefaultsPage3()
        {
            #region MyRegion
            l1text = "YES";
            l2text = "YES";
            l3text = "4000";
            l4text = "YES";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "DEFAULTS"; //page title and number used for navigating
            currentPageNumber = 3;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "DME USAGE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1slash = new TextBox();
            TB(l1slash, col4 - 25, row2, "/", Color.White);

            TextBox l1No = new TextBox();
            TB(l1No, col5 - 35, row2, "NO", Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "VOR USAGE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2slash = new TextBox();
            TB(l2slash, col4 - 25, row4, "/", Color.White);

            TextBox l2No = new TextBox();
            TB(l2No, col5 - 35, row4, "NO", Color.Green);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "NEAREST APTS MIN RWY");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3r = new TextBox();
            TB(l3r, col4, row6, "FT", Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "FLIGHT LOG ON LDG");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox l4slash = new TextBox();
            TB(l4slash, col4 - 25, row8, "/", Color.White);

            TextBox l4No = new TextBox();
            TB(l4No, col5 - 35, row8, "NO", Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "SPD/ALT LIMIT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "FL/TRANS ALT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void DefaultsPage4()
        {
            #region MyRegion
            l1text = "15.0°";
            l2text = "ON";
            l3text = "UNCOMP";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "DEFAULTS"; //page title and number used for navigating
            currentPageNumber = 4;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/4");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "REDUCED HALF BANK");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "TEMP COMP");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2slash = new TextBox();
            TB(l2slash, col3, row4, "/", Color.White);

            TextBox l2Off = new TextBox();
            TB(l2Off, col4, row4, "OFF", Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "DSPL TMP@ FINAL VPA");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3slash = new TextBox();
            TB(l3slash, l3.Location.X + l3.Width, row6, "/", Color.White);

            TextBox comp = new TextBox();
            TB(comp, l3slash.Location.X + l3slash.Width, row6, "COMP", Color.Green);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row7, "DESCENT ANGLE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            //TextBox l5t = new TextBox();
            //TB(l5t, col2, row9, "SPD/ALT LIMIT");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row11, "FL/TRANS ALT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }
        #endregion

        private void DefineWaypoint()
        {
            #region MyRegion
            l1text = "THAAT";
            l2text = "";
            l3text = "N23°13.28";
            l4text = "PDQ270.0/66.6";
            l5text = "- - - - -  - - - . - / - - - - -  - - - . -";
            l6text = "< STORE WPT";
            r1text = "";
            r2text = "";
            r3text = "W088°35.32";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "DEFINE PILOT WPT"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col1, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            //TextBox l2 = new TextBox();
            //TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col1, row5, "LATITUDE");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col1, row7, "PLACE BRG / DIST");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col1, row9, "PLACE BRG  /PLACE BRG");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox R3t = new TextBox();
            TB(R3t, col11, row5, "LONGITUDE");

            TextBox r3 = new TextBox();
            TB(r3, col11, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            //if (r3text != "")
            //{
            //    TextBox r3r = new TextBox();
            //    TB(r3r, col16, row6, ">", Color.White);
            //}

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void DirPage1()
        {
            l3text = "<(6935)";
            l4text = "<(6935)";
            l5text = "<KIRLE";


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
            TB(l2b, col2, row5, "250" + (char)176);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "215" + (char)176);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "R322" + (char)176);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void DiskRouteList()
        {
            l1text = "";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "< READ DISK";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "ROUTE MENU";

            currentPageTitle = "DISK ROUTE LIST"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "LOAD PLAN", Color.White);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col12, row1, "DATE", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);


            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }
        #endregion

        private void ExpSquarePage1()
        {
            #region MyRegion
            l1text = emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit; ;
            l2text = emptyDigit + emptyDigit + emptyDigit + "° /L TURN";
            l3text = "";
            l4text = "30.0 NM";
            l5text = "";
            l6text = "< FPLN INSERT";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "5.0 NM";
            r5text = "RESET";
            r6text = "SEARCH";

            currentPageTitle = "EXP SQUARE"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "FIX");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "REF CRS / DIR");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);


            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "LENGTH");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);


            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col9, row7, "TRACK SPACE");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox();
            //    TB(r4r, col16, row8, ">", Color.White);
            //}

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region F pages
        private void FixPage1()
        {
            l1text = "SGF";
            l2text = "002°";
            l3text = "63.3";
            l4text = "< ABEAM REF";
            l5text = "ABEAM REF";
            r2text = "- - - ° - - . - -";
            r3text = "- - - - ° - - . - -";

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
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "RAD CROSS");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "DIS CROSS");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);
            CenterMe(l5);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "LAT CROSS");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "LON CROSS");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox crs = new TextBox();
            TB(crs, col1, row11, "CRS");

            TextBox crsData = new TextBox();
            TB(crsData, col1, row12, "     ", Color.White);

            TextBox dist = new TextBox();
            TB(dist, col5, row11, "DIST");

            TextBox distData = new TextBox();
            TB(distData, col4 + 10, row12, "95.4NM", Color.White);

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
            l1text = "<KIRLE";
            l2text = "<KIRLE";
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

            currentPageTitle = "FMS CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox subtitle = new TextBox();
            TB(subtitle, col1, row1, "DISPLAY MODE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1slash = new TextBox();
            TB(l1slash, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1TRUE = new TextBox();
            TB(l1TRUE, l1slash.Location.X + l1slash.Width, row2, "TRUE", Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "FMS COORD MODE");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2slash = new TextBox();
            TB(l2slash, l2.Location.X + l2.Width, row4, "/", Color.White);

            TextBox l2INDEP = new TextBox();
            TB(l2INDEP, l2slash.Location.X + l2slash.Width, row4, "INDEP", Color.Green);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void FPLNpage1()
        {
            l1text = "KICT";
            r1text = "KDEN";
            l2text = "PLANT2";
            r2text = "KAPA";
            l4text = "DIRECT";
            r4text = "ICT";
            l5text = "<COPY ACTIVE";
            l6text = "<SEC FPLN";
            r6text = "PERF INIT";

            currentPageTitle = "flightplan";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col2, row0, "ACT FPLN");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/4");

            TextBox origin = new TextBox();
            TB(origin, col2, row1, "ORIGIN");

            TextBox dist = new TextBox();
            TB(dist, col7, row1, "DIST");
            dist.TextAlign = HorizontalAlignment.Right;

            TextBox dest = new TextBox();
            TB(dest, col13, row1, "DEST");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox nm = new TextBox();
            TB(nm, col8, row2, "452", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox route = new TextBox();
            TB(route, col2, row3, "ROUTE");

            TextBox altn = new TextBox();
            TB(altn, col13, row3, "ALTN");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r2b = new TextBox();
            TB(r2b, col11, row5, "ORIG RWY");

            TextBox via = new TextBox();
            TB(via, col2, row7, "VIA");

            TextBox to = new TextBox();
            TB(to, col14, row7, "TO");
            to.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.Green);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.Green);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void FrequencyDataPage1()
        {
            l1text = "KCID";
            l2text = "133.25";
            l3text = "121.900";
            l4text = "134.000";
            l5text = "< MULTIPLE";
            l6text = "< INDEX";
            r1text = "";
            r2text = "MULTIPLE";
            r3text = "160.00";
            r6text = "";
            r4text = "10120.00";
            r5text = "110.155";


            currentPageTitle = "FREQUENCY DATA"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/1");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, "SEL APT");

            TextBox l1 = new TextBox();

            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1slash1 = new TextBox();
            TB(l1slash1, l1.Location.X + l1.Width, row2, "/", Color.White);

            TextBox l1Loc2 = new TextBox();
            TB(l1Loc2, l1slash1.Location.X + l1slash1.Width, row2, "KMSP", Color.Green);

            TextBox l1slash2 = new TextBox();
            TB(l1slash2, l1Loc2.Location.X + l1Loc2.Width, row2, "/", Color.White);

            TextBox l1Loc3 = new TextBox();
            TB(l1Loc3, l1slash2.Location.X + l1slash2.Width, row2, "KORD", Color.White);

            TextBox l1slash3 = new TextBox();
            TB(l1slash3, l1Loc3.Location.X + l1Loc3.Width, row2, "/", Color.White);

            TextBox l1Loc4 = new TextBox();
            TB(l1Loc4, l1slash3.Location.X + l1slash3.Width, row2, "KDFW", Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "ATIS");

            TextBox l2 = new TextBox();

            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "AWAS");

            TextBox l3 = new TextBox();

            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, "GND");

            TextBox l4 = new TextBox();

            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "TCA");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "AIRLIFT CP");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r2right = new TextBox();
            TB(r2right, col16, row4, ">", Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "RDR");

            TextBox r3 = new TextBox();

            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4title = new TextBox();
            TB(r4title, col15, row7, "GPS");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5title = new TextBox();
            TB(r5title, col15, row9, "RFSS");

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }
        #endregion

        #region GNSS pages
        private void GNSScontrolPage()
        {
            l1text = "<ENABLED> GNSS1";
            l2text = "<ENABLED> GNSS2";
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

            currentPageTitle = "GNSS CTL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "FMS1 GNSS CONTROL");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r2right = new TextBox();
            TB(r2right, col16, row4, ">", Color.White);

            TextBox r5title = new TextBox();
            TB(r5title, col15, row9, "3 / 3 ENABLED", Color.Green);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r5right = new TextBox();
            TB(r5right, col16, row10, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void GNSS1statusPage1()
        {



            l1text = "N38°10.14 W097°01.29";
            l2text = "081° / 331 KT";
            l3text = "NO";
            l4text = "SBAS PA";
            l5text = "081° / 00.05 NM";
            l6text = "< INDEX";
            r1text = "";
            r2text = "13400 FT";
            r3text = "13300 FT";
            r4text = "8";
            r5text = "";
            r6text = "GNSS CTL";

            currentPageTitle = "GNSS1 STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "GNSS1 STATUS");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, "GNSS1 POS");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "TRK / SPD");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "SAT FAULT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, "MODE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "FMS1 POS DIFF");

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "GNSS HEIGHT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "GNSS ALT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4title = new TextBox();
            TB(r4title, col15, row7, "SATELLITES");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void GNSS1statusPage2()
        {
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

            currentPageTitle = "GNSS1 STATUS"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, "2/2");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, "HAL");

            TextBox l1 = new TextBox();
            l1text = "7409 M / 4.00 NM";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "HPL");

            TextBox l2 = new TextBox();
            l2text = "18 M";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "HFOM");

            TextBox l3 = new TextBox();
            l3text = "6 M";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, "HUL");

            TextBox l4 = new TextBox();
            l4text = "12 M";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "SERVICE IN USE");

            TextBox l5 = new TextBox();
            l5text = "WASS     EGNOS";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1title = new TextBox();
            TB(r1title, col15, row1, "APPR VAL");

            TextBox r1 = new TextBox();
            r1text = "N / A";
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "VPL");

            TextBox r2 = new TextBox();
            r2text = "30 M";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "VFOM");

            TextBox r3 = new TextBox();
            r3text = "12 M";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4title = new TextBox();
            TB(r4title, col15, row7, "GNSS UNITS");

            TextBox r4meters = new TextBox();
            TB(r4meters, col8 + 10, row8, "METERS", Color.Green);

            TextBox r4slash = new TextBox();
            TB(r4slash, r4meters.Location.X + r4meters.Width, row8, "/", Color.White);

            TextBox r4feet = new TextBox();
            TB(r4feet, col15, row8, "FEET", Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void GNSS2statusPage1()
        {
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

            currentPageTitle = "GNSS2 STATUS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "GNSS2 STATUS");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, "GNSS2 POS");

            TextBox l1 = new TextBox();
            l1text = "N38°10.14 W097°01.29";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "TRK / SPD");

            TextBox l2 = new TextBox();
            l2text = "081° / 331 KT";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "SAT FAULT");

            TextBox l3 = new TextBox();
            l3text = "NO";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, "MODE");

            TextBox l4 = new TextBox();
            l4text = "SBAS PA";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "FMS1 POS DIFF");

            TextBox l5 = new TextBox();
            l5text = "081° / 00.05 NM";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "GNSS HEIGHT");

            TextBox r2 = new TextBox();
            r2text = "13400 FT";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "GNSS ALT");

            TextBox r3 = new TextBox();
            r3text = "13300 FT";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4title = new TextBox();
            TB(r4title, col15, row7, "SATELLITES");

            TextBox r4 = new TextBox();
            r4text = "8";
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void GNSS2statusPage2()
        {
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

            currentPageTitle = "GNSS2 STATUS"; //page title and number used for navigating
            currentPageNumber = 2;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, "2/2");

            TextBox l1title = new TextBox();
            TB(l1title, col1, row1, "HAL");

            TextBox l1 = new TextBox();
            l1text = "7409 M / 4.00 NM";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "HPL");

            TextBox l2 = new TextBox();
            l2text = "18 M";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "HFOM");

            TextBox l3 = new TextBox();
            l3text = "6 M";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, "HUL");

            TextBox l4 = new TextBox();
            l4text = "12 M";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "SERVICE IN USE");

            TextBox l5 = new TextBox();
            l5text = "WASS     EGNOS";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1title = new TextBox();
            TB(r1title, col15, row1, "APPR VAL");

            TextBox r1 = new TextBox();
            r1text = "N / A";
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "VPL");

            TextBox r2 = new TextBox();
            r2text = "30 M";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3title = new TextBox();
            TB(r3title, col15, row5, "VFOM");

            TextBox r3 = new TextBox();
            r3text = "12 M";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4title = new TextBox();
            TB(r4title, col15, row7, "GNSS UNITS");

            TextBox r4meters = new TextBox();
            TB(r4meters, col8 + 10, row8, "METERS", Color.Green);

            TextBox r4slash = new TextBox();
            TB(r4slash, r4meters.Location.X + r4meters.Width, row8, "/", Color.White);

            TextBox r4feet = new TextBox();
            TB(r4feet, col15, row8, "FEET", Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }
        #endregion

        private void HoldPage1()
        {
            l1text = "PEABO";
            l2text = "BUM";
            l3text = "TRAKE";
            l4text = "KAYLA";
            l5text = "FTZ";
            r1text = "AUTO";
            r2text = "- - - / FL290";
            r3text = "- - - / FL200";
            r4text = "- - - / 12000";
            r5text = "- - - /  9000";
            r6text = "LEG WIND";

            currentPageTitle = "hold";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col2, row0, "ACT LEGS");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/4");

            TextBox sequence = new TextBox();
            TB(sequence, col11, row1, "SEQUENCE");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text);

            TextBox l1B = new TextBox();
            TB(l1B, col2, row3, "079" + (char)176, Color.Green);

            TextBox l1Bdistance = new TextBox();
            TB(l1Bdistance, col5, row3, "115NM", Color.Green);
            l1Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l2b = new TextBox();
            TB(l2b, col2, row5, "077" + (char)176, Color.White);

            TextBox l2Bdistance = new TextBox();
            TB(l2Bdistance, col5, row5, "131NM", Color.White);
            l2Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "089" + (char)176, Color.White);

            TextBox l3Bdistance = new TextBox();
            TB(l3Bdistance, col5, row7, "25.2NM", Color.White);
            l3Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "085" + (char)176, Color.White);

            TextBox l4Bdistance = new TextBox();
            TB(l4Bdistance, col5, row9, "11.2NM", Color.White);
            l4Bdistance.TextAlign = HorizontalAlignment.Right;

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col9, row2, r1text, Color.Green);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            TB(r1right, col12, row2, "/INHIBIT", Color.White);


            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.DeepPink);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.DeepPink);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.DeepPink);

            TextBox r4Degree = new TextBox();
            TB(r4Degree, col11, row7, "3.0°", Color.DeepPink);

            TextBox r5 = new TextBox();
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
            l1text = "< MCDU MENU";
            l2text = "< STATUS";
            l3text = "< POS INIT";
            l4text = "< IRS CTL";
            l5text = "< VORDME CTL";
            l6text = "< GNSS CTL";
            r1text = "GNSS1 POS";
            r2text = "FREQUENCY";
            r3text = "FIX";
            r4text = "HOLD";
            r5text = "PROG";
            r6text = "SEC FPLN";


            currentPageTitle = "index";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/3");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "FMS1", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col2, row11, "FMS1", Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);
            r3.TextAlign = HorizontalAlignment.Right;

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);
            r4.TextAlign = HorizontalAlignment.Right;

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);
            r5.TextAlign = HorizontalAlignment.Right;

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);
            r6.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            TB(r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            TB(r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            TB(r4right, col16, row8, ">", Color.White);

            TextBox r5right = new TextBox();
            TB(r5right, col16, row10, ">", Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");

        }

        private void IdxPage2()
        {
            l1text = "< FMS CTL";
            l2text = "";
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


            currentPageTitle = "index";
            currentPageNumber = 2;

            TextBox title = new TextBox();
            TB(title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            TB(page, col14, row0, "2/3");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);
            r3.TextAlign = HorizontalAlignment.Right;

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);
            r4.TextAlign = HorizontalAlignment.Right;

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);
            r5.TextAlign = HorizontalAlignment.Right;

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);
            r6.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);

            TextBox r2right = new TextBox();
            TB(r2right, col16, row4, ">", Color.White);

            TextBox r3right = new TextBox();
            TB(r3right, col16, row6, ">", Color.White);

            TextBox r4right = new TextBox();
            TB(r4right, col16, row8, ">", Color.White);

            TextBox r5right = new TextBox();
            TB(r5right, col16, row10, ">", Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void IdxPage3()
        {
            l1text = "";
            l2text = "";
            l3text = "";
            l4text = "";
            l5text = "";
            l6text = "";
            r1text = "MARK POINTS";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "index";
            currentPageNumber = 3;

            TextBox title = new TextBox();
            TB(title, col7, row0, "INDEX");

            TextBox page = new TextBox();
            TB(page, col14, row0, "3/3");


            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);
            r1.TextAlign = HorizontalAlignment.Right;

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);
            r2.TextAlign = HorizontalAlignment.Right;

            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #endregion

        private void IRSctlPage()
        {
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

            currentPageTitle = "FMS1 IRS CONTROL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "FMS1 IRS CONTROL");

            TextBox l2 = new TextBox();
            l2text = "IRS  <ENABLED>";
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "POS DIFF");

            TextBox r2 = new TextBox();
            r2text = "- - -° / - . -";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox drift = new TextBox();
            TB(drift, col7, row5, "DRIFT");

            TextBox driftData = new TextBox();
            TB(driftData, col10, row5, " - . - ", Color.White);

            TextBox NMperHR = new TextBox();
            TB(NMperHR, col15, row5, "NM / HR", Color.White);

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void LadderPage1()
        {
            #region MyRegion
            l1text = emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit; ;
            l2text = emptyDigit + emptyDigit + emptyDigit + "° /L TURN";
            l3text = "30.0 NM";
            l4text = "50.0 NM";
            l5text = "";
            l6text = "< FPLN INSERT";
            r1text = "ORIGIN";
            r2text = "";
            r3text = "";
            r4text = "5.0 NM";
            r5text = "RESET";
            r6text = "SEARCH";

            currentPageTitle = "LADDER"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "FIX");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "REF CRS / DIR");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "WIDTH");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "LENGTH");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col11 + 10, row1, "FIX TYPE");

            TextBox center = new TextBox();
            TB(center, col7 + 25, row2, "CENTER", Color.Green);

            TextBox slash = new TextBox();
            TB(slash, center.Location.X + center.Width, row2, "/", Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col9, row7, "TRACK SPACE");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox();
            //    TB(r4r, col16, row8, ">", Color.White);
            //}

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void MarkPointsPage1()
        {
            #region MyRegion
            l1text = "- - - - - - - - -";
            l2tText = "13 : 23  16JUN15       FL290 FT";
            l2text = "N38°46.5  W090°20.4";
            l3text = "";
            l4text = "FRACA/120";
            l5tText = "12 : 28  16AUG15       FL290 FT";
            l5text = "N37°56.5  W096°22.8";
            l6text = "< MARK";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "RETURN";

            currentPageTitle = "MARK POINTS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/2");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col1, row3, l2tText, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            //TextBox l3t = new TextBox();
            //TB(l3t, col2, row1, "IDENT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            //TextBox l4t = new TextBox();
            //TB(l4t, col2, row1, "IDENT");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5t = new TextBox();
            TB(l5t, col1, row9, l5tText, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            //TextBox l6t = new TextBox();
            //TB(l6t, col2, row1, "IDENT");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            //TextBox r1t = new TextBox();
            //TB(r1t, col2, row1, "IDENT");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            //TextBox r2t = new TextBox();
            //TB(r2t, col2, row1, "IDENT");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            //TextBox r3t = new TextBox();
            //TB(r3t, col2, row1, "IDENT");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            //TextBox r4t = new TextBox();
            //TB(r4t, col2, row1, "IDENT");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            //TextBox r6t = new TextBox();
            //TB(r6t, col2, row1, "IDENT");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void MCDU()
        {

            l1text = "< FMS 1";
            l2text = "";
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

            currentPageTitle = "mcdu";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col6, row0, "MCDU MENU");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r1right = new TextBox();
            TB(r1right, col16, row2, ">", Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void NonPrecisionApprRaimPage()
        {
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

            currentPageTitle = "NON PRECISION"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox subtitle = new TextBox();
            TB(subtitle, col1, row1, "APPROACH RAIM");
            CenterMe(subtitle);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, "DEST");

            TextBox l2titleCenter = new TextBox();
            TB(l2titleCenter, col3, row3, "NPA RAIM");
            CenterMe(l2titleCenter);

            TextBox l2center = new TextBox();
            TB(l2center, col3, row4, "AVAILABLE", Color.White);
            CenterMe(l2center);

            TextBox l2 = new TextBox();
            l2text = "KORD";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, "SATELLITE DESELECT");
            CenterMe(l3title);

            TextBox l3 = new TextBox();
            l3text = "1    5   10  13  24";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col15, row3, "ETA");

            TextBox r2 = new TextBox();
            r2text = "07:05";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #region P pages
        private void PilotRouteList()
        {
            l1text = "< KCID : KMKC";
            l2text = "< KICT : KSTL";
            l3text = "< KCLT : KBNA";
            l4text = "";
            l5text = "< SEC FPLN";
            l6text = "< - - - - - - - - -";
            r1text = "KIAH : KGPT";
            r2text = "";
            r3text = "";
            r4text = "FROM XSIDE";
            r5text = "ROUTE MENU";
            r6text = "- - - - - - - - -";

            currentPageTitle = "PILOT ROUTE LIST"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "LOAD PLAN");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox r1t = new TextBox();
            TB(r1t, col15, row1, "LOAD PLAN");

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r1r = new TextBox();
            TB(r1r, col16, row2, ">", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col15, row7, "RTE TRANSFER", Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r4r = new TextBox();
            TB(r4r, col16, row8, ">", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r5r = new TextBox();
            TB(r5r, col16, row10, ">", Color.White);

            TextBox r6t = new TextBox();
            TB(r6t, col15, row11, "SEC STORE");

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6r = new TextBox();
            TB(r6r, col16, row12, ">", Color.White);


            TextBox l4b = new TextBox();
            TB(l4b, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6t = new TextBox();
            TB(l6t, col2, row11, "ACT STORE");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void PilotWaypointList()
        {
            #region MyRegion
            l1text = "ITAUT";
            l2text = "ITAWA";
            l3text = "PUDDY";
            l4text = "THAAT";
            l5text = "";
            l6text = "< DATA BASE";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "FROM XSIDE";
            r6text = "DEFINE WPT";

            currentPageTitle = "PILOT WPT LIST"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox page = new TextBox();
            TB(page, col14, row0, currentPageNumber + "/3");

            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r5t = new TextBox();
            TB(r5t, col15, row9, "WPT TRANSFER", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        #region  PosInit Pages

        private void PosInitPage1()
        {

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

            currentPageTitle = "posinit";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col7, row0, "POS INIT");

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox l1Title = new TextBox();
            TB(l1Title, col2, row1, "FMS POS");

            TextBox l1 = new TextBox();
            l1text = "N00°00.00 E000°00.00";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2Title = new TextBox();
            TB(l2Title, col2, row3, "AIRPORT");

            TextBox l2 = new TextBox();
            l2text = "KNEL";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3Title = new TextBox();
            TB(l3Title, col2, row5, "PILOT/ WPT");

            TextBox l3 = new TextBox();
            l3text = "- - - - -";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox r2 = new TextBox();
            r2text = "N40°02.0 W074°21.2";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r5Title = new TextBox();
            TB(r5Title, col8, row9, "SET POS");

            TextBox r5 = new TextBox();
            r5text = emptyLatLong;
            TB(r5, col15, row10, r5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            r6text = "FPLN";
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6 = new TextBox();
            l6text = "< INDEX";
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }


        private void PosInitPage2()
        {
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

            currentPageTitle = "posinit";
            currentPageNumber = 2;

            TextBox title = new TextBox();
            TB(title, col7, row0, "POS INIT");

            TextBox page = new TextBox();
            TB(page, col14, row0, "2/2");

            TextBox l1Title = new TextBox();
            TB(l1Title, col2, row1, "FMS POS");

            TextBox l1 = new TextBox();
            l1text = "N38°15.59 W094°52.82";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2Title = new TextBox();
            TB(l2Title, col2, row3, "GNSS1");

            TextBox l2 = new TextBox();
            l2text = "N38°15.58 W094°52.87";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3Title = new TextBox();
            TB(l3Title, col2, row5, "GNSS2");

            TextBox l3 = new TextBox();
            l3text = "N38°15.57 W094°52.84";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col2, row9, "UPDATE FROM", Color.White);

            TextBox l5 = new TextBox();
            l5text = "< NAVAID";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox r1title = new TextBox();
            TB(r1title, col15, row1, "GS");

            TextBox r1 = new TextBox();
            r1text = "406";
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            r2text = "406";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            r3text = "406";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r5Title = new TextBox();
            TB(r5Title, col15, row9, "NAVAID");

            TextBox r5 = new TextBox();
            r5text = "BUM";
            TB(r5, col15, row10, r5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox r6 = new TextBox();
            r6text = "FPLN";
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l6 = new TextBox();
            l6text = "< INDEX";
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #endregion

        private void ProgressPage1()
        {
            l1text = "PEABO";
            l2text = "BUM";
            l3text = "TRAKE";
            l4text = "KSTL";
            l5text = "KBLV";

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
            TB(l1, col1, row2, l1text);

            TextBox l2title = new TextBox();
            TB(l2title, col1, row3, " TO");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l3title = new TextBox();
            TB(l3title, col1, row5, " NEXT");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col1, row7, " DEST");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, " ALTN");

            TextBox l5 = new TextBox();
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
            TB(l3dist, col5, row6, "214", Color.White);

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
            TB(l2fuel, col15, row4, "1710", Color.Green);

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
        #endregion

        private void RoutePage1()
        {
            l1text = "< PILOT ROUTE LIST";
            l2text = "< DISK ROUTE LIST";
            l3text = "< FPLN RECALL";
            l4text = "< FPLN WIND";
            l5text = "";
            l6text = "< SEC FPLN";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "ROUTE MENU"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);


            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        #region S pages

        private void SBASpage()
        {
            l1text = "WASS   <ENABLED>";
            l2text = "EGNOS <ENABLED>";
            l3text = "MSAS   <ENABLED>";
            l4text = "";
            l5text = "";
            l6text = "< INDEX";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "GNSS CTL";

            currentPageTitle = "SBAS"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            TextBox subtitle = new TextBox();
            TB(subtitle, col1, row1, "SERVICE PROVIDERS");
            CenterMe(subtitle);

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.Green);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void SearchPage1()
        {
            #region MyRegion
            l1text = "< LADDER";
            l2text = "< EXP SQUARE";
            l3text = "< SECTOR";
            l4text = "< CIRCLE";
            l5text = "";
            l6text = "< INDEX";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "";
            r5text = "";
            r6text = "";

            currentPageTitle = "SEARCH"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);


            //TextBox l1t = new TextBox();
            //TB(l1t, col2, row1, "IDENT");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            //TextBox l2t = new TextBox();
            //TB(l2t, col2, row3, "LOCATION");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            //TextBox divider = new TextBox();
            //TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            if (r1text != "")
            {
                TextBox r1r = new TextBox();
                TB(r1r, col16, row2, ">", Color.White);
            }

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            if (r4text != "")
            {
                TextBox r4r = new TextBox();
                TB(r4r, col16, row8, ">", Color.White);
            }

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void SECFPLNpage1()
        {
            l1text = "KSTL";
            l2text = "LINDYHOP";
            l4text = "CARDS6.CAP";
            l5text = "< ROUTE MENU";
            l6text = "< SEC LEGS";
            r1text = "KCID";
            r2text = "KDVN";
            r3text = "RW12R";
            r5text = "ACTIVATE";




            currentPageTitle = "SEC FPLN"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col2, row0, currentPageTitle + " " + l2text);

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox origin = new TextBox();
            TB(origin, col2, row1, "ORIGIN");

            TextBox dist = new TextBox();
            TB(dist, col8, row1, "DIST");

            TextBox l1dist = new TextBox();
            TB(l1dist, col8, row2, "249", Color.White);

            TextBox dest = new TextBox();
            TB(dest, col15, row1, "DEST");


            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2title = new TextBox();
            TB(l2title, col2, row3, "ROUTE");

            TextBox l2 = new TextBox();

            TB(l2, col1, row4, l2text, Color.White);

            TextBox l4title = new TextBox();
            TB(l4title, col2, row7, "VIA");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, l1text, Color.White);

            TextBox altn = new TextBox();
            TB(altn, col15, row3, "ALTN");

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, l2text, Color.White);

            TextBox origRwy = new TextBox();
            TB(origRwy, col15, row5, "ORIG RWY");

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, l3text, Color.White);

            TextBox to = new TextBox();
            TB(to, col15, row7, "TO");

            TextBox r4 = new TextBox();
            r4text = "CAP";
            TB(r4, col15, row8, r4text, Color.Green);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r5right = new TextBox();
            TB(r5right, col16, row10, ">", Color.White);


            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void SectorPage1()
        {
            #region MyRegion
            l1text = emptyDigit + emptyDigit + emptyDigit + emptyDigit + emptyDigit; ;
            l2text = emptyDigit + emptyDigit + emptyDigit + "° /L TURN";
            l3text = "10.0 NM";
            l4text = "60°";
            l5text = "";
            l6text = "< FPLN INSERT";
            r1text = "";
            r2text = "";
            r3text = "";
            r4text = "10.0 NM";
            r5text = "RESET";
            r6text = "SEARCH";

            currentPageTitle = "SECTOR"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, currentPageTitle);

            //TextBox page = new TextBox();
            //TB(page, col14, row0, currentPageNumber + "/1");

            TextBox l1t = new TextBox();
            TB(l1t, col2, row1, "FIX");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2t = new TextBox();
            TB(l2t, col2, row3, "REF CRS / DIR");

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l3t = new TextBox();
            TB(l3t, col2, row5, "RADIUS");

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4t = new TextBox();
            TB(l4t, col2, row7, "SECT ANGLE");

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);


            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4t = new TextBox();
            TB(r4t, col9, row7, "TRACK SPACE");

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);

            //TextBox r5t = new TextBox();
            //TB(r5t, col15, row9, "PILOT", Color.White);

            TextBox r5 = new TextBox();
            TB(r5, col15, row10, r5text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);

            TextBox divider = new TextBox();
            TB(divider, col1, row9, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");



            #region Add Arrows if Needed
            //if (r1text != "")
            //{
            //    TextBox r1r = new TextBox();
            //    TB(r1r, col16, row2, ">", Color.White);
            //}

            if (r2text != "")
            {
                TextBox r2r = new TextBox();
                TB(r2r, col16, row4, ">", Color.White);
            }

            if (r3text != "")
            {
                TextBox r3r = new TextBox();
                TB(r3r, col16, row6, ">", Color.White);
            }

            //if (r4text != "")
            //{
            //    TextBox r4r = new TextBox();
            //    TB(r4r, col16, row8, ">", Color.White);
            //}

            if (r5text != "")
            {
                TextBox r5r = new TextBox();
                TB(r5r, col16, row10, ">", Color.White);
            }


            if (r6text != "")
            {
                TextBox r6r = new TextBox();
                TB(r6r, col16, row12, ">", Color.White);
            }
            #endregion

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
            #endregion
        }

        private void StatusPage()
        {

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

            currentPageTitle = "status"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "STATUS");

            TextBox navData = new TextBox();
            TB(navData, col2, row1, "NAV DATA");

            TextBox l1 = new TextBox();
            l1text = "WORLD";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l1b = new TextBox();
            TB(l1b, col2, row3, "ACTIVE DATA BASE");

            TextBox l2 = new TextBox();
            l2text = "09JAN15 05FEB15";
            TB(l2, col1, row4, l2text, Color.Yellow);

            TextBox l2b = new TextBox();
            TB(l2b, col2, row5, "SEC DATA BASE");

            TextBox l3 = new TextBox();
            l3text = "06SEP15 03OCT15";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "UTC");

            TextBox l4 = new TextBox();
            l4text = formattedTime;
            TB(l4, col1, row8, l4text, Color.White);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "PROGRAM");

            TextBox l5 = new TextBox();
            l5text = "SCID D 001 CNN107";
            TB(l5, col1, row10, l5text, Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r3b = new TextBox();
            TB(r3b, col13, row7, " DATE");

            TextBox r4 = new TextBox();
            r4text = formattedDate;
            TB(r4, col15, row8, r4text, Color.White);

            TextBox r6 = new TextBox();
            TB(r6, col15, row12, r6text, Color.White);


            TextBox r6right = new TextBox();
            TB(r6right, col16, row12, ">", Color.White);



            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }
        #endregion

        private void TunPage1()
        {
            l1text = "122.875";
            l2text = "134.250";
            l3text = "113.80/ICT";
            l4text = "HOLD";
            l5text = "3144";
            l6text = "412.5";
            r1text = "121.700";
            r2text = "123.875";
            r3text = "110.30";
            r4text = " HOLD";

            currentPageTitle = "tune";
            currentPageNumber = 1;

            TextBox title = new TextBox();
            TB(title, col7, row0, "TUNE");

            TextBox com1 = new TextBox();
            TB(com1, col2, row1, "COM1", Color.White);

            TextBox com2 = new TextBox();
            TB(com2, col13, row1, "COM2", Color.White);

            TextBox page = new TextBox();
            TB(page, col14, row0, "1/2");

            TextBox l1 = new TextBox();
            TB(l1, col1, row2, l1text, Color.Green);

            TextBox l1b = new TextBox();
            TB(l1b, col2, row3, "RECALL", Color.White);

            TextBox l2 = new TextBox();
            TB(l2, col1, row4, l2text, Color.White);

            TextBox l2b = new TextBox();
            TB(l2b, col2, row5, "NAV1", Color.White);

            TextBox l3 = new TextBox();
            TB(l3, col1, row6, l3text, Color.Green);

            TextBox l3b = new TextBox();
            TB(l3b, col2, row7, "DME1", Color.White);

            TextBox l4 = new TextBox();
            TB(l4, col1, row8, l4text);

            TextBox l4right = new TextBox();
            TB(l4right, col4, row8, "116.80", Color.Green);

            TextBox l4b = new TextBox();
            TB(l4b, col2, row9, "ATC1", Color.White);

            TextBox l5 = new TextBox();
            TB(l5, col1, row10, l5text, Color.Green);


            TextBox l5b = new TextBox();
            TB(l5b, col2, row11, "ADF", Color.White);

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.Green);

            TextBox r1 = new TextBox();
            TB(r1, col15, row2, r1text, Color.Green);
            //r1.TextAlign = HorizontalAlignment.Left;


            TextBox r1b = new TextBox();
            TB(r1b, col12, row3, "RECALL", Color.White);

            TextBox r2 = new TextBox();
            TB(r2, col15, row4, r2text, Color.White);
            //r2.TextAlign = HorizontalAlignment.Left;

            TextBox r2b = new TextBox();
            TB(r2b, col10, row5, "MK-HI");

            TextBox r2bright = new TextBox();
            TB(r2bright, col13, row5, " NAV2", Color.White);

            TextBox r3 = new TextBox();
            TB(r3, col15, row6, r3text, Color.Green);
            //r3.TextAlign = HorizontalAlignment.Right;

            TextBox r3b = new TextBox();
            TB(r3b, col13, row7, " DME2", Color.White);

            TextBox r4 = new TextBox();
            TB(r4, col15, row8, r4text, Color.White);
            //r4.TextAlign = HorizontalAlignment.Right;


            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");

            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }

        private void VorDmeCtlPage()
        {
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

            currentPageTitle = "VORDME CTL"; //page title and number used for navigating
            currentPageNumber = 1;

            TextBox title = new TextBox();//displayed top center of screen
            TB(title, col7, row0, "FMS1 VOR/DME CONTROL");

            TextBox l1 = new TextBox();
            l1text = "IOW";
            TB(l1, col1, row2, l1text, Color.White);

            TextBox l2 = new TextBox();
            l2text = "- - -";
            TB(l2, col1, row4, l2text, Color.White);

            TextBox r2title = new TextBox();
            TB(r2title, col1, row3, "NAVAID INHIBIT");
            CenterMe(r2title);

            TextBox l3 = new TextBox();
            l3text = "- - -";
            TB(l3, col1, row6, l3text, Color.White);

            TextBox l4 = new TextBox();
            l4text = "- - -";
            TB(l4, col1, row8, l4text, Color.White);

            TextBox r1 = new TextBox();
            r1text = "- - -";
            TB(r1, col15, row2, r1text, Color.White);

            TextBox r2 = new TextBox();
            r2text = "- - -";
            TB(r2, col15, row4, r2text, Color.White);

            TextBox r3 = new TextBox();
            r3text = "- - -";
            TB(r3, col15, row6, r3text, Color.White);

            TextBox r4 = new TextBox();
            r4text = "- - -";
            TB(r4, col15, row8, r4text, Color.White);

            TextBox l5title = new TextBox();
            TB(l5title, col1, row9, "VOR - USAGE");

            TextBox r5title = new TextBox();
            TB(r5title, col15, row9, "DME - USAGE");

            TextBox l5YES = new TextBox();
            TB(l5YES, col1, row10, "YES", Color.White);

            TextBox l5slash = new TextBox();
            TB(l5slash, col1 + l5YES.Width, row10, "/", Color.White);

            TextBox l5NO = new TextBox();
            TB(l5NO, col1 + l5YES.Width + l5slash.Width, row10, "NO", Color.Green);

            TextBox r5YES = new TextBox();
            TB(r5YES, col11 + 10, row10, "YES", Color.Green);

            TextBox r5slash = new TextBox();
            TB(r5slash, r5YES.Location.X + r5YES.Width, row10, "/", Color.White);

            TextBox r5NO = new TextBox();
            TB(r5NO, col15, row10, "NO", Color.White);

            TextBox l5b = new TextBox();
            TB(l5b, col1, row11, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            TextBox l6 = new TextBox();
            TB(l6, col1, row12, l6text, Color.White);

            TextBox l6b = new TextBox();
            TB(l6b, col1, row13, "[");


            TextBox r6b = new TextBox();
            TB(r6b, col16, row13, "]");
        }



        #endregion



        #endregion Pages


        //__________________________________________________________________________________________



        #region button events

        #region left and right buttons

        private void l1Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l1";
            PageSelection(l1text);
        }

        private void l2Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l2";
            PageSelection(l2text);
        }

        private void l3Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l3";
            PageSelection(l3text);
        }

        private void l4Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l4";
            PageSelection(l4text);
        }

        private void l5Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l5";
            PageSelection(l5text);
        }

        private void l6Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "l6";
            PageSelection(l6text);
        }



        private void r1Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r1";
            PageSelection(r1text);
        }

        private void r2Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r2";
            PageSelection(r2text);
        }

        private void r3Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r3";
            PageSelection(r3text);
        }

        private void r4Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r4";
            PageSelection(r4text);
        }

        private void r5Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r5";
            PageSelection(r5text);
        }

        private void r6Btn_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "r6";
            PageSelection(r6text);
        }

        #endregion

        #region Fixed Buttons

        private void nextBtn_Click(object sender, EventArgs e)
        {
            #region Defaults pages

            if (currentPageTitle == "DEFAULTS" & currentPageNumber == 1)
            {
                StartFresh();
                DefaultsPage2();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "DEFAULTS" & currentPageNumber == 2)
                {
                    StartFresh();
                    DefaultsPage3();
                    UpdateDisplay();
                }
                else
                    if (currentPageTitle == "DEFAULTS" & currentPageNumber == 3)
                    {
                        StartFresh();
                        DefaultsPage4();
                        UpdateDisplay();
                    }
                    else
                        if (currentPageTitle == "DEFAULTS" & currentPageNumber == 4)
                        {
                            StartFresh();
                            DefaultsPage1();
                            UpdateDisplay();
                        }

            #endregion

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

            #region HF pages
            if (currentPageTitle == "HF1 CONTROL")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    HFcontrolPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        HFcontrolPage3();
                        UpdateDisplay();
                    }
                    else
                        if (currentPageNumber == 3)
                        {
                            StartFresh();
                            HFcontrolPage1();
                            UpdateDisplay();
                        }
            }
            #endregion

            #region HF ALE pages

            if (currentPageTitle == "HF1 ALE FCTN")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    HFALEfunctionPage2();
                    UpdateDisplay();
                }
                else
                {
                    StartFresh();
                    HFALEfunctionPage1();
                    UpdateDisplay();
                }
            }

            #endregion

            #region IFF pages

            if (currentPageTitle == "IFF STATUS")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    IFFstatusPage2();
                    UpdateDisplay();
                }
                else
                {
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        IFFstatusPage1();
                        UpdateDisplay();
                    }
                }
            }
            else
                if (currentPageTitle == "IFF")
                {
                    if (currentPageNumber == 1)
                    {
                        StartFresh();
                        IFFcontrolPage2();
                        UpdateDisplay();
                    }
                    else

                        if (currentPageNumber == 2)
                        {
                            StartFresh();
                            IFFcontrolPage3();
                            UpdateDisplay();
                        }
                        else

                            if (currentPageNumber == 3)
                            {
                                StartFresh();
                                IFFcontrolPage1();
                                UpdateDisplay();
                            }


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

            #region VU1 Control Pages
            if (currentPageTitle == "V/U1 CONTROL")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU1controlPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU1controlPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

            #region VU1 COMSEC States
            if (currentPageTitle == "V/U1 COMSEC STATES")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU1ComsecStatesPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU1ComsecStatesPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

            #region VU2 Control Pages
            if (currentPageTitle == "V/U2 CONTROL")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU2controlPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU2controlPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

            #region VU2 COMSEC States
            if (currentPageTitle == "V/U2 COMSEC STATES")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU2ComsecStatesPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU2ComsecStatesPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            #region Defaults pages

            if (currentPageTitle == "DEFAULTS" & currentPageNumber == 3)
            {
                StartFresh();
                DefaultsPage2();
                UpdateDisplay();
            }
            else
                if (currentPageTitle == "DEFAULTS" & currentPageNumber == 4)
                {
                    StartFresh();
                    DefaultsPage3();
                    UpdateDisplay();
                }
                else
                    if (currentPageTitle == "DEFAULTS" & currentPageNumber == 1)
                    {
                        StartFresh();
                        DefaultsPage4();
                        UpdateDisplay();
                    }
                    else
                        if (currentPageTitle == "DEFAULTS" & currentPageNumber == 2)
                        {
                            StartFresh();
                            DefaultsPage1();
                            UpdateDisplay();
                        }

            #endregion

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

            #region HF pages
            if (currentPageTitle == "HF1 CONTROL")
            {
                if (currentPageNumber == 3)
                {
                    StartFresh();
                    HFcontrolPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 1)
                    {
                        StartFresh();
                        HFcontrolPage3();
                        UpdateDisplay();
                    }
                    else
                        if (currentPageNumber == 2)
                        {
                            StartFresh();
                            HFcontrolPage1();
                            UpdateDisplay();
                        }
            }
            #endregion

            #region HF ALE pages

            if (currentPageTitle == "HF1 ALE FCTN")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    HFALEfunctionPage2();
                    UpdateDisplay();
                }
                else
                {
                    StartFresh();
                    HFALEfunctionPage1();
                    UpdateDisplay();
                }
            }

            #endregion

            #region IFF pages

            if (currentPageTitle == "IFF STATUS")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    IFFstatusPage2();
                    UpdateDisplay();
                }
                else
                {
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        IFFstatusPage1();
                        UpdateDisplay();
                    }
                }
            }
            else
                if (currentPageTitle == "IFF")
                {
                    if (currentPageNumber == 3)
                    {
                        StartFresh();
                        IFFcontrolPage2();
                        UpdateDisplay();
                    }
                    else

                        if (currentPageNumber == 2)
                        {
                            StartFresh();
                            IFFcontrolPage1();
                            UpdateDisplay();
                        }
                        else

                            if (currentPageNumber == 1)
                            {
                                StartFresh();
                                IFFcontrolPage3();
                                UpdateDisplay();
                            }


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

            #region VU1 COMSEC States
            if (currentPageTitle == "V/U1 COMSEC STATES")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU1ComsecStatesPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU1ComsecStatesPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

            #region VU1 Control Pages
            if (currentPageTitle == "V/U1 CONTROL")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU1controlPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU1controlPage1();
                        UpdateDisplay();
                    }
            }
            #endregion

            #region VU2 Control Pages
            if (currentPageTitle == "V/U2 CONTROL")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU2controlPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU2controlPage1();
                        UpdateDisplay();
                    }

            }
            #endregion

            #region VU2 COMSEC States
            if (currentPageTitle == "V/U2 COMSEC STATES")
            {
                if (currentPageNumber == 1)
                {
                    StartFresh();
                    VU2ComsecStatesPage2();
                    UpdateDisplay();
                }
                else
                    if (currentPageNumber == 2)
                    {
                        StartFresh();
                        VU2ComsecStatesPage1();
                        UpdateDisplay();
                    }

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

        private void btnBrt_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "btnBrt";
            if (alpha >= .05)
            {
                alpha = alpha - .05;
            }
            DM.Opacity = alpha;
            //DM.BackColor = Color.FromArgb (alpha, 0, 0, 0);
        }

        private void btnDim_Click(object sender, EventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "btnDim";
            if (alpha <= .80)
            {
                alpha = alpha + .05;
            }
            DM.Opacity = alpha;
            //DM.BackColor = Color.FromArgb (alpha, 0, 0, 0);
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
            btnPressed = "A";
            Scratch("A");
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            btnPressed = "B";
            Scratch("B");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            btnPressed = "C";
            Scratch("C");
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            btnPressed = "D";
            Scratch("D");
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            btnPressed = "E";
            Scratch("E");
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            btnPressed = "F";
            Scratch("F");
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            btnPressed = "G";
            Scratch("G");
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            btnPressed = "H";
            Scratch("H");
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            btnPressed = "I";
            Scratch("I");
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            btnPressed = "J";
            Scratch("J");
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            btnPressed = "K";
            Scratch("K");
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            btnPressed = "L";
            Scratch("L");
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            btnPressed = "M";
            Scratch("M");
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            btnPressed = "N";
            Scratch("N");
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            btnPressed = "O";
            Scratch("O");
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            btnPressed = "P";
            Scratch("P");
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            btnPressed = "Q";
            Scratch("Q");
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            btnPressed = "R";
            Scratch("R");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            btnPressed = "S";
            Scratch("S");
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            btnPressed = "T";
            Scratch("T");
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            btnPressed = "U";
            Scratch("U");
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            btnPressed = "V";
            Scratch("V");
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            btnPressed = "W";
            Scratch("W");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            btnPressed = "X";
            Scratch("X");
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            btnPressed = "Y";
            Scratch("Y");
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            btnPressed = "Z";
            Scratch("Z");
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            btnPressed = "  ";
            Scratch("  ");
        }

        private void btnSlash_Click(object sender, EventArgs e)
        {
            btnPressed = "/";
            Scratch("/");
        }
        #endregion

        #region Numbers
        private void btn1_Click(object sender, EventArgs e)
        {
            btnPressed = "1";
            Scratch("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnPressed = "2";
            Scratch("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btnPressed = "3";
            Scratch("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btnPressed = "4";
            Scratch("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btnPressed = "5";
            Scratch("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btnPressed = "6";
            Scratch("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btnPressed = "7";
            Scratch("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btnPressed = "8";
            Scratch("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btnPressed = "9";
            Scratch("9");
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            btnPressed = "0";
            Scratch("0");
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            btnPressed = ".";
            Scratch(".");
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #endregion

        #endregion


        #region TextBox manipulation

        private int TbWidth(TextBox tb)
        {
            Size size = TextRenderer.MeasureText(tb.Text, tb.Font);
            return size.Width;

        }

        private int CenterMe(TextBox tb)    //centers the text on the screen
        {
            tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth(tb) / 2), tb.Location.Y);
            return tb.Location.X;
        }

        private void JustifyTBs(TextBox tb)
        {
            if (tb.Location.X == col15)
            {
                tb.Location = new Point(tb.Location.X - TbWidth(tb), tb.Location.Y);
                tb.TextAlign = HorizontalAlignment.Right;
            }

            if (tb.Location.X == col17 & tb.Text != ">")
            {
                tb.Location = new Point(tb.Location.X - TbWidth(tb), tb.Location.Y);
                //tb.TextAlign = HorizontalAlignment.Right;
            }

            if (tb.Location.X == col7 & tb.Location.Y == row0)
            {
                CenterMe(tb);//tb.Location = new Point(((backgroundShp.Location.X + backgroundShp.Width) - (backgroundShp.Width / 2)) - (TbWidth( tb) / 2), tb.Location.Y);
            }

        }

        private void TypeLeft(TextBox tb)
        {
            tb.Location = new Point(tb.Location.X - TbWidth(tb), tb.Location.Y);
            tb.TextAlign = HorizontalAlignment.Right;
        }

        private void TB(TextBox myName, int col, int row, string tbText, Color? charColor = null, Color? backgroundColor = null, string fontType = "Arial", int fontSize = 20, FontStyle fstyle = FontStyle.Regular, BorderStyle bstyle = BorderStyle.None)
        {
            myName.Location = new Point(col, row);



            myName.Text = tbText;

            myName.Font = new Font(fontType, fontSize, fstyle);
            myName.Width = TbWidth(myName);
            JustifyTBs(myName);

            if (charColor == null)
            {
                myName.ForeColor = Color.Cyan;
            }
            else
            {
                if (myName.Text == "GO")
                {
                    myName.ForeColor = Color.White;
                }
                else
                    if (myName.Text == "NGO" & (myCont.VU1ValueChanged == true || myCont.VU2ValueChanged == true || myCont.TCNvalueChanged == true || myCont.EGIvalueChanged == true || myCont.EgiInuValueChanged == true || myCont.EgiGpsValueChanged == true || myCont.HF1ValueChanged == true))
                    {
                        myName.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        myName.ForeColor = (Color)charColor;
                    }

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


        #region Select Page

        private void PageSelection(String e) //used to select the proper Page from the input string
        {
            if (e == "")//added for validity check when a button that has no text is pushed
            {
                scratchMessage = "KEY NOT ACTIVE";
                CheckValidity();
            }

            string myTxt = null;
            string trimmedString = TrimSelection(e);   //holds the trimmed version of the passed string argument

            #region Color toggle of Yes/No, Comp/Uncomp, Inhibit, etc (maximum two choices only)

            if ((trimmedString == "OFF" & pushedButton == r4Btn & currentPageTitle == "IFF" & currentPageNumber == 1) || (pushedButton == r4Btn & currentPageTitle == "HF1 CONTROL"))
            {
                //skip the above under this condition
            }
            else
            {
                if (trimmedString == "SILENT" || trimmedString == "OCT" || trimmedString == "EHS" || (trimmedString == "MAN" & hfMode != "ALE") || trimmedString == "A" || (trimmedString == "STBY" & currentPageTitle != "HF1 CONTROL") || trimmedString == "Y-ONLY" || trimmedString == "GC" || trimmedString == "H2" || trimmedString == "OFF" || trimmedString == "PLAIN" || trimmedString == "DATA" || (trimmedString == "TR" & currentPageTitle != "TACAN CONTROL") || trimmedString == "ORIGIN" || trimmedString == "ON" || trimmedString == "UNCOMP" || trimmedString == "YES" || trimmedString == "NO" || trimmedString == "INHIBIT")//**Toggle colors
                {
                    try
                    {
                        for (int i = 0; i < tbCount; i++)//iterates through all  TextBoxes on the form
                        {
                            foreach (Control c in this.Controls)
                            {

                                if (c.GetType() == typeof(TextBox) & (Math.Abs(c.Location.Y - pushedButton.Location.Y) <= 15) & (Math.Abs(c.Location.X - pushedButton.Location.X) <= 200))//finds the textboxes within 15 points Y and 200 points X of the pushed button
                                {
                                    if (c.Text == trimmedString)//determines if the text from the textbox matches the trimmedString var
                                    {


                                        foreach (Control x in this.Controls)
                                        {
                                            if ((x.GetType() == typeof(TextBox)) & (x != c) & (x.Location.Y == c.Location.Y) & (Math.Abs(x.Location.X - c.Location.X) <= 200) & x.Text != "/")
                                            {




                                                if (x.ForeColor == Color.Green)
                                                {
                                                    x.ForeColor = Color.White;
                                                    switchColor2 = Color.White;
                                                }
                                                else
                                                {
                                                    x.ForeColor = Color.Green;
                                                    switchColor2 = Color.Green;
                                                }


                                                if (c.ForeColor == Color.Green)
                                                {
                                                    c.ForeColor = Color.White;
                                                    switchColor1 = Color.White;

                                                    if (currentPageTitle == "POWER")
                                                    {
                                                        if (trimmedString == "ON")//toggles IFF power
                                                        {
                                                            CDUIFFpower = "OFF";
                                                        }
                                                        else
                                                            if (pushedButton == r1Btn)
                                                            {
                                                                CDUVU1power = "ON";
                                                            }
                                                            else
                                                                if (pushedButton == r2Btn)
                                                                {
                                                                    CDUVU2power = "ON";
                                                                }
                                                    }

                                                    if (currentPageTitle == "HF1 CONTROL" & trimmedString == "MAN")
                                                    {
                                                        if (c.ForeColor == Color.Green)
                                                        {
                                                            hfSubMode = c.Text;
                                                        }
                                                        else
                                                            if (x.ForeColor == Color.Green)
                                                            {
                                                                hfSubMode = x.Text;
                                                            }
                                                        StartFresh();
                                                        HFcontrolPage1();

                                                    }
                                                    return;
                                                }
                                                else
                                                {
                                                    c.ForeColor = Color.Green;
                                                    switchColor1 = Color.Green;

                                                    if (currentPageTitle == "POWER")
                                                    {
                                                        if (trimmedString == "ON")//toggles IFF power
                                                        {
                                                            CDUIFFpower = "ON";
                                                        }
                                                        else
                                                            if (pushedButton == r1Btn)
                                                            {
                                                                CDUVU1power = "OFF";
                                                            }
                                                            else
                                                                if (pushedButton == r2Btn)
                                                                {
                                                                    CDUVU2power = "OFF";
                                                                }
                                                    }



                                                    if (currentPageTitle == "HF1 CONTROL" & trimmedString == "MAN")
                                                    {
                                                        if (c.ForeColor == Color.Green)
                                                        {
                                                            hfSubMode = c.Text;
                                                        }
                                                        else
                                                            if (x.ForeColor == Color.Green)
                                                            {
                                                                hfSubMode = x.Text;
                                                            }
                                                        StartFresh();
                                                        HFcontrolPage1();

                                                    }

                                                    return;
                                                }

                                            }
                                        }


                                    }

                                }

                            }
                        }

                    }
                    catch (Exception)
                    {

                    }

                    return;
                }
            }
            #endregion

            #region Color toggle of multiple choices (more than two choices only)

            if ((hfMode == "ALE" & trimmedString == "MAN") || (trimmedString == "2" & currentPageTitle != "V/U1 VHF-FM") || trimmedString == "NORM" || trimmedString == "CW" || trimmedString == "DIV" || (trimmedString == "OFF" & pushedButton == r4Btn & currentPageTitle == "IFF") || trimmedString == "1.2K" || trimmedString == "HIGH" || trimmedString == "UHF" || trimmedString == "0" || trimmedString == "NOR" || (trimmedString == "TR" & currentPageTitle == "TACAN CONTROL") || (currentPageTitle == "HF1 CONTROL" & trimmedString == "STBY"))//**Toggle colors
            {
                try
                {
                    for (int i = 0; i < tbCount; i++)//iterates through all  TextBoxes on the form
                    {
                        foreach (Control c in this.Controls)
                        {

                            if (c.GetType() == typeof(TextBox) & (Math.Abs(c.Location.Y - pushedButton.Location.Y) <= 5) & (Math.Abs(c.Location.X - pushedButton.Location.X) <= 500))//finds the textboxes within 5 points Y of the pushed button
                            {
                                if (c.ForeColor == Color.Green)
                                {
                                    myTxt = c.Text;//stores any text that is GREEN. Will use it in the next section for comparison.


                                    //tricky, find the next textbox that does not contain a slash
                                    foreach (Control y in this.Controls)
                                    {
                                        if (trimmedString == "2") //EXAMPLE: If "2" is next to the button you pressed (ie The selected row)
                                        {
                                            #region 0,1,2
                                            if (myTxt == "0")       //And the GREEN text is part of the selections on that row
                                            {
                                                if (y.Text == "1")  //And the computer selected textbox is the next selection of that row
                                                {
                                                    y.ForeColor = Color.Green;  //Change the colors 
                                                    c.ForeColor = Color.White;
                                                    return;
                                                }
                                            }
                                            else
                                                if (myTxt == "1")
                                                {
                                                    if (y.Text == "2")
                                                    {
                                                        y.ForeColor = Color.Green;
                                                        c.ForeColor = Color.White;
                                                        return;
                                                    }
                                                }
                                                else
                                                    if (myTxt == "2")
                                                    {
                                                        if (y.Text == "0")
                                                        {
                                                            y.ForeColor = Color.Green;
                                                            c.ForeColor = Color.White;
                                                            return;
                                                        }
                                                    }
                                            #endregion
                                        }
                                        else
                                            if (trimmedString == "MAN")
                                            {
                                                #region MAN,PRST,SCAN

                                                if (myTxt == "MAN")
                                                {
                                                    if (y.Text == "PRST")
                                                    {
                                                        y.ForeColor = Color.Green;
                                                        c.ForeColor = Color.White;
                                                        hfSubMode = y.Text;
                                                        StartFresh();
                                                        HFcontrolPage1();
                                                        return;
                                                    }
                                                }
                                                else
                                                    if (myTxt == "PRST")
                                                    {
                                                        if (y.Text == "SCAN")
                                                        {
                                                            y.ForeColor = Color.Green;
                                                            c.ForeColor = Color.White;
                                                            hfSubMode = y.Text;
                                                            StartFresh();
                                                            HFcontrolPage1();
                                                            return;
                                                        }
                                                    }
                                                    else
                                                        if (myTxt == "SCAN")
                                                        {
                                                            if (y.Text == "MAN")
                                                            {
                                                                y.ForeColor = Color.Green;
                                                                c.ForeColor = Color.White;
                                                                hfSubMode = y.Text;
                                                                StartFresh();
                                                                HFcontrolPage1();
                                                                return;
                                                            }
                                                        }

                                                #endregion
                                            }
                                            else
                                                if (trimmedString == "CW")
                                                {
                                                    #region USB,LSB,ISB,AME,CW

                                                    if (myTxt == "USB")
                                                    {
                                                        if (y.Text == "LSB")
                                                        {
                                                            y.ForeColor = Color.Green;
                                                            c.ForeColor = Color.White;
                                                            return;
                                                        }
                                                    }
                                                    else
                                                        if (myTxt == "LSB")
                                                        {
                                                            if (y.Text == "ISB")
                                                            {
                                                                y.ForeColor = Color.Green;
                                                                c.ForeColor = Color.White;
                                                                return;
                                                            }
                                                        }
                                                        else
                                                            if (myTxt == "ISB")
                                                            {
                                                                if (y.Text == "AME")
                                                                {
                                                                    y.ForeColor = Color.Green;
                                                                    c.ForeColor = Color.White;
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                                if (myTxt == "AME")
                                                                {
                                                                    if (y.Text == "CW")
                                                                    {
                                                                        y.ForeColor = Color.Green;
                                                                        c.ForeColor = Color.White;
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                    if (myTxt == "CW")
                                                                    {
                                                                        if (y.Text == "USB")
                                                                        {
                                                                            y.ForeColor = Color.Green;
                                                                            c.ForeColor = Color.White;
                                                                            return;
                                                                        }
                                                                    }

                                                    #endregion
                                                }
                                                else
                                                    if (trimmedString == "STBY")
                                                    {
                                                        #region STBY,BAS,ALE,SEL

                                                        if (myTxt == "STBY")
                                                        {
                                                            if (y.Text == "BAS")
                                                            {
                                                                y.ForeColor = Color.Green;
                                                                hfMode = y.Text;//stores the mode the HF radio is in
                                                                StartFresh();
                                                                HFcontrolPage1();
                                                                return;
                                                            }
                                                        }
                                                        else
                                                            if (myTxt == "BAS")
                                                            {
                                                                if (y.Text == "ALE")
                                                                {
                                                                    y.ForeColor = Color.Green;
                                                                    hfMode = y.Text;//stores the mode the HF radio is in
                                                                    StartFresh();
                                                                    HFcontrolPage1();
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                                if (myTxt == "ALE")
                                                                {
                                                                    if (y.Text == "SEL")
                                                                    {
                                                                        y.ForeColor = Color.Green;
                                                                        hfMode = y.Text;//stores the mode the HF radio is in
                                                                        StartFresh();
                                                                        HFcontrolPage1();
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                    if (myTxt == "SEL")
                                                                    {
                                                                        if (y.Text == "STBY")
                                                                        {
                                                                            y.ForeColor = Color.Green;
                                                                            hfMode = y.Text;//stores the mode the HF radio is in
                                                                            StartFresh();
                                                                            HFcontrolPage1();
                                                                            return;
                                                                        }
                                                                    }


                                                        #endregion
                                                    }
                                                    else
                                                        if (trimmedString == "NORM")
                                                        {
                                                            #region High, Med, and Low
                                                            if (myTxt == "NORM")
                                                            {
                                                                if (y.Text == "ABV")
                                                                {
                                                                    y.ForeColor = Color.Green;
                                                                    c.ForeColor = Color.White;
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                                if (myTxt == "ABV")
                                                                {
                                                                    if (y.Text == "BLW")
                                                                    {
                                                                        y.ForeColor = Color.Green;
                                                                        c.ForeColor = Color.White;
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                    if (myTxt == "BLW")
                                                                    {
                                                                        if (y.Text == "NORM")
                                                                        {
                                                                            y.ForeColor = Color.Green;
                                                                            c.ForeColor = Color.White;
                                                                            return;
                                                                        }
                                                                    }
                                                            #endregion
                                                        }
                                                        else
                                                            if (trimmedString == "HIGH")
                                                            {
                                                                #region High, Med, and Low
                                                                if (myTxt == "HIGH")
                                                                {
                                                                    if (y.Text == "MED")
                                                                    {
                                                                        y.ForeColor = Color.Green;
                                                                        c.ForeColor = Color.White;
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                    if (myTxt == "MED")
                                                                    {
                                                                        if (y.Text == "LOW")
                                                                        {
                                                                            y.ForeColor = Color.Green;
                                                                            c.ForeColor = Color.White;
                                                                            return;
                                                                        }
                                                                    }
                                                                    else
                                                                        if (myTxt == "LOW")
                                                                        {
                                                                            if (y.Text == "HIGH")
                                                                            {
                                                                                y.ForeColor = Color.Green;
                                                                                c.ForeColor = Color.White;
                                                                                return;
                                                                            }
                                                                        }
                                                                #endregion
                                                            }
                                                            else
                                                                if (trimmedString == "UHF")
                                                                {
                                                                    #region UHF, VHF,OFF

                                                                    if (myTxt == "UHF")
                                                                    {
                                                                        if (y.Text == "OFF")
                                                                        {
                                                                            y.ForeColor = Color.Green;
                                                                            c.ForeColor = Color.White;
                                                                            return;
                                                                        }
                                                                    }
                                                                    else
                                                                        if (myTxt == "OFF")
                                                                        {
                                                                            if (y.Text == "VHF")
                                                                            {
                                                                                y.ForeColor = Color.Green;
                                                                                c.ForeColor = Color.White;
                                                                                return;
                                                                            }
                                                                        }
                                                                        else
                                                                            if (myTxt == "VHF")
                                                                            {
                                                                                if (y.Text == "UHF")
                                                                                {
                                                                                    y.ForeColor = Color.Green;
                                                                                    c.ForeColor = Color.White;
                                                                                    return;
                                                                                }
                                                                            }

                                                                    #endregion
                                                                }
                                                                else
                                                                    if (trimmedString == "0")
                                                                    {
                                                                        #region 0,1,2,3,4,5

                                                                        if (myTxt == "0")
                                                                        {
                                                                            if (y.Text == "1")
                                                                            {
                                                                                y.ForeColor = Color.Green;
                                                                                c.ForeColor = Color.White;
                                                                                return;
                                                                            }
                                                                        }
                                                                        else
                                                                            if (myTxt == "1")
                                                                            {
                                                                                if (y.Text == "2")
                                                                                {
                                                                                    y.ForeColor = Color.Green;
                                                                                    c.ForeColor = Color.White;
                                                                                    return;
                                                                                }
                                                                            }
                                                                            else
                                                                                if (myTxt == "2")
                                                                                {
                                                                                    if (y.Text == "3")
                                                                                    {
                                                                                        y.ForeColor = Color.Green;
                                                                                        c.ForeColor = Color.White;
                                                                                        return;
                                                                                    }
                                                                                }
                                                                                else
                                                                                    if (myTxt == "3")
                                                                                    {
                                                                                        if (y.Text == "4")
                                                                                        {
                                                                                            y.ForeColor = Color.Green;
                                                                                            c.ForeColor = Color.White;
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                        if (myTxt == "4")
                                                                                        {
                                                                                            if (y.Text == "5")
                                                                                            {
                                                                                                y.ForeColor = Color.Green;
                                                                                                c.ForeColor = Color.White;
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                            if (myTxt == "5")
                                                                                            {
                                                                                                if (y.Text == "0")
                                                                                                {
                                                                                                    y.ForeColor = Color.Green;
                                                                                                    c.ForeColor = Color.White;
                                                                                                    return;
                                                                                                }
                                                                                            }

                                                                        #endregion
                                                                    }
                                                                    else
                                                                        if (trimmedString == "NOR")
                                                                        {
                                                                            #region NOR,NAR,ATC

                                                                            if (myTxt == "NOR")
                                                                            {
                                                                                if (y.Text == "NAR")
                                                                                {
                                                                                    y.ForeColor = Color.Green;
                                                                                    c.ForeColor = Color.White;
                                                                                    return;
                                                                                }
                                                                            }
                                                                            else
                                                                                if (myTxt == "NAR")
                                                                                {
                                                                                    if (y.Text == "ATC")
                                                                                    {
                                                                                        y.ForeColor = Color.Green;
                                                                                        c.ForeColor = Color.White;
                                                                                        return;
                                                                                    }
                                                                                }
                                                                                else
                                                                                    if (myTxt == "ATC")
                                                                                    {
                                                                                        if (y.Text == "NOR")
                                                                                        {
                                                                                            y.ForeColor = Color.Green;
                                                                                            c.ForeColor = Color.White;
                                                                                            return;
                                                                                        }
                                                                                    }

                                                                            #endregion
                                                                        }
                                                                        else
                                                                            if (trimmedString == "1.2K")
                                                                            {
                                                                                #region 1.2K,2.4K,9.6K,12K,16K

                                                                                if (myTxt == "1.2K")
                                                                                {
                                                                                    if (y.Text == "2.4K")
                                                                                    {
                                                                                        y.ForeColor = Color.Green;
                                                                                        c.ForeColor = Color.White;
                                                                                        return;
                                                                                    }
                                                                                }
                                                                                else
                                                                                    if (myTxt == "2.4K")
                                                                                    {
                                                                                        if (y.Text == "9.6K")
                                                                                        {
                                                                                            y.ForeColor = Color.Green;
                                                                                            c.ForeColor = Color.White;
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                        if (myTxt == "9.6K")
                                                                                        {
                                                                                            if (y.Text == "12K")
                                                                                            {
                                                                                                y.ForeColor = Color.Green;
                                                                                                c.ForeColor = Color.White;
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                            if (myTxt == "12K")
                                                                                            {
                                                                                                if (y.Text == "16K")
                                                                                                {
                                                                                                    y.ForeColor = Color.Green;
                                                                                                    c.ForeColor = Color.White;
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                                if (myTxt == "16K")
                                                                                                {
                                                                                                    if (y.Text == "1.2K")
                                                                                                    {
                                                                                                        y.ForeColor = Color.Green;
                                                                                                        c.ForeColor = Color.White;
                                                                                                        return;
                                                                                                    }
                                                                                                }

                                                                                #endregion
                                                                            }
                                                                            else
                                                                                if (trimmedString == "TR")
                                                                                {
                                                                                    #region TR,R,AATR,AAR

                                                                                    if (myTxt == "TR")
                                                                                    {
                                                                                        if (y.Text == "R")
                                                                                        {
                                                                                            y.ForeColor = Color.Green;
                                                                                            c.ForeColor = Color.White;
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                        if (myTxt == "R")
                                                                                        {
                                                                                            if (y.Text == "AATR")
                                                                                            {
                                                                                                y.ForeColor = Color.Green;
                                                                                                c.ForeColor = Color.White;
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                            if (myTxt == "AATR")
                                                                                            {
                                                                                                if (y.Text == "AAR")
                                                                                                {
                                                                                                    y.ForeColor = Color.Green;
                                                                                                    c.ForeColor = Color.White;
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                                if (myTxt == "AAR")
                                                                                                {
                                                                                                    if (y.Text == "TR")
                                                                                                    {
                                                                                                        y.ForeColor = Color.Green;
                                                                                                        c.ForeColor = Color.White;
                                                                                                        return;
                                                                                                    }
                                                                                                }

                                                                                    #endregion
                                                                                }
                                                                                else
                                                                                    if (currentPageTitle == "IFF" & currentPageNumber == 1)
                                                                                    {
                                                                                        if (trimmedString == "OFF")
                                                                                        {
                                                                                            #region OFF,L1,L2

                                                                                            if (myTxt == "OFF ")
                                                                                            {
                                                                                                if (y.Text == "L1")
                                                                                                {
                                                                                                    y.ForeColor = Color.Green;
                                                                                                    c.ForeColor = Color.White;
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                                if (myTxt == "L1")
                                                                                                {
                                                                                                    if (y.Text == "L2")
                                                                                                    {
                                                                                                        y.ForeColor = Color.Green;
                                                                                                        c.ForeColor = Color.White;
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                    if (myTxt == "L2")
                                                                                                    {
                                                                                                        if (y.Text == "OFF ")
                                                                                                        {
                                                                                                            y.ForeColor = Color.Green;
                                                                                                            c.ForeColor = Color.White;
                                                                                                            return;
                                                                                                        }
                                                                                                    }

                                                                                            #endregion
                                                                                        }

                                                                                        else
                                                                                            if (trimmedString == "DIV")
                                                                                            {
                                                                                                #region DIV,TOP,BOT

                                                                                                if (myTxt == "DIV")
                                                                                                {
                                                                                                    if (y.Text == "TOP")
                                                                                                    {
                                                                                                        y.ForeColor = Color.Green;
                                                                                                        c.ForeColor = Color.White;
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                    if (myTxt == "TOP")
                                                                                                    {
                                                                                                        if (y.Text == "BOT")
                                                                                                        {
                                                                                                            y.ForeColor = Color.Green;
                                                                                                            c.ForeColor = Color.White;
                                                                                                            return;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                        if (myTxt == "BOT")
                                                                                                        {
                                                                                                            if (y.Text == "DIV")
                                                                                                            {
                                                                                                                y.ForeColor = Color.Green;
                                                                                                                c.ForeColor = Color.White;
                                                                                                                return;
                                                                                                            }
                                                                                                        }

                                                                                                #endregion
                                                                                            }
                                                                                    }
                                                                                    else
                                                                                        if (currentPageTitle == "IFF" & currentPageNumber == 2 & pushedButton == r4Btn)
                                                                                        {
                                                                                            if (myTxt == "OFF ")
                                                                                            {
                                                                                                if (y.Text == "ON")
                                                                                                {
                                                                                                    y.ForeColor = Color.Green;
                                                                                                    c.ForeColor = Color.White;
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                                if (myTxt == "ON")
                                                                                                {
                                                                                                    if (y.Text == "OFF")
                                                                                                    {
                                                                                                        y.ForeColor = Color.Green;
                                                                                                        c.ForeColor = Color.White;
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                        }


                                    }

                                }

                            }

                        }
                    }

                }
                catch (Exception)
                {

                }

                return;
            }
            #endregion

            #region Non-Fixed Button Selection
            //because the VU1 and VU2 COMM pages (for example but not limited to) do not always have a fixed button selection,
            //this section was added prior to the switch statement to handle the oddity
            #region Handles page selection calls from COMM page and COM STATUS page

            if (currentPageTitle == "comm")
            {
                if (pushedButton == l1Btn)
                {
                    CheckVU1();
                    return;
                }
                else
                    if (pushedButton == l2Btn)
                    {
                        CheckVU2();
                        return;
                    }
                    else
                    {

                        if (pushedButton == l3Btn)
                        {
                            CheckBASandSEL();
                            CheckALE();
                            return;
                        }
                        else
                            if (pushedButton == r3Btn & scratchpad != null)
                            {
                                if (CheckFreqFormat("HF"))
                                {
                                    UpdateFreqswithRightBtnPush();
                                    scratchpad = "";
                                    sPad.Text = "";
                                    StartFresh();
                                    COMpage();
                                    return;
                                }
                                else
                                {
                                    DisplayErrorMessage("INVALID ENTRY");
                                    return;
                                }
                            }
                            else
                            {
                                if ((pushedButton == r2Btn || pushedButton == r1Btn) & scratchpad != null)
                                {
                                    if (CheckFreqFormat("UHF"))
                                    {
                                        UpdateFreqswithRightBtnPush();
                                        scratchpad = "";
                                        sPad.Text = "";
                                        StartFresh();
                                        COMpage();
                                        return;
                                    }
                                    else if (CheckFreqFormat("COMSEC"))
                                    {
                                        UpdateComsec();
                                        scratchpad = "";
                                        sPad.Text = "";
                                        StartFresh();
                                        COMpage();
                                        return;
                                    }
                                    else
                                    {
                                        DisplayErrorMessage("INVALID ENTRY");
                                        return;
                                    }
                                }
                            }
                    }
            }
            else
                if (currentPageTitle == "SYSTEM STATUS")
                {
                    if (pushedButton == l4Btn)
                    {
                        StartFresh();
                        ComStatusPage1();
                        return;
                    }
                }
                else
                    if (currentPageTitle == "COM STATUS")
                    {
                        if (pushedButton == l1Btn)
                        {
                            StartFresh();
                            VU1StatusPage();
                            return;
                        }
                        else
                            if (pushedButton == l2Btn)
                            {
                                StartFresh();
                                VU2StatusPage();
                                return;
                            }
                            else
                                if (pushedButton == l3Btn)
                                {
                                    StartFresh();
                                    HFStatusPage1();
                                    return;
                                }
                    }


            #endregion Non-Fixed Button Selection

            #region Handles call from VU1 & VU2 CONTROL pages
            if (currentPageTitle == "V/U1 CONTROL")
            {
                if (pushedButton == l1Btn)
                {
                    CheckVU1();
                    return;
                }
                else if ((pushedButton == r1Btn) & scratchpad != null)
                {
                    if (CheckFreqFormat("UHF"))
                    {
                        UpdateFreqswithRightBtnPush();
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        VU1controlPage1();
                        return;
                    }
                    else if (CheckFreqFormat("COMSEC"))
                    {
                        UpdateComsec();
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        VU1controlPage1();
                        return;
                    }
                    else
                    {
                        DisplayErrorMessage("INVALID ENTRY");
                        return;
                    }
                }
            }

            if (currentPageTitle == "V/U2 CONTROL")
            {
                if (pushedButton == l1Btn)
                {
                    CheckVU2();
                    return;
                }
                else if ((pushedButton == r1Btn) & scratchpad != null)
                {
                    if (CheckFreqFormat("UHF"))
                    {
                        UpdateFreqswithRightBtnPush();
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        VU2controlPage1();
                        return;
                    }
                    else if (CheckFreqFormat("COMSEC"))
                    {
                        UpdateComsec();
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        VU2controlPage1();
                        return;
                    }
                    else
                    {
                        DisplayErrorMessage("INVALID ENTRY");
                        return;
                    }
                }
            }
            #endregion

            #region Handles page selection calls from VU 1&2 Comsec Control pages

            if (currentPageTitle == "V/U1 COMSEC CONTROL" & pushedButton == l1Btn)
            {
                StartFresh();
                VU1comsecVarPage1();
                return;
            }
            else
                if (currentPageTitle == "V/U2 COMSEC CONTROL" & pushedButton == l1Btn)
                {
                    StartFresh();
                    VU2comsecVarPage1();
                    return;
                }

            #endregion

            #region Page selection for VU1 Preset Channels Page
            if ((currentPageTitle == "V/U1 UHF" || currentPageTitle == "V/U1 VHF-FM" || currentPageTitle == "V/U1 VHF-AM" || currentPageTitle == "V/U1 SATCOM" || currentPageTitle == "V/U1 HOPSETS") & pushedButton != r6Btn)
            {
                PresetController();
                return;
            }
            #endregion

            #region Page selection for VU1 Preset Channels Page
            if (currentPageTitle == "V/U2 UHF" & pushedButton != r6Btn)
            {
                PresetController();
                return;
            }
            #endregion

            #region page selection from SYSTEM STATUS page

            if (currentPageTitle == "SYSTEM STATUS")
            {
                if (pushedButton == l2Btn)
                {
                    StartFresh();
                    NAVstatusPage();
                    return;
                }
                else

                    if (pushedButton == r6Btn)
                    {
                        StartFresh();
                        ReturnList("SYSTEM STATUS");
                        return;
                    }

                    else

                        if (pushedButton == l3Btn)
                        {
                            StartFresh();
                            SurvStatusPage();
                            return;
                        }

                return;
            }

            #endregion

            #region page selection from NAV STATUS page

            if (currentPageTitle == "NAV STATUS")
            {
                if (pushedButton == r1Btn)
                {
                    StartFresh();
                    TACANstatusPage();
                    return;
                }
                else
                    if (pushedButton == l1Btn)
                    {
                        StartFresh();//clears all  TextBoxes before writing new page
                        EGIstatusPage();
                        return;
                    }
            }

            #endregion

            #region page selection from EGI STATUS page

            if (currentPageTitle == "EGI STATUS" & pushedButton == l5Btn)
            {
                StartFresh();
                EGIINUstatusPage();
                return;
            }

            if (currentPageTitle == "EGI STATUS" & pushedButton == r5Btn)
            {
                StartFresh();
                EgiGpsStatusPage();
                return;
            }

            #endregion

            #region page selection from HF ALE FCTN page

            if (currentPageTitle == "HF1 ALE FCTN" & currentPageNumber == 1 & pushedButton == r1Btn)
            {
                StartFresh();
                HFALEaddressPage();
                return;
            }

            #endregion

            #region page selection from HF ALE ADDRESS page

            if (currentPageTitle == "HF1 ALE ADDRESS" & pushedButton == r1Btn)
            {
                StartFresh();
                HFALEgroupAddressPage();
                return;
            }

            if (currentPageTitle == "HF1 ALE ADDRESS" & pushedButton == r2Btn)
            {
                StartFresh();
                HFALEnetAddressPage();
                return;
            }

            #endregion

            #region page selection from HF ALE PRESET page
            if (currentPageTitle == "HF1 ALE PRESET CHAN" & pushedButton != r6Btn)
            {
                PresetController();
                return;
            }
            #endregion

            #region Page selection for HF Preset Channels Page
            if (currentPageTitle == "HF1 PRESET CHANNELS" & pushedButton != r6Btn)
            {
                PresetController();
                return;
            }
            #endregion

            #region page selection for HF CONTROL page 1
            if (currentPageTitle == "HF1 CONTROL" & currentPageNumber == 1 & pushedButton == r3Btn)
            {
                if (hfSubMode == "PRST" & hfMode != "ALE")
                {
                    StartFresh();
                    HFpresetChannelsPage1();
                    return;
                }
                else
                    if (hfSubMode == "PRST" & hfMode == "ALE")
                    {
                        StartFresh();
                        HFALEpresetChannelsPage1();
                        return;
                    }
            }
            #endregion

            #region page selections from START INIT page

            if (currentPageTitle == "START INIT" & trimmedString != "RETURN")
            {
                if (pushedButton == l4Btn)
                {
                    if (actInactToggle == ">")
                    {
                        actInactToggle = "*";
                    }
                    else
                    {
                        actInactToggle = ">";
                    }

                    StartFresh();
                    StartInitPage();

                }
                else

                    if (pushedButton == l5Btn)
                    {
                        StartFresh();
                        EGIcontrolPage();
                    }
                    else
                        if (pushedButton == r5Btn)
                        {
                            StartFresh();
                            PowerPage();
                        }

                return;
            }

            #endregion

            #region page selections from SURV STATUS page

            if (currentPageTitle == "SURV STATUS")
            {
                if (pushedButton == l1Btn)
                {
                    StartFresh();
                    IFFstatusPage1();
                    return;
                }
            }

            #endregion



            #endregion Select Cases


            switch (CDU7000Page)//determines if the current page is a CDU 7000 page
            {
                case false://CDU3000 pages are here

                    #region MyRegion
                    //check current input string
                    switch (trimmedString)
                    {

                        #region cases

                        //Arrival Data page
                        case "ARR DATA":
                            StartFresh();
                            ArrivalDataPage1();
                            break;

                        //Circle page1
                        case "CIRCLE":
                            StartFresh();
                            CirclePage1();
                            break;


                        //Data Base Page1
                        case "DATA BASE":
                            StartFresh();
                            DataBasePage1();
                            break;

                        //DB Disk Ops
                        case "DB DISK OPS":
                            StartFresh();
                            DbDiskOps();
                            break;

                        //Defaults
                        case "DEFAULTS":
                            StartFresh();
                            DefaultsPage1();
                            break;

                        //Disk Route List page1
                        case "DISK ROUTE LIST":
                            StartFresh();
                            DiskRouteList();
                            break;

                        //Exp Squarepage1
                        case "EXP SQUARE":
                            StartFresh();
                            ExpSquarePage1();
                            break;

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
                        case "GNSS1 POS":
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

                        //IRS CTL page 1
                        case "LADDER":
                            StartFresh();//clears all  TextBoxes before writing new page
                            LadderPage1();
                            break;

                        //Mark Points page1
                        case "MARK POINTS":
                            StartFresh();
                            MarkPointsPage1();
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

                        //Pilot Route List page1
                        case "PILOT ROUTE LIST":
                            StartFresh();
                            PilotRouteList();
                            break;

                        //Search page1
                        case "SEARCH":
                            StartFresh();
                            SearchPage1();
                            break;

                        //Sector page1
                        case "SECTOR":
                            StartFresh();
                            SectorPage1();
                            break;

                        //Pilot Waypoint List page1
                        case "WPT LIST":
                            StartFresh();
                            PilotWaypointList();
                            break;

                        //Define Waypoint List page1
                        case "DEFINE WPT":
                            StartFresh();
                            DefineWaypoint();
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

                        //Return List 
                        case "RETURN":
                            StartFresh();
                            ReturnList(currentPageTitle);
                            break;

                        //ROUTE page1
                        case "ROUTE MENU":
                            StartFresh();
                            RoutePage1();
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
                                }
                                else
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
                        #endregion

                        //default to scratchpad
                        default:
                            try
                            {
                                if (scratchpad != null)//if the scratchpad is not null
                                {
                                    TransferScratch();//transfer the scratchpad data to the textbox adjacent to the button pushed
                                }
                                else
                                {
                                    Scratch(trimmedString, e);//add text tothe scratchpad
                                }
                            }
                            catch (Exception)
                            {


                            }
                            break;


                    }
                    break;
                    #endregion

                case true://CDU7000 pages are here

                    #region MyRegion
                    //insert cdu7000 switch statements here
                    switch (trimmedString)
                    {

                        //- -
                        case "- -":
                            if (currentPageTitle == "HF1 CONTROL" & hfSubMode == "PRST")
                            {
                                StartFresh();
                                HFpresetChannelsPage1();
                            }
                            else if (currentPageTitle == "HF1 CONTROL" & hfSubMode == "SCAN")
                            {
                                StartFresh();
                                ALEscanListsPage();
                            }
                            break;

                        //ALE FCTN
                        case "ALE FCTN":
                            {
                                StartFresh();
                                HFALEfunctionPage1();
                            }
                            break;

                        //Cancel
                        case "CANCEL":
                            if (currentPageTitle == "INU LEVER ARMS")
                            {
                                l2text = initialX;
                                l3text = initialY;
                                l4text = initialZ;
                                StartFresh();
                                EgiMaintenancePage();
                            }
                            break;

                        //Clear NVM pages
                        case "CLEAR":
                            StartFresh();
                            #region MyRegion
                            if (currentPageTitle == "V/U1 MAINTENANCE")
                            {
                                VU1ClearNVM();
                                break;
                            }
                            else
                                if (currentPageTitle == "V/U2 MAINTENANCE")
                                {
                                    VU2ClearNVM();
                                    break;
                                }
                            #endregion
                            break;

                        //COMM page
                        case "COM":
                            StartFresh();//clears all  TextBoxes before writing new page
                            COMpage();
                            break;

                        //VU1 COMSEC CONTROL Page
                        case "COMSEC":
                            #region MyRegion
                            StartFresh();

                            if (currentPageTitle == "V/U1 CONTROL")
                            {
                                VU1comsecControlPage();
                            }
                            else
                                if (currentPageTitle == "V/U2 CONTROL")
                                {
                                    VU2comsecControlPage();
                                }
                                else
                                    if (currentPageTitle == "V/U1 FILL")
                                    {
                                        VU1ComsecFill();
                                    }
                                    else
                                        if (currentPageTitle == "V/U2 FILL")
                                        {
                                            VU2ComsecFill();
                                        }

                            break;
                            #endregion

                        //EGI MAINTENANCE page
                        case "EGI MAINT":
                            StartFresh();
                            EgiMaintenancePage();
                            break;

                        //EGI SA/AS page
                        case "EGI SA/AS":
                            StartFresh();
                            EGIsaAsPage();
                            break;

                        //ENTER
                        case "ENTER":

                            updatedX = l2text;
                            updatedY = l3text;
                            updatedZ = l4text;
                            StartFresh();
                            EgiMaintenancePage();
                            break;


                        //Fill page
                        case "FILL":
                            StartFresh();
                            #region MyRegion
                            if (currentPageTitle == "V/U1 MAINTENANCE")
                            {
                                VU1Fill();
                            }
                            else
                                if (currentPageTitle == "V/U2 MAINTENANCE")
                                {
                                    VU2Fill();
                                }
                            #endregion
                            break;

                        //GPS SYNC
                        case "GPS SYNC":
                            StartFresh();
                            HFstandbyFunctionPage();
                            break;

                        //HF CONTROL page1
                        case "STBY FUNC":
                            StartFresh();
                            HFstandbyFunctionPage();
                            break;

                        //Lockouts page
                        case "LOCKOUTS":
                            StartFresh();

                            #region MyRegion
                            if (currentPageTitle == "V/U1 SINCGARS")
                            {
                                VU1lockoutsPage();
                            }
                            else
                                if (currentPageTitle == "V/U2 SINCGARS")
                                {
                                    VU2lockoutsPage();
                                }
                            #endregion

                            break;

                        //Loopback page
                        case "LOOPBACK":
                            StartFresh();
                            #region MyRegion
                            if (currentPageTitle == "V/U1 MAINTENANCE")
                            {
                                VU1LoopbackTest();
                                break;
                            }
                            else
                                if (currentPageTitle == "V/U2 MAINTENANCE")
                                {
                                    VU2LoopbackTest();
                                    break;
                                }
                            #endregion
                            break;

                        //Maintenance page
                        case "MAINTENANCE":
                            StartFresh();
                            #region MyRegion
                            if (currentPageTitle == "V/U1 CONTROL")
                            {
                                VU1maintenancePage();
                            }
                            else
                                if (currentPageTitle == "V/U2 CONTROL")
                                {
                                    VU2maintenancePage();
                                }
                            #endregion
                            break;

                        //Powerpage
                        case "POWER":
                            StartFresh();
                            PowerPage();
                            break;

                        //Presets pages
                        case "PRESETS":
                            CheckPresets();
                            break;

                        //Return List 
                        case "RETURN":
                            StartFresh();
                            ReturnList(currentPageTitle);
                            break;

                        //Sincgars page
                        case "SINCGARS":
                            StartFresh();
                            #region MyRegion
                            if (currentPageTitle == "V/U1 FILL")
                            {
                                VU1SincgarsFill();
                            }
                            else
                                if (currentPageTitle == "V/U2 FILL")
                                {
                                    VU2SincgarsFill();
                                }
                                else
                                    if (currentPageTitle == "V/U1 CONTROL")
                                    {
                                        VU1sincgarsControlPage();
                                    }
                                    else
                                        if (currentPageTitle == "V/U2 CONTROL")
                                        {
                                            VU2sincgarsControlPage();
                                        }
                            #endregion
                            break;

                        //States pages
                        case "STATES":
                            {
                                StartFresh();

                                #region MyRegion
                                if (currentPageTitle == "V/U1 COMSEC FILL")
                                {
                                    VU1ComsecStatesPage1();
                                }
                                else
                                    if (currentPageTitle == "V/U2 COMSEC FILL")
                                    {
                                        VU2ComsecStatesPage1();
                                    }
                                #endregion

                                break;
                            }

                        //Status pages
                        case "STATUS":
                            StartFresh();
                            MissionStatusPage1();
                            break;

                        //Start Init page
                        case "START INIT":
                            StartFresh();
                            StartInitPage();
                            break;



                        //SURV page
                        case "SURV":
                            StartFresh();
                            if (!myCont.IFFselected)
                            {
                                MissionPage();
                                CheckValidity();
                            }
                            else
                            {
                                IFFcontrolPage1();
                            }
                            break;

                        //TACAN Control Page
                        case "TACAN":
                            StartFresh();
                            TacanControlPage();
                            break;

                        //Transec page
                        case "TRANSEC":
                            StartFresh();

                            #region MyRegion
                            if (currentPageTitle == "V/U1 FILL")
                            {
                                VU1TransecFill();
                            }
                            else
                                if (currentPageTitle == "V/U2 FILL")
                                {
                                    VU2TransecFill();
                                }
                            #endregion

                            break;

                        //Zeroize page
                        case "ZEROIZE":
                            StartFresh();
                            ZeroizePage();
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
                    #endregion

                    break;

            }

            UpdateDisplay(); //updates the display after writing the page

        }

        private void UpdateComsec()
        {
            if (pushedButton == r2Btn || currentPageTitle == "V/U2 CONTROL")//VU2
            {
                if (BandSelection(currentVU2freq, "VU2") == "U")//verifies the band is UHF
                {
                    currentVU2ComsecVar = scratchpad;

                    if (currentVU2chan == VU2UHFpre1Chan.Trim('<', ' ', '*'))
                    {
                        VU2UHFpre1Comsec = currentVU2ComsecVar;
                    }
                    else
                        if (currentVU2chan == VU2UHFpre2Chan.Trim('<', ' ', '*'))
                        {
                            VU2UHFpre2Comsec = currentVU2ComsecVar;
                        }
                        else
                            if (currentVU2chan == VU2UHFpre3Chan.Trim('<', ' ', '*'))
                            {
                                VU2UHFpre3Comsec = currentVU2ComsecVar;
                            }
                            else
                                if (currentVU2chan == VU2UHFpre4Chan.Trim('<', ' ', '*'))
                                {
                                    VU2UHFpre4Comsec = currentVU2ComsecVar;
                                }
                                else
                                    if (currentVU2chan == VU2UHFpre5Chan.Trim('<', ' ', '*'))
                                    {
                                        VU2UHFpre5Comsec = currentVU2ComsecVar;
                                    }
                }

            }
            else
                if (pushedButton == r1Btn)//VU1
                {
                    if (BandSelection(currentVU1freq, "VU1") == "U")//verifies the band is UHF
                    {
                        currentVU1ComsecVar = scratchpad;

                        if (currentVU1chan == VU1UHFpre1Chan.Trim('<', ' ', '*'))
                        {
                            VU1UHFpre1Comsec = currentVU1ComsecVar;
                        }
                        else
                            if (currentVU1chan == VU1UHFpre2Chan.Trim('<', ' ', '*'))
                            {
                                VU1UHFpre2Comsec = currentVU1ComsecVar;
                            }
                            else
                                if (currentVU1chan == VU1UHFpre3Chan.Trim('<', ' ', '*'))
                                {
                                    VU1UHFpre3Comsec = currentVU1ComsecVar;
                                }
                                else
                                    if (currentVU1chan == VU1UHFpre4Chan.Trim('<', ' ', '*'))
                                    {
                                        VU1UHFpre4Comsec = currentVU1ComsecVar;
                                    }
                                    else
                                        if (currentVU1chan == VU1UHFpre5Chan.Trim('<', ' ', '*'))
                                        {
                                            VU1UHFpre5Comsec = currentVU1ComsecVar;
                                        }
                    }
                }
        }

        private void CheckALE()
        {
            if (hfMode == "ALE")
            {
                if (pushedButton == l3Btn & (scratchpad == "" || scratchpad == null))//scratchpad != "0" & ContainsLetters() == false
                {
                    StartFresh();
                    HFcontrolPage1();
                    return;
                }
                else
                    if (pushedButton == l3Btn & scratchpad == "0")
                    {
                        currentALEchan = ALERecallChan;
                        currentALEname = ALERecallName;
                        currentALEfreq = ALERecallFreq;
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        COMpage();
                        return;
                    }
                    else
                        if (pushedButton == l3Btn & ContainsLetters() == true)
                        {
                            if (SearchCallSign(scratchpad))/////////////
                            {
                                sPad.Text = "";
                                scratchpad = "";
                                StartFresh();
                                COMpage();
                                return;
                            }
                            else
                            {
                                StartFresh();
                                COMpage();
                                scratchMessage = "INVALID ENTRY";
                                ShowScratchMessage();
                                ScratchMessageTimer.Start();
                                return;
                            }


                        }
                        else
                            if (pushedButton == l3Btn & ContainsLetters() == false & ContainsNumbers() == true)
                            {
                                if (SearchChannelNumbers(scratchpad))////////////////
                                {
                                    sPad.Text = "";
                                    scratchpad = "";
                                    StartFresh();
                                    COMpage();
                                    return;
                                }
                                else
                                {
                                    StartFresh();
                                    COMpage();
                                    scratchMessage = "INVALID ENTRY";
                                    ShowScratchMessage();
                                    ScratchMessageTimer.Start();
                                    return;
                                }


                            }
            }
        }

        private void CheckBASandSEL()
        {


            if (hfMode != "ALE")
            {
                if (pushedButton == l3Btn & (scratchpad == "" || scratchpad == null))//scratchpad != "0" & ContainsLetters() == false
                {
                    StartFresh();
                    HFcontrolPage1();
                    return;
                }
                else
                    if (pushedButton == l3Btn & scratchpad == "0")
                    {
                        currentHFchan = hfRecallChan;
                        currentHFchanName = hfRecallName;
                        currentHFfreq = hfRecallFreq;
                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        COMpage();
                        return;
                    }
                    else
                        if (pushedButton == l3Btn & ContainsLetters() == true)
                        {
                            if (SearchCallSign(scratchpad))
                            {
                                sPad.Text = "";
                                scratchpad = "";
                                StartFresh();
                                COMpage();
                                return;
                            }
                            else
                            {
                                StartFresh();
                                COMpage();
                                scratchMessage = "INVALID ENTRY";
                                ShowScratchMessage();
                                ScratchMessageTimer.Start();
                                return;
                            }


                        }
                        else
                            if (pushedButton == l3Btn & ContainsLetters() == false & ContainsNumbers() == true)
                            {
                                if (SearchChannelNumbers(scratchpad))
                                {
                                    sPad.Text = "";
                                    scratchpad = "";
                                    StartFresh();
                                    COMpage();
                                    return;
                                }
                                else
                                {
                                    StartFresh();
                                    COMpage();
                                    scratchMessage = "INVALID ENTRY";
                                    ShowScratchMessage();
                                    ScratchMessageTimer.Start();
                                    return;
                                }


                            }
            }

        }

        private void CheckVU1()
        {
            if (currentPageTitle == "comm" || currentPageTitle == "V/U1 CONTROL")
            {
                if (pushedButton == l1Btn & (scratchpad == "" || scratchpad == null))//scratchpad != "0" & ContainsLetters() == false
                {
                    StartFresh();
                    if (currentPageTitle == "comm")
                    {
                        VU1controlPage1();
                    }
                    else if (currentPageTitle == "V/U1 CONTROL")
                    {
                        StartFresh();
                        VU1controlPage1();
                        scratchMessage = "INVALID ENTRY";
                        ScratchMessageTimer.Start();
                        ShowScratchMessage();
                    }
                    return;
                }
                else
                    if (pushedButton == l1Btn & scratchpad == "0")
                    {
                        if (VU1band == activeBand.UHF)
                        {
                            string tempChan = currentVU1chan;
                            string tempName = currentVU1name;
                            string tempFreq = currentVU1freq;
                            string tempComsec = currentVU1ComsecVar;

                            currentVU1chan = recallVU1UHFchan;
                            currentVU1name = recallVU1UHFname;
                            currentVU1freq = recallVU1UHFfreq;
                            currentVU1ComsecVar = recallVU1Comsec;

                            recallVU1UHFchan = tempChan;
                            recallVU1UHFname = tempName;
                            recallVU1UHFfreq = tempFreq;
                            recallVU1Comsec = tempComsec;
                        }
                        else if (VU1band == activeBand.FM)
                        {
                            string tempChan = currentVU1chan;
                            string tempName = currentVU1name;
                            string tempFreq = currentVU1freq;
                            string tempComsec = currentVU1ComsecVar;

                            currentVU1chan = recallVU1FMchan;
                            currentVU1name = recallVU1FMname;
                            currentVU1freq = recallVU1FMfreq;
                            currentVU1ComsecVar = recallVU1Comsec;

                            recallVU1FMchan = tempChan;
                            recallVU1FMname = tempName;
                            recallVU1FMfreq = tempFreq;
                            recallVU1Comsec = tempComsec;
                        }
                        else if (VU1band == activeBand.AM)
                        {
                            string tempChan = currentVU1chan;
                            string tempName = currentVU1name;
                            string tempFreq = currentVU1freq;
                            string tempComsec = currentVU1ComsecVar;

                            currentVU1chan = recallVU1AMchan;
                            currentVU1name = recallVU1AMname;
                            currentVU1freq = recallVU1AMfreq;
                            currentVU1ComsecVar = recallVU1Comsec;

                            recallVU1AMchan = tempChan;
                            recallVU1AMname = tempName;
                            recallVU1AMfreq = tempFreq;
                            recallVU1Comsec = tempComsec;
                        }
                        else if (VU1band == activeBand.HOPSETS)
                        {
                            string tempChan = currentVU1chan;
                            string tempName = currentVU1name;
                            string tempFreq = currentVU1freq;
                            string tempComsec = currentVU1ComsecVar;

                            currentVU1chan = recallVU1HOPchan;
                            currentVU1name = recallVU1HOPname;
                            currentVU1freq = recallVU1HOPfreq;
                            currentVU1ComsecVar = recallVU1Comsec;

                            recallVU1HOPchan = tempChan;
                            recallVU1HOPname = tempName;
                            recallVU1HOPfreq = tempFreq;
                            recallVU1Comsec = tempComsec;
                        }


                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        if (currentPageTitle == "comm")
                        {
                            COMpage();
                        }
                        else if (currentPageTitle == "V/U1 CONTROL")
                        {
                            VU1controlPage1();
                        }
                        return;
                    }
                    else
                        if (pushedButton == l1Btn & ContainsLetters() == true)
                        {
                            if (SearchCallSign(scratchpad))/////////////
                            {
                                sPad.Text = "";
                                scratchpad = "";
                                StartFresh();
                                if (currentPageTitle == "comm")
                                {
                                    COMpage();
                                }
                                else if (currentPageTitle == "V/U1 CONTROL")
                                {
                                    VU1controlPage1();
                                }
                                return;
                            }
                            else
                            {
                                StartFresh();
                                if (currentPageTitle == "comm")
                                {
                                    COMpage();
                                }
                                else if (currentPageTitle == "V/U1 CONTROL")
                                {
                                    VU1controlPage1();
                                }
                                scratchMessage = "INVALID ENTRY";
                                ShowScratchMessage();
                                ScratchMessageTimer.Start();
                                return;
                            }


                        }
                        else
                            if (pushedButton == l1Btn & ContainsLetters() == false & ContainsNumbers() == true)
                            {
                                if (SearchChannelNumbers(scratchpad))////////////////
                                {
                                    sPad.Text = "";
                                    scratchpad = "";
                                    StartFresh();
                                    if (currentPageTitle == "comm")
                                    {
                                        COMpage();
                                    }
                                    else if (currentPageTitle == "V/U1 CONTROL")
                                    {
                                        VU1controlPage1();
                                    }
                                    return;
                                }
                                else
                                {
                                    StartFresh();
                                    if (currentPageTitle == "comm")
                                    {
                                        COMpage();
                                    }
                                    else if (currentPageTitle == "V/U1 CONTROL")
                                    {
                                        VU1controlPage1();
                                    }
                                    scratchMessage = "INVALID ENTRY";
                                    ShowScratchMessage();
                                    ScratchMessageTimer.Start();
                                    return;
                                }


                            }
            }
        }

        private void CheckVU2()
        {
            if (currentPageTitle == "comm")
            {
                if (pushedButton == l2Btn & (scratchpad == "" || scratchpad == null))//scratchpad != "0" & ContainsLetters() == false
                {
                    StartFresh();
                    VU2controlPage1();
                    return;
                }
                else
                    if (pushedButton == l2Btn & scratchpad == "0")
                    {
                        string tempChan = currentVU2chan;
                        string tempName = currentVU2name;
                        string tempFreq = currentVU2freq;
                        string tempComsec = currentVU2ComsecVar;

                        currentVU2chan = recallVU2UHFchan;
                        currentVU2name = recallVU2UHFname;
                        currentVU2freq = recallVU2UHFfreq;
                        currentVU2ComsecVar = recallVU2Comsec;

                        recallVU2UHFchan = tempChan;
                        recallVU2UHFname = tempName;
                        recallVU2UHFfreq = tempFreq;
                        recallVU2Comsec = tempComsec;


                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        COMpage();
                        return;
                    }
                    else
                        if (pushedButton == l2Btn & ContainsLetters() == true)
                        {
                            if (SearchCallSign(scratchpad))/////////////
                            {
                                sPad.Text = "";
                                scratchpad = "";
                                StartFresh();
                                COMpage();
                                return;
                            }
                            else
                            {
                                StartFresh();
                                COMpage();
                                scratchMessage = "INVALID ENTRY";
                                ShowScratchMessage();
                                ScratchMessageTimer.Start();
                                return;
                            }


                        }
                        else
                            if (pushedButton == l2Btn & ContainsLetters() == false & ContainsNumbers() == true)
                            {
                                if (SearchChannelNumbers(scratchpad))////////////////
                                {
                                    sPad.Text = "";
                                    scratchpad = "";
                                    StartFresh();
                                    COMpage();
                                    return;
                                }
                                else
                                {
                                    StartFresh();
                                    COMpage();
                                    scratchMessage = "INVALID ENTRY";
                                    ShowScratchMessage();
                                    ScratchMessageTimer.Start();
                                    return;
                                }


                            }
            }
            else if (currentPageTitle == "V/U2 CONTROL")
            {
                if (pushedButton == l1Btn & (scratchpad == "" || scratchpad == null))//scratchpad != "0" & ContainsLetters() == false
                {
                    StartFresh();
                    VU2controlPage1();
                    scratchMessage = "INVALID ENTRY";
                    ScratchMessageTimer.Start();
                    ShowScratchMessage();
                    return;
                }
                else
                    if (pushedButton == l1Btn & scratchpad == "0")
                    {
                        string tempChan = currentVU2chan;
                        string tempName = currentVU2name;
                        string tempFreq = currentVU2freq;
                        string tempComsec = currentVU2ComsecVar;

                        currentVU2chan = recallVU2UHFchan;
                        currentVU2name = recallVU2UHFname;
                        currentVU2freq = recallVU2UHFfreq;
                        currentVU2ComsecVar = recallVU2Comsec;

                        recallVU2UHFchan = tempChan;
                        recallVU2UHFname = tempName;
                        recallVU2UHFfreq = tempFreq;
                        recallVU2Comsec = tempComsec;


                        scratchpad = "";
                        sPad.Text = "";
                        StartFresh();
                        VU2controlPage1();
                        return;
                    }
                    else
                        if (pushedButton == l1Btn & ContainsLetters() == true)
                        {
                            if (SearchCallSign(scratchpad))/////////////
                            {
                                sPad.Text = "";
                                scratchpad = "";
                                StartFresh();
                                VU2controlPage1();
                                return;
                            }
                            else
                            {
                                StartFresh();
                                VU2controlPage1();
                                scratchMessage = "INVALID ENTRY";
                                ShowScratchMessage();
                                ScratchMessageTimer.Start();
                                return;
                            }


                        }
                        else
                            if (pushedButton == l1Btn & ContainsLetters() == false & ContainsNumbers() == true)
                            {
                                if (SearchChannelNumbers(scratchpad))////////////////
                                {
                                    sPad.Text = "";
                                    scratchpad = "";
                                    StartFresh();
                                    VU2controlPage1();
                                    return;
                                }
                                else
                                {
                                    StartFresh();
                                    VU2controlPage1();
                                    scratchMessage = "INVALID ENTRY";
                                    ShowScratchMessage();
                                    ScratchMessageTimer.Start();
                                    return;
                                }


                            }
            }
        }

        #endregion




        #region Background methods  //backgroundworkers that handle needed tasks not seen by the user

        private void FormatManualTime()
        {
            string s1 = manualTime.Remove(4);

            string s2 = manualTime.Remove(0, 4);

            hfTime = s1 + " : " + s2;

        }

        private void FormatManualDate()
        {
            string trimmed = manualDate;
            char[] trimThis = { '/', '.' };
            trimmed = manualDate.Trim(trimThis);

            manualDate = trimmed.Insert(2, " / ");
            manualDate = manualDate.Insert(7, " / ");
            hfDate = manualDate;

        }

        private string TrimSelection(string e)    //takes input string and reduces it to text only
        {
            char[] charsToTrim = { '<', ' ', '>' };  //defines the dhars to trim
            e = e.Trim(charsToTrim);    //stores the new string
            return e;
        }

        private void Scratch(string e, string fullText = "")  //Updates scratchpad info when buttons are pressed 
        {
            bool isPresent = false;

            if (btnPressed == "l1" || btnPressed == "l2" || btnPressed == "l3" || btnPressed == "l4" || btnPressed == "l5" || btnPressed == "l6") //determine pushed button
            {
                if (fullText == "" || fullText.Contains("<") || (fullText.Contains("-")) || (fullText.Contains(emptyDigit))) //check if < or > exist next to that button
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
                    if (fullText.Contains("<"))
                    {
                        return;
                    }
                    isPresent = FindPushedButon(btnPressed);

                    if (fullText != "" & (fullText.Contains(emptyDigit) == false) & !isPresent & (fullText.Contains("-") == false))
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

        private void TransferScratch()     //transfers the scratchpad information into a line
        {
            int myRow = 0;//declare which row to put data in
            string mySide = "";//stores the button side

            switch (btnPressed)//gets the name of the last pressed button
            {
                case "l1"://determines the case
                    mySide = "left";
                    myRow = row2;//represents the row that the button is on
                    if (!CheckValidity())
                    {
                        return;
                    }
                    l1text = scratchpad;//assigns scratchpad information to the button variable
                    break;

                case "l2":
                    mySide = "left";
                    myRow = row4;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    if (currentPageTitle != "HF1 STANDBY FCTN")
                    {
                        l2text = scratchpad;
                    }
                    else
                    {
                        manualTime = scratchpad;
                        FormatManualTime();
                    }
                    break;

                case "l3":
                    mySide = "left";
                    myRow = row6;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    if (currentPageTitle != "HF1 STANDBY FCTN")
                    {
                        l3text = scratchpad;
                    }
                    else
                    {
                        manualDate = scratchpad;
                        FormatManualDate();
                    }
                    break;

                case "l4":
                    mySide = "left";
                    myRow = row8;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    l4text = scratchpad;
                    break;

                case "l5":
                    mySide = "left";
                    myRow = row10;
                    l5text = scratchpad;
                    break;

                case "l6":
                    mySide = "left";
                    myRow = row12;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    l6text = scratchpad;
                    break;


                case "r1":
                    mySide = "right";
                    myRow = row2;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    r1text = scratchpad;
                    break;

                case "r2":
                    mySide = "right";
                    myRow = row4;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    r2text = scratchpad;
                    break;

                case "r3":
                    mySide = "right";
                    myRow = row6;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    r3text = scratchpad;
                    break;

                case "r4":
                    mySide = "right";
                    myRow = row8;
                    if (!CheckValidity())
                    {
                        return;
                    }
                    r4text = scratchpad;
                    if (currentPageTitle == "HF1 CONTROL")
                    {
                        hfAircraftID = scratchpad;
                    }
                    break;

                case "r5":
                    mySide = "right";
                    myRow = row10;
                    r5text = scratchpad;
                    break;

                case "r6":
                    mySide = "right";
                    myRow = row12;
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
                            if (c.Location.X == col16)
                            { }
                            else
                                if (c.Location.Y == myRow & c.Location.X < col3 & mySide == "left")
                                {
                                    c.Text = scratchpad;
                                    Size size = TextRenderer.MeasureText(c.Text, c.Font);
                                    c.Size = size;

                                }
                                else
                                    if (c.Location.Y == myRow & ((c.Location.X + c.Width) > col14) & mySide == "right")
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



        private void UpdateVU1(string e)
        {
            Char[] myChar = { '<', ' ', '*' };

            if (VU1band == activeBand.UHF)
            {
                recallVU1UHFchan = currentVU1chan;
                recallVU1UHFfreq = currentVU1freq;
                recallVU1UHFname = currentVU1name;
                recallVU1Comsec = currentVU1ComsecVar;

                switch (e)
                {
                    case "VU1UHFpre1Name":
                        currentVU1chan = VU1UHFpre1Chan.Trim(myChar);
                        currentVU1freq = VU1UHFpre1Freq.Trim(myChar);
                        currentVU1name = VU1UHFpre1Name.Trim(myChar);
                        currentVU1ComsecVar = VU1UHFpre1Comsec;
                        break;

                    case "VU1UHFpre2Name":
                        currentVU1chan = VU1UHFpre2Chan.Trim(myChar);
                        currentVU1freq = VU1UHFpre2Freq.Trim(myChar);
                        currentVU1name = VU1UHFpre2Name.Trim(myChar);
                        currentVU1ComsecVar = VU1UHFpre2Comsec;
                        break;

                    case "VU1UHFpre3Name":
                        currentVU1chan = VU1UHFpre3Chan.Trim(myChar);
                        currentVU1freq = VU1UHFpre3Freq.Trim(myChar);
                        currentVU1name = VU1UHFpre3Name.Trim(myChar);
                        currentVU1ComsecVar = VU1UHFpre3Comsec;
                        break;

                    case "VU1UHFpre4Name":
                        currentVU1chan = VU1UHFpre4Chan.Trim(myChar);
                        currentVU1freq = VU1UHFpre4Freq.Trim(myChar);
                        currentVU1name = VU1UHFpre4Name.Trim(myChar);
                        currentVU1ComsecVar = VU1UHFpre4Comsec;
                        break;

                    case "VU1UHFpre5Name":
                        currentVU1chan = VU1UHFpre5Chan.Trim(myChar);
                        currentVU1freq = VU1UHFpre5Freq.Trim(myChar);
                        currentVU1name = VU1UHFpre5Name.Trim(myChar);
                        currentVU1ComsecVar = VU1UHFpre5Comsec;
                        break;
                }
            }
            else if (VU1band == activeBand.FM)
            {
                recallVU1FMchan = currentVU1chan;
                recallVU1FMfreq = currentVU1freq;
                recallVU1FMname = currentVU1name;
                recallVU1Comsec = currentVU1ComsecVar;

                switch (e)
                {
                    case "VU1FMpre1Name":
                        currentVU1chan = VU1FMpre1Chan.Trim(myChar);
                        currentVU1freq = VU1FMpre1Freq.Trim(myChar);
                        currentVU1name = VU1FMpre1Name.Trim(myChar);
                        currentVU1ComsecVar = VU1FMpre1Comsec;
                        break;

                    case "VU1FMpre2Name":
                        currentVU1chan = VU1FMpre2Chan.Trim(myChar);
                        currentVU1freq = VU1FMpre2Freq.Trim(myChar);
                        currentVU1name = VU1FMpre2Name.Trim(myChar);
                        currentVU1ComsecVar = VU1FMpre2Comsec;
                        break;

                    case "VU1FMpre3Name":
                        currentVU1chan = VU1FMpre3Chan.Trim(myChar);
                        currentVU1freq = VU1FMpre3Freq.Trim(myChar);
                        currentVU1name = VU1FMpre3Name.Trim(myChar);
                        currentVU1ComsecVar = VU1FMpre3Comsec;
                        break;

                    case "VU1FMpre4Name":
                        currentVU1chan = VU1FMpre4Chan.Trim(myChar);
                        currentVU1freq = VU1FMpre4Freq.Trim(myChar);
                        currentVU1name = VU1FMpre4Name.Trim(myChar);
                        currentVU1ComsecVar = VU1FMpre4Comsec;
                        break;

                    case "VU1FMpre5Name":
                        currentVU1chan = VU1FMpre5Chan.Trim(myChar);
                        currentVU1freq = VU1FMpre5Freq.Trim(myChar);
                        currentVU1name = VU1FMpre5Name.Trim(myChar);
                        currentVU1ComsecVar = VU1FMpre5Comsec;
                        break;
                }
            }
            else if (VU1band == activeBand.AM)
            {
                recallVU1AMchan = currentVU1chan;
                recallVU1AMfreq = currentVU1freq;
                recallVU1AMname = currentVU1name;
                recallVU1Comsec = currentVU1ComsecVar;

                switch (e)
                {
                    case "VU1AMpre1Name":
                        currentVU1chan = VU1AMpre1Chan.Trim(myChar);
                        currentVU1freq = VU1AMpre1Freq.Trim(myChar);
                        currentVU1name = VU1AMpre1Name.Trim(myChar);
                        currentVU1ComsecVar = VU1AMpre1Comsec;
                        break;

                    case "VU1AMpre2Name":
                        currentVU1chan = VU1AMpre2Chan.Trim(myChar);
                        currentVU1freq = VU1AMpre2Freq.Trim(myChar);
                        currentVU1name = VU1AMpre2Name.Trim(myChar);
                        currentVU1ComsecVar = VU1AMpre2Comsec;
                        break;

                    case "VU1AMpre3Name":
                        currentVU1chan = VU1AMpre3Chan.Trim(myChar);
                        currentVU1freq = VU1AMpre3Freq.Trim(myChar);
                        currentVU1name = VU1AMpre3Name.Trim(myChar);
                        currentVU1ComsecVar = VU1AMpre3Comsec;
                        break;

                    case "VU1AMpre4Name":
                        currentVU1chan = VU1AMpre4Chan.Trim(myChar);
                        currentVU1freq = VU1AMpre4Freq.Trim(myChar);
                        currentVU1name = VU1AMpre4Name.Trim(myChar);
                        currentVU1ComsecVar = VU1AMpre4Comsec;
                        break;

                    case "VU1AMpre5Name":
                        currentVU1chan = VU1AMpre5Chan.Trim(myChar);
                        currentVU1freq = VU1AMpre5Freq.Trim(myChar);
                        currentVU1name = VU1AMpre5Name.Trim(myChar);
                        currentVU1ComsecVar = VU1AMpre5Comsec;
                        break;
                }
            }
            else if (VU1band == activeBand.HOPSETS)
            {
                recallVU1HOPchan = currentVU1chan;
                recallVU1HOPfreq = currentVU1freq;
                recallVU1HOPname = currentVU1name;
                recallVU1Comsec = currentVU1ComsecVar;

                switch (e)
                {
                    case "VU1HOPpre1Name":
                        currentVU1chan = VU1HOPpre1Chan.Trim(myChar);
                        currentVU1freq = VU1HOPpre1Freq.Trim(myChar);
                        currentVU1name = VU1HOPpre1Name.Trim(myChar);
                        currentVU1ComsecVar = VU1HOPpre1Comsec;
                        break;

                    case "VU1HOPpre2Name":
                        currentVU1chan = VU1HOPpre2Chan.Trim(myChar);
                        currentVU1freq = VU1HOPpre2Freq.Trim(myChar);
                        currentVU1name = VU1HOPpre2Name.Trim(myChar);
                        currentVU1ComsecVar = VU1HOPpre2Comsec;
                        break;

                    case "VU1HOPpre3Name":
                        currentVU1chan = VU1HOPpre3Chan.Trim(myChar);
                        currentVU1freq = VU1HOPpre3Freq.Trim(myChar);
                        currentVU1name = VU1HOPpre3Name.Trim(myChar);
                        currentVU1ComsecVar = VU1HOPpre3Comsec;
                        break;

                    case "VU1HOPpre4Name":
                        currentVU1chan = VU1HOPpre4Chan.Trim(myChar);
                        currentVU1freq = VU1HOPpre4Freq.Trim(myChar);
                        currentVU1name = VU1HOPpre4Name.Trim(myChar);
                        currentVU1ComsecVar = VU1HOPpre4Comsec;
                        break;

                    case "VU1HOPpre5Name":
                        currentVU1chan = VU1HOPpre5Chan.Trim(myChar);
                        currentVU1freq = VU1HOPpre5Freq.Trim(myChar);
                        currentVU1name = VU1HOPpre5Name.Trim(myChar);
                        currentVU1ComsecVar = VU1HOPpre5Comsec;
                        break;
                }
            }

        }

        private void UpdateVU2(string e)
        {
            Char[] myChar = { '<', ' ', '*' };

            recallVU2UHFchan = currentVU2chan;
            recallVU2UHFfreq = currentVU2freq;
            recallVU2UHFname = currentVU2name;
            recallVU2Comsec = currentVU2ComsecVar;

            switch (e)
            {
                case "VU2UHFpre1Name":
                    currentVU2chan = VU2UHFpre1Chan.Trim(myChar);
                    currentVU2freq = VU2UHFpre1Freq.Trim(myChar);
                    currentVU2name = VU2UHFpre1Name.Trim(myChar);
                    currentVU2ComsecVar = VU2UHFpre1Comsec;
                    break;

                case "VU2UHFpre2Name":
                    currentVU2chan = VU2UHFpre2Chan.Trim(myChar);
                    currentVU2freq = VU2UHFpre2Freq.Trim(myChar);
                    currentVU2name = VU2UHFpre2Name.Trim(myChar);
                    currentVU2ComsecVar = VU2UHFpre2Comsec;
                    break;

                case "VU2UHFpre3Name":
                    currentVU2chan = VU2UHFpre3Chan.Trim(myChar);
                    currentVU2freq = VU2UHFpre3Freq.Trim(myChar);
                    currentVU2name = VU2UHFpre3Name.Trim(myChar);
                    currentVU2ComsecVar = VU2UHFpre3Comsec;
                    break;

                case "VU2UHFpre4Name":
                    currentVU2chan = VU2UHFpre4Chan.Trim(myChar);
                    currentVU2freq = VU2UHFpre4Freq.Trim(myChar);
                    currentVU2name = VU2UHFpre4Name.Trim(myChar);
                    currentVU2ComsecVar = VU2UHFpre4Comsec;
                    break;

                case "VU2UHFpre5Name":
                    currentVU2chan = VU2UHFpre5Chan.Trim(myChar);
                    currentVU2freq = VU2UHFpre5Freq.Trim(myChar);
                    currentVU2name = VU2UHFpre5Name.Trim(myChar);
                    currentVU2ComsecVar = VU2UHFpre5Comsec;
                    break;
            }
        }

        private void PresetController()//used to update preset pages
        {
            //updates call sign
            if (scratchpad != "" & scratchpad != null)
            {
                if (currentPageTitle == "HF1 PRESET CHANNELS")
                {
                    if (!CheckValidity())
                    {
                        return;
                    }

                    if (pushedButton == l1Btn)
                    {
                        HFpre1Name = scratchpad;
                    }
                    else
                        if (pushedButton == l2Btn)
                        {
                            HFpre2Name = scratchpad;
                        }
                        else
                            if (pushedButton == l3Btn)
                            {
                                HFpre3Name = scratchpad;
                            }
                            else
                                if (pushedButton == l4Btn)
                                {
                                    HFpre4Name = scratchpad;
                                }
                                else
                                    if (pushedButton == l5Btn)
                                    {
                                        HFpre5Name = scratchpad;
                                    }
                                    else//update the frequencies
                                        if (pushedButton == r1Btn)
                                        {
                                            HFpre1Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                        }
                                        else
                                            if (pushedButton == r2Btn)
                                            {
                                                HFpre2Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                            }
                                            else
                                                if (pushedButton == r3Btn)
                                                {
                                                    HFpre3Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                }
                                                else
                                                    if (pushedButton == r4Btn)
                                                    {
                                                        HFpre4Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                    }
                                                    else
                                                        if (pushedButton == r5Btn)
                                                        {
                                                            HFpre5Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                        }


                    scratchpad = "";
                    sPad.Text = scratchpad;
                    StartFresh();
                    HFpresetChannelsPage1();
                    return;
                    //end HF section


                    //begin VU1 section
                }
                else
                    if (currentPageTitle == "V/U1 UHF")
                    {
                        if (!CheckValidity())
                        {
                            return;
                        }

                        if (pushedButton == l1Btn)
                        {
                            VU1UHFpre1Name = scratchpad;
                        }
                        else
                            if (pushedButton == l2Btn)
                            {
                                VU1UHFpre2Name = scratchpad;
                            }
                            else
                                if (pushedButton == l3Btn)
                                {
                                    VU1UHFpre3Name = scratchpad;
                                }
                                else
                                    if (pushedButton == l4Btn)
                                    {
                                        VU1UHFpre4Name = scratchpad;
                                    }
                                    else
                                        if (pushedButton == l5Btn)
                                        {
                                            VU1UHFpre5Name = scratchpad;
                                        }
                                        else//update the frequencies or COMSEC
                                            if (pushedButton == r1Btn)
                                            {
                                                if (scratchpad.Length > 3)
                                                {
                                                    VU1UHFpre1Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                }
                                                else
                                                {
                                                    VU1UHFpre1Comsec = scratchpad;
                                                }

                                            }
                                            else
                                                if (pushedButton == r2Btn)
                                                {
                                                    if (scratchpad.Length > 3)
                                                    {
                                                        VU1UHFpre2Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                    }
                                                    else
                                                    {
                                                        VU1UHFpre2Comsec = scratchpad;
                                                    }
                                                }
                                                else
                                                    if (pushedButton == r3Btn)
                                                    {
                                                        if (scratchpad.Length > 3)
                                                        {
                                                            VU1UHFpre3Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                        }
                                                        else
                                                        {
                                                            VU1UHFpre3Comsec = scratchpad;
                                                        }
                                                    }
                                                    else
                                                        if (pushedButton == r4Btn)
                                                        {
                                                            if (scratchpad.Length > 3)
                                                            {
                                                                VU1UHFpre4Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                            }
                                                            else
                                                            {
                                                                VU1UHFpre4Comsec = scratchpad;
                                                            }
                                                        }
                                                        else
                                                            if (pushedButton == r5Btn)
                                                            {
                                                                if (scratchpad.Length > 3)
                                                                {
                                                                    VU1UHFpre5Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                }
                                                                else
                                                                {
                                                                    VU1UHFpre5Comsec = scratchpad;
                                                                }
                                                            }


                        scratchpad = "";
                        sPad.Text = scratchpad;
                        StartFresh();
                        VU1uhfPresetsPage1();
                        return;
                        //end VU1 section


                        //begin VU2 section
                    }
                    else
                        if (currentPageTitle == "V/U1 VHF-FM")
                        {
                            if (!CheckValidity())
                            {
                                return;
                            }

                            if (pushedButton == l1Btn)
                            {
                                VU1FMpre1Name = scratchpad;
                            }
                            else
                                if (pushedButton == l2Btn)
                                {
                                    VU1FMpre2Name = scratchpad;
                                }
                                else
                                    if (pushedButton == l3Btn)
                                    {
                                        VU1FMpre3Name = scratchpad;
                                    }
                                    else
                                        if (pushedButton == l4Btn)
                                        {
                                            VU1FMpre4Name = scratchpad;
                                        }
                                        else
                                            if (pushedButton == l5Btn)
                                            {
                                                VU1FMpre5Name = scratchpad;
                                            }
                                            else//update the frequencies or COMSEC
                                                if (pushedButton == r1Btn)
                                                {
                                                    if (scratchpad.Length > 3)
                                                    {
                                                        VU1FMpre1Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                    }
                                                    else
                                                    {
                                                        VU1FMpre1Comsec = scratchpad;
                                                    }

                                                }
                                                else
                                                    if (pushedButton == r2Btn)
                                                    {
                                                        if (scratchpad.Length > 3)
                                                        {
                                                            VU1FMpre2Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                        }
                                                        else
                                                        {
                                                            VU1FMpre2Comsec = scratchpad;
                                                        }
                                                    }
                                                    else
                                                        if (pushedButton == r3Btn)
                                                        {
                                                            if (scratchpad.Length > 3)
                                                            {
                                                                VU1FMpre3Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                            }
                                                            else
                                                            {
                                                                VU1FMpre3Comsec = scratchpad;
                                                            }
                                                        }
                                                        else
                                                            if (pushedButton == r4Btn)
                                                            {
                                                                if (scratchpad.Length > 3)
                                                                {
                                                                    VU1FMpre4Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                }
                                                                else
                                                                {
                                                                    VU1FMpre4Comsec = scratchpad;
                                                                }
                                                            }
                                                            else
                                                                if (pushedButton == r5Btn)
                                                                {
                                                                    if (scratchpad.Length > 3)
                                                                    {
                                                                        VU1FMpre5Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                    }
                                                                    else
                                                                    {
                                                                        VU1FMpre5Comsec = scratchpad;
                                                                    }
                                                                }


                            scratchpad = "";
                            sPad.Text = scratchpad;
                            StartFresh();
                            VU1vhfFMpresetsPage1();
                            return;
                            //end VU1 section


                            //begin VU2 section
                        }

                        else
                            if (currentPageTitle == "V/U1 HOPSETS")
                            {
                                if (!CheckValidity())
                                {
                                    return;
                                }

                                if (pushedButton == l1Btn)
                                {
                                    VU1HOPpre1Name = scratchpad;
                                }
                                else
                                    if (pushedButton == l2Btn)
                                    {
                                        VU1HOPpre2Name = scratchpad;
                                    }
                                    else
                                        if (pushedButton == l3Btn)
                                        {
                                            VU1HOPpre3Name = scratchpad;
                                        }
                                        else
                                            if (pushedButton == l4Btn)
                                            {
                                                VU1HOPpre4Name = scratchpad;
                                            }
                                            else
                                                if (pushedButton == l5Btn)
                                                {
                                                    VU1HOPpre5Name = scratchpad;
                                                }
                                                else//update the frequencies or COMSEC
                                                    if (pushedButton == r1Btn)
                                                    {
                                                        if (scratchpad.Length > 3 || scratchpad.Contains("F"))
                                                        {
                                                            if (!scratchpad.Contains("F"))
                                                            {
                                                                VU1HOPpre1Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                            }
                                                            else
                                                            {
                                                                VU1HOPpre1Freq = scratchpad;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            VU1HOPpre1Comsec = scratchpad;
                                                        }

                                                    }
                                                    else
                                                        if (pushedButton == r2Btn)
                                                        {
                                                            if (scratchpad.Length > 3 || scratchpad.Contains("F"))
                                                                    {
                                                                        if (!scratchpad.Contains("F"))
                                                                        {
                                                                            VU1HOPpre2Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                        }
                                                                        else
                                                                        {
                                                                            VU1HOPpre2Freq = scratchpad;
                                                                        }
                                                                    }
                                                            else
                                                            {
                                                                VU1HOPpre2Comsec = scratchpad;
                                                            }
                                                        }
                                                        else
                                                            if (pushedButton == r3Btn)
                                                            {
                                                                if (scratchpad.Length > 3 || scratchpad.Contains("F"))
                                                                {
                                                                    if (!scratchpad.Contains("F"))
                                                                    {
                                                                        VU1HOPpre3Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                    }
                                                                    else
                                                                    {
                                                                        VU1HOPpre3Freq = scratchpad;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    VU1HOPpre3Comsec = scratchpad;
                                                                }
                                                            }
                                                            else
                                                                if (pushedButton == r4Btn )
                                                                {
                                                                    if (scratchpad.Length > 3 || scratchpad.Contains("F"))
                                                                    {
                                                                        if (!scratchpad.Contains("F"))
                                                                        {
                                                                            VU1HOPpre4Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                        }
                                                                        else
                                                                        {
                                                                            VU1HOPpre4Freq = scratchpad;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        VU1HOPpre4Comsec = scratchpad;
                                                                    }
                                                                }
                                                                else
                                                                    if (pushedButton == r5Btn)
                                                                    {
                                                                        if (scratchpad.Length > 3 || scratchpad.Contains("F"))
                                                                        {
                                                                            if (!scratchpad.Contains("F"))
                                                                            {
                                                                                VU1HOPpre5Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                            }
                                                                            else
                                                                            {
                                                                                VU1HOPpre5Freq = scratchpad;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            VU1HOPpre5Comsec = scratchpad;
                                                                        }
                                                                    }


                                scratchpad = "";
                                sPad.Text = scratchpad;
                                StartFresh();
                                VU1hopsetsPage1();
                                return;
                                //end VU1 section


                                //begin VU2 section
                            }

                            else
                                if (currentPageTitle == "V/U1 SATCOM")
                                {
                                    if (!CheckValidity())
                                    {
                                        return;
                                    }

                                    if (pushedButton == l1Btn)
                                    {
                                        VU1SatcomPre1Name = scratchpad;
                                    }
                                    else
                                        if (pushedButton == l2Btn)
                                        {
                                            VU1SatcomPre1SATchan = scratchpad;
                                        }
                                        else
                                            if (pushedButton == l3Btn)
                                            {
                                                VU1SatcomPre2Name = scratchpad;
                                            }
                                            else
                                                if (pushedButton == l4Btn)
                                                {
                                                    VU1SatcomPre2SATchan = scratchpad;
                                                }

                                                else//update the frequencies or COMSEC
                                                    if (pushedButton == r1Btn)
                                                    {
                                                        if (scratchpad.Length == 6)
                                                        {
                                                            VU1SatcomPre1Uplink = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                        }
                                                        else
                                                        {
                                                            VU1SatcomPre1Comsec = scratchpad;
                                                        }

                                                    }
                                                    else
                                                        if (pushedButton == r2Btn)
                                                        {
                                                            if (scratchpad.Length == 6)
                                                            {
                                                                VU1SatcomPre1Downlink = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                            }

                                                        }
                                                        else
                                                            if (pushedButton == r3Btn)
                                                            {
                                                                if (scratchpad.Length == 6)
                                                                {
                                                                    VU1SatcomPre2Uplink = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                }
                                                                else
                                                                {
                                                                    VU1SatcomPre2Comsec = scratchpad;
                                                                }
                                                            }
                                                            else
                                                                if (pushedButton == r4Btn)
                                                                {
                                                                    if (scratchpad.Length == 6)
                                                                    {
                                                                        VU1SatcomPre2Downlink = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                    }

                                                                }



                                    scratchpad = "";
                                    sPad.Text = scratchpad;
                                    StartFresh();
                                    VU1satcomPresetsPage1();
                                    return;
                                    //end VU1 section


                                    //begin VU2 section
                                }

                                else
                                    if (currentPageTitle == "V/U1 VHF-AM")
                                    {
                                        if (!CheckValidity())
                                        {
                                            return;
                                        }

                                        if (pushedButton == l1Btn)
                                        {
                                            VU1AMpre1Name = scratchpad;
                                        }
                                        else
                                            if (pushedButton == l2Btn)
                                            {
                                                VU1AMpre2Name = scratchpad;
                                            }
                                            else
                                                if (pushedButton == l3Btn)
                                                {
                                                    VU1AMpre3Name = scratchpad;
                                                }
                                                else
                                                    if (pushedButton == l4Btn)
                                                    {
                                                        VU1AMpre4Name = scratchpad;
                                                    }
                                                    else
                                                        if (pushedButton == l5Btn)
                                                        {
                                                            VU1AMpre5Name = scratchpad;
                                                        }
                                                        else//update the frequencies or COMSEC
                                                            if (pushedButton == r1Btn)
                                                            {
                                                                if (scratchpad.Length > 3)
                                                                {
                                                                    VU1AMpre1Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                }
                                                                else
                                                                {
                                                                    VU1AMpre1Comsec = scratchpad;
                                                                }

                                                            }
                                                            else
                                                                if (pushedButton == r2Btn)
                                                                {
                                                                    if (scratchpad.Length > 3)
                                                                    {
                                                                        VU1AMpre2Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                    }
                                                                    else
                                                                    {
                                                                        VU1AMpre2Comsec = scratchpad;
                                                                    }
                                                                }
                                                                else
                                                                    if (pushedButton == r3Btn)
                                                                    {
                                                                        if (scratchpad.Length > 3)
                                                                        {
                                                                            VU1AMpre3Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                        }
                                                                        else
                                                                        {
                                                                            VU1AMpre3Comsec = scratchpad;
                                                                        }
                                                                    }
                                                                    else
                                                                        if (pushedButton == r4Btn)
                                                                        {
                                                                            if (scratchpad.Length > 3)
                                                                            {
                                                                                VU1AMpre4Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                            }
                                                                            else
                                                                            {
                                                                                VU1AMpre4Comsec = scratchpad;
                                                                            }
                                                                        }
                                                                        else
                                                                            if (pushedButton == r5Btn)
                                                                            {
                                                                                if (scratchpad.Length > 3)
                                                                                {
                                                                                    VU1AMpre5Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                                }
                                                                                else
                                                                                {
                                                                                    VU1AMpre5Comsec = scratchpad;
                                                                                }
                                                                            }


                                        scratchpad = "";
                                        sPad.Text = scratchpad;
                                        StartFresh();
                                        VU1vhfAMpresetsPage1();
                                        return;
                                        //end VU1 section


                                        //begin VU2 section
                                    }


                                    else
                                        if (currentPageTitle == "V/U2 UHF")
                                        {
                                            if (!CheckValidity())
                                            {
                                                return;
                                            }

                                            if (pushedButton == l1Btn)
                                            {
                                                VU2UHFpre1Name = scratchpad;
                                            }
                                            else
                                                if (pushedButton == l2Btn)
                                                {
                                                    VU2UHFpre2Name = scratchpad;
                                                }
                                                else
                                                    if (pushedButton == l3Btn)
                                                    {
                                                        VU2UHFpre3Name = scratchpad;
                                                    }
                                                    else
                                                        if (pushedButton == l4Btn)
                                                        {
                                                            VU2UHFpre4Name = scratchpad;
                                                        }
                                                        else
                                                            if (pushedButton == l5Btn)
                                                            {
                                                                VU2UHFpre5Name = scratchpad;
                                                            }
                                                            else//update the frequencies or COMSEC
                                                                if (pushedButton == r1Btn)
                                                                {
                                                                    if (scratchpad.Length > 3)
                                                                    {
                                                                        VU2UHFpre1Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                    }
                                                                    else
                                                                    {
                                                                        VU2UHFpre1Comsec = scratchpad;
                                                                    }

                                                                }
                                                                else
                                                                    if (pushedButton == r2Btn)
                                                                    {
                                                                        if (scratchpad.Length > 3)
                                                                        {
                                                                            VU2UHFpre2Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                        }
                                                                        else
                                                                        {
                                                                            VU2UHFpre2Comsec = scratchpad;
                                                                        }
                                                                    }
                                                                    else
                                                                        if (pushedButton == r3Btn)
                                                                        {
                                                                            if (scratchpad.Length > 3)
                                                                            {
                                                                                VU2UHFpre3Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                            }
                                                                            else
                                                                            {
                                                                                VU2UHFpre3Comsec = scratchpad;
                                                                            }
                                                                        }
                                                                        else
                                                                            if (pushedButton == r4Btn)
                                                                            {
                                                                                if (scratchpad.Length > 3)
                                                                                {
                                                                                    VU2UHFpre4Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                                }
                                                                                else
                                                                                {
                                                                                    VU2UHFpre4Comsec = scratchpad;
                                                                                }
                                                                            }
                                                                            else
                                                                                if (pushedButton == r5Btn)
                                                                                {
                                                                                    if (scratchpad.Length > 3)
                                                                                    {
                                                                                        VU2UHFpre5Freq = scratchpad.Insert(scratchpad.Length - 3, ".");
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        VU2UHFpre5Comsec = scratchpad;
                                                                                    }
                                                                                }


                                            scratchpad = "";
                                            sPad.Text = scratchpad;
                                            StartFresh();
                                            VU2uhfPresetsPage1();
                                            return;
                                        }



            }
            if (currentPageTitle == "HF1 PRESET CHANNELS")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentHFchanName = HFpre1Name;
                        currentHFchan = HFpre1Chan.Trim('<', ' ', '*');
                        currentHFfreq = HFpre1Freq;
                    }

                    if (pushedButton == l2Btn)
                    {
                        currentHFchanName = HFpre2Name;
                        currentHFchan = HFpre2Chan.Trim('<', ' ', '*');
                        currentHFfreq = HFpre2Freq;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentHFchanName = HFpre3Name;
                        currentHFchan = HFpre3Chan.Trim('<', ' ', '*');
                        currentHFfreq = HFpre3Freq;
                    }

                    if (pushedButton == l4Btn)
                    {
                        currentHFchanName = HFpre4Name;
                        currentHFchan = HFpre4Chan.Trim('<', ' ', '*');
                        currentHFfreq = HFpre4Freq;
                    }

                    if (pushedButton == l5Btn)
                    {
                        currentHFchanName = HFpre5Name;
                        currentHFchan = HFpre5Chan.Trim('<', ' ', '*');
                        currentHFfreq = HFpre5Freq;
                    }



                    StartFresh();
                    HFcontrolPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    hfRecallFreq = currentHFfreq;
                    hfRecallName = currentHFchanName;
                    hfRecallChan = currentHFchan;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentHFchan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            HFpre1Chan = "* " + l1text;
                            basSelChanVar = l1text;
                            currentHFchanName = HFpre1Name;
                            currentHFchan = l1text;
                            currentHFfreq = HFpre1Freq;
                        }
                    }
                    if (pushedButton == l2Btn || currentHFchan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            HFpre2Chan = "* " + l2text;
                            basSelChanVar = l2text;
                            currentHFchanName = HFpre2Name;
                            currentHFchan = l2text;
                            currentHFfreq = HFpre2Freq;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            HFpre3Chan = "* " + l3text;
                            basSelChanVar = l3text;
                            currentHFchanName = HFpre3Name;
                            currentHFchan = l3text;
                            currentHFfreq = HFpre3Freq;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            HFpre4Chan = "* " + l4text;
                            basSelChanVar = l4text;
                            currentHFchanName = HFpre4Name;
                            currentHFchan = l4text;
                            currentHFfreq = HFpre4Freq;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            HFpre5Chan = "* " + l5text;
                            basSelChanVar = l5text;
                            currentHFchanName = HFpre5Name;
                            currentHFchan = l5text;
                            currentHFfreq = HFpre5Freq;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        HFpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        HFpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        HFpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        HFpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        HFpre5Chan = "<" + l5text;
                    }
                }



                StartFresh();
                HFpresetChannelsPage1();
            }

            if (currentPageTitle == "HF1 ALE PRESET CHAN")
            {
                ALEpresetController();
            }

            if (currentPageTitle == "V/U1 UHF" || currentPageTitle == "V/U1 VHF-FM" || currentPageTitle == "V/U1 VHF-AM" || currentPageTitle == "V/U1 SATCOM" || currentPageTitle == "V/U1 HOPSETS")
            {
                VU1PresetController();
            }

            if (currentPageTitle == "V/U2 UHF" || currentPageTitle == "V/U2 VHF-FM" || currentPageTitle == "V/U2 VHF-AM" || currentPageTitle == "V/U2 SATCOM" || currentPageTitle == "V/U2 HOPSETS")
            {
                VU2PresetController();
            }

        }

        private void ALEpresetController()
        {
            if (scratchpad != null & scratchpad != "")
            {
                if (currentPageTitle == "HF1 ALE PRESET CHAN")
                {
                    if (!CheckValidity())
                    {
                        return;
                    }

                    if (pushedButton == l1Btn)
                    {
                        ALEpre1Name = scratchpad;
                    }
                    else
                        if (pushedButton == l2Btn)
                        {
                            ALEpre2Name = scratchpad;
                        }
                        else
                            if (pushedButton == l3Btn)
                            {
                                ALEpre3Name = scratchpad;
                            }
                            else
                                if (pushedButton == l4Btn)
                                {
                                    ALEpre4Name = scratchpad;
                                }
                                else
                                    if (pushedButton == l5Btn)
                                    {
                                        ALEpre5Name = scratchpad;
                                    }
                                    else//update the frequencies
                                        if (pushedButton == r1Btn)
                                        {
                                            ALEpre1Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                        }
                                        else
                                            if (pushedButton == r2Btn)
                                            {
                                                ALEpre2Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                            }
                                            else
                                                if (pushedButton == r3Btn)
                                                {
                                                    ALEpre3Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                }
                                                else
                                                    if (pushedButton == r4Btn)
                                                    {
                                                        ALEpre4Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                    }
                                                    else
                                                        if (pushedButton == r5Btn)
                                                        {
                                                            ALEpre5Freq = scratchpad.Insert(scratchpad.Length - 4, ".");
                                                        }


                    scratchpad = "";
                    sPad.Text = scratchpad;
                    StartFresh();
                    HFALEpresetChannelsPage1();
                    return;
                }
            }
            //return to HF Control Page
            if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
            {
                StartFresh();
                HFcontrolPage1();
                return;
            }
            else
            {
                char[] toTrim = { '<', ' ' };
                if (pushedButton == l1Btn)
                {
                    if (l1text.Contains("<"))
                    {
                        l1text = l1text.TrimStart(toTrim);
                        ALEpre1Chan = "* " + l1text;
                        aleChanVar = l1text;
                        currentALEname = ALEpre1Name;
                        currentALEchan = l1text;
                        currentALEfreq = ALEpre1Freq;
                    }
                }
                if (pushedButton == l2Btn)
                {
                    if (l2text.Contains("<"))
                    {
                        l2text = l2text.TrimStart(toTrim);
                        ALEpre2Chan = "* " + l2text;
                        aleChanVar = l2text;
                        currentALEname = ALEpre2Name;
                        currentALEchan = l2text;
                        currentALEfreq = ALEpre2Freq;
                    }
                }
                if (pushedButton == l3Btn)
                {
                    if (l3text.Contains("<"))
                    {
                        l3text = l3text.TrimStart(toTrim);
                        ALEpre3Chan = "* " + l3text;
                        aleChanVar = l3text;
                        currentALEname = ALEpre3Name;
                        currentALEchan = l3text;
                        currentALEfreq = ALEpre3Freq;
                    }
                }
                if (pushedButton == l4Btn)
                {
                    if (l4text.Contains("<"))
                    {
                        l4text = l4text.TrimStart(toTrim);
                        ALEpre4Chan = "* " + l4text;
                        aleChanVar = l4text;
                        currentALEname = ALEpre4Name;
                        currentALEchan = l4text;
                        currentALEfreq = ALEpre4Freq;
                    }
                }
                if (pushedButton == l5Btn)
                {
                    if (l5text.Contains("<"))
                    {
                        l5text = l5text.TrimStart(toTrim);
                        ALEpre5Chan = "* " + l5text;
                        aleChanVar = l5text;
                        currentALEname = ALEpre5Name;
                        currentALEchan = l5text;
                        currentALEfreq = ALEpre5Freq;
                    }
                }

                //reset the others
                char[] toCut = { '*' };

                if (l1text.Contains("*") & pushedButton != l1Btn)
                {
                    l1text = l1text.TrimStart(toCut);
                    ALEpre1Chan = "<" + l1text;
                }
                if (l2text.Contains("*") & pushedButton != l2Btn)
                {
                    l2text = l2text.TrimStart(toCut);
                    ALEpre2Chan = "<" + l2text;
                }
                if (l3text.Contains("*") & pushedButton != l3Btn)
                {
                    l3text = l3text.TrimStart(toCut);
                    ALEpre3Chan = "<" + l3text;
                }
                if (l4text.Contains("*") & pushedButton != l4Btn)
                {
                    l4text = l4text.TrimStart(toCut);
                    ALEpre4Chan = "<" + l4text;
                }
                if (l5text.Contains("*") & pushedButton != l5Btn)
                {
                    l5text = l5text.TrimStart(toCut);
                    ALEpre5Chan = "<" + l5text;
                }
            }



            StartFresh();
            HFALEpresetChannelsPage1();
        }

        private bool SearchCallSign(string e)
        {
            switch (currentPageTitle)
            {
                case "V/U2 CONTROL":
                    #region VU2 section
                    if (pushedButton == l1Btn)
                    {
                        if (scratchpad == VU2UHFpre1Name)
                        {
                            UpdateVU2("VU2UHFpre1Name");
                            return true;
                        }
                        else
                            if (scratchpad == VU2UHFpre2Name)
                            {
                                UpdateVU2("VU2UHFpre2Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2UHFpre3Name)
                                {
                                    UpdateVU2("VU2UHFpre3Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2UHFpre4Name)
                                    {
                                        UpdateVU2("VU2UHFpre4Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2UHFpre5Name)
                                        {
                                            UpdateVU2("VU2UHFpre5Name");
                                            return true;
                                        }
                                        else
                                        {

                                            return false;
                                        }
                    #endregion

                    }
                    break;


                case "V/U1 CONTROL":
                    #region VU1 section
                    if (VU1band == activeBand.UHF)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1UHFpre1Name)
                            {
                                UpdateVU1("VU1UHFpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1UHFpre2Name)
                                {
                                    UpdateVU1("VU1UHFpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1UHFpre3Name)
                                    {
                                        UpdateVU1("VU1UHFpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1UHFpre4Name)
                                        {
                                            UpdateVU1("VU1UHFpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1UHFpre5Name)
                                            {
                                                UpdateVU1("VU1UHFpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.FM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1FMpre1Name)
                            {
                                UpdateVU1("VU1FMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1FMpre2Name)
                                {
                                    UpdateVU1("VU1FMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1FMpre3Name)
                                    {
                                        UpdateVU1("VU1FMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1FMpre4Name)
                                        {
                                            UpdateVU1("VU1FMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1FMpre5Name)
                                            {
                                                UpdateVU1("VU1FMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.AM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1AMpre1Name)
                            {
                                UpdateVU1("VU1AMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1AMpre2Name)
                                {
                                    UpdateVU1("VU1AMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1AMpre3Name)
                                    {
                                        UpdateVU1("VU1AMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1AMpre4Name)
                                        {
                                            UpdateVU1("VU1AMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1AMpre5Name)
                                            {
                                                UpdateVU1("VU1AMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.HOPSETS)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1HOPpre1Name)
                            {
                                UpdateVU1("VU1HOPpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1HOPpre2Name)
                                {
                                    UpdateVU1("VU1HOPpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1HOPpre3Name)
                                    {
                                        UpdateVU1("VU1HOPpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1HOPpre4Name)
                                        {
                                            UpdateVU1("VU1HOPpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1HOPpre5Name)
                                            {
                                                UpdateVU1("VU1HOPpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    #endregion
                    break;

                case "comm":
                    #region HF section
                    if (pushedButton == l3Btn & hfMode != "ALE")
                    {
                        if (scratchpad == HFpre1Name)
                        {
                            UpdateFreqs("pre1Name");
                            return true;
                        }
                        else
                            if (scratchpad == HFpre2Name)
                            {
                                UpdateFreqs("pre2Name");
                                return true;
                            }
                            else
                                if (scratchpad == HFpre3Name)
                                {
                                    UpdateFreqs("pre3Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == HFpre4Name)
                                    {
                                        UpdateFreqs("pre4Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == HFpre5Name)
                                        {
                                            UpdateFreqs("pre5Name");
                                            return true;
                                        }
                                        else
                                        {

                                            return false;
                                        }

                    }
                    #endregion
                    else
                        #region ALE section
                        if (pushedButton == l3Btn & hfMode == "ALE")
                        {
                            if (scratchpad == ALEpre1Name)
                            {
                                UpdateALEfreqs("ALEpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == ALEpre2Name)
                                {
                                    UpdateALEfreqs("ALEpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == ALEpre3Name)
                                    {
                                        UpdateALEfreqs("ALEpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == ALEpre4Name)
                                        {
                                            UpdateALEfreqs("ALEpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == ALEpre5Name)
                                            {
                                                UpdateALEfreqs("ALEpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }
                        #endregion

                        }
                        else
                            #region VU1 section
                            if (pushedButton == l1Btn)
                            {
                                if (scratchpad == VU1UHFpre1Name)
                                {
                                    UpdateVU1("VU1UHFpre1Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1UHFpre2Name)
                                    {
                                        UpdateVU1("VU1UHFpre2Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1UHFpre3Name)
                                        {
                                            UpdateVU1("VU1UHFpre3Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1UHFpre4Name)
                                            {
                                                UpdateVU1("VU1UHFpre4Name");
                                                return true;
                                            }
                                            else
                                                if (scratchpad == VU1UHFpre5Name)
                                                {
                                                    UpdateVU1("VU1UHFpre5Name");
                                                    return true;
                                                }
                                                else
                                                {

                                                    return false;
                                                }
                            #endregion

                            }
                            else
                                #region VU2 section
                                if (pushedButton == l2Btn)
                                {
                                    if (scratchpad == VU2UHFpre1Name)
                                    {
                                        UpdateVU2("VU2UHFpre1Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2UHFpre2Name)
                                        {
                                            UpdateVU2("VU2UHFpre2Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU2UHFpre3Name)
                                            {
                                                UpdateVU2("VU2UHFpre3Name");
                                                return true;
                                            }
                                            else
                                                if (scratchpad == VU2UHFpre4Name)
                                                {
                                                    UpdateVU2("VU2UHFpre4Name");
                                                    return true;
                                                }
                                                else
                                                    if (scratchpad == VU2UHFpre5Name)
                                                    {
                                                        UpdateVU2("VU2UHFpre5Name");
                                                        return true;
                                                    }
                                                    else
                                                    {

                                                        return false;
                                                    }
                                #endregion

                                }


                    break;

            }
            return false;
        }

        private void UpdateALEfreqs(string e)
        {
            Char[] myChar = { '<', ' ', '*' };

            ALERecallChan = currentALEchan;
            ALERecallFreq = currentALEfreq;
            ALERecallName = currentALEname;

            switch (e)
            {
                case "ALEpre1Name":
                    currentALEchan = ALEpre1Chan.Trim(myChar);
                    currentALEfreq = ALEpre1Freq.Trim(myChar);
                    currentALEname = ALEpre1Name.Trim(myChar);
                    break;

                case "ALEpre2Name":
                    currentALEchan = ALEpre2Chan.Trim(myChar);
                    currentALEfreq = ALEpre2Freq.Trim(myChar);
                    currentALEname = ALEpre2Name.Trim(myChar);
                    break;

                case "ALEpre3Name":
                    currentALEchan = ALEpre3Chan.Trim(myChar);
                    currentALEfreq = ALEpre3Freq.Trim(myChar);
                    currentALEname = ALEpre3Name.Trim(myChar);
                    break;

                case "ALEpre4Name":
                    currentALEchan = ALEpre4Chan.Trim(myChar);
                    currentALEfreq = ALEpre4Freq.Trim(myChar);
                    currentALEname = ALEpre4Name.Trim(myChar);
                    break;

                case "ALEpre5Name":
                    currentALEchan = ALEpre5Chan.Trim(myChar);
                    currentALEfreq = ALEpre5Freq.Trim(myChar);
                    currentALEname = ALEpre5Name.Trim(myChar);
                    break;
            }
        }

        private bool SearchChannelNumbers(string e)
        {
            Char[] myChar = { '<', ' ', '*' };

            switch (currentPageTitle)
            {
                case "V/U2 CONTROL":
                    #region VU2 section
                    if (VU2band == activeBand.UHF)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU2UHFpre1Chan.Trim(myChar))
                            {
                                UpdateVU2("VU2UHFpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2UHFpre2Chan.Trim(myChar))
                                {
                                    UpdateVU2("VU2UHFpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2UHFpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU2("VU2UHFpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2UHFpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU2("VU2UHFpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU2UHFpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU2("VU2UHFpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU2band == activeBand.FM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU2FMpre1Chan.Trim(myChar))
                            {
                                UpdateVU2("VU2FMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2FMpre2Chan.Trim(myChar))
                                {
                                    UpdateVU2("VU2FMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2FMpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU2("VU2FMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2FMpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU2("VU2FMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU2FMpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU2("VU2FMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU2band == activeBand.AM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU2AMpre1Chan.Trim(myChar))
                            {
                                UpdateVU2("VU2AMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2AMpre2Chan.Trim(myChar))
                                {
                                    UpdateVU2("VU2AMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2AMpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU2("VU2AMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2AMpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU2("VU2AMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU2AMpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU2("VU2AMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU2band == activeBand.HOPSETS)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU2HOPpre1Chan.Trim(myChar))
                            {
                                UpdateVU2("VU2HOPpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2HOPpre2Chan.Trim(myChar))
                                {
                                    UpdateVU2("VU2HOPpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2HOPpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU2("VU2HOPpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2HOPpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU2("VU2HOPpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU2HOPpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU2("VU2HOPpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    #endregion
                    break;


                case "V/U1 CONTROL":
                    #region VU1 section
                    if (VU1band == activeBand.UHF)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1UHFpre1Chan.Trim(myChar))
                            {
                                UpdateVU1("VU1UHFpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1UHFpre2Chan.Trim(myChar))
                                {
                                    UpdateVU1("VU1UHFpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1UHFpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU1("VU1UHFpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1UHFpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU1("VU1UHFpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1UHFpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU1("VU1UHFpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.FM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1FMpre1Chan.Trim(myChar))
                            {
                                UpdateVU1("VU1FMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1FMpre2Chan.Trim(myChar))
                                {
                                    UpdateVU1("VU1FMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1FMpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU1("VU1FMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1FMpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU1("VU1FMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1FMpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU1("VU1FMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.AM)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1AMpre1Chan.Trim(myChar))
                            {
                                UpdateVU1("VU1AMpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1AMpre2Chan.Trim(myChar))
                                {
                                    UpdateVU1("VU1AMpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1AMpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU1("VU1AMpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1AMpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU1("VU1AMpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1AMpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU1("VU1AMpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    else if (VU1band == activeBand.HOPSETS)
                    {
                        if (pushedButton == l1Btn)
                        {
                            if (scratchpad == VU1HOPpre1Chan.Trim(myChar))
                            {
                                UpdateVU1("VU1HOPpre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1HOPpre2Chan.Trim(myChar))
                                {
                                    UpdateVU1("VU1HOPpre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1HOPpre3Chan.Trim(myChar))
                                    {
                                        UpdateVU1("VU1HOPpre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1HOPpre4Chan.Trim(myChar))
                                        {
                                            UpdateVU1("VU1HOPpre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == VU1HOPpre5Chan.Trim(myChar))
                                            {
                                                UpdateVU1("VU1HOPpre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    #endregion
                    break;


                case "comm":
                    #region HF section
                    if (hfMode != "ALE")
                    {
                        if (pushedButton == l3Btn)
                        {
                            if (scratchpad == HFpre1Chan.Trim(myChar))
                            {
                                UpdateFreqs("pre1Name");
                                return true;
                            }
                            else
                                if (scratchpad == HFpre2Chan.Trim(myChar))
                                {
                                    UpdateFreqs("pre2Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == HFpre3Chan.Trim(myChar))
                                    {
                                        UpdateFreqs("pre3Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == HFpre4Chan.Trim(myChar))
                                        {
                                            UpdateFreqs("pre4Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == HFpre5Chan.Trim(myChar))
                                            {
                                                UpdateFreqs("pre5Name");
                                                return true;
                                            }
                                            else
                                            {

                                                return false;
                                            }

                        }
                    }
                    #endregion
                    else
                        if (hfMode == "ALE")
                        {
                            if (pushedButton == l3Btn)
                            {
                                if (scratchpad == ALEpre1Chan.Trim(myChar))
                                {
                                    UpdateFreqs("pre1Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == ALEpre2Chan.Trim(myChar))
                                    {
                                        UpdateFreqs("pre2Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == ALEpre3Chan.Trim(myChar))
                                        {
                                            UpdateFreqs("pre3Name");
                                            return true;
                                        }
                                        else
                                            if (scratchpad == ALEpre4Chan.Trim(myChar))
                                            {
                                                UpdateFreqs("pre4Name");
                                                return true;
                                            }
                                            else
                                                if (scratchpad == ALEpre5Chan.Trim(myChar))
                                                {
                                                    UpdateFreqs("pre5Name");
                                                    return true;
                                                }
                                                else
                                                {

                                                    return false;
                                                }

                            }
                        }





                    #region VU1 section
                    if (pushedButton == l1Btn)
                    {
                        if (scratchpad == VU1UHFpre1Chan.Trim(myChar))
                        {
                            UpdateVU1("VU1UHFpre1Name");
                            return true;
                        }
                        else
                            if (scratchpad == VU1UHFpre2Chan.Trim(myChar))
                            {
                                UpdateVU1("VU1UHFpre2Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU1UHFpre3Chan.Trim(myChar))
                                {
                                    UpdateVU1("VU1UHFpre3Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU1UHFpre4Chan.Trim(myChar))
                                    {
                                        UpdateVU1("VU1UHFpre4Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU1UHFpre5Chan.Trim(myChar))
                                        {
                                            UpdateVU1("VU1UHFpre5Name");
                                            return true;
                                        }
                                        else
                                        {

                                            return false;
                                        }
                    #endregion




                    }

                    #region VU2 section
                    if (pushedButton == l2Btn)
                    {
                        if (scratchpad == VU2UHFpre1Chan.Trim(myChar))
                        {
                            UpdateVU2("VU2UHFpre1Name");
                            return true;
                        }
                        else
                            if (scratchpad == VU2UHFpre2Chan.Trim(myChar))
                            {
                                UpdateVU2("VU2UHFpre2Name");
                                return true;
                            }
                            else
                                if (scratchpad == VU2UHFpre3Chan.Trim(myChar))
                                {
                                    UpdateVU2("VU2UHFpre3Name");
                                    return true;
                                }
                                else
                                    if (scratchpad == VU2UHFpre4Chan.Trim(myChar))
                                    {
                                        UpdateVU2("VU2UHFpre4Name");
                                        return true;
                                    }
                                    else
                                        if (scratchpad == VU2UHFpre5Chan.Trim(myChar))
                                        {
                                            UpdateVU2("VU2UHFpre5Name");
                                            return true;
                                        }
                                        else
                                        {

                                            return false;
                                        }
                    #endregion




                    }


                    break;


            }
            return false;
        }

        private void UpdateFreqswithRightBtnPush()
        {
            if (pushedButton == r3Btn)//HF 
            {
                if (hfMode == "ALE")
                {
                    currentALEfreq = scratchpad.Insert(scratchpad.Length - 4, ".");

                    if (currentALEchan == ALEpre1Chan.Trim('<', ' ', '*'))
                    {
                        ALEpre1Freq = currentALEfreq;
                    }
                    else
                        if (currentALEchan == ALEpre2Chan.Trim('<', ' ', '*'))
                        {
                            ALEpre2Freq = currentALEfreq;
                        }
                        else
                            if (currentALEchan == ALEpre3Chan.Trim('<', ' ', '*'))
                            {
                                ALEpre3Freq = currentALEfreq;
                            }
                            else
                                if (currentALEchan == ALEpre4Chan.Trim('<', ' ', '*'))
                                {
                                    ALEpre4Freq = currentALEfreq;
                                }
                                else
                                    if (currentALEchan == ALEpre5Chan.Trim('<', ' ', '*'))
                                    {
                                        ALEpre5Freq = currentALEfreq;
                                    }
                }

                if (hfMode != "ALE")
                {
                    currentHFfreq = scratchpad.Insert(scratchpad.Length - 4, ".");

                    if (currentHFchan == HFpre1Chan.Trim('<', ' ', '*'))
                    {
                        HFpre1Freq = currentHFfreq;
                    }
                    else
                        if (currentHFchan == HFpre2Chan.Trim('<', ' ', '*'))
                        {
                            HFpre2Freq = currentHFfreq;
                        }
                        else
                            if (currentHFchan == HFpre3Chan.Trim('<', ' ', '*'))
                            {
                                HFpre3Freq = currentHFfreq;
                            }
                            else
                                if (currentHFchan == HFpre4Chan.Trim('<', ' ', '*'))
                                {
                                    HFpre4Freq = currentHFfreq;
                                }
                                else
                                    if (currentHFchan == HFpre5Chan.Trim('<', ' ', '*'))
                                    {
                                        HFpre5Freq = currentHFfreq;
                                    }
                }
            }// end HF
            else
                if (pushedButton == r2Btn || currentPageTitle == "V/U2 CONTROL")//VU2
                {
                    if (BandSelection(currentVU2freq, "VU2") == "U")//verifies the band is UHF
                    {
                        currentVU2freq = scratchpad.Insert(scratchpad.Length - 3, ".");

                        if (currentVU2chan == VU2UHFpre1Chan.Trim('<', ' ', '*'))
                        {
                            VU2UHFpre1Freq = currentVU2freq;
                        }
                        else
                            if (currentVU2chan == VU2UHFpre2Chan.Trim('<', ' ', '*'))
                            {
                                VU2UHFpre2Freq = currentVU2freq;
                            }
                            else
                                if (currentVU2chan == VU2UHFpre3Chan.Trim('<', ' ', '*'))
                                {
                                    VU2UHFpre3Freq = currentVU2freq;
                                }
                                else
                                    if (currentVU2chan == VU2UHFpre4Chan.Trim('<', ' ', '*'))
                                    {
                                        VU2UHFpre4Freq = currentVU2freq;
                                    }
                                    else
                                        if (currentVU2chan == VU2UHFpre5Chan.Trim('<', ' ', '*'))
                                        {
                                            VU2UHFpre5Freq = currentVU2freq;
                                        }
                    }

                }
                else
                    if (pushedButton == r1Btn)//VU1
                    {
                        if (BandSelection(currentVU1freq, "VU1") == "U")//verifies the band is UHF
                        {
                            currentVU1freq = scratchpad.Insert(scratchpad.Length - 3, ".");

                            if (currentVU1chan == VU1UHFpre1Chan.Trim('<', ' ', '*'))
                            {
                                VU1UHFpre1Freq = currentVU1freq;
                            }
                            else
                                if (currentVU1chan == VU1UHFpre2Chan.Trim('<', ' ', '*'))
                                {
                                    VU1UHFpre2Freq = currentVU1freq;
                                }
                                else
                                    if (currentVU1chan == VU1UHFpre3Chan.Trim('<', ' ', '*'))
                                    {
                                        VU1UHFpre3Freq = currentVU1freq;
                                    }
                                    else
                                        if (currentVU1chan == VU1UHFpre4Chan.Trim('<', ' ', '*'))
                                        {
                                            VU1UHFpre4Freq = currentVU1freq;
                                        }
                                        else
                                            if (currentVU1chan == VU1UHFpre5Chan.Trim('<', ' ', '*'))
                                            {
                                                VU1UHFpre5Freq = currentVU1freq;
                                            }
                        }
                    }
        }

        private bool CheckFreqFormat(string e)
        {


            switch (e)
            {

                case "HF":
                    if (ContainsCharacters() == false & ContainsLetters() == false & (scratchpad.Length <= 6) == true & (scratchpad.Length >= 5) == true)
                    {
                        try
                        {
                            int x = Convert.ToInt32(scratchpad);
                            if ((x <= 299999) == true & (x >= 20000) == true)
                            {
                                return true;
                            }
                        }
                        catch
                        {

                        }

                    }
                    break;

                case "COMSEC":
                    if (ContainsLetters() == true & ContainsNumbers() == true & (scratchpad.Length == 2 || scratchpad.Length == 3))
                    {
                        string x = scratchpad.Substring(0, 1);
                        if (x == "C" || x == "P")
                        {
                            string y = scratchpad.Substring(1);
                            int z = Convert.ToInt32(y);
                            if (z >= 1 & z <= 19)
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case "UHF":
                    if (ContainsCharacters() == false & ContainsLetters() == false & scratchpad.Length == 6)
                    {
                        try
                        {
                            int x = Convert.ToInt32(scratchpad);
                            if ((x >= 225000) == true & (x <= 399995) == true)
                            {
                                return true;
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;
            }

            return false;
        }



        private void CheckPresets()
        {
            if (currentPageTitle == "V/U1 CONTROL")
            {
                //determine which preset page to go to
                if (scratchpad == null || scratchpad == "")
                {
                    #region MyRegion
                    if (VU1band == activeBand.FM)//BandSelection(currentVU1freq) == "F"
                    {
                        StartFresh();
                        VU1vhfFMpresetsPage1();

                    }
                    else
                        if (BandSelection(currentVU1freq, "VU1") == "V")
                        {
                            StartFresh();
                            VU1vhfAMpresetsPage1();

                        }
                        else
                            if (VU1band == activeBand.UHF)//BandSelection(currentVU1freq) == "U"
                            {
                                StartFresh();
                                VU1uhfPresetsPage1();

                            }
                            else
                                if (BandSelection(currentVU1freq, "VU1") == "S")
                                {
                                    StartFresh();
                                    VU1satcomPresetsPage1();

                                }
                                else
                                    if (BandSelection(currentVU1freq, "VU1") == "E")
                                    {
                                        StartFresh();
                                        VU1hopsetsPage1();

                                    }
                    #endregion
                }
                else
                    #region Looks for scratchpad inputs
                    if (scratchpad == "F")
                    {
                        StartFresh();
                        VU1vhfFMpresetsPage1();
                    }
                    else
                        if (scratchpad == "V")
                        {
                            StartFresh();
                            VU1vhfAMpresetsPage1();

                        }
                        else
                            if (scratchpad == "U")
                            {
                                StartFresh();
                                VU1uhfPresetsPage1();

                            }
                            else
                                if (scratchpad == "S")
                                {
                                    StartFresh();
                                    VU1satcomPresetsPage1();
                                }
                                else
                                    if (scratchpad == "E")
                                    {
                                        StartFresh();
                                        VU1hopsetsPage1();

                                    }
                    #endregion

                //resets the scratchpad and sPad
                scratchpad = null;
                sPad.Text = scratchpad;

            }
            else
                if (currentPageTitle == "V/U2 CONTROL")
                {
                    //determine which preset page to go to
                    if (scratchpad == null || scratchpad == "")
                    {
                        #region MyRegion
                        if (BandSelection(currentVU2freq, "VU2") == "F")
                        {
                            StartFresh();
                            VU2vhfFMpresetsPage1();

                        }
                        else
                            if (BandSelection(currentVU2freq, "VU2") == "V")
                            {
                                StartFresh();
                                VU2vhfAMpresetsPage1();

                            }
                            else
                                if (BandSelection(currentVU2freq, "VU2") == "U")
                                {
                                    StartFresh();
                                    VU2uhfPresetsPage1();

                                }
                                else
                                    if (BandSelection(currentVU2freq, "VU2") == "S")
                                    {
                                        StartFresh();
                                        VU2satcomPresetsPage1();

                                    }
                                    else
                                        if (BandSelection(currentVU2freq, "VU2") == "E")
                                        {
                                            StartFresh();
                                            VU2hopsetsPage1();

                                        }
                        #endregion
                    }
                    else
                        #region Looks for scratchpad inputs
                        if (scratchpad == "F")
                        {
                            StartFresh();
                            VU2vhfFMpresetsPage1();
                        }
                        else
                            if (scratchpad == "V")
                            {
                                StartFresh();
                                VU2vhfAMpresetsPage1();

                            }
                            else
                                if (scratchpad == "U")
                                {
                                    StartFresh();
                                    VU2uhfPresetsPage1();

                                }
                                else
                                    if (scratchpad == "S")
                                    {
                                        StartFresh();
                                        VU2satcomPresetsPage1();
                                    }
                                    else
                                        if (scratchpad == "E")
                                        {
                                            StartFresh();
                                            VU2hopsetsPage1();

                                        }
                        #endregion

                    //resets the scratchpad and sPad
                    scratchpad = null;
                    sPad.Text = scratchpad;

                }

        }

        private void CheckStatus()//determines GO/NGO status prior to displaying the page
        {
            #region TACAN
            if (myCont.TacanPower == "ON" & myCont.TacanNVRAM == "GO" & myCont.TacanMicro == "GO" & myCont.Tacan1553 == "GO" & myCont.TacanAudio == "GO" & myCont.TacanDpdat == "GO" & myCont.TacanDpram == "GO" & myCont.TacanPwr == "GO" & myCont.TacanRam == "GO" & myCont.TacanRcv == "GO" & myCont.TacanRom == "GO" & myCont.TacanRt == "GO" & myCont.TacanSub == "GO" & myCont.TacanSynth == "GO" & myCont.TacanTrm == "GO" & myCont.TacanTun == "GO")
            {
                _tcnStatus = "GO";
            }
            else
            {
                _tcnStatus = "NGO";
            }
            #endregion

            #region VU1
            if (myCont.VU11553 == "GO" & myCont.VU1Comsec == "GO" & myCont.VU1Modem == "GO" & myCont.VU1PowerSupply == "GO" & myCont.VU1RT == "GO" & myCont.VU1Transmitter == "GO")
            {
                _VU1status = "GO";
            }
            else
            {
                _VU1status = "NGO";
            }
            #endregion

            #region VU2
            if (myCont.VU21553 == "GO" & myCont.VU2Comsec == "GO" & myCont.VU2Modem == "GO" & myCont.VU2PowerSupply == "GO" & myCont.VU2RT == "GO" & myCont.VU2Transmitter == "GO")
            {
                _VU2status = "GO";
            }
            else
            {
                _VU2status = "NGO";
            }
            #endregion

            #region EGI INU
            if (myCont.EgiInuPower == "ON" & myCont.EgiInuSensRef == "GO" & myCont.EgiInuRaccel == "GO" & myCont.EgiInuSaccel == "GO" & myCont.EgiInuTaccel == "GO" & myCont.EgiInuUgyro == "GO" & myCont.EgiInuWgyro == "GO" & myCont.EgiInuVgyro == "GO")
            {
                _egiInuStatus = "GO";
            }
            else
            {
                _egiInuStatus = "NGO";
            }
            #endregion

            #region EGI GPS
            if (myCont.EgiInuPower == "ON" & myCont.EgiGpsRpu == "GO" & myCont.EgiGpsEgr == "GO" & myCont.EgiGpsBattery == "GO")
            {
                _egiGpsStatus = "GO";
            }
            else
            {
                _egiGpsStatus = "NGO";
            }
            #endregion

            #region EGI
            if (myCont.EGIsub == "GO" & myCont.EGIcaic == "GO" & _egiInuStatus == "GO" & myCont.EGIio == "GO" & myCont.EGIpwr == "GO" & myCont.EGIproc == "GO" & _egiGpsStatus == "GO" & myCont.EGIieTempc == "GO" & myCont.EGI1553 == "GO" & myCont.EGItrm == "GO")
            {
                _egiStatus = "GO";
            }
            else
            {
                _egiStatus = "NGO";
            }
            #endregion

            #region NAV STATUS
            if (_egiStatus == "GO" & _tcnStatus == "GO")
            {
                _navStatus = "GO";
            }
            else
            {
                _navStatus = "NGO";
            }
            #endregion

            #region SURV STATUS

            if (_IFFstatus == "GO" & _TCASstatus == "GO")
            {
                _survStatus = "GO";
            }
            else
            {
                _survStatus = "NGO";
            }

            #endregion

            #region COM STATUS
            if (myCont.HF11553 == "GO" & myCont.HF1Ampl == "GO" & myCont.HF1Cplr == "GO" & myCont.HF1Eqpt == "GO" & myCont.HF1Fiber == "GO" & myCont.HF1HiTemp == "GO" & myCont.HF1OverVlt == "GO" & myCont.HF1RcvOvrld == "GO" & myCont.HF1RT == "GO" & myCont.HF1Tune == "GO" & myCont.HF1VSWR == "GO")
            {
                _HF1status = "GO";
                hf1Warning = "";
            }
            else
            {
                _HF1status = "NGO";
                hf1Warning = "!";
            }

            if (_VU1status == "GO" & _VU2status == "GO" & _HF1status == "GO")
            {
                _comStatus = "GO";
            }
            else
            {
                _comStatus = "NGO";
            }

            if (_VU1status == "GO" & CDUVU1power == "ON")
            {
                vu1Warning = "";
            }
            else
            {
                vu1Warning = "!";
            }

            if (_VU2status == "GO" & CDUVU2power == "ON")
            {
                vu2Warning = "";
            }
            else
            {
                vu2Warning = "!";
            }



            #endregion
        }

        private void UpdateFreqs(string e)
        {
            Char[] myChar = { '<', ' ', '*' };

            if (hfMode != "ALE")
            {
                hfRecallChan = currentHFchan;
                hfRecallFreq = currentHFfreq;
                hfRecallName = currentHFchanName;

                switch (e)
                {
                    case "pre1Name":
                        currentHFchan = HFpre1Chan.Trim(myChar);
                        currentHFfreq = HFpre1Freq.Trim(myChar);
                        currentHFchanName = HFpre1Name.Trim(myChar);
                        break;

                    case "pre2Name":
                        currentHFchan = HFpre2Chan.Trim(myChar);
                        currentHFfreq = HFpre2Freq.Trim(myChar);
                        currentHFchanName = HFpre2Name.Trim(myChar);
                        break;

                    case "pre3Name":
                        currentHFchan = HFpre3Chan.Trim(myChar);
                        currentHFfreq = HFpre3Freq.Trim(myChar);
                        currentHFchanName = HFpre3Name.Trim(myChar);
                        break;

                    case "pre4Name":
                        currentHFchan = HFpre4Chan.Trim(myChar);
                        currentHFfreq = HFpre4Freq.Trim(myChar);
                        currentHFchanName = HFpre4Name.Trim(myChar);
                        break;

                    case "pre5Name":
                        currentHFchan = HFpre5Chan.Trim(myChar);
                        currentHFfreq = HFpre5Freq.Trim(myChar);
                        currentHFchanName = HFpre5Name.Trim(myChar);
                        break;
                }
            }
            else
            {
                ALERecallChan = currentALEchan;
                ALERecallFreq = currentALEfreq;
                ALERecallName = currentALEname;

                switch (e)
                {
                    case "pre1Name":
                        currentALEchan = ALEpre1Chan.Trim(myChar);
                        currentALEfreq = ALEpre1Freq.Trim(myChar);
                        currentALEname = ALEpre1Name.Trim(myChar);
                        break;

                    case "pre2Name":
                        currentALEchan = ALEpre2Chan.Trim(myChar);
                        currentALEfreq = ALEpre2Freq.Trim(myChar);
                        currentALEname = ALEpre2Name.Trim(myChar);
                        break;

                    case "pre3Name":
                        currentALEchan = ALEpre3Chan.Trim(myChar);
                        currentALEfreq = ALEpre3Freq.Trim(myChar);
                        currentALEname = ALEpre3Name.Trim(myChar);
                        break;

                    case "pre4Name":
                        currentALEchan = ALEpre4Chan.Trim(myChar);
                        currentALEfreq = ALEpre4Freq.Trim(myChar);
                        currentALEname = ALEpre4Name.Trim(myChar);
                        break;

                    case "pre5Name":
                        currentALEchan = ALEpre5Chan.Trim(myChar);
                        currentALEfreq = ALEpre5Freq.Trim(myChar);
                        currentALEname = ALEpre5Name.Trim(myChar);
                        break;
                }
            }
        }

        private bool CheckValidity()
        {
            Button[] rightBtns = { r1Btn, r2Btn, r3Btn, r4Btn, r5Btn };
            Button[] leftBtn = { l1Btn, l2Btn, l3Btn, l4Btn, l5Btn };



            switch (currentPageTitle)
            {
                case "HF1 ALE PRESET CHAN":
                    try
                    {
                        foreach (Button btn in leftBtn)
                        {
                            if (pushedButton == btn)
                            {
                                if (scratchpad.Length <= 6)//& ContainsCharacters ( ) == false & ContainsNumbers ( ) == false
                                {
                                    return true;
                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }

                        foreach (Button btn in rightBtns)
                        {
                            if (pushedButton == btn)
                            {

                                if ((scratchpad.Length == 5 || scratchpad.Length == 6) & ContainsCharacters() == false & ContainsLetters() == false)
                                {
                                    int x = Convert.ToInt32(scratchpad);
                                    if ((20000 <= x) == true & (x <= 299999) == true)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }

                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
                    break;

                case "HF1 CONTROL":
                    if (pushedButton == r4Btn)
                    {
                        if (scratchpad.Length <= 7 & scratchpad.Length != 0 & ContainsCharacters() == false)
                        {
                            return true;
                        }
                        else
                        {
                            scratchMessage = "INVALID ENTRY";
                        }
                    }
                    break;

                case "HF1 PRESET CHANNELS":
                    try
                    {
                        foreach (Button btn in leftBtn)
                        {
                            if (pushedButton == btn)
                            {
                                if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                {
                                    return true;
                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }
                        foreach (Button btn in rightBtns)
                        {
                            if (pushedButton == btn)
                            {

                                if ((scratchpad.Length == 5 || scratchpad.Length == 6) & ContainsCharacters() == false & ContainsLetters() == false)
                                {
                                    int x = Convert.ToInt32(scratchpad);
                                    if ((20000 <= x) == true & (x <= 299999) == true)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }

                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
                    break;

                case "HF2 PRESET CHANNELS":
                    try
                    {
                        foreach (Button btn in leftBtn)
                        {
                            if (pushedButton == btn)
                            {
                                if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                {
                                    return true;
                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }
                        foreach (Button btn in rightBtns)
                        {
                            if (pushedButton == btn)
                            {

                                if ((scratchpad.Length == 5 || scratchpad.Length == 6) & ContainsCharacters() == false & ContainsLetters() == false)
                                {
                                    int x = Convert.ToInt32(scratchpad);
                                    if ((20000 <= x) == true & (x <= 299999) == true)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }

                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }
                    break;

                case "HF1 STANDBY FCTN":
                    try
                    {
                        if (pushedButton == l2Btn)
                        {
                            if (scratchpad.Length == 6 & ContainsLetters() == false & ContainsCharacters() == false)
                            {
                                return true;
                            }
                            else
                            {
                                scratchMessage = "INVALID ENTRY";
                            }
                        }
                        else
                            if (pushedButton == l3Btn)
                            {
                                if (scratchpad.Length <= 8 & ContainsLetters() == false)
                                {
                                    return true;
                                }
                                else
                                {
                                    scratchMessage = "INVALID ENTRY";
                                }
                            }
                    }
                    catch (Exception)
                    {


                    }
                    break;

                case "INU LEVER ARMS":
                    if (pushedButton == l2Btn || pushedButton == l3Btn || pushedButton == l4Btn)
                    {
                        if (IsDigitOnly(scratchpad))
                        {
                            if (Islength4(scratchpad))
                            {
                                return true;
                            }
                            else
                            {
                                scratchMessage = "INVALID ENTRY";
                            }
                        }
                        else
                        {
                            scratchMessage = "INVALID ENTRY";
                        }
                    }
                    else
                    {
                        if (pushedButton == r2Btn || pushedButton == r3Btn || pushedButton == r4Btn)
                        {
                            scratchMessage = "KEY NOT ACTIVE";
                        }
                    }
                    break;

                case "mission":
                    {
                        if (pushedButton == r4Btn & !myCont.IFFselected)
                        {
                            scratchMessage = "IFF DISABLED";
                        }
                        break;
                    }

                case "V/U1 UHF":
                    {
                        try
                        {
                            foreach (Button btn in leftBtn)
                            {
                                if (pushedButton == btn)
                                {
                                    if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }
                                }
                            }
                            foreach (Button btn in rightBtns)
                            {
                                if (pushedButton == btn)
                                {

                                    if ((scratchpad.Length == 6) & ContainsCharacters() == false & ContainsLetters() == false)
                                    {
                                        int x = Convert.ToInt32(scratchpad);
                                        if ((225000 <= x) == true & (x <= 399995) == true)
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }

                                    }
                                    else
                                        if ((scratchpad.Length == 2 || scratchpad.Length == 3) & (scratchpad.Contains("P") || scratchpad.Contains("C")))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;

                case "V/U1 VHF-FM":
                    {
                        try
                        {
                            foreach (Button btn in leftBtn)
                            {
                                if (pushedButton == btn)
                                {
                                    if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }
                                }
                            }
                            foreach (Button btn in rightBtns)
                            {
                                if (pushedButton == btn)
                                {

                                    if ((scratchpad.Length == 6 || scratchpad.Length == 5) & ContainsCharacters() == false & ContainsLetters() == false)
                                    {
                                        int x = Convert.ToInt32(scratchpad);
                                        if (((173995 >= x) == true & (x >= 130000) == true) || ((30000 <= x) == true & (x <= 87995)))
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }

                                    }
                                    else
                                        if ((scratchpad.Length == 2 || scratchpad.Length == 3) & (scratchpad.Contains("P") || scratchpad.Contains("C")))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;

                case "V/U1 VHF-AM":
                    {
                        try
                        {
                            foreach (Button btn in leftBtn)
                            {
                                if (pushedButton == btn)
                                {
                                    if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }
                                }
                            }
                            foreach (Button btn in rightBtns)
                            {
                                if (pushedButton == btn)
                                {

                                    if ((scratchpad.Length == 6) & ContainsCharacters() == false & ContainsLetters() == false)
                                    {
                                        int x = Convert.ToInt32(scratchpad);
                                        if (((155995 >= x) == true & (x >= 108000) == true))
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }

                                    }
                                    else
                                        if ((scratchpad.Length == 2 || scratchpad.Length == 3) & (scratchpad.Contains("P") || scratchpad.Contains("C")))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;

                case "V/U1 HOPSETS":
                    {
                        try
                        {
                            foreach (Button btn in leftBtn)
                            {
                                if (pushedButton == btn)
                                {
                                    if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }
                                }
                            }
                            foreach (Button btn in rightBtns)
                            {
                                if (pushedButton == btn)
                                {

                                    if (ContainsCharacters() == false & ContainsLetters() == false & scratchpad.Length == 5)
                                    {

                                        int x = Convert.ToInt32(scratchpad);
                                        if (((87995 >= x) == true & (x >= 30000) == true))
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }

                                    }
                                    else if (scratchpad.Contains("F") & scratchpad.Length >= 2 & scratchpad.Length <= 4)
                                    {
                                        string e = scratchpad.Trim('F');
                                        int i = Convert.ToInt32(e);
                                        if (((0 <= i) == true & (i <= 999) == true))
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                    }
                                    else
                                        if ((scratchpad.Length == 2 || scratchpad.Length == 3) & (scratchpad.Contains("P") || scratchpad.Contains("C")))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;

                case "V/U1 SATCOM":
                    {
                        try
                        {
                            foreach (Button btn in leftBtn)
                            {
                                if (pushedButton == btn)
                                {
                                    if (scratchpad.Length <= 6 & ContainsCharacters() == false)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        scratchMessage = "INVALID ENTRY";
                                        break;
                                    }
                                }
                            }
                            foreach (Button btn in rightBtns)
                            {
                                if (pushedButton == btn)
                                {

                                    if ((scratchpad.Length == 6 || scratchpad.Length == 5) & ContainsCharacters() == false & ContainsLetters() == false)
                                    {
                                        int x = Convert.ToInt32(scratchpad);
                                        if ((399995 >= x) == true & (x >= 225000) == true)
                                        {
                                            return true;
                                        }

                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }

                                    }
                                    else
                                        if ((scratchpad.Length == 2 || scratchpad.Length == 3) & (scratchpad.Contains("P") || scratchpad.Contains("C")))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            scratchMessage = "INVALID ENTRY";
                                            break;
                                        }
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    break;

            }

            //used for all possible cases

            ShowScratchMessage();
            ScratchMessageTimer.Start();
            return false;
        }   //validates the input to textboxes

        public void UTCupdateTimer_Tick(object sender, EventArgs e)
        {
            egiDateTime = DateTime.UtcNow;
            egiDate = DateTime.Now;
            formattedTime = egiDateTime.ToString("HH : mm : ss");
            formattedDate = egiDate.ToString("dd MMM yy").ToUpper();

            if (currentPageTitle == "HF1 STANDBY FCTN")
            {
                StartFresh();
                HFstandbyFunctionPage();
            }

            if (currentPageTitle == "START INIT")
            {
                StartFresh();
                StartInitPage();
            }

            if (currentPageTitle == "status")
            {
                StartFresh();
                StatusPage();
            }

            if (currentPageTitle == "IFF STATUS" & currentPageNumber == 1)
            {
                StartFresh();
                IFFstatusPage1();
            }

        }   //updates the clock and refreshes the page

        private string LatLonFormat(string e)
        {
            string j = null;
            char k;
            string l = " ";

            for (int i = 0; i < e.Length; i++)
            {
                k = e[i];
                j += k;

                if (i == 2 || i == 5 || i == 13 || i == 16)
                {

                }
                else
                {
                    j += l;

                    if (i == 9)
                    {
                        j = j + l + l;
                    }
                }
            }
            return j;
        }   //adds proper spacing to lat/lon string

        private void ReturnList(string e)   //handles all RETURN buttons
        {
            switch (e)
            {
                case "comm":
                    {
                        MissionPage();
                        break;
                    }

                case "COM STATUS":
                    {
                        MissionStatusPage1();
                        break;
                    }

                case "EGI CONTROL":
                    {
                        StartInitPage();
                        break;
                    }

                case "EGI GPS STATUS":
                    {
                        EGIstatusPage();
                        break;
                    }

                case "EGI INU STATUS":
                    {
                        EGIstatusPage();
                        break;
                    }

                case "EGI SA/AS":
                    {
                        MissionPage();
                        break;
                    }

                case "HF1 ALE ADDRESS":
                    {
                        HFALEfunctionPage1();
                        break;
                    }

                case "HF1 ALE FCTN":
                    {
                        HFcontrolPage1();
                        break;
                    }

                case "HF1 ALE PRESET CHAN":
                    {
                        HFcontrolPage1();
                        break;
                    }

                case "HF1 ALE SCAN LISTS":
                    {
                        HFcontrolPage1();
                        break;
                    }

                case "HF1 CONTROL":
                    {
                        COMpage();
                        break;
                    }

                case "HF1 GROUP ADDRESS":
                    {
                        HFALEaddressPage();
                        break;
                    }

                case "HF1 NET ADDRESS":
                    {
                        HFALEaddressPage();
                        break;
                    }

                case "HF1 PRESET CHANNELS":
                    {
                        HFcontrolPage1();
                        break;
                    }

                case "HF1 STANDBY FCTN":
                    {
                        HFcontrolPage1();
                        break;
                    }

                case "EGI STATUS":
                    {
                        NAVstatusPage();
                        break;
                    }

                case "HF1 STATUS":
                    {
                        ComStatusPage1();
                        break;
                    }

                case "IFF":
                    {
                        MissionPage();
                        break;
                    }

                case "IFF STATUS":
                    {
                        SurvStatusPage();
                        break;
                    }

                case "INU LEVER ARMS":
                    {
                        NAVstatusPage();
                        break;
                    }

                case "MARK POINTS":
                    {
                        IdxPage1();
                        break;
                    }

                case "NAV STATUS":
                    {
                        MissionStatusPage1();
                        break;
                    }

                case "POWER":
                    {
                        StartInitPage();
                        break;
                    }

                case "START INIT":
                    {
                        MissionPage();
                        break;
                    }

                case "SYSTEM STATUS":
                    {
                        MissionPage();
                        break;
                    }

                case "SURV STATUS":
                    {
                        MissionPage();
                        break;
                    }

                case "TACAN CONTROL":
                    {
                        MissionPage();
                        break;
                    }

                case "TACAN STATUS":
                    {
                        NAVstatusPage();
                        break;
                    }

                case "V/U1 CLEAR NVM":
                    {
                        VU1maintenancePage();
                        break;
                    }

                case "V/U1 COMSEC FILL":
                    {
                        VU1Fill();
                        break;
                    }

                case "V/U1 COMSEC STATES":
                    {
                        VU1Fill();
                        break;
                    }

                case "V/U1 CONTROL":
                    {
                        COMpage();
                        break;
                    }

                case "V/U1 FILL":
                    {
                        VU1maintenancePage();
                        break;
                    }

                case "V/U1 LOCKOUTS":
                    {
                        VU1controlPage2();
                        break;
                    }

                case "V/U1 LOOPBACK TEST":
                    {
                        VU1maintenancePage();
                        break;
                    }

                case "V/U1 MAINTENANCE":
                    {
                        VU1controlPage2();
                        break;
                    }

                case "V/U1 SINCGARS":
                    {
                        VU1controlPage2();
                        break;
                    }

                case "V/U1 SINCGARS FILL":
                    {
                        VU1Fill();
                        break;
                    }

                case "V/U1 TRANSEC FILL":
                    {
                        VU1Fill();
                        break;
                    }

                case "V/U2 CLEAR NVM":
                    {
                        VU2maintenancePage();
                        break;
                    }

                case "V/U2 COMSEC FILL":
                    {
                        VU2Fill();
                        break;
                    }

                case "V/U2 COMSEC STATES":
                    {
                        VU2Fill();
                        break;
                    }

                case "V/U2 CONTROL":
                    {
                        COMpage();
                        break;
                    }

                case "V/U2 FILL":
                    {
                        VU2maintenancePage();
                        break;
                    }

                case "V/U2 LOCKOUTS":
                    {
                        VU2controlPage2();
                        break;
                    }

                case "V/U2 LOOPBACK TEST":
                    {
                        VU2maintenancePage();
                        break;
                    }

                case "V/U2 MAINTENANCE":
                    {
                        VU2controlPage2();
                        break;
                    }

                case "V/U2 SINCGARS":
                    {
                        VU2controlPage2();
                        break;
                    }

                case "V/U2 SINCGARS FILL":
                    {
                        VU2Fill();
                        break;
                    }

                case "V/U2 TRANSEC FILL":
                    {
                        VU2Fill();
                        break;
                    }

                case "V/U1 COMSEC CONTROL":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 COMSEC CONTROL":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "V/U1 COMSEC VAR":
                    {
                        VU1comsecControlPage();
                        break;
                    }

                case "V/U2 COMSEC VAR":
                    {
                        VU2comsecControlPage();
                        break;
                    }

                case "V/U1 HOPSETS":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 HOPSETS":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "V/U1 SATCOM":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 SATCOM":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "V/U1 STATUS":
                    {
                        ComStatusPage1();
                        break;
                    }

                case "V/U2 STATUS":
                    {
                        ComStatusPage1();
                        break;
                    }

                case "V/U1 VHF-AM":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 VHF-AM":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "V/U1 VHF-FM":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 VHF-FM":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "V/U1 UHF":
                    {
                        VU1controlPage1();
                        break;
                    }

                case "V/U2 UHF":
                    {
                        VU2controlPage1();
                        break;
                    }

                case "ZEROIZE":
                    {
                        MissionPage();
                        break;
                    }
            }
        }

        private void DisplayErrorMessage(string e)
        {
            scratchMessage = e;
            ShowScratchMessage();
            ScratchMessageTimer.Start();
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


        #region Validation

        bool IsDigitOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        bool Islength4(string str)
        {
            if (str.Length > 4)
            {
                return false;
            }
            return true;
        }

        private bool ContainsLetters()
        {
            string[] letter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            foreach (string value in letter)
            {
                if (scratchpad != null)
                {
                    if (scratchpad.Contains(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ContainsNumbers()
        {
            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            if (scratchpad != null)
            {
                foreach (string value in number)
                {
                    if (scratchpad.Contains(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ContainsCharacters()
        {
            string[] character = { ".", "/", "+", "-", " " };

            foreach (string value in character)
            {
                if (scratchpad.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        private void ScratchMessageTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Location.Y == row13 + 3 & c.Location.X == col1 + 7)
                    {

                        c.Dispose();

                    }
                }
            }
            ScratchMessageTimer.Stop();
        }

        public void ShowScratchMessage()
        {
            TextBox scMessage = new TextBox();
            TB(scMessage, col1 + 7, row13 + 3, scratchMessage, Color.White);
            scMessage.BringToFront();
        }

        #endregion


        #endregion


        #region Form Load and Display First Page

        public CDU3000()
        {
            InitializeComponent();
            DM.Show();//displays the dimmer form over the main form
            DM.Owner = this;//causes the dimmer form to be above the mainform but not over other forms

            myCont.Show();
            //myCont.Hide ( );//TEMPORARILY HID FORM DURING DEVELOPMENT

            if (UTCupdateTimer.Enabled == false)
            {
                UTCupdateTimer.Start();
            }
        }

        private void InitialPageLoad(object sender, EventArgs e) //loads the initial page seen on the CDU
        {
            if (initialLoad == true)//if this is the initial load of the program
            {
                CheckStatus();//checks the status of all items
                StatusPage();//load the status page
                initialLoad = false;//change the initialLoad state to false
            }

        }





        #endregion


        #region Form Close Items

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DeleteBtnTimer.Stop();
            DeleteBtnTimer.Dispose();
            DimBrtTimer.Stop();
            DimBrtTimer.Dispose();
            ScratchMessageTimer.Stop();
            ScratchMessageTimer.Dispose();
            UTCupdateTimer.Stop();
            UTCupdateTimer.Dispose();
            this.Close();
            ActiveForm.Close();
        }

        private void CDU3000_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteBtnTimer.Stop();
            DeleteBtnTimer.Dispose();
            DimBrtTimer.Stop();
            DimBrtTimer.Dispose();
            ScratchMessageTimer.Stop();
            ScratchMessageTimer.Dispose();
            UTCupdateTimer.Stop();
            UTCupdateTimer.Dispose();

        }

        #endregion





        #region Dimming methods

        private void CDU3000_LocationChanged(object sender, EventArgs e)
        {
            CheckForBorder();//refactored into this
        }

        private void btnDim_MouseDown(object sender, MouseEventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "btnDim";

            DimBrtTimer.Start();
        }

        private void btnDim_MouseUp(object sender, MouseEventArgs e)
        {
            DimBrtTimer.Stop();
        }

        private void btnBrt_MouseDown(object sender, MouseEventArgs e)
        {
            pushedButton = (Button)sender;
            btnPressed = "btnDim";

            DimBrtTimer.Start();
        }

        private void btnBrt_MouseUp(object sender, MouseEventArgs e)
        {
            DimBrtTimer.Stop();
        }

        private void DimBrtTimer_Tick(object sender, EventArgs e)
        {
            if (pushedButton == btnDim)
            {
                if (alpha <= .80)
                {
                    alpha = alpha + .05;
                }
                DM.Opacity = alpha;
            }
            else
                if (pushedButton == btnBrt)
                {
                    if (alpha >= .05)
                    {
                        alpha = alpha - .05;
                    }
                    DM.Opacity = alpha;
                }
        }

        private void CDU3000_StyleChanged(object sender, EventArgs e)
        {
            CheckForBorder();//refactored into this
        }

        private void CheckForBorder()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                //positions the dimmer form (DM) when the main form moves and the border is not visible
                DM.DimmerLocX = this.Location.X + 134;
                DM.DimmerLocY = this.Location.Y + 52;
            }
            else
            {
                //positions the dimmer form (DM) when the main form moves
                DM.DimmerLocX = this.Location.X + 145;
                DM.DimmerLocY = this.Location.Y + 88;
            }
        }

        #endregion Dimming Methods


        private void VU1PresetController()
        {
            if (currentPageTitle == "V/U1 UHF")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU1name = VU1UHFpre1Name;
                        currentVU1chan = VU1UHFpre1Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1UHFpre1Freq;
                        currentVU1ComsecVar = VU1UHFpre1Comsec;
                    }

                    if (pushedButton == l2Btn)
                    {
                        currentVU1name = VU1UHFpre2Name;
                        currentVU1chan = VU1UHFpre2Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1UHFpre2Freq;
                        currentVU1ComsecVar = VU1UHFpre2Comsec;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentVU1name = VU1UHFpre3Name;
                        currentVU1chan = VU1UHFpre3Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1UHFpre3Freq;
                        currentVU1ComsecVar = VU1UHFpre3Comsec;
                    }

                    if (pushedButton == l4Btn)
                    {
                        currentVU1name = VU1UHFpre4Name;
                        currentVU1chan = VU1UHFpre4Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1UHFpre4Freq;
                        currentVU1ComsecVar = VU1UHFpre4Comsec;
                    }

                    if (pushedButton == l5Btn)
                    {
                        currentVU1name = VU1UHFpre5Name;
                        currentVU1chan = VU1UHFpre5Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1UHFpre5Freq;
                        currentVU1ComsecVar = VU1UHFpre5Comsec;
                    }
                    VU1band = activeBand.UHF;
                    StartFresh();
                    VU1controlPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    recallVU1UHFfreq = currentVU1UHFfreq;
                    recallVU1UHFname = currentVU1UHFname;
                    recallVU1UHFchan = currentVU1UHFchan;
                    recallVU1Comsec = currentVU1ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU1chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU1UHFpre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU1name = VU1UHFpre1Name;
                            currentVU1chan = l1text;
                            currentVU1freq = VU1UHFpre1Freq;
                            currentVU1ComsecVar = VU1UHFpre1Comsec;
                        }
                    }
                    if (pushedButton == l2Btn || currentVU1chan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            VU1UHFpre2Chan = "* " + l2text;
                            //basSelChanVar = l2text;
                            currentVU1name = VU1UHFpre2Name;
                            currentVU1chan = l2text;
                            currentVU1freq = VU1UHFpre2Freq;
                            currentVU1ComsecVar = VU1UHFpre2Comsec;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU1UHFpre3Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU1name = VU1UHFpre3Name;
                            currentVU1chan = l3text;
                            currentVU1freq = VU1UHFpre3Freq;
                            currentVU1ComsecVar = VU1UHFpre3Comsec;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            VU1UHFpre4Chan = "* " + l4text;
                            //basSelChanVar = l4text;
                            currentVU1name = VU1UHFpre4Name;
                            currentVU1chan = l4text;
                            currentVU1freq = VU1UHFpre4Freq;
                            currentVU1ComsecVar = VU1UHFpre4Comsec;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            VU1UHFpre5Chan = "* " + l5text;
                            //basSelChanVar = l5text;
                            currentVU1name = VU1UHFpre5Name;
                            currentVU1chan = l5text;
                            currentVU1freq = VU1UHFpre5Freq;
                            currentVU1ComsecVar = VU1UHFpre5Comsec;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU1UHFpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU1UHFpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU1UHFpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        VU1UHFpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        VU1UHFpre5Chan = "<" + l5text;
                    }
                }

                VU1band = activeBand.UHF;
                VU1activeBand = "U";
                StartFresh();
                VU1uhfPresetsPage1();
            }
            else if (currentPageTitle == "V/U1 VHF-FM")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU1name = VU1FMpre1Name;
                        currentVU1chan = VU1FMpre1Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1FMpre1Freq;
                        currentVU1ComsecVar = VU1FMpre1Comsec;
                    }

                    if (pushedButton == l2Btn)
                    {
                        currentVU1name = VU1FMpre2Name;
                        currentVU1chan = VU1FMpre2Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1FMpre2Freq;
                        currentVU1ComsecVar = VU1FMpre2Comsec;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentVU1name = VU1FMpre3Name;
                        currentVU1chan = VU1FMpre3Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1FMpre3Freq;
                        currentVU1ComsecVar = VU1FMpre3Comsec;
                    }

                    if (pushedButton == l4Btn)
                    {
                        currentVU1name = VU1FMpre4Name;
                        currentVU1chan = VU1FMpre4Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1FMpre4Freq;
                        currentVU1ComsecVar = VU1FMpre4Comsec;
                    }

                    if (pushedButton == l5Btn)
                    {
                        currentVU1name = VU1FMpre5Name;
                        currentVU1chan = VU1FMpre5Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1FMpre5Freq;
                        currentVU1ComsecVar = VU1FMpre5Comsec;
                    }
                    VU1band = activeBand.FM;
                    StartFresh();
                    VU1controlPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    recallVU1FMfreq = currentVU1freq;
                    recallVU1FMname = currentVU1name;
                    recallVU1FMchan = currentVU1chan;
                    recallVU1Comsec = currentVU1ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU1chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU1FMpre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU1name = VU1FMpre1Name;
                            currentVU1chan = l1text;
                            currentVU1freq = VU1FMpre1Freq;
                            currentVU1ComsecVar = VU1FMpre1Comsec;
                        }
                    }
                    if (pushedButton == l2Btn || currentVU1chan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            VU1FMpre2Chan = "* " + l2text;
                            //basSelChanVar = l2text;
                            currentVU1name = VU1FMpre2Name;
                            currentVU1chan = l2text;
                            currentVU1freq = VU1FMpre2Freq;
                            currentVU1ComsecVar = VU1FMpre2Comsec;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU1FMpre3Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU1name = VU1FMpre3Name;
                            currentVU1chan = l3text;
                            currentVU1freq = VU1FMpre3Freq;
                            currentVU1ComsecVar = VU1FMpre3Comsec;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            VU1FMpre4Chan = "* " + l4text;
                            //basSelChanVar = l4text;
                            currentVU1name = VU1FMpre4Name;
                            currentVU1chan = l4text;
                            currentVU1freq = VU1FMpre4Freq;
                            currentVU1ComsecVar = VU1FMpre4Comsec;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            VU1FMpre5Chan = "* " + l5text;
                            //basSelChanVar = l5text;
                            currentVU1name = VU1FMpre5Name;
                            currentVU1chan = l5text;
                            currentVU1freq = VU1FMpre5Freq;
                            currentVU1ComsecVar = VU1FMpre5Comsec;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU1FMpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU1FMpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU1FMpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        VU1FMpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        VU1FMpre5Chan = "<" + l5text;
                    }
                }

                VU1band = activeBand.FM;
                VU1activeBand = "F";
                StartFresh();
                VU1vhfFMpresetsPage1();
            }
            else if (currentPageTitle == "V/U1 VHF-AM")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU1name = VU1AMpre1Name;
                        currentVU1chan = VU1AMpre1Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1AMpre1Freq;
                        currentVU1ComsecVar = VU1AMpre1Comsec;
                    }

                    if (pushedButton == l2Btn)
                    {
                        currentVU1name = VU1AMpre2Name;
                        currentVU1chan = VU1AMpre2Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1AMpre2Freq;
                        currentVU1ComsecVar = VU1AMpre2Comsec;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentVU1name = VU1AMpre3Name;
                        currentVU1chan = VU1AMpre3Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1AMpre3Freq;
                        currentVU1ComsecVar = VU1AMpre3Comsec;
                    }

                    if (pushedButton == l4Btn)
                    {
                        currentVU1name = VU1AMpre4Name;
                        currentVU1chan = VU1AMpre4Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1AMpre4Freq;
                        currentVU1ComsecVar = VU1AMpre4Comsec;
                    }

                    if (pushedButton == l5Btn)
                    {
                        currentVU1name = VU1AMpre5Name;
                        currentVU1chan = VU1AMpre5Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1AMpre5Freq;
                        currentVU1ComsecVar = VU1AMpre5Comsec;
                    }
                    VU1band = activeBand.AM;
                    StartFresh();
                    VU1controlPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    recallVU1AMfreq = currentVU1freq;
                    recallVU1AMname = currentVU1name;
                    recallVU1AMchan = currentVU1chan;
                    recallVU1Comsec = currentVU1ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU1chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU1AMpre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU1name = VU1AMpre1Name;
                            currentVU1chan = l1text;
                            currentVU1freq = VU1AMpre1Freq;
                            currentVU1ComsecVar = VU1AMpre1Comsec;
                        }
                    }
                    if (pushedButton == l2Btn || currentVU1chan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            VU1AMpre2Chan = "* " + l2text;
                            //basSelChanVar = l2text;
                            currentVU1name = VU1AMpre2Name;
                            currentVU1chan = l2text;
                            currentVU1freq = VU1AMpre2Freq;
                            currentVU1ComsecVar = VU1AMpre2Comsec;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU1AMpre3Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU1name = VU1AMpre3Name;
                            currentVU1chan = l3text;
                            currentVU1freq = VU1AMpre3Freq;
                            currentVU1ComsecVar = VU1AMpre3Comsec;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            VU1AMpre4Chan = "* " + l4text;
                            //basSelChanVar = l4text;
                            currentVU1name = VU1AMpre4Name;
                            currentVU1chan = l4text;
                            currentVU1freq = VU1AMpre4Freq;
                            currentVU1ComsecVar = VU1AMpre4Comsec;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            VU1AMpre5Chan = "* " + l5text;
                            //basSelChanVar = l5text;
                            currentVU1name = VU1AMpre5Name;
                            currentVU1chan = l5text;
                            currentVU1freq = VU1AMpre5Freq;
                            currentVU1ComsecVar = VU1AMpre5Comsec;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU1AMpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU1AMpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU1AMpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        VU1AMpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        VU1AMpre5Chan = "<" + l5text;
                    }
                }

                VU1band = activeBand.AM;
                VU1activeBand = "V";
                StartFresh();
                VU1vhfAMpresetsPage1();
            }
            else if (currentPageTitle == "V/U1 HOPSETS")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU1name = VU1HOPpre1Name;
                        currentVU1chan = VU1HOPpre1Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1HOPpre1Freq;
                        currentVU1ComsecVar = VU1HOPpre1Comsec;
                    }

                    if (pushedButton == l2Btn)
                    {
                        currentVU1name = VU1HOPpre2Name;
                        currentVU1chan = VU1HOPpre2Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1HOPpre2Freq;
                        currentVU1ComsecVar = VU1HOPpre2Comsec;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentVU1name = VU1HOPpre3Name;
                        currentVU1chan = VU1HOPpre3Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1HOPpre3Freq;
                        currentVU1ComsecVar = VU1HOPpre3Comsec;
                    }

                    if (pushedButton == l4Btn)
                    {
                        currentVU1name = VU1HOPpre4Name;
                        currentVU1chan = VU1HOPpre4Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1HOPpre4Freq;
                        currentVU1ComsecVar = VU1HOPpre4Comsec;
                    }

                    if (pushedButton == l5Btn)
                    {
                        currentVU1name = VU1HOPpre5Name;
                        currentVU1chan = VU1HOPpre5Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1HOPpre5Freq;
                        currentVU1ComsecVar = VU1HOPpre5Comsec;
                    }
                    VU1band = activeBand.HOPSETS;
                    StartFresh();
                    VU1controlPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    recallVU1HOPfreq = currentVU1freq;
                    recallVU1HOPname = currentVU1name;
                    recallVU1HOPchan = currentVU1chan;
                    recallVU1Comsec = currentVU1ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU1chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU1HOPpre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU1name = VU1HOPpre1Name;
                            currentVU1chan = l1text;
                            currentVU1freq = VU1HOPpre1Freq;
                            currentVU1ComsecVar = VU1HOPpre1Comsec;
                        }
                    }
                    if (pushedButton == l2Btn || currentVU1chan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            VU1HOPpre2Chan = "* " + l2text;
                            //basSelChanVar = l2text;
                            currentVU1name = VU1HOPpre2Name;
                            currentVU1chan = l2text;
                            currentVU1freq = VU1HOPpre2Freq;
                            currentVU1ComsecVar = VU1HOPpre2Comsec;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU1HOPpre3Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU1name = VU1HOPpre3Name;
                            currentVU1chan = l3text;
                            currentVU1freq = VU1HOPpre3Freq;
                            currentVU1ComsecVar = VU1HOPpre3Comsec;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            VU1HOPpre4Chan = "* " + l4text;
                            //basSelChanVar = l4text;
                            currentVU1name = VU1HOPpre4Name;
                            currentVU1chan = l4text;
                            currentVU1freq = VU1HOPpre4Freq;
                            currentVU1ComsecVar = VU1HOPpre4Comsec;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            VU1HOPpre5Chan = "* " + l5text;
                            //basSelChanVar = l5text;
                            currentVU1name = VU1HOPpre5Name;
                            currentVU1chan = l5text;
                            currentVU1freq = VU1HOPpre5Freq;
                            currentVU1ComsecVar = VU1HOPpre5Comsec;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU1HOPpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU1HOPpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU1HOPpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        VU1HOPpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        VU1HOPpre5Chan = "<" + l5text;
                    }
                }

                VU1band = activeBand.HOPSETS;
                VU1activeBand = "E";
                StartFresh();
                VU1hopsetsPage1();
            }
            else if (currentPageTitle == "V/U1 SATCOM")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU1name = VU1SatcomPre1Name;
                        currentVU1chan = VU1SatcomPre1Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1SatcomPre1Uplink;
                        currentVU1ComsecVar = VU1SatcomPre1Comsec;
                    }

                    if (pushedButton == l3Btn)
                    {
                        currentVU1name = VU1SatcomPre2Name;
                        currentVU1chan = VU1SatcomPre2Chan.Trim('<', ' ', '*');
                        currentVU1freq = VU1SatcomPre2Uplink;
                        currentVU1ComsecVar = VU1SatcomPre2Comsec;
                    }


                    VU1band = activeBand.SATCOM;
                    StartFresh();
                    VU1controlPage1();
                    return;
                }
                else
                {

                    //add to allow Preset recall 
                    recallVU1Satcomfreq = currentVU1freq;
                    recallVU1Satcomname = currentVU1name;
                    recallVU1Satcomchan = currentVU1chan;
                    recallVU1Comsec = currentVU1ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU1chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU1SatcomPre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU1name = VU1SatcomPre1Name;
                            currentVU1chan = l1text;
                            currentVU1freq = VU1SatcomPre1Uplink;
                            currentVU1ComsecVar = VU1SatcomPre1Comsec;
                        }
                    }

                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU1SatcomPre2Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU1name = VU1SatcomPre2Name;
                            currentVU1chan = l3text;
                            currentVU1freq = VU1SatcomPre2Uplink;
                            currentVU1ComsecVar = VU1SatcomPre2Comsec;
                        }
                    }



                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU1SatcomPre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU1SatcomPre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU1SatcomPre2Chan = "<" + l3text;
                    }

                }

                VU1band = activeBand.SATCOM;
                VU1activeBand = "S";
                StartFresh();
                VU1satcomPresetsPage1();
            }


        }


        private void VU2PresetController()
        {
            if (currentPageTitle == "V/U2 UHF")
            {
                //return to HF Control Page
                if ((pushedButton == l1Btn & l1text.Contains("*")) || (pushedButton == l2Btn & l2text.Contains("*")) || (pushedButton == l3Btn & l3text.Contains("*")) || (pushedButton == l4Btn & l4text.Contains("*")) || (pushedButton == l5Btn & l5text.Contains("*")))
                {
                    if (pushedButton == l1Btn)
                    {
                        currentVU2name = VU2UHFpre1Name;
                        currentVU2chan = VU2UHFpre1Chan.Trim('<', ' ', '*');
                        currentVU2freq = VU2UHFpre1Freq;
                        currentVU2ComsecVar = VU2UHFpre1Comsec;
                    }

                    StartFresh();
                    VU2controlPage1();
                    return;
                }
                else
                {

                    //add to allow preset recall 
                    recallVU2UHFfreq = currentVU2freq;
                    recallVU2UHFname = currentVU2name;
                    recallVU2UHFchan = currentVU2chan;
                    recallVU2Comsec = currentVU2ComsecVar;

                    char[] toTrim = { '<', ' ' };
                    if (pushedButton == l1Btn || currentVU2chan == l1text)
                    {
                        if (l1text.Contains("<"))
                        {
                            l1text = l1text.TrimStart(toTrim);
                            VU2UHFpre1Chan = "* " + l1text;
                            //basSelChanVar = l1text;
                            currentVU2name = VU2UHFpre1Name;
                            currentVU2chan = l1text;
                            currentVU2freq = VU2UHFpre1Freq;
                            currentVU2ComsecVar = VU2UHFpre1Comsec;
                        }
                    }
                    if (pushedButton == l2Btn || currentVU2chan == l2text)
                    {
                        if (l2text.Contains("<"))
                        {
                            l2text = l2text.TrimStart(toTrim);
                            VU2UHFpre2Chan = "* " + l2text;
                            //basSelChanVar = l2text;
                            currentVU2name = VU2UHFpre2Name;
                            currentVU2chan = l2text;
                            currentVU2freq = VU2UHFpre2Freq;
                            currentVU2ComsecVar = VU2UHFpre2Comsec;
                        }
                    }
                    if (pushedButton == l3Btn)
                    {
                        if (l3text.Contains("<"))
                        {
                            l3text = l3text.TrimStart(toTrim);
                            VU2UHFpre3Chan = "* " + l3text;
                            //basSelChanVar = l3text;
                            currentVU2name = VU2UHFpre3Name;
                            currentVU2chan = l3text;
                            currentVU2freq = VU2UHFpre3Freq;
                            currentVU2ComsecVar = VU2UHFpre3Comsec;
                        }
                    }
                    if (pushedButton == l4Btn)
                    {
                        if (l4text.Contains("<"))
                        {
                            l4text = l4text.TrimStart(toTrim);
                            VU2UHFpre4Chan = "* " + l4text;
                            //basSelChanVar = l4text;
                            currentVU2name = VU2UHFpre4Name;
                            currentVU2chan = l4text;
                            currentVU2freq = VU2UHFpre4Freq;
                            currentVU2ComsecVar = VU2UHFpre4Comsec;
                        }
                    }
                    if (pushedButton == l5Btn)
                    {
                        if (l5text.Contains("<"))
                        {
                            l5text = l5text.TrimStart(toTrim);
                            VU2UHFpre5Chan = "* " + l5text;
                            //basSelChanVar = l5text;
                            currentVU2name = VU2UHFpre5Name;
                            currentVU2chan = l5text;
                            currentVU2freq = VU2UHFpre5Freq;
                            currentVU2ComsecVar = VU2UHFpre5Comsec;
                        }
                    }

                    //reset the others
                    char[] toCut = { '*' };

                    if (l1text.Contains("*") & pushedButton != l1Btn)
                    {
                        l1text = l1text.TrimStart(toCut);
                        VU2UHFpre1Chan = "<" + l1text;
                    }
                    if (l2text.Contains("*") & pushedButton != l2Btn)
                    {
                        l2text = l2text.TrimStart(toCut);
                        VU2UHFpre2Chan = "<" + l2text;
                    }
                    if (l3text.Contains("*") & pushedButton != l3Btn)
                    {
                        l3text = l3text.TrimStart(toCut);
                        VU2UHFpre3Chan = "<" + l3text;
                    }
                    if (l4text.Contains("*") & pushedButton != l4Btn)
                    {
                        l4text = l4text.TrimStart(toCut);
                        VU2UHFpre4Chan = "<" + l4text;
                    }
                    if (l5text.Contains("*") & pushedButton != l5Btn)
                    {
                        l5text = l5text.TrimStart(toCut);
                        VU2UHFpre5Chan = "<" + l5text;
                    }
                }


                VU2activeBand = "U";
                StartFresh();
                VU2uhfPresetsPage1();
            }
        }



        private void DevelopmentArea()
        {
            if (VU1UHFpre1Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('<', '*');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
            }
            if (VU1UHFpre2Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('<', '*');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
            }
            if (VU1UHFpre3Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('<', '*');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
            }
            if (VU1UHFpre4Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('<', '*');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('*', '<');
            }
            if (VU1UHFpre5Chan.Trim('<', ' ') == currentVU1chan)
            {
                VU1UHFpre5Chan = VU1UHFpre5Chan.Replace('<', '*');
                VU1UHFpre4Chan = VU1UHFpre4Chan.Replace('*', '<');
                VU1UHFpre3Chan = VU1UHFpre3Chan.Replace('*', '<');
                VU1UHFpre2Chan = VU1UHFpre2Chan.Replace('*', '<');
                VU1UHFpre1Chan = VU1UHFpre1Chan.Replace('*', '<');

            }
        }

        private string BandSelection(string e, string VUnumber)
        {

            try
            {
                e = e.Remove(e.Length - 4, 1);
                int x = Convert.ToInt32(e);

                if (VUnumber == "VU1")
                {
                    if (x <= 399995 & x >= 225000)
                    {
                        if (VU1band == activeBand.UHF)
                        {
                            return "U";
                        }

                        if (VU1band == activeBand.SATCOM)
                        {
                            return "S";
                        }
                    }

                    if (((x <= 87995 & x >= 30000) || (x <= 173995 & x >= 130000)) & VU1band == activeBand.FM)
                    {
                        return "F";
                    }

                    if ((x <= 155995 & x >= 108000) & VU1band == activeBand.AM)
                    {
                        return "V";
                    }

                    if (((x <= 87975 & x >= 30000) & (VU1band == activeBand.HOPSETS)) || (x >= 0 & x <= 999))
                    {
                        return "E";
                    }
                }


                return "";
            }
            catch (Exception)
            {
                return "";

            }

        }


    }


}
