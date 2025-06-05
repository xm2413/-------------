namespace 个人理财管理系统
{
    partial class AddRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            listBox1 = new ListBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            label7 = new Label();
            numericUpDown1 = new NumericUpDown();
            label8 = new Label();
            textBox2 = new TextBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(167, 0);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(71, 28);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "支出";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(94, 0);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(71, 28);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "收入";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 82);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 0;
            label2.Text = "收支类别：";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(146, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 32);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 132);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 0;
            label3.Text = "收支项目：";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 24;
            listBox1.Location = new Point(146, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(180, 124);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(379, 35);
            label4.Name = "label4";
            label4.Size = new Size(64, 24);
            label4.TabIndex = 0;
            label4.Text = "日期：";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(449, 35);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 30);
            dateTimePicker1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(379, 76);
            label5.Name = "label5";
            label5.Size = new Size(64, 24);
            label5.TabIndex = 0;
            label5.Text = "说明：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(455, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(294, 30);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(98, 0);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(54, 28);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "我";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(54, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(278, 36);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "收支类型：";
            groupBox1.Enter += groupBox1_Enter_1;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(179, 0);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(72, 28);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "家人";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(268, 0);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(72, 28);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "亲戚";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(98, 36);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(72, 28);
            checkBox4.TabIndex = 6;
            checkBox4.Text = "朋友";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(179, 36);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(72, 28);
            checkBox5.TabIndex = 6;
            checkBox5.Text = "同事";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(268, 34);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(72, 28);
            checkBox6.TabIndex = 6;
            checkBox6.Text = "其他";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(379, 219);
            label7.Name = "label7";
            label7.Size = new Size(64, 24);
            label7.TabIndex = 0;
            label7.Text = "金额：";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(455, 217);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(185, 30);
            numericUpDown1.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 280);
            label8.Name = "label8";
            label8.Size = new Size(64, 24);
            label8.TabIndex = 0;
            label8.Text = "备注：";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(146, 277);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(603, 120);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox5);
            groupBox2.Controls.Add(checkBox6);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Location = new Point(389, 128);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(370, 70);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "收支人：";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // button1
            // 
            button1.Location = new Point(139, 426);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 11;
            button1.Text = "保存";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(637, 426);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 11;
            button2.Text = "退出";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddRecordForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 503);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Name = "AddRecordForm";
            Text = "收支情况记录";
            Load += ChildForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private ListBox listBox1;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Label label7;
        private NumericUpDown numericUpDown1;
        private Label label8;
        private TextBox textBox2;
        private GroupBox groupBox2;
        private Button button1;
        private Button button2;
    }
}