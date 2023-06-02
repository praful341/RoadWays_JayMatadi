using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Transaction
{
    public class Item_Sales
    {
        public decimal ItemSalesID { get; set; }
        public decimal ItemSalesMasterID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public decimal AddVat { get; set; }
        public decimal Discount { get; set; }
        public decimal AddAmount { get; set; }
        public decimal LessAmount { get; set; }
        public decimal NetAmount { get; set; }
        public System.DateTime SystemDate { get; set; }
        public System.Guid Rowguid { get; set; }
    }
}
