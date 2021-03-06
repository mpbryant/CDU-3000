﻿using System;
using System.Windows.Forms;


namespace CDU3000
{
    public partial class Controller : Form
    {

        //POWER backing fields
        #region
        private string _egiInuPower = "ON";
        private string _CrpaPower = "ON";
        private string _tacanPower = "ON";
        private string _iffPower = "ON";
        private string _vu1Power = "ON";
        private string _vu2Power = "ON";
        #endregion

        //TACAN backing fields
        #region MyRegion
        private bool _TCNvalChanged = false;
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
        //EGI STATUS backing fields
        private bool _EGIvalChanged = false;
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

        //EGI INU backing fields
        private bool _EgiInuValChanged;
        private string _EgiInuSensRef = "GO";
        private string _EgiInuRaccel = "GO";
        private string _EgiInuSaccel = "GO";
        private string _EgiInuTaccel = "GO";
        private string _EgiInuUgyro = "GO";
        private string _EgiInuVgyro = "GO";
        private string _EgiInuWgyro = "GO";

        //EGI GPS backing fields
        private bool _EgiGpsValChanged;
        private string _EgiGpsBattery = "GO";
        private string _EgiGpsRpu = "GO";
        private string _EgiGpsEgr = "GO";

        #endregion

        //HF1 backing fields
        #region MyRegion
        private bool _HF1valueChanged;
        private string _HF11553 = "GO";
        private string _HF1ampl = "GO";
        private string _HF1hitemp = "GO";
        private string _HF1cplr = "GO";
        private string _HF1eqpt = "GO";
        private string _HF1rcvOvrld = "GO";
        private string _HF1rt = "GO";
        private string _HF1vswr = "GO";
        private string _HF1tune = "GO";
        private string _HF1ovrvlt = "GO";
        private string _HF1fiber = "GO";
        #endregion

        //VU1 backing fields
        #region
        private bool _VU1valChanged = true;
        private string _VU1trans = "GO";
        private string _VU1PwrSply = "GO";
        private string _VU1modem = "GO";
        private string _VU1RT = "GO";
        private string _VU11553 = "GO";
        private string _VU1comsec = "GO";
        #endregion

        //VU2 backing fields
        #region
        private string _VU2trans = "GO";
        private bool _VU2valChanged = true;
        private string _VU2PwrSply = "GO";
        private string _VU2modem = "GO";
        private string _VU2RT = "GO";
        private string _VU21553 = "GO";
        private string _VU2comsec = "GO";

        #endregion

        //IFF backing fields
        #region
        private string _IFFmodeS = "GO";
        private string _IFFant = "GO";
        private string _IFFmode4 = "GO";
        private string _IFFmodeC = "GO";
        private string _IFFtod = "GO";
        private string _IFF1553 = "GO";
        private string _IFFmode5 = "GO";
        private string _IFFmode3 = "GO";
        private string _IFFmode2 = "GO";
        private string _IFFmode1 = "GO";

        private bool _iffValueChanged;
        #endregion



        //VU1
        #region Accessors

        public bool VU1ValueChanged
        {
            get
            {
                return _VU1valChanged; ;
            }

            set
            {
                _VU1valChanged = false;
            }
        }

        public string VU1Transmitter
        {
            get
            {
                return _VU1trans;
            }
        }

        public string VU1PowerSupply
        {
            get
            {
                return _VU1PwrSply;
            }
        }

        public string VU1Modem
        {
            get
            {
                return _VU1modem;
            }
        }

        public string VU1RT
        {
            get
            {
                return _VU1RT;
            }
        }

        public string VU11553
        {
            get
            {
                return _VU11553;
            }
        }

        public string VU1Comsec
        {
            get
            {
                return _VU1comsec;
            }
        }

        #endregion

        #region Checkboxes

