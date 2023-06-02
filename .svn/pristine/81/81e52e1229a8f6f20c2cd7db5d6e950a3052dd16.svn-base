using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class BranchMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        
        #region Other Function

        public int Save(Branch_MasterProperty pClsProperty) // Add : Narendra : 03-Sep-2014
        {
            Request Request = new Request();

            Request.AddParams("@Branch_Code", pClsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Branch_Name", pClsProperty.Branch_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Company_code", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Location_Code", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Address", pClsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Country_Code", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@State_Code", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@City_Code", pClsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ZIPCode", pClsProperty.Zip_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PHONE", pClsProperty.Phone1, DbType.String, ParameterDirection.Input);
            Request.AddParams("@STNO", pClsProperty.STNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CSTNO", pClsProperty.CSTNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EPCGNO", pClsProperty.EPCGNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@WARDNO", pClsProperty.WARDNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TINNO", pClsProperty.TINNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ESICNO", pClsProperty.ESICNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PANNO", pClsProperty.PANNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@VATNO", pClsProperty.VATNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PFNO", pClsProperty.PFNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EXCISENO", pClsProperty.EXCISENO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TANNO", pClsProperty.TANNO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LICENCE_NO", pClsProperty.Licence_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PT_NO", pClsProperty.EPT_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CPT_NO", pClsProperty.CPT_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TDS_NO", pClsProperty.TDS_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REG_NO", pClsProperty.Registration_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IT_PA_NO", pClsProperty.IT_PA_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ESIC_COVERAGE_DATE", pClsProperty.ESIC_Coverage_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ESIC_LOCAL_OFFICE", pClsProperty.ESIC_Local_Office, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PF_GROUP_CODE", pClsProperty.PF_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CIN_NO", pClsProperty.CinNo, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Branch_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);                     
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Branch_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Serch()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Branch_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string BranchName, Int64 BranchCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "BRANCH_MASTER", "BRANCH_NAME", "AND BRANCH_NAME = '" + BranchName + "' AND NOT BRANCH_CODE =" + BranchCode));
        }   

        #endregion
    }
}
