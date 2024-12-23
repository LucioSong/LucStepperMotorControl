using Luc.Common;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Motion
{
    public class AxisPDVStepper : AxisBase, IAxis
    {
        private SerialPort _serialPort = null;
        public SerialPort SerialPort 
        { 
            get { return _serialPort; } 
            set { _serialPort = value; }
        }

        public AxisBase AxisBase => this;

        public double GetActualPosition()
        {
            throw new NotImplementedException();
        }

        public uint GetHomeState()
        {
            throw new NotImplementedException();
        }

        public bool GetServoOnState()
        {
            throw new NotImplementedException();
        }

        public void Home()
        {
            throw new NotImplementedException();
        }

        public bool IsBusy()
        {
            throw new NotImplementedException();
        }

        public bool IsCompletedHome()
        {
            throw new NotImplementedException();
        }

        public bool IsNegativeLimit()
        {
            throw new NotImplementedException();
        }

        public bool IsPositiveLimit()
        {
            throw new NotImplementedException();
        }

        public bool IsUse()
        {
            throw new NotImplementedException();
        }

        public void LoadAxisINI(string path)
        {
            try
            {
                this.LoadAxisBase(path);
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }

        public void Move(double pos, bool isRelative)
        {
            throw new NotImplementedException();
        }

        public void MoveJog(bool isDirectionPostive)
        {
            throw new NotImplementedException();
        }

        public void PositionClear()
        {
            throw new NotImplementedException();
        }

        public void SaveAxisINI(string path)
        {
            try
            {
                this.SaveAxisBase(path);
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }

        public void SetServoOn(bool isOn)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
