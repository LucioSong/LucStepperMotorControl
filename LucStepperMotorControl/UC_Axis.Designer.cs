namespace LucStepperMotorControl
{
    partial class UC_Axis
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_stop = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_position = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_state = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button_positive_ver = new System.Windows.Forms.Button();
            this.button_negative_hor = new System.Windows.Forms.Button();
            this.button_positive_hor = new System.Windows.Forms.Button();
            this.button_negative_ver = new System.Windows.Forms.Button();
            this.numericUpDown_step = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_control_mode = new System.Windows.Forms.ComboBox();
            this.label_axis_name = new System.Windows.Forms.Label();
            this.label_axis_user_name = new System.Windows.Forms.Label();
            this.button_home = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_abs = new System.Windows.Forms.NumericUpDown();
            this.timer_state = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_state = new System.ComponentModel.BackgroundWorker();
            this.timer_value_changed = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_step)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_abs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button_stop, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_axis_name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_axis_user_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_home, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.598583F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.04612F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.04612F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.04612F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.21692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.04612F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 343);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_stop
            // 
            this.button_stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_stop.Location = new System.Drawing.Point(3, 254);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(187, 49);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.82888F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.17112F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_position, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 82);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(187, 24);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Postion : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_position
            // 
            this.textBox_position.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_position.Location = new System.Drawing.Point(70, 3);
            this.textBox_position.Multiline = true;
            this.textBox_position.Name = "textBox_position";
            this.textBox_position.ReadOnly = true;
            this.textBox_position.Size = new System.Drawing.Size(114, 18);
            this.textBox_position.TabIndex = 1;
            this.textBox_position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.82888F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.17112F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_state, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(187, 24);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "State : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_state
            // 
            this.textBox_state.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_state.Location = new System.Drawing.Point(70, 3);
            this.textBox_state.Multiline = true;
            this.textBox_state.Name = "textBox_state";
            this.textBox_state.ReadOnly = true;
            this.textBox_state.Size = new System.Drawing.Size(114, 18);
            this.textBox_state.TabIndex = 1;
            this.textBox_state.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.button_positive_ver, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_negative_hor, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_positive_hor, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_negative_ver, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDown_step, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox_control_mode, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 112);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(187, 106);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // button_positive_ver
            // 
            this.button_positive_ver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_positive_ver.Location = new System.Drawing.Point(65, 3);
            this.button_positive_ver.Name = "button_positive_ver";
            this.button_positive_ver.Size = new System.Drawing.Size(56, 29);
            this.button_positive_ver.TabIndex = 4;
            this.button_positive_ver.Tag = "1";
            this.button_positive_ver.Text = "▲";
            this.button_positive_ver.UseVisualStyleBackColor = true;
            this.button_positive_ver.Click += new System.EventHandler(this.button_Click);
            this.button_positive_ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.button_positive_ver.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // button_negative_hor
            // 
            this.button_negative_hor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_negative_hor.Location = new System.Drawing.Point(3, 38);
            this.button_negative_hor.Name = "button_negative_hor";
            this.button_negative_hor.Size = new System.Drawing.Size(56, 29);
            this.button_negative_hor.TabIndex = 5;
            this.button_negative_hor.Tag = "0";
            this.button_negative_hor.Text = "◀";
            this.button_negative_hor.UseVisualStyleBackColor = true;
            this.button_negative_hor.Click += new System.EventHandler(this.button_Click);
            this.button_negative_hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.button_negative_hor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // button_positive_hor
            // 
            this.button_positive_hor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_positive_hor.Location = new System.Drawing.Point(127, 38);
            this.button_positive_hor.Name = "button_positive_hor";
            this.button_positive_hor.Size = new System.Drawing.Size(57, 29);
            this.button_positive_hor.TabIndex = 6;
            this.button_positive_hor.Tag = "1";
            this.button_positive_hor.Text = "▶";
            this.button_positive_hor.UseVisualStyleBackColor = true;
            this.button_positive_hor.Click += new System.EventHandler(this.button_Click);
            this.button_positive_hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.button_positive_hor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // button_negative_ver
            // 
            this.button_negative_ver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_negative_ver.Location = new System.Drawing.Point(65, 73);
            this.button_negative_ver.Name = "button_negative_ver";
            this.button_negative_ver.Size = new System.Drawing.Size(56, 30);
            this.button_negative_ver.TabIndex = 7;
            this.button_negative_ver.Tag = "0";
            this.button_negative_ver.Text = "▼";
            this.button_negative_ver.UseVisualStyleBackColor = true;
            this.button_negative_ver.Click += new System.EventHandler(this.button_Click);
            this.button_negative_ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.button_negative_ver.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // numericUpDown_step
            // 
            this.numericUpDown_step.DecimalPlaces = 2;
            this.numericUpDown_step.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_step.Location = new System.Drawing.Point(65, 38);
            this.numericUpDown_step.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_step.Name = "numericUpDown_step";
            this.numericUpDown_step.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown_step.TabIndex = 11;
            this.numericUpDown_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_step.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(127, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 35);
            this.label5.TabIndex = 13;
            this.label5.Text = "unit : mm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox_control_mode
            // 
            this.comboBox_control_mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_control_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_control_mode.FormattingEnabled = true;
            this.comboBox_control_mode.Items.AddRange(new object[] {
            "Step",
            "Jog"});
            this.comboBox_control_mode.Location = new System.Drawing.Point(3, 3);
            this.comboBox_control_mode.Name = "comboBox_control_mode";
            this.comboBox_control_mode.Size = new System.Drawing.Size(56, 20);
            this.comboBox_control_mode.TabIndex = 14;
            this.comboBox_control_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_control_mode_SelectedIndexChanged);
            // 
            // label_axis_name
            // 
            this.label_axis_name.AutoSize = true;
            this.label_axis_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_axis_name.Location = new System.Drawing.Point(3, 0);
            this.label_axis_name.Name = "label_axis_name";
            this.label_axis_name.Size = new System.Drawing.Size(187, 19);
            this.label_axis_name.TabIndex = 4;
            this.label_axis_name.Text = "Axis name";
            this.label_axis_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_axis_user_name
            // 
            this.label_axis_user_name.AutoSize = true;
            this.label_axis_user_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_axis_user_name.Location = new System.Drawing.Point(3, 19);
            this.label_axis_user_name.Name = "label_axis_user_name";
            this.label_axis_user_name.Size = new System.Drawing.Size(187, 30);
            this.label_axis_user_name.TabIndex = 5;
            this.label_axis_user_name.Text = "Axis user name";
            this.label_axis_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_home
            // 
            this.button_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_home.Location = new System.Drawing.Point(3, 309);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(187, 31);
            this.button_home.TabIndex = 3;
            this.button_home.Text = "Home";
            this.button_home.UseVisualStyleBackColor = true;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.91892F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.08108F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDown_abs, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 224);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(185, 24);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Absolute : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_abs
            // 
            this.numericUpDown_abs.DecimalPlaces = 2;
            this.numericUpDown_abs.Location = new System.Drawing.Point(75, 3);
            this.numericUpDown_abs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_abs.Name = "numericUpDown_abs";
            this.numericUpDown_abs.Size = new System.Drawing.Size(107, 21);
            this.numericUpDown_abs.TabIndex = 2;
            this.numericUpDown_abs.ValueChanged += new System.EventHandler(this.numericUpDown_abs_ValueChanged);
            this.numericUpDown_abs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_abs_KeyPress);
            // 
            // timer_state
            // 
            this.timer_state.Interval = 70;
            // 
            // backgroundWorker_state
            // 
            this.backgroundWorker_state.WorkerReportsProgress = true;
            this.backgroundWorker_state.WorkerSupportsCancellation = true;
            this.backgroundWorker_state.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_state_DoWork);
            this.backgroundWorker_state.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_state_ProgressChanged);
            // 
            // timer_value_changed
            // 
            this.timer_value_changed.Interval = 150;
            this.timer_value_changed.Tick += new System.EventHandler(this.timer_value_changed_Tick);
            // 
            // UC_Axis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Axis";
            this.Size = new System.Drawing.Size(200, 350);
            this.Load += new System.EventHandler(this.UC_Axis_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_step)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_abs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_position;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_state;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button_positive_ver;
        private System.Windows.Forms.Button button_negative_hor;
        private System.Windows.Forms.Button button_positive_hor;
        private System.Windows.Forms.Button button_negative_ver;
        private System.Windows.Forms.NumericUpDown numericUpDown_step;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.Timer timer_state;
        private System.Windows.Forms.Label label_axis_name;
        private System.Windows.Forms.Label label_axis_user_name;
        private System.ComponentModel.BackgroundWorker backgroundWorker_state;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_abs;
        private System.Windows.Forms.Timer timer_value_changed;
        private System.Windows.Forms.ComboBox comboBox_control_mode;
    }
}
