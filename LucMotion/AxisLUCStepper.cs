using Luc.Common;
using Luc.Motion;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Luc.Motion
{
    public class AxisLUCStepper : AxisBase, IAxis
    {
        private MotionLUCStepper _parent = null;

        public AxisLUCStepper(MotionLUCStepper parent)
        {
            _iAxis = this;
            _parent = parent;
        }

        public enum HOMESTATE
        {
            HOME_NONE = 100, HOME_FIRST, HOME_SECOND, HOME_THIRD, HOME_FOURTH, HOME_COMPLETED = HOME_NONE + 10,
        }

        private double _dMotorPosition = double.NaN;
        public double MotorPosition
        {
            set { _dMotorPosition = value; }
        }

        private double _dMotorSpeed = double.NaN;
        public double MotorSpeed
        {
            set 
            {
                _dMotorSpeed = value;
                Velocity = _dMotorSpeed / UnitPerMM;
            }
        }


        private double _dMotorAcc = double.NaN;
        public double MotorAccelation
        {
            set 
            {
                _dMotorAcc = value;
                Acceleration = _dMotorAcc / UnitPerMM;
            }
        }
        private bool _bMotorLimitN = false;
        public bool MotorLimitN
        {
            set { _bMotorLimitN = value; }
        }

        private bool _bMotorLimitP = false;
        public bool MotorLimitP
        {
            set { _bMotorLimitP = value; }
        }

        private bool _bMotorIsMoving = false;
        public bool MotorIsMoving
        {
            set { _bMotorIsMoving = value; }
        }

        private HOMESTATE _motHomeState = HOMESTATE.HOME_NONE;
        public HOMESTATE MotorHomeState
        {
            set { _motHomeState = value; }
        }

        private SerialPort _serialPort = null;
        public SerialPort SerialPort
        {
            get { return _serialPort; }
            set { _serialPort = value; }
        }

        public AxisBase AxisBase => this;

        public double GetActualPosition()
        {
            return _dMotorPosition / m_dUnitperMM;
        }

        public uint GetHomeState()
        {
            return (uint)m_state;
        }

        public bool GetServoOnState()
        {
            throw new NotImplementedException();
        }

        public void Home()
        {
            HomeMotor();
        }

        public bool IsBusy()
        {
            return _bMotorIsMoving;
        }

        public bool IsCompletedHome()
        {
            throw new NotImplementedException();
        }

        public bool IsNegativeLimit()
        {
            return _bMotorLimitN;
        }

        public bool IsPositiveLimit()
        {
            return _bMotorLimitP;
        }

        public bool IsUse()
        {
            return m_bIsUseAxis;
        }

        public void LoadAxisINI(string path)
        {
            try
            {
                this.LoadAxisBase(path);
                SetSpeedMotor(Convert.ToInt32(m_dVelocity * m_dUnitperMM));
                SetSpeedMotor(Convert.ToInt32(m_dAcceleration * m_dUnitperMM));
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }

        public void Move(double pos, bool isRelative)
        {
            int target = int.MaxValue;

            if (isRelative)
            {
                target = Convert.ToInt32(_dMotorPosition + (pos * m_dUnitperMM));
            }
            else
            {
                target = Convert.ToInt32(pos * m_dUnitperMM);
            }

            if (target != int.MaxValue)
            {
                MoveMotor(target);
            }
        }

        public void MoveJog(bool isDirectionPostive)
        {
            if (isDirectionPostive)
            {
                MoveMotor(int.MaxValue / 2);
            }
            else
            {
                MoveMotor(int.MinValue / 2);
            }
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
            AllStop();
        }




        // LUC Stepper motor part
        private bool MoveMotor(int pos)
        {
            SetSpeedMotor(Convert.ToInt32(m_dVelocity * m_dUnitperMM));
            SetAccDecMotor(Convert.ToInt32(m_dAcceleration * m_dUnitperMM));

            _parent._bIsCommanded = true;
            bool isOK = false;

            Thread.Sleep(100);
            string recv = _parent.SendProtocol("CMV" + (AxisNumber + 1) + "," + pos.ToString());
            isOK = _parent.RecvParsing(recv);

            _parent._bIsCommanded = false;

            return isOK;
        }

        private bool AllStop()
        {
            _parent._bIsCommanded = true;
            bool isOK = false;

            Thread.Sleep(100);
            string recv = _parent.SendProtocol("C!!");
            isOK = _parent.RecvParsing(recv);

            _parent._bIsCommanded = false;

            return isOK;
        }

        private bool SetSpeedMotor(int hz)
        {
            _parent._bIsCommanded = true;
            bool isOK = false;

            Thread.Sleep(100);
            string recv = _parent.SendProtocol("SVL" + (AxisNumber + 1) + "," + hz.ToString());
            isOK = _parent.RecvParsing(recv);

            _parent._bIsCommanded = false;

            return isOK;
        }

        private bool SetAccDecMotor(int hz)
        {
            _parent._bIsCommanded = true;
            bool isOK = false;

            Thread.Sleep(100);
            string recv = _parent.SendProtocol("SAC" + (AxisNumber + 1) + "," + hz.ToString());
            isOK = _parent.RecvParsing(recv);

            _parent._bIsCommanded = false;

            return isOK;
        }

        private bool HomeMotor()
        {
            _parent._bIsCommanded = true;
            bool isOK = false;

            Thread.Sleep(100);
            string recv = _parent.SendProtocol("CRS" + (AxisNumber + 1));
            isOK = _parent.RecvParsing(recv);

            _parent._bIsCommanded = false;

            return isOK;
        }
    }
}
