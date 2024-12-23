using Luc.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Luc.Motion.DialogMotion
{
    public partial class MotionSettingPDV : UserControl
    {
        MotionPDVStepper m_motion = null;

        public MotionSettingPDV()
        {
            InitializeComponent();

            m_motion = MotionPDVStepper.GetInstance();
        }

        private void MotionSettingPDV_Load(object sender, EventArgs e)
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
                        comboBox_com_port.Enabled = false;
                    }
                    else
                    {
                        checkBox_com_connect.Checked = false;
                        comboBox_com_port.Enabled = true;
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
                }
                else
                {
                    checkBox_com_connect.Text = "Connect";
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
                    m_motion.InitMotion();
                }

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
                        m_motion.ListAxis[index].SetUnitperMM(Convert.ToDouble(textBox_unit_per_mm.Text));
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
                    textBox_unit_per_mm.Text = String.Format("{0}", m_motion.ListAxis[index].UnitPerMM);                    
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
