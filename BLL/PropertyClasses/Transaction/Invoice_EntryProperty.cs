using System;

namespace BLL.PropertyClasses.Transaction
{
    public class Invoice_EntryProperty
    {
        public Int64 Purchase_Master_ID { get; set; }
        public Int64 TransactionMasterID { get; set; }
        public Int64 TransactionDetailID { get; set; }
        public Int64 Unit_ID { get; set; }
        public int Own_Truck { get; set; }
        public string Invoice_Date { get; set; }
        public string Description { get; set; }
        public string Unload_Date { get; set; }
        public string From_Party_GSTNo { get; set; }
        public string To_Party_GSTNo { get; set; }
        public string LR_No { get; set; }
        public string MT { get; set; }
        public string Financial_Year { get; set; }
        public string Invoice_No { get; set; }
        public Int64 From_Party { get; set; }
        public Int64 To_Party { get; set; }
        public string From_Party_Name { get; set; }
        public string To_Party_Name { get; set; }
        public string Bill_OF_Entry_Date { get; set; }
        public string Party_Invoice_No { get; set; }
        public string Payment_Mode { get; set; }
        public string Payment_Days { get; set; }
        public string Payment_Date { get; set; }
        public string Transaction_Date { get; set; }
        public Int64 From_Party_Code { get; set; }
        public Int64 To_Party_Code { get; set; }
        public Int64 From_Destination { get; set; }
        public Int64 To_Destination { get; set; }
        public Int64 IS_Reverse { get; set; }
        public Int64 HSN_ID { get; set; }
        public decimal My_Commission { get; set; }
        public decimal Commission { get; set; }
        public decimal Advance { get; set; }
        public Int64 Truck_No { get; set; }
        public decimal Diesel_Expence { get; set; }
        public decimal Diesel { get; set; }
        public decimal Baki { get; set; }
        public decimal Freight { get; set; }
        public decimal Weight { get; set; }
        public decimal Holding { get; set; }
        public Int64 ItemSaleReturnMasterID { get; set; }
        public Int64 ItemSaleReturnDtlID { get; set; }
        public Int64 ItemPurchaseMasterID { get; set; }
        public Int64 ItemPurchaseDetailID { get; set; }
        public Int64 ItemPurchaseRtnMasterID { get; set; }
        public Int64 ItemPurchaseReturnDtlID { get; set; }
        public Int64 ItemSaleDetailID { get; set; }
        public Int64 ItemSaleMasterID { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public double CGST_Amt { get; set; }
        public double SGST_Amt { get; set; }
        public decimal IGST_Amt { get; set; }
        public double Total_Amt { get; set; }
        public double Gross_Amt { get; set; }
        public double Add_Amt { get; set; }
        public double Less_Amt { get; set; }
        public decimal Net_Amt { get; set; }
        public decimal Labour_Amt { get; set; }
        public string Challan_No { get; set; }
        public string Fin_Year { get; set; }

        public string From_Date { get; set; }
        public string To_Date { get; set; }
        public double T_Amt { get; set; }

        private Int64 _SrNo;
        public Int64 SrNo
        {
            get { return _SrNo; }
            set { _SrNo = value; }
        }

        private string _Unit_Type;

        public string Unit_Type
        {
            get { return _Unit_Type; }
            set { _Unit_Type = value; }
        }

        private Int64 _Item_Code;

        public Int64 Item_Code
        {
            get { return _Item_Code; }
            set { _Item_Code = value; }
        }

        private double _Split_Per;

        public double Split_Per
        {
            get { return _Split_Per; }
            set { _Split_Per = value; }
        }

        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        private Int64 _Lot_ID;

        public Int64 Lot_ID
        {
            get { return _Lot_ID; }
            set { _Lot_ID = value; }
        }

        private Int64 _Parent_Lot_ID;

        public Int64 Parent_Lot_ID
        {
            get { return _Parent_Lot_ID; }
            set { _Parent_Lot_ID = value; }
        }

        private Int64 _Source_Code;

        public Int64 Source_Code
        {
            get { return _Source_Code; }
            set { _Source_Code = value; }
        }

        private Int64 _Source_Company_Code;

        public Int64 Source_Company_Code
        {
            get { return _Source_Company_Code; }
            set { _Source_Company_Code = value; }
        }

        private Int64 _Article_Code;

        public Int64 Article_Code
        {
            get { return _Article_Code; }
            set { _Article_Code = value; }
        }

        private Int64 _MSize_Code;

        public Int64 MSize_Code
        {
            get { return _MSize_Code; }
            set { _MSize_Code = value; }
        }

        private Int64 _Quality_Code;

        public Int64 Quality_Code
        {
            get { return _Quality_Code; }
            set { _Quality_Code = value; }
        }


        private Int64 _SubQuality_Code;

        public Int64 SubQuality_Code
        {
            get { return _SubQuality_Code; }
            set { _SubQuality_Code = value; }
        }

        private decimal _Quantity;

        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private decimal _Rate_Dollar;

        public decimal Rate_Dollar
        {
            get { return _Rate_Dollar; }
            set { _Rate_Dollar = value; }
        }

        private double _Rate_Local;

        public double Rate_Local
        {
            get { return _Rate_Local; }
            set { _Rate_Local = value; }
        }

        private double _Rate_Purchase;

        public double Rate_Purchase
        {
            get { return _Rate_Purchase; }
            set { _Rate_Purchase = value; }
        }


        private double _Prem_Disc;

        public double Prem_Disc
        {
            get { return _Prem_Disc; }
            set { _Prem_Disc = value; }
        }



        private Int64 _Terms;

        public Int64 Terms
        {
            get { return _Terms; }
            set { _Terms = value; }
        }


        private double _Prem_Amount_Dollar;

        public double Prem_Amount_Dollar
        {
            get { return _Prem_Amount_Dollar; }
            set { _Prem_Amount_Dollar = value; }
        }

        private double _Prem_Amount_Local;

        public double Prem_Amount_Local
        {
            get { return _Prem_Amount_Local; }
            set { _Prem_Amount_Local = value; }
        }
        private decimal _Amount;

        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private double _Prem_Amount_Purchase;

        public double Prem_Amount_Purchase
        {
            get { return _Prem_Amount_Purchase; }
            set { _Prem_Amount_Purchase = value; }
        }

        private double _Prem_Rate_Dollar;

        public double Prem_Rate_Dollar
        {
            get { return _Prem_Rate_Dollar; }
            set { _Prem_Rate_Dollar = value; }
        }

        private double _Prem_Rate_Local;

        public double Prem_Rate_Local
        {
            get { return _Prem_Rate_Local; }
            set { _Prem_Rate_Local = value; }
        }

        private double _Prem_Rate_Purchase;

        public double Prem_Rate_Purchase
        {
            get { return _Prem_Rate_Purchase; }
            set { _Prem_Rate_Purchase = value; }
        }

        private double _Amount_Dollar;

        public double Amount_Dollar
        {
            get { return _Amount_Dollar; }
            set { _Amount_Dollar = value; }
        }

        private double _Amount_Local;

        public double Amount_Local
        {
            get { return _Amount_Local; }
            set { _Amount_Local = value; }
        }

        private double _Amount_Purchase;

        public double Amount_Purchase
        {
            get { return _Amount_Purchase; }
            set { _Amount_Purchase = value; }
        }


        private string _Issue_Type;

        public string Issue_Type
        {
            get { return _Issue_Type; }
            set { _Issue_Type = value; }
        }


        private string _Brokrage_Type;

        public string Brokrage_Type
        {
            get { return _Brokrage_Type; }
            set { _Brokrage_Type = value; }
        }

        private double _Brokrage;

        public double Brokrage
        {
            get { return _Brokrage; }
            set { _Brokrage = value; }
        }

        private double _Brokrage_Amount_Dollar;

        public double Brokrage_Amount_Dollar
        {
            get { return _Brokrage_Amount_Dollar; }
            set { _Brokrage_Amount_Dollar = value; }
        }

        private double _Brokrage_Amount_Local;

        public double Brokrage_Amount_Local
        {
            get { return _Brokrage_Amount_Local; }
            set { _Brokrage_Amount_Local = value; }
        }

        private double _Brokrage_Amount_Purchase;

        public double Brokrage_Amount_Purchase
        {
            get { return _Brokrage_Amount_Purchase; }
            set { _Brokrage_Amount_Purchase = value; }
        }

        private string _Create_Date;

        public string Create_Date
        {
            get { return _Create_Date; }
            set { _Create_Date = value; }
        }

        private string _Create_Time;

        public string Create_Time
        {
            get { return _Create_Time; }
            set { _Create_Time = value; }
        }


        private double _Balance_Quantity;

        public double Balance_Quantity
        {
            get { return _Balance_Quantity; }
            set { _Balance_Quantity = value; }
        }


        private double _Balance_Carat;

        public double Balance_Carat
        {
            get { return _Balance_Carat; }
            set { _Balance_Carat = value; }
        }


        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private Int64 _Goods_Rec_Pcs;

        public Int64 Goods_Rec_Pcs
        {
            get { return _Goods_Rec_Pcs; }
            set { _Goods_Rec_Pcs = value; }
        }

        private double _Goods_Rec_Carat;

        public double Goods_Rec_Carat
        {
            get { return _Goods_Rec_Carat; }
            set { _Goods_Rec_Carat = value; }
        }

        private string _Goods_Rec_Date;

        public string Goods_Rec_Date
        {
            get { return _Goods_Rec_Date; }
            set { _Goods_Rec_Date = value; }
        }

        private string _Goods_Rec_Time;

        public string Goods_Rec_Time
        {
            get { return _Goods_Rec_Time; }
            set { _Goods_Rec_Time = value; }
        }


        private Int64 _Goods_Rec_Employee_Code;

        public Int64 Goods_Rec_Employee_Code
        {
            get { return _Goods_Rec_Employee_Code; }
            set { _Goods_Rec_Employee_Code = value; }
        }

        private string _Goods_Rec_Computer_IP;

        public string Goods_Rec_Computer_IP
        {
            get { return _Goods_Rec_Computer_IP; }
            set { _Goods_Rec_Computer_IP = value; }
        }

        private Int64 _Loss_Pcs;

        public Int64 Loss_Pcs
        {
            get { return _Loss_Pcs; }
            set { _Loss_Pcs = value; }
        }

        private Int64 _Lost_Pcs;

        public Int64 Lost_Pcs
        {
            get { return _Lost_Pcs; }
            set { _Lost_Pcs = value; }
        }

        private Int64 _Trn_Id;

        public Int64 Trn_Id
        {
            get { return _Trn_Id; }
            set { _Trn_Id = value; }
        }


        private Int64 _IS_Approve;

        public Int64 IS_Approve
        {
            get { return _IS_Approve; }
            set { _IS_Approve = value; }
        }

        private Int64 _IS_Hold;

        public Int64 IS_Hold
        {
            get { return _IS_Hold; }
            set { _IS_Hold = value; }
        }

        private double _Vat_Per;

        public double Vat_Per
        {
            get { return _Vat_Per; }
            set { _Vat_Per = value; }
        }

        private double _Add_Vat_Per;

        public double Add_Vat_Per
        {
            get { return _Add_Vat_Per; }
            set { _Add_Vat_Per = value; }
        }

        private double _Disc_Per;

        public double Disc_Per
        {
            get { return _Disc_Per; }
            set { _Disc_Per = value; }
        }

        private double _Add_Amount;

        public double Add_Amount
        {
            get { return _Add_Amount; }
            set { _Add_Amount = value; }
        }

        private double _Less_Amount;

        public double Less_Amount
        {
            get { return _Less_Amount; }
            set { _Less_Amount = value; }
        }

        private double _Net_Amount_Dollar;

        public double Net_Amount_Dollar
        {
            get { return _Net_Amount_Dollar; }
            set { _Net_Amount_Dollar = value; }
        }

        private double _Net_Amount_Local;

        public double Net_Amount_Local
        {
            get { return _Net_Amount_Local; }
            set { _Net_Amount_Local = value; }
        }

        private double _Net_Amount_Purchase;

        public double Net_Amount_Purchase
        {
            get { return _Net_Amount_Purchase; }
            set { _Net_Amount_Purchase = value; }
        }

        private Int64 _Company_Code;

        public Int64 Company_Code
        {
            get { return _Company_Code; }
            set { _Company_Code = value; }
        }

        private Int64 _Branch_Code;

        public Int64 Branch_Code
        {
            get { return _Branch_Code; }
            set { _Branch_Code = value; }
        }
    }
}
