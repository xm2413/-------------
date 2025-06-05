using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人理财管理系统
{
    public class ItemData
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryId { get; set; } // 可为空
        public string Remark { get; set; }
    }
}
