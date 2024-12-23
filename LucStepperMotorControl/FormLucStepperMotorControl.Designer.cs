namespace LucStepperMotorControl
{
    partial class FormLucStepperMotorControl
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_setting = new System.Windows.Forms.Button();
            this.timer_connect_monitor = new System.Windows.Forms.Timer(this.components);
            this.label_conn_status = new System.Windows.Forms.Label();
            this.flowLayoutPanel_axis = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button_setting
            // 
            this.button_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setting.Location = new System.Drawing.Point(697, 12);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 0;
            this.button_setting.Text = "Setting";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // timer_connect_monitor
            // 
            this.timer_connect_monitor.Enabled = true;
            this.timer_connect_monitor.Tick += new System.EventHandler(this.timer_connect_monitor_Tick);
            // 
            // label_conn_status
            // 
            this.label_conn_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_conn_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_conn_status.Location = new System.Drawing.Point(12, 63);
            this.label_conn_status.Name = "label_conn_status";
            this.label_conn_status.Size = new System.Drawing.Size(760, 25);
            this.label_conn_status.TabIndex = 4;
            this.label_conn_status.Text = "Status";
            this.label_conn_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel_axis
            // 
            this.flowLayoutPanel_axis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_axis.AutoScroll = true;
            this.flowLayoutPanel_axis.Location = new System.Drawing.Point(12, 91);
            this.flowLayoutPanel_axis.Name = "flowLayoutPanel_axis";
            this.flowLayoutPanel_axis.Size = new System.Drawing.Size(760, 308);
            this.flowLayoutPanel_axis.TabIndex = 5;
            // 
            // FormLucStepperMotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.flowLayoutPanel_axis);
            this.Controls.Add(this.label_conn_status);
            this.Controls.Add(this.button_setting);
            this.Name = "FormLucStepperMotorControl";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Luc Stepper motor control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLucStepperMotorControl_FormClosing);
            this.Load += new System.EventHandler(this.FormLucStepperMotorControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_setting;
        private System.Windows.Forms.Timer timer_connect_monitor;
        private System.Windows.Forms.Label label_conn_status;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_axis;
    }
}

