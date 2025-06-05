using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace 个人理财管理系统
{
    public partial class CategoryForm : Form
    {
        private List<CategoryData> categories = new List<CategoryData>();
        public CategoryForm()
        {
            InitializeComponent();
            categories = SQLManager.Instance.GetCategoryTable();
            DataGridInit();

        }
        private void DataGridInit()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < categories.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1, categories[i].CategoryName, categories[i].IsPayout, categories[i].Remark);
            }
        }
        private List<CategoryData> GetGridInfo()
        {
            List<CategoryData> categories2 = new();
            // 实现修改逻辑，例如保存更改到数据库或文件
            // 示例：遍历 DataGridView 的行并获取数据
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if (row.IsNewRow) continue; // 跳过新行

                int id = Convert.ToInt32(row.Cells[0].Value);
                string name = row.Cells[1].Value.ToString();
                bool isExpense = Convert.ToBoolean(row.Cells[2].Value);
                string remarks = row.Cells[3].Value?.ToString() ?? string.Empty;
                CategoryData category = new CategoryData();
                category.CategoryId = categories[i].CategoryId;
                category.CategoryName = name;
                category.IsPayout = isExpense;
                category.Remark = remarks;
                categories2.Add(category);
                // 这里可以将数据保存到数据库或其他存储介质
            }
            return categories2;
        }
        private void ChildForm2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 显示修改确认消息框
            DialogResult result = MessageBox.Show(
                "确定要修改吗？",    // 消息内容
                "删除确认",      // 标题
                MessageBoxButtons.OKCancel, // 按钮：确定和取消
                MessageBoxIcon.Question,    // 图标：问号
                MessageBoxDefaultButton.Button1); // 默认按钮：确定

            // 根据用户的选择执行相应的操作
            if (result == DialogResult.OK)
            {
                // 用户点击了“确定”，执行删除操作
                ModifyGridByButton();
            }
            else
            {

            }

        }
        private void ModifyGridByButton()
        {
            List<CategoryData> categories2 = GetGridInfo();

            int successRow = 0;
            for (int i = 0; i < categories2.Count; i++)
            {
                successRow += UpdateCategoryWithTransaction(
                    SQLManager.Instance.connectionString,
                    categories2[i].CategoryId,
                    categories2[i].CategoryName,
                    categories2[i].IsPayout,
                    categories2[i].Remark
                    );
            }
            MessageBox.Show("修改成功");
            for (int i = 0; i < categories2.Count; i++)
            {

                categories[i].CategoryName = categories2[i].CategoryName;
                categories[i].IsPayout = categories2[i].IsPayout;
                categories[i].Remark = categories2[i].Remark;
            }
            //dataGridView1.Rows.Clear();
            DataGridInit();
        }
        private static int UpdateCategoryWithTransaction(string connectionString, int categoryId, string newName, bool isPayout, string remark)
        {
            int successRow = 0;
            string updateQuery = @"UPDATE [dbo].[category]
                            SET [categoryname] = @newName,
                                [ispayout] = @isPayout,
                                [remark] = @remark
                            WHERE [categoryid] = @categoryId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //MessageBox.Show("Connection opened successfully.");

                    // 开始事务
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = new SqlCommand(updateQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@newName", newName);
                            command.Parameters.AddWithValue("@isPayout", isPayout);
                            command.Parameters.AddWithValue("@remark", remark);
                            command.Parameters.AddWithValue("@categoryId", categoryId);

                            int rowsAffected = command.ExecuteNonQuery();
                            successRow += rowsAffected;
                            //MessageBox.Show($"{rowsAffected} row(s) updated within the transaction.");
                        }

                        // 如果所有操作成功，提交事务
                        transaction.Commit();
                        //MessageBox.Show("Transaction committed successfully.");
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                        //MessageBox.Show("Connection closed.");
                    }
                }
            }
            return successRow;
        }
        DataGridViewRow selectedRow;
        private void button2_Click(object sender, EventArgs e)//删除
        {
            selectedRow = dataGridView1.CurrentRow;
            int cnt;
            if (selectedRow != null)
            {
                // 处理选中的行
                cnt = Convert.ToInt32(selectedRow.Cells[0].Value) - 1;
                DeleteButton(cnt);
            }
            else
            {
                MessageBox.Show("请先选择一行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void DeleteButton(int cnt)
        {
            // 显示修改确认消息框
            DialogResult result = MessageBox.Show(
                "确定要删除吗？",    // 消息内容
                "删除确认",      // 标题
                MessageBoxButtons.OKCancel, // 按钮：确定和取消
                MessageBoxIcon.Question,    // 图标：问号
                MessageBoxDefaultButton.Button1); // 默认按钮：确定

            // 根据用户的选择执行相应的操作
            if (result == DialogResult.OK)
            {
                List<CategoryData> categories2 = GetGridInfo();
                int categoryIdToDelete = categories2[cnt].CategoryId; // 要删除的categoryid

                using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
                {
                    connection.Open();

                    // 检查是否有外键约束
                    bool hasForeignKeyConstraint = CheckForeignKeyConstraint(connection, categoryIdToDelete);

                    if (hasForeignKeyConstraint)
                    {
                        // 执行你希望的其他代码
                        MessageBox.Show("该收支类别有收支项目信息，不能删除！", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        // 直接删除该项
                        DeleteCategory(connection, categoryIdToDelete);
                        categories.Remove(categories[cnt]);
                        DataGridInit();
                        MessageBox.Show("删除成功！", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            else
            {

            }

        }
        private bool CheckForeignKeyConstraint(SqlConnection connection, int categoryId)
        {
            string query = "SELECT COUNT(*) FROM [item] WHERE [categoryid] = @categoryId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryId", categoryId);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void DeleteCategory(SqlConnection connection, int categoryId)
        {
            string query = "DELETE FROM [category] WHERE [categoryid] = @categoryId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<CategoryData> categories2 = GetGridInfo();
            foreach (CategoryData category in categories2)
            {
            }
        }
    }
}
