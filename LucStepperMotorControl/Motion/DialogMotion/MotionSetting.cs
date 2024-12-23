using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luc.Motion.DialogMotion
{
    public partial class MotionSetting : Form
    {
        MotionBase _motion = null;

        MotionSettingLUC _motSettingLUC = null;
        MotionSettingPDV _motSettingPDV = null;
        

        public MotionSetting()
        {
            switch (MotionBase.GetKindOfMotion())
            {
                case MotionBase.KIND_MOTION.LUCStepper:
                    {
                        _motion = MotionLUCStepper.GetInstance();
                    }
                    break;

                case MotionBase.KIND_MOTION.PDVStepper:
                    {
                        _motion = MotionPDVStepper.GetInstance();
                    }
                    break;
            }

            InitializeComponent();
        }

        private void MotionSetting_Load(object sender, EventArgs e)
        {
            if (_motion != null)
            {
                switch (MotionBase.GetKindOfMotion())
                {
                    case MotionBase.KIND_MOTION.LUCStepper:
                        {
                            _motSettingLUC = new MotionSettingLUC();
                            Controls.Add(_motSettingLUC);
                        }
                        break;

                    case MotionBase.KIND_MOTION.PDVStepper:
                        {
                            _motSettingPDV = new MotionSettingPDV();
                            Controls.Add(_motSettingPDV);
                        }
                        break;
                }
            }
            else
            {
                Close();
            }
        }

        private void MotionSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
