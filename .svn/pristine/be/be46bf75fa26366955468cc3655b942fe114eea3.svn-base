using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class ItemCategoryMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
    
        #region Other Function

        public int Save(Item_Category_MasterProperty  pClsProperty)
        {           
            Request Request = new Request();

            Request.AddParams("@ITEM_CATEGORY_CODE", pClsProperty.Item_Category_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ITEM_CATEGORY_NAME", pClsProperty.Item_Category_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_CONSUMABLE", pClsProperty.Is_Consumable, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_REPAIRABLE", pClsProperty.Is_repairable, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Cat_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Cat_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;           
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Item_Cat_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string ItemCategoryName, Int64 ItemCategoryCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "ITEM_CATEGORY_MASTER", "ITEM_CATEGORY_NAME", "AND ITEM_CATEGORY_NAME = '" + ItemCategoryName + "' AND NOT ITEM_CATEGORY_CODE =" + ItemCategoryCode));
        }   

        #endregion
    }
}
