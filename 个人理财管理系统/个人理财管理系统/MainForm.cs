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
    public partial class MainForm : Form
    {
        private string username;
        public MainForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {

        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "确定要退出程序吗？",
                "退出确认",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void 添加收支ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecordForm addRecordForm = new AddRecordForm(username);
            addRecordForm.MdiParent = this;
            addRecordForm.Show();
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
        private void 收支类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.MdiParent = this;
            categoryForm.Show();
        }
        private void 收支项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.MdiParent = this;
            itemForm.Show();
        }
        private void 统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            queryForm.MdiParent = this;
            queryForm.Show();
        }
    }
}
