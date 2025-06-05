namespace 个人理财管理系统
{
    partial class LoginForm
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
            button2 = new Button();
            button3 = new Button();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(308, 268);
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
            label1.Font = new Font("Microsoft Sans Serif", 25.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(115, 59);
            label1.Name = "label1";
            label1.Size = new Size(233, 59);
            label1.TabIndex = 1;
            label1.Text = "个人理财";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(39, 144);
            label2.Name = "label2";
            label2.Size = new Size(126, 32);
            label2.TabIndex = 1;
            label2.Text = "用户名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.9999981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(39, 200);
            label3.Name = "label3";
            label3.Size = new Size(119, 32);
            label3.TabIndex = 1;
            label3.Text = "密   码：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 146);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 30);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(171, 268);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 0;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_Cancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(46, 268);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 0;
            button3.Text = "登录";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button_Load_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(171, 202);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(249, 30);
            textBox3.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 360);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LoginForm";
            Text = "欢迎界面";
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
        private Button button2;
        private Button button3;
        private TextBox textBox3;

    }
}
