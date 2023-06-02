using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLL;

namespace BLL
{
    public class FillCombo
    {
        InterfaceLayer Ope = new InterfaceLayer();

        public enum TABLE
        {
            COMPANY_MASTER = 1,
            BRANCH_MASTER = 2,
            LOCATION_MASTER = 3,
            DEPARTMENT_MASTER = 4,
            ROUGH_MASTER = 5,
            PROCESS_MASTER_ALL = 6,
            PROCESS_MASTER_CLV_MIX = 7,
            PROCESS_MASTER_MFG_MIX = 8,
            ROUGH_TYPE_MASTER = 9,
            TEAM_MASTER = 10,
            GROUP_MASTER = 11,
            MFG_CLARITY_MASTER_ALL = 12,
            MFG_CLARITY_MASTER_POLISH = 13,
            MFG_CLARITY_MASTER_PROCESS = 14,
            CLV_CLARITY_MASTER_ALL = 15,
            CLV_CLARITY_MASTER_POLISH = 16,
            CLV_CLARITY_MASTER_PROCESS = 17,
            SHAPE_MASTER = 18,            
            COLOR_MASTER = 19,
            POLISH_COLOR_MASTER = 20,
            MIX_SIEVE_MASTER = 21,            
            MACHINE_MASTER = 22,
            SHIFT_MASTER = 23,
            REASON_MASTER = 24,
            ARTICLE_MASTER = 25,
            SOURCE_MASTER = 26,
            SOURCE_COMPANY_MASTER = 27,
            MSIZE_MASTER = 28,
            QUALITY_MASTER = 29,
            POINTER_MASTER = 30,
            ITEM_GROUP_MASTER = 31,
            ITEM_CATEGORY_MASTER = 32,
            ITEM_MASTER = 33,
            COST_CENTER_MASTER = 34,
            SUB_COST_CENTER_MASTER = 35,
            ACCOUNT_TYPE_MASTER = 36,
            ACCOUNT_HEAD_MASTER = 37,
            EMPLOYEE_MASTER=38,
            MFG_CLARITY_MASTER=39,
            CLV_CLARITY_MASTER=40,
            PROCESS_MASTER=41,
            PROCESS_GROUP_MASTER=42,
            LEDGER_MASTER=43,
            SUB_LEDGER_MASTER=44,
            PACKET_MASTER = 45,
            SUB_LEDGER_MASTER_CITY=46,
            SIGHT_TYPE_MASTER=47,
            DESIGNATION_MASTER =48,
            CLARITY_MASTER=49,
            MIX_SIEVE_MASTER_POLISH = 50,
            SUB_LEDGER_MASTER_RIGHTS = 51,
            SUB_ROUGH_MASTER =52,
            BROKER = 53,
            ADAT = 54,
            INSPECTION_LEDGER = 55,
            DEACTIVE_EMPLOYEE_MASTER = 56,
            ROUGH_MASTER_COSTSHEET_COMPLETE = 57,
            PAY_HEAD_MASTER = 58,
            YEAR_MASTER = 59,
            LAB_MASTER =60,
            EMPLOYEE_MASTER_ACTIVE=61, // ADD : NARENDRA : 27-12-2014
            EMPLOYEE_MASTER_DEACTIVE=62,
            MIX_SIEVE_MASTER_WAGES = 63, // ADD : NARENDRA : 02-JAN-2015

            SECTION_MASTER = 64,
            GRADE_MASTER = 65,
            EMPLOYEE_GRADE_MASTER = 66,

            CUT_MASTER = 67,
            FL_MASTER = 68,

            RETURN_STATUS = 69,
            PRODUCTION_STATUS = 70,

            MFG_CLARITY_MASTER_INTERNATIONAL = 71, // ADD : VIPUL : 08/May/2015

            PROCESS_MASTER_CLV_SINGLE = 72,
            PROCESS_MASTER_MFG_SINGLE = 73,
            FORM_MASTER=74,
            REPORTED_TO =75,

            BANK_MASTER = 76,
            RAP_DISC_SETTING=77,
            EMPLOYEE_MASTER_WITH_ID = 78,
            REMARK_MASTER = 79,  // ADD BY NISHANT [-_-] 31/05/2015

            EMPLOYEE_MASTER_WITH_All_PROCESS = 80,
            DEPARTMENT_MASTER_POLISH = 81,

