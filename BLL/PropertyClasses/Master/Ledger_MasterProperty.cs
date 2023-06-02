using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class Ledger_MasterProperty
    {
        public Int64 Ledger_Code { get; set; }
        public string Ledger_Name { get; set; }
        public string Contact_Person_Name { get; set; }
        public string Mobile_No { get; set; }
        public string Pan_No { get; set; }
        public string Party_Type { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public Int64 Country_Code { get; set; }
        public Int64 City_Code { get; set; }
        public Int64 State_Code { get; set; }
        public string Zip_Code { get; set; }
        public string Phone { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Branch { get; set; }
        public string Bank_IFSC { get; set; }
        public string Bank_Acc_No { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
        public string GSTTIN { get; set; }
        public string GSTIN_Effective_Date { get; set; }

        public Int64 LEDGER_OPENING_ID { get; set; }
        public Int64 Company_Code { get; set; }
        public Int64 Branch_Code { get; set; }
        public Int64 Location_Code { get; set; }

        public double Debit_Amt { get; set; }
        public double Credit_Amt { get; set; }
        public string Opening_Date { get; set; }
        public Int64 Fin_Year_Code { get; set; }


    }
}
