using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Account
{
    public class Item_Purchase_MasterProperty
    {

        private string _Fin_Year;

        public string Fin_Year
        {
            get { return _Fin_Year; }
            set { _Fin_Year = value; }
        }

        private int _Invoice_No;

        public int Invoice_No
        {
            get { return _Invoice_No; }
            set { _Invoice_No = value; }
        }

        private string _Party_Invoice_No;

        public string Party_Invoice_No
        {
            get { return _Party_Invoice_No; }
            set { _Party_Invoice_No = value; }
        }

        private string _Invoice_Date;

        public string Invoice_Date
        {
            get { return _Invoice_Date; }
            set { _Invoice_Date = value; }
        }

        private int _Purchase_Type_Code;

        public int Purchase_Type_Code
        {
            get { return _Purchase_Type_Code; }
            set { _Purchase_Type_Code = value; }
        }

        private int _From_Sub_Party_Code;

        public int From_Sub_Party_Code
        {
            get { return _From_Sub_Party_Code; }
            set { _From_Sub_Party_Code = value; }
        }

        private int _To_Sub_Party_Code;

        public int To_Sub_Party_Code
        {
            get { return _To_Sub_Party_Code; }
            set { _To_Sub_Party_Code = value; }
        }

        private int _Third_Sub_Party_Code;

        public int Third_Sub_Party_Code
        {
            get { return _Third_Sub_Party_Code; }
            set { _Third_Sub_Party_Code = value; }
        }

        private int _Third_Party_Group_Code;

        public int Third_Party_Group_Code
        {
            get { return _Third_Party_Group_Code; }
            set { _Third_Party_Group_Code = value; }
        }

        //private int _From_Party_Code;

        //public int From_Party_Code
        //{
        //    get { return _From_Party_Code; }
        //    set { _From_Party_Code = value; }
        //}

        private int _Third_Party_Code;

        public int Third_Party_Code
        {
            get { return _Third_Party_Code; }
            set { _Third_Party_Code = value; }
        }

        private int _From_Party_Group_Code;

        public int From_Party_Group_Code
        {
            get { return _From_Party_Group_Code; }
            set { _From_Party_Group_Code = value; }
        }

        private Int64 _To_Party_Code;

        public Int64 To_Party_Code
        {
            get { return _To_Party_Code; }
            set { _To_Party_Code = value; }
        }

        private Int64 _From_Party_Code;

        public Int64 From_Party_Code
        {
            get { return _From_Party_Code; }
            set { _From_Party_Code = value; }
        }

        private int _To_Party_Group_Code;

        public int To_Party_Group_Code
        {
            get { return _To_Party_Group_Code; }
            set { _To_Party_Group_Code = value; }
        }

        private int _Broker_Code;

        public int Broker_Code
        {
            get { return _Broker_Code; }
            set { _Broker_Code = value; }
        }

        private int _Local_Currency_Code;

        public int Local_Currency_Code
        {
            get { return _Local_Currency_Code; }
            set { _Local_Currency_Code = value; }
        }

        private double _Local_Currency_Rate;

        public double Local_Currency_Rate
        {
            get { return _Local_Currency_Rate; }
            set { _Local_Currency_Rate = value; }
        }

        private int _Purchase_Currency_Code;

        public int Purchase_Currency_Code
        {
            get { return _Purchase_Currency_Code; }
            set { _Purchase_Currency_Code = value; }
        }

        private double _Purchase_Currency_Rate;

        public double Purchase_Currency_Rate
        {
            get { return _Purchase_Currency_Rate; }
            set { _Purchase_Currency_Rate = value; }
        }

        private int _Payment_Days;

        public int Payment_Days
        {
            get { return _Payment_Days; }
            set { _Payment_Days = value; }
        }

        private string _Payment_Date;

        public string Payment_Date
        {
            get { return _Payment_Date; }
            set { _Payment_Date = value; }
        }

        private string _Bill_Of_Entry_Date;

        public string Bill_Of_Entry_Date
        {
            get { return _Bill_Of_Entry_Date; }
            set { _Bill_Of_Entry_Date = value; }
        }

        private string _Payment_Mode;

        public string Payment_Mode
        {
            get { return _Payment_Mode; }
            set { _Payment_Mode = value; }
        }

        private double _Total_Quantity;

        public double Total_Quantity
        {
            get { return _Total_Quantity; }
            set { _Total_Quantity = value; }
        }

        private double _Brokrage;

        public double Brokrage
        {
            get { return _Brokrage; }
            set { _Brokrage = value; }
        }

        private double _Gross_Amount_Dollar;

        public double Gross_Amount_Dollar
        {
            get { return _Gross_Amount_Dollar; }
            set { _Gross_Amount_Dollar = value; }
        }

        private double _Gross_Amount_Local;

        public double Gross_Amount_Local
        {
            get { return _Gross_Amount_Local; }
            set { _Gross_Amount_Local = value; }
        }

        private double _Gross_Amount_Purchase;

        public double Gross_Amount_Purchase
        {
            get { return _Gross_Amount_Purchase; }
            set { _Gross_Amount_Purchase = value; }
        }

        private double _Other_Charges;

        public double Other_Charges
        {
            get { return _Other_Charges; }
            set { _Other_Charges = value; }
        }

        private double _Freight_charges;

        public double Freight_charges
        {
            get { return _Freight_charges; }
            set { _Freight_charges = value; }
        }

        private double _Insurence_Charges;

        public double Insurence_Charges
        {
            get { return _Insurence_Charges; }
            set { _Insurence_Charges = value; }
        }

        private double _VAT_Charges;

        public double VAT_Charges
        {
            get { return _VAT_Charges; }
            set { _VAT_Charges = value; }
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

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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

        private int _Record_Code;

        public int Record_Code
        {
            get { return _Record_Code; }
            set { _Record_Code = value; }
        }

        private Int64 _Trn_Id;

        public Int64 Trn_Id
        {
            get { return _Trn_Id; }
            set { _Trn_Id = value; }
        }

        private string _Trn_Date;

        public string Trn_Date
        {
            get { return _Trn_Date; }
            set { _Trn_Date = value; }
        }


        private string _Lot_Create_By;

        public string Lot_Create_By
        {
            get { return _Lot_Create_By; }
            set { _Lot_Create_By = value; }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _Item_Tax_Code;

        public int Item_Tax_Code
        {
            get { return _Item_Tax_Code; }
            set { _Item_Tax_Code = value; }
        }

        private string _Item_Tax_Name;

        public string Item_Tax_Name
        {
            get { return _Item_Tax_Name; }
            set { _Item_Tax_Name = value; }
        }

        private double _Item_Tax_Per;

        public double Item_Tax_Per
        {
            get { return _Item_Tax_Per; }
            set { _Item_Tax_Per = value; }
        }

        private double _Item_Tax_Amount_Dollar;

        public double Item_Tax_Amount_Dollar
        {
            get { return _Item_Tax_Amount_Dollar; }
            set { _Item_Tax_Amount_Dollar = value; }
        }

        private double _Item_Tax_Amount_Local;

        public double Item_Tax_Amount_Local
        {
            get { return _Item_Tax_Amount_Local; }
            set { _Item_Tax_Amount_Local = value; }
        }

        private double _Item_Tax_Amount_Purchase;

        public double Item_Tax_Amount_Purchase
        {
            get { return _Item_Tax_Amount_Purchase; }
            set { _Item_Tax_Amount_Purchase = value; }
        }

        private int _Cost_Center_Code;

        public int Cost_Center_Code
        {
            get { return _Cost_Center_Code; }
            set { _Cost_Center_Code = value; }
        }

        private int _Sub_Cost_Center_Code;

        public int Sub_Cost_Center_Code
        {
            get { return _Sub_Cost_Center_Code; }
            set { _Sub_Cost_Center_Code = value; }
        }


    }

    public class Item_Purchase_DetailProperty
    {

        private string _Fin_Year;

        public string Fin_Year
        {
            get { return _Fin_Year; }
            set { _Fin_Year = value; }
        }


        private string _Save_Category;

        public string Save_Category
        {
            get { return _Save_Category; }
            set { _Save_Category = value; }
        }


        private int _Invoice_No;

        public int Invoice_No
        {
            get { return _Invoice_No; }
            set { _Invoice_No = value; }
        }

        private int _SrNo;

        public int SrNo
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

        private int _Item_Code;

        public int Item_Code
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

        private int _Source_Code;

        public int Source_Code
        {
            get { return _Source_Code; }
            set { _Source_Code = value; }
        }

        private int _Source_Company_Code;

        public int Source_Company_Code
        {
            get { return _Source_Company_Code; }
            set { _Source_Company_Code = value; }
        }

        private int _Article_Code;

        public int Article_Code
        {
            get { return _Article_Code; }
            set { _Article_Code = value; }
        }

        private int _MSize_Code;

        public int MSize_Code
        {
            get { return _MSize_Code; }
            set { _MSize_Code = value; }
        }

        private int _Quality_Code;

        public int Quality_Code
        {
            get { return _Quality_Code; }
            set { _Quality_Code = value; }
        }


        private int _SubQuality_Code;

        public int SubQuality_Code
        {
            get { return _SubQuality_Code; }
            set { _SubQuality_Code = value; }
        }

        private int _Sight_Type_Code;

        public int Sight_Type_Code
        {
            get { return _Sight_Type_Code; }
            set { _Sight_Type_Code = value; }
        }

        private int _Team_Code;

        public int Team_Code
        {
            get { return _Team_Code; }
            set { _Team_Code = value; }
        }

        private int _Group_Code;

        public int Group_Code
        {
            get { return _Group_Code; }
            set { _Group_Code = value; }
        }

        private double _Quantity;

        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        //private double _Carat;

        //public double Carat
        //{
        //    get { return _Carat; }
        //    set { _Carat = value; }
        //}

        //private double _Parent_Carat;

        //public double Parent_Carat
        //{
        //    get { return _Parent_Carat; }
        //    set { _Parent_Carat = value; }
        //}

        private double _Rate_Dollar;

        public double Rate_Dollar
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



        private int _Terms;

        public int Terms
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

        private int _Goods_Rec_Pcs;

        public int Goods_Rec_Pcs
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


        private int _Goods_Rec_Employee_Code;

        public int Goods_Rec_Employee_Code
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



        private int _Loss_Pcs;

        public int Loss_Pcs
        {
            get { return _Loss_Pcs; }
            set { _Loss_Pcs = value; }
        }


        //private double _Loss_Carat;

        //public double Loss_Carat
        //{
        //    get { return _Loss_Carat; }
        //    set { _Loss_Carat = value; }
        //}


        private int _Lost_Pcs;

        public int Lost_Pcs
        {
            get { return _Lost_Pcs; }
            set { _Lost_Pcs = value; }
        }


        //private double _Lost_Carat;

        //public double Lost_Carat
        //{
        //    get { return _Lost_Carat; }
        //    set { _Lost_Carat = value; }
        //}


        //private double _Carat_Plus;

        //public double Carat_Plus
        //{
        //    get { return _Carat_Plus; }
        //    set { _Carat_Plus = value; }
        //}


        private Int64 _Trn_Id;

        public Int64 Trn_Id
        {
            get { return _Trn_Id; }
            set { _Trn_Id = value; }
        }


        private int _IS_Approve;

        public int IS_Approve
        {
            get { return _IS_Approve; }
            set { _IS_Approve = value; }
        }

        private int _IS_Hold;

        public int IS_Hold
        {
            get { return _IS_Hold; }
            set { _IS_Hold = value; }
        }

        /* Add new field */

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

        private int _Company_Code;

        public int Company_Code
        {
            get { return _Company_Code; }
            set { _Company_Code = value; }
        }

        private int _Branch_Code;

        public int Branch_Code
        {
            get { return _Branch_Code; }
            set { _Branch_Code = value; }
        }

        private int _Department_Code;

        public int Department_Code
        {
            get { return _Department_Code; }
            set { _Department_Code = value; }
        }

    }
}
