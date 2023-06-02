using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class StateMaster
    {

        InterfaceLayer Ope = new InterfaceLayer();

        //#region Property Settings

        //private DataTable _DTab = new DataTable(BLL.TPV.Table.State_Master);

        //public DataTable DTab
        //{
        //    get { return _DTab; }
        //    set { _DTab = value; }
        //}

        //#endregion

        #region Other Function

        //public int FindNewID()
        //{
        //    return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.State_Master, "MAX(STATE_CODE)", "");
        //}

        public int Save(State_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@State_code", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@State_Name", pClsProperty.State_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Country_Code", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
           
            Request.CommandText = "State_Master_Save"; ;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "State_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "State_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string StateName, Int64 StateCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "STATE_MASTER", "STATE_NAME", "AND STATE_NAME = '" + StateName + "' AND NOT STATE_CODE =" + StateCode));
        }   

        #endregion

    }
}
