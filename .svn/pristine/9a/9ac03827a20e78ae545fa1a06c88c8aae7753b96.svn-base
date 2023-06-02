using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class ItemHSNMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(ItemHSN_MasterProperty pClsProperty) 
        {
            Request Request = new Request();

            Request.AddParams("@HSN_ID", pClsProperty.HSN_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@HSN_CODE", pClsProperty.HSN_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@HSN_NAME", pClsProperty.HSN_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IGST_DATE", pClsProperty.IGST_DATE, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@IGST_RATE", pClsProperty.IGST_RATE, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SGST_DATE", pClsProperty.SGST_DATE, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@SGST_RATE", pClsProperty.SGST_RATE, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CGST_DATE", pClsProperty.CGST_DATE, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@CGST_RATE", pClsProperty.CGST_RATE, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "HSN_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "HSN_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_UnitType()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Unit_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "HSN_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string HSNCode, Int64 HSNID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_HSN_Master", "HSN_CODE", "AND HSN_CODE = '" + HSNCode + "' AND NOT HSN_ID =" + HSNID));
        }  

        #endregion

    }
}

