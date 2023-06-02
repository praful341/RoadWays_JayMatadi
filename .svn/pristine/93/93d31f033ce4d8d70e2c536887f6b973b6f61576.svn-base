using BLL.PropertyClasses.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class ItemSalesReturnMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Item_Sales_Return_Master pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ItemSalesReturnMasterID", pClsProperty.ItemSalesReturnMasterID, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@ReferenceNo", pClsProperty.ReferenceNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@SalesDate", pClsProperty.SalesDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FinancialYear", pClsProperty.FinancialYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FromCompany", pClsProperty.FromCompany, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ToCompany", pClsProperty.ToCompany, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FromBranch", pClsProperty.FromBranch, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ToBranch", pClsProperty.ToBranch, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FromLocation", pClsProperty.FromLocation, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ToLocation", pClsProperty.ToLocation, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TotalQuantity", pClsProperty.TotalQuantity, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@TotalAmount", pClsProperty.TotalAmount, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Item_Sales_Return_Master_Save";
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

            Request.CommandText = "Item_Sales_Return_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        #endregion
    }
}