        private void vu1transCb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1transCb.Checked)
            {
                _VU1trans = "GO";
            }
            else
            {
                _VU1trans = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu1PwrSplycb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1PwrSplycb.Checked)
            {
                _VU1PwrSply = "GO";
            }
            else
            {
                _VU1PwrSply = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu1modemCb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1modemCb.Checked)
            {
                _VU1modem = "GO";
            }
            else
            {
                _VU1modem = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu1RTcb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1RTcb.Checked)
            {
                _VU1RT = "GO";
            }
            else
            {
                _VU1RT = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu11553Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu11553Cb.Checked)
            {
                _VU11553 = "GO";
            }
            else
            {
                _VU11553 = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu1comsecCb_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1comsecCb.Checked)
            {
                _VU1comsec = "GO";
            }
            else
            {
                _VU1comsec = "NGO";
                _VU1valChanged = true;
            }
        }

        private void vu1ALLGOcb_Click(object sender, EventArgs e)
        {
            vu1transCb.Checked = true;
            vu1PwrSplycb.Checked = true;
            vu1modemCb.Checked = true;
            vu1RTcb.Checked = true;
            vu11553Cb.Checked = true;
            vu1comsecCb.Checked = true;
        }

        private void vu1ALLNGOcb_Click(object sender, EventArgs e)
        {
            vu1transCb.Checked = false;
            vu1PwrSplycb.Checked = false;
            vu1modemCb.Checked = false;
            vu1RTcb.Checked = false;
            vu11553Cb.Checked = false;
            vu1comsecCb.Checked = false;
        }
        #endregion

        //VU2
        #region Accessors

        public bool VU2ValueChanged
        {
            get
            {
                return _VU2valChanged; ;
            }

            set
            {
                _VU2valChanged = false;
            }
        }

        public string VU2Transmitter
        {
            get
            {
                return _VU2trans;
            }
        }

        public string VU2PowerSupply
        {
            get
            {
                return _VU2PwrSply;
            }
        }

        public string VU2Modem
        {
            get
            {
                return _VU2modem;
            }
        }

        public string VU2RT
        {
            get
            {
                return _VU2RT;
            }
        }

        public string VU21553
        {
            get
            {
                return _VU21553;
            }
        }

        public string VU2Comsec
        {
            get
            {
                return _VU2comsec;
            }
        }

        #endregion

        #region Checkboxes
        private void vu2TransCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2TransCB.Checked)
            {
                _VU2trans = "GO";
            }
            else
            {
                _VU2trans = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu2PwrSplyCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2PwrSplyCB.Checked)
            {
                _VU2PwrSply = "GO";
            }
            else
            {
                _VU2PwrSply = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu2ModemCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2ModemCB.Checked)
            {
                _VU2modem = "GO";
            }
            else
            {
                _VU2modem = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu2RtCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2RtCB.Checked)
            {
                _VU2RT = "GO";
            }
            else
            {
                _VU2RT = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu21553CB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu21553CB.Checked)
            {
                _VU21553 = "GO";
            }
            else
            {
                _VU21553 = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu2ComsecCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2ComsecCB.Checked)
            {
                _VU2comsec = "GO";
            }
            else
            {
                _VU2comsec = "NGO";
                _VU2valChanged = true;
            }
        }

        private void vu2ALLGObtn_Click(object sender, EventArgs e)
        {
            vu2TransCB.Checked = true;
            vu2PwrSplyCB.Checked = true;
            vu2ModemCB.Checked = true;
            vu2RtCB.Checked = true;
            vu21553CB.Checked = true;
            vu2ComsecCB.Checked = true;
        }

        private void vu2ALLNGObtn_Click(object sender, EventArgs e)
        {
            vu2TransCB.Checked = false;
            vu2PwrSplyCB.Checked = false;
            vu2ModemCB.Checked = false;
            vu2RtCB.Checked = false;
            vu21553CB.Checked = false;
            vu2ComsecCB.Checked = false;
        }
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
                return _EGIsub;
            }
        }

        public string EGIcaic
        {
            get
            {
                return _EGIcaic;
            }
        }

        public string EGIinu
        {
            get
            {
                return _EGIinu;
            }
        }

        public string EGItrm
        {
            get
            {
                return _EGItrm;
            }
        }

        public string EGI1553
        {
            get
            {
                return _EGI1553;
            }
        }

        public string EGIieTempc
        {
            get
            {
                return _EGIieTempc;
            }
        }

        public string EGIio
        {
            get
            {
                return _EGIio;
            }
        }

        public string EGIpwr
        {
            get
            {
                return _EGIpwr;
            }
        }

        public string EGIproc
        {
            get
            {
                return _EGIproc;
            }
        }

        public string EGIgps
        {
            get
            {
                return _EGIgps;
            }
        }

        #endregion

        #region Checkboxes

        private void EgiSubcb_CheckedChanged(object sender, EventArgs e)
        {
            if (EgiSubcb.Checked)
            {
                _EGIsub = "GO";
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
                _EGIinu = "GO";
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
                _EGIieTempc = "GO";
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

        //EGI INU

        #region Accessors

        //holds value that represents if the value has changed since it was last visited
        public bool EgiInuValueChanged
        {
            get
            {
                return _EgiInuValChanged;
            }

            set
            {
                _EgiInuValChanged = false;
            }
        }

        public string EgiInuSensRef
        {
            get
            {
                return _EgiInuSensRef;
            }
        }

        public string EgiInuRaccel
        {
            get
            {
                return _EgiInuRaccel;
            }
        }

        public string EgiInuSaccel
        {
            get
            {
                return _EgiInuSaccel;
            }
        }

        public string EgiInuTaccel
        {
            get
            {
                return _EgiInuTaccel;
            }
        }

        public string EgiInuUgyro
        {
            get
            {
                return _EgiInuUgyro;
            }
        }

        public string EgiInuVgyro
        {
            get
            {
                return _EgiInuVgyro;
            }
        }

        public string EgiInuWgyro
        {
            get
            {
                return _EgiInuWgyro;
            }
        }



        #endregion

        #region Checkboxes
        private void EgiInuSensRefcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuSensRefcb.Checked)
                {
                    _EgiInuSensRef = "GO";
                }
                else
                {
                    _EgiInuSensRef = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuSensRef = "- - -";
            }

        }

        private void EgiInuRaccelcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuRaccelcb.Checked)
                {
                    _EgiInuRaccel = "GO";
                }
                else
                {
                    _EgiInuRaccel = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuRaccel = "- - -";
            }
        }

        private void EgiInuSaccelcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuSaccelcb.Checked)
                {
                    _EgiInuSaccel = "GO";
                }
                else
                {
                    _EgiInuSaccel = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuSaccel = "- - -";
            }
        }

        private void EgiInuTaccelcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuTaccelcb.Checked)
                {
                    _EgiInuTaccel = "GO";
                }
                else
                {
                    _EgiInuTaccel = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuTaccel = "- - -";
            }
        }

        private void EgiInuUgyrocb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuUgyrocb.Checked)
                {
                    _EgiInuUgyro = "GO";
                }
                else
                {
                    _EgiInuUgyro = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuUgyro = "- - -";
            }
        }

        private void EgiInuVgyrocb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuVgyrocb.Checked)
                {
                    _EgiInuVgyro = "GO";
                }
                else
                {
                    _EgiInuVgyro = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuVgyro = "- - -";
            }
        }

        private void EgiInuWgyrocb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiInuWgyrocb.Checked)
                {
                    _EgiInuWgyro = "GO";
                }
                else
                {
                    _EgiInuWgyro = "NGO";
                    _EgiInuValChanged = true;
                }
            }
            else
            {
                _EgiInuWgyro = "- - -";
            }
        }

        private void EgiInuAllGObtn_Click(object sender, EventArgs e)
        {
            EgiInuSensRefcb.Checked = true;
            EgiInuRaccelcb.Checked = true;
            EgiInuSaccelcb.Checked = true;
            EgiInuTaccelcb.Checked = true;
            EgiInuUgyrocb.Checked = true;
            EgiInuVgyrocb.Checked = true;
            EgiInuWgyrocb.Checked = true;

        }

        private void EgiInuAllNGObtn_Click(object sender, EventArgs e)
        {
            EgiInuSensRefcb.Checked = false;
            EgiInuRaccelcb.Checked = false;
            EgiInuSaccelcb.Checked = false;
            EgiInuTaccelcb.Checked = false;
            EgiInuUgyrocb.Checked = false;
            EgiInuVgyrocb.Checked = false;
            EgiInuWgyrocb.Checked = false;
        }
        #endregion

        //EGI GPS

        #region Accessors

        public bool EgiGpsValueChanged
        {
            get
            {
                return _EgiGpsValChanged;
            }

            set
            {
                _EgiGpsValChanged = false;
            }
        }

        public string EgiGpsBattery
        {
            get
            {
                return _EgiGpsBattery;
            }
        }

        public string EgiGpsRpu
        {
            get
            {
                return _EgiGpsRpu;
            }
        }

        public string EgiGpsEgr
        {
            get
            {
                return _EgiGpsEgr;
            }
        }


        #endregion

        #region Checkboxes

        private void EgiGpsBatteryGOcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiGpsBatteryGOcb.Checked)
                {
                    _EgiGpsBattery = "GO";
                }
                else
                {
                    _EgiGpsBattery = "NGO";
                    _EgiGpsValChanged = true;
                }
            }
            else
            {
                _EgiGpsBattery = "- - -";
            }
        }

        private void EgiGpsRpuGOcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiGpsRpuGOcb.Checked)
                {
                    _EgiGpsRpu = "GO";
                }
                else
                {
                    _EgiGpsRpu = "NGO";
                    _EgiGpsValChanged = true;
                }
            }
            else
            {
                _EgiGpsRpu = "- - -";
            }
        }

        private void EgiGpsEgrGOcb_CheckedChanged(object sender, EventArgs e)
        {
            if (_egiInuPower == "ON")
            {
                if (EgiGpsEgrGOcb.Checked)
                {
                    _EgiGpsEgr = "GO";
                }
                else
                {
                    _EgiGpsEgr = "NGO";
                    _EgiGpsValChanged = true;
                }
            }
            else
            {
                _EgiGpsEgr = "- - -";
            }
        }

        private void EgiGpsAllGObtn_Click(object sender, EventArgs e)
        {
            EgiGpsEgrGOcb.Checked = true;
            EgiGpsRpuGOcb.Checked = true;
            EgiGpsBatteryGOcb.Checked = true;
        }

        private void EgiGpsAllNGObtn_Click(object sender, EventArgs e)
        {
            EgiGpsEgrGOcb.Checked = false;
            EgiGpsRpuGOcb.Checked = false;
            EgiGpsBatteryGOcb.Checked = false;
        }

        #endregion

        //HF1

        #region Accessors
        public bool HF1ValueChanged
        {
            get
            {
                return _HF1valueChanged;
            }

            set
            {
                _HF1valueChanged = false;
            }
        }

        public string HF11553
        {
            get
            {
                return _HF11553;
            }
        }

        public string HF1Ampl
        {
            get
            {
                return _HF1ampl;
            }
        }

        public string HF1HiTemp
        {
            get
            {
                return _HF1hitemp;
            }
        }

        public string HF1Cplr
        {
            get
            {
                return _HF1cplr;
            }
        }

        public string HF1Eqpt
        {
            get
            {
                return _HF1eqpt;
            }
        }

        public string HF1RcvOvrld
        {
            get
            {
                return _HF1rcvOvrld;
            }
        }

        public string HF1RT
        {
            get
            {
                return _HF1rt;
            }
        }

        public string HF1VSWR
        {
            get
            {
                return _HF1vswr;
            }
        }

        public string HF1Tune
        {
            get
            {
                return _HF1tune;
            }
        }

        public string HF1OverVlt
        {
            get
            {
                return _HF1ovrvlt;
            }
        }

        public string HF1Fiber
        {
            get
            {
                return _HF1fiber;
            }
        }


        #endregion

        #region Checkboxes
        private void HF1amplCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1amplCB.Checked)
            {
                _HF1ampl = "GO";
            }
            else
            {
                _HF1ampl = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1hitempCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1hitempCB.Checked)
            {
                _HF1hitemp = "GO";
            }
            else
            {
                _HF1hitemp = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1cplrCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1cplrCB.Checked)
            {
                _HF1cplr = "GO";
            }
            else
            {
                _HF1cplr = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1eqptCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1eqptCB.Checked)
            {
                _HF1eqpt = "GO";
            }
            else
            {
                _HF1eqpt = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF11553CB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF11553CB.Checked)
            {
                _HF11553 = "GO";
            }
            else
            {
                _HF11553 = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1rcvOvrldCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1rcvOvrldCB.Checked)
            {
                _HF1rcvOvrld = "GO";
            }
            else
            {
                _HF1rcvOvrld = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1rtCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1rtCB.Checked)
            {
                _HF1rt = "GO";
            }
            else
            {
                _HF1rt = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1vswrCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1vswrCB.Checked)
            {
                _HF1vswr = "GO";
            }
            else
            {
                _HF1vswr = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1tuneCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1tuneCB.Checked)
            {
                _HF1tune = "GO";
            }
            else
            {
                _HF1tune = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1overvltCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1overvltCB.Checked)
            {
                _HF1ovrvlt = "GO";
            }
            else
            {
                _HF1ovrvlt = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1fiberCB_CheckedChanged(object sender, EventArgs e)
        {
            if (HF1fiberCB.Checked)
            {
                _HF1fiber = "GO";
            }
            else
            {
                _HF1fiber = "NGO";
                _HF1valueChanged = true;
            }
        }

        private void HF1allGoBtn_Click(object sender, EventArgs e)
        {
            HF11553CB.Checked = true;
            HF1amplCB.Checked = true;
            HF1hitempCB.Checked = true;
            HF1cplrCB.Checked = true;
            HF1eqptCB.Checked = true;
            HF1rcvOvrldCB.Checked = true;
            HF1rtCB.Checked = true;
            HF1vswrCB.Checked = true;
            HF1tuneCB.Checked = true;
            HF1overvltCB.Checked = true;
            HF1fiberCB.Checked = true;
            _HF1valueChanged = true;
        }

        private void HF1AllNgoBtn_Click(object sender, EventArgs e)
        {
            HF11553CB.Checked = false;
            HF1amplCB.Checked = false;
            HF1hitempCB.Checked = false;
            HF1cplrCB.Checked = false;
            HF1eqptCB.Checked = false;
            HF1rcvOvrldCB.Checked = false;
            HF1rtCB.Checked = false;
            HF1vswrCB.Checked = false;
            HF1tuneCB.Checked = false;
            HF1overvltCB.Checked = false;
            HF1fiberCB.Checked = false;
            _HF1valueChanged = true;
        }
        #endregion

        //IFF

        #region Accessors

        public bool iffValChanged
        {
            get
            {
                return _iffValueChanged;
            }

            set
            {
                _iffValueChanged = false;
            }
        }

        public string iffMode1
        {
            get
            {
                return _IFFmode1;
            }
        }

        public string iffMode2
        {
            get
            {
                return _IFFmode2;
            }
        }

        public string iffMode3
        {
            get
            {
                return _IFFmode3;
            }
        }

        public string iffMode4
        {
            get
            {
                return _IFFmode4;
            }
        }

        public string iffMode5
        {
            get
            {
                return _IFFmode5;
            }
        }

        public string iffModeC
        {
            get
            {
                return _IFFmodeC;
            }
        }

        public string iffModeS
        {
            get
            {
                return _IFFmodeS;
            }
        }

        public string iffTOD
        {
            get
            {
                return _IFFtod;
            }
        }

        public string iff1553
        {
            get
            {
                return _IFF1553;
            }
        }

        public string iffAnt
        {
            get
            {
                return _IFFant;
            }
        }

        #endregion

        #region Checkboxes

        private void antCB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFant = state;
        }

        private void mode1CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmode1 = state;
        }

        private void mode2CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmode2 = state;
        }

        private void mode3CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmode3 = state;
        }

        private void mode5CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmode5 = state;
        }

        private void iff1553CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFF1553 = state;
        }

        private void todCB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFtod = state;
        }

        private void modecCB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmodeC = state;
        }

        private void mode4CB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmode4 = state;
        }

        private void modesCB_CheckedChanged(object sender, EventArgs e)
        {
            string state;
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                state = "GO";
            }
            else
            {
                state = "NGO";
                _iffValueChanged = true;
            }

            _IFFmodeS = state;
        }

        private void iffAllGObtn_Click(object sender, EventArgs e)
        {
            antCB.Checked = true;
            iff1553CB.Checked = true;
            mode1CB.Checked = true;
            mode2CB.Checked = true;
            mode3CB.Checked = true;
            mode4CB.Checked = true;
            mode5CB.Checked = true;
            modecCB.Checked = true;
            modesCB.Checked = true;
            todCB.Checked = true;

            _IFF1553 = "GO";
            _IFFant = "GO";
            _IFFmode1 = "GO";
            _IFFmode2 = "GO";
            _IFFmode3 = "GO";
            _IFFmode4 = "GO";
            _IFFmode5 = "GO";
            _IFFmodeC = "GO";
            _IFFmodeS = "GO";
            _IFFtod = "GO";

            _iffValueChanged = true;
        }

        private void iffAllNGObtn_Click(object sender, EventArgs e)
        {
            antCB.Checked = false;
            iff1553CB.Checked = false;
            mode1CB.Checked = false;
            mode2CB.Checked = false;
            mode3CB.Checked = false;
            mode4CB.Checked = false;
            mode5CB.Checked = false;
            modecCB.Checked = false;
            modesCB.Checked = false;
            todCB.Checked = false;

            _IFF1553 = "NGO";
            _IFFant = "NGO";
            _IFFmode1 = "NGO";
            _IFFmode2 = "NGO";
            _IFFmode3 = "NGO";
            _IFFmode4 = "NGO";
            _IFFmode5 = "NGO";
            _IFFmodeC = "NGO";
            _IFFmodeS = "NGO";
            _IFFtod = "NGO";

            _iffValueChanged = true;
        }

        #endregion

        //POWER

        #region Accessors

        public string EgiInuPower
        {
            get
            {
                return _egiInuPower;
            }
        }

        public string CRPAPower
        {
            get
            {
                return _CrpaPower;
            }
        }

        public string TacanPower
        {
            get
            {
                return _tacanPower;
            }
        }

        public string IffPower
        {
            get
            {
                return _iffPower;
            }
        }

        public string VU1Power
        {
            get
            {
                return _vu1Power;
            }
        }

        public string VU2Power
        {
            get
            {
                return _vu2Power;
            }
        }

        #endregion

        #region Checkboxes

        private void egiInuPowerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (egiInuPowerCB.Checked == true)
            {
                _egiInuPower = "ON";
                EgiInuAllGObtn_Click(null, null);
                EgiAllGobtn_Click(null, null);
                EgiGpsAllGObtn_Click(null, null);


            }
            else
            {
                _egiInuPower = "OFF";

                EgiInuAllNGObtn_Click(null, null);
                EgiAllNGObtn_Click(null, null);
                EgiGpsAllNGObtn_Click(null, null);


                _EGIsub = "- - -";
                _EGIcaic = "- - -";
                _EGIinu = "- - -";
                _EGI1553 = "NGO-T";
                _EGItrm = "- - -";
                _EGIieTempc = "- - -";
                _EGIio = "- - -";
                _EGIpwr = "- - -";
                _EGIproc = "- - -";
                _EGIgps = "- - -";
                _EgiInuSensRef = "- - -";
                _EgiInuRaccel = "- - -";
                _EgiInuSaccel = "- - -";
                _EgiInuTaccel = "- - -";
                _EgiInuUgyro = "- - -";
                _EgiInuVgyro = "- - -";
                _EgiInuWgyro = "- - -";


            }
        }

        private void Crpa_CheckedChanged(object sender, EventArgs e)
        {
            if (CrpaPowerCB.Checked == true)
            {
                _CrpaPower = "ON";
            }
            else
            {
                _CrpaPower = "OFF";
            }
        }

        private void tcnPowerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (tcnPowerCB.Checked == true)
            {
                _tacanPower = "ON";
            }
            else
            {
                _tacanPower = "OFF";
            }
        }

        private void iffPowerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (iffPowerCB.Checked == true)
            {
                _iffPower = "ON";
            }
            else
            {
                _iffPower = "OFF";
            }
        }

        private void vu1PowerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu1PowerCB.Checked == true)
            {
                _vu1Power = "ON";
            }
            else
            {
                _vu1Power = "OFF";
                _VU1valChanged = true;
            }
        }

        private void vu2PowerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (vu2PowerCB.Checked == true)
            {
                _vu2Power = "ON";
            }
            else
            {
                _vu2Power = "OFF";
                _VU2valChanged = true;
            }
        }

        private void mpAllOnBtn_Click(object sender, EventArgs e)
        {
            egiInuPowerCB.Checked = true;
            CrpaPowerCB.Checked = true;
            tcnPowerCB.Checked = true;
            iffPowerCB.Checked = true;
            vu1PowerCB.Checked = true;
            vu2PowerCB.Checked = true;
        }

        private void mpAllOffBtn_Click(object sender, EventArgs e)
        {
            egiInuPowerCB.Checked = false;
            CrpaPowerCB.Checked = false;
            tcnPowerCB.Checked = false;
            iffPowerCB.Checked = false;
            vu1PowerCB.Checked = false;
            vu2PowerCB.Checked = false;
        }

        #endregion

        //REVISONARY PANEL

        #region ACCESSORS

        public bool IFFselected
        {
            get
            {
                return IFFselectBtn.Checked;
            }
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

        public Controller()
        {
            InitializeComponent();
        }
































    }
}
