using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Common
{
    public static class DefPath
    {
        public static string CommonAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public static string ConfigPath = CommonAppDataPath + "\\GaussianStageControl";

        // inifile path in Config directory
        public static string LaserSetting = ConfigPath + "\\InitialSetup.ini";
        public static string VisionSetting = ConfigPath + "\\VisionSetting.ini";
        public static string MotionSetting = ConfigPath + "\\InitialMotionSetup.ini";
        public static string DongleKey = ConfigPath + "\\KEYS.ini";
        public static string ViewportSetting = ConfigPath + "\\ViewportLayoutSetting.ini";
        public static string CalibationSetting = ConfigPath + "\\CalibrationSetting.ini";
        public static string AutomationMachine = ConfigPath + "\\AutomationMachine.ini";
        public static string IOMap = ConfigPath + "\\IOMap.ini";
        public static string InitLaserPara = ConfigPath + "\\InitLaserPara.ini";
        public static string MotorizedOpticSetting = ConfigPath + "\\MotorizedOptic.ini";
        public static string MotorizedOpticData = ConfigPath + "\\MotorizedOptic.motoptxml";

        public static string ProgramConfig = ConfigPath + "\\Config.ini";

        // Lens directory in Config directory
        public static string LensDir = ConfigPath + "\\Lens";
    }
}
