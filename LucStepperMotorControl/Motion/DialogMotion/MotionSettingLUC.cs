using Luc.Common;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Luc.Motion.DialogMotion
{
    public partial class MotionSettingLUC : UserControl
    {
        MotionLUCStepper m_motion = null;
        public MotionSettingLUC()
        {
            InitializeComponent();

            m_motion = MotionLUCStepper.GetInstance();
        }

        private void MotionSettingLUC_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            string currPort = string.Empty;
            foreach (string port in ports)
            {
                comboBox_com_port.Items.Add(port);
                if (m_motion.PortName == port)
                {
                    currPort = port;
                }
            }

            if (comboBox_com_port.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(currPort))
                {
                    comboBox_com_port.SelectedItem = currPort;
                    if (m_motion.IsInitMotion())
                    {
                        checkBox_com_connect.Checked = true;
                    }
                    else
                    {
                        checkBox_com_connect.Checked = false;
                    }
                }
                else
                {
                    comboBox_com_port.SelectedIndex = 0;
                }

                for (int i = 0; i < m_motion.GetAxisCount(); i++)
                {
                    comboBox_Axis.Items.Add(String.Format("{0} - {1}", i, m_motion.ListAxis[i].DevName));
                }
            }

            comboBox_Axis.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_motion != null)
            {
                bool isInitMotion = m_motion.IsInitMotion();
                groupBox1.Enabled = isInitMotion;
                checkBox_com_connect.Checked = isInitMotion;

                if (isInitMotion)
                {
                    checkBox_com_connect.Text = "Disconnect";
                    comboBox_com_port.Enabled = false;
                }
                else
                {
                    checkBox_com_connect.Text = "Connect";
                    comboBox_com_port.Enabled = true;
                }
            }
            else
            {
                groupBox1.Enabled = false;
                checkBox_com_connect.Enabled = false;
            }
        }

        private void checkBox_com_connect_Click(object sender, EventArgs e)
        {
            if (m_motion != null)
            {
                m_motion.PortName = comboBox_com_port.Text;

                if (m_motion.IsInitMotion())
                {
                    m_motion.Disconnect();
                }
                else
                {
                    m_motion.Connect();
                }

                Thread.Sleep(100);
                m_motion.SaveMotionINI(DefPath.MotionSetting);
            }
        }

        private void checkBox_use_axis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index < 0)
                    {
                        checkBox_use_axis.Checked = false;
                        return;
                    }

                    m_motion.ListAxis[index].IsUseAxis = checkBox_use_axis.Checked;
                    m_motion.SaveMotionINI(DefPath.MotionSetting);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index > -1)
                    {
                        m_motion.ListAxis[index].UserName = textBox_user_name.Text;
                        m_motion.ListAxis[index].SetUnitperMM(Convert.ToDouble(textBox_unit_per_mm.Text));
                        m_motion.ListAxis[index].Velocity = Convert.ToDouble(numericUpDown_spd.Value);
                        m_motion.ListAxis[index].Acceleration = Convert.ToDouble(numericUpDown_acc_dec.Value);
                        m_motion.SaveMotionINI(DefPath.MotionSetting);
                    }
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void comboBox_Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    GetMotionSettingUpdate();
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void GetMotionSettingUpdate()
        {
            try
            {
                int index = comboBox_Axis.SelectedIndex;
                if (index > -1)
                {
                    checkBox_use_axis.Checked = m_motion.ListAxis[index].IsUseAxis;
                    checkBox_ui_vertical.Checked = m_motion.ListAxis[index].IsUIVertical;
                    textBox_unit_per_mm.Text = String.Format("{0}", m_motion.ListAxis[index].UnitPerMM);
                    textBox_user_name.Text = m_motion.ListAxis[index].UserName;
                    numericUpDown_spd.Value = Convert.ToDecimal(m_motion.ListAxis[index].Velocity);
                    numericUpDown_acc_dec.Value = Convert.ToDecimal(m_motion.ListAxis[index].Acceleration);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }

        private void checkBox_ui_vertical_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_motion != null)
                {
                    int index = comboBox_Axis.SelectedIndex;
                    if (index < 0)
                    {
                        checkBox_ui_vertical.Checked = false;
                        return;
                    }

                    m_motion.ListAxis[index].IsUIVertical = checkBox_ui_vertical.Checked;
                    m_motion.SaveMotionINI(DefPath.MotionSetting);
                }
            }
            catch (Exception E)
            {
                LogFile.LogExceptionErr(E.ToString());
                MessageBox.Show(E.Message);
            }
        }
    }
}
