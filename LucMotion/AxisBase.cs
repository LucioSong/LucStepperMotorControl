using Luc.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Motion
{
    public class AxisBase
    {
        public static string INISECTION_AXIS = "AxisSetting";

        public static string INIKEY_NUMBER = "NUMBER";
        public static string INIKEY_UNITPERMM = "UNITPERMM";
        public static string INIKEY_UNITPERMMENCODER = "UNITPERMM_ENC";
        public static string INIKEY_VEL = "VEL";
        public static string INIKEY_ACC = "ACC";
        public static string INIKEY_DEC = "DEC";
        public static string INIKEY_HOME_VEL = "HOME_VEL";
        public static string INIKEY_USE_GALVOPOS = "USE_GALVOPOS";
        public static string INIKEY_GALVO_POSITION = "GALVO_POSITION";
        public static string INIKEY_USE_CAMPOS = "USE_CAMPOS";
        public static string INIKEY_CAM_POSITION = "CAM_POSITION";
        public static string INIKEY_USEAXIS = "USE";        
        public static string INIKEY_DEVNAME = "DEV_NAME";
        public static string INIKEY_USERNAME = "USER_NAME";
        public static string INIKEY_UIVERTICAL = "UIVERTICAL";
        public static string INIKEY_UIISSTEP = "UIISSTEP";

        public enum HOME_STATE { NONE, HOMMING, COMPLETED }

        protected int m_nAxisNumber = 0;    // 축번호
        public int AxisNumber
        {
            get { return m_nAxisNumber; }
            set { m_nAxisNumber = value; }
        }

        protected string m_strDeviceName = "";  // 축 DeviceName
        public string DevName
        {
            get { return m_strDeviceName; }
            set { m_strDeviceName = value; }
        }

        protected string m_strUserName = "";    // 사용자 지정 Name
        public string UserName
        {
            get { return m_strUserName; }
            set { m_strUserName = value; }
        }

        protected int m_nUserAxisNumber = 0;    // 사용자 지정 Number
        public int UserAxisNumber
        {
            get { return m_nUserAxisNumber; }
            set { m_nUserAxisNumber = value; }
        }

        protected double m_dUnitperMM = 1;       // 축 단위 환산 (mm 기준)
        public void SetUnitperMM(double unitPerMM)
        {
            m_dUnitperMM = unitPerMM;
        }
        public double UnitPerMM
        {
            get { return m_dUnitperMM; }
        }

        protected double m_dUnitperMMEnc = 1;    // 엔코더 단위 환산 (mm 기준)
        public void SetUnitperMMforEncoder(double unitPerMM)
        {
            m_dUnitperMMEnc = unitPerMM;
        }
        public double UnitPerMMEncoder
        {
            get { return m_dUnitperMMEnc; }
        }

        protected double m_dVelocity = 50;     // 축 속도
        public double Velocity
        {
            get { return m_dVelocity; }
            set { m_dVelocity = value; }
        }

        protected double m_dAcceleration = 100; // 축 가속도
        public double Acceleration
        {
            get { return m_dAcceleration; }
            set { m_dAcceleration = value; }
        }

        protected double m_dDeceleration = 100; // 축 감속도
        public double Deceleration
        {
            get { return m_dDeceleration; }
            set { m_dDeceleration = value; }
        }

        protected double m_dHomeVelocity = 30;     // 축 Home 속도
        public double HomeVelocity
        {
            get { return m_dHomeVelocity; }
        }
        public void SetHomeVelocity(double vel)
        {
            m_dHomeVelocity = vel;
        }

        protected bool m_bIsUseAxis = false;        // 축 사용 여부
        public bool IsUseAxis
        {
            get { return m_bIsUseAxis; }
            set { m_bIsUseAxis = value; }
        }

        protected HOME_STATE m_state;
        public HOME_STATE HomeState
        {
            get { return m_state; }
            set { m_state = value; }
        }

        protected bool m_bIsUIVertical = false;
        public bool IsUIVertical
        {
            get { return m_bIsUIVertical; }
            set { m_bIsUIVertical = value; }
        }

        protected bool m_bIsUIStepMode = false;
        public bool IsUIStepMode
        {
            get { return m_bIsUIStepMode; }
            set { m_bIsUIStepMode = value; }
        }

        protected IAxis _iAxis = null;
        public IAxis GetAxisInterface()
        {
            return _iAxis;
        }

        public void SaveAxisBase(string path)
        {
            try
            {
                IniFile ini = new IniFile();
                string buildSectionName = INISECTION_AXIS + "_" + m_nAxisNumber;
                ini.IniWriteValue(buildSectionName, INIKEY_NUMBER, String.Format("{0}", m_nAxisNumber), path);
                ini.IniWriteValue(buildSectionName, INIKEY_USERNAME, m_strUserName, path);
                ini.IniWriteValue(buildSectionName, INIKEY_UNITPERMM, String.Format("{0}", m_dUnitperMM), path);
                ini.IniWriteValue(buildSectionName, INIKEY_VEL, String.Format("{0}", m_dVelocity), path);
                ini.IniWriteValue(buildSectionName, INIKEY_ACC, String.Format("{0}", m_dAcceleration), path);
                ini.IniWriteValue(buildSectionName, INIKEY_USEAXIS, String.Format("{0}", m_bIsUseAxis), path);
                ini.IniWriteValue(buildSectionName, INIKEY_UIVERTICAL, String.Format("{0}", m_bIsUIVertical), path);
                ini.IniWriteValue(buildSectionName, INIKEY_UIISSTEP, String.Format("{0}", m_bIsUIStepMode), path);
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }

        public void LoadAxisBase(string path)
        {
            try
            {
                IniFile ini = new IniFile();
                string buildSectionName = INISECTION_AXIS + "_" + m_nAxisNumber;
                string tempVal = "";
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_NUMBER, path);
                if (tempVal != "") { m_nAxisNumber = Convert.ToInt32(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_USERNAME, path);
                if (tempVal != "") { m_strUserName = tempVal; }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_UNITPERMM, path);
                if (tempVal != "") { m_dUnitperMM = Convert.ToInt32(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_VEL, path);
                if (tempVal != "") { m_dVelocity = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_ACC, path);
                if (tempVal != "") { m_dAcceleration = Convert.ToDouble(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_USEAXIS, path);
                if (tempVal != "") { m_bIsUseAxis = Convert.ToBoolean(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_UIVERTICAL, path);
                if (tempVal != "") { m_bIsUIVertical = Convert.ToBoolean(tempVal); }
                tempVal = ini.IniReadValue(buildSectionName, INIKEY_UIISSTEP, path);
                if (tempVal != "") { m_bIsUIStepMode = Convert.ToBoolean(tempVal); }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                throw;
            }
        }
    }
}
