using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLL.FunctionClasses.Entry;
using BLL.PropertyClasses.Account;
using BLL.FunctionClasses.Account;

using BLL.PropertyClasses.Master;
using BLL.FunctionClasses.Master;
using System.Collections;

using System.Data;
using DLL;
using BLL.PropertyClasses.Transaction;

namespace BLL.FunctionClasses.Account
{
    public class ItemPurchaseMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        Validation Val = new Validation();

        #region Property Settings

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        private DataTable _DTab = new DataTable("Item_Purchase_Detail");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        private DataTable _DTable = new DataTable("Item_Purchase_Master");

        public DataTable DTable
        {
            get { return _DTable; }
            set { _DTable = value; }
        }

        public string TableName
        {
            get { return "Item_Purchase_Master"; }
        }

        public string TableNameDetail
        {
            get { return "Item_Purchase_Detail"; }
        }

        private DataTable _DTabTax = new DataTable("Item_Purchse_Tax_Detail");

        public DataTable DTabTax
        {
            get { return _DTabTax; }
            set { _DTabTax = value; }
        }

        public string TableNameDetailTax
        {
            get { return "Item_Purchse_Tax_Detail"; }
        }
        
        #endregion

        #region Find New ID

        public int FindNewInvoiceNo(string pStrFinYear)
        {
            int IntRes = Val.ToInt(new Entry.MaximumID().Generate("ITEM_INVOICE_NO", pStrFinYear));
            return IntRes;
        }

        public int FindNewSrNo(string pStrFinYear)
        {
            int IntRes = Val.ToInt(new Entry.MaximumID().Generate("ITEM_SRNO", pStrFinYear));
            return IntRes;
        }

        public Int64 FindNewLotID(string pStrFinYear)
        {
            Int64 IntRes = Val.ToInt64(new Entry.MaximumID().Generate("ITEM_LOT_ID", pStrFinYear));
            return IntRes;
        }

        #endregion

        #region Save IMPORT

        //public int SaveInvoiceEntryMaster(ArrayList AL)
        //{
        //    int IntRes = 0;
        //    try
        //    {
        //        foreach (Ledger_MasterProperty Obj in AL)
        //        {
        //            Request Request  = new Request();

        //            Request.AddParams("@COMPANY_CODE_", Obj.Company_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@BRANCH_CODE_", Obj.Branch_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@LOCATION_CODE_", Obj.Location_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@LEDGER_CODE_", Obj.Ledger_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@LEDGER_OPENING_ID_", Obj.LEDGER_OPENING_ID, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@DEBIT_AMT_", Obj.Debit_Amt, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("@CREDIT_AMT_", Obj.Credit_Amt, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("@FIN_YEAR_CODE_", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("@OPENING_DATE_", Obj.Opening_Date, DbType.Date, ParameterDirection.Input);

        //            Request.CommandText = "Ledger_Opening_Save";
        //            Request.CommandType = CommandType.StoredProcedure;
        //            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //        }

        //        //Request Request = new Request();

        //        //Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("INVOICE_DATE_", pClsProperty.Invoice_Date, DbType.Date, ParameterDirection.Input);
        //        //Request.AddParams("BILL_OF_ENTRY_DATE_", pClsProperty.Bill_Of_Entry_Date, DbType.Date, ParameterDirection.Input);
        //        //Request.AddParams("PAYMENT_MODE_", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("PURCHASE_TYPE_CODE_", pClsProperty.Purchase_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("FROM_PARTY_GROUP_CODE_", pClsProperty.From_Party_Group_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("TO_PARTY_GROUP_CODE_", pClsProperty.To_Party_Group_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("BROKER_CODE_", pClsProperty.Broker_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("LOCAL_CURRENCY_CODE_", pClsProperty.Local_Currency_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Currency_Rate, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("PURCHASE_CURRENCY_CODE_", pClsProperty.Purchase_Currency_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("PURCHASE_EXCHANGE_RATE_", pClsProperty.Purchase_Currency_Rate, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("PAYMENT_DAYS_", pClsProperty.Payment_Days, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("PAYMENT_DATE_", pClsProperty.Payment_Date, DbType.Date, ParameterDirection.Input);
        //        //Request.AddParams("TOTAL_QUANTITY_", pClsProperty.Total_Quantity, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("BROKRAGE_", pClsProperty.Brokrage, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("GROSS_AMOUNT_DOLLAR_", pClsProperty.Gross_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("GROSS_AMOUNT_LOCAL_", pClsProperty.Gross_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("GROSS_AMOUNT_PURCHASE_", pClsProperty.Gross_Amount_Purchase, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("NET_AMOUNT_DOLLAR_", pClsProperty.Net_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("NET_AMOUNT_LOCAL_", pClsProperty.Net_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("NET_AMOUNT_PURCHASE_", pClsProperty.Net_Amount_Purchase, DbType.Double, ParameterDirection.Input);
        //        //Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("PARTY_INVOICE_NO_", pClsProperty.Party_Invoice_No, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("COST_CENTER_CODE_", pClsProperty.Cost_Center_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("SUB_COST_CENTER_CODE_", pClsProperty.Sub_Cost_Center_Code, DbType.Int32, ParameterDirection.Input);


