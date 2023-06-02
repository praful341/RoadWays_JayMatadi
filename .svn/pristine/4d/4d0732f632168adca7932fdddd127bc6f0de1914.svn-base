using BLL.PropertyClasses.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class ItemPurchase
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

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

        public DataTable GetData(int ItemPurchaseMasterID)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@ItemPurchaseMasterID", ItemPurchaseMasterID, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Purchase_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        #endregion
    }
}
