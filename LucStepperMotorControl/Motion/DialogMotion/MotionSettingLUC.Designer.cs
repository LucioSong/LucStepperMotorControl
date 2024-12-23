namespace Luc.Motion.DialogMotion
{
    partial class MotionSettingLUC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_user_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ui_vertical = new System.Windows.Forms.CheckBox();
            this.checkBox_use_axis = new System.Windows.Forms.CheckBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox_unit_per_mm = new System.Windows.Forms.TextBox();
            this.label_unitpermm = new System.Windows.Forms.Label();
            this.comboBox_Axis = new System.Windows.Forms.ComboBox();
            this.checkBox_com_connect = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_com_port = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_spd = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_acc_dec = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_spd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_acc_dec)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown_acc_dec);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown_spd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_user_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox_ui_vertical);
            this.groupBox1.Controls.Add(this.checkBox_use_axis);
            this.groupBox1.Controls.Add(this.button_apply);
            this.groupBox1.Controls.Add(this.label59);
            this.groupBox1.Controls.Add(this.textBox_unit_per_mm);
            this.groupBox1.Controls.Add(this.label_unitpermm);
            this.groupBox1.Controls.Add(this.comboBox_Axis);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 218);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis setting";
            // 
            // textBox_user_name
            // 
            this.textBox_user_name.Location = new System.Drawing.Point(183, 74);
            this.textBox_user_name.Name = "textBox_user_name";
            this.textBox_user_name.Size = new System.Drawing.Size(161, 21);
            this.textBox_user_name.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 69;
            this.label2.Text = "User name  :";
            // 
            // checkBox_ui_vertical
            // 
            this.checkBox_ui_vertical.AutoSize = true;
            this.checkBox_ui_vertical.Location = new System.Drawing.Point(6, 174);
            this.checkBox_ui_vertical.Name = "checkBox_ui_vertical";
            this.checkBox_ui_vertical.Size = new System.Drawing.Size(121, 16);
            this.checkBox_ui_vertical.TabIndex = 68;
            this.checkBox_ui_vertical.Text = "UI control vertical";
            this.checkBox_ui_vertical.UseVisualStyleBackColor = true;
            this.checkBox_ui_vertical.CheckedChanged += new System.EventHandler(this.checkBox_ui_vertical_CheckedChanged);
            // 
            // checkBox_use_axis
            // 
            this.checkBox_use_axis.AutoSize = true;
            this.checkBox_use_axis.Location = new System.Drawing.Point(6, 196);
            this.checkBox_use_axis.Name = "checkBox_use_axis";
            this.checkBox_use_axis.Size = new System.Drawing.Size(74, 16);
            this.checkBox_use_axis.TabIndex = 67;
            this.checkBox_use_axis.Text = "Use axis";
            this.checkBox_use_axis.UseVisualStyleBackColor = true;
            this.checkBox_use_axis.CheckedChanged += new System.EventHandler(this.checkBox_use_axis_CheckedChanged);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(274, 189);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 66;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(286, 50);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(58, 12);
            this.label59.TabIndex = 65;
            this.label59.Text = "Step/mm";
            // 
            // textBox_unit_per_mm
            // 
            this.textBox_unit_per_mm.Location = new System.Drawing.Point(183, 47);
            this.textBox_unit_per_mm.Name = "textBox_unit_per_mm";
            this.textBox_unit_per_mm.Size = new System.Drawing.Size(100, 21);
            this.textBox_unit_per_mm.TabIndex = 64;
            this.textBox_unit_per_mm.Text = "0";
            // 
            // label_unitpermm
            // 
            this.label_unitpermm.AutoSize = true;
            this.label_unitpermm.Location = new System.Drawing.Point(87, 50);
            this.label_unitpermm.Name = "label_unitpermm";
            this.label_unitpermm.Size = new System.Drawing.Size(90, 12);
            this.label_unitpermm.TabIndex = 63;
            this.label_unitpermm.Text = "Step per mm  :";
            // 
            // comboBox_Axis
            // 
            this.comboBox_Axis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Axis.FormattingEnabled = true;
            this.comboBox_Axis.Location = new System.Drawing.Point(7, 21);
            this.comboBox_Axis.Name = "comboBox_Axis";
            this.comboBox_Axis.Size = new System.Drawing.Size(339, 20);
            this.comboBox_Axis.TabIndex = 0;
            this.comboBox_Axis.SelectedIndexChanged += new System.EventHandler(this.comboBox_Axis_SelectedIndexChanged);
            // 
            // checkBox_com_connect
            // 
            this.checkBox_com_connect.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_com_connect.Location = new System.Drawing.Point(226, 2);
            this.checkBox_com_connect.Name = "checkBox_com_connect";
            this.checkBox_com_connect.Size = new System.Drawing.Size(105, 20);
            this.checkBox_com_connect.TabIndex = 8;
            this.checkBox_com_connect.Text = "Connect";
            this.checkBox_com_connect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_com_connect.UseVisualStyleBackColor = true;
            this.checkBox_com_connect.Click += new System.EventHandler(this.checkBox_com_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Com port : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_com_port
            // 
            this.comboBox_com_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_com_port.FormattingEnabled = true;
            this.comboBox_com_port.Location = new System.Drawing.Point(87, 2);
            this.comboBox_com_port.Name = "comboBox_com_port";
            this.comboBox_com_port.Size = new System.Drawing.Size(133, 20);
            this.comboBox_com_port.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 71;
            this.label3.Text = "Speed :";
            // 
            // numericUpDown_spd
            // 
            this.numericUpDown_spd.Location = new System.Drawing.Point(183, 101);
            this.numericUpDown_spd.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_spd.Name = "numericUpDown_spd";
            this.numericUpDown_spd.Size = new System.Drawing.Size(100, 21);
            this.numericUpDown_spd.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 12);
            this.label4.TabIndex = 73;
            this.label4.Text = "mm/sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 76;
            this.label5.Text = "mm/sec²";
            // 
            // numericUpDown_acc_dec
            // 
            this.numericUpDown_acc_dec.Location = new System.Drawing.Point(183, 128);
            this.numericUpDown_acc_dec.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_acc_dec.Name = "numericUpDown_acc_dec";
            this.numericUpDown_acc_dec.Size = new System.Drawing.Size(100, 21);
            this.numericUpDown_acc_dec.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 12);
            this.label6.TabIndex = 74;
            this.label6.Text = "Acc/Dec :";
            // 
            // MotionSettingLUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_com_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_com_port);
            this.Name = "MotionSettingLUC";
            this.Size = new System.Drawing.Size(361, 273);
            this.Load += new System.EventHandler(this.MotionSettingLUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_spd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_acc_dec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_use_axis;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox_unit_per_mm;
        private System.Windows.Forms.Label label_unitpermm;
        private System.Windows.Forms.ComboBox comboBox_Axis;
        private System.Windows.Forms.CheckBox checkBox_com_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_com_port;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_ui_vertical;
        private System.Windows.Forms.TextBox textBox_user_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_spd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_acc_dec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}
