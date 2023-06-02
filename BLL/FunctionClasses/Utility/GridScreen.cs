using DLL;
using System.Data;

namespace BLL.FunctionClasses.Utility
{
    public class GridScreen
    {
        InterfaceLayer Ope = new InterfaceLayer();
        public DataTable Get_GridScreenGetData(int GridID) 
        {
            DataTable DTabCarat = new DataTable();
            Request Request = new Request();
            Request.CommandText = "SYS_GRID_SCREEN_GETDATA";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("SYS_GRID_SCREEN_MASTER_ID_",GridID, DbType.Date, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabCarat, Request, "");
            return DTabCarat;
        }
    }
}
