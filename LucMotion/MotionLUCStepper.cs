using Luc.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static Luc.Motion.AxisBase;

namespace Luc.Motion
{
    public class MotionLUCStepper : MotionBase, IMotion
    {
        private static MotionLUCStepper m_motionLUC = null;        

        public static MotionLUCStepper GetInstance()
        {
            if (m_bIsUseMotion)
            {
                if (m_motionLUC == null)
                {
                    m_motionLUC = new MotionLUCStepper();
                }

                return m_motionLUC;
            }

            return null;
        }

        public enum CMD
        {
            NONE = 0,
            ALLSTOP,
            ALLHOME,
            MOVE_MOT1,
            SET_VEL_MOT,
            GET_VEL_MOT,
            GET_POS_MOT,
            GET_LMT_MOT,
            GET_HOME_STATE,
            IS_MOVE_MOT,
            TEST_CMD,
        }

        public static int MAX_AXIS_CNT = 4;

        public static string INIKEY_COMPORT = "COMPORT";
        public static string INIKEY_CONNECTED = "CONNECTED";

        private SerialPort _serialPort = new SerialPort();
        private System.Timers.Timer _serialMonitorTimer = new System.Timers.Timer();
        private bool _bIsConnected = false;
        private BackgroundWorker _backgroundMonitor = new BackgroundWorker();

        private CMD _cmd = CMD.NONE;

        public bool _bIsDebugData = false;
        public bool _bIsCommanded = false;
        public string _strRecvData = string.Empty;
        public string _strTestCmdData = string.Empty;

        object _lock = new object();

        private List<AxisLUCStepper> _listAxis = null;
        public List<AxisLUCStepper> ListAxis
        {
            get { return _listAxis; }
        }

        public string PortName
        {
            get { return _serialPort.PortName; }
            set
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                _serialPort.PortName = value;
            }
        }

        public MotionLUCStepper()
        {
            _serialPort.PortName = "COM1";
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DtrEnable = true;
            _serialPort.RtsEnable = true;
            _serialPort.ReadTimeout = 5000;

            _serialMonitorTimer.Interval = 50;
            _serialMonitorTimer.Elapsed += _serialMonitorTimer_Elapsed;

            m_nAxisCount = MAX_AXIS_CNT;

            _listAxis = new List<AxisLUCStepper>(m_nAxisCount);
            for (int i = 0; i < m_nAxisCount; i++)
            {
                AxisLUCStepper axis = new AxisLUCStepper(this);
                axis.SerialPort = _serialPort;
                axis.AxisNumber = i;
                axis.DevName = i.ToString();

                _listAxis.Add(axis);
            }

            _backgroundMonitor.WorkerReportsProgress = true;
            _backgroundMonitor.WorkerSupportsCancellation = true;
            _backgroundMonitor.DoWork += _backgroundMonitor_DoWork;
        }

