using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLL;
using BLL.PropertyClasses.Utility;
namespace BLL.FunctionClasses.Utility
{
    public class Settings
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Operation

        public Request AddSettingsParams(Settings_Property pClsProperty) // Add By Haresh On 01-08-2016
        {
            Request Request = new Request();

            Request.AddParams("VERSION_", pClsProperty.Version, DbType.String, ParameterDirection.Input);
            Request.AddParams("EXE_COPY_PATH_", pClsProperty.Exe_Copy_Path, DbType.String, ParameterDirection.Input);
            Request.AddParams("SENDER_EMAIL_", pClsProperty.Sender_Email, DbType.String, ParameterDirection.Input);
            Request.AddParams("SENDER_PASSWORD_", pClsProperty.Sender_Password, DbType.String, ParameterDirection.Input);
            Request.AddParams("SMTPSERVER_", pClsProperty.SMTP_Server, DbType.String, ParameterDirection.Input);
            Request.AddParams("SMTPPORT_", pClsProperty.SMTP_Port, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("RAPNET_USERNAME_", pClsProperty.RapNet_UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("RAPNET_PASSWORD_", pClsProperty.RapNet_Password, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_GRACE_APPLICABLE_", pClsProperty.IS_Grace_Applicable, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_ENABLE_SSL_", pClsProperty.IS_Enable_SSL, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ADVANCE_SALARY_LIMIT_PER_", pClsProperty.Advance_Salary_Limit_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ADVANCE_DEDUCTION_LIMIT_PER_", pClsProperty.Advance_Deduction_Limit_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ATTENDANCE_UPDATE_DUE_DAYS_", pClsProperty.Attendance_Update_Due_Days, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ATTENDANCE_ABSENT_LIMIT_", pClsProperty.Attendance_Absent_Limit, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MINOR_AGE_LIMIT_", pClsProperty.Minor_Age_Limit, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("Allow_Developer_ENTRY_", pClsProperty.Allow_Developer_Entry, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ALLOW_EMAIL_SEND_", pClsProperty.Allow_Email_Send, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ALLOW_SIEVE_PCS_VALIDATION_", pClsProperty.ALLOW_SIEVE_PCS_VALIDATION, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MINIMUM_WORKING_HOURS_", pClsProperty.Minimum_Working_Hours, DbType.Double, ParameterDirection.Input);
            Request.AddParams("IS_PAYHEAD_DYNAMIC_", pClsProperty.IS_PAYHEAD_DYNAMIC, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IDLE_MODE_EXE_CLOSE_", pClsProperty.IDLE_MODE_EXE_CLOSE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_BARCODE_PRINT_", pClsProperty.Is_Barcode_Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DOLLAR_RATE_", pClsProperty.DOLLAR_RATE, DbType.Double, ParameterDirection.Input);
            Request.AddParams("PROCESS_COST_", pClsProperty.PROCESS_COST, DbType.Double, ParameterDirection.Input);
            Request.AddParams("OVER_HEAD_", pClsProperty.OVER_HEAD, DbType.Double, ParameterDirection.Input);
            Request.AddParams("PREVIOUS_YEAR_PRESENT_LIMIT_", pClsProperty.PREVIOUS_YEAR_PRESENT_LIMIT, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CURRENT_MONTH_PRESENT_LIMIT_", pClsProperty.CURRENT_MONTH_PRESENT_LIMIT, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("MAX_PRED_PLAN_", pClsProperty.MAX_PRED_PLAN, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MAX_RECORD_LIVESTOCK_", pClsProperty.MAX_RECORD_LIVESTOCK, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("GUEST_HOSTNAME_", pClsProperty.GUEST_HOSTNAME, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GUEST_PORT_", pClsProperty.GUEST_PORT, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GUEST_SERVICENAME_", pClsProperty.GUEST_SERVICENAME, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GUEST_USERNAME_", pClsProperty.GUEST_USERNAME, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GUEST_PASSWORD_", pClsProperty.GUEST_PASSWORD, DbType.Int32, ParameterDirection.Input);

            //ADD BY HARESH ON 01-08-2016

            Request.AddParams("WEB_HOSTNAME_", pClsProperty.WEB_HOSTNAME, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("WEB_DATABASE_", pClsProperty.WEB_DATABASE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("WEB_USERNAME_", pClsProperty.WEB_USERNAME, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("WEB_PASSWORD_", pClsProperty.WEB_PASSWORD, DbType.Int32, ParameterDirection.Input);

            //END AS

            Request.AddParams("ALLOW_TIME_DIFF_", pClsProperty.ALLOW_TIME_DIFF, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Settings_Save";
            Request.CommandType = CommandType.StoredProcedure;

            return Request;
        }

        public int Save(Settings_Property pClsProperty)
        {
            Request Request = AddSettingsParams(pClsProperty);
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public Settings_Property GetDataByPK()
        {

            Request Request = new Request();

            Request.CommandText = "Settings_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (DRow == null)
            {
                return null;
            }
            Settings_Property Property = new Settings_Property();
            Property.Version = Val.ToString(DRow["VERSION"]);
            Property.Exe_Copy_Path = Val.ToString(DRow["EXE_COPY_PATH"]);

            Property.SMTP_Server = Val.ToString(DRow["SMTPSERVER"]);
            Property.SMTP_Port = Val.ToInt(DRow["SMTPPORT"]);
            Property.Sender_Email = Val.ToString(DRow["SENDER_EMAIL"]);
            if (Val.ToString(DRow["SENDER_PASSWORD"]) != "")
            {
                Property.Sender_Password = BLL.GlobalDec.Decrypt(Val.ToString(DRow["SENDER_PASSWORD"]), true);
            }
            else
            {
                Property.Sender_Password = "";
            }
            Property.RapNet_UserName = Val.ToString(DRow["RAPNET_USERNAME"]);
            if (Val.ToString(DRow["RAPNET_PASSWORD"]) != "")
            {
                Property.RapNet_Password = BLL.GlobalDec.Decrypt(Val.ToString(DRow["RAPNET_PASSWORD"]), true);
            }
            else
            {
                Property.RapNet_Password = "";
            }
            Property.IS_Grace_Applicable = Val.ToInt(DRow["IS_GRACE_APPLICABLE"]);

            Property.IS_Enable_SSL = Val.ToInt(DRow["IS_ENABLE_SSL"]);

            Property.Advance_Salary_Limit_Per = Val.ToInt(DRow["ADVANCE_SALARY_LIMIT_PER"]);
            Property.Advance_Deduction_Limit_Per = Val.ToInt(DRow["ADVANCE_DEDUCTION_LIMIT_PER"]);

            Property.Attendance_Update_Due_Days = Val.ToInt(DRow["ATTENDANCE_UPDATE_DUE_DAYS"]);
            Property.Attendance_Absent_Limit = Val.ToInt(DRow["ATTENDANCE_ABSENT_LIMIT"]);
            Property.Minor_Age_Limit = Val.ToInt(DRow["MINOR_AGE_LIMIT"]);
            Property.Allow_Developer_Entry = Val.ToInt(DRow["Allow_Developer_ENTRY"]);
            Property.Allow_Email_Send = Val.ToInt(DRow["ALLOW_EMAIL_SEND"]);
            Property.EXE_UPDATE_MESSAGE_PATH = Val.ToString(DRow["EXE_UPDATE_MESSAGE_PATH"]);
            Property.Minimum_Working_Hours = Val.Val(DRow["MINIMUM_WORKING_HOURS"]);
            Property.ALLOW_SIEVE_PCS_VALIDATION = Val.ToInt(DRow["ALLOW_SIEVE_PCS_VALIDATION"]);
            Property.IS_PAYHEAD_DYNAMIC = Val.ToInt(DRow["IS_PAYHEAD_DYNAMIC"]);
            Property.IDLE_MODE_EXE_CLOSE = Val.ToInt(DRow["IDLE_MODE_EXE_CLOSE"]);
            Property.Is_Barcode_Print = Val.ToInt(DRow["IS_BARCODE_PRINT"]);

            Property.DOLLAR_RATE = Val.Val(DRow["DOLLAR_RATE"]);
            Property.PROCESS_COST = Val.Val(DRow["PROCESS_COST"]);
            Property.OVER_HEAD = Val.Val(DRow["OVER_HEAD"]);

            Property.PREVIOUS_YEAR_PRESENT_LIMIT = Val.ToInt(DRow["PREVIOUS_YEAR_PRESENT_LIMIT"]);
            Property.CURRENT_MONTH_PRESENT_LIMIT = Val.ToInt(DRow["CURRENT_MONTH_PRESENT_LIMIT"]);

            Property.MAX_PRED_PLAN = Val.ToInt(DRow["MAX_PRED_PLAN"]);

            Property.MAX_RECORD_LIVESTOCK = Val.ToInt(DRow["MAX_RECORD_LIVESTOCK"]);

            Property.ALLOW_TIME_DIFF = Val.ToInt(DRow["ALLOW_TIME_DIFF"]);

            Property.GUEST_HOSTNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["GUEST_HOSTNAME"]), true);
            Property.GUEST_PORT = BLL.GlobalDec.Decrypt(Val.ToString(DRow["GUEST_PORT"]), true);
            Property.GUEST_SERVICENAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["GUEST_SERVICENAME"]), true);
            Property.GUEST_USERNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["GUEST_USERNAME"]), true);
            Property.GUEST_PASSWORD = BLL.GlobalDec.Decrypt(Val.ToString(DRow["GUEST_PASSWORD"]), true);
            Property.PROD_SUMMARY_SETTING = BLL.GlobalDec.Decrypt(Val.ToString(DRow["PRODSUMMAYCONG"]), true);

            /*Property.WEB_HOSTNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_HOSTNAME"]), true);
            Property.WEB_DATABASE = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_DATABASE"]), true);
            Property.WEB_USERNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_USERNAME"]), true);
            Property.WEB_PASSWORD = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_PASSWORD"]), true);*/
            
            return Property;
        }

        #endregion
    }
}
