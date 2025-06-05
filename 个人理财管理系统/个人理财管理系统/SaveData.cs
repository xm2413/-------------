using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人理财管理系统
{
    public class SaveData
    {
        public int itemid { get; set; }

        public DateTime tradedate { get; set; } = DateTime.Now;

        public decimal jine { get; set; }

        public string username { get; set; }
        public string remark { get; set; }

        public string explain { get; set; }
    }

}
