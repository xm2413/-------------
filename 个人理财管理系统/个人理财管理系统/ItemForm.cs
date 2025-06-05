using Microsoft.Data.SqlClient;
using System.Data;

namespace 个人理财管理系统
{
    public partial class ItemForm : Form
    {
        private List<CategoryData> categories = new List<CategoryData>();
        private List<ItemData> items = new List<ItemData>();
        public ItemForm()
        {
            InitializeComponent();
            categories=SQLManager.Instance.GetCategoryTable();
            items=SQLManager.Instance.GetItemTable();
            DataGridInit();
        }
        
        

        private void DataGridInit()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                CategoryData category = SQLManager.Instance.FindCategoryById(items[i].CategoryId, categories);

                dataGridView1.Rows.Add(i + 1, items[i].ItemName, category.CategoryName, items[i].Remark);
            }
            comboBox1.Items.Clear();
            foreach (CategoryData category in categories)
            {
                comboBox1.Items.Add(category.CategoryName);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ChildForm3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("收支项目不能为空！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (comboBox1.SelectedIndex <= -1)
                {
                    MessageBox.Show("收支类别不能为空！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    AddButton();
                }
            }
        }
        private void AddButton()
        {
            // 显示修改确认消息框
            DialogResult result = MessageBox.Show(
                "确定要添加吗？",    // 消息内容
                "添加确认",      // 标题
                MessageBoxButtons.OKCancel, // 按钮：确定和取消
                MessageBoxIcon.Question,    // 图标：问号
                MessageBoxDefaultButton.Button1); // 默认按钮：确定

            // 根据用户的选择执行相应的操作
            if (result == DialogResult.OK)
            {

                string itemname = textBox1.Text;
                CategoryData category = SQLManager.Instance.FindCategoryByName(comboBox1.SelectedItem.ToString(), categories);
                string remark = textBox2.Text;
                if (SQLManager.Instance.FindItemByName(itemname, items) != null)
                {
                    MessageBox.Show("收支项目已经存在，不能重复添加！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                AddItem(itemname, category.CategoryId, remark);
                MessageBox.Show("添加成功！", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                items = SQLManager.Instance.GetItemTable();
                DataGridInit();

            }
            else
            {
                return;
            }

        }
        public int AddItem(string itemName, int categoryId, string remark)
        {
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));

            int newItemId;
            string query = @"INSERT INTO [dbo].[item] ([itemname], [categoryid], [remark])
                         OUTPUT INSERTED.[itemid]
                         VALUES (@ItemName, @CategoryId, @Remark);";

            using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 设置参数值
                    command.Parameters.Add("@ItemName", SqlDbType.NChar, 20).Value = itemName.PadRight(20);
                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                    command.Parameters.Add("@Remark", SqlDbType.VarChar, 50).Value = remark ?? string.Empty;

                    try
                    {
                        connection.Open();
                        newItemId = (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        // 处理SQL异常
                        throw new ApplicationException("Error occurred while inserting the item.", ex);
                    }
                    finally
                    {
                        // 确保连接关闭
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            return newItemId;
        }
        public int selectedRowIndex;
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {

            // 获取当前选中的行
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            if (selectedRow != null)
            {

                if (selectedRow.IsNewRow)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    return;
                }
                else
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    string name = selectedRow.Cells[1].Value.ToString();
                    if (name == null) return;
                    textBox1.Text = name;
                    selectedRowIndex = selectedRow.Index;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= -1)
            {
                MessageBox.Show("收支类别不能为空！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 显示修改确认消息框
            DialogResult result = MessageBox.Show(
                "确定要修改吗？",    // 消息内容
                "修改确认",      // 标题
                MessageBoxButtons.OKCancel, // 按钮：确定和取消
                MessageBoxIcon.Question,    // 图标：问号
                MessageBoxDefaultButton.Button1); // 默认按钮：确定

            // 根据用户的选择执行相应的操作
            if (result == DialogResult.OK)
            {
                ModifyButton();
            }
            else
            {
                return;
            }
        }
        private void ModifyButton()
        {
            int itemId = items[selectedRowIndex].ItemId;
            string newname = textBox1.Text;
            CategoryData category = SQLManager.Instance.FindCategoryByName(comboBox1.SelectedItem.ToString(), categories);

            int? categoryId = category.CategoryId;
            string remark = textBox2.Text;
            UpdateItemWithTransaction(itemId, newname, categoryId, remark);
            items = SQLManager.Instance.GetItemTable();
            DataGridInit();
        }
        private static int UpdateItemWithTransaction(int itemId, string newName, int? categoryId, string remark)
        {
            int successRow = 0;
            string updateQuery = @"UPDATE [dbo].[item]
                                SET [itemname] = @newName,
                                    [categoryid] = @categoryid,
                                    [remark] = @remark
                                WHERE [itemid] = @itemId";

            using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
            {
                try
                {
                    connection.Open();
                    // 开始事务
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = new SqlCommand(updateQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@newName", newName);
                            command.Parameters.AddWithValue("@categoryId", categoryId); // 处理可空值
                            command.Parameters.AddWithValue("@remark", remark);
                            command.Parameters.AddWithValue("@itemId", itemId);

                            int rowsAffected = command.ExecuteNonQuery();
                            successRow += rowsAffected;
                        }
                        // 如果所有操作成功，提交事务
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return successRow;
        }

        private void button3_Click(object sender, EventArgs e)
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
                DeleteButton();
            }
            else
            {
                return;
            }
        }
        private void DeleteButton()
        {


            int itemIdToDelete = items[selectedRowIndex].ItemId; // 要删除的categoryid

            using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
            {
                connection.Open();

                // 检查是否有外键约束
                bool hasForeignKeyConstraint = CheckForeignKeyConstraint(connection, itemIdToDelete);

                if (hasForeignKeyConstraint)
                {
                    // 执行你希望的其他代码
                    MessageBox.Show("该收支项目有对应的收支明细信息，不能删除！", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    // 直接删除该项
                    DeleteItem(connection, itemIdToDelete);
                    items.Remove(items[selectedRowIndex]);
                    DataGridInit();
                    MessageBox.Show("删除成功！", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private bool CheckForeignKeyConstraint(SqlConnection connection, int itemId)
        {
            string query = "SELECT COUNT(*) FROM [list] WHERE [itemid] = @itemId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@itemId", itemId);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void DeleteItem(SqlConnection connection, int itemId)
        {
            string query = "DELETE FROM [item] WHERE [itemid] = @itemId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@itemId", itemId);
                command.ExecuteNonQuery();
            }
        }
    }
}
