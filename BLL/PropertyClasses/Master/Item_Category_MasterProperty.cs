using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
   public class Item_Category_MasterProperty
    {
       public Int64 Item_Category_Code { get; set; }
       public string Item_Category_Name { get; set; }
       public int Active { get; set; }
       public string Remark { get; set; }
       public int Is_Consumable { get; set; }
       public int Is_repairable { get; set; }
    }
}
