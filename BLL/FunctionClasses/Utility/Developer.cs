/*
***************************************************************************
Author:		    Haresh
Create date:    22-08-12
Description:	Article Master Business Login For Save,Delete And Display Data
***************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using BLL.FunctionClasses.Master;
using System.Data;
using DLL;

namespace BLL.FunctionClasses.Utility
{
    public class Developer
    {
        InterfaceLayer Ope = new InterfaceLayer();

        Validation Val = new Validation();

        #region Property Settings


        private DataTable _DTab = new DataTable();

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }


        #endregion

        #region Other Function

        public void GetData(string pStrUserName, string pStrTableName)
        {
            Request Request = new Request();
            Request.CommandText = @"Select Tab.COLUMN_NAME,Tab.DATA_TYPE,cols.Column_Name AS PRIMARY_KEY From  user_tab_columns Tab
                                Left Join all_constraints cons On cons.constraint_type = 'P' And Tab.Table_Name = Cons.Table_Name
                                Left Join all_cons_columns cols On cons.constraint_name = cols.constraint_name
                                                                   AND cons.owner = cols.owner
                                                                   And Tab.TABLE_NAME = cols.Table_Name
                                                                   And Tab.COLUMN_NAME = cols.COLUMN_NAME
                                Where Tab.TABLE_NAME = '" + pStrTableName + "' AND cons.owner = '" + pStrUserName + "' ORDER BY COLUMN_ID";

            Request.CommandType = CommandType.Text;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName,DTab, Request);
        }

        public void UpdateColumnPosition(string pStrTableName,string pStrColumnList,string pStrPrimaryKey)
        {
            Request Request = new Request();
            Request.CommandText = "Alter Table " + pStrTableName + " Rename To " + pStrTableName + "_1";
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            Request = new Request();
            Request.CommandText = "Create Table " + pStrTableName + " As Select " + pStrColumnList + " From " + pStrTableName + "_1";
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            Request = new Request();
            Request.CommandText = "Drop Table " + pStrTableName + "_1 purge";
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request); 
            
            Request = new Request();
            Request.CommandText = "Alter Table " + pStrTableName + " add CONSTRAINT " + pStrTableName + "_PK PRIMARY KEY (" + pStrPrimaryKey + ")";
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            
            
        }

        public void UpdateColumnDataType(string pStrTableName, string pStrColumnName, string pStrDataType)
        {
            // A-PART

            string StrSql = "alter table " + pStrTableName + " rename column " + pStrColumnName + " to " + pStrColumnName + "_OLD";

            Request Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            StrSql = " alter table " + pStrTableName + " add " + pStrColumnName + " " + pStrDataType + "";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
            StrSql = " update " + pStrTableName + " set " + pStrColumnName + " = " + pStrColumnName + "_OLD";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
            StrSql = " alter table " + pStrTableName + " drop column " + pStrColumnName + "_OLD";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
            // B-PART

            StrSql = "alter table " + pStrTableName + " rename column " + pStrColumnName + " to " + pStrColumnName + "_OLD";

            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            StrSql = " alter table " + pStrTableName + " add " + pStrColumnName + " " + pStrDataType + "";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            StrSql = " update " + pStrTableName + " set " + pStrColumnName + " = " + pStrColumnName + "_OLD";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            StrSql = " alter table " + pStrTableName + " drop column " + pStrColumnName + "_OLD";
            Request = new Request();
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;
            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            

        }

        public int VIPULRoughDelete(string pStrRoughName)
        {
            Request Request = new Request();
            Request.CommandText = "ASP_ROUGH_MANUALDELETE";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int IssRecJangedUpdate()
        {
            Request Request = new Request();
            Request.CommandText = "A_UPDATE_ISSREC_JANGED1";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        public DataTable GetEmployeeMasterA(int pIntCompanyCode)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "SELECT EMPLOYEE_CODE FROM EMPLOYEE_MASTER WHERE COMPANY_CODE = '" + pIntCompanyCode + "' ORDER BY EMPLOYEE_CODE";
            Request.CommandType = CommandType.Text;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public int UpdateEmployeeIDA(int pIntCompanyCode,int pIntEmployeeCode,int pIntEmployeeID)
        {
            Request Request = new Request();
            Request.CommandText = "UPDATE EMPLOYEE_MASTER SET EMPLOYEE_ID = " + pIntEmployeeID + " WHERE EMPLOYEE_CODE = '" + pIntEmployeeCode + "' ";
            Request.CommandType = CommandType.Text;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            Request = new Request();
            Request.CommandText = "UPDATE EMPLOYEE_MASTER SET EMPLOYEE_ID = " + pIntEmployeeID + " WHERE EMPLOYEE_CODE = '" + pIntEmployeeCode + "' ";
            Request.CommandType = CommandType.Text;
            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            return IntRes;

        }

        public DataTable GetEmployeeMasterB(int pIntCompanyCode)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "SELECT EMPLOYEE_CODE FROM EMPLOYEE_MASTER WHERE COMPANY_CODE = '" + pIntCompanyCode + "' AND SAVE_CATEGORY='B' ORDER BY EMPLOYEE_CODE";
            Request.CommandType = CommandType.Text;
            Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request);
            return DTab;
        }

        public int UpdateEmployeeIDB(int pIntCompanyCode, int pIntEmployeeCode, int pIntEmployeeID)
        {
            Request Request = new Request();
            Request.CommandText = "UPDATE EMPLOYEE_MASTER SET EMPLOYEE_ID = " + pIntEmployeeID + " WHERE EMPLOYEE_CODE = '" + pIntEmployeeCode + "' ";
            Request.CommandType = CommandType.Text;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            return IntRes;

        }


        #endregion
    }
}


