using Luc.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;
using System.Timers;

namespace Luc.Motion
{
    public class MotionPDVStepper : MotionBase, IMotion
    {
        private static MotionPDVStepper m_motionPDV = null;
        public static MotionPDVStepper GetInstance()
        {
            if (m_bIsUseMotion)
            {
                if (m_motionPDV == null)
                {
                    m_motionPDV = new MotionPDVStepper();
                }

                return m_motionPDV;
            }

            return null;
        }

        public static int MAX_AXIS_CNT = 4;

        public static string INIKEY_COMPORT = "COMPORT";
        public static string INIKEY_CONNECTED = "CONNECTED";

        private SerialPort _serialPort = new SerialPort();
        private System.Timers.Timer _serialMonitorTimer = new System.Timers.Timer();
        private bool _bIsConnected = false;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        private List<AxisPDVStepper> _listAxis = null;
        public List<AxisPDVStepper> ListAxis
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

        public MotionPDVStepper() 
        {
            _serialPort.PortName = "COM1";
            _serialPort.BaudRate = 57600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;

            _serialMonitorTimer.Interval = 50;
            _serialMonitorTimer.Elapsed += _serialMonitorTimer_Elapsed;

            m_nAxisCount = MAX_AXIS_CNT;

            _listAxis = new List<AxisPDVStepper>(m_nAxisCount);
            for (int i = 0; i < m_nAxisCount; i++)
            {
                AxisPDVStepper axis = new AxisPDVStepper();
                axis.SerialPort = _serialPort;
                axis.AxisNumber = i;
                switch (i)
                {
                    case 0:
                        axis.DevName = "X";
                        break;

                    case 1:
                        axis.DevName = "Y";
                        break;

                    case 2:
                        axis.DevName = "Z";
                        break;

                    case 3:
                        axis.DevName = "L";
                        break;
                }

                _listAxis.Add(axis);
            }
        }

        event EventHandler IMotion.ChangedSetting
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void _serialMonitorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _bIsConnected = m_bIsInitMotion = _serialPort.IsOpen;
        }

        public void Connect()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }

            try
            {
                _serialPort.Open();
                _bIsConnected = _serialPort.IsOpen;
            }
            catch (Exception)
            {
            }
        }

        public void Disconnect()
        {
            if (_serialPort.IsOpen)
            {
                _serialMonitorTimer.Stop();
                Thread.Sleep(300);
                _serialPort.Close();
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
            Connect();
            _serialMonitorTimer.Start();
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

                if (_bIsConnected)
                {
                    InitMotion();
                }

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