        private void _backgroundMonitor_DoWork(object sender, DoWorkEventArgs e)
        {
            int command_err = 0;
            int mot_max_cnt = MAX_AXIS_CNT;
            int mot_index = 0;

            while (!_backgroundMonitor.CancellationPending)
            {
                if (_serialPort.IsOpen)
                {
                    Thread.Sleep(1);

                    try
                    {
                        if (_cmd != CMD.TEST_CMD && _bIsDebugData)
                        {
                            if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();
                            Thread.Sleep(8);
                            if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();
                            _bIsDebugData = false;
                        }

                        if (_cmd == CMD.TEST_CMD)
                        {
                            _strRecvData = string.Empty;
                            _serialPort.ReadExisting();
                            Thread.Sleep(10);

                            _strRecvData = SendProtocol(_strTestCmdData, true);

                            _cmd = CMD.NONE;

                            _bIsDebugData = false;
                        }
                        else if (_cmd == CMD.NONE)
                        {
                            _cmd = CMD.GET_POS_MOT;
                        }
                        else
                        {
                            string recv = string.Empty;
                            switch (_cmd)
                            {
                                case CMD.GET_POS_MOT:
                                    {
                                        while (_bIsCommanded) { Thread.Sleep(10); }
                                        Thread.Sleep(8);
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();                                        
                                        recv = SendProtocol("GPS" + (mot_index + 1));
                                        if (!RecvParsing(recv))
                                        {
                                            if (command_err == 5)
                                            {
                                                Disconnect();
                                                break;
                                            }
                                            else
                                            {
                                                command_err++;
                                                continue;
                                            }
                                        }
                                        if (_cmd == CMD.TEST_CMD || _bIsDebugData)
                                        {
                                            continue;
                                        }
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();

                                        command_err = 0;
                                        if (mot_index++ >= mot_max_cnt - 1)
                                        {
                                            _cmd = CMD.GET_LMT_MOT;
                                            mot_index = 0;
                                        }                                        
                                    }
                                    break;
                                

                                case CMD.GET_LMT_MOT:
                                    {
                                        while (_bIsCommanded) { Thread.Sleep(10); }
                                        Thread.Sleep(8);
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();
                                        recv = SendProtocol("GLM" + (mot_index + 1));
                                        if (!RecvParsing(recv))
                                        {
                                            if (command_err == 5)
                                            {
                                                Disconnect();
                                                break;
                                            }
                                            else
                                            {
                                                command_err++;
                                                continue;
                                            }
                                        }
                                        if (_cmd == CMD.TEST_CMD || _bIsDebugData)
                                        {
                                            continue;
                                        }
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();

                                        command_err = 0;
                                        if (mot_index++ >= mot_max_cnt - 1)
                                        {
                                            _cmd = CMD.GET_HOME_STATE;
                                            mot_index = 0;
                                        }
                                    }
                                    break;                                

                                case CMD.GET_HOME_STATE:
                                    {
                                        while (_bIsCommanded) { Thread.Sleep(10); }
                                        Thread.Sleep(8);
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();
                                        recv = SendProtocol("GHS" + (mot_index + 1));
                                        if (!RecvParsing(recv))
                                        {
                                            if (command_err == 5)
                                            {
                                                Disconnect();
                                                break;
                                            }
                                            else
                                            {
                                                command_err++;
                                                continue;
                                            }
                                        }
                                        if (_cmd == CMD.TEST_CMD || _bIsDebugData)
                                        {
                                            continue;
                                        }
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();

                                        command_err = 0;
                                        if (mot_index++ >= mot_max_cnt - 1)
                                        {
                                            _cmd = CMD.IS_MOVE_MOT;
                                            mot_index = 0;
                                        }
                                        
                                    }
                                    break;                                

                                case CMD.IS_MOVE_MOT:
                                    {
                                        while (_bIsCommanded) { Thread.Sleep(10); }
                                        Thread.Sleep(8);
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();
                                        recv = SendProtocol("GIM" + (mot_index + 1));
                                        if (!RecvParsing(recv))
                                        {
                                            if (command_err == 5)
                                            {
                                                Disconnect();
                                                break;
                                            }
                                            else
                                            {
                                                command_err++;
                                                continue;
                                            }
                                        }
                                        if (_cmd == CMD.TEST_CMD || _bIsDebugData)
                                        {
                                            continue;
                                        }
                                        if (_serialPort.BytesToRead > 0) _serialPort.ReadExisting();

                                        command_err = 0;
                                        if (mot_index++ >= mot_max_cnt - 1)
                                        {
                                            _cmd = CMD.GET_POS_MOT;
                                            mot_index = 0;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Disconnect();
                        break;
                    }
                }
            }

            Thread.Sleep(50);
            _serialPort.Close();
        }

        public string TestTerminalSend(string data, bool isCR = true)
        {
            _strTestCmdData = data;
            _cmd = CMD.TEST_CMD;
            while (_cmd == CMD.TEST_CMD) { Thread.Sleep(500); }

            return _strRecvData;
        }

        public string SendProtocol(string cmd, bool isCR = true)
        {
            lock (_lock)
            {
                try
                {
                    string strRet = string.Empty;
                    if (_serialPort.IsOpen)
                    {
                        if (isCR)
                        {
                            _serialPort.WriteLine(cmd);
                        }
                        else
                        {
                            _serialPort.Write(cmd);
                        }

                        if (isCR)
                        {
                            if (_cmd == CMD.TEST_CMD)
                            {
                                Thread.Sleep(500);
                                if (_serialPort.BytesToRead <= 0)
                                {
                                    Stopwatch tout = new Stopwatch();
                                    tout.Reset(); tout.Start();
                                    while (_serialPort.BytesToRead <= 0 && tout.ElapsedMilliseconds < _serialPort.ReadTimeout)
                                    {
                                        Thread.Sleep(10);
                                    }
                                }

                                while (_serialPort.BytesToRead > 0)
                                {
                                    strRet += _serialPort.ReadExisting();
                                    Thread.Sleep(50);
                                }
                            }
                            else
                            {
                                strRet = _serialPort.ReadLine();
                            }

                        }
                        else
                        {
                            Thread.Sleep(100);
                            strRet += _serialPort.ReadExisting();
                            while (_serialPort.BytesToRead > 0)
                            {
                                strRet += _serialPort.ReadExisting();
                                Thread.Sleep(50);
                            }
                        }
                    }

                    return strRet;
                }
                catch (System.Exception)
                {
                    //Disconnect();
                    return string.Empty;
                }
            }
        }

        public bool RecvParsing(string data)
        {
            bool ret = false;
            if (data.Contains("DBG"))
            {
                _bIsDebugData = true;
                return true;
            }

            string[] pars = data.Split(',');
            if (pars != null && pars.Length > 0)
            {
                switch (pars.Length)
                {
                    case 3:
                        {
                            switch (pars[0])
                            {
                                case "POS":
                                    {
                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                double motPos = double.NaN;
                                                if (double.TryParse(pars[2], out motPos))
                                                {
                                                    _listAxis[nMotNum].MotorPosition = motPos;
                                                    ret = true;
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "SVL":
                                    {
                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                double motSpd = double.NaN;
                                                if (double.TryParse(pars[2], out motSpd))
                                                {
                                                    _listAxis[nMotNum].MotorSpeed = motSpd;
                                                    ret = true;
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "SAC":
                                    {
                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                double motAcc = double.NaN;
                                                if (double.TryParse(pars[2], out motAcc))
                                                {
                                                    _listAxis[nMotNum].Acceleration = motAcc;
                                                    ret = true;
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "HMS":
                                    {
                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                int homeState = -1;
                                                if (int.TryParse(pars[2], out homeState))
                                                {
                                                    switch (homeState)
                                                    {
                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_NONE:
                                                            _listAxis[nMotNum].HomeState = HOME_STATE.NONE;
                                                            break;

                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_FIRST:
                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_SECOND:
                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_THIRD:
                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_FOURTH:
                                                            _listAxis[nMotNum].HomeState = HOME_STATE.HOMMING;
                                                            break;

                                                        case (int)AxisLUCStepper.HOMESTATE.HOME_COMPLETED:
                                                            _listAxis[nMotNum].HomeState = HOME_STATE.COMPLETED;
                                                            break;

                                                        default:
                                                            _listAxis[nMotNum].HomeState = HOME_STATE.NONE;
                                                            break;

                                                    }
                                                    ret = true;
                                                }
                                            }
                                        }   
                                    }
                                    break;

                                case "GIM":
                                    {
                                        pars[2] = pars[2].Replace('\r', ' ');

                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                int isMove = -1;
                                                if (int.TryParse(pars[2], out isMove))
                                                {
                                                    _listAxis[nMotNum].MotorIsMoving = isMove == 1 ? true : false;
                                                    ret = true;
                                                }
                                            }
                                        }
                                    }
                                    break;

                                //case "ERR":
                                //    {

                                //    }
                                //    break;

                                case "OK":
                                    {
                                        ret = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    

                    case 4:
                        {
                            switch (pars[0])
                            {
                                case "LMT":
                                    {
                                        int nMotNum = -1;
                                        if (int.TryParse(pars[1], out nMotNum))
                                        {
                                            nMotNum -= 1;
                                            if (nMotNum >= 0 && nMotNum < _listAxis?.Count)
                                            {
                                                int limitN = -1;
                                                if (int.TryParse(pars[2], out limitN))
                                                {
                                                    _listAxis[nMotNum].MotorLimitN = limitN == 1 ? true : false;
                                                    ret = true;
                                                }

                                                int limitP = -1;
                                                if (int.TryParse(pars[3], out limitP))
                                                {
                                                    _listAxis[nMotNum].MotorLimitP = limitP == 1 ? true : false;
                                                    ret = true;
                                                }
                                            }
                                        }                                            
                                    }
                                    break;
                            }
                        }
                        break;

                    default:
                        {
                            if (pars[0] == "OK")
                            {
                                ret = true;
                            }
                        }
                        break;
                }
            }

            return ret;
        }

        private void _serialMonitorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _bIsConnected = m_bIsInitMotion = _serialPort.IsOpen;
        }

        public void Connect()
        {
            if (_serialPort.IsOpen && _backgroundMonitor.IsBusy)
            {
                _backgroundMonitor.CancelAsync();
                while (_backgroundMonitor.IsBusy) { Thread.Sleep(50); }
            }

            try
            {
                _serialPort.BaudRate = 115200;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = true;
                _serialPort.ReadTimeout = 5000;

                _serialPort.Open();
                _bIsConnected = _serialPort.IsOpen;
                _backgroundMonitor.RunWorkerAsync();

                _serialMonitorTimer.Start();
            }
            catch (Exception)
            {
            }
        }

        public void Disconnect()
        {
            if (_serialPort.IsOpen)
            {
                if (_backgroundMonitor.IsBusy)
                {
                    _backgroundMonitor.CancelAsync();                    
                }                

                while (_serialPort.IsOpen) { Thread.Sleep(50); }                
                
                _bIsConnected = false;
            }
        }

        public event EventHandler ChangedSetting;

        public void AllHome()
        {
            throw new NotImplementedException();
        }

        public void AllStop()
        {
            throw new NotImplementedException();
        }

        public double AxisGetActualPosition(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool AxisGetServoOnState(int axisNum)
        {
            throw new NotImplementedException();
        }

        public void AxisHome(int axisNum)
        {
            throw new NotImplementedException();
        }

        public uint AxisHomeState(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool AxisIsBusy(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool AxisIsNegativeLimit(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool AxisIsPositiveLimit(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool AxisIsUse(int axisNum)
        {
            throw new NotImplementedException();
        }

        public void AxisMove(int axisNum, double pos, bool isRel)
        {
            throw new NotImplementedException();
        }

        public void AxisMoveJog(int axisNum, bool isDirectionPostive)
        {
            throw new NotImplementedException();
        }

        public void AxisMoveV(int axisNum, double fPos, double fV)
        {
            throw new NotImplementedException();
        }

        public void AxisMoveV(int axisNum, double fPos, double fPosV, double fV)
        {
            throw new NotImplementedException();
        }

        public void AxisPositionClear(int axisNum)
        {
            throw new NotImplementedException();
        }

        public void AxisSetMoveParameter(int axisNum, double vel, double acc, double dec)
        {
            throw new NotImplementedException();
        }

        public void AxisSetServoOn(int axisNum, bool isOn)
        {
            //throw new NotImplementedException();
        }

        public void AxisStop(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool GantryGetStatus()
        {
            throw new NotImplementedException();
        }

        public bool GantrySetDisable()
        {
            throw new NotImplementedException();
        }

        public bool GantrySetEnable()
        {
            throw new NotImplementedException();
        }

        public string GetAxisDevName(int axisNum)
        {
            throw new NotImplementedException();
        }

        public string GetDevName(int axisNum)
        {
            throw new NotImplementedException();
        }

        public double GetPosDst(int axisNum)
        {
            throw new NotImplementedException();
        }

        public void InitMotion()
        {
            if (_bIsConnected)
            {
                Connect();
                
            }            
        }

        public bool IsAllCompletedHome()
        {
            throw new NotImplementedException();
        }

        public bool IsAxisCompletedHome(int axisNum)
        {
            throw new NotImplementedException();
        }

        public bool IsMotionBusy()
        {
            throw new NotImplementedException();
        }

        public bool IsUseGantry()
        {
            throw new NotImplementedException();
        }

        public void LoadMotionINI(string path)
        {
            try
            {
                if (path == null || path == "")
                {
                    path = m_sIniPath;
                }
                IniFile ini = new IniFile();
                string tempVal = "";
                tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_COMPORT, path);
                if (tempVal != null && tempVal != "") { _serialPort.PortName = tempVal; }
                tempVal = ini.IniReadValue(INISECTION_MOTION_SETTING, INIKEY_CONNECTED, path);
                if (tempVal != null && tempVal != "") { _bIsConnected = Convert.ToBoolean(tempVal); }

                InitMotion();                

                for (int i = 0; i < _listAxis.Count; i++)
                {
                    _listAxis[i].LoadAxisINI(path);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }        

        public void OverrideVel(int axisNum, double fV)
        {
            throw new NotImplementedException();
        }

        public void SaveMotionINI(string path)
        {
            try
            {
                if (path == null || path == "")
                {
                    path = m_sIniPath;
                }


                IniFile ini = new IniFile();
                ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_COMPORT, _serialPort.PortName, path);
                ini.IniWriteValue(INISECTION_MOTION_SETTING, INIKEY_CONNECTED, _bIsConnected.ToString(), path);

                for (int i = 0; i < _listAxis.Count; i++)
                {
                    _listAxis[i].SaveAxisINI(path);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }

        public void SetTrigger(int axisNum, double dStartPos, double dEndPos, double dPeriodPos, bool bCmd, double dTrigTime = 2, uint triggerLevel = 1)
        {
            throw new NotImplementedException();
        }        

        public void StopTrigger(int axisNum)
        {
            throw new NotImplementedException();
        }

        public IAxis GetAxis(int axisNum)
        {
            if (m_nAxisCount > 0 && axisNum < m_nAxisCount)
            {
                return _listAxis[axisNum].GetAxisInterface();
            }

            return null;
        }
    }
}
