using Azure.Identity;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace 个人理财管理系统
{

    public partial class Form1 : Form
    {
        SqlConnection conn;
        private string UserName;
        private string Password;
        public Form1()
        {

            InitializeComponent();
            this.Name = "个人理财";
            string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";
            conn = new SqlConnection(connectionString);
            conn.Open();

            //MessageBox.Show("数据库连接成功！");

            /*
            #region 手动添加username和password
            try
            {
                // 插入数据的 SQL 语句
                string query = "INSERT INTO [user] (username, password) VALUES (@username, @password)";

                // 创建 SqlCommand 对象
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 添加参数并设置值
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    // 执行插入操作
                    //int rowsAffected = cmd.ExecuteNonQuery();
                    //MessageBox.Show($"数据插入成功！影响了 {rowsAffected} 行。");
                }
            }
            

            catch (Exception ex)
            {
                //MessageBox.Show("发生错误：" + ex.Message);
            }
            #endregion
            //*/
            //#region 检测是否添加成功
            //string query2 = "SELECT * FROM [user]";

            //// 创建 SqlCommand 对象
            //using (SqlCommand cmd = new SqlCommand(query2, conn))
            //{
            //    // 执行查询操作
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        // 检查是否有数据
            //        if (!reader.HasRows)
            //        {
            //            MessageBox.Show("表中没有数据。");
            //        }
            //        else
            //        {
            //            // 遍历并输出每一行数据
            //            while (reader.Read())
            //            {
            //                MessageBox.Show($"链接成功！Username: {reader["username"]}, Password: {reader["password"]}");
            //            }
            //        }
            //    }
            //}
            //#endregion
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
            //textBox1.Text = conn.ConnectionString;
            textBox1.Text = "";
            TextBox2.Text = "";
        }
        private void button_Load_Click(object sender, EventArgs e)
        {

            UserName = textBox1.Text.Trim();
            Password = TextBox2.Text.Trim();
            string sql = "SELECT COUNT(*) FROM [user] WHERE username = @username AND password = @password";
            if (string.IsNullOrEmpty(UserName))
            {
                DialogResult result = MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    textBox1.Focus();
                    TextBox2.Text = new string('*', TextBox2.Text.Length);
                }
            }
            else if (string.IsNullOrEmpty(Password))
            {
                DialogResult result = MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    TextBox2.Focus();
                }
            }
            else if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(TextBox2.Text.Trim()))
            {
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@username", UserName);
                    comm.Parameters.AddWithValue("@password", Password);

                    // 执行查询并获取结果
                    object result = comm.ExecuteScalar();

                    // 判断是否有匹配的记录
                    if(true)
                    if (result != null && (int)result == 1)
                    {
                        MessageBox.Show("欢迎进入理财系统！", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form2 form2 = new Form2(this);
                        TextBox2.PasswordChar = '*';
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


