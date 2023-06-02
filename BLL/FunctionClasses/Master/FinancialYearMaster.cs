using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class FinancialYearMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Financial_Year_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@FIN_YEAR_CODE", pClsProperty.Fin_Year_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@START_DATE", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@END_DATE", pClsProperty.End_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@SHORT_NAME", pClsProperty.Short_Name, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FINANCIAL_YEAR", pClsProperty.Financial_year, DbType.String, ParameterDirection.Input);
            Request.AddParams("@START_YEARMONTH", pClsProperty.Start_YearMonth, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@END_YEARMONTH", pClsProperty.End_YearMonth, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Financial_Year_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Financial_Year_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Financial_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }   

        #endregion
    }
}
