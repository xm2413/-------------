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
    public partial class ChildForm4 : Form
    {
        private List<SaveList> saveList = new List<SaveList>();
        private List<Category> categories = new List<Category>();
        private List<Item> items = new List<Item>();
        public ChildForm4()
        {
            InitializeComponent();
            this.Text = "收支明细查询";
            comboBox1.SelectedIndex = 0;
            UpdateData();
        }
        private void UpdateData()
        {
            saveList = Tools.Instance.GetListTable();
            categories = Tools.Instance.GetCategoryTable();
            items = Tools.Instance.GetItemTable();
        }

        private void ChildForm4_Load(object sender, EventArgs e)
        {

        }
        private int SelectIndex;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndex = comboBox1.SelectedIndex;
            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 2)
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
            if (textBox1.Text.Trim() == "")
            {
                for (int i = 0; i < saveList.Count; i++)
                {
                    Item item = Tools.Instance.FindItemById(saveList[i].itemid, items);
                    Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                    dataGridView1.Rows.Add(i + 1,
                                           item.ItemName,
                                           category.CategoryName,
                                           category.IsPayout ? "支出" : "收入",
                                           saveList[i].tradedate,
                                           saveList[i].jine,
                                           saveList[i].remark);
                }
                return;
            }
            else
            {

                if (SelectIndex == 0)//收支项
                {
                    string s1 = textBox1.Text.Trim();
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        Item item = Tools.Instance.FindItemById(saveList[i].itemid, items);
                        Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                        if (item.ItemName.Trim() != s1) continue;
                        dataGridView1.Rows.Add(i + 1,
                                               item.ItemName,
                                               category.CategoryName,
                                               category.IsPayout ? "支出" : "收入",
                                               saveList[i].tradedate,
                                               saveList[i].jine,
                                               saveList[i].remark);
                    }
                }
                if (SelectIndex == 1) //类别
                {
                    string s1 = textBox1.Text.Trim();
                    for (int i = 0; i < saveList.Count; i++)
                    {
                        Item item = Tools.Instance.FindItemById(saveList[i].itemid, items);
                        Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                        if (category.CategoryName != s1) continue;
                        dataGridView1.Rows.Add(i + 1,
                                               item.ItemName,
                                               category.CategoryName,
                                               category.IsPayout ? "支出" : "收入",
                                               saveList[i].tradedate,
                                               saveList[i].jine,
                                               saveList[i].remark);
                    }
                }
                if (SelectIndex == 2)//说明
                {
                    string s1 = textBox1.Text.Trim();
                    var resultList = saveList.Where(item => item.remark.Contains(s1)).ToList();

                    // 输出结果
                    for (int i = 0;i<resultList.Count;i++)
                    {
                        Item item = Tools.Instance.FindItemById(resultList[i].itemid, items);
                        Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                        
                        dataGridView1.Rows.Add(i + 1,
                                               item.ItemName,
                                               category.CategoryName,
                                               category.IsPayout ? "支出" : "收入",
                                               saveList[i].tradedate,
                                               saveList[i].jine,
                                               resultList[i].remark);
                    }
                    
                }
                if (SelectIndex == 3)//金额
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

                    var resultList = saveList.Where(item => item.jine>=d1&&item.jine<=d2).ToList();
                    // 输出结果
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        //MessageBox.Show(resultList[i].jine.ToString());
                        Item item = Tools.Instance.FindItemById(resultList[i].itemid, items);
                        Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                        dataGridView1.Rows.Add(i + 1,
                                               item.ItemName,
                                               category.CategoryName,
                                               category.IsPayout ? "支出" : "收入",
                                               saveList[i].tradedate,
                                               saveList[i].jine,
                                               resultList[i].remark);
                    }
                }
                if (SelectIndex == 4)//日期
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
                    //if(dateTime1<=sa)
                    var resultList = saveList.Where(item => item.tradedate >= dateTime1 && item.tradedate <= dateTime2).ToList();
                    // 输出结果
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        //MessageBox.Show(resultList[i].jine.ToString());
                        Item item = Tools.Instance.FindItemById(resultList[i].itemid, items);
                        Category category = Tools.Instance.FindCategoryById(item.CategoryId, categories);
                        dataGridView1.Rows.Add(i + 1,
                                               item.ItemName,
                                               category.CategoryName,
                                               category.IsPayout ? "支出" : "收入",
                                               saveList[i].tradedate,
                                               saveList[i].jine,
                                               resultList[i].remark);
                    }
                }

            }

        }
    }
}
