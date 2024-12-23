using Luc.Common;
using Luc.Motion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LucStepperMotorControl
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DefPath.ConfigPath = DefPath.CommonAppDataPath + "\\" + Assembly.GetExecutingAssembly().GetName();
            DirectoryInfo di = new DirectoryInfo(DefPath.ConfigPath);
            if (!di.Exists)
            {
                di.Create();
            }

            IniFile ini = new IniFile();
            ini.IniWriteValue(MotionBase.INISECTION_MOTION_INITIAL, MotionBase.INIKEY_INIT_USE_MOTION, true.ToString(), DefPath.MotionSetting);
            ini.IniWriteValue(MotionBase.INISECTION_MOTION_INITIAL, MotionBase.INIKEY_INIT_KIND_OF_MOTION, "2", DefPath.MotionSetting);
            MotionBase.ReadMotionINI(DefPath.MotionSetting);

            IMotion motion = MotionBase.GetInstanceInterface();

            Application.Run(new FormLucStepperMotorControl());
        }
    }
}