            GIRDLE_MASTER =82,
            PROCESS_MASTER_PAR_PRED = 83,
            SINGLE_REMARK_MASTER = 84,
            CS_MASTER =85,

            DEPARTMENT_GROUP_MASTER = 86,
            ORDER_TYPE = 87,                     // ADD BY NISHANT 28/08/2015
            PROCESS_MASTER_PREDICTION_SINGLE = 88,
            EMPLOYEE_MASTER_WITH_ID_PRESENT=89,
            EMPLOYEE_MASTER_WITH_All_PROCESS_PRESENT = 90,

            ARTICLE_GROUP_MASTER = 91,

            EMPLOYEE_MFG_SECTION_MASTER = 92,
            PACKET_MASTER_ALL_COLUMN = 93,
            PROCESS_MASTER_ALL_SINGLE = 94,
            SHAPE_MASTER_WITH_SHORT_NAME = 95,//SANDIP ADDED
            SUB_LEDGER_RIGHTS =96,
            MIX_SIEVE_MASTER_WAGES_ENTRY = 97,
            PROCESS_SEQ_GROUP = 98,// ADD : NARENDRA : 02-JAN-2015
            CS_AH_MASTER = 99, // ADD : PRAFUL : 26-OCT-2016
            OBSERVED_BY = 100,
            PRIORITY_TYPE_MASTER = 101
        }

        public int EMPLOYEE_CODE;
        public int COMPANY_CODE;
        public int BRANCH_CODE;
        public int LOCATION_CODE;
        public int DEPARTMENT_CODE;
        public int TEAM_CODE;
        public int PROCESS_CODE;
        public int COST_CENTER_CODE;
        public int GROUP_CODE;
        public int ARTICLE_CODE;
        public int MSIZE_CODE;
        
        public DataTable FillCmb(TABLE tenum)
        {
            DataTable DTab=new DataTable();
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", EMPLOYEE_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", COMPANY_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", BRANCH_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", LOCATION_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", DEPARTMENT_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", TEAM_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", PROCESS_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COST_CENTER_CODE_", COST_CENTER_CODE, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("OPE_", tenum.ToString(), DbType.String, ParameterDirection.Input);
            Request.CommandText = "FILL_COMBO";
            
            Request.CommandType = CommandType.StoredProcedure;

            if (tenum == TABLE.EMPLOYEE_MASTER)
            {
                //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                //{
                //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
                //}
                //else
                //{
                //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
                //}
            }
            else
            {
                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            }
             
            return DTab;
        }


        public DataTable FillCmbHR(TABLE tenum,string pStrType =null)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", EMPLOYEE_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", COMPANY_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", BRANCH_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", LOCATION_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", DEPARTMENT_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", TEAM_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", PROCESS_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COST_CENTER_CODE_", COST_CENTER_CODE, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("OPE_", tenum.ToString(), DbType.String, ParameterDirection.Input);
            if (pStrType == null) // Add By Khushbu 26/11/2014
            {
                Request.AddParams("TYPE_", pStrType, DbType.String, ParameterDirection.Input);    
            }
            else
            {
                Request.AddParams("TYPE_", pStrType.ToUpper(), DbType.String, ParameterDirection.Input);
            }


            Request.CommandText = "FILL_COMBO_HR";

            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}
            return DTab;
        }
        public DataTable FillCmb_RIGHTS(TABLE tenum, string pStrType ,int EmployeeCode)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", EmployeeCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", COMPANY_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", BRANCH_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", LOCATION_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", DEPARTMENT_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", TEAM_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", PROCESS_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COST_CENTER_CODE_", COST_CENTER_CODE, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("OPE_", tenum.ToString(), DbType.String, ParameterDirection.Input);
            Request.AddParams("TYPE_", pStrType.ToUpper(), DbType.String, ParameterDirection.Input);

            Request.CommandText = "FILL_COMBO_HR";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        // Add By Praful On 16052016

        public DataTable Rough_Master_GetData(TABLE tenum)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", EMPLOYEE_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", COMPANY_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", BRANCH_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", LOCATION_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", DEPARTMENT_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", TEAM_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", PROCESS_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COST_CENTER_CODE_", COST_CENTER_CODE, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("OPE_", tenum.ToString(), DbType.String, ParameterDirection.Input);
            Request.CommandText = "FILL_COMBO";

            Request.CommandType = CommandType.StoredProcedure;

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        // End
       
    }
}
