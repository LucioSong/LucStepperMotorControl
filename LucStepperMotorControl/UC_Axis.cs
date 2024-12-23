using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Luc.Common;
using Luc.Motion;

namespace LucStepperMotorControl
{
    public partial class UC_Axis : UserControl
    {
        enum CHANGE_FLG { HOME, POS, LIM, AX_NAME, BUSY }

        IMotion _motion;
        AxisBase _axisBase;
        IAxis _iAxis;


        public UC_Axis(IAxis axis)
        {
            InitializeComponent();

            _motion = MotionBase.GetInstanceInterface();

            _iAxis = axis;
            _axisBase = _iAxis.AxisBase;
        }

        ~UC_Axis() 
        {
            backgroundWorker_state.CancelAsync();            
        }

        private void UC_Axis_Load(object sender, EventArgs e)
        {
            if (_iAxis != null && _axisBase != null)
            {
                button_positive_hor.Visible = button_negative_hor.Visible = !_axisBase.IsUIVertical;
                button_positive_ver.Visible = button_negative_ver.Visible = _axisBase.IsUIVertical;

                label_axis_name.Text = _axisBase.DevName;
                comboBox_control_mode.SelectedIndex = _axisBase.IsUIStepMode ? 0 : 1;
            }

            backgroundWorker_state.RunWorkerAsync();
        }

        private void backgroundWorker_state_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isFirst = true;
            uint preHomeState = (uint)AxisBase.HOME_STATE.NONE;
            bool preNLimit = false, prePLimit = false, preIsBusy = false;
            double prePos = double.NaN;
            string preAxisName = string.Empty;

            while (!backgroundWorker_state.CancellationPending)
            {
                Thread.Sleep(5);                

                if (_motion.IsInitMotion() && _iAxis != null)
                {
                    uint homeState = _iAxis.GetHomeState();
                    bool nLimit = _iAxis.IsNegativeLimit(), pLimit = _iAxis.IsPositiveLimit(), isBusy = _iAxis.IsBusy();
                    double pos = _iAxis.GetActualPosition();
                    string axisName = _axisBase.UserName;


                    if (isFirst || (preHomeState != homeState))
                    {
                        backgroundWorker_state.ReportProgress(-1, CHANGE_FLG.HOME);
                    }

                    if (isFirst || (preNLimit != nLimit) || (prePLimit != pLimit))
                    {
                        backgroundWorker_state.ReportProgress(-1, CHANGE_FLG.LIM);
                    }

                    if (isFirst || (!double.IsNaN(pos) && prePos != pos))
                    {
                        backgroundWorker_state.ReportProgress(-1, CHANGE_FLG.POS);
                    }

                    if (isFirst || (preAxisName != axisName))
                    {
                        backgroundWorker_state.ReportProgress(-1, CHANGE_FLG.AX_NAME);
                    }

                    if (isFirst || (preIsBusy != isBusy))
                    {
                        backgroundWorker_state.ReportProgress(-1, CHANGE_FLG.BUSY);
                    }

                    isFirst = false;
                    preHomeState = homeState;
                    preNLimit = nLimit;
                    prePLimit = pLimit;
                    preIsBusy = isBusy;
                    preAxisName = axisName;
                    prePos = pos;
                }                    
            }
        }

