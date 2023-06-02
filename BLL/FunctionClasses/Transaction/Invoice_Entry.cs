using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Collections;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class Invoice_Entry
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function
        public int FindNewTransactionID()
        {
            int IntRes = 0;
            //if (Form_Type == "P")
            //{
            IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Transaction_Master", "isnull(MAX(TransactionMasterID),0)", "");
            //}
            //else if (Form_Type == "PR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Purchase_ReturnMaster", "isnull(MAX(ItemPurchaseRtnMasterID),0)", "");
            //}
            //else if (Form_Type == "S")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Master", "isnull(MAX(ItemSaleMasterID),0)", "");
            //}
            //else if (Form_Type == "SR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Return_Master", "isnull(MAX(ItemSaleReturnMasterID),0)", "");
            //}
            return IntRes;
        }

        public int FindNewID(string Form_Type)
        {
            int IntRes = 0;
            //if (Form_Type == "P")
            //{
            IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Bill_Transaction", "isnull(MAX(TransactionID),0)", "");
            //}
            //else if (Form_Type == "PR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Purchase_ReturnMaster", "isnull(MAX(ItemPurchaseRtnMasterID),0)", "");
            //}
            //else if (Form_Type == "S")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Master", "isnull(MAX(ItemSaleMasterID),0)", "");
            //}
            //else if (Form_Type == "SR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Return_Master", "isnull(MAX(ItemSaleReturnMasterID),0)", "");
            //}
            return IntRes;
        }
        public int FindNewRoadWays_TranID(string Form_Type)
        {
            int IntRes = 0;
            //if (Form_Type == "P")
            //{
            IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "RoadWays_Bill_Transaction", "isnull(MAX(transaction_id),0)", "");
            //}
            //else if (Form_Type == "PR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Purchase_ReturnMaster", "isnull(MAX(ItemPurchaseRtnMasterID),0)", "");
            //}
            //else if (Form_Type == "S")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Master", "isnull(MAX(ItemSaleMasterID),0)", "");
            //}
            //else if (Form_Type == "SR")
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Return_Master", "isnull(MAX(ItemSaleReturnMasterID),0)", "");
            //}
            return IntRes;
        }

        public string GEtMaximumID(string StrIDType)
        {
            DataTable DtPreView = new DataTable();
            string RetMaxID = string.Empty;

            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = "SL_MAXIMUM_ID_GETDATA";
            Request.AddParams("@ID_NAME", StrIDType, DbType.String);
            Request.AddParams("@OUT_SRNO", "", DbType.String, ParameterDirection.Output);

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    RetMaxID = Convert.ToString(DTAB.Rows[0][0]);
                }
            }

            return RetMaxID;
        }

        public string FindNewInvoiceNo(string Form_Type)
        {
            string IntRes = string.Empty;
            if (Form_Type == "PR")
            {
                IntRes = Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Purchase_ReturnMaster", "isnull('PR' + CAST(SUBSTRING(max(Inovice_No), 3, 3) +1 AS varchar(50)),'PR1')", "AND Company_Code = '" + GlobalDec.gEmployeeProperty.Company_Code + "' AND Location_Code = '" + GlobalDec.gEmployeeProperty.Location_Code + "' AND Branch_Code = '" + GlobalDec.gEmployeeProperty.Branch_Code + "' AND FinancialYear = '" + GlobalDec.gEmployeeProperty.gFinancialYear + "' ");
            }
            else if (Form_Type == "S")
            {
                IntRes = Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Sales_Master", "isnull('S' + CAST(SUBSTRING(max(Inovice_No), 2, 1) +1 AS varchar(50)),'S1')", "AND Company_Code = '" + GlobalDec.gEmployeeProperty.Company_Code + "' AND Location_Code = '" + GlobalDec.gEmployeeProperty.Location_Code + "' AND Branch_Code = '" + GlobalDec.gEmployeeProperty.Branch_Code + "' AND FinancialYear = '" + GlobalDec.gEmployeeProperty.gFinancialYear + "' ");
            }
            return IntRes;
        }

        public int Save(Item_Purchase pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ItemPurchaseID", pClsProperty.ItemPurchaseID, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@ItemPurchaseMasterID", pClsProperty.ItemPurchaseMasterID, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@ItemName", pClsProperty.ItemName, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Unit", pClsProperty.Unit, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Price", pClsProperty.Price, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Amount", pClsProperty.Amount, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Vat", pClsProperty.Vat, DbType.String, ParameterDirection.Input);
            Request.AddParams("@AddVat", pClsProperty.AddVat, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Discount", pClsProperty.Discount, DbType.String, ParameterDirection.Input);
            Request.AddParams("@AddAmount", pClsProperty.AddAmount, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LessAmount", pClsProperty.LessAmount, DbType.String, ParameterDirection.Input);
            Request.AddParams("@NetAmount", pClsProperty.NetAmount, DbType.Decimal, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public Invoice_EntryProperty SaveInvoiceEntryMaster(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@TransactionMasterID", pClsProperty.TransactionMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Party_Code", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Party_Code", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Invoice_Date", pClsProperty.Invoice_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Inovice_No", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_City_Code", pClsProperty.From_Destination, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_City_Code", pClsProperty.To_Destination, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Terms", pClsProperty.Payment_Days, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Challan_No", pClsProperty.Challan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Payment_Type", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Term_Date", pClsProperty.Payment_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Own_Truck", pClsProperty.Own_Truck, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@My_Commission", pClsProperty.My_Commission, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Advance", pClsProperty.Advance, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Truck_No", pClsProperty.Truck_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Diesel_Expence", pClsProperty.Diesel_Expence, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@NetAmount", pClsProperty.Net_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Company_Code", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TAmount", pClsProperty.T_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Labour_Amt", pClsProperty.Labour_Amt, DbType.Decimal, ParameterDirection.Input);

            Request.CommandText = "Transaction_Master_SAVE";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);

            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.TransactionMasterID = Convert.ToInt64(DTAB.Rows[0][0]);
                }
            }
            else
            {
                pClsProperty.TransactionMasterID = 0;
            }
            return pClsProperty;

        }

        public Int64 SaveBillTransaction(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            int IntRes = 0;
            Request.AddParams("@TransactionID", pClsProperty.TransactionMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Transaction_Date", pClsProperty.Transaction_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Inovice_No", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_Party_Name", pClsProperty.From_Party_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Party_Name", pClsProperty.To_Party_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_City_Code", pClsProperty.From_Destination, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_City_Code", pClsProperty.To_Destination, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Truck_ID", pClsProperty.Truck_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LR_NO", pClsProperty.LR_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Item_Code", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Description", pClsProperty.Description, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_Party_GSTNo", pClsProperty.From_Party_GSTNo, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Party_GSTNo", pClsProperty.To_Party_GSTNo, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Qty", pClsProperty.Quantity, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Weight", pClsProperty.Weight, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Amount", pClsProperty.Amount, DbType.Decimal, ParameterDirection.Input);

            Request.CommandText = "Roadways_Bill_Transaction_SAVE";
            Request.CommandType = CommandType.StoredProcedure;

            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            return IntRes;
        }

        public Request SaveItemPurchaseDetail(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@TransactionDetailID", pClsProperty.TransactionDetailID, DbType.Int64);
            Request.AddParams("@TransactionMasterID", pClsProperty.TransactionMasterID, DbType.Int64);
            Request.AddParams("@Unit_ID", pClsProperty.Unit_ID, DbType.Int64);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Decimal);
            Request.AddParams("@Weight", pClsProperty.Weight, DbType.Decimal);
            Request.AddParams("@Rate", pClsProperty.Rate_Dollar, DbType.Decimal);
            Request.AddParams("@SGST_Per", pClsProperty.SGST, DbType.Decimal);
            Request.AddParams("@CGST_Per", pClsProperty.CGST, DbType.Decimal);
            Request.AddParams("@IGST_Per", pClsProperty.IGST, DbType.Decimal);
            Request.AddParams("@NetAmount", pClsProperty.Net_Amt, DbType.Decimal);

            return Request;
        }

        public Request SaveItemPurchaseReturnDetail(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ItemPurchaseReturnDtlID", pClsProperty.ItemPurchaseReturnDtlID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ItemPurchaseRtnMasterID", pClsProperty.ItemPurchaseRtnMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Item_Code", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@HSN_ID", pClsProperty.HSN_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Unit_Name", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Rate", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Gross_Amt", pClsProperty.Gross_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Discount", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Rate", pClsProperty.SGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Amt", pClsProperty.SGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Rate", pClsProperty.CGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Amt", pClsProperty.CGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Rate", pClsProperty.IGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Amt", pClsProperty.IGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@NetAmount", pClsProperty.Net_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Remarks", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            return Request;
        }

        public Request SaveItemSalesDetail(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ItemSaleDetailID", pClsProperty.ItemSaleDetailID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ItemSaleMasterID", pClsProperty.ItemSaleMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Item_Code", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@HSN_ID", pClsProperty.HSN_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Unit_Name", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Rate", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Gross_Amt", pClsProperty.Gross_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Discount", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Rate", pClsProperty.SGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Amt", pClsProperty.SGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Rate", pClsProperty.CGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Amt", pClsProperty.CGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Rate", pClsProperty.IGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Amt", pClsProperty.IGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@NetAmount", pClsProperty.Net_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Remarks", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            return Request;
        }

        public Request SaveItemSalesReturnDetail(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ItemSaleReturnDtlID", pClsProperty.ItemSaleReturnDtlID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ItemSaleReturnMasterID", pClsProperty.ItemSaleReturnMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Item_Code", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@HSN_ID", pClsProperty.HSN_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Unit_Name", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Rate", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Gross_Amt", pClsProperty.Gross_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Discount", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Rate", pClsProperty.SGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_Amt", pClsProperty.SGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Rate", pClsProperty.CGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_Amt", pClsProperty.CGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Rate", pClsProperty.IGST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IGST_Amt", pClsProperty.IGST_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@NetAmount", pClsProperty.Net_Amt, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Remarks", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            return Request;
        }


        public int SavePurchaseDetail(ArrayList AL)
        {
            int IntRes = 0;
            Request Request = new Request();

            foreach (Invoice_EntryProperty Obj in AL)
            {
                Request = SaveItemPurchaseDetail(Obj);
                Request.CommandText = "Transaction_Detail_SAVE";
                Request.CommandType = CommandType.StoredProcedure;
                IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            }

            return IntRes;
        }

        public DataTable GetTransactionPrintData(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@INVOICE_DATE", Property.Invoice_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@INVOICE_NO", Property.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TRN_ID", Property.Trn_Id, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TRN_TYPE", Property.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "RPT_BILL_PRINT";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }
        public DataTable GetTransactionPrintRoadWaysData(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@INVOICE_DATE", Property.Invoice_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@INVOICE_NO", Property.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TRN_ID", Property.Trn_Id, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TRN_TYPE", Property.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "RPT_BILL_PRINT_NEW";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable GetPrintData(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@INVOICE_DATE", Property.Invoice_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@INVOICE_NO", Property.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TRN_ID", Property.Trn_Id, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TRN_TYPE", Property.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "invoice_Print_Data";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable GetData(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@From_Date", Property.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Date", Property.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Transaction_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_New(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Invoice_No", Property.Invoice_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Transaction_Master_GetDataNew";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable Bill_Transaction_GetData(Invoice_EntryProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@From_Date", Property.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Date", Property.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Roadways_Bill_Transaction_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetPurchaseDetail(Int64 pIntItemCode = 0)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Master_ID", pIntItemCode, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Transaction_Detail_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int DeleteInvoiceEntryMaster(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@TransactionMasterID", pClsProperty.TransactionMasterID, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Transaction_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public int DeleteBillTransaction(Invoice_EntryProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@TransactionID", pClsProperty.TransactionMasterID, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Bill_Transaction_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int DeletePurchaseDetail(Invoice_EntryProperty pClsProperty)
        {
            int IntRes = 0;
            Request Request = new Request();

            Request.AddParams("@TransactionMasterID", pClsProperty.ItemPurchaseMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TransactionDetailID", pClsProperty.ItemPurchaseDetailID, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Transaction_Detail_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            return IntRes;
        }

        #endregion
    }
}
