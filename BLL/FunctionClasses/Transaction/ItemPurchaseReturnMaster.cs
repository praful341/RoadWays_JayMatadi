using BLL.PropertyClasses.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class ItemPurchaseReturnMaster
    {

        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Item_Purchase_ReturnMaster pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ItemPurchaseReturnMasterID", pClsProperty.ItemPurchaseReturnMasterID, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@ReferenceNo", pClsProperty.ReferenceNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ReceivedDate", pClsProperty.ReceivedDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FinancialYear", pClsProperty.FinancialYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FromParty1", pClsProperty.FromParty1, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FromParty2", pClsProperty.FromParty2, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PartyInvoiceDate", pClsProperty.PartyInvoiceDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ToParty1", pClsProperty.ToParty1, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ToParty2", pClsProperty.ToParty2, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ChallanNo", pClsProperty.ChallanNo, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Payment", pClsProperty.Payment, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Terms", pClsProperty.Terms, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TermsDate", (object)pClsProperty.TermsDate ?? DBNull.Value, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@CostCenter", pClsProperty.CostCenter, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SubCostCenter", pClsProperty.SubCostCenter, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TotalItems", pClsProperty.TotalItems, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Quantity", pClsProperty.Quantity, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@GrossAmount", pClsProperty.GrossAmount, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_ReturnMaster_Save";
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

            Request.CommandText = "Item_Purchase_Return_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        public Boolean GetDataByItemName(string ItemName)
        {
            Boolean isValid = false;
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@ItemName", ItemName, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_SearchByItem";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            if (DTab.Rows.Count > 0 && Convert.ToDecimal(DTab.Rows[0][0].ToString()) > 0)
                isValid = true;

            return isValid;
        }

        #endregion


    }
}