        private void backgroundWorker_state_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_motion.IsInitMotion() && _iAxis != null)
            {
                uint homeState = _iAxis.GetHomeState();
                bool nLimit = _iAxis.IsNegativeLimit(), pLimit = _iAxis.IsPositiveLimit(), isBusy = _iAxis.IsBusy();
                double pos = _iAxis.GetActualPosition();
                string axisName = _axisBase.UserName;

                CHANGE_FLG chage_flage = (CHANGE_FLG)e.UserState;

                switch (chage_flage)
                {
                    case CHANGE_FLG.AX_NAME:
                        {
                            label_axis_user_name.Text = axisName;
                        }
                        break;

                    case CHANGE_FLG.HOME:
                        {
                            switch(homeState)
                            {
                                case (uint)AxisBase.HOME_STATE.HOMMING:
                                    textBox_state.BackColor = SystemColors.Control;
                                    textBox_state.Text = "Homing...";
                                    break;

                                case (uint)AxisBase.HOME_STATE.NONE:
                                    textBox_state.BackColor = SystemColors.Control;
                                    textBox_state.Text = " - ";
                                    break;

                                case (uint)AxisBase.HOME_STATE.COMPLETED:
                                    textBox_state.BackColor = SystemColors.Control;
                                    textBox_state.Text = "Ready";
                                    break;
                            }
                        }
                        break;

                    case CHANGE_FLG.LIM:
                        {
                            if (_iAxis.GetHomeState() != (uint)AxisBase.HOME_STATE.HOMMING)
                            {
                                if (nLimit && pLimit)
                                {
                                    textBox_state.BackColor = Color.OrangeRed;
                                    textBox_state.Text = "(-),(+) Limit";
                                }
                                else if (nLimit)
                                {
                                    textBox_state.BackColor = Color.OrangeRed;
                                    textBox_state.Text = "(-) Limit";
                                }
                                else if (pLimit)
                                {
                                    textBox_state.BackColor = Color.OrangeRed;
                                    textBox_state.Text = "(+) Limit";
                                }
                                else
                                {
                                    switch (homeState)
                                    {
                                        case (uint)AxisBase.HOME_STATE.HOMMING:
                                            textBox_state.BackColor = SystemColors.Control;
                                            textBox_state.Text = "Homing...";
                                            break;

                                        case (uint)AxisBase.HOME_STATE.NONE:
                                            textBox_state.BackColor = SystemColors.Control;
                                            textBox_state.Text = " - ";
                                            break;

                                        case (uint)AxisBase.HOME_STATE.COMPLETED:
                                            textBox_state.BackColor = SystemColors.Control;
                                            textBox_state.Text = "Ready";
                                            break;
                                    }
                                }
                            }
                        }
                        break;

                    case CHANGE_FLG.BUSY:
                        {
                            //tableLayoutPanel5.Enabled = tableLayoutPanel4.Enabled = !isBusy;
                        }
                        break;

                    case CHANGE_FLG.POS:
                        {
                            textBox_position.Text = pos.ToString();
                        }
                        break;
                }
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (_motion.IsInitMotion() && _iAxis != null)
            {
                _iAxis.Stop();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (comboBox_control_mode.SelectedIndex == 0)
            {
                if (_motion.IsInitMotion() && _iAxis != null)
                {
                    Button button = (Button)sender;
                    if (button.Tag != null && (string)button.Tag == "0")
                    {
                        _iAxis.Move(Convert.ToDouble(-numericUpDown_step.Value), true);
                    }
                    else if (button.Tag != null && (string)button.Tag == "1")
                    {
                        _iAxis.Move(Convert.ToDouble(numericUpDown_step.Value), true);
                    }
                }
            }            
        }

        bool _bIsNumericUpDown_abs_ValueChanged = false;
        private void numericUpDown_abs_ValueChanged(object sender, EventArgs e)
        {
            if (_motion.IsInitMotion() && _iAxis != null)
            {
                _bIsNumericUpDown_abs_ValueChanged = true;
                timer_value_changed.Start();
                _iAxis.Move(Convert.ToDouble(numericUpDown_abs.Value), false);
            }
        }

        private void numericUpDown_abs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_motion.IsInitMotion() && _iAxis != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!_bIsNumericUpDown_abs_ValueChanged)
                    {
                        _iAxis.Move(Convert.ToDouble(numericUpDown_abs.Value), false);
                    }                        
                }
                    
            }
        }

        private void timer_value_changed_Tick(object sender, EventArgs e)
        {
            timer_value_changed.Stop();
            _bIsNumericUpDown_abs_ValueChanged = false;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox_control_mode.SelectedIndex == 1)
            {
                if (_motion.IsInitMotion() && _iAxis != null)
                {
                    Button button = (Button)sender;
                    if (button.Tag != null && (string)button.Tag == "0")
                    {
                        _iAxis.Move(((int.MinValue + 99999) / _axisBase.UnitPerMM), false);
                    }
                    else
                    {
                        _iAxis.Move(((int.MaxValue - 99999) / _axisBase.UnitPerMM), false);
                    }
                }
            }
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            if (comboBox_control_mode.SelectedIndex == 1)
            {
                if (_motion.IsInitMotion() && _iAxis != null)
                {
                    _iAxis.Stop();
                }
            }
        }

        private void comboBox_control_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_motion.IsInitMotion() && _axisBase != null)
            {
                _axisBase.IsUIStepMode = (comboBox_control_mode.SelectedIndex == 0);
                _axisBase.SaveAxisBase(DefPath.MotionSetting);
            }
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            if (_motion.IsInitMotion() && _iAxis != null)
            {
                _iAxis.Home();
            }
        }
    }
}
