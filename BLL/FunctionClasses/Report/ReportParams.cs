using BLL.PropertyClasses.Report;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Report
{
    //add by haresh
    public class ReportParams
    {

        public enum ReportGroup
        {
            PURCHASE = 0,
            MIXTRANSACTION = 1
        }

        public struct CrystalParameter
        {
        }

        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        //#region Property Settings

        //private DataTable _DTab = new DataTable(BLL.TPV.Table.Report);

        //public DataTable DTab
        //{
        //    get { return _DTab; }
        //    set { _DTab = value; }
        //}

        //#endregion

        #region Other Function

        #region Purchase Report

        public DataTable GetPurchaseData(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            // Start Haresh On 16-11-2013

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            // End Haresh
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("PURCHASE_TYPE_CODE_", pClsProperty.Purchase_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PRODUCT_TYPE_CODE_", pClsProperty.Product_Type_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PARTY_GROUP_CODE_", pClsProperty.From_Party_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("DEAL_TYPE_", pClsProperty.Deal_Type, DbType.String, ParameterDirection.Input);

            Request.AddParams("BROKER_CODE_", pClsProperty.Broker_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("LOCAL_CURRENCY_CODE_", pClsProperty.Local_Currency_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PURCHASE_CURRENCY_CODE_", pClsProperty.Purchase_Currency_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIGHT_TYPE_CODE_", pClsProperty.Sight_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_QUALITY_CODE_", pClsProperty.Sub_Quality_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("PARTY_INVOICE_NO_", pClsProperty.Party_Invoice_No, DbType.String, ParameterDirection.Input);

            Request.AddParams("SHIPPED_BY_", pClsProperty.Shipped_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("INSURED_BY_", pClsProperty.Insured_By, DbType.String, ParameterDirection.Input);

            Request.AddParams("MAWB_NO_", pClsProperty.MAWB_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("IDF_NO_", pClsProperty.IDF_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("HAWB_NO_", pClsProperty.HAWB_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("KPC_NO_", pClsProperty.KPC_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("PAYMENT_DAYS_", pClsProperty.Payment_Days, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_INVOICE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_INVOICE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);


            Request.AddParams("FROM_HAWB_DATE_", pClsProperty.From_HAWB_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_HAWB_DATE_", pClsProperty.To_HAWB_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_MAWB_DATE_", pClsProperty.From_MAWB_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_MAWB_DATE_", pClsProperty.To_MAWB_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_KPC_DATE_", pClsProperty.From_KPC_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_KPC_DATE_", pClsProperty.To_KPC_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_KPCCLEAR_DATE_", pClsProperty.From_KPCClear_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_KPCCLEAR_DATE_", pClsProperty.To_KPCClear_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_IDF_DATE_", pClsProperty.From_IDF_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_IDF_DATE_", pClsProperty.To_IDF_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_BILL_OF_ENTRY_DATE_", pClsProperty.From_BillEntry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_BILL_OF_ENTRY_DATE_", pClsProperty.To_BillEntry_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_PAYMENT_DATE_", pClsProperty.From_Payment_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_PAYMENT_DATE_", pClsProperty.To_Payment_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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

        public DataTable Get_Rough_Lot_Detail_Report(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 16/06/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_TRN_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_TRN_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);


            Request.CommandText = pStrSPName;
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

        public DataTable Get_Team_Transfer_Report(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 17/06/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_QUALITY_CODE_", pClsProperty.Sub_Quality_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_TEAM_CODE_", pClsProperty.From_Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_TEAM_CODE_", pClsProperty.To_Team_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_GROUP_CODE_", pClsProperty.From_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_GROUP_CODE_", pClsProperty.To_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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

        public DataTable GetBranchTransferData(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

            Request.AddParams("PARTY_INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_TRANSFER_NO_", pClsProperty.Transfer_No, DbType.String, ParameterDirection.Input);

            Request.AddParams("PURCHASE_TYPE_CODE_", pClsProperty.Purchase_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PRODUCT_TYPE_CODE_", pClsProperty.Product_Type_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_INVOICE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_INVOICE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_TRANSFER_DATE_", pClsProperty.From_HO_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_TRANSFER_DATE_", pClsProperty.To_HO_Date, DbType.Date, ParameterDirection.Input);


            Request.CommandText = pStrSPName;
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


        #endregion

        #region Prepolishig Report

        //public DataTable Get_Employee_Wise_Report(ReportParams_EmployeeProperty pClsProperty, string pStrSPName)
        //{
        //    DataTable DTab = new DataTable();

        //    Request Request = new Request();
        //    Request.AddParams("GROUP_BY_", pClsProperty.Group_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEGMENT_CODE_", pClsProperty.Segment_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("DOMAIN_CODE_", pClsProperty.Domain_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("CATEGORY_CODE_", pClsProperty.Category_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("POSITION_CODE_", pClsProperty.Employee_Position_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_GRADE_CODE_", pClsProperty.Employee_Grade_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PRIMARY_PROCESS_CODE_", pClsProperty.Primary_Process_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_TEAM_CODE_", pClsProperty.Process_Team_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("GRADE_CODE_", pClsProperty.Grade_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_TYPE_CODE_", pClsProperty.Employee_Type_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("DESIGNATION_CODE_", pClsProperty.Designation_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("MANAGER_CODE_", pClsProperty.Manager_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("MAIN_LOCATION_CODE_", pClsProperty.Main_Location_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SHIFT_CODE_", pClsProperty.Shift_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("COUNTRY_CODE_", pClsProperty.Country_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("STATE_CODE_", pClsProperty.State_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FROM_DOJ_", pClsProperty.From_DOJ, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DOJ_", pClsProperty.To_DOJ, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("FROM_DOL_", pClsProperty.From_DOL, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DOL_", pClsProperty.To_DOL, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = pStrSPName;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    //}

        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
        //    //{
        //    //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
        //    //}

        //    return DTab;
        //}

        public DataTable Get_Tansaction_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("@From_Date", pClsProperty.Stock_From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@To_Date", pClsProperty.Stock_To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@From_Pary", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Party", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Type", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Bill_Tansaction_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("@Invoice_No", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_ID", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Date", pClsProperty.Stock_From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@To_Date", pClsProperty.Stock_To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Bill_Tansaction_Surat_Report(ReportParams_Property pClsProperty, string pStrSPName, int pstrToPartyCode)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("@FROM_PARTY", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY", pstrToPartyCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Date", pClsProperty.Stock_From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@To_Date", pClsProperty.Stock_To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_MIX_Prepolishing_Stock_ReportForInspection(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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

        public DataTable Get_MIX_Prepolishing_Stock_Report_OPT(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_HEAD_", pClsProperty.Article_Head, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_GRADE_", pClsProperty.MFG_Mix_Grade, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_GRADE_", pClsProperty.MFG_Grade, DbType.String, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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


        public DataTable Get_Valuation_Stock_ReportWith_RoughDate(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 26/08/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_HEAD_", pClsProperty.Article_Head, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_GRADE_", pClsProperty.MFG_Mix_Grade, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_GRADE_", pClsProperty.MFG_Grade, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_RATE_DATE_", pClsProperty.ROUGH_RATE_DATE, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_MIX_Prepolishing_OutSide_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);


            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_LOCATION_CODE_", pClsProperty.Main_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CITY_", pClsProperty.City, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("POINTER_CODE_", pClsProperty.Pointer_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_CONF_DATE_", pClsProperty.From_Conf_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_CONF_DATE_", pClsProperty.To_Conf_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("IS_SHOW_LABOUR_", pClsProperty.ISShowLabour, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("RECEIPT_DAYS_", pClsProperty.ReceiptDays, DbType.Int32, ParameterDirection.Input); //Add By Khushbu 29/08/2014

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Valuation_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);


            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_LOCATION_CODE_", pClsProperty.Main_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CITY_", pClsProperty.City, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("POINTER_CODE_", pClsProperty.Pointer_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("IS_SHOW_LABOUR_", pClsProperty.ISShowLabour, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGHRATE_DATE_", pClsProperty.ROUGH_RATE_DATE, DbType.Date, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public int FindNewBillNo(int pIntParty, int pIntProcess, int pIntMonth, int pIntYear)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Issrec_Janged", "MAX(BILL_INT)", " And From_Party_Code = '" + pIntParty.ToString() + "' And From_Process_Code = '" + pIntProcess.ToString() + "' And extract(year from BILL_DATE) = '" + pIntYear.ToString() + "' And extract(Month from BILL_DATE) = '" + pIntMonth.ToString() + "'");

        }

        //public DataTable GetBillData(string pStrToSubPartyCode, int pIntFromProcess,int pIntProcessGroup, string pStrFromDate, string pStrToDate)
        //{
        //    DataTable DTabBillNo = new DataTable(BLL.TPV.Table.Temp);
        //    Request Request = new Request();

        //    Request.AddParams("TO_SUB_PARTY_CODE_", pStrToSubPartyCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PROCESS_CODE_", pIntFromProcess, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_GROUP_CODE_", pIntProcessGroup, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_DATE_", pStrFromDate, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TO_DATE_", pStrToDate, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Labour_Bill_GetBillNo;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBillNo, Request);
        //    return DTabBillNo;
        //}

        //public DataTable GetPartyAddress(string pStrToPartyCode)
        //{
        //    DataTable DTabPartyAddress = new DataTable(BLL.TPV.Table.AggregateType);
        //    Request Request = new Request();

        //    Request.AddParams("LEDGER_CODE_", pStrToPartyCode, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.RP_LEDGER_ADDRESS;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabPartyAddress, Request);
        //    return DTabPartyAddress;
        //}

        //public int UpdateJangedBill(int pIntLinkCode, int pIntFromProcessCode, int pIntProcessGroup, int pIntMonth, int pIntYear, string pStrBillNo, int PIntBillInt, double pDouTDSAmount)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("LINK_CODE_", pIntLinkCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PROCESS_CODE_", pIntFromProcessCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_GROUP_CODE_", pIntProcessGroup, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MONTH_", pIntMonth, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("YEAR_", pIntYear, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BILL_NO_", pStrBillNo, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("BILL_INT_", PIntBillInt, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TDS_AMOUNT_", pDouTDSAmount, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("BILL_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BILL_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Labour_Bill_UpdateBillNo;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public DataTable Get_MIX_Prepolishing_Emp_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("IS_PROCESS_LOSS_", pClsProperty.IS_ProcessLoss, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_MFG_LOSS_", pClsProperty.IS_MFGLoss, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_EMPLOYEE_CODE_", pClsProperty.Sub_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("STOCK_TYPE_", pClsProperty.Stock_Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Employee_Performance_Activity_And_Size_Wise_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("DISCOUNT_MINUTE_", pClsProperty.Discount_Minute, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Employee_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);

            /*ADD BY HARESH ON 22-08-2014 FOR ROUGH AND ACTIVITY FILTERING*/

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("CARAT_TYPE_CODE_", pClsProperty.Carat_Type.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);
            /*--------*/

            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code.Replace("'", " ").Trim(), DbType.String, ParameterDirection.Input);

            //ADD BY HARESH ON 31-10-2014 FOR SIEVE FILTERING
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            ///

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            //ADD BY HARESH ON 30-10-2014
            Request.AddParams("STANDARD_DATE_", pClsProperty.Standard_Date, DbType.String, ParameterDirection.Input);
            //END 

            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            //Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("IS_PROCESS_LOSS_", pClsProperty.IS_ProcessLoss, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("IS_MFG_LOSS_", pClsProperty.IS_MFGLoss, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("SUB_EMPLOYEE_CODE_", pClsProperty.Sub_Employee_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            //Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);

            //Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            //Request.AddParams("STOCK_TYPE_", pClsProperty.Stock_Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //    //TELL BY CHIRAGBHAI ON DATE 28-APR-2016 FOR A PART SHOW DATA 
            //    //Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        public DataTable Get_MIX_Prepolishing_Machine_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MACHINE_CODE_", pClsProperty.Machine_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHIFT_CODE_", pClsProperty.Shift_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("REASON_CODE_", pClsProperty.Reason_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SAW_TYPE_", pClsProperty.Saw_Type, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("FROM_BOILING_DATE_", pClsProperty.From_Boiling_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_BOILING_DATE_", pClsProperty.To_Boiling_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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

        public DataTable Get_MIX_Rough_ToRough_Transfer_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ROUGH_NAME_", pClsProperty.From_Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }




        #endregion

        public DataSet GetSummaryReportData(string strRough, string dtPolishdate, string dtBenchMarkDate, decimal decDollorRate, decimal decProcessCost, decimal decOverHead, Int16 intDet)
        {
            DataSet DS = new DataSet();
            Request Request = new Request();

            Request.AddParams("ROUGH_NAME_", strRough, DbType.String, ParameterDirection.Input);
            Request.AddParams("POLISH_DATE_", dtPolishdate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("BANCKMARK_DATE_", dtBenchMarkDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("DOLLOR_RATE_", decDollorRate, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("PROCESS_COST_", decProcessCost, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("OVER_HEAD_", decOverHead, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("DETAIL_", intDet, DbType.Int16, ParameterDirection.Input);
            Request.CommandText = "RP_ROUGH_FCP_MAINSUMMARY";
            Request.CommandType = CommandType.StoredProcedure;
            Request.REF_CUR_OUT = 6;

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Temp", Request, "");
            //}
            //else
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "Temp", Request, "");
            //}

            return DS;
        }

        public DataSet GetSummaryReportData(string strRough, string strTeamCode, string strArticleCode, string strMSizeCode, string strArticleHeadCode, string dtFromDate, string dtToDate, string dtPolishdate, string dtBenchMarkDate, decimal decDollorRate, decimal decProcessCost, decimal decOverHead)
        {
            DataSet DS = new DataSet();
            Request Request = new Request();

            Request.AddParams("ROUGH_NAME_", strRough, DbType.String, ParameterDirection.Input);
            Request.AddParams("POLISH_DATE_", dtPolishdate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("BANCKMARK_DATE_", dtBenchMarkDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("DOLLOR_RATE_", decDollorRate, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("PROCESS_COST_", decProcessCost, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("OVER_HEAD_", decOverHead, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", strTeamCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", strArticleCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", strMSizeCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_HEAD_", strArticleHeadCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPLETED_FROM_DATE_", dtFromDate.Length == 0 ? null : dtFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("COMPLETED_TO_DATE_", dtToDate.Length == 0 ? null : dtToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "RP_ROUGH_FCP_MAINSUMMARY2";// BLL.TPV.SProc.RP_ROUGH_FCP_MAINSUMMARY;
            Request.CommandType = CommandType.StoredProcedure;
            Request.REF_CUR_OUT = 6;

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Temp", Request, "");
            //}
            //else
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "Temp", Request, "");
            //}

            return DS;
        }

        public DataSet GetSummaryReportData(string strRough, string strTeamCode, string strArticleCode, string strMSizeCode, string strArticleHeadCode, string dtFromDate, string dtToDate, string dtPolishdate, string dtBenchMarkDate, decimal decDollorRate, decimal decProcessCost, decimal decOverHead, decimal decRoughRate)
        {
            DataSet DS = new DataSet();
            Request Request = new Request();

            Request.AddParams("ROUGH_NAME_", strRough, DbType.String, ParameterDirection.Input);
            Request.AddParams("POLISH_DATE_", dtPolishdate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("BANCKMARK_DATE_", dtBenchMarkDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("DOLLOR_RATE_", decDollorRate, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("PROCESS_COST_", decProcessCost, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("OVER_HEAD_", decOverHead, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", strTeamCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", strArticleCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", strMSizeCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_HEAD_", strArticleHeadCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPLETED_FROM_DATE_", dtFromDate.Length == 0 ? null : dtFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("COMPLETED_TO_DATE_", dtToDate.Length == 0 ? null : dtToDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("EXP_RGH_PRICE_", decRoughRate, DbType.Decimal, ParameterDirection.Input);

            Request.CommandText = "RP_ROUGH_FCP_MAINSUMMARY2";// BLL.TPV.SProc.RP_ROUGH_FCP_MAINSUMMARY;
            Request.CommandType = CommandType.StoredProcedure;
            Request.REF_CUR_OUT = 6;

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Temp", Request, "");
            //}
            //else
            //{
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "Temp", Request, "");
            //}

            return DS;
        }

        #region get Absentism And Man Days Report Data

        public DataTable Get_Absentism_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DESIGNATION_CODE_", pClsProperty.Designation_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_YEAR_", pClsProperty.From_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_MONTH_", pClsProperty.From_Month, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_YEAR_", pClsProperty.To_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_MONTH_", pClsProperty.To_Month, DbType.String, ParameterDirection.Input);
            Request.AddParams("DDL_", pClsProperty.ddl, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
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

        #endregion

        // Completed By Praful on 04-05-2015

        #region get HR Salary Report Data

        // Replace the Code

        // Start by Praful HR Salary Report on 16-06-2015

        public DataTable Get_Salary_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PAYMENT_MODE_", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANK_CODE_", pClsProperty.Bank_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SAVE_CATEGORY_", pClsProperty.Save_Category, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_YEAR_", pClsProperty.From_Year, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_MONTH_", pClsProperty.From_Month, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_YEAR_", pClsProperty.To_Year, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_MONTH_", pClsProperty.To_Month, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROMYEARMONTH_", pClsProperty.From_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("TOYEARMONTH_", pClsProperty.To_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("DDL_", pClsProperty.ddl, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //    DTab.Columns.Remove(DTab.Columns["OT_SALARY"].ColumnName);
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}


            return DTab;
        }

        // Completed By Praful on 16-06-2015

        // Start by Praful HR Salary on 08-07-2015

        public DataTable Get_Salary(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("PAYMENT_MODE_", pClsProperty.Payment_Mode, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANK_CODE_", pClsProperty.Bank_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROMYEARMONTH_", pClsProperty.From_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("TOYEARMONTH_", pClsProperty.To_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("SAVE_CATEGORY_", pClsProperty.Save_Category, DbType.String, ParameterDirection.Input);
            Request.AddParams("DDL_", pClsProperty.ddl, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //    DTab.Columns.Remove(DTab.Columns["OT_SALARY"].ColumnName);
            //    DTab.Columns.Remove(DTab.Columns["TOTAL_OT_HRS"].ColumnName);
            //    DTab.Columns.Remove(DTab.Columns["OT_AMOUNT"].ColumnName);
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}

            return DTab;
        }

        // Completed By Praful on 08-07-2015

        #endregion

        // Code By Praful On 10-09-2015

        //public DataTable SelDistinctBankName(Employee_MasterProperty pClsProperty)
        //{
        //    DataTable DTab = new DataTable(BLL.TPV.Table.Temp);
        //    Request Request = new Request();

        //    string StrSql = "SELECT BANK_NAME,BANK_CODE FROM BANK_MASTER";
        //    Request.CommandText = StrSql;
        //    Request.CommandType = CommandType.Text;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        // Completed By Praful On 10-09-2015

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        public DataTable Get_Dept_To_Dept_Transfer_Data(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        // Completed By Praful On 10-09-2016

        // Add By Praful On 10112016

        public DataTable Get_MIX_Factory_Stock_Report_OPT(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("CHECKER_", pClsProperty.Checker, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_SEQ_CODE_", pClsProperty.Process_Sequence_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);

            /*ADD BY HARESH FOR MANAGER OS FILTER PUPOSE OF FROM-TO PROCESS AND FROM-TO COMP. PROCESS */

            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_COMP_PROCESS_CODE_", pClsProperty.From_Comp_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_COMP_PROCESS_CODE_", pClsProperty.To_Comp_Process_Code, DbType.String, ParameterDirection.Input);

            /*-------------*/

            Request.AddParams("MANAGER_CODE_", pClsProperty.Manager_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("MAIN_PROCESS_CODE_", pClsProperty.Main_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_MANAGER_CODE_", pClsProperty.Main_Manager_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_HO_DATE_", pClsProperty.From_HO_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_HO_DATE_", pClsProperty.To_HO_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_IMPORT_DATE_", pClsProperty.From_Import_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_IMPORT_DATE_", pClsProperty.To_Import_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMP_TYPE_", pClsProperty.Comp_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("POINTER_CODE_", pClsProperty.Pointer_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_ISS_TIME_", pClsProperty.Is_Iss_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_REC_TIME_", pClsProperty.Is_Rec_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_TIME_", pClsProperty.From_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_TIME_", pClsProperty.To_Time, DbType.String, ParameterDirection.Input);

            Request.AddParams("MFG_SECTION_CODE_", pClsProperty.MFG_Section_Code, DbType.String, ParameterDirection.Input);

            //ADD BY HARESH ON 08-11-2016
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_Code, DbType.Int32, ParameterDirection.Input);
            //END AS

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        // End
        #endregion
    }
}
