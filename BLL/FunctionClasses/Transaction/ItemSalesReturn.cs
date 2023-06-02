using BLL.PropertyClasses.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class ItemSalesReturn
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Item_Sales_Return pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ItemSalesReturnID", pClsProperty.ItemSalesReturnID, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@ItemSalesReturnMasterID", pClsProperty.ItemSalesReturnMasterID, DbType.Decimal, ParameterDirection.Input);
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

            Request.CommandText = "Item_Sales_Return_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        public DataTable GetData(int ItemSalesReturnMasterID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@ItemSalesReturnMasterID", ItemSalesReturnMasterID, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Sales_Return_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        #endregion
    }
}
