using Luc.Motion;
using Luc.Motion.DialogMotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LucStepperMotorControl
{
    public partial class FormLucStepperMotorControl : Form
    {
        IMotion _motion = null;

        public FormLucStepperMotorControl()
        {
            InitializeComponent();
        }

        private void FormLucStepperMotorControl_Load(object sender, EventArgs e)
        {
            _motion = MotionBase.GetInstanceInterface();

            if (Properties.Settings.Default.WindowWidth > 0 &&
                Properties.Settings.Default.WindowHeight > 0)
            {
                this.Width = Properties.Settings.Default.WindowWidth;
                this.Height = Properties.Settings.Default.WindowHeight;
            }

            if (Properties.Settings.Default.WindowX >= 0 &&
                Properties.Settings.Default.WindowY >= 0)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(
                    Properties.Settings.Default.WindowX,
                    Properties.Settings.Default.WindowY);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void button_setting_Click(object sender, EventArgs e)
        {
            MotionSetting motionSetting = new MotionSetting();
            motionSetting.ShowDialog();

            if (_motion != null)
            {
                bool isInitMotion = _motion.IsInitMotion();

                if (isInitMotion)
                {
                    flowLayoutPanel_axis.Controls.Clear();

                    int axisCnt = _motion.GetAxisCount();
                    for (int i = 0; i < axisCnt; i++)
                    {
                        IAxis iAxis = _motion.GetAxis(i);
                        if (iAxis.IsUse())
                        {
                            UC_Axis ucaxis = new UC_Axis(iAxis);
                            flowLayoutPanel_axis.Controls.Add(ucaxis);
                        }
                    }
                }
            }
        }

        bool _isPreInitMotion = false;
        private void timer_connect_monitor_Tick(object sender, EventArgs e)
        {
            if (_motion != null)
            {
                bool isInitMotion  = _motion.IsInitMotion();
                if (isInitMotion)
                {
                    label_conn_status.Text = "Connected.";
                    label_conn_status.BackColor = Color.Green;
                }
                else
                {
                    label_conn_status.Text = "Disconnected.";
                    label_conn_status.BackColor = Color.Red;
                }

                if ((_isPreInitMotion != isInitMotion))
                {
                    if (isInitMotion)
                    {
                        flowLayoutPanel_axis.Controls.Clear();

                        int axisCnt = _motion.GetAxisCount();
                        for (int i = 0; i < axisCnt; i++)
                        {
                            IAxis iAxis = _motion.GetAxis(i);
                            if (iAxis.IsUse())
                            {
                                UC_Axis ucaxis = new UC_Axis(iAxis);
                                flowLayoutPanel_axis.Controls.Add(ucaxis);
                            }
                        }
                    }
                    else
                    {
                        flowLayoutPanel_axis.Controls.Clear();
                    }
                }

                _isPreInitMotion = isInitMotion;
            }
        }

        private void FormLucStepperMotorControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 현재 창 크기 및 위치 저장
            Properties.Settings.Default.WindowWidth = this.Width;
            Properties.Settings.Default.WindowHeight = this.Height;
            Properties.Settings.Default.WindowX = this.Location.X;
            Properties.Settings.Default.WindowY = this.Location.Y;
            Properties.Settings.Default.Save();
        }
    }
}
