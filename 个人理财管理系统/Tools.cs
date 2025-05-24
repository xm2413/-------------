using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人理财管理系统
{
    public class Tools
    {
        // 私有静态实例
        private static Tools _instance;
        private string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";
        // 私有构造函数，防止外部实例化
        private Tools()
        {
            // 初始化逻辑（如加载配置）
        }

        // 公共静态属性，返回唯一实例
        public static Tools Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Tools();
                }
                return _instance;
            }
        }
        #region 以下为从服务器获取
        public List<SaveList> GetListTable()
        {
            #region 获取[list]表
            string query = "SELECT * FROM [dbo].[list]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<SaveList> saveList = new List<SaveList>();

                while (reader.Read())
                {
                    SaveList item = new SaveList
                    {
                        itemid = reader.GetInt32(1),
                        tradedate = reader.GetDateTime(2),
                        explain = reader.IsDBNull(3) ? null : reader.GetString(3),
                        jine = reader.GetDecimal(4),
                        username = reader.IsDBNull(5) ? null : reader.GetString(5),
                        remark = reader.IsDBNull(6) ? null : reader.GetString(6)
                    };
                    saveList.Add(item);
                }
                return saveList;
            }
            #endregion
        }

        public List<Category> GetCategoryTable()
        {
            #region 获取[category]表
            string query = "SELECT * FROM [dbo].[category]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Category> categories = new List<Category>();
                while (reader.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1).Trim(),
                        IsPayout = reader.GetBoolean(2),
                        Remark = reader.IsDBNull(3) ? null : reader.GetString(3)
                    };
                    categories.Add(category);
                }
                return categories;
            }
            #endregion
        }
        public List<Item> GetItemTable()
        {
            #region 获取[item]表
            string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";
            string query2 = "SELECT * FROM [dbo].[item]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Item> items = new List<Item>();
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
                }
                return items;
            }
            #endregion
        }
        #endregion
        #region 以下为通过id或name查找
        public Item FindItemById(int itemId, List<Item> items)
        {
            foreach (Item item1 in items)
            {
                //MessageBox.Show(item1.ItemName.Trim()+itemName);
                if (item1.ItemId == itemId)
                {
                    //MessageBox.Show("找到了");
                    return item1;
                }
            }
            return null;
        }
        public Item FindItemByName(string itemName, List<Item> items)
        {
            foreach (Item item1 in items)
            {
                //MessageBox.Show(item1.ItemName.Trim()+itemName);
                if (item1.ItemName.Trim() == itemName.Trim())
                {
                    //MessageBox.Show("找到了");
                    return item1;
                }
            }
            return null;

        }
        public Category FindCategoryById(int? CategoryId, List<Category> categories)
        {
            foreach (Category category in categories)
            {
                //MessageBox.Show(item1.ItemName.Trim()+itemName);
                if (category.CategoryId == CategoryId)
                {
                    //MessageBox.Show("找到了");
                    return category;
                }
            }
            return null;
        }
        public Category FindCategoryByName(string CategoryName, List<Category> categories)
        {
            foreach (Category category in categories)
            {
                //MessageBox.Show(category.CategoryName.Trim()+ CategoryName.Trim()+'/');
                if (category.CategoryName.Trim() == CategoryName.Trim())
                {
                    //MessageBox.Show("找到了");
                    return category;
                }
            }
            return null;
        }
        #endregion
    }
}
