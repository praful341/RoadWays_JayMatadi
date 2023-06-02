using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System.Collections;

namespace BLL.FunctionClasses.Master
{
    public class EmployeeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Params Region

        public int Save(User_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@USER_CODE", pClsProperty.User_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@USER_NAME", pClsProperty.User_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", pClsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ID_CARD_NO", pClsProperty.ID_Card_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DOJ", pClsProperty.DOJ, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ADDRESS", pClsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COUNTRY_CODE", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@STATE_CODE", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CITY_Code", pClsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PINCODE", pClsProperty.Pincode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DOB", pClsProperty.DOB, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@GENDER", pClsProperty.Gender, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BLOOD_GROUP", pClsProperty.Blood_Group, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MARITILE_STATUS", pClsProperty.Maritile_Status, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ANNIVERSARTY", pClsProperty.Anniversary, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@OCCUPATION", pClsProperty.Occupation, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EMAIL", pClsProperty.EMail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@VEHICLE_NO", pClsProperty.Vehicle_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IDENTITY_MARK", pClsProperty.Identity_Mark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@NATIONALITY", pClsProperty.Nationality, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RELIGION", pClsProperty.Religion, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CAST_SUBCAST", pClsProperty.Cast_SubCast, DbType.String, ParameterDirection.Input);
            Request.AddParams("@HOBBIES", pClsProperty.Hobbies, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LANGUAGE_KNOWN", pClsProperty.Language_Known, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PASSPORT_NO", pClsProperty.Passport_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PHONE_NO", pClsProperty.Phone_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PAN_NO", pClsProperty.PAN_NO, DbType.String, ParameterDirection.Input);
            Request.AddParams("@USERNAME", pClsProperty.UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PASSWORD", pClsProperty.PassWord, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_PHOTO", "", DbType.String, ParameterDirection.Input);
            Request.AddParams("@OFF_EXT_NO", pClsProperty.OfficeExtNo, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SKYPE_ID", pClsProperty.SkypeId, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DRIVING_LICENCE_NO", pClsProperty.Driving_Lic_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@AADHAR_CARD_NO", pClsProperty.Adhar_Card_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ELECTION_CARD_NO", pClsProperty.Election_Card_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@USER_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input); 

            Request.CommandText = "User_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);      
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "User_Master_GetFullDetail";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int SaveThemes(string Theme_Name)
        {
            Request Request = new Request();
            Request.AddParams("@User_Code", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32);
            Request.AddParams("@Theme_Name", Theme_Name, DbType.String);
            Request.AddParams("@Active", 1, DbType.Int32);
            Request.AddParams("@Location_Code", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32);

            Request.CommandText = "STORE_THEME_MASTER_SAVE";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable Get_Theme_Master()
        {
            Request Request = new Request();
            DataTable DTable = new DataTable();
            Request.AddParams("@User_Code", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32);
            Request.AddParams("@Location_Code", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32);

            Request.CommandText = "Get_Theme_Master";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTable, Request, "");

            return DTable;
        }

        #endregion
    }
}

