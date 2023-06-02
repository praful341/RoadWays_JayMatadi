using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class Location_MasterProperty
    {
        public Int64 Location_Code { get; set; }
        public string Location_Name { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
    }
}
