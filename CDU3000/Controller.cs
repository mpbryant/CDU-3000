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
    public partial class Controller : Form
    {
        private bool _TCNvalChanged = false;
        private bool _EGIvalChanged = false;

        
        //TACAN backing fields
        #region MyRegion
        private string _nvram = "GO";
        private string _micro = "GO";
        private string _audio = "GO";
        private string _rt = "GO";
        private string _1553 = "GO";
        private string _sub = "GO";
        private string _trm = "GO";
        private string _pwr = "GO";
        private string _ram = "GO";
        private string _rom = "GO";
        private string _tun = "GO";
        private string _rcv = "GO";
        private string _synth = "GO";
        private string _dpdat = "GO";
        private string _dpram = "GO"; 
        #endregion

        //EGI backing fields
        #region MyRegion
        private string _EGIsub = "GO";
        private string _EGIcaic = "GO";
        private string _EGIinu = "GO";
        private string _EGItrm = "GO";
        private string _EGI1553 = "GO";
        private string _EGIieTempc = "GO";
        private string _EGIio = "GO";
        private string _EGIpwr = "GO";
        private string _EGIproc = "GO";
        private string _EGIgps = "GO";
        
        #endregion

        //EGI
        #region Accessors

        //holds value that represents if the value has changed since it was last visited
        public bool EGIvalueChanged
        {
            get
            {
                return _EGIvalChanged;
            }

            set
            {
                _EGIvalChanged = false;
            }
        }

        public string EGIsub
        {
            get
            {
                return _EGIsub ;
            }
        }

        public string EGIcaic
        {
            get
            {
                return _EGIcaic ;
            }
        }

        public string EGIinu
        {
            get
            {
                return _EGIinu ;
            }
        }

        public string EGItrm
        {
            get
            {
                return _EGItrm ;
            }
        }

        public string EGI1553
        {
            get
            {
                return _EGI1553 ;
            }
        }

        public string EGIieTempc
        {
            get
            {
                return _EGIieTempc ;
            }
        }

        public string EGIio
        {
            get
            {
                return _EGIio ;
            }
        }

        public string EGIpwr
        {
            get
            {
                return _EGIpwr ;
            }
        }

        public string EGIproc
        {
            get
            {
                return _EGIproc ;
            }
        }

        public string EGIgps
        {
            get
            {
                return _EGIgps ;
            }
        }

        #endregion

        #region Checkboxes

        private void EgiSubcb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiSubcb.Checked)
            {
                _EGIsub  = "GO";
            }
            else
            {
                _EGIsub = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiCaiccb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiCaiccb.Checked)
            {
                _EGIcaic = "GO";
            }
            else
            {
                _EGIcaic = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiInucb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiInucb.Checked)
            {
                _EGIinu  = "GO";
            }
            else
            {
                _EGIinu = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiTrmcb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiTrmcb.Checked)
            {
                _EGItrm = "GO";
            }
            else
            {
                _EGItrm = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void Egi1553cb_CheckedChanged(object sender, EventArgs e)
        {
            if (Egi1553cb.Checked)
            {
                _EGI1553 = "GO";
            }
            else
            {
                _EGI1553 = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiIeTempccb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiIeTempccb.Checked)
            {
                _EGIieTempc  = "GO";
            }
            else
            {
                _EGIieTempc = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiIocb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiIocb.Checked)
            {
                _EGIio = "GO";
            }
            else
            {
                _EGIio = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiPwrcb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiPwrcb.Checked)
            {
                _EGIpwr = "GO";
            }
            else
            {
                _EGIpwr = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiProccb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiProccb.Checked)
            {
                _EGIproc = "GO";
            }
            else
            {
                _EGIproc = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiGpscb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiGpscb.Checked)
            {
                _EGIgps = "GO";
            }
            else
            {
                _EGIgps = "NGO";
                _EGIvalChanged = true;
            }
        }

        private void EgiAllNGObtn_Click(object sender, EventArgs e)
        {
            EgiSubcb.Checked = false;
            EgiCaiccb.Checked = false;
            EgiInucb.Checked = false;
            EgiTrmcb.Checked = false;
            Egi1553cb.Checked = false;
            EgiIeTempccb.Checked = false;
            EgiIocb.Checked = false;
            EgiPwrcb.Checked = false;
            EgiProccb.Checked = false;
            EgiGpscb.Checked = false;
            
        }

        private void EgiAllGobtn_Click(object sender, EventArgs e)
        {
            EgiSubcb.Checked = true;
            EgiCaiccb.Checked = true;
            EgiInucb.Checked = true;
            EgiTrmcb.Checked = true;
            Egi1553cb.Checked = true;
            EgiIeTempccb.Checked = true;
            EgiIocb.Checked = true;
            EgiPwrcb.Checked = true;
            EgiProccb.Checked = true;
            EgiGpscb.Checked = true;
        }

        #endregion

        //TACAN

        #region MyRegion
        #region Accessors

        //holds value that represents if the value has changed since it was last visited
        public bool TCNvalueChanged
        {
            get
            {
                return _TCNvalChanged;
            }
            set
            {
                _TCNvalChanged = false;
            }
        }


        public string TacanNVRAM
        {
            get
            {
                return _nvram;
            }
        }

        public string TacanMicro
        {
            get
            {
                return _micro;
            }
        }

        public string TacanAudio
        {
            get
            {
                return _audio;
            }
        }

        public string TacanRt
        {
            get
            {
                return _rt;
            }
        }

        public string Tacan1553
        {
            get
            {
                return _1553;
            }
        }

        public string TacanSub
        {
            get
            {
                return _sub;
            }

        }

        public string TacanTrm
        {
            get
            {
                return _trm;
            }
        }

        public string TacanPwr
        {
            get
            {
                return _pwr;
            }
        }

        public string TacanRam
        {
            get
            {
                return _ram;
            }
        }

        public string TacanRom
        {
            get
            {
                return _rom;
            }
        }

        public string TacanTun
        {
            get
            {
                return _tun;
            }
        }

        public string TacanRcv
        {
            get
            {
                return _rcv;
            }
        }

        public string TacanSynth
        {
            get
            {
                return _synth;
            }
        }

        public string TacanDpdat
        {
            get
            {
                return _dpdat;
            }
        }

        public string TacanDpram
        {
            get
            {
                return _dpram;
            }
        }
        #endregion

        #region CheckBoxes
        private void nvramGo_CheckedChanged(object sender, EventArgs e)
        {
            if (nvramGo.Checked)
            {
                _nvram = "GO";
            }
            else
            {
                _nvram = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void microGo_CheckedChanged(object sender, EventArgs e)
        {
            if (microGo.Checked)
            {
                _micro = "GO";
            }
            else
            {
                _micro = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void audioGo_CheckedChanged(object sender, EventArgs e)
        {
            if (audioGo.Checked)
            {
                _audio = "GO";
            }
            else
            {
                _audio = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void rtGo_CheckedChanged(object sender, EventArgs e)
        {
            if (rtGo.Checked)
            {
                _rt = "GO";
            }
            else
            {
                _rt = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void busGo_CheckedChanged(object sender, EventArgs e)
        {
            if (busGo.Checked)
            {
                _1553 = "GO";
            }
            else
            {
                _1553 = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void subGo_CheckedChanged(object sender, EventArgs e)
        {
            if (subGo.Checked)
            {
                _sub = "GO";
            }
            else
            {
                _sub = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void ramGo_CheckedChanged(object sender, EventArgs e)
        {
            if (ramGo.Checked)
            {
                _ram = "GO";
            }
            else
            {
                _ram = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void tunGo_CheckedChanged(object sender, EventArgs e)
        {
            if (tunGo.Checked)
            {
                _tun = "GO";
            }
            else
            {
                _tun = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void trmGo_CheckedChanged(object sender, EventArgs e)
        {
            if (trmGo.Checked)
            {
                _trm = "GO";
            }
            else
            {
                _trm = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void pwrGo_CheckedChanged(object sender, EventArgs e)
        {
            if (pwrGo.Checked)
            {
                _pwr = "GO";
            }
            else
            {
                _pwr = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void romGo_CheckedChanged(object sender, EventArgs e)
        {
            if (romGo.Checked)
            {
                _rom = "GO";
            }
            else
            {
                _rom = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void rcvGo_CheckedChanged(object sender, EventArgs e)
        {
            if (rcvGo.Checked)
            {
                _rcv = "GO";
            }
            else
            {
                _rcv = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void synthGo_CheckedChanged(object sender, EventArgs e)
        {
            if (synthGo.Checked)
            {
                _synth = "GO";
            }
            else
            {
                _synth = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void dpdatGo_CheckedChanged(object sender, EventArgs e)
        {
            if (dpdatGo.Checked)
            {
                _dpdat = "GO";
            }
            else
            {
                _dpdat = "NGO";
                _TCNvalChanged = true;
            }

        }

        private void dpramGo_CheckedChanged(object sender, EventArgs e)
        {
            if (dpramGo.Checked)
            {
                _dpram = "GO";
            }
            else
            {
                _dpram = "NGO";
                _TCNvalChanged = true;
            }

        }
        #endregion

        private void TcnAllNGObtn_Click(object sender, EventArgs e)
        {
            nvramGo.Checked = false;
            microGo.Checked = false;
            audioGo.Checked = false;
            rtGo.Checked = false;
            busGo.Checked = false;
            subGo.Checked = false;
            ramGo.Checked = false;
            tunGo.Checked = false;
            trmGo.Checked = false;
            pwrGo.Checked = false;
            romGo.Checked = false;
            rcvGo.Checked = false;
            synthGo.Checked = false;
            dpdatGo.Checked = false;
            dpramGo.Checked = false;

        }

        private void TcnAllGoBtn_Click(object sender, EventArgs e)
        {
            nvramGo.Checked = true;
            microGo.Checked = true;
            audioGo.Checked = true;
            rtGo.Checked = true;
            busGo.Checked = true;
            subGo.Checked = true;
            ramGo.Checked = true;
            tunGo.Checked = true;
            trmGo.Checked = true;
            pwrGo.Checked = true;
            romGo.Checked = true;
            rcvGo.Checked = true;
            synthGo.Checked = true;
            dpdatGo.Checked = true;
            dpramGo.Checked = true;
        } 
        #endregion

        public Controller( )
        {
            InitializeComponent ( );

        }

        

        
    }
}
