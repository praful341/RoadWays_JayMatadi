using BLL.FunctionClasses.Master;
using System.Data;
using DLL;

namespace BLL.FunctionClasses.Utility
{
    public class Login
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function
        
        public int CheckLogin(string UserName, string Password)
        {
            DataRow Drow;
            Request Request = new Request();
            Request.AddParams("@UserName", UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Password", Password, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Check_Login";
            Request.CommandType = CommandType.StoredProcedure;
            Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (Drow == null)
            {
                return -1;
            }
            else
            {
                GlobalDec.gEmployeeProperty.User_Code = Val.ToInt64(Drow["USER_CODE"]);
                GlobalDec.gEmployeeProperty.User_Name = Val.ToString(Drow["USER_NAME"]);
                GlobalDec.gEmployeeProperty.Company_Code = Val.ToInt64(Drow["COMPANY_CODE"]);
                GlobalDec.gEmployeeProperty.Company_Name = Val.ToString(Drow["COMPANY_NAME"]);
                GlobalDec.gEmployeeProperty.Branch_Code = Val.ToInt64(Drow["BRANCH_CODE"]);
                GlobalDec.gEmployeeProperty.Branch_Name = Val.ToString(Drow["BRANCH_NAME"]);
                GlobalDec.gEmployeeProperty.Address = Val.ToString(Drow["ADDRESS"]);
                GlobalDec.gEmployeeProperty.Location_Code = Val.ToInt64(Drow["LOCATION_CODE"]);
                GlobalDec.gEmployeeProperty.Location_Name = Val.ToString(Drow["LOCATION_NAME"]);
                GlobalDec.gEmployeeProperty.DOJ = Val.ToString(Drow["DOJ"]);
                GlobalDec.gEmployeeProperty.EMail = Val.ToString(Drow["EMAIL"]);
                GlobalDec.gEmployeeProperty.ID_Card_No = Val.ToString(Drow["ID_CARD_NO"]);
                GlobalDec.gEmployeeProperty.UserName = Val.ToString(Drow["USERNAME"]);
                GlobalDec.gEmployeeProperty.PassWord = Val.ToString(Drow["PASSWORD"]);
                GlobalDec.gEmployeeProperty.Phone_No = Val.ToString(Drow["PHONE_NO"]);
                GlobalDec.gEmployeeProperty.State_Code = Val.ToInt64(Drow["BRANCH_STATE_CODE"]);
                EmployeeMaster ObjEmp = new EmployeeMaster();

                ObjEmp = null;

                GlobalDec.gStrUserName = GlobalDec.gEmployeeProperty.UserName;

                return 1;
            }
        }
    }
        #endregion
}


