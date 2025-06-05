using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人理财管理系统
{
    public class SQLManager
    {
        private static SQLManager _instance;
        public readonly string connectionString = "Server=(localdb)\\ProjectModels;Database=finance;Integrated Security=True;";
        private SQLManager()
        {
            
        }

        public static SQLManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLManager();
                }
                return _instance;
            }
        }
        public List<SaveData> GetListTable()
        {
            string query = "SELECT * FROM [dbo].[list]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<SaveData> saveList = new List<SaveData>();

                while (reader.Read())
                {
                    SaveData item = new SaveData
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
        }

        public List<CategoryData> GetCategoryTable()
        {
            string query = "SELECT * FROM [dbo].[category]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<CategoryData> categories = new List<CategoryData>();
                while (reader.Read())
                {
                    CategoryData category = new CategoryData
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
        }
        public List<ItemData> GetItemTable()
        {
            //string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ShiyanDatabaseProject;Integrated Security=True;";
            string query2 = "SELECT * FROM [dbo].[item]";
            using (SqlConnection connection = new SqlConnection(SQLManager.Instance.connectionString))
            {
                SqlCommand command = new SqlCommand(query2, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<ItemData> items = new List<ItemData>();
                while (reader.Read())
                {
                    ItemData item = new ItemData
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
        }
        public ItemData FindItemById(int itemId, List<ItemData> items)
        {
            foreach (ItemData item1 in items)
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
        public ItemData FindItemByName(string itemName, List<ItemData> items)
        {
            foreach (ItemData item1 in items)
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
        public CategoryData FindCategoryById(int? CategoryId, List<CategoryData> categories)
        {
            foreach (CategoryData category in categories)
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
        public CategoryData FindCategoryByName(string CategoryName, List<CategoryData> categories)
        {
            foreach (CategoryData category in categories)
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
    }
}
