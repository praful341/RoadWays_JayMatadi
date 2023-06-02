using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Utility;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Utility
{
    public class UserAuthentication
    {
        InterfaceLayer Ope = new InterfaceLayer();
        User_MasterProperty objEmp = new User_MasterProperty();
        
        #region Property Settings

        private DataTable _DTab = new DataTable("User_Authentication");

        public DataTable  DTab 
        { 
            get{return _DTab;}
            set { _DTab= value;}
        }

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        public string TableForm
        {
            get { return "Form_Master";}
        }

        public string TableReport
        {
            get { return "New_Report_Master"; }
        }

        private DataTable _DTDATA = new DataTable("REPORT_AUTHENTICATION");

        public DataTable DTDATA
        {
            get { return _DTDATA; }
            set { _DTDATA = value; }
        }

        public string TableName
        {
            get { return "Employee_Master"; }
        }

        
        //private DataTable _DTab1 = new DataTable(BLL.TPV.Table.Employee_Master);

        //public DataTable DTab1
        //{
        //    get { return _DTab1; }
        //    set { _DTab1 = value; }
        //}
      

        #endregion

        #region Other Function

        public int Save(UserAuthenticationProperty pClsProperty)
        {

            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FORM_CODE_", pClsProperty.Form_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("VIW_", pClsProperty.Viw, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("INS_", pClsProperty.Ins, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("UPD_", pClsProperty.Upd, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEL_", pClsProperty.Del, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PRN_", pClsProperty.Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PASS_", pClsProperty.Pass, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMAIL_", pClsProperty.Email, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            //Request.AddParams("COMPANY_CODE_", pClsProperty.Compny_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("LOCATION_CODE_", pClsProperty.Location_code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = "UserAuth_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }


        public int SaveReport(UserAuthenticationProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("VIW_", pClsProperty.Viw, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PRN_", pClsProperty.Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMAIL_", pClsProperty.Email, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EXP_", pClsProperty.Export, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PASS_", pClsProperty.Pass, DbType.String, ParameterDirection.Input);

            //Request.AddParams("COMPANY_CODE_", pClsProperty.Compny_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("LOCATION_CODE_", pClsProperty.Location_code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = "REPORT_AUTHENTICATION_SAVE";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public void GetGroup()
        {
            Request Request = new Request();
            Request.CommandText = "Form_Group_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS,TableForm, Request, "");
        }

        public void GetReportGroup()
        {
            Request Request = new Request();
            Request.CommandText = "REPORT_GROUP_GETDATA";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableReport, Request, "");
        }

        public DataTable GetDataForSearch()
        {
            GetGroup();
            return DS.Tables[TableForm];
        }

        public DataTable GetdataForReportSearch()
        {
            GetReportGroup();
            return DS.Tables[TableReport];
        }

        public DataTable GetFormDetail(string PStrFornGroup, int mStrEmpCode)
        {
            Request Request = new Request();
            DataTable _DTable = new DataTable(); // ->  Add : Narendra : 11-07-2014
            Request.AddParams("FORM_GROUP_NAME_", PStrFornGroup, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", mStrEmpCode, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "UserAuth_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, _DTable, Request, "");
            _DTab = _DTable;
            //return _DTab;
            return _DTable;
        }


        public DataTable GetRportDetail(string PStrReportGroup, int mStrEmpCode)
        {
            Request Request = new Request();

            Request.AddParams("REPORT_GROUP_NAME_", PStrReportGroup, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", mStrEmpCode, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "REPORT_AUTHENTICATION_GETDATA";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTDATA, Request, "");

            return DTDATA;
        }

        public DataTable GetUser()
        {
            Request Request = new Request();

            Request.CommandText = "User_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS,TableName, Request, "");

            return DS.Tables[TableName];
        }

        #endregion



       
    }

}
