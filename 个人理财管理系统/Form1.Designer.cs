namespace 个人理财管理系统
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            TextBox2 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(584, 349);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "退出";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("方正润玉圆宋 简", 25.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(285, 79);
            label1.Name = "label1";
            label1.Size = new Size(233, 60);
            label1.TabIndex = 1;
            label1.Text = "个人理财";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("方正润玉圆宋 简", 13.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(249, 188);
            label2.Name = "label2";
            label2.Size = new Size(126, 32);
            label2.TabIndex = 1;
            label2.Text = "用户名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("方正润玉圆宋 简", 13.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(249, 250);
            label3.Name = "label3";
            label3.Size = new Size(122, 32);
            label3.TabIndex = 1;
            label3.Text = "密   码：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(394, 191);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            TextBox2.Location = new Point(394, 253);
            TextBox2.Name = "textBox2";
            TextBox2.Size = new Size(150, 30);
            TextBox2.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(362, 349);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 0;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_Cancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(139, 349);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 0;
            button3.Text = "登录";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button_Load_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Button button3;

        public TextBox TextBox2 { get => textBox2; set => textBox2 = value; }
    }
}
