using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class State_MasterProperty
    {
        public Int64 State_Code { get; set; }
        public Int64 Country_Code { get; set; }
        public string State_Name { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }   
    }
}
