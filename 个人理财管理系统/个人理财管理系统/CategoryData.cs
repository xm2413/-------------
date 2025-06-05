using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人理财管理系统
{
    public class CategoryData
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsPayout { get; set; }
        public string Remark { get; set; }
    }
}
