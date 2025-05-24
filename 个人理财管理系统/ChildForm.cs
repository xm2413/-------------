using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using GroupBox = System.Windows.Forms.GroupBox;

namespace 个人理财管理系统
{



    public partial class ChildForm1 : Form
    {
        private List<Category> categoriesIsPay = new List<Category>();//支出

        private List<Category> categoriesNotPay = new List<Category>();//收入
        private List<Item> items = new List<Item>();
        private Category nowCategory;
        public ChildForm1()
        {
            InitializeComponent();
            this.Text = "收支情况记录";
            string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";

            #region 获取[category]表
            string query = "SELECT * FROM [dbo].[category]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        IsPayout = reader.GetBoolean(2),
                        Remark = reader.IsDBNull(3) ? null : reader.GetString(3)
                    };
                    if (category.IsPayout)
                    {
                        categoriesIsPay.Add(category);
                    }
                    else
                    {
                        categoriesNotPay.Add(category);
                    }

                }
                radioButton1.Checked = true;
            }
            #endregion
            #region 获取item表
            string query2 = "SELECT * FROM [dbo].[item]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item
                    {
                        ItemId = reader.GetInt32(0), // itemid
                        ItemName = reader.GetString(1).Trim(), // itemname
                        CategoryId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2), // categoryid
                        Remark = reader.IsDBNull(3) ? null : reader.GetString(3) // remark
                    };
                    items.Add(item);
                    OnComboBox1_SelectedIndexChanged();

                }
            }
            #endregion
            checkBox1.Checked = true;
        }





        private void ChildForm_Load(object sender, EventArgs e)
        {

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            
            foreach (Category cat in categoriesIsPay)
            {
                comboBox1.Items.Add(cat.CategoryName);
            }
            
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("尚无收支类别，请先添加！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButton1.Checked = true;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();

            foreach (Category cat in categoriesNotPay)
            {
                comboBox1.Items.Add(cat.CategoryName);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("尚无收支类别，请先添加！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private int currentIndex = 0;
        bool a = true;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a) { a = false; return; }
            OnComboBox1_SelectedIndexChanged();
        }
        private void OnComboBox1_SelectedIndexChanged()
        {
            int selected = comboBox1.SelectedIndex;
            listBox1.Items.Clear();

            foreach (var it in items)
            {
                if (radioButton1.Checked == true)
                {
                    if (it.CategoryId == categoriesNotPay[selected].CategoryId)
                    {
                        listBox1.Items.Add(it.ItemName);

                    }
                    textBox1.Text = categoriesNotPay[selected].Remark;
                }
                if (radioButton1.Checked == false)
                {
                    if (it.CategoryId == categoriesIsPay[selected].CategoryId)
                    {
                        listBox1.Items.Add(it.ItemName);
                    }
                    textBox1.Text = categoriesIsPay[selected].Remark;
                }
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                currentIndex = selected;
            }
            else
            {
                MessageBox.Show("尚无收支项目，请先添加！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.SelectedIndex = currentIndex;
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetCheckedCheckBoxes(GroupBox groupBox, out List<CheckBox> checkedCheckBoxes)
        {
            checkedCheckBoxes = new List<CheckBox>();
            foreach (Control control in groupBox.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    checkedCheckBoxes.Add(checkBox);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("金额信息小于等于0，请修改后保存！", "信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveList saveList = new SaveList();
            string selectedItem = listBox1.SelectedItem?.ToString();
            Item item = Tools.Instance.FindItemByName(selectedItem,items);
            saveList.itemid=item.ItemId;
            saveList.jine = numericUpDown1.Value;
            saveList.explain = comboBox1.Text.Trim() + "-" + listBox1.Text + '\n';
            saveList.explain += "日期：" + saveList.tradedate.ToString("yyyy年M月d日") + '\n';
            saveList.explain += "说明：\n";
            saveList.explain += "收支人：";
            List<CheckBox> checkedCheckBoxes;
            GetCheckedCheckBoxes(groupBox2, out checkedCheckBoxes);

            foreach (var checkBox in checkedCheckBoxes)
            {
                saveList.explain += checkBox.Text + " ";
                saveList.username += checkBox.Text + " ";
            }
            saveList.explain += '\n';
            MessageBox.Show(saveList.explain);
            AddSaveList(saveList);
        }
        private void AddSaveList(SaveList saveList)
        {
            int itemId = saveList.itemid; // 示例值，根据实际情况修改
            decimal jine = saveList.jine; // 示例值，必须大于0
            string username = "aa"; // 示例值，根据实际情况修改
            string explain = saveList.explain; // 可选
            string remark = textBox2.Text ; // 可选
            string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";

            // 定义INSERT语句
            string insertQuery = @"
                INSERT INTO [dbo].[list] (itemid, tradedate, explain, jine, username, remark)
                VALUES (@ItemId, @TradeDate, @Explain, @Jine, @Username, @Remark)";
            
            // 创建连接对象
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                connection.Open();
                // 创建命令对象
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // 添加参数并设置值
                    command.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
                    command.Parameters.Add("@TradeDate", SqlDbType.DateTime).Value=saveList.tradedate; // 默认当前时间
                    command.Parameters.Add("@Explain", SqlDbType.NChar, 20).Value=explain;
                    command.Parameters.Add("@Jine", SqlDbType.Decimal).Value=jine;
                    command.Parameters.Add("@Username", SqlDbType.NChar, 10).Value=username;
                    command.Parameters.Add("@Remark", SqlDbType.VarChar, 50).Value=remark;

                    // 执行插入命令
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("保存成功！","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
