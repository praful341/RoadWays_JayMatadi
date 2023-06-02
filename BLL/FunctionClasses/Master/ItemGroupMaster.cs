using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;

namespace BLL.FunctionClasses.Master
{
    public class ItemGroupMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Item_Group_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ITEM_GROUP_CODE", pClsProperty.Item_Group_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ITEM_GROUP_NAME", pClsProperty.Item_Group_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Group_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Group_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Item_Group_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string ItemGroupName, Int64 ItemGroupCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "ITEM_GROUP_MASTER", "ITEM_GROUP_NAME", "AND ITEM_GROUP_NAME = '" + ItemGroupName + "' AND NOT ITEM_GROUP_CODE =" + ItemGroupCode));
        }

        #endregion
    }

}
