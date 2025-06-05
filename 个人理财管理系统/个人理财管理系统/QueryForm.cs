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

namespace 个人理财管理系统
{
    public partial class QueryForm : Form
    {
        private List<SaveData> saveList = new List<SaveData>();
        private List<CategoryData> categories = new List<CategoryData>();
        private List<ItemData> items = new List<ItemData>();
        public QueryForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            UpdateData();
        }
        private void UpdateData()
        {
            saveList = SQLManager.Instance.GetListTable();
            categories = SQLManager.Instance.GetCategoryTable();
            items = SQLManager.Instance.GetItemTable();
        }

        private int curSelectIndex;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curSelectIndex = comboBox1.SelectedIndex;
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)//均可用
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            UpdateData();
            List<SaveData> approveSaveData = new List<SaveData>();

            
            if (textBox1.Text.Trim() == "")
            {
                for (int i = 0; i < saveList.Count; i++)
                {
                    ItemData item = SQLManager.Instance.FindItemById(saveList[i].itemid, items);
                    CategoryData category = SQLManager.Instance.FindCategoryById(item.CategoryId, categories);
                    approveSaveData.Add(saveList[i]);
                }
            }
            else
            {
                if (curSelectIndex == 0)//按收支项
                {
                    string s1 = textBox1.Text.Trim();
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        ItemData item = SQLManager.Instance.FindItemById(saveList[i].itemid, items);
                        CategoryData category = SQLManager.Instance.FindCategoryById(item.CategoryId, categories);
                        if (item.ItemName.Trim() != s1) continue;
                        approveSaveData.Add( saveList[i]);
                    }
                }
                if (curSelectIndex == 1)//按类别
                {
                    string s1 = textBox1.Text.Trim();
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        ItemData item = SQLManager.Instance.FindItemById(saveList[i].itemid, items);
                        CategoryData category = SQLManager.Instance.FindCategoryById(item.CategoryId, categories);
                        if (category.CategoryName != s1) continue;
                        approveSaveData.Add((saveList[i]));
                    }
                }
                if (curSelectIndex == 2)//按说明
                {
                    string s1 = textBox1.Text.Trim();
                    approveSaveData = saveList.Where(item => item.remark.Contains(s1)).ToList();
                    
                }
                if (curSelectIndex == 3)//按金额
                {
                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("查询条件不完整，请补充！", "查询错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string s1 = textBox1.Text.Trim();
                    string s2 = textBox2.Text.Trim();
                    decimal d1=decimal.Parse(s1);
                    decimal d2=decimal.Parse(s2);

                    approveSaveData = saveList.Where(item => item.jine>=d1&&item.jine<=d2).ToList();
                }
                if (curSelectIndex == 4)//按日期
                {
                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("查询条件不完整，请补充！", "查询错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string s1 = textBox1.Text.Trim();
                    string s2 = textBox2.Text.Trim();

                    DateTime dateTime1 = DateTime.Parse(s1);
                    DateTime dateTime2 = DateTime.Parse(s2);

                    approveSaveData = saveList.Where(item => item.tradedate >= dateTime1 && item.tradedate <= dateTime2).ToList();
                }

            }
            MessageBox.Show("结果：" + approveSaveData.Count);
            int index = 0;
            foreach (var saveData in approveSaveData)
            {
                ItemData item = SQLManager.Instance.FindItemById(saveData.itemid, items);
                CategoryData category = SQLManager.Instance.FindCategoryById(item.CategoryId, categories);
                dataGridView1.Rows.Add(index++,
                                       item.ItemName,
                                       category.CategoryName,
                                       category.IsPayout ? "支出" : "收入",
                                       saveData.tradedate,
                                       saveData.jine,
                                       saveData.remark);
            }

        }
        private void ChildForm4_Load(object sender, EventArgs e)
        {

        }
    }
}