        //        //Request.AddParams("STATUS_", pClsProperty.Status, DbType.String, ParameterDirection.Input);

        //        //Request.CommandText = "Item_Purchase_Master_Save";
        //        //Request.CommandType = CommandType.StoredProcedure;
        //        //IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //        //if (IntRes != -1)
        //        //{
        //        //    Request = SaveTaxItemPurchaseMaster(pClsProperty);

        //        //    Request.CommandText = "Item_Purchase_Tax_Detail_Save";
        //        //    Request.CommandType = CommandType.StoredProcedure;
        //        //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //        //}

        //        //if (IntRes != -1)
        //        //{
        //        //    foreach (Item_Purchase_DetailProperty Obj in AL)
        //        //    {
        //        //        Request = SaveItemPurchaseDetail(Obj);

        //        //        Request.CommandText = "Item_Purchase_Detail_Save";
        //        //        Request.CommandType = CommandType.StoredProcedure;
        //        //        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //        //    }
        //        //}
        //    }
        //    catch
        //    {
        //        // Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
        //        IntRes = 0;
        //    }

        //    return IntRes;
        //}


        public Invoice_EntryProperty SaveInvoiceEntryMaster(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ItemPurchaseMasterID", pClsProperty.Purchase_Master_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Company_Code", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Branch_Code", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Location_Code", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Ledger_Code", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Invoice_Date", pClsProperty.Invoice_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Inovice_No", pClsProperty.Invoice_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FinancialYear", pClsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Payment_Type", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Terms", pClsProperty.Payment_Days, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Term_Date", pClsProperty.Payment_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Trans_Date", pClsProperty.Transaction_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@IGST_Amt", pClsProperty.IGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Amt", pClsProperty.CGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Amt", pClsProperty.SGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Is_Reverse", pClsProperty.IS_Reverse, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Gross_Amt", pClsProperty.Gross_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Add_Amt", pClsProperty.Add_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Less_Amt", pClsProperty.Less_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Net_Amt", pClsProperty.Net_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Total_Amt", pClsProperty.Total_Amt, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "Purchase_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);

            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.Purchase_Master_ID = Convert.ToInt64(DTAB.Rows[0][1]);
                }
            }
            else
            {
                pClsProperty.Purchase_Master_ID = 0;
            }
            return pClsProperty;
        }

        public int SaveItemPurchaseMaster(Item_Purchase_MasterProperty pClsProperty, int pIntAllowBPartEntry, string pStrMode,ArrayList AL)
        {
            int IntRes = 0;
            try
            {
                Request Request = new Request();

                Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
                Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("INVOICE_DATE_", pClsProperty.Invoice_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("BILL_OF_ENTRY_DATE_", pClsProperty.Bill_Of_Entry_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("PAYMENT_MODE_", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
                Request.AddParams("PURCHASE_TYPE_CODE_", pClsProperty.Purchase_Type_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("FROM_PARTY_GROUP_CODE_", pClsProperty.From_Party_Group_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("TO_PARTY_GROUP_CODE_", pClsProperty.To_Party_Group_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("BROKER_CODE_", pClsProperty.Broker_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("LOCAL_CURRENCY_CODE_", pClsProperty.Local_Currency_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Currency_Rate, DbType.Double, ParameterDirection.Input);
                Request.AddParams("PURCHASE_CURRENCY_CODE_", pClsProperty.Purchase_Currency_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("PURCHASE_EXCHANGE_RATE_", pClsProperty.Purchase_Currency_Rate, DbType.Double, ParameterDirection.Input);
                Request.AddParams("PAYMENT_DAYS_", pClsProperty.Payment_Days, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("PAYMENT_DATE_", pClsProperty.Payment_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("TOTAL_QUANTITY_", pClsProperty.Total_Quantity, DbType.Double, ParameterDirection.Input);
                Request.AddParams("BROKRAGE_", pClsProperty.Brokrage, DbType.Double, ParameterDirection.Input);
                Request.AddParams("GROSS_AMOUNT_DOLLAR_", pClsProperty.Gross_Amount_Dollar, DbType.Double, ParameterDirection.Input);
                Request.AddParams("GROSS_AMOUNT_LOCAL_", pClsProperty.Gross_Amount_Local, DbType.Double, ParameterDirection.Input);
                Request.AddParams("GROSS_AMOUNT_PURCHASE_", pClsProperty.Gross_Amount_Purchase, DbType.Double, ParameterDirection.Input);
                Request.AddParams("NET_AMOUNT_DOLLAR_", pClsProperty.Net_Amount_Dollar, DbType.Double, ParameterDirection.Input);
                Request.AddParams("NET_AMOUNT_LOCAL_", pClsProperty.Net_Amount_Local, DbType.Double, ParameterDirection.Input);
                Request.AddParams("NET_AMOUNT_PURCHASE_", pClsProperty.Net_Amount_Purchase, DbType.Double, ParameterDirection.Input);
                Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
                Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("PARTY_INVOICE_NO_", pClsProperty.Party_Invoice_No, DbType.String, ParameterDirection.Input);
                Request.AddParams("COST_CENTER_CODE_", pClsProperty.Cost_Center_Code, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("SUB_COST_CENTER_CODE_", pClsProperty.Sub_Cost_Center_Code, DbType.Int32, ParameterDirection.Input);


                Request.AddParams("STATUS_", pClsProperty.Status, DbType.String, ParameterDirection.Input);

                Request.CommandText = "Item_Purchase_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;
                IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

                if (IntRes != -1)
                {
                    Request = SaveTaxItemPurchaseMaster(pClsProperty);

                    Request.CommandText = "Item_Purchase_Tax_Detail_Save";
                    Request.CommandType = CommandType.StoredProcedure;
                    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

                }

                if (IntRes != -1)
                {
                    foreach (Item_Purchase_DetailProperty Obj in AL)
                    {
                        Request = SaveItemPurchaseDetail(Obj);

                        Request.CommandText = "Item_Purchase_Detail_Save";
                        Request.CommandType = CommandType.StoredProcedure;
                        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

                    }
                }
            }
            catch
            {
                // Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
                IntRes = 0;
            }

            return IntRes;
        }
  
        public Request SaveTaxItemPurchaseMaster(Item_Purchase_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_CODE_", pClsProperty.Item_Tax_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_PER_", pClsProperty.Item_Tax_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_AMOUNT_DOLLAR_", pClsProperty.Item_Tax_Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_AMOUNT_LOCAL_", pClsProperty.Item_Tax_Amount_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_AMOUNT_PURCHASE_", pClsProperty.Item_Tax_Amount_Purchase, DbType.Double, ParameterDirection.Input);

            //Request.CommandText = BLL.TPV.SProc.Item_Purchase_Tax_Detail_Save;
            //Request.CommandType = CommandType.StoredProcedure;
            //return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return Request;
        }

        public Request SaveItemPurchaseDetail(Item_Purchase_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ITEM_CODE_", pClsProperty.Item_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("UNIT_TYPE_", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("QUANTITY_", pClsProperty.Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_PURCHASE_", pClsProperty.Rate_Purchase, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_PURCHASE_", pClsProperty.Amount_Purchase, DbType.Double, ParameterDirection.Input);
            Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BALANCE_QUANTITY_", pClsProperty.Balance_Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_APPROVE_", pClsProperty.IS_Approve, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_HOLD_", pClsProperty.IS_Approve, DbType.Int32, ParameterDirection.Input);
            
            Request.AddParams("VAT_PER_", pClsProperty.Vat_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ADD_VAT_PER_", pClsProperty.Add_Vat_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("DISC_PER_", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ADD_AMOUNT_", pClsProperty.Add_Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParams("LESS_AMOUNT_", pClsProperty.Less_Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParams("NET_AMOUNT_DOLLAR_", pClsProperty.Net_Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("NET_AMOUNT_LOCAL_", pClsProperty.Net_Amount_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("NET_AMOUNT_PURCHASE_", pClsProperty.Net_Amount_Purchase, DbType.Double, ParameterDirection.Input);
           
            //Request.CommandText = BLL.TPV.SProc.Item_Purchase_Detail_Save;
            //Request.CommandType = CommandType.StoredProcedure;
            //return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return Request;
           
        }

        public int UpdateDataByPK(Item_Purchase_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            int IntRes = 0;
            Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("BOX_NO_", pClsProperty.Box_No, DbType.String, ParameterDirection.Input);
            //Request.AddParams("PACKET_ID_", pClsProperty.Packet_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUBQUALITY_CODE_", pClsProperty.SubQuality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SIGHT_TYPE_CODE_", pClsProperty.Sight_Type_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("QUANTITY_", pClsProperty.Quantity, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("CARAT_", pClsProperty.Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_PURCHASE_", pClsProperty.Rate_Purchase, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_PURCHASE_", pClsProperty.Amount_Purchase, DbType.Double, ParameterDirection.Input);
            Request.AddParams("BALANCE_QUANTITY_", pClsProperty.Balance_Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
            Request.CommandText = "Purchase_Detail_UpdateByPK";
            Request.CommandType = CommandType.StoredProcedure;

            IntRes =  Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }

        public Boolean ISExistsInvoiceNoExists(string pStrFinYear, int pIntInvoiceNo)
        {
            Request Request = new Request();
           
                Request.CommandText = "Item_Purchase_Master_ISExist";
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
                Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);
                string StrRes = Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                if (Val.Val(StrRes) == 0)
                {
                    return false;
                } 

            return true;
        }

        public Boolean ISExistsInvoiceNoIN_B_Part(string pStrFinYear, int pIntInvoiceNo)
        {
            Request Request = new Request();
            Request.CommandText = "Item_Purchase_Master_ISExist_B";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);
            string StrRes = Ope.ExecuteScalar(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderName, Request);
            if (Val.Val(StrRes) == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Delete IMPORT

        public int ItemDeleteMaster(Item_Purchase_MasterProperty pClsProperty)
        {

            Request Request = new Request();
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("ITEM_TAX_CODE_", pClsProperty.Item_Tax_Code, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Item_Purchase_Master_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region Get Data

        public void GetData()
        {
            Request Request = new Request();
            Request.CommandText = "Item_Purchase_Detail_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            Request.CommandText = "Item_Purchase_Tax_Dtl_GetData" ;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabTax, Request, "");

        }

        public void GetDataMaster()
        {
            Request Request = new Request();
            Request.CommandText = "Item_Purchase_Master_GetData";
            
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTable, Request, "");
        }

        public void GetMasterData(string pStrFromDate, string pStrToDate,int pIntInvoiceNo =0)
        {
           
            Request Request = new Request();
            Request.CommandText = "Item_Purchase_Master_GetData";
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableName, Request, "");
            
        }

        public DataTable GetMasterDataForSearch(string pStrFromDate, string pStrToDate, int pIntInvoiceNo)
        {
            GetMasterData(pStrFromDate, pStrToDate, pIntInvoiceNo);

            return DS.Tables[TableName];
        }

        public DataRow GetPurchaseMasterByPK(string pStrFinYear, int pIntInvoiceNo)
        {
            Request Request = new Request();
            Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);
            
            Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_Master_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public void GetPurchaseDetail(string pStrFinYear, int pIntInvoiceNo = 0, string pStrLotIDs = null)
        {
            Request Request = new Request();

            Request.AddParams("LOT_ID_", pStrLotIDs, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);


            Request.CommandText = "Item_Purchase_Detail_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameDetail, Request, "");

        }

        public void GetItemTaxDetail(string pStrFinYear, int pIntInvoiceNo = 0)
        {
            Request Request = new Request();
            Request.AddParams("INVOICE_NO_", pIntInvoiceNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ITEM_TAX_CODE_", , DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Item_Purchase_Tax_Dtl_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabTax, Request, "");
        }

        #endregion

        #region Other Function

        public int FindRecordCode(int pIntCode)
        {
            Validation Val = new Validation();
            int IntRes = Val.ToInt(Val.SearchText(DS.Tables[TableName], "Invoice_No", pIntCode.ToString(), "Record_Code"));
            Val = null;
            return IntRes;
        }

        #region Other Function

        public int Save(Item_Purchase_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            //Request.AddParams("@ItemPurchaseMasterID", pClsProperty.ItemPurchaseMasterID, DbType.Decimal, ParameterDirection.Input);
            //Request.AddParams("@ReferenceNo", pClsProperty.ReferenceNo, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@ReceivedDate", pClsProperty.ReceivedDate, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@FinancialYear", pClsProperty.FinancialYear, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FromParty1", pClsProperty.FromParty1, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FromParty2", pClsProperty.FromParty2, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@PartyInvoiceDate", pClsProperty.PartyInvoiceDate, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ToParty1", pClsProperty.ToParty1, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ToParty2", pClsProperty.ToParty2, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ChallanNo", pClsProperty.ChallanNo, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@Payment", pClsProperty.Payment, DbType.Decimal, ParameterDirection.Input);
            //Request.AddParams("@Terms", pClsProperty.Terms, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TermsDate", (object)pClsProperty.TermsDate ?? DBNull.Value, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@CostCenter", pClsProperty.CostCenter, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@SubCostCenter", pClsProperty.SubCostCenter, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TotalItems", pClsProperty.TotalItems, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@GrossAmount", pClsProperty.GrossAmount, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTab = new DataTable();
            //return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            if (DTab.Rows.Count > 0)
                return Convert.ToInt32(DTab.Rows[0][0]);
            else
                return -1;
        }

        public DataTable GetData(int ReferenceNo)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@ReferenceNo", ReferenceNo, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        #endregion

       
        #endregion

       
    }
}
