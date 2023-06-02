using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Transaction
{
    public class Item_Purchase_Master
    {
        public decimal ItemPurchaseMasterID { get; set; }
        public int ReferenceNo { get; set; }
        public System.DateTime ReceivedDate { get; set; }
        public string FinancialYear { get; set; }
        public string FromParty1 { get; set; }
        public string FromParty2 { get; set; }
        public Nullable<System.DateTime> PartyInvoiceDate { get; set; }
        public string ToParty1 { get; set; }
        public string ToParty2 { get; set; }
        public string ChallanNo { get; set; }
        public string Payment { get; set; }
        public string Terms { get; set; }
        public Nullable<System.DateTime> TermsDate { get; set; }
        public string CostCenter { get; set; }
        public string SubCostCenter { get; set; }
        public int TotalItems { get; set; }
        public int Quantity { get; set; }
        public decimal GrossAmount { get; set; }
        public string Remark { get; set; }
        public System.DateTime SystemDate { get; set; }
        public System.Guid Rowguid { get; set; }
    }
}
