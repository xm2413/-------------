using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 个人理财管理系统
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2()
        {
            InitializeComponent();
            this.Name = "个人理财";
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {

        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1.TextBox2.Text = "";
            form1.Show();
            this.Close();

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 显示确认对话框
            DialogResult result = MessageBox.Show(
                "确定要退出程序吗？",
                "退出确认",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            // 检查用户选择
            if (result == DialogResult.OK)
            {
                // 用户点击了"确定"，退出程序
                Application.Exit();
                // 或者如果你想关闭主窗体：
                // this.Close(); // 如果这是主窗体
            }
            // 如果用户点击"取消"，什么都不做，对话框会自动关闭
        }
        private static ChildForm1 childForm1;
        private void 添加收支ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在主窗体构造函数或Load事件中设置
            this.IsMdiContainer = true;

            // 创建并显示子窗体
            if (childForm1 == null)
            {
                childForm1 = new ChildForm1();
            }
            childForm1.MdiParent = this;  // 设置MdiParent属性
            //schildForm.WindowState = FormWindowState.Maximized;  // 最大化显示
            childForm1.Show();
        }

        private void 收支管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void 修改收支ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private static ChildForm2 childForm2;
        private void 收支类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在主窗体构造函数或Load事件中设置
            this.IsMdiContainer = true;

            // 创建并显示子窗体
            if (childForm2 == null)
            {
                childForm2 = new ChildForm2();
            }
            childForm2.MdiParent = this;  // 设置MdiParent属性
            //schildForm.WindowState = FormWindowState.Maximized;  // 最大化显示
            childForm2.Show();
        }
        private static ChildForm3 childForm3;
        private void 收支项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在主窗体构造函数或Load事件中设置
            this.IsMdiContainer = true;

            // 创建并显示子窗体
            if (childForm3 == null)
            {
                childForm3 = new ChildForm3();
            }
            childForm3.MdiParent = this;  // 设置MdiParent属性
            //schildForm.WindowState = FormWindowState.Maximized;  // 最大化显示
            childForm3.Show();
        }
        private static ChildForm4 childForm4;
        private void 统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在主窗体构造函数或Load事件中设置
            this.IsMdiContainer = true;

            // 创建并显示子窗体
            if (childForm4 == null)
            {
                childForm4 = new ChildForm4();
            }
            childForm4.MdiParent = this;  // 设置MdiParent属性
            //schildForm.WindowState = FormWindowState.Maximized;  // 最大化显示
            childForm4.Show();
        }
    }
}
