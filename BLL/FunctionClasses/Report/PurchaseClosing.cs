using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Report;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Report;
using System.Data;
using DLL;

namespace BLL.FunctionClasses.Report
{
    public class PurchaseClosing
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();


        public DataSet GetClosingReport(string pStrFromDate,string pStrToDate,int pIntLocationCode)
        {
            DataSet DS = new DataSet();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_PURCHASE_CLOSINGDET";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Temp", Request, "");
            //}
            //else
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "Temp", Request, "");
            //}
            
            return DS;
        }

      

        public DataTable GetClosingImport(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_IMPORT";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingSale(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_SALE";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingConsume(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_CONSUME";
            Request.CommandType = CommandType.StoredProcedure;
            
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingTransferPlus(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_TRANSFER_PLUS";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingTransferLess(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_TRANSFER_LESS";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingNeilsPlus(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_NEILS";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosing(string pStrFromDate, string pStrToDate, int pIntLocationCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_STOCK";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }
        // End : Narendra : 26-May-2015

        public DataTable GetClosingImportForExcel(string pStrFromDate, string pStrToDate)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_ROUGHIMPORT";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable GetClosingExportForExcel(string pStrFromDate, string pStrToDate)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_ROUGHEXPORT";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}
            return DTab;
        }

        public DataTable GetClosingConsumeForExcel(string pStrFromDate, string pStrToDate)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_ROUGHCONSUME";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable GetClosingTransferForExcel(string pStrFromDate, string pStrToDate)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_CLOSING_ROUGHTRANSFER";
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        // Add : Narendra : 31-May-2016
        public int SaveClosingStock(PurchaseClosing_Property Property)
        {
            Request Request = new Request();
            Request.AddParams("CLOSING_DATE_", Property.CLOSING_DATE, DbType.String, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", Property.TEAM_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", Property.GROUP_CODE, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CARAT_", Property.CARAT, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_", Property.AMOUNT, DbType.Double, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_BY_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_IP_", GlobalDec.gStrComputerIP, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("ID_", Property.ID, DbType.String, ParameterDirection.Input);


            Request.CommandText = "CLOSING_STOCK_SAVE";
            Request.CommandType = CommandType.StoredProcedure;
            return 0;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //else
            //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

        }
        // End ; Narendra : 31-May-2016


    }
}
