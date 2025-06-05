using Azure.Identity;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace 个人理财管理系统
{

    public partial class LoginForm : Form
    {
        private string UserName;
        private string Password;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }
        private void button_Load_Click(object sender, EventArgs e)
        {

            UserName = textBox1.Text.Trim();
            Password = textBox3.Text.Trim();
            string sql = "SELECT COUNT(*) FROM [user] WHERE username = @username AND password = @password";
            if (string.IsNullOrEmpty(UserName))
            {
                DialogResult result = MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    textBox1.Focus();
                    textBox3.Text = new string('*', textBox3.Text.Length);
                }
            }
            else if (string.IsNullOrEmpty(Password))
            {
                DialogResult result = MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    textBox3.Focus();
                }
            }
            else if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                SqlConnection conn;
                conn = new SqlConnection(SQLManager.Instance.connectionString);
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@username", UserName);
                    comm.Parameters.AddWithValue("@password", Password);

                    object result = comm.ExecuteScalar();


                    if (result != null && (int)result == 1)
                    {
                        MessageBox.Show("欢迎进入理财系统！", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm form2 = new MainForm(UserName);
                        textBox3.PasswordChar = '*';
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误，请重试。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}


