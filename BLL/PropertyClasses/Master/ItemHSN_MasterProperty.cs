using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class ItemHSN_MasterProperty
    {
        public Int64 HSN_ID { get; set; }       
        public string HSN_Name { get; set; }
        public string HSN_Code { get; set; }
        public string IGST_DATE { get; set; }
        public double IGST_RATE { get; set; }
        public string SGST_DATE { get; set; }
        public double SGST_RATE { get; set; }
        public string CGST_DATE { get; set; }
        public double CGST_RATE { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
    }
}
