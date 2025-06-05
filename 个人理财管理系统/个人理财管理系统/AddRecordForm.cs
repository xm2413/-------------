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
    public partial class AddRecordForm : Form
    {
        private List<CategoryData> categoryList = new List<CategoryData>();
        private List<ItemData> allItemList = new List<ItemData>();
        private CategoryData nowCategory;
        private bool listInited = false;
        private string AdminUserName;
        public AddRecordForm(string username)
        {
            InitializeComponent();
            this.AdminUserName = username;
            categoryList = SQLManager.Instance.GetCategoryTable();
            radioButton1.Checked = true;
            allItemList = SQLManager.Instance.GetItemTable();
            checkBox1.Checked = true;


            RefreshListBox();
            listInited = true;

        }
        //支出单选框
        private bool afterRidioChanged;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                //afterRidioChanged = true;
                comboBox1.Items.Clear();

                foreach (CategoryData category in categoryList)
                {
                    if (category.IsPayout) comboBox1.Items.Add(category.CategoryName);
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
        }
        //收入单选框
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //afterRidioChanged = true;
            if (radioButton1.Checked)
            {
                comboBox1.Items.Clear();

                foreach (CategoryData category in categoryList)
                {
                    if (!category.IsPayout) comboBox1.Items.Add(category.CategoryName);
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

        }
        //private int currentIndex = 0;
        //下拉框
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());
            if (listInited == false) return;
            RefreshListBox();
            //afterRidioChanged = false;
        }
        //根据当前选择的收支类型刷新列表
        private void RefreshListBox()
        {
            //if (afterRidioChanged) return;
            string selectedName = comboBox1.SelectedItem?.ToString();
            CategoryData selectedCategory = categoryList.Find(x => x.CategoryName == selectedName);
           // MessageBox.Show(selectedName);
            listBox1.Items.Clear();

            foreach (var item in allItemList)
            {
                if (item.CategoryId == selectedCategory.CategoryId)
                {
                    listBox1.Items.Add(item.ItemName);
                }
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                //currentIndex = selected;
            }
            else
            {
                MessageBox.Show("尚无收支项目，请先添加！", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //comboBox1.SelectedIndex = currentIndex;
            }

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

        //保存按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("金额信息小于等于0，请修改后保存！", "信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveData saveData = new SaveData();
            string selectedItem = listBox1.SelectedItem?.ToString();
            ItemData item = allItemList.Find((x) => x.ItemName.Trim() == selectedItem.Trim());
            saveData.itemid = item.ItemId;
            saveData.jine = numericUpDown1.Value;
            saveData.explain = comboBox1.Text.Trim() + "-" + listBox1.Text + '\n';
            saveData.explain += "日期：" + saveData.tradedate.ToString("yyyy年M月d日") + '\n';
            saveData.explain += "说明：\n";
            saveData.explain += "收支人：";
            List<CheckBox> checkedCheckBoxes;
            GetCheckedCheckBoxes(groupBox2, out checkedCheckBoxes);

            foreach (var checkBox in checkedCheckBoxes)
            {
                saveData.explain += checkBox.Text + " ";
                saveData.username += checkBox.Text + " ";
            }
            textBox2.Text = saveData.explain;
            saveData.explain += '\n';
            if (MessageBox.Show("确认保存吗?", "保存操作", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                AddSaveList(saveData);
            }
        }
        private void AddSaveList(SaveData saveData)
        {
            int itemId = saveData.itemid;
            decimal jine = saveData.jine;
            string username = AdminUserName;
            string explain = saveData.explain;
            string remark = textBox2.Text;

            string insertQuery = @"
                INSERT INTO [dbo].[list] (itemid, tradedate, explain, jine, username, remark)
                VALUES (@ItemId, @TradeDate, @Explain, @Jine, @Username, @Remark)";


            using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
                        command.Parameters.Add("@TradeDate", SqlDbType.DateTime).Value = saveData.tradedate;
                        command.Parameters.Add("@Explain", SqlDbType.NChar, 20).Value = explain;
                        command.Parameters.Add("@Jine", SqlDbType.Decimal).Value = jine;
                        command.Parameters.Add("@Username", SqlDbType.NChar, 10).Value = username;
                        command.Parameters.Add("@Remark", SqlDbType.VarChar, 50).Value = remark;


                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
        private void ChildForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
