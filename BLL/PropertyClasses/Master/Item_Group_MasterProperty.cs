using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class Item_Group_MasterProperty
    {
        public Int64 Item_Group_Code { get; set; }
        public string Item_Group_Name { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
    }
}
