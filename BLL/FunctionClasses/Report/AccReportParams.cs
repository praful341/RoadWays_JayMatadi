using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Report;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Report;
using System.Text.RegularExpressions;

using System.Data;
using DLL;
using System.Reflection;

namespace BLL.FunctionClasses.Report
{
    public class AccReportParams
    {
    
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        double DblLedgerOpBal = 0.00;
        double DblOpeningBalance = 0.00;
      
       // LedgerMaster ObjLedger = new LedgerMaster();
        CompanyMaster ObjComp = new CompanyMaster();


        #region Other Function

        #region Accounts Report

        public DataTable Get_Ledger_Transaction_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            Request.AddParams("VOUCHER_NO_", pClsProperty.Voucher_No, DbType.String, ParameterDirection.Input);

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("COST_CENTER_CODE_", pClsProperty.Cost_Center_code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_COST_CENTER_CODE_", pClsProperty.Sub_Cost_Center_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.AddParams("BOOK_CODE_", pClsProperty.Book_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANKING_TYPE_", pClsProperty.BankingType, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("DRAWN_BANK_CODE_", pClsProperty.Drawn_Bank_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANK_CODE_", pClsProperty.Bank_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pClsProperty.Fin_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.Account_Type_Code, DbType.String, ParameterDirection.Input);
                              
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Ledger_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
          
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

           
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        // Add ; Narendra : 17-May-2016
        public DataTable Get_Ledger_Report_Condensed(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "RP_ACC_SINGLE_LEDGER_ENTRY_SUM";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        // End ; Narendra : 17-May-2016

        // Add : Narendra : 28-July-2015
        public DataTable Get_Tree_Account_Type_Master(string StrAccountTypeCode) // Add : Narendra : 28-July-2015
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("ACCOUNT_TYPE_CODE_", Val.ToInt(StrAccountTypeCode), DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "ACC_GET_TREE_ACC_TYPE_MAST_FW";                      
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        // End : Narendra : 28-July-2015
        public DataTable Get_Trail_Balance_Report(ReportParams_Property pClsProperty, string pStrSPName) // Add By Vipul 12/09/2014
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.Account_Type_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_GROUP_CODE_", pClsProperty.Account_Type_Group_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("IS_OPENING_", pClsProperty.IsOpening, DbType.Int32, ParameterDirection.Input);
            //Request.CommandText = pStrSPName + "1"; Commeted : Narendra : 11-Feb-2015
            Request.CommandText = pStrSPName + "_LEV";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Balance_Sheet(ReportParams_Property pClsProperty, string pStrSPName) //Khushbu 11/04/2014 // Changes DataSet To DataTable By Khushbu 11/09/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();        
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            //Request.AddParams("TYPE_LEVEL_", 0, DbType.Int32, ParameterDirection.Input);            
            //COMMETED : NARENDRA : 27-JAN-2015

            //Request.CommandText = pStrSPName + "1"; // COMMENTED : NARENDRA : 19-JAN-2015
            Request.CommandText = pStrSPName + "_LEV"; // ADD : NARENDRA : 19-JAN-2015
            
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Balance_Sheet_Dynamic(ReportParams_Property pClsProperty, string pStrSPName) //Khushbu 11/04/2014 // Changes DataSet To DataTable By Khushbu 11/09/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName + "2";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Generate_BalanceSheet_Report_New1(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate) //Khushbu 11/09/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int))); // Add : Narendra : 27-Jan-2015

                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int))); // Add : Narendra : 27-Jan-2015

                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int))); // Add : Narendra : 23-Jan-2015

                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int))); // Add : Narendra : 23-Jan-2015

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE' AND ( TYPE_LEVEL = 0 OR TYPE_LEVEL = 1 ) ";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
                DTab.DefaultView.RowFilter = "TYPE = 'INCOME' AND ( TYPE_LEVEL = 0 OR TYPE_LEVEL = 1 )";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));
                DTAccountType.Columns.Add("TYPE_LEVEL", typeof(int)); // ADD : NARENDRA ; 27-JAN-2015

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];
                //        DTNewRow["TYPE_LEVEL"] = DRowType["TYPE_LEVEL"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();

                // ----------------------- FOR EXPENSE -------------------------//
                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;


                foreach (DataRow DR in DTRow)
                {     
                    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                    if (DTView.ToTable().Rows.Count > 0)
                    {
                        DataTable DTabSub = DTView.ToTable();
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "TYPE_LEVEL"); //"LEDGER_CODE", "LEDGER_NAME"

                        double DouAccType_TotalAmt = 0.00;
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            DataRow DRNew = DTabExpense.NewRow();
                            if (Val.Val(DRDist["TYPE_LEVEL"]).Equals(0))
                            {
                                DRNew = DTabExpense.NewRow();

                                DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_CODE"];
                                DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " ACCOUNT_TYPE_CODE = " + Val.Val(DRDist["ACCOUNT_TYPE_CODE"]) + ""));
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;
                                DouOpening = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT)) * -1", " ACCOUNT_TYPE_CODE = " + Val.Val(DRDist["ACCOUNT_TYPE_CODE"]) + ""));

                                DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                DTabExpense.Rows.Add(DRNew);
                            }
                            else if (Val.Val(DRDist["TYPE_LEVEL"]).Equals(1))
                            {
                                DRNew = DTabExpense.NewRow();

                                DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_CODE"];
                                DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " ACCOUNT_TYPE_CODE = " + Val.Val(DRDist["ACCOUNT_TYPE_CODE"]) + ""));
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;
                                DouOpening = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT)) * -1", " ACCOUNT_TYPE_CODE = " + Val.Val(DRDist["ACCOUNT_TYPE_CODE"]) + ""));

                                DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                DTabExpense.Rows.Add(DRNew);
                            }

                        }


                    }
                }


                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Generate_BalanceSheet_Report_New(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate,bool boolDetails) //Khushbu 11/09/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));


                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
                

                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE' AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0) // tO CHECK ONLY MAIN ACCOUNT TYPE.
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///


                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"]; //TYPE_LEVEL=1 AND 
                    if (DTView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME","ACCOUNT_TYPE_CODE","UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE","TYPE_LEVEL","ACCOUNT_TYPE_SRNO");
                            DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                            DTabDistinct = DTabDistinct.DefaultView.ToTable();

                            DataRow DRNew = DTabExpense.NewRow(); 
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            if(boolDetails)
                                DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                    DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    //DTabSub
                                    DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    // Commented :Narendra : 31-Jul-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;
                                    // Add : narendra : 31-Jul-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;

                                    if (boolDetails)
                                    {
                                        if ((DouAmount + DouOpening) != 0)
                                        {
                                            //if (Val.Val(DRDist["LEDGER_CODE_COMBINE"]) == 645) // FOR PROFIT & LOSS A/C
                                            //{
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     OPENING BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouOpening;
                                            //    DTabExpense.Rows.Add(DRNew);
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     CURRENT BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouAmount;
                                            //    DTabExpense.ImportRow(DRNew);
                                            //}
                                            //else
                                                DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    //DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=1 AND LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO");
                                    DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                                  DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                                  : null;*/

                                    if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                    {
                                        DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                        DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO ASC";
                                        DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "' OR UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                            //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                           // DataRow[] UDRowGroup = DTab.Select("TYPE_LEVEL=2 AND   UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");

                                            double DouAmount = 0, DouGrpTotal = 0.00;
                                            if (UDRowGroup != null && UDRowGroup.Count() > 0)
                                            {
                                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");
                                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                                {
                                                    DouOpenig = 0;

                                                    //DRNew = DTabExpense.NewRow();
                                                    //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                    //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                    //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                    //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                    //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                                    
                                                    //DTabSub
                                                    DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", "DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + "")); //TYPE_LEVEL=2 AND  
                                                    // Commented : Narendra : 31-July-2015
                                                    //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                                    // Add : Narendra : 31-July-2015
                                                 //   DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));
                                                    //DouOpenig = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT) * -1)", " TYPE_LEVEL=1 AND LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                                    //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                    //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                                    // DTabExpense.Rows.Add(DRNew);
                                                }
                                            }
                                            DRNew = DTabExpense.NewRow();
                                            DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"])+1;

                                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                            if (boolDetails)
                                                DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            
                            //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                            //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;

                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                   // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_NAME"], Val.FormatWithSeperator(DouOpenig), Val.FormatWithSeperator(DouGrpTotal), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;

                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                             DouOpeningAmount + DouAmount, "", IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {                    
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];// +" AND TYPE_LEVEL = 0";
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                            //
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL","ACCOUNT_TYPE_SRNO");
                            DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                            DTabDistinct = DTabDistinct.DefaultView.ToTable();


                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;
                            if (boolDetails)
                                DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    double DouAmount = 0, DouOpening = 0;

                                    //DTabSub
                                    DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    // Commented : Narendra : 31-July-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);
                                    // Add : Narendra : 31-July-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if (boolDetails)
                                    {
                                        if((DouOpening + DouAmount) != 0)
                                            DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    //DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO");
                                    DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                                 DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                                 : null;*/
                                    if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                    {
                                        DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                        DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                                        DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "' OR UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                            DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                            double DouAmount = 0, DouOpening = 0;

                                            double DouGrpTotal = 0.00;
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                //DTabSub
                                                DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                                // Commented : Narendra ; 31-Jul-2015
                                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                                // Add : Narendra : 31-July-2015
                                              //  DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                                //DouOpening = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT) * -1)", " TYPE_LEVEL=1 AND LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                                DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                                DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                            }

                                            DRNew = DTabIncome.NewRow();
                                            DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                            DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                            if (boolDetails)
                                                DTabIncome.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                //foreach (DataRow DR1 in DtabSubGroup.Rows)
                                //{
                                //    if (Val.Val(DR1["ACCOUNT_TYPE_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_CODE"]))
                                //    {
                                //        DouAmount = DouAmount + (Val.Val(DR1["DEBIT_AMOUNT"]) - Val.Val(DR1["CREDIT_AMOUNT"]));
                                //        DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                //    }
                                //}

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]))
                                    {
                                        //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ""));
                                
                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                   // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));

                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;

                int Diff = Val.ToInt(DTabExpense.Rows.Count) - Val.ToInt(DTabIncome.Rows.Count);

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];


                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                    }
                }

                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < DTabIncome.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabExpense.Rows.Count)
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                            DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                            DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra ; 27-May-2015
                            

                        }
                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        
                        // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabIncome.Rows.Count)
                        {
                            DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                            //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            
                            //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015
                        
                        DTabCombine.Rows.Add(DRNew);
                    }
                }


                /* Commeted : Narendra : 16-Jan-2015
                 * 
                if (DouIncomeAmount - DouExpenseAmount> 0)
                {
                    
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

              
                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    
                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew); 

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);
                    

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   // DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                    DTabCombine.Rows.Add(DRNew);
                    

                }

                else if (DouIncomeAmount - DouExpenseAmount< 0)
                {
                   
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

                   
                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                   DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew);
                    

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                   DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                  // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                   DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));
                   DTabCombine.Rows.Add(DRNew);
                   
                }

                else*/
                {


                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);
                }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist) //Add : Narendra ; 26-Sep-2015
        {
            DataTable dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public DataTable Generate_BalanceSheet_Report_New_LINQ(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrToDate, string pStrFromDate, bool boolDetails) // Add : Narendra : 28-Sep-2015
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));


                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));


                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                #region Manage BRANCH / DIVISIONS AND SUSPENSE A/C Account Type Sides On Balance Sheet.

                string[] StrAccountTypeCode = Val.Trim("7,9").Split(','); // 7 : BRANCH / DIVISIONS, 9 : SUSPENSE A/C :: GET BOTH THIS TYPE UNDER LEDGER ACCOUNT AND FIX SIDE ON BALANCE SHEET - ASSETS/LIABILITIES.
                string AccountTypeCode_BRANCH_DEVISION = string.Empty;
                string AccountTypeCode_SUSPENSE = string.Empty;
                for (int i = 0; i < StrAccountTypeCode.Length; i++)
                {
                    if (StrAccountTypeCode[i].Trim().Equals(string.Empty))
                        continue;

                    string StrAccountType = Val.ToString(StrAccountTypeCode[i]);
                    DataTable DTTemp = Get_Tree_Account_Type_Master(StrAccountType);
                    foreach (DataRow DrowAcc in DTTemp.Rows)
                    {
                        if (i == 0)
                            AccountTypeCode_BRANCH_DEVISION = AccountTypeCode_BRANCH_DEVISION + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                        else if (i == 1)
                            AccountTypeCode_SUSPENSE = AccountTypeCode_SUSPENSE + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                    }

                }
                if (AccountTypeCode_BRANCH_DEVISION.Length > 1)
                    AccountTypeCode_BRANCH_DEVISION = "," + AccountTypeCode_BRANCH_DEVISION;
                if (AccountTypeCode_SUSPENSE.Length > 1)
                    AccountTypeCode_SUSPENSE = "," + AccountTypeCode_SUSPENSE;


                var QueryBranchDivision = (from row in DTab.AsEnumerable()
                                           where AccountTypeCode_BRANCH_DEVISION.Contains("," + row.Field<decimal>("ACCOUNT_TYPE_CODE") + ",")
                                           select new
                                           {
                                               LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                               LEDGER_NAME = (string)row["LEDGER_NAME"],
                                           })
                                       .Distinct();

                double DouBranchDivision = 0.00;
                if (QueryBranchDivision.Count() > 0)
                {
                    DataTable DTabBranchDivision = LINQToDataTable(QueryBranchDivision);
                    foreach (DataRow DrBranchDivision in DTabBranchDivision.Rows)
                    {
                        //DouBranchDivision += GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.CLOSING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DrBranchDivision["LEDGER_CODE"]), Val.DBDate(pStrToDate));
                    }                    
                    // Add : Narendra : 24-Oct-2015                    
                    DTab.Rows.Cast<DataRow>().Where(r => r["ACCOUNT_TYPE_CODE"].ToString() == "7").ToList().ForEach(r => r.SetField("TYPE", (DouBranchDivision < 0 ? "EXPENSE" : "INCOME")));
                    // End : Narendra : 24-Oct-2015
                }

                

                var QuerySuspense = (from row in DTab.AsEnumerable()
                                     where AccountTypeCode_SUSPENSE.Contains("," + row.Field<decimal>("ACCOUNT_TYPE_CODE") + ",")
                                     select new
                                     {
                                         LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                         LEDGER_NAME = (string)row["LEDGER_NAME"],
                                     })
                                           .Distinct();
                double DouSuspense = 0.00;
                if (QuerySuspense.Count() > 0)
                {
                    DataTable DTabSuspense = LINQToDataTable(QuerySuspense);
                    foreach (DataRow DrSuspense in DTabSuspense.Rows)
                    {
                        //DouSuspense += GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.CLOSING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DrSuspense["LEDGER_CODE"]), Val.DBDate(pStrToDate));
                    }
                    // Add : Narendra : 24-Oct-2015
                    //IEnumerable<DataRow> rowsSuspenseAc = 
                    DTab.Rows.Cast<DataRow>().Where(r => r["ACCOUNT_TYPE_CODE"].ToString() == "9").ToList().ForEach(r => r.SetField("TYPE", (DouSuspense < 0 ? "EXPENSE" : "INCOME")));
                    // End : Narendra : 24-Oct-2015
                }                
                // END ; NARENDRA ; 10-10-2015

                #endregion


                // FILTER WITH ONLU EXPENSE TYPE DATA
                var QueryExpense = from row in DTab.AsEnumerable()
                                   where row.Field<string>("TYPE") == "EXPENSE" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                                   select row;
                DataTable DTabFilterExpense = DTab.Clone();
                DTabFilterExpense = QueryExpense.Count() > 0 ? QueryExpense.CopyToDataTable() : null;
           
                // FILTER WITH ONLU INCOME TYPE DATA
                var QueryIncome = from row in DTab.AsEnumerable()
                                  where row.Field<string>("TYPE") == "INCOME" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                                  select row;
                DataTable DTabFilterIncome = DTab.Clone();
                DTabFilterIncome = QueryIncome.Count() > 0 ? QueryIncome.CopyToDataTable() : null;


                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                // ADD ; NARENDRA ; 10-10-2015
                //DataTable DTabOpeningAmount = new DataTable();
                //DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(pStrFromDate));

                

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0) // tO CHECK ONLY MAIN ACCOUNT TYPE.
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        //DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"]; // COMMENTED ; NARENDRA ; 10-10-2015
                //        // ADD ; NARENDRA ; 10-10-2015
                //        if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 7)
                //        {
                //            if (DouBranchDivision < 0)
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "CREDIT";
                //            else
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "DEBIT";
                //        }
                //        else if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 9)
                //        {
                //            if (DouSuspense < 0)
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "CREDIT";
                //            else
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "DEBIT";
                //        }
                //        else
                //            DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        // END ; NARENDRA ; 10-10-2015

                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///

                // CALCULATE LEDGER CR/DR BALANCE...
                var QueryLedgerAmount = DTab.AsEnumerable()
               .GroupBy(w => new
               {
                   LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
               })
               .Select(x => new
               {
                   DETAIL_MODE = x.Key.DETAIL_MODE,
                   LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                   AMOUNT = Val.Val((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

               })
               .Where(A => A.DETAIL_MODE == "LEDGER");

                DataTable DtTempAmount = new DataTable();
                if (QueryLedgerAmount.Count() > 0)
                {
                    DtTempAmount = LINQToDataTable(QueryLedgerAmount);
                }


                // Add : Narendra : 29-Sep-2015 // GET ALL LEDGER OPENING BALANCE 
                DataTable DTabOpeningAmount = new DataTable(); // COMMENTED ; NARENDRA ; 10-10-2015
                DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(pStrFromDate));
                // End : Narendra : 29-Sep-2015
                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                //DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    // Add : Narendra : 28-Sep-2015
                    var QueryDTView = (from row in DTabFilterExpense.AsEnumerable()
                                       where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DR["ACCOUNT_TYPE_CODE"])
                                       orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                       select new
                                       {
                                           LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                           LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                           ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                           ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                           UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                           DETAIL_MODE = (string)row["DETAIL_MODE"],
                                           TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                           ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                       }
                                     )
                                    .Distinct();

                    if (QueryDTView.Count() > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabDistinct = LINQToDataTable(QueryDTView); // Add : Narendra : 28-Sep-2015

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            if (boolDetails)
                                DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                    DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    Double DouAmount = 0, DouOpening = 0;


                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rows != null && rows.Count() > 0)
                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]) * -1;

                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;

                                    // Add : Narendra : 26-Oct-2015
                                    //if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 7)
                                    //{
                                    //    if (DouAmount < 0)
                                    //    {
                                    //        DouAmount *= -1;
                                    //    }
                                    //    if(DouOpening < 0)
                                    //    {
                                    //        DouOpening *= -1;
                                    //    }

                                    //}
                                    // End : Narendra : 26-Oct-2015

                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening; // Commented : Narendra : 26-Oct-2015

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;

                                    if (boolDetails)
                                    {
                                        if ((DouAmount + DouOpening) != 0)
                                        {
                                            //if (Val.Val(DRDist["LEDGER_CODE_COMBINE"]) == 645) // FOR PROFIT & LOSS A/C
                                            //{
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     OPENING BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouOpening;
                                            //    DTabExpense.Rows.Add(DRNew);
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     CURRENT BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouAmount;
                                            //    DTabExpense.ImportRow(DRNew);
                                            //}
                                            //else
                                            DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    // Add : Narendra : 28-Sep-2015
                                    var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                                   orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                                   select new
                                                                   {
                                                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                                   }).Distinct();
                                    DataTable DTabGroupDistinct = QueryUDRowGroupDistinct.Count() > 0 ? LINQToDataTable(QueryUDRowGroupDistinct) : null;
                                    // Add : Narendra : 28-Sep-2015

                                    if (DTabGroupDistinct != null && DTabGroupDistinct.Rows.Count > 0) // Add : Narendra ; 29-Sep-2015
                                    {

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            // Add : Narendra : 28-Sep-2015
                                            var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                                   select new
                                                                   {
                                                                       LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                       LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                                   })
                                                                  .Distinct();
                                            DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                            // Add : Narendra : 28-Sep-2015

                                            double DouAmount = 0, DouGrpTotal = 0.00;
                                            DouOpenig = 0.00;
                                            if (DTabGroupLedgerDistinct != null && DTabGroupDistinct.Rows.Count > 0) // Add : Narendra ; 28-SEp-2015
                                            {
                                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                                {
                                                    DouOpenig = 0;

                                                    //DRNew = DTabExpense.NewRow();
                                                    //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                    //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                    //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                    //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                    //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                    DouAmount = 0.00;
                                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rows != null && rows.Count() > 0)
                                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]) * -1;

                                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                                        DouOpenig = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;


                                                    //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                    //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                                    // DTabExpense.Rows.Add(DRNew);
                                                }
                                            }
                                            DRNew = DTabExpense.NewRow();
                                            DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            // Add : Narendra : 26-Oct-2015
                                            //if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 7)
                                            //{
                                            //    if (DouGrpTotal < 0)
                                            //    {
                                            //        DouGrpTotal *= -1;
                                            //    }
                                            //    if (DouOpenig < 0)
                                            //    {
                                            //        DouOpenig *= -1;
                                            //    }

                                            //}
                                            // End : Narendra : 26-Oct-2015

                                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                            if (boolDetails)
                                                DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                            //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {

                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {

                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                // Add : Narendra : 29-Sep-2015
                var QueryLedgerAmountIncome = DTab.AsEnumerable()
               .GroupBy(w => new
               {
                   LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
               })
               .Select(x => new
               {
                   DETAIL_MODE = x.Key.DETAIL_MODE,
                   LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                   //AMOUNT = Val.ToString((x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("DEBIT_AMOUNT"))))) - x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("CREDIT_AMOUNT")))))) * -1),
                   AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

               })
               .Where(A => A.DETAIL_MODE == "LEDGER");

                DtTempAmount = new DataTable();
                if (QueryLedgerAmountIncome.Count() > 0)
                {
                    DtTempAmount = LINQToDataTable(QueryLedgerAmountIncome);
                }
                // End : Narendra : 29-Sep-2015

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    // Add : Narendra : 29-Sep-2015
                    var QueryDTIncomeView = (from row in DTabFilterIncome.AsEnumerable()
                                             where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"])
                                             orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                             select new
                                             {
                                                 LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                                 LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                                 ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                 ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                 UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                 DETAIL_MODE = (string)row["DETAIL_MODE"],
                                                 TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                 ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                             }
                                       )
                                      .Distinct();

                    if (QueryDTIncomeView.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabDistinct = LINQToDataTable(QueryDTIncomeView); // ADD ; NARENDRA ; 29-SEP-2015

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;
                            if (boolDetails)
                                DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    double DouAmount = 0, DouOpening = 0;

                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rows != null && rows.Count() > 0)
                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                    //DTabSub
                                    //DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate); // COMMENTED ; NARENDRA ; 29-SEP-2015

                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);

                                    //// Add : Narendra : 26-Oct-2015
                                    //if (Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) == 7)
                                    //{
                                    //    if (DouAmount > 0)
                                    //    {
                                    //        DouAmount *= -1;
                                    //    }
                                    //    if (DouOpening > 0)
                                    //    {
                                    //        DouOpening *= -1;
                                    //    }

                                    //}
                                    //// End : Narendra : 26-Oct-2015

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if (boolDetails)
                                    {
                                        if ((DouOpening + DouAmount) != 0)
                                            DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {

                                    // COMMENTED : NARENDRA ; 29-SEP-2015 :: DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                                   orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                                   select new
                                                                   {
                                                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                                   }).Distinct();

                                    if (QueryUDRowGroupDistinct.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015
                                    {
                                        DTabGroupDistinct = LINQToDataTable(QueryUDRowGroupDistinct); // ADD ; NARENDRA ; 29-SEP-2015

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            // Add : Narendra : 28-Sep-2015
                                            var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                                   select new
                                                                   {
                                                                       LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                       LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                                   })
                                                                  .Distinct();
                                            DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                            // Add : Narendra : 28-Sep-2015

                                            double DouAmount = 0, DouOpening = 0;

                                            double DouGrpTotal = 0.00;
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                DouAmount = 0.00;
                                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRow["LEDGER_CODE"]));
                                                if (rows != null && rows.Count() > 0)
                                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                                DouOpening = 0;
                                                IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rowsOpening != null && rowsOpening.Count() > 0)
                                                    DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);

                                                DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                                DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                            }

                                            DRNew = DTabIncome.NewRow();
                                            DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                            DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                            if (boolDetails)
                                                DTabIncome.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS")
                        {
                            /*IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                //foreach (DataRow DR1 in DtabSubGroup.Rows)
                                //{
                                //    if (Val.Val(DR1["ACCOUNT_TYPE_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_CODE"]))
                                //    {
                                //        DouAmount = DouAmount + (Val.Val(DR1["DEBIT_AMOUNT"]) - Val.Val(DR1["CREDIT_AMOUNT"]));
                                //        DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                //    }
                                //}

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]))
                                    {
                                        DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ""));

                                DouOpeningAmount = DouOpeningAmount;



                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }*/
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            /*
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                    DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));

                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);
                            */
                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;

                int Diff = Val.ToInt(DTabExpense.Rows.Count) - Val.ToInt(DTabIncome.Rows.Count);

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];


                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                    }
                }

                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < DTabIncome.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabExpense.Rows.Count)
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                            DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                            DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra ; 27-May-2015


                        }
                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                        // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabIncome.Rows.Count)
                        {
                            DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                            //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                            //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                        DTabCombine.Rows.Add(DRNew);
                    }
                }



                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);
                }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // ADD ; NARENDRA ; 29-SEP-2015
        public DataTable FindLedgerOpeningClosing_All(BLL.GlobalDec.LEDGEROPENING pEnum, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, int pIntLedgerCode, string pStrEntryDate)
        {
            DataTable DTab = new DataTable();
            Validation Val = new Validation();
            InterfaceLayer Ope = new InterfaceLayer();

            Request Request = new Request();
            Request.CommandText = "FIND_LEDGER_OPENINGCLOSING_ALL";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("OPE_", Val.Left(pEnum.ToString(), 1), DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pIntLedgerCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("NEW_AMOUNT", DouAmount, DbType.Double, ParameterDirection.Output);

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
            
        }

        // END ; NARENDRA ; 29-SEP-2015
        public DataTable Generate_BalanceSheet_Report_New_LINQ_old(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate, bool boolDetails) //Khushbu 11/09/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));


                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));


                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE' AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

               // DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                // Add : Narendra : 26-Sep-2015
                DataTable DTRow = DTAccountType.Clone();
                //var QueryAccType = from row in DTAb.AsEnumerable()
                //                   where row.Field<decimal>("IN_BALANCESHEET") == 1 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == 0
                //                   select row;

                //if (QueryAccType != null && QueryAccType.Count() > 0)
                //{
                //    foreach (DataRow DRowType in QueryAccType)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        //DataRow DTRowNewRow = DTRow.NewRow();

                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];
                        
                //        DTAccountType.Rows.Add(DTNewRow);
                //        DTRow.ImportRow(DTNewRow);
                //    }
                //}

                /* Commented : Narendra ; 26-Sep-2015
                 * foreach (DataRow DRowType in DTAb.Rows)
                {
                    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0) // tO CHECK ONLY MAIN ACCOUNT TYPE.
                    {
                        DataRow DTNewRow = DTAccountType.NewRow();
                        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                        DTAccountType.Rows.Add(DTNewRow);
                    }
                }
                */
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///


                // ----------------------- FOR EXPENSE -------------------------//


                var QueryLedgerAmount = DTab.AsEnumerable()
                       .GroupBy(w => new
                       {
                           LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                           DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
                       })
                       .Select(x => new
                       {
                           DETAIL_MODE = x.Key.DETAIL_MODE,
                           LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                           //AMOUNT = Val.ToString((x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("DEBIT_AMOUNT"))))) - x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("CREDIT_AMOUNT")))))) * -1),
                           AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1")))) * -1),

                       })
                       .Where(A => A.DETAIL_MODE == "LEDGER");

                DataTable DtTempAmount = LINQToDataTable(QueryLedgerAmount);

                // Add : Narendra ; 26-Sep-2015 To Calculate Transaction Of Ledger
                //DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'"); // Commented : Narendra : 26-Sep-2015
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow.Rows)
                {
                    double DouOpenig = 0;
                    //DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"]; //TYPE_LEVEL=1 AND              

                    // Fetch Distinct Column Value From Datatable.
                    var QueryDTView = DTView.Table.AsEnumerable().Select(r => new
                    {
                        LEDGER_CODE_COMBINE = r.Field<decimal>("LEDGER_CODE_COMBINE"),
                        LEDGER_NAME_COMBINE = r.Field<string>("LEDGER_NAME_COMBINE"),
                        ACCOUNT_TYPE_NAME = r.Field<string>("ACCOUNT_TYPE_NAME"),
                        ACCOUNT_TYPE_CODE = r.Field<decimal>("ACCOUNT_TYPE_CODE"),
                        UPPER_ACCOUNT_TYPE_CODE = r.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE"),
                        DETAIL_MODE = r.Field<string>("DETAIL_MODE"),
                        TYPE_LEVEL = r.Field<decimal>("TYPE_LEVEL"),
                        ACCOUNT_TYPE_SRNO = r.Field<decimal>("ACCOUNT_TYPE_SRNO"),

                    })
                    .Where(r => r.ACCOUNT_TYPE_CODE == Val.ToInt32(DR["ACCOUNT_TYPE_CODE"]))
                    .Distinct()
                    .OrderBy(r => r.DETAIL_MODE)
                    .OrderBy(r => r.ACCOUNT_TYPE_SRNO)
                    .OrderBy(r => r.LEDGER_NAME_COMBINE);

                    DataTable DtFilterData = LINQToDataTable(QueryDTView);

                    //if (DTView.ToTable().Rows.Count > 0) // Commented : Narendra ; 26-Sep-2015
                    if( DtFilterData != null && DtFilterData.Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            /* Commented : Narendra : 26-Sep-2015
                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                            DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                            DTabDistinct = DTabDistinct.DefaultView.ToTable();*/

                            // Add ; Narendra ; 26-Sep-2015
                            DataTable DTabDistinct = DtFilterData.Copy();

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            if (boolDetails)
                                DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                    DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rows != null && rows.Count() > 0)
                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);
                                    //rows.ToList().ForEach(r => r.SetField("SEL", true));

                                    //DTabSub :: COMMENTED ; NARENDRA ; 26-SEP-2015
                                    //DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                    // Commented :Narendra : 31-Jul-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;
                                    // Add : narendra : 31-Jul-2015
                                   // DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;

                                    if (boolDetails)
                                    {
                                        if ((DouAmount + DouOpening) != 0)
                                        {
                                            //if (Val.Val(DRDist["LEDGER_CODE_COMBINE"]) == 645) // FOR PROFIT & LOSS A/C
                                            //{
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     OPENING BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouOpening;
                                            //    DTabExpense.Rows.Add(DRNew);
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     CURRENT BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouAmount;
                                            //    DTabExpense.ImportRow(DRNew);
                                            //}
                                            //else
                                            DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    // Fetch Distinct Column Value From Datatable. // ADD ; NARENDRA ; 26-SEP-2015

                                    var QueryFilter1 = from row in DTab.AsEnumerable()
                                                      where row.Field<decimal>("TYPE_LEVEL") == 2 &&
                                                            row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                      select row;

                                    


                                    // Commented : Narendra : 26-Sep-2015
                                    //DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    //DTabGroupDistinct = LINQToDataTable(QueryGROUP);
                                    if (QueryFilter1 != null && QueryFilter1.Count() > 0)
                                        DTabGroupDistinct = QueryFilter1.CopyToDataTable();

                                    if (DTabGroupDistinct != null && DTabGroupDistinct.Rows.Count > 0)
                                    //if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0) // Commented ; Narendra : 26-SEp-2015
                                    {
                                        // Commented ; Narendra : 26-SEp-2015
                                        //DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                        //DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO ASC";
                                        //DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                        var QueryGROUP = DTab.AsEnumerable().Select(r => new //DTabGroupDistinct
                                            {                                       
                                                ACCOUNT_TYPE_NAME = r.Field<string>("ACCOUNT_TYPE_NAME"),
                                                ACCOUNT_TYPE_CODE = r.Field<decimal>("ACCOUNT_TYPE_CODE"),
                                                UPPER_ACCOUNT_TYPE_CODE = r.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE"),
                                                TYPE_LEVEL = r.Field<decimal>("TYPE_LEVEL"),
                                                ACCOUNT_TYPE_SRNO = r.Field<decimal>("ACCOUNT_TYPE_SRNO"),

                                            })
                                            .Where(r => r.UPPER_ACCOUNT_TYPE_CODE == Val.ToInt32(DRDist["ACCOUNT_TYPE_CODE"]) && r.TYPE_LEVEL == 2)
                                            .Distinct()
                                            .OrderBy(r => r.ACCOUNT_TYPE_SRNO);

                                        DTabGroupDistinct = LINQToDataTable(QueryGROUP);
                                        // END ; NARENDRA ; 26-SEP-2015

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {

                                            /*var QueryGroupLedgerAmount = DTab.AsEnumerable()
                                               .GroupBy(w => new
                                               {
                                                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
                                                   ACCOUNT_TYPE_CODE = w.Field<decimal>("ACCOUNT_TYPE_CODE"),
                                                   UPPER_ACCOUNT_TYPE_CODE = w.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE"),
                                                   LEDGER_CODE = w.Field<decimal>("LEDGER_CODE"),
                                                   LEDGER_NAME = w.Field<string>("LEDGER_NAME"),
                                               })
                                               .Select(x => new
                                               {
                                                   DETAIL_MODE = x.Key.DETAIL_MODE,
                                                   ACCOUNT_TYPE_CODE = x.Key.ACCOUNT_TYPE_CODE,
                                                   UPPER_ACCOUNT_TYPE_CODE = x.Key.UPPER_ACCOUNT_TYPE_CODE,

                                                   LEDGER_CODE = x.Key.LEDGER_CODE,
                                                   LEDGER_NAME = x.Key.LEDGER_NAME,
                                                   AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1")))) * -1),

                                               })
                                               .Where(A => A.DETAIL_MODE == "LEDGER" && (A.ACCOUNT_TYPE_CODE == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || A.UPPER_ACCOUNT_TYPE_CODE == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) ) );
                                            */
                                            var QueryFilter = from row in DTab.AsEnumerable()
                                                              where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) && 
                                                                    row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) &&
                                                                    row.Field<string>("DETAIL_MODE") == "LEDGER"
                                                              select row;

                                           // DataTable DTabGroupLedgerDistinct = LINQToDataTable(QueryGroupLedgerAmount); 
                                            DataTable DTabGroupLedgerDistinct = new DataTable();
                                            if(QueryFilter != null && QueryFilter.Count() > 0)
                                                DTabGroupLedgerDistinct = QueryFilter.CopyToDataTable(); 


                                            //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "' OR UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                            

                                            double DouAmount = 0, DouGrpTotal = 0.00;
                                            //if (UDRowGroup != null && UDRowGroup.Count() > 0) // COMMENTED ; NARENDRA ; 26-SEP-2015
                                            if (DTabGroupLedgerDistinct != null && DTabGroupLedgerDistinct.Rows.Count > 0) // ADD ; NARENDRA ; 26-SEP-2015
                                            {
                                                // DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME"); // COMMENTED ; NARENDRA ; 26-SEP-2015
                                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                                {
                                                    DouOpenig = 0;

                                                    //DRNew = DTabExpense.NewRow();
                                                    //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                    //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                    //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                    //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                    //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                    IEnumerable<DataRow> rows = DTabGroupLedgerDistinct.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE"].ToString() == Val.ToString(DRow["LEDGER_CODE"]));
                                                    if (rows != null && rows.Count() > 0)
                                                        DouAmount = (Val.Val(rows.CopyToDataTable().Rows[0]["DEBIT_AMOUNT_1"]) - Val.Val(rows.CopyToDataTable().Rows[0]["CREDIT_AMOUNT_1"])) * -1;

                                                    //DTabSub // COMMENTED ; NARENDRA ; 26-SEP-2015
                                                    //DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", "DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + "")); //TYPE_LEVEL=2 AND  

                                                    // Commented : Narendra : 31-July-2015
                                                    //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                                    // Add : Narendra : 31-July-2015
                                                   // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));
                                                    //DouOpenig = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT) * -1)", " TYPE_LEVEL=1 AND LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                                    //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                    //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                                    // DTabExpense.Rows.Add(DRNew);
                                                }
                                            }
                                            DRNew = DTabExpense.NewRow();
                                            DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                            if (boolDetails)
                                                DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                            //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                            //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;

                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                    //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_NAME"], Val.FormatWithSeperator(DouOpenig), Val.FormatWithSeperator(DouGrpTotal), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;

                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                             DouOpeningAmount + DouAmount, "", IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];// +" AND TYPE_LEVEL = 0";
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                            //
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                            DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                            DTabDistinct = DTabDistinct.DefaultView.ToTable();


                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;
                            if (boolDetails)
                                DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    double DouAmount = 0, DouOpening = 0;

                                    //DTabSub
                                    DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    // Commented : Narendra : 31-July-2015
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);
                                    // Add : Narendra : 31-July-2015
                                    //DouOpening = //FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if (boolDetails)
                                    {
                                        if ((DouOpening + DouAmount) != 0)
                                            DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    //DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO");
                                    DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                                 DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                                 : null;*/
                                    if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                    {
                                        DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                        DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                                        DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "' OR UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                            DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                            double DouAmount = 0, DouOpening = 0;

                                            double DouGrpTotal = 0.00;
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                //DTabSub
                                                DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                                // Commented : Narendra ; 31-Jul-2015
                                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                                // Add : Narendra : 31-July-2015
                                              //  DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                                //DouOpening = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT) * -1)", " TYPE_LEVEL=1 AND LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                                DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                                DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                            }

                                            DRNew = DTabIncome.NewRow();
                                            DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                            DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                            if (boolDetails)
                                                DTabIncome.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                //foreach (DataRow DR1 in DtabSubGroup.Rows)
                                //{
                                //    if (Val.Val(DR1["ACCOUNT_TYPE_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_CODE"]))
                                //    {
                                //        DouAmount = DouAmount + (Val.Val(DR1["DEBIT_AMOUNT"]) - Val.Val(DR1["CREDIT_AMOUNT"]));
                                //        DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                //    }
                                //}

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]))
                                    {
                                        //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ""));

                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));

                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;

                int Diff = Val.ToInt(DTabExpense.Rows.Count) - Val.ToInt(DTabIncome.Rows.Count);

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];


                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                    }
                }

                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < DTabIncome.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabExpense.Rows.Count)
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                            DRNew["EXPENSE_TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];

                            DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra ; 27-May-2015


                        }
                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                        DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]; // add ; narendra ; 08-apr-2015

                        DRNew["INCOME_TYPE_LEVEL"] = DTabIncome.Rows[IntJ]["INCOME_TYPE_LEVEL"];
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                        // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabIncome.Rows.Count)
                        {
                            DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                            //DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            //DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            //DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DRNew["INCOME_OPENING_AMOUNT"] = (DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = (Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                            //DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]); // Commented : Narendra : 27-May-2015
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DRNew["EXPENSE_OPENING_AMOUNT"] = (DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        //DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // Commented : Narendra : 27/May/2015

                        DTabCombine.Rows.Add(DRNew);
                    }
                }


                /* Commeted : Narendra : 16-Jan-2015
                 * 
                if (DouIncomeAmount - DouExpenseAmount> 0)
                {
                    
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

              
                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    
                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew); 

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);
                    

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   // DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                    DTabCombine.Rows.Add(DRNew);
                    

                }

                else if (DouIncomeAmount - DouExpenseAmount< 0)
                {
                   
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

                   
                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                   DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew);
                    

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                   DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                  // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                   DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));
                   DTabCombine.Rows.Add(DRNew);
                   
                }

                else*/
                {


                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);
                }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

         //commeted : Narendra : 23/Jan/2015
         
        public DataTable Generate_BalanceSheet_Report(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate) //Khushbu 11/09/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

               // DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///


                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                    if (DTView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));                              
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;
                                                                
                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                    DTabExpense.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouGrpTotal = 0.00;

                                 
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouOpenig = 0;

                                            //DRNew = DTabExpense.NewRow();
                                            //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                            //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                            //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                            //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                            DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                           // DTabExpense.Rows.Add(DRNew);
                                        }

                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;
                                        DTabExpense.Rows.Add(DRNew);
                                    }

                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                          //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                          //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;

                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                   // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_GROUP_NAME"], Val.FormatWithSeperator(DouOpenig), Val.FormatWithSeperator(DouGrpTotal), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }    
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;
                       
                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                             DouOpeningAmount + DouAmount,"", IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;

                            DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {       
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    DTabIncome.Rows.Add(DRNew);
                                 }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouOpening = 0;
                                        
                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {                                            
                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                           // DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                           // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                
                                double DouOpeningAmount = 0;

                                //foreach (DataRow DR1 in DtabSubGroup.Rows)
                                //{
                                //    if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                //    {
                                //        DouAmount = DouAmount + (Val.Val(DR1["DEBIT_AMOUNT"]) - Val.Val(DR1["CREDIT_AMOUNT"]));
                                //        DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                //    }
                                //}

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_GROUP_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                    {
                                       // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_GROUP_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]) + ""));
                                
                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {                           
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true,"ACCOUNT_TYPE_CODE","LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) ==  Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                }
                            }                         
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));

                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount ;
                            DRNew["INCOME_AMOUNT"] =  DouAmount +  DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;
                
                int Diff = Val.ToInt(DTabExpense.Rows.Count) - Val.ToInt(DTabIncome.Rows.Count);

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"] );
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                    }
                }

                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < DTabIncome.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabExpense.Rows.Count)
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                            DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);

                        }
                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabIncome.Rows.Count)
                        {
                            DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DTabCombine.Rows.Add(DRNew);
                    }
                }


               /* Commeted : Narendra : 16-Jan-2015
                * 
               if (DouIncomeAmount - DouExpenseAmount> 0)
               {
                    
                   DataRow DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew);

              
                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                   DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    
                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew); 

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew);
                    

                   DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                  // DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                   DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                   DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                   DTabCombine.Rows.Add(DRNew);
                    

               }

               else if (DouIncomeAmount - DouExpenseAmount< 0)
               {
                   
                   DataRow DRNew = DTabCombine.NewRow();
                   DRNew["EXPENSE_DETAIL_MODE"] = "";
                   DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                   DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                   DRNew["EXPENSE_AMOUNT"] = "";

                   DRNew["INCOME_DETAIL_MODE"] = "";
                   DRNew["INCOME_ACCOUNT_CODE"] = 0;
                   DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["INCOME_OPENING_AMOUNT"] = 0;
                   DRNew["INCOME_AMOUNT"] = "";
                   DTabCombine.Rows.Add(DRNew);

                   
                  DRNew = DTabCombine.NewRow();
                  DRNew["EXPENSE_DETAIL_MODE"] = "";
                  DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                  DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                  DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                  DRNew["EXPENSE_AMOUNT"] = "";

                  DRNew["INCOME_DETAIL_MODE"] = "";
                  DRNew["INCOME_ACCOUNT_CODE"] = 0;
                  DRNew["INCOME_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                  DRNew["INCOME_OPENING_AMOUNT"] = 0;
                  DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                  DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                  DTabCombine.Rows.Add(DRNew);

                  DRNew = DTabCombine.NewRow();
                  DRNew["EXPENSE_DETAIL_MODE"] = "";
                  DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                  DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                  DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                  DRNew["EXPENSE_AMOUNT"] = "";

                  DRNew["INCOME_DETAIL_MODE"] = "";
                  DRNew["INCOME_ACCOUNT_CODE"] = 0;
                  DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                  DRNew["INCOME_OPENING_AMOUNT"] = 0;
                  DRNew["INCOME_AMOUNT"] = "";
                  DTabCombine.Rows.Add(DRNew);
                    

                  DRNew = DTabCombine.NewRow();
                  DRNew["EXPENSE_DETAIL_MODE"] = "";
                  DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                  DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                  DRNew["EXPENSE_OPENING_AMOUNT"] = "";
               //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                  DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                  DRNew["INCOME_DETAIL_MODE"] = "";
                  DRNew["INCOME_ACCOUNT_CODE"] = 0;
                  DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                  DRNew["INCOME_OPENING_AMOUNT"] = 0;
                 // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                  DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));
                  DTabCombine.Rows.Add(DRNew);
                   
               }

               else*/
                {
                    

                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);
                }
                
                return DTabCombine;

                }
            catch (Exception)
            {
                throw;
            }
        }
        
        public DataTable Generate_BalanceSheet_Report_Dynamic(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate) //Khushbu 24/11/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));

                DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));
                DTAccountType.Columns.Add("UPPER_ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("UPPER_ACCOUNT_TYPE_NAME", typeof(string));
               

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];
                //        DTNewRow["UPPER_ACCOUNT_TYPE_CODE"] = DRowType["UPPER_ACCOUNT_TYPE_CODE"];
                //        DTNewRow["UPPER_ACCOUNT_TYPE_NAME"] = DRowType["UPPER_ACCOUNT_TYPE_NAME"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///


                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT' AND UPPER_ACCOUNT_TYPE_CODE = 0");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    DTView.RowFilter = "UPPER_ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                    if (DTView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "ACCOUNT_TYPE_cODE", "ACCOUNT_TYPE_NAME", "UPPER_ACCOUNT_TYPE_NAME", "DETAIL_MODE", "LEDGER_CODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["UPPER_ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_CODE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["UPPER_ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " ACCOUNT_TYPE_CODE = " + Val.Val(DRDist["ACCOUNT_TYPE_CODE"]) + ""));
                                   // DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]), pStrStartDate, pStrFromDate) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                    DTabExpense.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouGrpTotal = 0.00;


                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouOpenig = 0;

                                            //DRNew = DTabExpense.NewRow();
                                            //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                            //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                            //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                          //  DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                            DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                            // DTabExpense.Rows.Add(DRNew);
                                        }

                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;
                                        DTabExpense.Rows.Add(DRNew);
                                    }

                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                            //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;

                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                   // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_GROUP_NAME"], Val.FormatWithSeperator(DouOpenig), Val.FormatWithSeperator(DouGrpTotal), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                   // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;

                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                             DouOpeningAmount + DouAmount, "", IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;

                            DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    DTabIncome.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                            DouOpening = //FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                //foreach (DataRow DR1 in DtabSubGroup.Rows)
                                //{
                                //    if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                //    {
                                //        DouAmount = DouAmount + (Val.Val(DR1["DEBIT_AMOUNT"]) - Val.Val(DR1["CREDIT_AMOUNT"]));
                                //        DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                //    }
                                //}

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_GROUP_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                    {
                                        //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_GROUP_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]) + ""));
                                
                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));

                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;

                int Diff = Val.ToInt(DTabExpense.Rows.Count) - Val.ToInt(DTabIncome.Rows.Count);

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]);

                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                    }
                }

                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < DTabIncome.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabExpense.Rows.Count)
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                            DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);

                        }
                        DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                        DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < DTabIncome.Rows.Count)
                        {
                            DRNew["INCOME_DETAIL_MODE"] = DTabIncome.Rows[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabIncome.Rows[IntJ]["INCOME_ACCOUNT_NAME"];
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : DTabIncome.Rows[IntJ]["INCOME_TOTAL_AMOUNT"];

                            DouIncomeOpening += Val.Val(DTabIncome.Rows[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(DTabIncome.Rows[IntJ]["INCOME_AMOUNT"]);
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.FormatWithSeperator(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"];

                        DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (DouIncomeAmount - DouExpenseAmount > 0)
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount - DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    // DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DblSumIncome);
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                    DTabCombine.Rows.Add(DRNew);

                }

                else if (DouIncomeAmount - DouExpenseAmount < 0)
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount - DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));
                    DTabCombine.Rows.Add(DRNew);
                }

                else
                {


                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    DRNew["EXPENSE_AMOUNT"] = "";

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    DRNew["INCOME_AMOUNT"] = "";
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["EXPENSE_DETAIL_MODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                    //   DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouExpenseAmount));

                    DRNew["INCOME_DETAIL_MODE"] = "";
                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
                    DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
                    // DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense));
                    DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DouIncomeAmount));
                    DTabCombine.Rows.Add(DRNew);
                }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet Get_Balance_Sheet_Vertical(ReportParams_Property pClsProperty, string pStrSPName) // Add : Narendra : 03-08-2014
        {
            DataSet DS = new DataSet();

            Request Request = new Request();
            Request.REF_CUR_OUT = 2;
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "RP_ACC_BALANCE_SHEET_VERTICAL";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");
            //else
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "", Request, "");

            return DS;
        }

        public DataTable Register_Transaction(ReportParams_Property pClsProperty, string pStrSPName)  // Khushbu 05/05/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BOOK_CODE_", pClsProperty.Book_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BOOK_NAME_", pClsProperty.Book_Name, DbType.String, ParameterDirection.Input);//ADD : 23-05-2014 : NARENDRA

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
           

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Multi_Voucher_Print_Transaction(ReportParams_Property pClsProperty, string pStrSPName)  // Add : Narendra : 09-Jun-2015
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.Account_Type_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("PRINT_REF_DOC_NO_", pClsProperty.Is_Bill_By_Bill_No_Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PRINT_COST_SUB_CENTER_", pClsProperty.Is_Cost_Sub_Cost_Center_Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PRINT_NARRATION_", pClsProperty.Is_Narration_Print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PRINT_VOUCHER_NO_", pClsProperty.Is_Voucher_No_Print, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);


            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataSet Get_Trading_Account(ReportParams_Property pClsProperty, string pStrSPName) //Khushbu 22/04/2014
        {
            DataSet DS = new DataSet();

            Request Request = new Request();
            Request.REF_CUR_OUT = 2;
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");
            //else
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "", Request, "");

            return DS;
        }

        public DataTable Get_Profit_and_Loss(ReportParams_Property pClsProperty, string pStrSPName) //Chitranjan on Dated : 15/04/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName+"_LEV"; // MODIFY ; NARENDRA ; 18-FEB-2015
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        /* PROFIT & LOSS COMMETED : NARENDRA : 19-11-2014
        public DataTable GenerateProfitLossreport(DataTable DTab, string pStrReportTYpe) //Khushbu 08/07/2014
        {
           
            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));


            DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

            DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
            DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
            DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
            DataTable DTabFilterIncome = DTab.DefaultView.ToTable();
            

            // Add Code By Khushbu 07/09/2014 ---- //
            if (DTabFilterExpense.Rows.Count > 0)
            {
                if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabExpense.Rows.Add(DRNew);

                    DTabExpense.Rows.Add("", "", "");
                }
            }

            if (DTabFilterIncome.Rows.Count > 0)
            {
                if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabIncome.Rows.Add(DRNew);

                    DTabIncome.Rows.Add("", "", "");

                    
                }
            }

            DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            foreach (DataRow DRowType in DTAb.Rows)
            {
                if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1)
                {
                    DataRow DTNewRow = DTAccountType.NewRow();
                    DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                    DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                    DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
                    DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                    DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

                    DTAccountType.Rows.Add(DTNewRow);
                }
            }
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///


            // ----------------------- FOR EXPENSE -------------------------//

            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DTabFilterExpense);

            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                if (DTView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;

                        DataTable DTabSub = DTView.ToTable();
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            DataRow DRNew = DTabExpense.NewRow();

                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                            Double DouAmount = 0,DouOpening = 0;

                            DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                            DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);
                        }                        
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++;
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {

                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                            DRNew["EXPENSE_DETAIL_MODE"] = "";

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);
                            
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;

                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));

                        DataRow DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_DETAIL_MODE"] = "";

                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["EXPENSE_AMOUNT"] = DouAmount;
                        DTabExpense.Rows.Add(DRNew);

                    }
                }
            }

            // ---------------- FOR INCOME ---------------------------------

            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DTabFilterIncome);
            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                if (DTIncomeView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;

                        DataTable DTabSub = DTIncomeView.ToTable();
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            DataRow DRNew = DTabIncome.NewRow();

                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                            Double DouAmount = 0, DouOpening = 0;

                            DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                            DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }


                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"]=DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", ""));

                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));

                        IntIncomeRNO++;

                        DataRow DRNew = DTabIncome.NewRow();
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_SRNO"] = IntIncomeRNO;
                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_DETAIL_MODE"] = "";

                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["INCOME_AMOUNT"] = DouAmount;
                        DTabIncome.Rows.Add(DRNew);

                    }
                }
            }

            double DouGrossDiff = 0;

            double DouExpenseOpening = 0;
            double DouExpenseAmount = 0;
            double DouIncomeOpening = 0;
            double DouIncomeAmount = 0;

            double DouLastExpenseGrossProfit = 0;
            double DouLastIncomeGrossProfit = 0;
            double DouLastExpenseAmount = 0;
            double DouLastIncomeAmount = 0;

            for (int IntI = 0; IntI < 5; IntI++)
            {
                DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
                DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

                int Diff = UDRowExpense.Count() - UDRowIncome.Count();

                DouExpenseOpening = 0;
                DouExpenseAmount = 0;
                DouIncomeOpening = 0;
                DouIncomeAmount = 0;

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                        DRNew["EXPENSE_AMOUNT"] = "";

                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["INCOME_OPENING_AMOUNT"] = "";
                        DRNew["INCOME_AMOUNT"] = "";

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator (UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                    }
                }
                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowExpense.Count())
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                            DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        }
                        else
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";                            
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowIncome.Count())
                        {
                            DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        }
                        else
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.SetCrDr(DouExpenseOpening,true);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.SetCrDr(DouIncomeOpening, true);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                        DTabCombine.Rows.Add(DRNew);

                        DouGrossDiff += DouIncomeAmount - DouExpenseAmount;


                        if (IntI<3 && DouGrossDiff > 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouIncomeAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouIncomeAmount;
                            }
                            else
                            {
                                DouLastExpenseGrossProfit = DouGrossDiff;
                                DouLastIncomeGrossProfit = DouGrossDiff;
                            }
                            
                            

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff < 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouExpenseAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouExpenseAmount;

                            }
                            else
                            {
                                DouLastExpenseGrossProfit = (DouGrossDiff * -1);
                                DouLastIncomeGrossProfit = (DouGrossDiff * -1);

                            }

                           
                            //DouLastIncomeGrossProfit = DouGrossDiff + DouIncomeAmount - DouExpenseAmount;
                            
                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS c/o";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff*-1);

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;
                    }
                }
            }

            double DblSumIncome = Val.ToDouble(DTabFilterIncome.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DTabFilterExpense.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));

            if (DblSumIncome - DblSumExpense > 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);
                
                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense));

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);
                

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DTabCombine.Rows.Add(DRNew);
                
            }

            else if (DblSumIncome - DblSumExpense < 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "NET LOSS TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense - DblSumIncome));
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DTabCombine.Rows.Add(DRNew);
            }


            DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);

            return DTabCombine;
        }
        */

        // RENAME ; NARENDRA : 18-FEB-2015 
        public DataTable GenerateProfitLossreport_OLD(DataTable DTab, string pStrReportTYpe) //Khushbu 08/07/2014
        {

            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));


            DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

            DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
            DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
            DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
            DataTable DTabFilterIncome = DTab.DefaultView.ToTable();


            // Add Code By Khushbu 07/09/2014 ---- //
            if (DTabFilterExpense.Rows.Count > 0)
            {
                if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabExpense.Rows.Add(DRNew);

                    DTabExpense.Rows.Add("", "", "");
                }
            }

            if (DTabFilterIncome.Rows.Count > 0)
            {
                if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabIncome.Rows.Add(DRNew);

                    DTabIncome.Rows.Add("", "", "");


                }
            }

            //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            //foreach (DataRow DRowType in DTAb.Rows)
            //{
            //    if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1)
            //    {
            //        DataRow DTNewRow = DTAccountType.NewRow();
            //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
            //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
            //        DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
            //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
            //        DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

            //        DTAccountType.Rows.Add(DTNewRow);
            //    }
            //}
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///


            // ----------------------- FOR EXPENSE -------------------------//

            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DTabFilterExpense);

            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                if (DTView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;

                        DataTable DTabSub = DTView.ToTable();
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            DataRow DRNew = DTabExpense.NewRow();

                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                            Double DouAmount = 0, DouOpening = 0;

                            DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                            DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++;
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE");                        
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {

                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DataRow DRNew = DTabExpense.NewRow();
                            //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                            //DRNew["EXPENSE_DETAIL_MODE"] = ""; //Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);

                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;

                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                        DataRow DRNew = DTabExpense.NewRow();
                        //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DR["ACCOUNT_TYPE_CODE"];// DTView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        //DRNew["EXPENSE_DETAIL_MODE"] = ""; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_DETAIL_MODE"] = "GROUP";// DR["DETAIL_MODE"]; // Add : Narendra : 19-11-2014

                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["EXPENSE_AMOUNT"] = DouAmount;
                        DTabExpense.Rows.Add(DRNew);

                    }
                }
            }

            // ---------------- FOR INCOME ---------------------------------

            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DTabFilterIncome);
            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                if (DTIncomeView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;

                        DataTable DTabSub = DTIncomeView.ToTable();
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            DataRow DRNew = DTabIncome.NewRow();

                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                            Double DouAmount = 0, DouOpening = 0;

                            DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                            DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        //DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME"); // Commeted : Narendra : 19-11-2014
                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE"); // Add : Narendra : 19-11-2014

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }


                            DataRow DRNew = DTabIncome.NewRow();
                            //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add :Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", ""));
                        
                        /* // Add : Narendra : 19-11-2014*/
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + "")); 
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));
                        
                        // Add : Narendra : 19-11-2014
                        double DouOpeningAmount = Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        // End : Narendra : 19-11-2014

                        IntIncomeRNO++;

                        DataRow DRNew = DTabIncome.NewRow();
                        //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted: Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_CODE"] = DTIncomeView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_SRNO"] = IntIncomeRNO;
                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                       //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                        DRNew["INCOME_DETAIL_MODE"] = "GROUP";// Add : Narendra : 19-11-2014

                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["INCOME_AMOUNT"] = DouAmount;
                        DTabIncome.Rows.Add(DRNew);

                    }
                }
            }

            double DouGrossDiff = 0;

            double DouExpenseOpening = 0;
            double DouExpenseAmount = 0;
            double DouIncomeOpening = 0;
            double DouIncomeAmount = 0;

            double DouLastExpenseGrossProfit = 0;
            double DouLastIncomeGrossProfit = 0;
            double DouLastExpenseAmount = 0;
            double DouLastIncomeAmount = 0;

            for (int IntI = 0; IntI < 5; IntI++)
            {
                DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
                DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

                int Diff = UDRowExpense.Count() - UDRowIncome.Count();

                DouExpenseOpening = 0;
                DouExpenseAmount = 0;
                DouIncomeOpening = 0;
                DouIncomeAmount = 0;

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                        DRNew["EXPENSE_AMOUNT"] = "";

                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["INCOME_OPENING_AMOUNT"] = "";
                        DRNew["INCOME_AMOUNT"] = "";

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                    }
                }
                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowExpense.Count())
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                            DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        }
                        else
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowIncome.Count())
                        {
                            DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        }
                        else
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.SetCrDr(DouExpenseOpening, true);
                        DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.SetCrDr(DouIncomeOpening, true);
                        DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);

                        DTabCombine.Rows.Add(DRNew);

                        DouGrossDiff += DouIncomeAmount - DouExpenseAmount;


                        if (IntI < 3 && DouGrossDiff > 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouIncomeAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouIncomeAmount;
                            }
                            else
                            {
                                DouLastExpenseGrossProfit = DouGrossDiff;
                                DouLastIncomeGrossProfit = DouGrossDiff;
                            }



                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff < 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouExpenseAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouExpenseAmount;

                            }
                            else
                            {
                                DouLastExpenseGrossProfit = (DouGrossDiff * -1);
                                DouLastIncomeGrossProfit = (DouGrossDiff * -1);

                            }


                            //DouLastIncomeGrossProfit = DouGrossDiff + DouIncomeAmount - DouExpenseAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS c/o";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;
                    }
                }
            }

            double DblSumIncome = Val.ToDouble(DTabFilterIncome.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DTabFilterExpense.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));

            if (DblSumIncome - DblSumExpense > 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense));

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DTabCombine.Rows.Add(DRNew);

            }

            else if (DblSumIncome - DblSumExpense < 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "NET LOSS TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense - DblSumIncome));
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DTabCombine.Rows.Add(DRNew);
            }

            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);

            // Add : Narendra : 19-11-2014
            if (pStrReportTYpe != "ACCOUNT_TYPE")
            {
                DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            }

            return DTabCombine;
        }

        public int pIntCompanyCode, pIntBranchCode, pIntLocationCode;
        public string pStrStartDate, pStrFromDate;
        public bool boolDetails = false;
        public DataTable GenerateProfitLossreport(DataTable DTab, string pStrReportTYpe) //MODIFY ; NARENDRA ; 18-FEB-2015 ;; FOR DISPLAY REPORT LEVEL WISE
        {

            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

            DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
          

            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

           


            DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
            DTab.DefaultView.RowFilter = "TYPE = 'INCOME'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterIncome = DTab.DefaultView.ToTable();


            // Add Code By Khushbu 07/09/2014 ---- //
            if (DTabFilterExpense.Rows.Count > 0)
            {
                if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabExpense.Rows.Add(DRNew);

                    DTabExpense.Rows.Add("", "", "");
                }
            }

            if (DTabFilterIncome.Rows.Count > 0)
            {
                if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabIncome.Rows.Add(DRNew);

                    DTabIncome.Rows.Add("", "", "");


                }
            }

           // DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            //foreach (DataRow DRowType in DTAb.Rows)
            //{
            //    if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0)
            //    {
            //        DataRow DTNewRow = DTAccountType.NewRow();
            //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
            //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
            //        DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
            //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
            //        DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

            //        DTAccountType.Rows.Add(DTNewRow);
            //    }
            //}
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///


            // ----------------------- FOR EXPENSE -------------------------//

            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DTabFilterExpense);

            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                double DouOpenig = 0;

                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                if (DTView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;

                        DataTable DTabSub = DTView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();

                        DataRow DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                        DRNew["EXPENSE_AMOUNT"] = 0;

                        //if (boolDetails)
                            DTabExpense.Rows.Add(DRNew);

                        double DouAccType_TotalAmt = 0.00;

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabExpense.NewRow();
                                DRNew = DTabExpense.NewRow();

                                DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["EXPENSE_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND   LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                DouOpening = Val.Val(DTab.Compute("Sum(OPENING_AMOUNT)", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                // Commented : Narendra : 31-July-2015
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate)*-1;
                                // Add ; Narendra : 31-July-2015
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015

                                DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                DRNew["EXPENSE_AMOUNT"] = DouAmount; // Commented : Narendra : 21/July/2015
                                //DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;
                                //DTabExpense.Rows.Add(DRNew);

                                // Commented : Narendra ; 31-Jul-2015
                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                // Add : Narendra ; 31-Jul-2015
                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount;


                                //if (boolDetails)
                                {
                                    if (DouAmount != 0 || DouOpening != 0)
                                    {                                        
                                        DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF LEDGER
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                DataTable DTabGroupDistinct = new DataTable();

                                if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                {
                                    DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO ASC";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        // DataRow[] UDRowGroup = DTab.Select("TYPE_LEVEL=2 AND   UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");

                                        
                                        double DouAmount = 0, DouGrpTotal = 0.00;
                                        if (UDRowGroup != null && UDRowGroup.Count() > 0)
                                        {
                                            DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                DouOpenig = 0;

                                                //DRNew = DTabExpense.NewRow();
                                                //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                //DTabSub
                                                DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT))", "DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + "")); //TYPE_LEVEL=2 AND  
                                                //DouOpenig = Val.Val(DTab.Compute("Sum(OPENING_AMOUNT)", " DETAIL_MODE='LEDGER' AND   LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                                // Commented : Narendra : 31-July-2015
                                                //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                                // Add : Narendra : 31-July-2015
                                            //    DouOpenig =  FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                                // Add : Narendra : 31-July-2015
                                                
                                                DouAmount += DouOpenig;

                                                // Add : Narendra : 31-July-2015

                                                //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;

                                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount; // Add : Narendra : 31-July-2015

                                                //DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount; // COMMENTED ; NARENDRA ; 21/JULY/2015
                                                DouGrpTotal = DouGrpTotal + DouAmount; // Commented ; Narendra ; 31-July-2015

                                                // DTabExpense.Rows.Add(DRNew);
                                            }
                                        }
                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) +1;

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                        //if (boolDetails)
                                            DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }
                        }// END OF DISTINCT LEDGER FOR EACH...

                        DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                        //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                        DTabExpense.Rows.Add(DRNew);
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++;
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE");
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {

                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DataRow DRNew = DTabExpense.NewRow();
                            //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                            //DRNew["EXPENSE_DETAIL_MODE"] = ""; //Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);

                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;

                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                        DataRow DRNew = DTabExpense.NewRow();
                        //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DR["ACCOUNT_TYPE_CODE"];// DTView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        //DRNew["EXPENSE_DETAIL_MODE"] = ""; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_DETAIL_MODE"] = "GROUP";// DR["DETAIL_MODE"]; // Add : Narendra : 19-11-2014

                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["EXPENSE_AMOUNT"] = DouAmount;
                        DTabExpense.Rows.Add(DRNew);

                    }
                }
            }

            // ---------------- FOR INCOME ---------------------------------

            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DTabFilterIncome);
            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                if (DTIncomeView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;

                        DataTable DTabSub = DTIncomeView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();


                        DataRow DRNew = DTabIncome.NewRow();
                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["INCOME_OPENING_AMOUNT"] = 0;
                        DRNew["INCOME_AMOUNT"] = 0;
                        //if (boolDetails)
                            DTabIncome.Rows.Add(DRNew);

                        double DouIncomeTot = 0.00;


                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabIncome.NewRow();
                                DRNew = DTabIncome.NewRow();

                                DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;
                                // Commented : Narendra : 19-Aug-2015
                                //DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                // Add : Narendra : 19-Aug-2015
                                DouAmount = Val.Val(DTab.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                //DouOpening = Val.Val(DTab.Compute("Sum(OPENING_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                // Commented : Narendra : 31-July-2015 :: Un-Commented : Narendra : 19-Aug-2015
                               // DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate) * -1;
                                // Add : Narendra ; 31-July-2015 :: Commented : Narendra : 19-Aug-2015
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015
                              
                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                DRNew["INCOME_AMOUNT"] = DouAmount;
                                    //DTabIncome.Rows.Add(DRNew);
                                //if (boolDetails)
                                {
                                    if ((DouOpening + DouAmount) != 0)
                                        DTabIncome.Rows.Add(DRNew);
                                }
                            }
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                //DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO");
                                DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                DataTable DTabGroupDistinct = new DataTable();

                                /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                             DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                             : null;*/
                                if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                {
                                    DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            //DTabSub
                                            // Commented : Narendra : 19-Aug-2015
                                            //DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                            // Add : Narendra : 19-Aug-2015
                                            DouAmount = Val.Val(DTab.Compute("(Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                            // Commented : Narendra : 31-July-2015 // Un-Commented : 19-Aug-2015
                                           // DouOpening = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));
                                            // Add : Narendra : 31-July-2015
                                            //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                            //DouOpening = Val.Val(DTabSub.Compute("(Sum(OPENING_AMOUNT) * -1)", " DETAIL_MODE='LEDGER'  AND LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                            // Add : Narendra : 31-July-2015
                                            //DouAmount += DouOpening;                                            
                                            DouAmount += DouOpening;

                                            DouIncomeTot = DouIncomeTot + DouAmount;
                                            DouGrpTotal = DouGrpTotal +  DouAmount;
                                            // Add : Narendra : 31-July-2015

                                            // Commented : Narendra : 31-July-2015
                                            //DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            //DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;

                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        //if (boolDetails)
                                            DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF GROUP 

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        //DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME"); // Commeted : Narendra : 19-11-2014
                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE"); // Add : Narendra : 19-11-2014

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }


                            DataRow DRNew = DTabIncome.NewRow();
                            //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add :Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", ""));

                        /* // Add : Narendra : 19-11-2014*/
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + "")); 
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));

                        // Add : Narendra : 19-11-2014
                        double DouOpeningAmount = Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        // End : Narendra : 19-11-2014

                        IntIncomeRNO++;

                        DataRow DRNew = DTabIncome.NewRow();
                        //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted: Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_CODE"] = DTIncomeView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_SRNO"] = IntIncomeRNO;
                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                        DRNew["INCOME_DETAIL_MODE"] = "GROUP";// Add : Narendra : 19-11-2014

                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["INCOME_AMOUNT"] = DouAmount;
                        DTabIncome.Rows.Add(DRNew);

                    }
                }
            }

            double DouGrossDiff = 0;

            double DouExpenseOpening = 0;
            double DouExpenseAmount = 0;
            double DouIncomeOpening = 0;
            double DouIncomeAmount = 0;

            double DouLastExpenseGrossProfit = 0;
            double DouLastIncomeGrossProfit = 0;
            double DouLastExpenseAmount = 0;
            double DouLastIncomeAmount = 0;

            for (int IntI = 0; IntI < 5; IntI++)
            {
                DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
                DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

                int Diff = UDRowExpense.Count() - UDRowIncome.Count();

                DouExpenseOpening = 0;
                DouExpenseAmount = 0;
                DouIncomeOpening = 0;
                DouIncomeAmount = 0;

                //if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0) // Commented : Narendra : 27-May-2015
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();
                        if (UDRowExpense.Count() != 0) // Add If Condition : Narendra : 27-May-2015
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        if (UDRowIncome.Count() != 0) // Add : Narendra : 27-May-2015
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }
                        if(boolDetails) // ADD ; NARENDRA ; 19-FEB-2015
                            DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        // commented ; Narendra ; 21/July/2015
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_OPENING_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        // Add ; Narendra : 18-Feb-2015 //
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]); //commented ; narendra ; 21/july/2015
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]); // commented ; narendra ; 21/july/2015
                        DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        // Add ; Narendra : 18-Feb-2015
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 
                            DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                    }
                }
                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowExpense.Count())
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                            // Add ; Narendra : 18-Feb-2015
                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                            DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                            //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // commented ; narendra ; 21/July/2015
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                            // Add : Narendra : 18-Feb-2015 

                            DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);


                        }
                        else
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        // Add ; Narendra : 18-Feb-2015
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);


                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 ;; 
                         DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowIncome.Count())
                        {
                            DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                            //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            // Add ; Narendra : 18-Feb-2015
                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                            DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                            //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                            // Add : Narendra : 18-Feb-2015

                            DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        }
                        else
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_OPENING_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        // Add ; Narendra : 18-Feb-2015
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);


                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 (Val.Val() < 0 ? "(-) " : string.Empty) +
                            DTabCombine.Rows.Add(DRNew);
                    }
                }

                //if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0) // Commented : Narendra : 28/May/2015
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (UDRowExpense.Count() != 0) // Add If Condition : Narendra : 28-May-2015
                        {
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.SetCrDr(DouExpenseOpening, true);
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);// ADD ; NARENDRA ; 19-FEB-2015
                        }
                        if (UDRowIncome.Count() != 0)
                        {
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.SetCrDr(DouIncomeOpening, true);
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount); // ADD ; NARENDRA ; 19-FEB-2015
                        }
                        DTabCombine.Rows.Add(DRNew);

                        // Add : Narendra : 04-Aug-2015
                        if (DouIncomeAmount < 0)
                            DouIncomeAmount = DouIncomeAmount * -1;
                        if (DouExpenseAmount < 0)
                            DouExpenseAmount = DouExpenseAmount * -1;
                        // End : Narendra ; 04-Aug-2015

                        DouGrossDiff += (DouIncomeAmount - DouExpenseAmount);


                        if (IntI < 3 && DouGrossDiff > 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouIncomeAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouIncomeAmount;
                            }
                            else
                            {
                                DouLastExpenseGrossProfit = DouGrossDiff;
                                DouLastIncomeGrossProfit = DouGrossDiff;
                            }



                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff); // ADD ;NARENDRA ; 19-FEB-2015

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);//ADD ; NARENDRA ; 19-FEB-2015

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff < 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouExpenseAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouExpenseAmount;

                            }
                            else
                            {
                                DouLastExpenseGrossProfit = (DouGrossDiff * -1);
                                DouLastIncomeGrossProfit = (DouGrossDiff * -1);

                            }


                            //DouLastIncomeGrossProfit = DouGrossDiff + DouIncomeAmount - DouExpenseAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS c/o";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1); // ADD ; NARENDRA ; 19-FEB-2015

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1); // ADD ; NARENDRA ; 19-FEB-2015

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;
                    }
                }
            }

            //double DblSumIncome = Val.ToDouble(DTabFilterIncome.Compute("SUM(DEBIT_AMOUNT)-SUM(CREDIT_AMOUNT)", " DETAIL_MODE = 'LEDGER' "));
            //double DblSumExpense = Val.ToDouble(DTabFilterExpense.Compute("SUM(DEBIT_AMOUNT)-SUM(CREDIT_AMOUNT)", " DETAIL_MODE = 'LEDGER' "));
            double DblSumIncome = Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""));
            //double DblSumIncome = Val.ToDouble(DTab.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", " TYPE = 'INCOME' AND DETAIL_MODE = 'LEDGER' "));
            //double DblSumExpense = Val.ToDouble(DTab.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", " TYPE = 'EXPENSE' AND DETAIL_MODE = 'LEDGER' "));

            // aDD : Narendra : 04-Aug-2015
            if (DblSumIncome < 0)
                DblSumIncome = DblSumIncome * -1;

            if (DblSumExpense < 0)
                DblSumExpense = DblSumExpense * -1;

            if (DblSumIncome - DblSumExpense > 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense));
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense)); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);

            }

            else if (DblSumIncome - DblSumExpense < 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "NET LOSS TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense - DblSumIncome));
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense)); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);
            }

            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);

            // Add : Narendra : 19-11-2014
            if (pStrReportTYpe != "ACCOUNT_TYPE")
            {
                if (DTabCombine.Rows.Count > 5)
                {
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                }
            }

            return DTabCombine;
        }

        public DataTable GenerateProfitLossreport_LINQ(DataTable DTab, string pStrReportTYpe) //MODIFY ; NARENDRA ; 18-FEB-2015 - 01-OCT-2015 ;; FOR DISPLAY REPORT LEVEL WISE
        {

            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

            DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));


            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));




            /* COMMENTED ; NARENDRA ; 01-OCT-2015
             * DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
            DTab.DefaultView.RowFilter = "TYPE = 'INCOME'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterIncome = DTab.DefaultView.ToTable();*/

            // FILTER WITH ONLU EXPENSE TYPE DATA
            var QueryExpense = from row in DTab.AsEnumerable()
                               where row.Field<string>("TYPE") == "EXPENSE" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                               select row;
            DataTable DTabFilterExpense = DTab.Clone();
            DTabFilterExpense = QueryExpense.Count() > 0 ? QueryExpense.CopyToDataTable() : null;

            // FILTER WITH ONLU INCOME TYPE DATA
            var QueryIncome = from row in DTab.AsEnumerable()
                              where row.Field<string>("TYPE") == "INCOME" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                              select row;
            DataTable DTabFilterIncome = DTab.Clone();
            DTabFilterIncome = QueryIncome.Count() > 0 ? QueryIncome.CopyToDataTable() : null;



            // Add Code By Khushbu 07/09/2014 ---- //
            if (DTabFilterExpense.Rows.Count > 0)
            {
                if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabExpense.Rows.Add(DRNew);

                    DTabExpense.Rows.Add("", "", "");
                }
            }

            if (DTabFilterIncome.Rows.Count > 0)
            {
                if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabIncome.Rows.Add(DRNew);

                    DTabIncome.Rows.Add("", "", "");


                }
            }

            //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            //foreach (DataRow DRowType in DTAb.Rows)
            //{
            //    if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0)
            //    {
            //        DataRow DTNewRow = DTAccountType.NewRow();
            //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
            //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
            //        DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
            //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
            //        DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

            //        DTAccountType.Rows.Add(DTNewRow);
            //    }
            //}
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///

            // ADD ; NARENDRA ; 05-OCT-2015
            string[] StrAccountTypeCode = Val.Trim("12,13,14,15").Split(','); // 12=Direct Income, 13=Direct Expense, 14=Indirect Income, 15=Indirect Expense :: Opening Balance Are Not Comes On Report, Which Ledger Belongs To this Group Or Its Sub Groups.
            string AccountTypeCode = string.Empty;
            for (int i = 0; i < StrAccountTypeCode.Length; i++)
            {
                if (StrAccountTypeCode[i].Trim().Equals(string.Empty))
                    continue;

                string StrAccountType = Val.ToString(StrAccountTypeCode[i]);
                DataTable DTTemp = Get_Tree_Account_Type_Master(StrAccountType);
                foreach (DataRow DrowAcc in DTTemp.Rows)
                {
                    AccountTypeCode = AccountTypeCode + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                }

            }
            if (AccountTypeCode.Length > 1)
                AccountTypeCode = "," + AccountTypeCode;
            // END ; NARENDRA ; 05-OCT-2015

            // ADD ; NARENDRA ; 01-OCT-2015 ::  CALCULATE LEDGER CR/DR BALANCE...
            var QueryLedgerAmount = DTab.AsEnumerable()
           .GroupBy(w => new
           {
               LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
               DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
           })
           .Select(x => new
           {
               DETAIL_MODE = x.Key.DETAIL_MODE,
               LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
               AMOUNT = Val.Val((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

           })
           .Where(A => A.DETAIL_MODE == "LEDGER");

            DataTable DtTempAmount = new DataTable();
            if (QueryLedgerAmount.Count() > 0)
            {
                DtTempAmount = LINQToDataTable(QueryLedgerAmount);
            }

            // GET ALL LEDGER OPENING BALANCE 
            DataTable DTabOpeningAmount = new DataTable();
            DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(pStrFromDate));
            // End : Narendra : 01-OCT-2015

            // ----------------------- FOR EXPENSE -------------------------//

            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DTabFilterExpense);

            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                double DouOpenig = 0;
                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];

                // Add : Narendra : 28-Sep-2015
                var QueryDTView = (from row in DTabFilterExpense.AsEnumerable()
                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DR["ACCOUNT_TYPE_CODE"])
                                   orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                   select new
                                   {
                                       LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                       LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                       DETAIL_MODE = (string)row["DETAIL_MODE"],
                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                   }
                                 )
                                .Distinct();

                //if (DTView.ToTable().Rows.Count > 0)
                if(QueryDTView.Count() > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;

                        DataTable DTabDistinct = LINQToDataTable(QueryDTView); // Add : Narendra : 28-Sep-2015

                        /*DataTable DTabSub = DTView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();*/

                        DataRow DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                        DRNew["EXPENSE_AMOUNT"] = 0;

                        //if (boolDetails)
                        DTabExpense.Rows.Add(DRNew);

                        double DouAccType_TotalAmt = 0.00;

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabExpense.NewRow();
                                DRNew = DTabExpense.NewRow();

                                DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["EXPENSE_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                
                                // Add ; Narendra : 01-Oct-2015
                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                if (rows != null && rows.Count() > 0)
                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                {
                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);
                                }
                                // End : Narendra : 01-Oct-2015

                                /*DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND   LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                DouOpening = Val.Val(DTab.Compute("Sum(OPENING_AMOUNT)", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);
                                */
                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015

                                DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                DRNew["EXPENSE_AMOUNT"] = DouAmount; // Commented : Narendra : 21/July/2015
                                //DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;
                                //DTabExpense.Rows.Add(DRNew);

                                // Commented : Narendra ; 31-Jul-2015
                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                // Add : Narendra ; 31-Jul-2015
                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount;


                                //if (boolDetails)
                                {
                                    if (DouAmount != 0 || DouOpening != 0)
                                    {
                                        DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF LEDGER
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                // Add : Narendra : 28-Sep-2015
                                var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                               orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                               select new
                                                               {
                                                                   ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                   UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                   ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                   ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                   TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                               }).Distinct();
                                DataTable DTabGroupDistinct = QueryUDRowGroupDistinct.Count() > 0 ? LINQToDataTable(QueryUDRowGroupDistinct) : null;
                                // Add : Narendra : 28-Sep-2015

                                /* Commented : Narendra : 01-Oct-2015
                                 * DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                DataTable DTabGroupDistinct = new DataTable();*/

                                //if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                if(DTabGroupDistinct != null && DTabGroupDistinct.Rows.Count > 0)
                                {
                                    /*
                                    DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO ASC";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();*/

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        // Add : Narendra : 28-Sep-2015
                                        var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) //|| row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                               select new
                                                               {
                                                                   LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                   LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                               })
                                                              .Distinct();
                                        DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                        // Add : Narendra : 28-Sep-2015

                                        //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        // DataRow[] UDRowGroup = DTab.Select("TYPE_LEVEL=2 AND   UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");


                                        double DouAmount = 0, DouGrpTotal = 0.00;
                                        DouOpenig = 0;
                                        //if (UDRowGroup != null && UDRowGroup.Count() > 0)
                                        if(DTabGroupLedgerDistinct != null && DTabGroupLedgerDistinct.Rows.Count > 0) // Add : Narendra : 01-Oct-2015
                                        {
                                            

                                            //DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME"); // Commented  Narend;ra ; 
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                DouOpenig = 0;

                                                //DRNew = DTabExpense.NewRow();
                                                //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                //DTabSub
                                                DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT))", "DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + "")); //TYPE_LEVEL=2 AND                                                 
                                                
                                                // COMMENTED ; NARENDRA ; 05-OCT-2015
                                                //DouOpenig = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                                DouAmount = 0.00;
                                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rows != null && rows.Count() > 0)
                                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                                {
                                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                                        DouOpenig = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);
                                                }
                                                // Add : Narendra : 31-July-2015

                                                DouAmount += DouOpenig;

                                                // Add : Narendra : 31-July-2015

                                                //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;

                                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount; // Add : Narendra : 31-July-2015

                                                //DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount; // COMMENTED ; NARENDRA ; 21/JULY/2015
                                                DouGrpTotal = DouGrpTotal + DouAmount; // Commented ; Narendra ; 31-July-2015

                                                // DTabExpense.Rows.Add(DRNew);
                                            }
                                        }
                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                        //if (boolDetails)
                                        DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }
                        }// END OF DISTINCT LEDGER FOR EACH...

                        DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                        //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                        DTabExpense.Rows.Add(DRNew);
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++;
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE");
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {

                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DataRow DRNew = DTabExpense.NewRow();
                            //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                            //DRNew["EXPENSE_DETAIL_MODE"] = ""; //Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);

                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;

                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                        DataRow DRNew = DTabExpense.NewRow();
                        //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DR["ACCOUNT_TYPE_CODE"];// DTView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        //DRNew["EXPENSE_DETAIL_MODE"] = ""; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_DETAIL_MODE"] = "GROUP";// DR["DETAIL_MODE"]; // Add : Narendra : 19-11-2014

                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["EXPENSE_AMOUNT"] = DouAmount;
                        DTabExpense.Rows.Add(DRNew);

                    }
                }
            }

            // ---------------- FOR INCOME ---------------------------------

            // Add : Narendra : 01-Oct-2015
            var QueryLedgerAmountIncome = DTab.AsEnumerable()
           .GroupBy(w => new
           {
               LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
               DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
           })
           .Select(x => new
           {
               DETAIL_MODE = x.Key.DETAIL_MODE,
               LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
               //AMOUNT = Val.ToString((x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("DEBIT_AMOUNT"))))) - x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("CREDIT_AMOUNT")))))) * -1),
               AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))))),

           })
           .Where(A => A.DETAIL_MODE == "LEDGER");

            DtTempAmount = new DataTable();
            if (QueryLedgerAmountIncome.Count() > 0)
            {
                DtTempAmount = LINQToDataTable(QueryLedgerAmountIncome);
            }

            // End : Narendra : 29-Sep-2015
            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DTabFilterIncome);
            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                // Add : Narendra : 29-Sep-2015
                var QueryDTIncomeView = (from row in DTabFilterIncome.AsEnumerable()
                                         where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"])
                                         orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                         select new
                                         {
                                             LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                             LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                             ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                             ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                             UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                             DETAIL_MODE = (string)row["DETAIL_MODE"],
                                             TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                             ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                         }
                                   )
                                  .Distinct();

                // DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"]; // Commented ; Narendra : 01-Oct-2015
                //if (DTIncomeView.ToTable().Rows.Count > 0) // Commented ; Narendra ; 01-Sep-2015
                if (QueryDTIncomeView.Count() > 0) // ADD ; NARENDRA ; 01-Sep-2015
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;

                        DataTable DTabDistinct = LINQToDataTable(QueryDTIncomeView); // ADD ; NARENDRA ; 29-SEP-2015

                        /* Commented : Narendra : 01-Oct-2015
                         * DataTable DTabSub = DTIncomeView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();*/


                        DataRow DRNew = DTabIncome.NewRow();
                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["INCOME_OPENING_AMOUNT"] = 0;
                        DRNew["INCOME_AMOUNT"] = 0;
                        //if (boolDetails)
                        DTabIncome.Rows.Add(DRNew);

                        double DouIncomeTot = 0.00;


                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabIncome.NewRow();
                                DRNew = DTabIncome.NewRow();

                                DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                if (rows != null && rows.Count() > 0)
                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                // Commented : Narendra : 01-Oct-2015
                                //DouAmount = Val.Val(DTab.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                
                                // Commented : Narendra 
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate) * -1;
                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                {
                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;
                                }
                                // Add : Narendra ; 31-July-2015 :: Commented : Narendra : 19-Aug-2015
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                DRNew["INCOME_AMOUNT"] = DouAmount;
                                //DTabIncome.Rows.Add(DRNew);
                                //if (boolDetails)
                                {
                                    if ((DouOpening + DouAmount) != 0)
                                        DTabIncome.Rows.Add(DRNew);
                                }
                            }
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                // Commented ; Narendra ; 01-Oct-2015
                                //DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                               orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                               select new
                                                               {
                                                                   ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                   UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                   ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                   ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                   TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                               }).Distinct();

                                DataTable DTabGroupDistinct = new DataTable();

                                /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                             DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                             : null;*/
                                // if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0) // Commented : Narendra : 01-Oct-2015
                                if (QueryUDRowGroupDistinct.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015                                
                                {
                                    DTabGroupDistinct = LINQToDataTable(QueryUDRowGroupDistinct); // ADD ; NARENDRA ; 29-SEP-2015

                                    /*DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();*/

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        // Commented : Narendra ; 01-Oct-2015
                                        //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        //DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        // Add : Narendra : 28-Sep-2015
                                        var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                               select new
                                                               {
                                                                   LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                   LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                               })
                                                              .Distinct();
                                        DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                        // Add : Narendra : 28-Sep-2015

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouAmount = 0.00;
                                            IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRow["LEDGER_CODE"]));
                                            if (rows != null && rows.Count() > 0)
                                                DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                            DouOpening = 0;
                                            if (!AccountTypeCode.Contains("," + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                            {
                                                IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rowsOpening != null && rowsOpening.Count() > 0)
                                                    DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;
                                            }
                                            // Commented  : Narendra ; 01-Oct-2015
                                            //DouAmount = Val.Val(DTab.Compute("(Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                            //DouOpening = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                            // Add : Narendra : 31-July-2015
                                            //DouAmount += DouOpening;                                            
                                            DouAmount += DouOpening;

                                            DouIncomeTot = DouIncomeTot + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouAmount;
                                            // Add : Narendra : 31-July-2015

                                            // Commented : Narendra : 31-July-2015
                                            //DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            //DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;

                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        //if (boolDetails)
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF GROUP 

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        //DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME"); // Commeted : Narendra : 19-11-2014
                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE"); // Add : Narendra : 19-11-2014

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }


                            DataRow DRNew = DTabIncome.NewRow();
                            //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add :Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", ""));

                        /* // Add : Narendra : 19-11-2014*/
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + "")); 
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));

                        // Add : Narendra : 19-11-2014
                        double DouOpeningAmount = Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        // End : Narendra : 19-11-2014

                        IntIncomeRNO++;

                        DataRow DRNew = DTabIncome.NewRow();
                        //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted: Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_CODE"] = DTIncomeView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_SRNO"] = IntIncomeRNO;
                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                        DRNew["INCOME_DETAIL_MODE"] = "GROUP";// Add : Narendra : 19-11-2014

                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["INCOME_AMOUNT"] = DouAmount;
                        DTabIncome.Rows.Add(DRNew);

                    }
                }
            }

            double DouGrossDiff = 0;

            double DouExpenseOpening = 0;
            double DouExpenseAmount = 0;
            double DouIncomeOpening = 0;
            double DouIncomeAmount = 0;

            double DouLastExpenseGrossProfit = 0;
            double DouLastIncomeGrossProfit = 0;
            double DouLastExpenseAmount = 0;
            double DouLastIncomeAmount = 0;

            for (int IntI = 0; IntI < 5; IntI++)
            {
                DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
                DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

                int Diff = UDRowExpense.Count() - UDRowIncome.Count();

                DouExpenseOpening = 0;
                DouExpenseAmount = 0;
                DouIncomeOpening = 0;
                DouIncomeAmount = 0;

                //if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0) // Commented : Narendra : 27-May-2015
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();
                        if (UDRowExpense.Count() != 0) // Add If Condition : Narendra : 27-May-2015
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        if (UDRowIncome.Count() != 0) // Add : Narendra : 27-May-2015
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }
                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015
                            DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        // commented ; Narendra ; 21/July/2015
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_OPENING_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        // Add ; Narendra : 18-Feb-2015 //
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]); //commented ; narendra ; 21/july/2015
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]); // commented ; narendra ; 21/july/2015
                        DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        // Add ; Narendra : 18-Feb-2015
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 
                            DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                    }
                }
                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowExpense.Count())
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                            DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                            // Add ; Narendra : 18-Feb-2015
                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                            DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                            //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]); // commented ; narendra ; 21/July/2015
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                            // Add : Narendra : 18-Feb-2015 

                            DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);


                        }
                        else
                        {
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        // Add ; Narendra : 18-Feb-2015
                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                        //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);


                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 ;; 
                            DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowIncome.Count())
                        {
                            DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                            DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                            //DRNew["INCOME_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            DRNew["INCOME_OPENING_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DRNew["INCOME_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                            // Add ; Narendra : 18-Feb-2015
                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = UDRowIncome[IntJ]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                            DRNew["INCOME_TYPE_LEVEL"] = UDRowIncome[IntJ]["INCOME_TYPE_LEVEL"];
                            //DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                            DRNew["INCOME_TOTAL_AMOUNT"] = (Val.Val(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowIncome[IntJ]["INCOME_TOTAL_AMOUNT"]);
                            // Add : Narendra : 18-Feb-2015

                            DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        }
                        else
                        {
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";
                        }

                        DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
                        DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        //DRNew["EXPENSE_OPENING_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DRNew["EXPENSE_OPENING_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DRNew["EXPENSE_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        // Add ; Narendra : 18-Feb-2015
                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = UDRowExpense[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                        DRNew["EXPENSE_TYPE_LEVEL"] = UDRowExpense[IntJ]["EXPENSE_TYPE_LEVEL"];
                        //DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = (Val.Val(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(UDRowExpense[IntJ]["EXPENSE_TOTAL_AMOUNT"]);
                        // Add : Narendra : 18-Feb-2015

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);


                        if (boolDetails) // ADD ; NARENDRA ; 19-FEB-2015 (Val.Val() < 0 ? "(-) " : string.Empty) +
                            DTabCombine.Rows.Add(DRNew);
                    }
                }

                //if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0) // Commented : Narendra : 28/May/2015
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (UDRowExpense.Count() != 0) // Add If Condition : Narendra : 28-May-2015
                        {
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.SetCrDr(DouExpenseOpening, true);
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouExpenseAmount);// ADD ; NARENDRA ; 19-FEB-2015
                        }
                        if (UDRowIncome.Count() != 0)
                        {
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.SetCrDr(DouIncomeOpening, true);
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeAmount); // ADD ; NARENDRA ; 19-FEB-2015
                        }
                        DTabCombine.Rows.Add(DRNew);

                        // Add : Narendra : 04-Aug-2015
                        if (DouIncomeAmount < 0)
                            DouIncomeAmount = DouIncomeAmount * -1;
                        if (DouExpenseAmount < 0)
                            DouExpenseAmount = DouExpenseAmount * -1;
                        // End : Narendra ; 04-Aug-2015

                        DouGrossDiff += (DouIncomeAmount - DouExpenseAmount);


                        if (IntI < 3 && DouGrossDiff > 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouIncomeAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouIncomeAmount;
                            }
                            else
                            {
                                DouLastExpenseGrossProfit = DouGrossDiff;
                                DouLastIncomeGrossProfit = DouGrossDiff;
                            }



                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff); // ADD ;NARENDRA ; 19-FEB-2015

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff);//ADD ; NARENDRA ; 19-FEB-2015

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff < 0)
                        {
                            if (DouLastExpenseGrossProfit != 0)
                            {
                                DouLastExpenseGrossProfit = DouLastExpenseGrossProfit + DouExpenseAmount;
                                DouLastIncomeGrossProfit = DouLastIncomeGrossProfit + DouExpenseAmount;

                            }
                            else
                            {
                                DouLastExpenseGrossProfit = (DouGrossDiff * -1);
                                DouLastIncomeGrossProfit = (DouGrossDiff * -1);

                            }


                            //DouLastIncomeGrossProfit = DouGrossDiff + DouIncomeAmount - DouExpenseAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS c/o";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1); // ADD ; NARENDRA ; 19-FEB-2015

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1);
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossDiff * -1); // ADD ; NARENDRA ; 19-FEB-2015

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;
                    }
                }
            }

            //double DblSumIncome = Val.ToDouble(DTabFilterIncome.Compute("SUM(DEBIT_AMOUNT)-SUM(CREDIT_AMOUNT)", " DETAIL_MODE = 'LEDGER' "));
            //double DblSumExpense = Val.ToDouble(DTabFilterExpense.Compute("SUM(DEBIT_AMOUNT)-SUM(CREDIT_AMOUNT)", " DETAIL_MODE = 'LEDGER' "));
            double DblSumIncome = Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""));
            //double DblSumIncome = Val.ToDouble(DTab.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", " TYPE = 'INCOME' AND DETAIL_MODE = 'LEDGER' "));
            //double DblSumExpense = Val.ToDouble(DTab.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", " TYPE = 'EXPENSE' AND DETAIL_MODE = 'LEDGER' "));

            // aDD : Narendra : 04-Aug-2015
            if (DblSumIncome < 0)
                DblSumIncome = DblSumIncome * -1;

            if (DblSumExpense < 0)
                DblSumExpense = DblSumExpense * -1;

            if (DblSumIncome - DblSumExpense > 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense));
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense)); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit);
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);

            }

            else if (DblSumIncome - DblSumExpense < 0)
            {
                DataRow DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "NET LOSS TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator((DblSumExpense - DblSumIncome));
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator((DblSumIncome - DblSumExpense)); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);

                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                DRNew["EXPENSE_AMOUNT"] = "";

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = "";
                DTabCombine.Rows.Add(DRNew);


                DRNew = DTabCombine.NewRow();
                DRNew["EXPENSE_DETAIL_MODE"] = "";
                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                //DRNew["EXPENSE_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastExpenseGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                //DRNew["INCOME_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit);
                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouLastIncomeGrossProfit); // ADD ; NARENDRA ; 19-FEB-2015
                DTabCombine.Rows.Add(DRNew);
            }

            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);

            // Add : Narendra : 19-11-2014
            if (pStrReportTYpe != "ACCOUNT_TYPE")
            {
                if (DTabCombine.Rows.Count > 5)
                {
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                }
            }

            return DTabCombine;
        }

        public DataTable Get_Day_Book(ReportParams_Property pClsProperty, string pStrSPName) //Khushbu 18/07/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
           
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName,DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        // Add ; Narendra ; 16--mar-2016
        public DataTable Get_Ledger_Columnar_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        // End ; Narendra ; 16--mar-2016

        public DataSet Get_BalanceSheet_ReportData(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataSet DS = new DataSet();
            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("EXPENSE_OR_INCOME_", pClsProperty.Expense_Or_Income, DbType.String, ParameterDirection.Input);
            Request.AddParams("OPE_", pClsProperty.TableName, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.AccountTypeCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_GROUP_CODE_", pClsProperty.AccountTypeGroupCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");
            //else
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "", Request, "");

            return DS;
        }

        public DataTable GetCahsFlowDetail(ReportParams_Property pClsProperty, string pStrName)
        {
            DataTable DTab = new DataTable();
            //DataSet DS = new DataSet();
            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("OPE_", pClsProperty.Transaction_Type, DbType.String, ParameterDirection.Input);

            //Request.CommandText = pStrName; // Commented : Narendra : 14/May/2015
            Request.CommandText = pStrName + "_LEV";// Add : Narendra : 14/May/2015
            Request.REF_CUR_OUT = 2;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Temp, Request, "");

            //return DS;

            return DTab;
        }

        public DataTable GetFundsFlowDetail(ReportParams_Property pClsProperty, string pStrName) // Add : Narendra : 20-Sep-2014
        {
            DataTable DTab = new DataTable();
            
            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
            

            Request.CommandText = pStrName;
            Request.REF_CUR_OUT = 2;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        /*public DataTable GetCahsFlowDetail(ReportParams_Property pClsProperty, string pStrName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("OPE_", pClsProperty.Transaction_Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }*/

        public DataTable GetScoringDetailReport(ReportParams_Property pClsProperty, string pStrName)//ADD : NARENDRA : 01-07-2014
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("CATEGORY_CODE_", pClsProperty.Category_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SARAN_CODE_", pClsProperty.Saran_Code, DbType.Int32, ParameterDirection.Input);
            
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText =  pStrName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Cash_Bank_Book(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 16/07/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();           
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName,DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Ledger_Group_Detail(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 23/07/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_GROUP_CODE_", pClsProperty.Ledger_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.Account_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_GROUP_CODE_", pClsProperty.Account_Type_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("BOOK_CODE_", pClsProperty.Book_Code, DbType.String, ParameterDirection.Input); // Add By Khushbu 03/09/2014

            Request.CommandText = pStrSPName;
            //Request.CommandText = pStrSPName+"_LEV1";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Outstanding_Detail_Report(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 16/09/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            //Request.AddParams("REPORT_TYPE_", pClsProperty.Transaction_Type, DbType.String, ParameterDirection.Input); // Add : Narendra : 21-Aug-2015
           
            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        public DataSet Get_Receipt_Payment_Detail(ReportParams_Property pClsProperty, string pStrSPName) // Khushbu 10/09/2014
        {
            DataSet DS = new DataSet();

            Request Request = new Request();
            Request.REF_CUR_OUT = 2;
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_GROUP_CODE_", pClsProperty.Ledger_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("ACCOUNT_TYPE_CODE_", pClsProperty.Account_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACCOUNT_TYPE_GROUP_CODE_", pClsProperty.Account_Type_Group_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName+"_LEV";
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0) 
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");
            //else
            //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, "", Request, "");

            return DS; ;
        }

        #endregion

        #region  Account Report Function

        public DataTable GenerateLedgerReport(DataTable DTab, ReportParams_Property pClsProperty) // Khushbu 07/07/2014
        {
            //DataTable DTabLedger = new LedgerMaster().GetDataForSearch();
            //DataRow[] DRowLedger = DTabLedger.Select("LEDGER_CODE =" + Val.ToInt(pClsProperty.Ledger_Code));

            //foreach (DataRow DR in DRowLedger)
            //{
            //    if (DR["LEDGER_NAME"].ToString() == "CAPITAL A/C")
            //    {
            //        AddPLAmt = true;
            //    }
            //    else
            //    {
            //        AddPLAmt = false;
            //    }
            //    //StrAccType = DR["ACCOUNT_TYPE_NAME"].ToString(); MODIFY : NARENDRA : 24-05-20144
            //    StrAccType = DR["LEDGER_NAME"].ToString();

            //    StrDrCrType = DR["DR_CR_TYPE"].ToString();
            //}

            DataTable DTabFinal = DTab.Clone();

            if (pClsProperty.IsOpening == true)
            {
                DTabFinal = GetLedgerCurrBal(DTabFinal,pClsProperty);
            }

            double DouDebitAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)", ""));
            double DouCreditAmount = Val.Val(DTab.Compute("Sum(CREDIT_AMOUNT)", ""));

            DTabFinal.Merge(DTab);

            DTabFinal.Rows.Add(DTabFinal.NewRow());

            double DblTotDr = 0.00, DblTotCr = 0.00;

            for (int IntI = 0; IntI < DTabFinal.Rows.Count - 1; IntI++)
            {
                if (Val.Val(DTabFinal.Rows[IntI]["DEBIT_AMOUNT"]) != 0)
                {
                    DblTotDr = DblTotDr + Val.ToDouble(DTabFinal.Rows[IntI]["DEBIT_AMOUNT"]);
                }

                if (Val.Val(DTabFinal.Rows[IntI]["CREDIT_AMOUNT"]) != 0)
                {
                    DblTotCr = DblTotCr + Val.ToDouble(DTabFinal.Rows[IntI]["CREDIT_AMOUNT"]);
                }
                if (IntI != 0)
                {
                    DblLedgerOpBal = DblLedgerOpBal + Val.ToDouble(DTabFinal.Rows[IntI]["DEBIT_AMOUNT"]) - Val.ToDouble(DTabFinal.Rows[IntI]["CREDIT_AMOUNT"]);
                }

                if (DblLedgerOpBal > 0)
                {
                    DTabFinal.Rows[IntI]["RUNNING_LEDGER"] = Math.Abs(DblLedgerOpBal) + " Dr";
                }
                else
                {
                    DTabFinal.Rows[IntI]["RUNNING_LEDGER"] = Math.Abs(DblLedgerOpBal) + " Cr";
                }
            }

            string StrType = "";
            StrType = DTabFinal.Rows[DTabFinal.Rows.Count - 2]["RUNNING_LEDGER"].ToString();

            DTabFinal.Rows.Add(DTabFinal.NewRow());
            DTabFinal.Rows.Add(DTabFinal.NewRow());
            DTabFinal.Rows.Add(DTabFinal.NewRow());
            DTabFinal.Rows.Add(DTabFinal.NewRow());

            if (DblOpeningBalance < 0.0)
            {
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["REF_LEDGER_NAME"] = "OPENING BALANCE";
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["CREDIT_AMOUNT"] = Math.Abs(DblOpeningBalance);
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["DEBIT_AMOUNT"] = 0.00;    
            }
            else
            {
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["REF_LEDGER_NAME"] = "OPENING BALANCE";
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["DEBIT_AMOUNT"] = Math.Abs(DblOpeningBalance);
                DTabFinal.Rows[DTabFinal.Rows.Count - 4]["CREDIT_AMOUNT"] = 0.00;    
            }

            if (Val.ToString(DTabFinal.Rows[0]["REF_LEDGER_NAME"]).Contains("OPENING")) //Add By Khushbu 11/09/2014
            {
                if (Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) != 0.0)
                {
                    DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]);
                }
                else if (Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) != 0.0)
                {
                    DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]);
                }
            }
            
            DTabFinal.Rows[DTabFinal.Rows.Count - 3]["REF_LEDGER_NAME"] = "CURRENT TOTAL ";
            DTabFinal.Rows[DTabFinal.Rows.Count - 3]["CREDIT_AMOUNT"] = Math.Abs(DouCreditAmount);
            DTabFinal.Rows[DTabFinal.Rows.Count - 3]["DEBIT_AMOUNT"] = Math.Abs(DouDebitAmount);

            double DouClosing = 0;
            // Add ; Narendra : 07/May/2015            
            DouClosing = (DouDebitAmount - DouCreditAmount) + DblOpeningBalance;
            

            /* commeted ; narendra ; 07/May/2015
             * if (Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) != 0.0)
            {
                //DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]);
                DouClosing = Val.Val(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) + DouDebitAmount - DouCreditAmount;
            }
            else if (Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) != 0.0)
            {
                //DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]);
                DouClosing = Val.Val(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) - DouDebitAmount + DouCreditAmount;
            }*/
            

            //if (Val.ToString(DTabFinal.Rows[0]["REF_LEDGER_NAME"]).Contains("OPENING"))//Add By Khushbu 11/09/2014
            //{
            //    if (Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) != 0.0)
            //    {
            //        DblLedgerOpBal = DblLedgerOpBal + Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]);
            //    }
            //    else if (Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) != 0.0)
            //    {
            //        DblLedgerOpBal = DblLedgerOpBal + Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]);
            //    }
            //}


            if (DouClosing < 0)
            {
                DTabFinal.Rows[DTabFinal.Rows.Count - 2]["REF_LEDGER_NAME"] = "CLOSING BALANCE";
                DTabFinal.Rows[DTabFinal.Rows.Count - 2]["CREDIT_AMOUNT"] = Math.Abs(DouClosing);
            }
            else
            {
                DTabFinal.Rows[DTabFinal.Rows.Count - 2]["REF_LEDGER_NAME"] = "CLOSING BALANCE";
                DTabFinal.Rows[DTabFinal.Rows.Count - 2]["DEBIT_AMOUNT"] = Math.Abs(DouClosing);
            }

            DTabFinal.AcceptChanges();

            return DTabFinal;

        }

        public DataTable GetLedgerCurrBal(DataTable DTabFinal,ReportParams_Property pClsProeprty) // Khushbu 07/07/2014
        {
           // LedgerOpeningBalance_MasterProperty Property = new LedgerOpeningBalance_MasterProperty();
           // Property.Ledger_Code = Val.ToInt(pClsProeprty.Ledger_Code);
           // Property.Company_Code = Val.ToInt(pClsProeprty.Company_Code);
           // Property.Location_Code = Val.ToInt(pClsProeprty.Location_Code);
           // Property.Branch_Code = Val.ToInt(pClsProeprty.Branch_Code);


           // Property.Start_Date = pClsProeprty.Start_Date;
           // Property.From_Date = Val.ToString(pClsProeprty.From_Date);

           // if (Val.ToInt(pClsProeprty.IntStatus) == 0)
           // {
           //     Property.Is_Cr_Dr = 0;
           // }
           // else if (Val.ToInt(pClsProeprty.IntStatus) == 1)
           // {
           //     Property.Is_Cr_Dr = 1;
           // }
           // else if (Val.ToInt(pClsProeprty.IntStatus) == 2)
           // {
           //     Property.Is_Cr_Dr = 2;
           // }
            
           ///* Commented : Narendra : 18-JUN-2015
           //  DataRow DRow = ObjLedger.GetLedgerOpeningBalDetail(Property);

           // if (DRow == null)
           // {
           //     DblLedgerOpBal = 0.00;
           //     DblOpeningBalance = 0.00;
           // }
           // else
           // {
           //     // ADD ; NARENDRA ; 23-APR-2015
           //     DataRow[] dROW_BAL = DRow.Table.Select("ENTRY_DATE >= '" + GlobalDec.gFinancialYear_StartDate + "' AND ENTRY_DATE <= '" + GlobalDec.gFinancialYear_EndDate + "'");
           //     if (dROW_BAL != null && dROW_BAL.Count() > 0)
           //     {
           //         DRow = dROW_BAL[0];
           //         DblLedgerOpBal = Val.ToDouble(DRow["DEBIT_LOCAL"]) - Val.ToDouble(DRow["CREDIT_LOCAL"]);
           //     }
           //     // END ; NARENDRA ; 23-APR-2015
           //     // DblLedgerOpBal = Val.ToDouble(DRow["DEBIT_LOCAL"]) - Val.ToDouble(DRow["CREDIT_LOCAL"]); // COMMENTED ; NARENDRA ; 23-APR-2015
               
           // }*/

           // /* Add : Narendra : 10-Apr-2015 */
           // //DblLedgerOpBal = FindLedger_Opening_Balance(Property.Company_Code, Property.Branch_Code, Property.Location_Code, Property.Ledger_Code, "", Property.From_Date);

           // /* ADD ; NARENDRA ; 18-JUN-2015 */
           // DblLedgerOpBal = 0.00;
           // DblOpeningBalance = 0.00;
           // if (GlobalDec.CheckLedgerForExpenseOrIncome(Property.Ledger_Code.ToString())) // Add : Narendra : 05-Jan-2017

           //     DblLedgerOpBal = GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.OPENING, Property.Company_Code, Property.Branch_Code, Property.Location_Code, Val.ToInt(Property.Ledger_Code), Val.DBDate(Property.From_Date));
           // else
           //     DblLedgerOpBal = GlobalDec.FindLedgerOpeningClosingForExpenseIncome(GlobalDec.LEDGEROPENING.OPENING, Property.Company_Code, Property.Branch_Code, Property.Location_Code, Val.ToInt(Property.Ledger_Code), Val.DBDate(Property.From_Date));
           // // End : Narendra : 05-Jan-2017 

           // /* END ; NARENDRA ; 18-JUN-2015 */
           // double DblCurrBal = 0.00;
           // double DblTotalDebit = 0.00, DblTotalCredit = 0.00;

           // /* Commented : Narendra : 02-July-2015
           //  * DataTable DTabTotal = ObjLedger.GetLedgerTotalBalance(Property);

           // if (DTabTotal.Rows.Count > 0)
           // {
           //     DataRow DR = DTabTotal.Rows[0];
           //     DblTotalDebit = Val.ToDouble(DR["TOTALDEBIT"]);
           //     DblTotalCredit = Val.ToDouble(DR["TOTALCREDIT"]);
           // }
           // else
           // {
           //     DblTotalDebit = 0.00;
           //     DblTotalCredit = 0.00;
           // }*/

           // DblCurrBal = DblLedgerOpBal + DblTotalDebit - DblTotalCredit;
           // DblOpeningBalance = DblLedgerOpBal + DblTotalDebit - DblTotalCredit;
            
           // DblCurrBal = DblLedgerOpBal; // Add : Narendra : 24-July-2015
           // DataRow Dr = DTabFinal.NewRow();

           // if (Val.Val(DblCurrBal) > 0)
           // {
                
           //     Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
           //     Dr["DEBIT_AMOUNT"] = Math.Abs(DblCurrBal);
           //     Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Dr";
           //     DblLedgerOpBal = Math.Abs(DblCurrBal);
           //     DblCurrBal = Math.Abs(DblCurrBal);
           // }
           // else if (Val.Val(DblCurrBal) == 0)
           // {
                

           //     Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
           //     if (StrDrCrType == "CR")
           //     {
           //         Dr["CREDIT_AMOUNT"] = Math.Abs(DblCurrBal);
           //         Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Cr";
           //         DblLedgerOpBal = Math.Abs(DblCurrBal) * -1;
           //         DblCurrBal = Math.Abs(DblCurrBal) * -1;
           //     }
           //     else
           //     {
           //         Dr["DEBIT_AMOUNT"] = Math.Abs(DblCurrBal);
           //         Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Dr";
           //         DblLedgerOpBal = Math.Abs(DblCurrBal);
           //         DblCurrBal = Math.Abs(DblCurrBal);
           //     }
           // }
           // else
           // {
                

           //     Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
           //     Dr["CREDIT_AMOUNT"] = Math.Abs(DblCurrBal);
           //     Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Cr";
           //     DblLedgerOpBal = Math.Abs(DblCurrBal) * -1;
           //     DblCurrBal = Math.Abs(DblCurrBal) * -1;
           // }
           // DTabFinal.Rows.Add(Dr);

            return DTabFinal;
        }
      
        public DataTable GenerateBalanceSheet(DataSet DS, ReportParams_Property pClsProeprty) // Khushbu 08/07/2014
        {
           // DataTable DTabExpense = new DataTable();
           // DataTable DTabIncome = new DataTable();

           // double DblTempCapitalAmt = 0.00;
           // double DblTempPlAmt = 0.00;


           // DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
           // DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
           // DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));

           // DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
           // DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
           // DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

           // // ADD : 26-05-2014 :   NARENDRA 

           // DTabExpense.Columns.Add(new DataColumn("CODE_", typeof(string)));
           // DTabExpense.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
           // DTabExpense.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
           // DTabExpense.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

           // DTabIncome.Columns.Add(new DataColumn("CODE_", typeof(string)));
           // DTabIncome.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
           // DTabIncome.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
           // DTabIncome.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

           // if (DS.Tables[0].Rows.Count > 0)
           // {
           //     if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
           //     {
           //         // DTabExpense.Rows.Add(DS.Tables[0].Rows[0]["EXPENSE_ACCOUNT_NAME"], DS.Tables[0].Rows[0]["OPENING_AMOUNT"], DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
           //         DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
           //     }
           // }

           //// //DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
           //// DTAccountType.DefaultView.Sort = "BS_SRNO";
           //// DTAccountType = DTAccountType.DefaultView.ToTable();
           //// //ADD : NARENDRA : 23-05-2014
           ////// DataTable DTAccountTypeGroup = new AccTypeGroupMaster().GetDataForSearch();
           //// DTAccountTypeGroup.DefaultView.Sort = "BS_SRNO";
           //// DTAccountTypeGroup = DTAccountTypeGroup.DefaultView.ToTable();
           //// //-------------------------
           //// DataView DTView = new DataView(DS.Tables[0]);

           //// DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

           //// DataRow[] DTRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

           // // ----------------------- FOR EXPENSE -------------------------//
           // foreach (DataRow DR in DTRow)
           // {
           //     DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
           //     if (DTView.ToTable().Rows.Count > 0)
           //     {
           //         if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary.
           //         {
           //             DTabExpense.NewRow();
           //             DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
           //             DTabExpense.Rows.Add(Regex.Replace(DR["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

           //         }
           //         foreach (DataRow DRG in DTRowGroup)
           //         {
           //             DataView DTViewGroup = new DataView(DTView.ToTable());
           //             DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
           //             if (DTViewGroup.ToTable().Rows.Count > 0)
           //             {
           //                 if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
           //                 {
           //                     //--------
           //                     if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
           //                     {
           //                         DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
           //                         DTabExpense.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
           //                         foreach (DataRow DVRow in DTViewGroup.ToTable().Rows)
           //                         {
           //                             if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
           //                             {
           //                                 ObjComp.GetCompanyCapitalMaster(Val.ToInt(pClsProeprty.Company_Code));

           //                                 DataTable DTabCapital = ObjComp.DS.Tables["Company_Capital_Master"];

           //                                 DataRow[] DTFilterRow = DTabCapital.Select("COMPANY_CODE = " + Val.ToInt(pClsProeprty.Company_Code) + " AND LEDGER_CODE = " + DVRow["EXPENSE_ACCOUNT_CODE"]);

           //                                 if (DTFilterRow.Length > 0)
           //                                 {
           //                                     DTabExpense.Rows.Add("      " + DVRow["EXPENSE_ACCOUNT_NAME"] + "(" + DTFilterRow[0]["shere_per"].ToString() + "% )", DVRow["OPENING_AMOUNT"], Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100, DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);

           //                                     if (DS.Tables[0].Rows.Count > 0)
           //                                     {
           //                                         if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
           //                                         {
           //                                             DblTempCapitalAmt = DblTempCapitalAmt + Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100;
           //                                         }
           //                                     }

           //                                 }
           //                             }
           //                             else
           //                             {
           //                                 DTabExpense.Rows.Add("      " + DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);
           //                             }
           //                         }
           //                         DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
           //                     }//---end of rbt
           //                     if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
           //                     {
           //                         DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, DR["ACCOUNT_TYPE_CODE"], "LEDGER_TRANSACTION", DRG["ACCOUNT_TYPE_GROUP_CODE"], ""); // "" => DVRow["EXPENSE_ACCOUNT_CODE"]
           //                     }
           //                     else
           //                     {
           //                         DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL ", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

           //                     }
           //                     //if (Val.ToInt(RbtReportType.SelectedValue) > 0)
           //                     //{
           //                     //    DTabExpense.Rows.Add("", "-------------------", "---------------------");

           //                     //}
           //                 }// End Of Summary Data.
           //             }
           //         }// END OF MAIN TOTAL
           //         //if (Val.ToInt(RbtReportType.SelectedValue) == 0)
           //         //  DTabExpense.Rows.Add("", "-------------------", "---------------------");
           //         if (DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
           //         {
           //             DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
           //         }
           //         else
           //         {
           //             if (Val.ToInt(pClsProeprty.IntReportType) > 0)
           //             {
           //                 DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");

           //             }
           //             DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

           //         }

           //     }
           //     //-----------------------------

           // }
           // if (DS.Tables[0].Rows.Count > 0)
           // {
           //     if (Val.ToInt(pClsProeprty.IntReportType) == 0)
           //         DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
           //     DTabExpense.Rows.Add("LIABILITIES ACCOUNT TOTAL", DS.Tables[0].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "", "");
           // }

           // //-----------------------------------------//

           // // ---------------- FOR INCOME ---------------------------------

           // DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
           // DataRow[] DTIncomeRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
           // DataView DTIncomeView = new DataView(DS.Tables[1]);
           // foreach (DataRow DIRow in DTIncomeRow)
           // {
           //     DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
           //     if (DTIncomeView.ToTable().Rows.Count > 0)
           //     {

           //         if (Val.ToInt(pClsProeprty.IntReportType) > 0)
           //         {
           //             DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
           //             DTabIncome.Rows.Add(Regex.Replace(DIRow["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
           //         }
           //         foreach (DataRow DRG in DTIncomeRowGroup)
           //         {
           //             DataView DTViewGroup = new DataView(DTIncomeView.ToTable());
           //             DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DIRow["ACCOUNT_TYPE_CODE"];
           //             if (DTViewGroup.ToTable().Rows.Count > 0)
           //             {
           //                 if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
           //                 {
           //                     //--------
           //                     if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
           //                     {
           //                         DTabIncome.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
           //                         DTabIncome.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

           //                         //----------
           //                         foreach (DataRow DR in DTViewGroup.ToTable().Rows)
           //                         {
           //                             DTabIncome.Rows.Add("      " + DR["INCOME_ACCOUNT_NAME"], DR["OPENING_AMOUNT"], DR["INCOME_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DR["INCOME_ACCOUNT_CODE"]);
           //                         }

           //                         DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
           //                     }
           //                     DTabIncome.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DRG["ACCOUNT_TYPE_CODE"], "");

           //                     //if (Val.ToInt(RbtReportType.SelectedValue) == 0)
           //                     //{
           //                     //    DTabIncome.Rows.Add("", "-------------------", "-------------------");
           //                     //}
           //                 }
           //             }

           //         }
           //         if (Val.ToInt(pClsProeprty.IntReportType) > 0)
           //         {
           //             DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
           //         }
           //         DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"] + " TOTAL", DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");

           //     }
           // }

           // if (DS.Tables[1].Rows.Count > 0)
           // {
           //     if (Val.ToInt(pClsProeprty.IntReportType) == 0)
           //         DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
           //     DTabIncome.Rows.Add("ASSETS ACCOUNT TOTAL", DS.Tables[1].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""), "", "", "", "");
           // }

           // DataTable DTabOuter = DTabIncome;
           // DataTable DTabInner = DTabExpense;

           // if (!DTabInner.Columns.Contains("INCOME_ACCOUNT_NAME"))
           // {
           //     DTabInner.Columns.Add("INCOME_ACCOUNT_NAME").SetOrdinal(5);
           // }

           // if (!DTabInner.Columns.Contains("OPENING_AMOUNT1"))
           // {
           //     DTabInner.Columns.Add("OPENING_AMOUNT1").SetOrdinal(6);
           // }

           // if (!DTabInner.Columns.Contains("INCOME_AMOUNT"))
           // {
           //     DTabInner.Columns.Add("INCOME_AMOUNT").SetOrdinal(7);
           // }

           // if (!DTabInner.Columns.Contains("CODE_1"))
           // {
           //     DTabInner.Columns.Add("CODE_1").SetOrdinal(8);
           // }

           // if (!DTabInner.Columns.Contains("TABLE_NAME_1"))
           // {
           //     DTabInner.Columns.Add("TABLE_NAME_1").SetOrdinal(9);
           // }

           // if (!DTabInner.Columns.Contains("ACC_TYPE_CODE"))
           // {
           //     DTabInner.Columns.Add("ACC_TYPE_CODE_1").SetOrdinal(10);
           // }

           // if (!DTabInner.Columns.Contains("LEDGER_CODE"))
           // {
           //     DTabInner.Columns.Add("LEDGER_CODE_1").SetOrdinal(11);
           // }

           // if (DTabExpense.Rows.Count > DTabIncome.Rows.Count)
           // {
           //     for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
           //     {
           //         DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
           //         DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
           //         DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
           //         DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
           //         DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

           //         DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
           //         DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
           //     }
           // }
           // else
           // {
           //     for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
           //     {
           //         if (IntI <= DTabInner.Rows.Count - 1)
           //         {
           //             DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
           //             DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
           //             DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
           //             DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
           //             DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

           //             DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
           //             DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
           //         }
           //         else
           //         {
           //             DTabInner.Rows.Add("", "", "", "", "", DTabOuter.Rows[IntI][0], DTabOuter.Rows[IntI][1], DTabOuter.Rows[IntI][2], DTabOuter.Rows[IntI][3], DTabOuter.Rows[IntI][4], DTabOuter.Rows[IntI][5], DTabOuter.Rows[IntI][6]);
           //         }
           //     }
           // }

           // // Difference opening balance
           // if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) != Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
           // {
           //     DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");

           //     if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) > Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
           //     {
           //         DTabInner.Rows.Add("", "", "", "", "", "DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")));

           //         DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "", "", "-------------------");
           //         DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "ASSETS GRAND TOTAL", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""))));

           //     }
           //     else
           //     {
           //         DTabInner.Rows.Add("DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")), "", "", "");

           //         DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");
           //         DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""))), "", "", "ASSETS GRAND TOTAL", "", DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
           //         DTabInner.Rows.Add("", "", "===============", "", "", "", "", "===============");
           //     }
           // }

           // //for (int IntI = 0; IntI < DTabInner.Rows.Count; IntI++)
           // //{
           // //    if ((!DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
           // //        !DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")) ||
           // //        (!DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
           // //        !DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")))

           // //        {
           // //            DTabInner.Rows[IntI].Delete();
           // //            DTabInner.AcceptChanges();
           // //        }
           // //} 
            DataTable DTabInner = new DataTable();
           return DTabInner;
        }

        public DataTable GenerateTradingAccountReport(DataSet DS) //Khushbu 08/07/2014
        {
            //DataTable DTabExpense = new DataTable();
            //DataTable DTabIncome = new DataTable();

            //DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
     

            //DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
           
            //double DblTempPlAmt = 0.00;

            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
            //    {
            //        DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
            //    }
            //}

            ////DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
            //DataView DTView = new DataView(DS.Tables[0]);

            ////DataRow[] DTRow = DTAccountType.Select("IN_TRADING= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");

            //// ----------------------- FOR EXPENSE -------------------------//
            ////foreach (DataRow DR in DTRow)
            ////{
            ////    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
            ////    if (DTView.ToTable().Rows.Count > 0)
            ////    {
            ////        DTabExpense.NewRow();

            ////        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], "", "");
            ////        DTabExpense.Rows.Add(Regex.Replace(DR["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "");

            ////        foreach (DataRow DVRow in DTView.ToTable().Rows)
            ////        {
            ////            DTabExpense.Rows.Add(DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"]);
            ////        }
            ////        DTabExpense.Rows.Add("", "-------------------", "---------------------");

            ////        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""));

            ////        DTabExpense.Rows.Add("", "-------------------", "---------------------");
            ////    }
            ////}
            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    DTabExpense.Rows.Add("EXPENSE ACCOUNT TOTAL", DS.Tables[0].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""));
            //}

            ////-----------------------------------------//

            //// ---------------- FOR INCOME ---------------------------------

            //DataRow[] DTIncomeRow = DTAccountType.Select("IN_TRADING = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            //DataView DTIncomeView = new DataView(DS.Tables[1]);
            //foreach (DataRow DIRow in DTIncomeRow)
            //{
            //    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
            //    if (DTIncomeView.ToTable().Rows.Count > 0)
            //    {
            //        DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], "", "");
            //        DTabIncome.Rows.Add(Regex.Replace(DIRow["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "");
            //        foreach (DataRow DR in DTIncomeView.ToTable().Rows)
            //        {
            //            DTabIncome.Rows.Add(DR["INCOME_ACCOUNT_NAME"], DR["OPENING_AMOUNT"], DR["INCOME_AMOUNT"]);
            //        }
            //        DTabIncome.Rows.Add("", "-------------------", "-------------------");
            //        DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"] + " TOTAL", DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""));
            //        DTabIncome.Rows.Add("", "-------------------", "-------------------");
            //    }
            //}

            //if (DS.Tables[1].Rows.Count > 0)
            //{
            //    DTabIncome.Rows.Add("INCOME ACCOUNT TOTAL", DS.Tables[1].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            //}

            //DataTable DTabOuter = DTabIncome;
            //DataTable DTabInner = DTabExpense;

            //if (!DTabInner.Columns.Contains("INCOME_ACCOUNT_NAME"))
            //{
            //    DTabInner.Columns.Add("INCOME_ACCOUNT_NAME").SetOrdinal(3);
            //}

            //if (!DTabInner.Columns.Contains("OPENING_AMOUNT1"))
            //{
            //    DTabInner.Columns.Add("OPENING_AMOUNT1").SetOrdinal(4);
            //}

            //if (!DTabInner.Columns.Contains("INCOME_AMOUNT"))
            //{
            //    DTabInner.Columns.Add("INCOME_AMOUNT").SetOrdinal(5);
            //}

            //if (DTabExpense.Rows.Count > DTabIncome.Rows.Count)
            //{
            //    for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
            //    {
            //        DTabInner.Rows[IntI][3] = DTabOuter.Rows[IntI][0];
            //        DTabInner.Rows[IntI][4] = DTabOuter.Rows[IntI][1];
            //        DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][2];
            //    }
            //}
            //else
            //{
            //    for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
            //    {
            //        if (IntI <= DTabInner.Rows.Count - 1)
            //        {
            //            DTabInner.Rows[IntI][3] = DTabOuter.Rows[IntI][0];
            //            DTabInner.Rows[IntI][4] = DTabOuter.Rows[IntI][1];
            //            DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][2];
            //        }
            //        else
            //        {
            //            DTabInner.Rows.Add("", "", "", DTabOuter.Rows[IntI][0], DTabOuter.Rows[IntI][1], DTabOuter.Rows[IntI][2]);
            //        }
            //    }
            //}


            //double DblSumIncome = Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            //double DblSumExpense = Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""));

            //if (DblSumIncome - DblSumExpense < 0)
            //{
            //    DTabInner.Rows.Add("", "", "", "GROSS LOSS TRANS. TO PL A/C", "", System.Math.Round(Math.Abs(DblSumIncome - DblSumExpense), 2));
            //    DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            //    DTabInner.Rows.Add("EXPENSE GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2), "INCOME GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2));
            //    DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            //}

            //else
            //{
            //    DTabInner.Rows.Add("", "", "", "GROSS PROFIT TRANS. TO PL A/C", "", System.Math.Round(Math.Abs(DblSumIncome - DblSumExpense), 2));
            //    DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            //    DTabInner.Rows.Add("EXPENSE GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2), "INCOME GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2));
            //    DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            //}
            DataTable DTabInner = new DataTable();
            return DTabInner;
        }

        public DataTable tGenerateProfitLossreport(DataSet DS,string pStrReportTYpe) //Khushbu 08/07/2014
        {
            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));

            DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

            // Add Code By Khushbu 07/09/2014 ---- //
            if (DS.Tables[0].Rows.Count > 0)
            {
                if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DS.Tables[0].Rows[0]["LEDGER_COMBINE_NAME"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DS.Tables[0].Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = "";
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";

                    DTabExpense.Rows.Add(DRNew);

                }
            }

            if (DS.Tables[1].Rows.Count > 0)
            {
                if (DS.Tables[1].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();
                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DS.Tables[0].Rows[0]["LEDGER_COMBINE_NAME"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DS.Tables[0].Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = "";
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";

                    DTabIncome.Rows.Add(DRNew);
                }
            }
           
            //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            //foreach (DataRow DRowType in DTAb.Rows)
            //{
            //    if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1)
            //    {
            //        DataRow DTNewRow = DTAccountType.NewRow();
            //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
            //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
            //        DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
            //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
            //        DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

            //        DTAccountType.Rows.Add(DTNewRow);
            //    }
            //}
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///


            // ----------------------- FOR EXPENSE -------------------------//

            
            
            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DS.Tables[0]);

            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                if (DTView.ToTable().Rows.Count > 0)
                {
                    
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;
                        foreach (DataRow DVRow in DTView.ToTable().Rows)
                        {
                            DTabExpense.Rows.Add("       " + DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"], IntExpenseRNO, DVRow["ACCOUNT_TYPE_NAME"]);
                        }                    
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++; 
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                        

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + Val.Val(DR1["EXPENSE_AMOUNT"]);
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DTabExpense.Rows.Add("       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpeningAmount, "###############0.00"), Val.Format(DouAmount, "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }                              
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;
                        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], Val.Format((Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""))), "###############0.00"),
                                                                           Val.Format((Val.Val(DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                    }                    
                }
            }

            // ---------------- FOR INCOME ---------------------------------

            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DS.Tables[1]);
            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                if (DTIncomeView.ToTable().Rows.Count > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;
                        foreach (DataRow DR in DTIncomeView.ToTable().Rows)
                        {
                            DTabIncome.Rows.Add("       " + DR["INCOME_ACCOUNT_NAME"], Val.Format((Val.ToDouble(DR["OPENING_AMOUNT"])), "###############0.00"),
                                                                           Val.Format((Val.ToDouble(DR["INCOME_AMOUNT"])), "###############0.00"), IntIncomeRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }                    
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");
                        
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + Val.Val(DR1["INCOME_AMOUNT"]);
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);    
                                }                                
                            }

                            DTabIncome.Rows.Add("       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpeningAmount, "###############0.00"), Val.Format(DouAmount, "###############0.00"), IntIncomeRNO, DIRow["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntIncomeRNO++;
                        DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], Val.Format((Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""))), "###############0.00"),
                                                                           Val.Format((Val.Val(DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00"), IntIncomeRNO, DIRow["ACCOUNT_TYPE_NAME"]);
                    }
                }
            }

            double DouGrossDiff = 0;


            double DouExpenseOpening = 0;
            double DouExpenseAmount = 0;
            double DouIncomeOpening = 0;
            double DouIncomeAmount = 0;
            double DouExpenseNetToTal = 0,DouIncomeNetTotal = 0;
            double DouLastExpenseGross = 0, DouLastIncomeGross = 0;

            for (int IntI = 0; IntI < 5; IntI++)
            {
                DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
                DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

                int Diff = UDRowExpense.Count() - UDRowIncome.Count();

                DouExpenseOpening = 0;
                DouExpenseAmount = 0;
                DouIncomeOpening = 0;
                DouIncomeAmount = 0;

                if (UDRowIncome.Count()!=0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        if (DouGrossDiff < 0)
                        {
                            DouLastExpenseGross = DouGrossDiff * -1;
                            DTabCombine.Rows.Add("GROSS LOSS c/o", "", Val.Format(DouGrossDiff*-1, "###############0.00"), "", "", "");
                        }
                        else if (DouGrossDiff > 0)
                        {
                            DouLastIncomeGross = DouGrossDiff;
                            DTabCombine.Rows.Add("", "", "", "GROSS PROFIT b/f", "", Val.Format(DouGrossDiff, "###############0.00"));
                        }
                        
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                        DRNew["EXPENSE_AMOUNT"] = "";
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
                        DRNew["INCOME_OPENING_AMOUNT"] = "";
                        DRNew["INCOME_AMOUNT"] = "";

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (Diff == 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"],"#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"],"#################0.00");
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"],"#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"],"#################0.00");

                        DTabCombine.Rows.Add(DRNew);

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                    }
                }
                else if (Diff < 0)
                {
                    for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowExpense.Count())
                        {
                            DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"],"#################0.00");
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"],"#################0.00");
                        
                            
                            DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                            DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

                        }
                        else
                        {
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";
                        }
                        
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"],"#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"],"#################0.00");

                        DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                        DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                else if (Diff > 0)
                {
                    for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        if (IntJ < UDRowIncome.Count())
                        {
                            DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"],"#################0.00");
                            DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"],"#################0.00");

                            DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
                            DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
                        }
                        else
                        {
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = "";
                            DRNew["INCOME_AMOUNT"] = "";

                        }

                        DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"],"#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                        DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                        DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
                        DTabCombine.Rows.Add(DRNew);
                    }
                }

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        DataRow DRNew = DTabCombine.NewRow();

                        DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Format(DouExpenseOpening, "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Format(DouExpenseAmount, "#################0.00");
                        DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Format(DouIncomeOpening, "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Format(DouIncomeAmount, "#################0.00");

                        DTabCombine.Rows.Add(DRNew);

                        DouGrossDiff += DouIncomeAmount - DouExpenseAmount;

                        DouIncomeNetTotal = DouIncomeAmount;
                        DouExpenseNetToTal = DouExpenseAmount;

                        if (DouGrossDiff > 0)
                        {
                            DouLastExpenseGross = DouGrossDiff;
                            DTabCombine.Rows.Add("GROSS PROFIT c/o", "", Val.Format(DouGrossDiff, "###############0.00"), "", "", "");
                        }
                        else if (DouGrossDiff < 0)
                        {
                            DouLastIncomeGross = DouGrossDiff * -1;
                            DTabCombine.Rows.Add("", "", "", "GROSS LOSS b/f", "", Val.Format(DouGrossDiff*-1, "###############0.00"));
                        }
                    }
                }
            }

            /*DTabCombine.Rows.Add("EXPENSE ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_OPENING_AMOUNT)", ""))), "###############0.00"),
                                                            Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"), 
                                 "INCOME ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_OPENING_AMOUNT)", ""))), "###############0.00"),
                                                            Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00")                                                            
                                                            );
            */

            double DblSumIncome = Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""));

            
            if (DblSumIncome - DblSumExpense > 0)
            {
                DTabCombine.Rows.Add("", "", "", "", "", "");
                DTabCombine.Rows.Add("NET PROFIT TRANS. TO CAPITAL A/C", "", Val.Format((DblSumIncome - DblSumExpense), "###############0.00"), "", "", "");
                DTabCombine.Rows.Add("", "", "------------------------", "", "", "------------------------");
                //DTabCombine.Rows.Add("EXPENSE GRAND TOTAL", "", Val.Format((DblSumIncome), "###############0.00"), "INCOME GRAND TOTAL", "", Val.Format((DblSumIncome), "###############0.00"));
                DTabCombine.Rows.Add("TOTAL", "", Val.Format((DouExpenseNetToTal+DouLastExpenseGross), "###############0.00"), "TOTAL", "", Val.Format((DouIncomeNetTotal+DouLastIncomeGross), "###############0.00"));
                DTabCombine.Rows.Add("", "", "------------------------", "", "", "------------------------");
            }

            else if (DblSumIncome - DblSumExpense < 0)
            {
                DTabCombine.Rows.Add("", "", "", "", "", "");
                DTabCombine.Rows.Add("", "", "", "NET LOSS TRANS. TO CAPITAL A/C", "", Val.Format((DblSumExpense - DblSumIncome), "###############0.00"));
                DTabCombine.Rows.Add("", "", "------------------------", "", "", "------------------------");
                //DTabCombine.Rows.Add("EXPENSE GRAND TOTAL", "", Val.Format((DblSumExpense), "###############0.00"), "INCOME GRAND TOTAL", "", Val.Format((DblSumExpense), "###############0.00"));
                DTabCombine.Rows.Add("TOTAL", "", Val.Format((DouExpenseNetToTal + DouLastExpenseGross), "###############0.00"), "INCOME GRAND TOTAL", "", Val.Format((DouIncomeNetTotal + DouLastIncomeGross), "###############0.00"));
                DTabCombine.Rows.Add("", "", "------------------------", "", "", "------------------------");
            }
            return DTabCombine;
        }

        public DataTable Generate_LedgerGroup_Detail(DataTable DTab,string start_Date)
        {
            DataTable DTabFinal = DTab.Clone();
         
            //DataTable DTDistinct = DTab.DefaultView.ToTable(true, "LEDGER_GROUP_CODE", "LEDGER_CODE");

            
            //foreach (DataRow DRow in DTDistinct.Rows)
            //{
            //    DataRow DTNewRow = DTabFinal.NewRow();

            //    ReportParams_Property pClsProperty = new ReportParams_Property();
            //    double douOpening = 0.0;

            //    foreach (DataRow DR in DTab.Rows)
            //    {
            //        if (DR["LEDGER_GROUP_CODE"].ToString() == DRow["LEDGER_GROUP_CODE"].ToString() && DR["LEDGER_CODE"].ToString() == DRow["LEDGER_CODE"].ToString())
            //        {
            //            pClsProperty.Ledger_Code = Val.ToString(DR["LEDGER_CODE"]);
            //            pClsProperty.Company_Code = Val.ToString(DR["COMPANY_CODE"]);
            //            pClsProperty.Branch_Code = Val.ToString(DR["BRANCH_CODE"]);
            //            pClsProperty.Location_Code = Val.ToString(DR["LOCATION_CODE"]);
            //            pClsProperty.Start_Date = start_Date;
            //            pClsProperty.From_Date = Val.DBDate(Val.ToString(DR["TRANSACTION_ENTRY_DATE"]));

            //            douOpening = Get_LedgerWise_OpeningBalance_Cash_Bank_Book(pClsProperty);

            //            DTNewRow["LEDGER_CODE"] = Val.ToString(DR["LEDGER_CODE"]);
            //            DTNewRow["LEDGER_NAME"] = Val.ToString(DR["LEDGER_NAME"]);

            //            DTNewRow["COMPANY_CODE"] = Val.ToString(DR["COMPANY_CODE"]);
            //            DTNewRow["COMPANY_NAME"] = Val.ToString(DR["COMPANY_NAME"]);

            //            DTNewRow["BRANCH_CODE"] = Val.ToString(DR["BRANCH_CODE"]);
            //            DTNewRow["BRANCH_NAME"] = Val.ToString(DR["BRANCH_NAME"]);

            //            DTNewRow["LOCATION_CODE"] = Val.ToString(DR["LOCATION_CODE"]);
            //            DTNewRow["LOCATION_NAME"] = Val.ToString(DR["LOCATION_NAME"]);

            //            DTNewRow["LEDGER_GROUP_CODE"] = Val.ToString(DR["LEDGER_GROUP_CODE"]);
            //            DTNewRow["LEDGER_GROUP_NAME"] = Val.ToString(DR["LEDGER_GROUP_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_GROUP_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_GROUP_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_NAME"]);

            //            DTNewRow["REF_LEDGER_NAME"] = "Opening Balance";

            //            if (douOpening >= 0)
            //            {
            //                DTNewRow["DEBIT_AMOUNT"] = "0.00";
            //                DTNewRow["CREDIT_AMOUNT"] = Val.ToString(douOpening);
            //               // DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(douOpening);
            //                DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(douOpening) + " CR";
            //            }
            //            else
            //            {
            //                DTNewRow["CREDIT_AMOUNT"] = "0.00";
            //                DTNewRow["DEBIT_AMOUNT"] = Val.ToString(Math.Abs(douOpening));
            //                DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(Math.Abs(douOpening)) + " DR";
            //               // DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(Math.Abs(douOpening));
            //            }

            //            DTabFinal.Rows.Add(DTNewRow);
            //            double DouTotal = douOpening;
            //            double DouTotalCredit = 0.0;
            //            double DouTotalDebit = 0.0;

            //            foreach (DataRow DAllRow in DTab.Rows)
            //            {
            //                if (DR["LEDGER_GROUP_CODE"].ToString() == DAllRow["LEDGER_GROUP_CODE"].ToString() && DR["LEDGER_CODE"].ToString() == DAllRow["LEDGER_CODE"].ToString())
            //                {
            //                    DouTotalCredit = DouTotalCredit + Val.ToDouble(DAllRow["CREDIT_AMOUNT"]);
            //                    DouTotalDebit = DouTotalDebit + Val.ToDouble(DAllRow["DEBIT_AMOUNT"]);
            //                    DouTotal = DouTotal + Val.ToDouble(DAllRow["CREDIT_AMOUNT"]) - Val.ToDouble(DAllRow["DEBIT_AMOUNT"]);
            //                    if (DouTotal >= 0)
            //                    {
            //                        DAllRow["RUNNING_LEDGER_BALANCE"] = DouTotal + " CR";
            //                    }
            //                    else
            //                    {
            //                        DAllRow["RUNNING_LEDGER_BALANCE"] = Math.Abs(DouTotal) + " DR";
            //                    }
            //                }
            //            }

            //            // Add Total Row
            //            DTNewRow = DTabFinal.NewRow();
            //            DTNewRow["LEDGER_CODE"] = 99999;
            //            DTNewRow["LEDGER_NAME"] = Val.ToString(DR["LEDGER_NAME"]);

            //            DTNewRow["COMPANY_CODE"] = Val.ToString(DR["COMPANY_CODE"]);
            //            DTNewRow["COMPANY_NAME"] = Val.ToString(DR["COMPANY_NAME"]);

            //            DTNewRow["BRANCH_CODE"] = Val.ToString(DR["BRANCH_CODE"]);
            //            DTNewRow["BRANCH_NAME"] = Val.ToString(DR["BRANCH_NAME"]);

            //            DTNewRow["LOCATION_CODE"] = Val.ToString(DR["LOCATION_CODE"]);
            //            DTNewRow["LOCATION_NAME"] = Val.ToString(DR["LOCATION_NAME"]);

            //            DTNewRow["LEDGER_GROUP_CODE"] = Val.ToString(DR["LEDGER_GROUP_CODE"]);
            //            DTNewRow["LEDGER_GROUP_NAME"] = Val.ToString(DR["LEDGER_GROUP_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_GROUP_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_GROUP_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_NAME"]);

            //            DTNewRow["REF_LEDGER_NAME"] = "Total :";
            //            DTNewRow["CREDIT_AMOUNT"] = DouTotalCredit;
            //            DTNewRow["DEBIT_AMOUNT"] = DouTotalDebit;

            //            DTabFinal.Rows.Add(DTNewRow);

            //            // Add Total Row
            //            DTNewRow = DTabFinal.NewRow();
            //            DTNewRow["LEDGER_CODE"] = 999999;
            //            DTNewRow["LEDGER_NAME"] = Val.ToString(DR["LEDGER_NAME"]);

            //            DTNewRow["COMPANY_CODE"] = Val.ToString(DR["COMPANY_CODE"]);
            //            DTNewRow["COMPANY_NAME"] = Val.ToString(DR["COMPANY_NAME"]);

            //            DTNewRow["BRANCH_CODE"] = Val.ToString(DR["BRANCH_CODE"]);
            //            DTNewRow["BRANCH_NAME"] = Val.ToString(DR["BRANCH_NAME"]);

            //            DTNewRow["LOCATION_CODE"] = Val.ToString(DR["LOCATION_CODE"]);
            //            DTNewRow["LOCATION_NAME"] = Val.ToString(DR["LOCATION_NAME"]);

            //            DTNewRow["LEDGER_GROUP_CODE"] = Val.ToString(DR["LEDGER_GROUP_CODE"]);
            //            DTNewRow["LEDGER_GROUP_NAME"] = Val.ToString(DR["LEDGER_GROUP_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_NAME"]);

            //            DTNewRow["ACCOUNT_TYPE_GROUP_CODE"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_CODE"]);
            //            DTNewRow["ACCOUNT_TYPE_GROUP_NAME"] = Val.ToString(DR["ACCOUNT_TYPE_GROUP_NAME"]);

            //            DTNewRow["REF_LEDGER_NAME"] = "Total Current Balance :";
            //            if (DouTotal>=0)
            //            {
            //                DTNewRow["CREDIT_AMOUNT"] = DouTotal;
            //            }
            //            else
            //            {
            //                DTNewRow["DEBIT_AMOUNT"] =Math.Abs(DouTotal);
            //            }
                       
                       
            //            DTabFinal.Rows.Add(DTNewRow);
            //            break;
            //        }
                   
            //    }
                
            //}

            //DTabFinal.Merge(DTab);

            //DTabFinal.DefaultView.Sort = "LEDGER_CODE";

            return DTabFinal;
        }

        //public DataTable Generate_BalanceSheet_Report(DataTable DTab, string pStrReportTYpe) //Khushbu 11/09/2014
        //{
        //    DataTable DTabExpense = new DataTable();
        //    DataTable DTabIncome = new DataTable();
        //    DataTable DTabCombine = new DataTable();

        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
        //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

        //    DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
        //    DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));


        //    DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
        //    DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
        //    DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
        //    DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

        //    DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
        //    DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
        //    DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
        //    DataTable DTabFilterIncome = DTab.DefaultView.ToTable();


        //    // Add Code By Khushbu 07/09/2014 ---- //
        //    if (DTabFilterExpense.Rows.Count > 0)
        //    {
        //        if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
        //        {
        //            DataRow DRNew = DTabExpense.NewRow();

        //            DRNew["EXPENSE_ACCOUNT_CODE"] = "";
        //            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
        //            DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
        //            DRNew["EXPENSE_AMOUNT"] = 0;
        //            DRNew["EXPENSE_SRNO"] = 0;
        //            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
        //            DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
        //            DRNew["DETAIL_MODE"] = "";
        //            DTabExpense.Rows.Add(DRNew);

        //            DTabExpense.Rows.Add("", "", "");
        //        }
        //    }

        //    if (DTabFilterIncome.Rows.Count > 0)
        //    {
        //        if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
        //        {
        //            DataRow DRNew = DTabIncome.NewRow();

        //            DRNew["EXPENSE_ACCOUNT_CODE"] = "";
        //            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
        //            DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
        //            DRNew["EXPENSE_AMOUNT"] = 0;
        //            DRNew["EXPENSE_SRNO"] = 0;
        //            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
        //            DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
        //            DRNew["DETAIL_MODE"] = "";
        //            DTabIncome.Rows.Add(DRNew);

        //            DTabIncome.Rows.Add("", "", "");


        //        }
        //    }

        //    DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
        //    DataTable DTAccountType = new DataTable();

        //    DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
        //    DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
        //    DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
        //    DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
        //    DTAccountType.Columns.Add("PL_SRNO", typeof(int));

        //    foreach (DataRow DRowType in DTAb.Rows)
        //    {
        //        if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1)
        //        {
        //            DataRow DTNewRow = DTAccountType.NewRow();
        //            DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
        //            DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
        //            DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
        //            DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
        //            DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

        //            DTAccountType.Rows.Add(DTNewRow);
        //        }
        //    }
        //    DTAccountType.AcceptChanges();

        //    DTAccountType.DefaultView.Sort = "PL_SRNO";

        //    DTAccountType = DTAccountType.DefaultView.ToTable();
        //    //   ---------------------- ///


        //    // ----------------------- FOR EXPENSE -------------------------//

        //    DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
        //    DataView DTView = new DataView(DTabFilterExpense);

        //    int IntExpenseRNO = 0;
        //    foreach (DataRow DR in DTRow)
        //    {
        //        DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
        //        if (DTView.ToTable().Rows.Count > 0)
        //        {
        //            if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
        //            {
        //                IntExpenseRNO++;

        //                DataTable DTabSub = DTView.ToTable();
        //                DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

        //                foreach (DataRow DRDist in DTabDistinct.Rows)
        //                {
        //                    DataRow DRNew = DTabExpense.NewRow();

        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
        //                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
        //                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
        //                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

        //                    Double DouAmount = 0, DouOpening = 0;

        //                    DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
        //                    DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

        //                    //foreach (DataRow DVRow in DTabDistinct.Rows)
        //                    //{
        //                    //    if (Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) == Val.ToInt(DVRow["LEDGER_CODE_COMBINE"]))
        //                    //    {
        //                    //        DouAmount += (Val.Val(DVRow["CREDIT_AMOUNT"]) - Val.Val(DVRow["DEBIT_AMOUNT"]));
        //                    //        DouOpening += Val.Val(DVRow["OPENING_AMOUNT"]);
        //                    //    }                               
        //                    //}
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
        //                    DRNew["EXPENSE_AMOUNT"] = DouAmount;
        //                    DTabExpense.Rows.Add(DRNew);
        //                }
        //            }
        //            /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
        //            {
        //                IntExpenseRNO++;
        //                DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

        //                DataTable DtabSubGroup = DTView.ToTable();

        //                DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

        //                foreach (DataRow DRDist in DTabDistinct.Rows)
        //                {

        //                    double DouAmount = 0;
        //                    double DouOpeningAmount = 0;

        //                    foreach (DataRow DR1 in DtabSubGroup.Rows)
        //                    {
        //                        if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
        //                        {
        //                            DouAmount = DouAmount + Val.Val(DR1["EXPENSE_AMOUNT"]);
        //                            DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
        //                        }
        //                    }

        //                    DTabExpense.Rows.Add("       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpeningAmount, "###############0.00"), Val.Format(DouAmount, "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
        //                }
        //            }
        //            else if (pStrReportTYpe == "ACCOUNT_TYPE")
        //            {
        //                IntExpenseRNO++;

        //                DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], Val.Format((Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""))), "###############0.00"),
        //                                                                   Val.Format((Val.Val(DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
        //            }*/
        //        }
        //    }

        //    // ---------------- FOR INCOME ---------------------------------

        //    DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
        //    DataView DTIncomeView = new DataView(DTabFilterIncome);
        //    int IntIncomeRNO = 0;
        //    foreach (DataRow DIRow in DTIncomeRow)
        //    {
        //        DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
        //        if (DTIncomeView.ToTable().Rows.Count > 0)
        //        {
        //            if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
        //            {
        //                IntIncomeRNO++;

        //                DataTable DTabSub = DTIncomeView.ToTable();
        //                DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

        //                foreach (DataRow DRDist in DTabDistinct.Rows)
        //                {
        //                    DataRow DRNew = DTabIncome.NewRow();

        //                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
        //                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
        //                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
        //                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

        //                    Double DouAmount = 0, DouOpening = 0;

        //                    DouAmount = Val.Val(DTabSub.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
        //                    DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

        //                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
        //                    DRNew["INCOME_AMOUNT"] = DouAmount;
        //                    DTabIncome.Rows.Add(DRNew);
        //                }
        //            }
        //            /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
        //            {
        //                IntIncomeRNO++;
        //                DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

        //                DataTable DtabSubGroup = DTIncomeView.ToTable();

        //                DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

        //                foreach (DataRow DRDist in DTabDistinct.Rows)
        //                {
        //                    double DouAmount = 0;
        //                    double DouOpeningAmount = 0;

        //                    foreach (DataRow DR1 in DtabSubGroup.Rows)
        //                    {
        //                        if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
        //                        {
        //                            DouAmount = DouAmount + Val.Val(DR1["INCOME_AMOUNT"]);
        //                            DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
        //                        }
        //                    }

        //                    DTabIncome.Rows.Add("       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpeningAmount, "###############0.00"), Val.Format(DouAmount, "###############0.00"), IntIncomeRNO, DIRow["ACCOUNT_TYPE_NAME"]);
        //                }
        //            }
        //            else if (pStrReportTYpe == "ACCOUNT_TYPE")
        //            {
        //                IntIncomeRNO++;
        //                DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], Val.Format((Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""))), "###############0.00"),
        //                                                                   Val.Format((Val.Val(DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00"), IntIncomeRNO, DIRow["ACCOUNT_TYPE_NAME"]);
        //            }*/
        //        }
        //    }

        //    double DouGrossDiff = 0;

        //    double DouExpenseOpening = 0;
        //    double DouExpenseAmount = 0;
        //    double DouIncomeOpening = 0;
        //    double DouIncomeAmount = 0;

        //    double DouLastExpenseGrossProfit = 0;
        //    double DouLastIncomeGrossProfit = 0;
        //    double DouLastExpenseAmount = 0;
        //    double DouLastIncomeAmount = 0;

        //    for (int IntI = 0; IntI < 5; IntI++)
        //    {
        //        DataRow[] UDRowExpense = DTabExpense.Select("EXPENSE_SRNO=" + (IntI + 1).ToString());
        //        DataRow[] UDRowIncome = DTabIncome.Select("INCOME_SRNO=" + (IntI + 1).ToString());

        //        int Diff = UDRowExpense.Count() - UDRowIncome.Count();

        //        DouExpenseOpening = 0;
        //        DouExpenseAmount = 0;
        //        DouIncomeOpening = 0;
        //        DouIncomeAmount = 0;

        //        if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
        //        {
        //            if (pStrReportTYpe != "ACCOUNT_TYPE")
        //            {

        //                /*if (IntI < 3 && DouGrossDiff < 0)
        //                {
        //                    DouLastExpenseGrossProfit = DouGrossDiff;

        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff*-1, "###############0.00");

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = "";

        //                    DTabCombine.Rows.Add(DRNew);

        //                }
        //                else if (IntI < 3 && DouGrossDiff > 0)
        //                {
        //                    DouLastIncomeGrossProfit = DouGrossDiff;
                            
        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = "";

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

        //                    DTabCombine.Rows.Add(DRNew);
        //                }
        //                */

        //                DataRow DRNew = DTabCombine.NewRow();

        //                DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"] + " :- ";
        //                DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                DRNew["EXPENSE_AMOUNT"] = "";

        //                DRNew["INCOME_DETAIL_MODE"] = "";
        //                DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"] + " :- ";
        //                DRNew["INCOME_OPENING_AMOUNT"] = "";
        //                DRNew["INCOME_AMOUNT"] = "";

        //                DTabCombine.Rows.Add(DRNew);
        //            }
        //        }

        //        if (Diff == 0)
        //        {
        //            for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
        //            {
        //                DataRow DRNew = DTabCombine.NewRow();

        //                DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
        //                DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
        //                DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
        //                DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
        //                DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

        //                DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
        //                DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
        //                DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
        //                DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
        //                DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

        //                DTabCombine.Rows.Add(DRNew);

        //                DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
        //                DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

        //                DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
        //                DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

        //            }
        //        }
        //        else if (Diff < 0)
        //        {
        //            for (int IntJ = 0; IntJ < UDRowIncome.Count(); IntJ++)
        //            {
        //                DataRow DRNew = DTabCombine.NewRow();

        //                if (IntJ < UDRowExpense.Count())
        //                {
        //                    DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
        //                    DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

        //                    DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
        //                    DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);

        //                }
        //                else
        //                {
        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = "";
        //                }

        //                DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
        //                DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
        //                DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
        //                DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
        //                DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

        //                DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
        //                DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);

        //                DTabCombine.Rows.Add(DRNew);
        //            }
        //        }

        //        else if (Diff > 0)
        //        {
        //            for (int IntJ = 0; IntJ < UDRowExpense.Count(); IntJ++)
        //            {
        //                DataRow DRNew = DTabCombine.NewRow();

        //                if (IntJ < UDRowIncome.Count())
        //                {
        //                    DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
        //                    DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
        //                    DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
        //                    DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
        //                    DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

        //                    DouIncomeOpening += Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]);
        //                    DouIncomeAmount += Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]);
        //                }
        //                else
        //                {
        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = "";
        //                    DRNew["INCOME_AMOUNT"] = "";
        //                }

        //                DRNew["EXPENSE_DETAIL_MODE"] = UDRowExpense[IntJ]["EXPENSE_DETAIL_MODE"];
        //                DRNew["EXPENSE_ACCOUNT_CODE"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_CODE"];
        //                DRNew["EXPENSE_ACCOUNT_NAME"] = UDRowExpense[IntJ]["EXPENSE_ACCOUNT_NAME"];
        //                DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
        //                DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

        //                DouExpenseOpening += Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]);
        //                DouExpenseAmount += Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]);
        //                DTabCombine.Rows.Add(DRNew);
        //            }
        //        }

        //        if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
        //        {
        //            if (pStrReportTYpe != "ACCOUNT_TYPE")
        //            {
        //                DataRow DRNew = DTabCombine.NewRow();

        //                DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
        //                DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Format(DouExpenseOpening, "#################0.00");
        //                DRNew["EXPENSE_AMOUNT"] = Val.Format(DouExpenseAmount, "#################0.00");
        //                DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
        //                DRNew["INCOME_OPENING_AMOUNT"] = Val.Format(DouIncomeOpening, "#################0.00");
        //                DRNew["INCOME_AMOUNT"] = Val.Format(DouIncomeAmount, "#################0.00");

        //                DTabCombine.Rows.Add(DRNew);

        //                DouGrossDiff += DouIncomeAmount - DouExpenseAmount;

        //                DouLastExpenseAmount = DouExpenseAmount;
        //                DouLastIncomeAmount = DouIncomeAmount;

        //                if (IntI < 2 && DouGrossDiff > 0)
        //                {
        //                    DouLastExpenseGrossProfit = DouGrossDiff + DouLastIncomeAmount;

        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = "";

        //                    DTabCombine.Rows.Add(DRNew);

        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = 0;

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

        //                    DTabCombine.Rows.Add(DRNew);

        //                }
        //                else if (IntI < 2 && DouGrossDiff < 0)
        //                {
        //                    DouLastIncomeGrossProfit = DouGrossDiff + DouLastExpenseAmount;

        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = "";

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS b/f";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

        //                    DTabCombine.Rows.Add(DRNew);

        //                    DRNew = DTabCombine.NewRow();

        //                    DRNew["EXPENSE_DETAIL_MODE"] = "";
        //                    DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //                    DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
        //                    DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //                    DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

        //                    DRNew["INCOME_DETAIL_MODE"] = "";
        //                    DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //                    DRNew["INCOME_ACCOUNT_NAME"] = "";
        //                    DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //                    DRNew["INCOME_AMOUNT"] = "";

        //                    DTabCombine.Rows.Add(DRNew);

        //                }
        //            }
        //        }
        //    }

        //    //DTabCombine.Rows.Add("EXPENSE ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_OPENING_AMOUNT)", ""))), "###############0.00"),
        //    //                                                Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"),
        //    //                     "INCOME ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_OPENING_AMOUNT)", ""))), "###############0.00"),
        //    //                                                Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00")
        //    //                                                );



        //    double DblSumIncome = Val.ToDouble(DTabFilterIncome.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));
        //    double DblSumExpense = Val.ToDouble(DTabFilterExpense.Compute("SUM(CREDIT_AMOUNT)-SUM(DEBIT_AMOUNT)", ""));

        //    if (DblSumIncome - DblSumExpense > 0)
        //    {
        //        DataRow DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = "";

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = "";
        //        DTabCombine.Rows.Add(DRNew);

        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = Val.Format((DblSumIncome - DblSumExpense), "###############0.00");

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = "";
        //        DTabCombine.Rows.Add(DRNew);

        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = "";

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = "";
        //        DTabCombine.Rows.Add(DRNew);


        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");
        //        DTabCombine.Rows.Add(DRNew);

        //    }

        //    else if (DblSumIncome - DblSumExpense < 0)
        //    {
        //        DataRow DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = "";

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = "";
        //        DTabCombine.Rows.Add(DRNew);

        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = "";

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = Val.Format((DblSumExpense - DblSumIncome), "###############0.00");
        //        DTabCombine.Rows.Add(DRNew);

        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = "";

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "----------------------------------";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = "";
        //        DTabCombine.Rows.Add(DRNew);


        //        DRNew = DTabCombine.NewRow();
        //        DRNew["EXPENSE_DETAIL_MODE"] = "";
        //        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
        //        DRNew["EXPENSE_ACCOUNT_NAME"] = "TOTAL";
        //        DRNew["EXPENSE_OPENING_AMOUNT"] = "";
        //        DRNew["EXPENSE_AMOUNT"] = Val.Format((DouLastExpenseAmount + DouLastExpenseGrossProfit), "###############0.00");

        //        DRNew["INCOME_DETAIL_MODE"] = "";
        //        DRNew["INCOME_ACCOUNT_CODE"] = 0;
        //        DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
        //        DRNew["INCOME_OPENING_AMOUNT"] = 0;
        //        DRNew["INCOME_AMOUNT"] = Val.Format((DouLastIncomeAmount + DouLastIncomeGrossProfit), "###############0.00");
        //        DTabCombine.Rows.Add(DRNew);
        //    }

        //    return DTabCombine;
        //}

       

        #endregion

        //public double FindLedger_Opening_Balance(int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, int pIntLedgerCode, string pStrStartDate, string pStrFromDate) // Add By Khushbu 11/09/2014
        //{
        //    /* Commented : Narendra : 07/May/2015
        //    InterfaceLayer Ope = new InterfaceLayer();
        //    BLL.Validation Val = new BLL.Validation();

        //    Request Request = new Request();

        //    // Commented : Narendar : 10-Apr-2015
        //    string StrSql = "SELECT FN_ACC_OPENING_BALANCE (" + pIntCompanyCode + "," + pIntBranchCode + "," + pIntLocationCode + "," + pIntLedgerCode +
        //                    ",'" + pStrStartDate + "','" + pStrFromDate + "') FROM DUAL";

        //    // Add : Narendar : 10-Apr-2015
        //    //string StrSql = "SELECT FN_ACC_OPENING_BALANCE (" + pIntCompanyCode + "," + pIntBranchCode + "," + pIntLocationCode + "," + pIntLedgerCode +
        //    //               ",'01/APR/2014','" + pStrFromDate + "') FROM DUAL";

        //    Request.CommandText = StrSql;

        //    //Request.CommandText = "Select FN_Find_Polish_CP_Rate(" + pIntShapeCode + "," + pIntPolishClarityCode + "," + pIntPolishColorCode + "," + pIntSieveCode + "," + pIntPcs + "," + pDouCarat + "," + pDouExpPer + "," + pDouReadyCarat + ",'" + pStrRDate + "') from dual";

        //    Request.CommandType = CommandType.Text;

        //    return Val.ToDouble(Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request));*/

        //    // Add : Narendra : 07/May/2015
        //    return GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, pIntLedgerCode, Val.DBDate(pStrStartDate));
        //}

        public DataTable Generate_BalanceSheet_Report_Vertical(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate , string pStrToDate) //Khushbu 11/09/2014
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));

                DTabCombine.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("AMOUNT", typeof(string)));

                DTab.DefaultView.RowFilter = "ENTRY_DATE >= '" + pStrFromDate + "' AND ENTRY_DATE <= '" + pStrToDate + "'";
                DTab = DTab.DefaultView.ToTable();

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();

                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();

                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///


                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                    if (DTView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                    if( (DouAmount + DouOpening ) != 0 ) // Add ; Narendra ; 06-Oct-2015
                                    DTabExpense.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        // Add ; Narendra : 06-Oct-2015
                                        if (UDRowGroup.Count() <= 0)
                                            continue;
                                        // End ; Narendra : 06-Oct-2015

                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouGrpTotal = 0.00;


                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouOpenig = 0;
                                            //DRNew = DTabExpense.NewRow();
                                            //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                            //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                            //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                        //    DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                            DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                            // DTabExpense.Rows.Add(DRNew);
                                        }

                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;
                                        DTabExpense.Rows.Add(DRNew);
                                    }

                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;

                            DTabExpense.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                            //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;
                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                    //DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpenig, "###############0.00"), Val.Format(DouGrpTotal, "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                   // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;

                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                            DouAmount + DouOpeningAmount, IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;

                            DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if ((DouAmount + DouOpening) != 0) // Add ; Narendra ; 06-Oct-2015
                                    DTabIncome.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        // Add : Narendra : 06-Oct-2015
                                        if (UDRowGroup.Count() <= 0)
                                            continue;
                                        // end : Narendra : 06-Oct-2015

                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                            //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;

                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = DouIncomeTot;

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_GROUP_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                    {
                                        //DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_GROUP_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]) + ""));

                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                    //DouOpeningAmount += //FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));


                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }

                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;


                DTabCombine.Rows.Add("", 0, "Source Of Funds :", "", "");

                DouExpenseAmount = Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", " EXPENSE_ACCOUNT_CODE <> 0"));
                DouIncomeAmount = Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", " INCOME_ACCOUNT_CODE <> 0"));

                for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                    DTabCombine.Rows.Add(DRNew);

                    DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                   // DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());

               /* Commeted : Narendra : 16-Jan-2015
               * 
               if (DouIncomeAmount - DouExpenseAmount > 0)
               {
                   DataRow DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["OPENING_AMOUNT"] = 0;
                   DRNew["AMOUNT"] = 0;

                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                   DRNew["OPENING_AMOUNT"] = 0;
                   DRNew["AMOUNT"] = Val.Format((DouIncomeAmount - DouExpenseAmount), "###############0.00");

                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();

                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["OPENING_AMOUNT"] = 0;
                   DRNew["AMOUNT"] = 0;
                   DTabCombine.Rows.Add(DRNew);


                   DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "TOTAL";
                   DRNew["OPENING_AMOUNT"] = 0;
                   DRNew["AMOUNT"] = Val.Format(DouIncomeAmount, "###############0.00");
                   DTabCombine.Rows.Add(DRNew);

               }
               else*/
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = Val.Format(DouExpenseAmount, "###############0.00");
                    DTabCombine.Rows.Add(DRNew);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());
                DTabCombine.Rows.Add("", 0, "Application Of Funds :", "", "");

                for (int IntIncome = 0; IntIncome < DTabIncome.Rows.Count; IntIncome++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabIncome.Rows[IntIncome]["INCOME_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"], "#################0.00");

                    DTabCombine.Rows.Add(DRNew);

                    DouIncomeOpening += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]);
                   // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]);
                }

              /* Commeted : Narendra : 16-Jan-2015
              * 
              if (DouIncomeAmount - DouExpenseAmount < 0)
               {
                   DataRow DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["OPENING_AMOUNT"] = "";
                   DRNew["AMOUNT"] = "";

                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();
                 
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                   DRNew["OPENING_AMOUNT"] = 0;
                   DRNew["AMOUNT"] = Val.Format((DouExpenseAmount - DouIncomeAmount), "###############0.00");
                   DTabCombine.Rows.Add(DRNew);

                   DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "----------------------------------";
                   DRNew["OPENING_AMOUNT"] = "";
                   DRNew["AMOUNT"] = "";

                   DTabCombine.Rows.Add(DRNew);


                   DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "TOTAL";
                   DRNew["OPENING_AMOUNT"] = "";
                   DRNew["AMOUNT"] = Val.Format((DouExpenseAmount), "###############0.00");
                   DTabCombine.Rows.Add(DRNew);

               }
              else*/
               {
                   DataRow DRNew = DTabCombine.NewRow();
                   DRNew["DETAIL_MODE"] = "";
                   DRNew["ACCOUNT_CODE"] = 0;
                   DRNew["ACCOUNT_NAME"] = "TOTAL";
                   DRNew["OPENING_AMOUNT"] = "";
                   DRNew["AMOUNT"] = Val.Format((DouIncomeAmount), "###############0.00");
                   DTabCombine.Rows.Add(DRNew);
               }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Generate_BalanceSheet_Report_Vertical_NEW(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrStartDate, string pStrFromDate, string pStrToDate) //Add ; Narendra : 06-Oct-2015
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));

                // Add : Narendra : 06-Oct-2015
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
                // End : Narendra : 06-Oct-2015

                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));

                DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));


                DTabCombine.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("AMOUNT", typeof(string)));

                /* Commented : Narendra : 06-Oct-2015
                DTab.DefaultView.RowFilter = "ENTRY_DATE >= '" + pStrFromDate + "' AND ENTRY_DATE <= '" + pStrToDate + "'";
                DTab = DTab.DefaultView.ToTable();

                DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'";
                DataTable DTabFilterExpense = DTab.DefaultView.ToTable();

                DTab.DefaultView.RowFilter = "TYPE = 'INCOME'";
                DataTable DTabFilterIncome = DTab.DefaultView.ToTable();
                */

                // Add : Narendra ; 06-Oct-2015
                // FILTER WITH ONLY EXPENSE TYPE DATA
                var QueryExpense = from row in DTab.AsEnumerable()
                                   where row.Field<string>("TYPE") == "EXPENSE" && (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate))
                                   select row;
                DataTable DTabFilterExpense = DTab.Clone();
                DTabFilterExpense = QueryExpense.Count() > 0 ? QueryExpense.CopyToDataTable() : null;

                // FILTER WITH ONLY INCOME TYPE DATA
                var QueryIncome = from row in DTab.AsEnumerable()
                                  where row.Field<string>("TYPE") == "INCOME" && (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate))
                                  select row;
                DataTable DTabFilterIncome = DTab.Clone();
                DTabFilterIncome = QueryIncome.Count() > 0 ? QueryIncome.CopyToDataTable() : null;
                // End : Narendra : 06-Oct-2015


                // Add Code By Khushbu 07/09/2014 ---- //
                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

               // DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0)
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///

                // Add : Narendra : 06-Oct-2015
                // CALCULATE LEDGER CR/DR BALANCE...
                var QueryLedgerAmount = DTab.AsEnumerable()
               .GroupBy(w => new
               {
                   LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
               })
               .Select(x => new
               {
                   DETAIL_MODE = x.Key.DETAIL_MODE,
                   LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                   AMOUNT = Val.Val((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

               })
               .Where(A => A.DETAIL_MODE == "LEDGER");

                DataTable DtTempAmount = new DataTable();
                if (QueryLedgerAmount.Count() > 0)
                {
                    DtTempAmount = LINQToDataTable(QueryLedgerAmount);
                }


                // GET ALL LEDGER OPENING BALANCE 
                DataTable DTabOpeningAmount = new DataTable();
                DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(pStrFromDate));

                // End : Narendra : 06-Oct-2015


                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    // Commented ; Narendra ; 06-Oct-2015
                    // DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];

                    // Add : Narendra : 06-Oct-2015
                    var QueryDTView = (from row in DTabFilterExpense.AsEnumerable()
                                       where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DR["ACCOUNT_TYPE_CODE"])
                                       orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                       select new
                                       {
                                           LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                           LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                           ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                           ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                           UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                           DETAIL_MODE = (string)row["DETAIL_MODE"],
                                           TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                           ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                       }
                                     )
                                    .Distinct();

                    
                    // if (DTView.ToTable().Rows.Count > 0) // Commented ; Narendra ; 06-Oct-2015
                    if (QueryDTView.Count() > 0)// Add ; Narendra ; 06-Oct-2015
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabSub = DTView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            if (boolDetails)// Add ; Narendra ; 06-Oct-2015
                            DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    Double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                 //   DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                    if ((DouAmount + DouOpening) != 0) // Add ; Narendra ; 06-Oct-2015
                                        DTabExpense.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        // Add ; Narendra : 06-Oct-2015
                                        if (UDRowGroup.Count() <= 0)
                                            continue;
                                        // End ; Narendra : 06-Oct-2015

                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouGrpTotal = 0.00;


                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouOpenig = 0;

                                            //DRNew = DTabExpense.NewRow();
                                            //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                            //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                            //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                           // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                            DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                            // DTabExpense.Rows.Add(DRNew);
                                        }

                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;
                                        DTabExpense.Rows.Add(DRNew);
                                    }

                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;

                            DTabExpense.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntExpenseRNO++;

                            //  DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DataTable DtabSubGroup = DTView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            DTabExpense.Rows.Add(DRNew);

                            DataTable DTabGroupDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                            DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                            foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                            {
                                DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                double DouAmount = 0, DouGrpTotal = 0.00;

                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                {
                                    DouOpenig = 0;

                                    DouAmount = Val.Val(DtabSubGroup.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) * -1", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                   // DouOpenig = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                }

                                DTabExpense.Rows.Add(0, "       " + DRGroup["ACCOUNT_TYPE_GROUP_NAME"], Val.Format(DouOpenig, "###############0.00"), Val.Format(DouGrpTotal, "###############0.00"), IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            IntExpenseRNO++;

                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DROW in DTView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DROW["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DR["ACCOUNT_TYPE_CODE"]))
                                {
                                   // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT) * -1", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                            DouOpeningAmount = DouOpeningAmount * -1;

                            DTabExpense.Rows.Add(0, DR["ACCOUNT_TYPE_NAME"], DouOpeningAmount,
                                                                            DouAmount + DouOpeningAmount, IntExpenseRNO, DR["ACCOUNT_TYPE_NAME"]);
                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                    if (DTIncomeView.ToTable().Rows.Count > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabSub = DTIncomeView.ToTable();
                            DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;

                            DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    double DouAmount = 0, DouOpening = 0;

                                    DouAmount = Val.Val(DTabSub.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                    //DouOpening = Val.Val(DTabSub.Compute("Sum(OPENING_AMOUNT)", " LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                   // DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrStartDate, pStrFromDate);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if ((DouAmount + DouOpening) != 0) // Add ; Narendra ; 06-Oct-2015
                                        DTabIncome.Rows.Add(DRNew);
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    DataTable DTabGroupDistinct = DTab.Select("LEDGER_CODE_COMBINE = " + Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_GROUP_SRNO");

                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_GROUP_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]) + "'");
                                        // Add : Narendra : 06-Oct-2015
                                        if (UDRowGroup.Count() <= 0)
                                            continue;
                                        // end : Narendra : 06-Oct-2015

                                        DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouAmount = Val.Val(DTabSub.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)) ", " LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));
                                          //  DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                            DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;

                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_GROUP_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_GROUP_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = DouIncomeTot;

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {
                            IntIncomeRNO++;
                            DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                            DataTable DtabSubGroup = DTIncomeView.ToTable();

                            DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME");

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                double DouOpeningAmount = 0;

                                foreach (DataRow DROW in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "LEDGER_CODE").Rows)
                                {
                                    if (Val.ToInt(DROW["ACCOUNT_TYPE_GROUP_CODE"]) == Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                    {
                                       // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DROW["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));
                                    }
                                }
                                double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_GROUP_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_GROUP_CODE"]) + ""));

                                DataRow DRNew = DTabIncome.NewRow();
                                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = "";

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                                DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                                DTabIncome.Rows.Add(DRNew);
                            }
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {
                            double DouOpeningAmount = 0.00;
                            foreach (DataRow DR in DTIncomeView.ToTable(true, "ACCOUNT_TYPE_CODE", "LEDGER_CODE").Rows)
                            {
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]))
                                {
                                   // DouOpeningAmount += FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DR["LEDGER_CODE"]), Val.DBDate(pStrStartDate), Val.DBDate(pStrFromDate));

                                }
                            }
                            double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));


                            IntIncomeRNO++;

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            DRNew["INCOME_DETAIL_MODE"] = "";

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount + DouOpeningAmount;
                            DTabIncome.Rows.Add(DRNew);

                        }

                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;


                DTabCombine.Rows.Add("", 0, "Source Of Funds :", "", "");

                DouExpenseAmount = Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", " EXPENSE_ACCOUNT_CODE <> 0"));
                DouIncomeAmount = Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", " INCOME_ACCOUNT_CODE <> 0"));

                for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                    DTabCombine.Rows.Add(DRNew);

                    DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                    // DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());

                /* Commeted : Narendra : 16-Jan-2015
                * 
                if (DouIncomeAmount - DouExpenseAmount > 0)
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = 0;

                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "DIFF IN OPENING BALANCE";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = Val.Format((DouIncomeAmount - DouExpenseAmount), "###############0.00");

                    DTabCombine.Rows.Add(DRNew);

                    DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "----------------------------------";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = 0;
                    DTabCombine.Rows.Add(DRNew);


                    DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = Val.Format(DouIncomeAmount, "###############0.00");
                    DTabCombine.Rows.Add(DRNew);

                }
                else*/
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = Val.Format(DouExpenseAmount, "###############0.00");
                    DTabCombine.Rows.Add(DRNew);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());
                DTabCombine.Rows.Add("", 0, "Application Of Funds :", "", "");

                for (int IntIncome = 0; IntIncome < DTabIncome.Rows.Count; IntIncome++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabIncome.Rows[IntIncome]["INCOME_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"], "#################0.00");

                    DTabCombine.Rows.Add(DRNew);

                    DouIncomeOpening += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]);
                    // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]);
                }

                /* Commeted : Narendra : 16-Jan-2015
                * 
                if (DouIncomeAmount - DouExpenseAmount < 0)
                 {
                     DataRow DRNew = DTabCombine.NewRow();
                     DRNew["DETAIL_MODE"] = "";
                     DRNew["ACCOUNT_CODE"] = 0;
                     DRNew["ACCOUNT_NAME"] = "----------------------------------";
                     DRNew["OPENING_AMOUNT"] = "";
                     DRNew["AMOUNT"] = "";

                     DTabCombine.Rows.Add(DRNew);

                     DRNew = DTabCombine.NewRow();
                 
                     DRNew["DETAIL_MODE"] = "";
                     DRNew["ACCOUNT_CODE"] = 0;
                     DRNew["ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                     DRNew["OPENING_AMOUNT"] = 0;
                     DRNew["AMOUNT"] = Val.Format((DouExpenseAmount - DouIncomeAmount), "###############0.00");
                     DTabCombine.Rows.Add(DRNew);

                     DRNew = DTabCombine.NewRow();
                     DRNew["DETAIL_MODE"] = "";
                     DRNew["ACCOUNT_CODE"] = 0;
                     DRNew["ACCOUNT_NAME"] = "----------------------------------";
                     DRNew["OPENING_AMOUNT"] = "";
                     DRNew["AMOUNT"] = "";

                     DTabCombine.Rows.Add(DRNew);


                     DRNew = DTabCombine.NewRow();
                     DRNew["DETAIL_MODE"] = "";
                     DRNew["ACCOUNT_CODE"] = 0;
                     DRNew["ACCOUNT_NAME"] = "TOTAL";
                     DRNew["OPENING_AMOUNT"] = "";
                     DRNew["AMOUNT"] = Val.Format((DouExpenseAmount), "###############0.00");
                     DTabCombine.Rows.Add(DRNew);

                 }
                else*/
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = "";
                    DRNew["AMOUNT"] = Val.Format((DouIncomeAmount), "###############0.00");
                    DTabCombine.Rows.Add(DRNew);
                }

                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Generate_BalanceSheet_Report_Vertical_NEW_LINQ(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrFromDate, string pStrToDate, bool boolDetails) // Add : Narendra : 06-Oct-2015
        {
            try
            {

                DataTable DTabExpense = new DataTable();
                DataTable DTabIncome = new DataTable();
                DataTable DTabCombine = new DataTable();

                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));


                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));


                /*DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));*/

                DTabCombine.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OR_EXPENSE", typeof(string)));

                /*DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
                //DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_CODE", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
                DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));*/

                DataTable DtData = new DataTable();
                DtData = DTab.Clone();
                var QueryFromToDate = from row in DTab.AsEnumerable()
                                   //where (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate)) // COMMENTED ; NARENDRA ; 26-OCT-2015
                                      where (row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate)) // ADD ; NARENDRA ; 26-OCT-2015
                                   select row;
                DtData = QueryFromToDate.Count() > 0 ? QueryFromToDate.CopyToDataTable() : null;

                if (DtData == null || DtData.Rows.Count == 0)
                    return null;

                #region Calculate Opening Amount For Profit & Loss Report.

                DataTable DTOpeningAmount = GetProfitLossAmount(pIntCompanyCode, pIntBranchCode, pIntLocationCode, pStrToDate);
                double DoupProfitLossAmount = 0.00;
                DoupProfitLossAmount = Val.Val(DTOpeningAmount.Rows[0]["AMOUNT"]);
                DtData.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == "645").ToList().ForEach(r => r.SetField("CREDIT_AMOUNT_1", (DoupProfitLossAmount > 0 ? -DoupProfitLossAmount : 0)));
                DtData.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == "645").ToList().ForEach(r => r.SetField("DEBIT_AMOUNT_1", (DoupProfitLossAmount < 0 ? DoupProfitLossAmount : 0)));

                #endregion


                #region Manage BRANCH / DIVISIONS AND SUSPENSE A/C Account Type Sides On Balance Sheet.

                // Add : Narendra : 26-Oct-2015

                string[] StrAccountTypeCode = Val.Trim("7,9").Split(','); // 7 : BRANCH / DIVISIONS, 9 : SUSPENSE A/C :: GET BOTH THIS TYPE UNDER LEDGER ACCOUNT AND FIX SIDE ON BALANCE SHEET - ASSETS/LIABILITIES.
                string AccountTypeCode_BRANCH_DEVISION = string.Empty;
                string AccountTypeCode_SUSPENSE = string.Empty;
                for (int i = 0; i < StrAccountTypeCode.Length; i++)
                {
                    if (StrAccountTypeCode[i].Trim().Equals(string.Empty))
                        continue;

                    string StrAccountType = Val.ToString(StrAccountTypeCode[i]);
                    DataTable DTTemp = Get_Tree_Account_Type_Master(StrAccountType);
                    foreach (DataRow DrowAcc in DTTemp.Rows)
                    {
                        if (i == 0)
                            AccountTypeCode_BRANCH_DEVISION = AccountTypeCode_BRANCH_DEVISION + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                        else if (i == 1)
                            AccountTypeCode_SUSPENSE = AccountTypeCode_SUSPENSE + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                    }

                }
                if (AccountTypeCode_BRANCH_DEVISION.Length > 1)
                    AccountTypeCode_BRANCH_DEVISION = "," + AccountTypeCode_BRANCH_DEVISION;
                if (AccountTypeCode_SUSPENSE.Length > 1)
                    AccountTypeCode_SUSPENSE = "," + AccountTypeCode_SUSPENSE;


                var QueryBranchDivision = (from row in DtData.AsEnumerable()
                                           where AccountTypeCode_BRANCH_DEVISION.Contains("," + row.Field<decimal>("ACCOUNT_TYPE_CODE") + ",")
                                           select new
                                           {
                                               LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                               LEDGER_NAME = (string)row["LEDGER_NAME"],
                                           })
                                       .Distinct();

                double DouBranchDivision = 0.00;
                if (QueryBranchDivision.Count() > 0)
                {
                    DataTable DTabBranchDivision = LINQToDataTable(QueryBranchDivision);
                    foreach (DataRow DrBranchDivision in DTabBranchDivision.Rows)
                    {
                        //DouBranchDivision += GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.CLOSING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DrBranchDivision["LEDGER_CODE"]), Val.DBDate(pStrToDate));
                    }
                    DtData.Rows.Cast<DataRow>().Where(r => r["ACCOUNT_TYPE_CODE"].ToString() == "7").ToList().ForEach(r => r.SetField("TYPE", (DouBranchDivision < 0 ? "EXPENSE" : "INCOME")));
                }



                var QuerySuspense = (from row in DtData.AsEnumerable()
                                     where AccountTypeCode_SUSPENSE.Contains("," + row.Field<decimal>("ACCOUNT_TYPE_CODE") + ",")
                                     select new
                                     {
                                         LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                         LEDGER_NAME = (string)row["LEDGER_NAME"],
                                     })
                                           .Distinct();
                double DouSuspense = 0.00;
                if (QuerySuspense.Count() > 0)
                {
                    DataTable DTabSuspense = LINQToDataTable(QuerySuspense);
                    foreach (DataRow DrSuspense in DTabSuspense.Rows)
                    {
                      //  DouSuspense += GlobalDec.FindLedgerOpeningClosing(GlobalDec.LEDGEROPENING.CLOSING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DrSuspense["LEDGER_CODE"]), Val.DBDate(pStrToDate));
                    }
                    //IEnumerable<DataRow> rowsSuspenseAc = 
                    DtData.Rows.Cast<DataRow>().Where(r => r["ACCOUNT_TYPE_CODE"].ToString() == "9").ToList().ForEach(r => r.SetField("TYPE", (DouSuspense < 0 ? "EXPENSE" : "INCOME")));
                }
                // END ; NARENDRA ; 26-Oct-2015

                #endregion

                DataTable dT001 = DTab.Select("LEDGER_CODE = 541").CopyToDataTable();
                // FILTER WITH ONLU EXPENSE TYPE DATA
                var QueryExpense = from row in DtData.AsEnumerable()
                                   where (row.Field<string>("TYPE") == "EXPENSE") && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                                        //&& (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate) )
                                   select row;
                DataTable DTabFilterExpense = DTab.Clone();
                DTabFilterExpense = QueryExpense.Count() > 0 ? QueryExpense.CopyToDataTable() : null;

                /*DataTable DtIncomeData = new DataTable();
                DtIncomeData = DTab.Clone();
                var QueryIncomeFromToDate = from row in DTab.AsEnumerable()
                                             where (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate))
                                             select row;
                DtIncomeData = QueryIncomeFromToDate.Count() > 0 ? QueryIncomeFromToDate.CopyToDataTable() : null;*/

                // FILTER WITH ONLU INCOME TYPE DATA
                var QueryIncome = from row in DtData.AsEnumerable()
                                  where row.Field<string>("TYPE") == "INCOME" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                                  //&& (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate))
                                  select row;
                DataTable DTabFilterIncome = DTab.Clone();
                DTabFilterIncome = QueryIncome.Count() > 0 ? QueryIncome.CopyToDataTable() : null;


                if (DTabFilterExpense.Rows.Count > 0)
                {
                    if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabExpense.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabExpense.Rows.Add(DRNew);

                        DTabExpense.Rows.Add("", "", "");
                    }
                }

                if (DTabFilterIncome.Rows.Count > 0)
                {
                    if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                    {
                        DataRow DRNew = DTabIncome.NewRow();

                        DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                        DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                        DRNew["EXPENSE_AMOUNT"] = 0;
                        DRNew["EXPENSE_SRNO"] = 0;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                        DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                        DRNew["DETAIL_MODE"] = "";
                        DTabIncome.Rows.Add(DRNew);

                        DTabIncome.Rows.Add("", "", "");

                    }
                }

                //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
                DataTable DTAccountType = new DataTable();

                DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
                DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
                DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
                DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
                DTAccountType.Columns.Add("BS_SRNO", typeof(int));

                /* Commented : Narendra ; 26-Oct-2015
                 * foreach (DataRow DRowType in DTAb.Rows)
                {
                    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0) // tO CHECK ONLY MAIN ACCOUNT TYPE.
                    {
                        DataRow DTNewRow = DTAccountType.NewRow();
                        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                        DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                        DTAccountType.Rows.Add(DTNewRow);
                    }
                }*/
                // Add : Narendra : 26-Oct-2015
                //foreach (DataRow DRowType in DTAb.Rows)
                //{
                //    if (Val.ToInt(DRowType["IN_BALANCESHEET"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0) // tO CHECK ONLY MAIN ACCOUNT TYPE.
                //    {
                //        DataRow DTNewRow = DTAccountType.NewRow();
                //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
                //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
                //        DTNewRow["IN_BALANCESHEET"] = DRowType["IN_BALANCESHEET"];
                //        //DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"]; // COMMENTED ; NARENDRA ; 10-10-2015
                //        // ADD ; NARENDRA ; 10-10-2015
                //        if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 7)
                //        {
                //            if (DouBranchDivision < 0)
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "CREDIT";
                //            else
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "DEBIT";
                //        }
                //        else if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 9)
                //        {
                //            if (DouSuspense < 0)
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "CREDIT";
                //            else
                //                DTNewRow["TRIAL_BALANCE_SIDE"] = "DEBIT";
                //        }
                //        else
                //            DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
                //        // END ; NARENDRA ; 10-10-2015

                //        DTNewRow["BS_SRNO"] = DRowType["BS_SRNO"];

                //        DTAccountType.Rows.Add(DTNewRow);
                //    }
                //}
                // End : Narendra : 26-Oct-2015

                DTAccountType.AcceptChanges();

                DTAccountType.DefaultView.Sort = "BS_SRNO";

                DTAccountType = DTAccountType.DefaultView.ToTable();
                //   ---------------------- ///

                // CALCULATE LEDGER CR/DR BALANCE...
                var QueryLedgerAmount = DtData.AsEnumerable()
               .GroupBy(w => new
               {
                   LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
               })
               .Select(x => new
               {
                   DETAIL_MODE = x.Key.DETAIL_MODE,
                   LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                   AMOUNT = Val.Val((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

               })
               .Where(A => A.DETAIL_MODE == "LEDGER");

                DataTable DtTempAmount = new DataTable();
                if (QueryLedgerAmount.Count() > 0)
                {
                    DtTempAmount = LINQToDataTable(QueryLedgerAmount);
                }


                // Add : Narendra : 29-Sep-2015 // GET ALL LEDGER OPENING BALANCE 
                DataTable DTabOpeningAmount = new DataTable();
                DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(GlobalDec.gFinancialYear_StartDate)); //pStrFromDate
                // End : Narendra : 29-Sep-2015
                // ----------------------- FOR EXPENSE -------------------------//

                DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
                //DataView DTView = new DataView(DTabFilterExpense);

                int IntExpenseRNO = 0;              
                foreach (DataRow DR in DTRow)
                {
                    double DouOpenig = 0;

                    // Add : Narendra : 28-Sep-2015
                    var QueryDTView = (from row in DTabFilterExpense.AsEnumerable()
                                       where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DR["ACCOUNT_TYPE_CODE"])
                                       orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                       select new
                                       {
                                           LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                           LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                           ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                           ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                           UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                           DETAIL_MODE = (string)row["DETAIL_MODE"],
                                           TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                           ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                       }
                                     )
                                    .Distinct();

                    if (QueryDTView.Count() > 0)
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntExpenseRNO++;

                            DataTable DTabDistinct = LINQToDataTable(QueryDTView); // Add : Narendra : 28-Sep-2015

                            DataRow DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                            DRNew["EXPENSE_AMOUNT"] = 0;

                            if (boolDetails)
                                DTabExpense.Rows.Add(DRNew);

                            double DouAccType_TotalAmt = 0.00;
                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {

                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabExpense.NewRow();

                                    DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["EXPENSE_ACCOUNT_NAME"] = "     " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                    DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    Double DouAmount = 0, DouOpening = 0;


                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rows != null && rows.Count() > 0)
                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]) * -1;

                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;

                                    DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;

                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;

                                    if (boolDetails)
                                    {
                                        if ((DouAmount + DouOpening) != 0)
                                        {
                                            //if (Val.Val(DRDist["LEDGER_CODE_COMBINE"]) == 645) // FOR PROFIT & LOSS A/C
                                            //{
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     OPENING BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouOpening;
                                            //    DTabExpense.Rows.Add(DRNew);
                                            //    DRNew["EXPENSE_ACCOUNT_NAME"] = "     CURRENT BALANCE";
                                            //    DRNew["EXPENSE_AMOUNT"] = DouAmount;
                                            //    DTabExpense.ImportRow(DRNew);
                                            //}
                                            //else
                                            DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {
                                    // Add : Narendra : 28-Sep-2015
                                    var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                                   orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                                   select new
                                                                   {
                                                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                                   }).Distinct();
                                    DataTable DTabGroupDistinct = QueryUDRowGroupDistinct.Count() > 0 ? LINQToDataTable(QueryUDRowGroupDistinct) : null;
                                    // Add : Narendra : 28-Sep-2015

                                    if (DTabGroupDistinct != null && DTabGroupDistinct.Rows.Count > 0) // Add : Narendra ; 29-Sep-2015
                                    {

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            // Add : Narendra : 28-Sep-2015
                                            var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                                   select new
                                                                   {
                                                                       LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                       LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                                   })
                                                                  .Distinct();
                                            DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                            // Add : Narendra : 28-Sep-2015

                                            double DouAmount = 0, DouGrpTotal = 0.00;
                                            DouOpenig = 0.00;
                                            if (DTabGroupLedgerDistinct != null && DTabGroupDistinct.Rows.Count > 0) // Add : Narendra ; 28-SEp-2015
                                            {
                                                foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                                {
                                                    DouOpenig = 0;

                                                    //DRNew = DTabExpense.NewRow();
                                                    //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                    //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                    //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                    //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                    //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                    DouAmount = 0.00;
                                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rows != null && rows.Count() > 0)
                                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]) * -1;

                                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                                        DouOpenig = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;


                                                    //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                    //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;
                                                    DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                    DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount;

                                                    // DTabExpense.Rows.Add(DRNew);
                                                }
                                            }
                                            DRNew = DTabExpense.NewRow();
                                            DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["EXPENSE_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                            DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                            DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                            if (boolDetails)
                                                DTabExpense.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabExpense.NewRow();
                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                            //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                            DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                            DTabExpense.Rows.Add(DRNew);


                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                        {

                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {

                        }
                    }
                }

                // ---------------- FOR INCOME ---------------------------------

                // Add : Narendra : 29-Sep-2015
                var QueryLedgerAmountIncome = DtData.AsEnumerable()
               .GroupBy(w => new
               {
                   LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
                   DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
               })
               .Select(x => new
               {
                   DETAIL_MODE = x.Key.DETAIL_MODE,
                   LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
                   //AMOUNT = Val.ToString((x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("DEBIT_AMOUNT"))))) - x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("CREDIT_AMOUNT")))))) * -1),
                   AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

               })
               .Where(A => A.DETAIL_MODE == "LEDGER");

                DtTempAmount = new DataTable();
                if (QueryLedgerAmountIncome.Count() > 0)
                {
                    DtTempAmount = LINQToDataTable(QueryLedgerAmountIncome);
                }
                // End : Narendra : 29-Sep-2015

                DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET = 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
                DataView DTIncomeView = new DataView(DTabFilterIncome);
                int IntIncomeRNO = 0;
                foreach (DataRow DIRow in DTIncomeRow)
                {
                    // Add : Narendra : 29-Sep-2015
                    var QueryDTIncomeView = (from row in DTabFilterIncome.AsEnumerable()
                                             where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"])
                                             orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                             select new
                                             {
                                                 LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                                 LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                                 ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                 ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                 UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                 DETAIL_MODE = (string)row["DETAIL_MODE"],
                                                 TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                 ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                             }
                                       )
                                      .Distinct();

                    if (QueryDTIncomeView.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015
                    {
                        if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                        {
                            IntIncomeRNO++;

                            DataTable DTabDistinct = LINQToDataTable(QueryDTIncomeView); // ADD ; NARENDRA ; 29-SEP-2015

                            DataRow DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = 0;
                            if (boolDetails)
                                DTabIncome.Rows.Add(DRNew);

                            double DouIncomeTot = 0.00;

                            foreach (DataRow DRDist in DTabDistinct.Rows)
                            {
                                if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                                {
                                    DRNew = DTabIncome.NewRow();

                                    DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                    DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                    DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                    DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                    DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                    DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                    DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                    double DouAmount = 0, DouOpening = 0;

                                    IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rows != null && rows.Count() > 0)
                                        DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                    //DTabSub
                                    //DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                    //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate); // COMMENTED ; NARENDRA ; 29-SEP-2015

                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);

                                    DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                    DRNew["INCOME_AMOUNT"] = DouOpening + DouAmount;
                                    DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                    if (boolDetails)
                                    {
                                        if ((DouOpening + DouAmount) != 0)
                                            DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                                else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                                {

                                    // COMMENTED : NARENDRA ; 29-SEP-2015 :: DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                    DataTable DTabGroupDistinct = new DataTable();

                                    var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                                   orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                                   select new
                                                                   {
                                                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                                   }).Distinct();

                                    if (QueryUDRowGroupDistinct.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015
                                    {
                                        DTabGroupDistinct = LINQToDataTable(QueryUDRowGroupDistinct); // ADD ; NARENDRA ; 29-SEP-2015

                                        foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                        {
                                            // Add : Narendra : 28-Sep-2015
                                            var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                                   select new
                                                                   {
                                                                       LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                       LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                                   })
                                                                  .Distinct();
                                            DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                            // Add : Narendra : 28-Sep-2015

                                            double DouAmount = 0, DouOpening = 0;

                                            double DouGrpTotal = 0.00;
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                DouAmount = 0.00;
                                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRow["LEDGER_CODE"]));
                                                if (rows != null && rows.Count() > 0)
                                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                                DouOpening = 0;
                                                IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rowsOpening != null && rowsOpening.Count() > 0)
                                                    DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);

                                                DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                                DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;
                                            }

                                            DRNew = DTabIncome.NewRow();
                                            DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                            DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                            DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                            DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                            DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                            DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                            DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                            if (boolDetails)
                                                DTabIncome.Rows.Add(DRNew);
                                        }
                                    }
                                }
                            }

                            DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);
                        }

                        else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS")
                        {                           
                        }
                        else if (pStrReportTYpe == "ACCOUNT_TYPE")
                        {                            
                        }
                    }
                }

                double DouExpenseOpening = 0;
                double DouExpenseAmount = 0;
                double DouIncomeOpening = 0;
                double DouIncomeAmount = 0;

                DTabCombine.Rows.Add("", 0, "Source Of Funds :", "", "");

                DouExpenseAmount = Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", " EXPENSE_ACCOUNT_CODE <> 0"));
                DouIncomeAmount = Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", " INCOME_ACCOUNT_CODE <> 0"));

                for (int IntJ = 0; IntJ < DTabExpense.Rows.Count; IntJ++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabExpense.Rows[IntJ]["EXPENSE_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabExpense.Rows[IntJ]["EXPENSE_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]));// Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                    // Add ; Narendra : 08-Oct-2015
                    DRNew["TOTAL_AMOUNT"] = Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) == 0 ? "" : (Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"]));// Val.Format(DTabExpense.Rows[IntJ]["EXPENSE_TOTAL_AMOUNT"], "#################0.00");
                    DRNew["TYPE_LEVEL"] = DTabExpense.Rows[IntJ]["EXPENSE_TYPE_LEVEL"];
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = DTabExpense.Rows[IntJ]["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                    DRNew["INCOME_OR_EXPENSE"]  = "EXPENSE";
                    // End ; Narendra : 08-Oct-2015

                    DTabCombine.Rows.Add(DRNew);

                    DouExpenseOpening += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_OPENING_AMOUNT"]);
                    // DouExpenseAmount += Val.Val(DTabExpense.Rows[IntJ]["EXPENSE_AMOUNT"]);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());


                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = 0;
                    DRNew["AMOUNT"] = "";// Val.Format(DouExpenseAmount, "###############0.00"); // Commented ; Narendra : 08-Oct-2015

                    // Add ; Narendra : 08-Oct-2015
                    DRNew["TOTAL_AMOUNT"] = DouExpenseAmount < 0 ? "(-) " + Val.FormatWithSeperator(DouExpenseAmount) : "" + Val.FormatWithSeperator(DouExpenseAmount);
                    DRNew["TYPE_LEVEL"] = 0;
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = 0;
                    DRNew["INCOME_OR_EXPENSE"] = "EXPENSE";
                    // End ; Narendra : 08-Oct-2015

                    DTabCombine.Rows.Add(DRNew);
                }

                DTabCombine.Rows.Add(DTabCombine.NewRow());
                DTabCombine.Rows.Add("", 0, "Application Of Funds :", "", "");

                for (int IntIncome = 0; IntIncome < DTabIncome.Rows.Count; IntIncome++)
                {
                    DataRow DRNew = DTabCombine.NewRow();

                    DRNew["DETAIL_MODE"] = DTabIncome.Rows[IntIncome]["INCOME_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = DTabIncome.Rows[IntIncome]["INCOME_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"], "#################0.00");
                    DRNew["AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]) == 0 ? "" : (Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]));// Val.Format(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"], "#################0.00");

                    // Add ; Narendra : 08-Oct-2015
                    DRNew["TOTAL_AMOUNT"] = Val.Val(DTabIncome.Rows[IntIncome]["INCOME_TOTAL_AMOUNT"]) == 0 ? "" : (Val.Val(DTabIncome.Rows[IntIncome]["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : "") + Val.FormatWithSeperator(Val.Val(DTabIncome.Rows[IntIncome]["INCOME_TOTAL_AMOUNT"]));// Val.Format(DTabIncome.Rows[IntIncome]["INCOME_TOTAL_AMOUNT"], "#################0.00");
                    DRNew["TYPE_LEVEL"] = DTabIncome.Rows[IntIncome]["INCOME_TYPE_LEVEL"];
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = DTabIncome.Rows[IntIncome]["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                    DRNew["INCOME_OR_EXPENSE"] = "INCOME";
                    // End ; Narendra : 08-Oct-2015

                    DTabCombine.Rows.Add(DRNew);

                    DouIncomeOpening += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_OPENING_AMOUNT"]);
                    // DouIncomeAmount += Val.Val(DTabIncome.Rows[IntIncome]["INCOME_AMOUNT"]);
                }

                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = "";
                    DRNew["ACCOUNT_CODE"] = 0;
                    DRNew["ACCOUNT_NAME"] = "TOTAL";
                    DRNew["OPENING_AMOUNT"] = "";
                    DRNew["AMOUNT"] = "";// Val.Format((DouIncomeAmount), "###############0.00"); // Commented ; Narendra : 08-Oct-2015

                    // Add ; Narendra : 08-Oct-2015
                    DRNew["TOTAL_AMOUNT"] = DouIncomeAmount < 0 ? "(-) " + Val.FormatWithSeperator(DouIncomeAmount) : "" + Val.FormatWithSeperator(DouIncomeAmount);
                    DRNew["TYPE_LEVEL"] = 0;
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = 0;
                    DRNew["INCOME_OR_EXPENSE"] = "INCOME";
                    // End ; Narendra : 08-Oct-2015

                    DTabCombine.Rows.Add(DRNew);
                }


                return DTabCombine;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GenerateProfitLossreport_Vertical_LINQ(DataTable DTab, string pStrReportTYpe, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrFromDate, string pStrToDate, bool boolDetails)  //ADD ; NARENDRA ; 18-FEB-2015 - 19-OCT-2015 ;; FOR DISPLAY REPORT LEVEL WISE WITH VERTICAL PROFIT & LOSS ACCOUNT REPORT
        {

            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();
            DataTable DTabCombine = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(double)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_SRNO", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));

            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(double)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_SRNO", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_TYPE_GROUP_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));

            DTabCombine.Columns.Add(new DataColumn("DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("TOTAL_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OR_EXPENSE", typeof(string)));

            /* COMMENTED ; NARENDRA ; 22-OCT-2015
             * DTabCombine.Columns.Add(new DataColumn("EXPENSE_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("EXPENSE_TOTAL_AMOUNT", typeof(string)));

           
            DTabCombine.Columns.Add(new DataColumn("INCOME_DETAIL_MODE", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_OPENING_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_UPPER_ACCOUNT_TYPE_CODE", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TYPE_LEVEL", typeof(int)));
            DTabCombine.Columns.Add(new DataColumn("INCOME_TOTAL_AMOUNT", typeof(string)));*/




            /* COMMENTED ; NARENDRA ; 01-OCT-2015
             * DTab.DefaultView.RowFilter = "TYPE = 'EXPENSE'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterExpense = DTab.DefaultView.ToTable();
            DTab.DefaultView.RowFilter = "TYPE = 'INCOME'  AND (TYPE_LEVEL = 1 OR TYPE_LEVEL = 2)";
            DataTable DTabFilterIncome = DTab.DefaultView.ToTable();*/

            DataTable DtData = new DataTable();
            DtData = DTab.Clone();
            var QueryFromToDate = from row in DTab.AsEnumerable()
                                  where (row.Field<DateTime>("ENTRY_DATE") >= Convert.ToDateTime(pStrFromDate) && row.Field<DateTime>("ENTRY_DATE") <= Convert.ToDateTime(pStrToDate))
                                  select row;
            DtData = QueryFromToDate.Count() > 0 ? QueryFromToDate.CopyToDataTable() : null;
            if (DtData == null || DtData.Rows.Count == 0)
                return null;
            // FILTER WITH ONLU EXPENSE TYPE DATA
            var QueryExpense = from row in DtData.AsEnumerable()
                               where row.Field<string>("TYPE") == "EXPENSE" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                               select row;
            DataTable DTabFilterExpense = DTab.Clone();
            DTabFilterExpense = QueryExpense.Count() > 0 ? QueryExpense.CopyToDataTable() : null;

            // FILTER WITH ONLU INCOME TYPE DATA
            var QueryIncome = from row in DtData.AsEnumerable()
                              where row.Field<string>("TYPE") == "INCOME" && (row.Field<decimal>("TYPE_LEVEL") == 1 || row.Field<decimal>("TYPE_LEVEL") == 2)
                              select row;
            DataTable DTabFilterIncome = DTab.Clone();
            DTabFilterIncome = QueryIncome.Count() > 0 ? QueryIncome.CopyToDataTable() : null;



            // Add Code By Khushbu 07/09/2014 ---- //
            if (DTabFilterExpense.Rows.Count > 0)
            {
                if (DTabFilterExpense.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabExpense.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabExpense.Rows.Add(DRNew);

                    DTabExpense.Rows.Add("", "", "");
                }
            }

            if (DTabFilterIncome.Rows.Count > 0)
            {
                if (DTabFilterIncome.Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DataRow DRNew = DTabIncome.NewRow();

                    DRNew["EXPENSE_ACCOUNT_CODE"] = "";
                    DRNew["EXPENSE_ACCOUNT_NAME"] = DTabFilterExpense.Rows[0]["LEDGER_NAME_COMBINE"];
                    DRNew["EXPENSE_OPENING_AMOUNT"] = DTabFilterExpense.Rows[0]["OPENING_AMOUNT"];
                    DRNew["EXPENSE_AMOUNT"] = 0;
                    DRNew["EXPENSE_SRNO"] = 0;
                    DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = "";
                    DRNew["EXPENSE_ACCOUNT_TYPE_GROUP_NAME"] = "";
                    DRNew["DETAIL_MODE"] = "";
                    DTabIncome.Rows.Add(DRNew);

                    DTabIncome.Rows.Add("", "", "");


                }
            }

            //DataTable DTAb = new AccountTypeMaster().GetDataForSearch();
            DataTable DTAccountType = new DataTable();

            DTAccountType.Columns.Add("ACCOUNT_TYPE_CODE", typeof(int));
            DTAccountType.Columns.Add("ACCOUNT_TYPE_NAME", typeof(string));
            DTAccountType.Columns.Add("IN_PROFITLOSS", typeof(int));
            DTAccountType.Columns.Add("TRIAL_BALANCE_SIDE", typeof(string));
            DTAccountType.Columns.Add("PL_SRNO", typeof(int));

            
            //foreach (DataRow DRowType in DTAb.Rows)
            //{
            //    if (Val.ToInt(DRowType["IN_PROFITLOSS"]) == 1 && Val.ToInt(DRowType["UPPER_ACCOUNT_TYPE_CODE"]) == 0)
            //    {
            //        DataRow DTNewRow = DTAccountType.NewRow();
            //        DTNewRow["ACCOUNT_TYPE_CODE"] = DRowType["ACCOUNT_TYPE_CODE"];
            //        DTNewRow["ACCOUNT_TYPE_NAME"] = DRowType["ACCOUNT_TYPE_NAME"];
            //        DTNewRow["IN_PROFITLOSS"] = DRowType["IN_PROFITLOSS"];
            //        //DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"]; // COMMENTED ; NARENDRA ; 19-10-2015

            //        // ADD ; NARENDRA ; 19-OCT-2015 :: [ 10 : SALES A/C ], [ 11 : PURCHASE A/C ], [ 12 : DIRECT INCOME ], [ 13 : DIRECT EXPENSE ]
            //        if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 10 || Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 11
            //            || Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 12 || Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 13)
            //        {
            //            DTNewRow["TRIAL_BALANCE_SIDE"] = "DEBIT";

            //        }
            //        else if (Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 14 || Val.ToInt(DRowType["ACCOUNT_TYPE_CODE"]) == 15) // [ 14 : INDIRECT INCOME ], [ 15 : INDIRECT EXPENSE ]
            //        {
            //            DTNewRow["TRIAL_BALANCE_SIDE"] = "CREDIT";
            //        }
            //        else
            //            DTNewRow["TRIAL_BALANCE_SIDE"] = DRowType["TRIAL_BALANCE_SIDE"];
            //        DTNewRow["PL_SRNO"] = DRowType["PL_SRNO"];

            //        DTAccountType.Rows.Add(DTNewRow);
            //    }
            //}
            // Add : Narendra ; 19-Oct-2015 To Set SrNo. Of PL Report Primary Account Type.
            if (DTAccountType != null && DTAccountType.Rows.Count > 0)
            { 
                foreach(DataRow Drow in DTAccountType.Rows)
                {
                    switch (Val.ToInt(Drow["ACCOUNT_TYPE_CODE"]))
                    { 
                        case 10:
                            Drow["PL_SRNO"] = 10;
                            break;
                        case 11:
                            Drow["PL_SRNO"] = 12;
                            break;
                        case 12:
                            Drow["PL_SRNO"] = 11;
                            break;
                        case 13:
                            Drow["PL_SRNO"] = 13;
                            break;
                        case 14:
                            Drow["PL_SRNO"] = 14;
                            break;
                        case 15:
                            Drow["PL_SRNO"] = 15;
                            break;
                        default:
                            continue;
                    }                    
                }
            }
            // End : Narendra ; 19-Oct-2015 
            DTAccountType.AcceptChanges();

            DTAccountType.DefaultView.Sort = "PL_SRNO";

            DTAccountType = DTAccountType.DefaultView.ToTable();
            //   ---------------------- ///

            // ADD ; NARENDRA ; 05-OCT-2015
            string[] StrAccountTypeCode = Val.Trim("12,13,14,15").Split(','); // 12=Direct Income, 13=Direct Expense, 14=Indirect Income, 15=Indirect Expense :: Opening Balance Are Not Comes On Report, Which Ledger Belongs To this Group Or Its Sub Groups.
            string AccountTypeCode = string.Empty;
            for (int i = 0; i < StrAccountTypeCode.Length; i++)
            {
                if (StrAccountTypeCode[i].Trim().Equals(string.Empty))
                    continue;

                string StrAccountType = Val.ToString(StrAccountTypeCode[i]);
                DataTable DTTemp = Get_Tree_Account_Type_Master(StrAccountType);
                foreach (DataRow DrowAcc in DTTemp.Rows)
                {
                    AccountTypeCode = AccountTypeCode + DrowAcc["ACCOUNT_TYPE_CODE"] + ",";
                }

            }
            if (AccountTypeCode.Length > 1)
                AccountTypeCode = "," + AccountTypeCode;
            // END ; NARENDRA ; 05-OCT-2015

            // ADD ; NARENDRA ; 01-OCT-2015 ::  CALCULATE LEDGER CR/DR BALANCE...
            var QueryLedgerAmount = DTab.AsEnumerable()
           .GroupBy(w => new
           {
               LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
               DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
           })
           .Select(x => new
           {
               DETAIL_MODE = x.Key.DETAIL_MODE,
               LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
               AMOUNT = Val.Val((x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))))),

           })
           .Where(A => A.DETAIL_MODE == "LEDGER");

            DataTable DtTempAmount = new DataTable();
            if (QueryLedgerAmount.Count() > 0)
            {
                DtTempAmount = LINQToDataTable(QueryLedgerAmount);
            }

            // GET ALL LEDGER OPENING BALANCE 
            DataTable DTabOpeningAmount = new DataTable();
            DTabOpeningAmount = FindLedgerOpeningClosing_All(GlobalDec.LEDGEROPENING.OPENING, pIntCompanyCode, pIntBranchCode, pIntLocationCode, 0, Val.DBDate(pStrFromDate));
            // End : Narendra : 01-OCT-2015

            // ----------------------- FOR EXPENSE -------------------------//
            
            #region Expense

            DataRow[] DTRow = DTAccountType.Select("IN_PROFITLOSS= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");
            DataView DTView = new DataView(DTabFilterExpense);

            // Add : Narendra : 22-Oct-2015
            DataRow DrHeadExpense = DTabExpense.NewRow();
            DrHeadExpense["EXPENSE_ACCOUNT_NAME"] = "TRADING ACCOUNT :-";
            DTabExpense.Rows.Add(DrHeadExpense);
            bool IsHeaderPrint = true; // To Print Header Only Once.
            double DouTotalTradingAmount = 0.00, DouTotalCostOfSalesAmount = 0.00;
            // End : Narendra : 22-Oct-2015
            int IntExpenseRNO = 0;
            foreach (DataRow DR in DTRow)
            {
                // Add : Narendra : 22-Oct-2015
                if ((Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 11 || Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 13) && IsHeaderPrint)
                {
                    DataRow DRSubTot = DTabExpense.NewRow();
                    DRSubTot["EXPENSE_TOTAL_AMOUNT"] = DouTotalTradingAmount;
                    DTabExpense.Rows.Add(DRSubTot);

                    DataRow DrHead = DTabExpense.NewRow();
                    DrHead["EXPENSE_ACCOUNT_NAME"] = "COST OF SALES :-";
                    DTabExpense.Rows.Add(DrHead);
                    IsHeaderPrint = false;
                }
                // End : Narendra : 22-Oct-2015

                double DouOpenig = 0;
                DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];

                // Add : Narendra : 28-Sep-2015
                var QueryDTView = (from row in DTabFilterExpense.AsEnumerable()
                                   where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DR["ACCOUNT_TYPE_CODE"])
                                   orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                   select new
                                   {
                                       LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                       LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                       ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                       ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                       UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                       DETAIL_MODE = (string)row["DETAIL_MODE"],
                                       TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                       ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                   }
                                 )
                                .Distinct();

                //if (DTView.ToTable().Rows.Count > 0)
                if (QueryDTView.Count() > 0)
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntExpenseRNO++;

                        DataTable DTabDistinct = LINQToDataTable(QueryDTView); // Add : Narendra : 28-Sep-2015

                        /*DataTable DTabSub = DTView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();*/

                        DataRow DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = (IsHeaderPrint ? "" : "  ") + DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;
                        DRNew["EXPENSE_AMOUNT"] = 0;

                        //if (boolDetails)
                        DTabExpense.Rows.Add(DRNew);

                        double DouAccType_TotalAmt = 0.00;

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabExpense.NewRow();
                                DRNew = DTabExpense.NewRow();

                                DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["EXPENSE_ACCOUNT_NAME"] = (IsHeaderPrint ? "" : "  ") + "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["EXPENSE_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;


                                // Add ; Narendra : 01-Oct-2015
                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                if (rows != null && rows.Count() > 0)
                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);
                                
                                // Add : Narendra : 22-Oct-2015
                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 10 || Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 12)
                                {
                                    DouAmount *= -1;
                                }
                                // End : Narendra : 22-Oct-2015

                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                {
                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);
                                }
                                // End : Narendra : 01-Oct-2015

                                /*DouAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND   LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));
                                DouOpening = Val.Val(DTab.Compute("Sum(OPENING_AMOUNT)", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);
                                */
                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015

                                DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                                DRNew["EXPENSE_AMOUNT"] = DouAmount; // Commented : Narendra : 21/July/2015
                                //DRNew["EXPENSE_AMOUNT"] = DouAmount + DouOpening;
                                //DTabExpense.Rows.Add(DRNew);

                                // Commented : Narendra ; 31-Jul-2015
                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount + DouOpening;
                                // Add : Narendra ; 31-Jul-2015
                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount;


                                //if (boolDetails)
                                {
                                    if (DouAmount != 0 || DouOpening != 0)
                                    {
                                        DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF LEDGER
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                // Add : Narendra : 28-Sep-2015
                                var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                               orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                               select new
                                                               {
                                                                   ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                   UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                   ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                   ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                   TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                               }).Distinct();
                                DataTable DTabGroupDistinct = QueryUDRowGroupDistinct.Count() > 0 ? LINQToDataTable(QueryUDRowGroupDistinct) : null;
                                // Add : Narendra : 28-Sep-2015

                                /* Commented : Narendra : 01-Oct-2015
                                 * DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                DataTable DTabGroupDistinct = new DataTable();*/

                                //if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0)
                                if (DTabGroupDistinct != null && DTabGroupDistinct.Rows.Count > 0)
                                {
                                    /*
                                    DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO ASC";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();*/

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        // Add : Narendra : 28-Sep-2015
                                        var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) //|| row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                               select new
                                                               {
                                                                   LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                   LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                               })
                                                              .Distinct();
                                        DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                        // Add : Narendra : 28-Sep-2015

                                        //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        // DataRow[] UDRowGroup = DTab.Select("TYPE_LEVEL=2 AND   UPPER_ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");


                                        double DouAmount = 0, DouGrpTotal = 0.00;
                                        DouOpenig = 0;
                                        //if (UDRowGroup != null && UDRowGroup.Count() > 0)
                                        if (DTabGroupLedgerDistinct != null && DTabGroupLedgerDistinct.Rows.Count > 0) // Add : Narendra : 01-Oct-2015
                                        {


                                            //DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME"); // Commented  Narend;ra ; 
                                            foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                            {
                                                DouOpenig = 0;

                                                //DRNew = DTabExpense.NewRow();
                                                //DRNew["EXPENSE_ACCOUNT_CODE"] = DRow["LEDGER_CODE"];
                                                //DRNew["EXPENSE_ACCOUNT_NAME"] = "      ---   " + DRow["LEDGER_NAME"];
                                                //DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                                //DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                                //DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                                //DTabSub
                                                //DouAmount = Val.Val(DTab.Compute("(Sum(DEBIT_AMOUNT)-Sum(CREDIT_AMOUNT))", "DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + "")); //TYPE_LEVEL=2 AND                                                 

                                                // COMMENTED ; NARENDRA ; 05-OCT-2015
                                                //DouOpenig = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                                DouAmount = 0.00;
                                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE_COMBINE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rows != null && rows.Count() > 0)
                                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                                // Add : Narendra : 22-Oct-2015
                                                if (Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 10 || Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) == 12)
                                                {
                                                    DouAmount *= -1;
                                                }
                                                // End : Narendra : 22-Oct-2015

                                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                                {
                                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                                        DouOpenig = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]);
                                                }
                                                // Add : Narendra : 31-July-2015

                                                DouAmount += DouOpenig;

                                                // Add : Narendra : 31-July-2015

                                                //DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                                //DRNew["EXPENSE_AMOUNT"] = DouOpenig + DouAmount;

                                                //DouAccType_TotalAmt = DouAccType_TotalAmt + DouOpenig + DouAmount;
                                                DouAccType_TotalAmt = DouAccType_TotalAmt + DouAmount; // Add : Narendra : 31-July-2015

                                                //DouGrpTotal = DouGrpTotal + DouOpenig + DouAmount; // COMMENTED ; NARENDRA ; 21/JULY/2015
                                                DouGrpTotal = DouGrpTotal + DouAmount; // Commented ; Narendra ; 31-July-2015

                                                // DTabExpense.Rows.Add(DRNew);
                                            }
                                        }
                                        DRNew = DTabExpense.NewRow();
                                        DRNew["EXPENSE_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["EXPENSE_ACCOUNT_NAME"] = (IsHeaderPrint ? "" : "  ") + "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["EXPENSE_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                        DRNew["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["EXPENSE_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpenig;
                                        DRNew["EXPENSE_AMOUNT"] = DouGrpTotal;

                                        //if (boolDetails)
                                        DTabExpense.Rows.Add(DRNew);
                                    }
                                }
                            }
                        }// END OF DISTINCT LEDGER FOR EACH...

                        DRNew = DTabExpense.NewRow();
                        DRNew["EXPENSE_DETAIL_MODE"] = "";
                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = (IsHeaderPrint ? "" : "  ") + DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = 0;

                        //  DRNew["EXPENSE_AMOUNT"] = DouAccType_TotalAmt;
                        DRNew["EXPENSE_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouAccType_TotalAmt);

                        // Add : Narendra : 22-Oct-2015
                        if (IsHeaderPrint)
                            DouTotalTradingAmount += DouAccType_TotalAmt;
                        else
                            DouTotalCostOfSalesAmount += DouAccType_TotalAmt;
                        // End : Narendra : 22-Oct-2015

                        DTabExpense.Rows.Add(DRNew);
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntExpenseRNO++;
                        DTView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTView.ToTable();

                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE");
                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {

                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }

                            DataRow DRNew = DTabExpense.NewRow();
                            //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                            DRNew["EXPENSE_ACCOUNT_NAME"] = DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                            DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                            //DRNew["EXPENSE_DETAIL_MODE"] = ""; //Commeted : Narendra : 19-11-2014
                            DRNew["EXPENSE_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);

                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        IntExpenseRNO++;

                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_NAME"]) + ""));
                        double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DR["ACCOUNT_TYPE_CODE"]) + ""));

                        DataRow DRNew = DTabExpense.NewRow();
                        //DRNew["EXPENSE_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_CODE"] = DR["ACCOUNT_TYPE_CODE"];// DTView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : : Narendra : 19-11-2014
                        DRNew["EXPENSE_ACCOUNT_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        DRNew["EXPENSE_SRNO"] = IntExpenseRNO;
                        DRNew["EXPENSE_ACCOUNT_TYPE_NAME"] = DR["ACCOUNT_TYPE_NAME"];
                        //DRNew["EXPENSE_DETAIL_MODE"] = ""; // Commeted : Narendra : 19-11-2014
                        DRNew["EXPENSE_DETAIL_MODE"] = "GROUP";// DR["DETAIL_MODE"]; // Add : Narendra : 19-11-2014

                        DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["EXPENSE_AMOUNT"] = DouAmount;
                        DTabExpense.Rows.Add(DRNew);

                    }
                }
            }

            // Add : Narendra : 22-Oct-2015
            DataRow DRSubTotal = DTabExpense.NewRow();
            DRSubTotal["EXPENSE_ACCOUNT_NAME"] = "COST OF SALES TOTAL";
            DRSubTotal["EXPENSE_TOTAL_AMOUNT"] = DouTotalCostOfSalesAmount;
            DTabExpense.Rows.Add(DRSubTotal);

            double DouGrossProfitAmount = 0.00;
            DouGrossProfitAmount = (DouTotalTradingAmount - DouTotalCostOfSalesAmount);
            DataRow DRTotal = DTabExpense.NewRow();
            DRTotal["EXPENSE_ACCOUNT_NAME"] = "    GROSS PROFIT :-";
            DRTotal["EXPENSE_TOTAL_AMOUNT"] = DouGrossProfitAmount;
            DTabExpense.Rows.Add(DRTotal);

            
            DTabExpense.Rows.Add(DTabExpense.NewRow()); // EXTRA ROW...
            // End : Narendra : 22-Oct-2015
            #endregion

            #region Income

            // ---------------- FOR INCOME ---------------------------------

            // Add : Narendra : 01-Oct-2015
            var QueryLedgerAmountIncome = DTab.AsEnumerable()
           .GroupBy(w => new
           {
               LEDGER_CODE_COMBINE = w.Field<decimal>("LEDGER_CODE_COMBINE"),
               DETAIL_MODE = w.Field<string>("DETAIL_MODE"),
           })
           .Select(x => new
           {
               DETAIL_MODE = x.Key.DETAIL_MODE,
               LEDGER_CODE_COMBINE = x.Key.LEDGER_CODE_COMBINE,
               //AMOUNT = Val.ToString((x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("DEBIT_AMOUNT"))))) - x.Sum(w => ( Val.Val(Val.ToString(w.Field<string>("CREDIT_AMOUNT")))))) * -1),
               AMOUNT = Val.ToString((x.Sum(w => (w.Field<decimal>("CREDIT_AMOUNT_1"))) - x.Sum(w => (w.Field<decimal>("DEBIT_AMOUNT_1"))))),

           })
           .Where(A => A.DETAIL_MODE == "LEDGER");

            DtTempAmount = new DataTable();
            if (QueryLedgerAmountIncome.Count() > 0)
            {
                DtTempAmount = LINQToDataTable(QueryLedgerAmountIncome);
            }

            // End : Narendra : 29-Sep-2015
            DataRow[] DTIncomeRow = DTAccountType.Select("IN_PROFITLOSS = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DTabFilterIncome);

            // Add : Narendra : 22-Oct-2015
            DataRow DrHeadIncome = DTabIncome.NewRow();
            DrHeadIncome["INCOME_ACCOUNT_NAME"] = "INCOME STATEMENT :-";
            DTabIncome.Rows.Add(DrHeadIncome);

            bool IsPrintNettProfit = true;
            // End : Narendra : 22-Oct-2015

            int IntIncomeRNO = 0;
            foreach (DataRow DIRow in DTIncomeRow)
            {
                // Add : Narendra : 29-Sep-2015
                var QueryDTIncomeView = (from row in DTabFilterIncome.AsEnumerable()
                                         where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"])
                                         orderby (string)row["DETAIL_MODE"] ascending, (decimal)row["ACCOUNT_TYPE_SRNO"] ascending, (string)row["LEDGER_NAME_COMBINE"] ascending
                                         select new
                                         {
                                             LEDGER_CODE_COMBINE = (decimal)row["LEDGER_CODE_COMBINE"],
                                             LEDGER_NAME_COMBINE = (string)row["LEDGER_NAME_COMBINE"],
                                             ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                             ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                             UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                             DETAIL_MODE = (string)row["DETAIL_MODE"],
                                             TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                             ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                         }
                                   )
                                  .Distinct();

                // DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"]; // Commented ; Narendra : 01-Oct-2015
                //if (DTIncomeView.ToTable().Rows.Count > 0) // Commented ; Narendra ; 01-Sep-2015
                if (QueryDTIncomeView.Count() > 0) // ADD ; NARENDRA ; 01-Sep-2015
                {
                    if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_ACCOUNT")
                    {
                        IntIncomeRNO++;

                        DataTable DTabDistinct = LINQToDataTable(QueryDTIncomeView); // ADD ; NARENDRA ; 29-SEP-2015

                        /* Commented : Narendra : 01-Oct-2015
                         * DataTable DTabSub = DTIncomeView.ToTable();
                        //DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "DETAIL_MODE");
                        DataTable DTabDistinct = DTabSub.DefaultView.ToTable(true, "LEDGER_CODE_COMBINE", "LEDGER_NAME_COMBINE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "DETAIL_MODE", "TYPE_LEVEL", "ACCOUNT_TYPE_SRNO");
                        DTabDistinct.DefaultView.Sort = "DETAIL_MODE ASC,ACCOUNT_TYPE_SRNO ASC,LEDGER_NAME_COMBINE ASC";
                        DTabDistinct = DTabDistinct.DefaultView.ToTable();*/


                        DataRow DRNew = DTabIncome.NewRow();
                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " :-";
                        DRNew["INCOME_OPENING_AMOUNT"] = 0;
                        DRNew["INCOME_AMOUNT"] = 0;
                        //if (boolDetails)
                        DTabIncome.Rows.Add(DRNew);

                        double DouIncomeTot = 0.00;


                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            if (Val.ToString(DRDist["DETAIL_MODE"]) == "LEDGER")
                            {
                                //DataRow DRNew = DTabIncome.NewRow();
                                DRNew = DTabIncome.NewRow();

                                DRNew["INCOME_ACCOUNT_CODE"] = DRDist["LEDGER_CODE_COMBINE"];
                                DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["LEDGER_NAME_COMBINE"];
                                DRNew["INCOME_SRNO"] = IntIncomeRNO;
                                DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];
                                DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRDist["UPPER_ACCOUNT_TYPE_CODE"];
                                DRNew["INCOME_TYPE_LEVEL"] = DRDist["TYPE_LEVEL"];

                                Double DouAmount = 0, DouOpening = 0;

                                IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                if (rows != null && rows.Count() > 0)
                                    DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                // Add : Narendra : 22-Oct-2015
                                if (Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) == 15)
                                {
                                    DouAmount *= -1;
                                }
                                // End : Narendra : 22-Oct-2015
                                // Commented : Narendra : 01-Oct-2015
                                //DouAmount = Val.Val(DTab.Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " DETAIL_MODE='LEDGER' AND LEDGER_CODE_COMBINE = " + Val.Val(DRDist["LEDGER_CODE_COMBINE"]) + ""));

                                // Commented : Narendra 
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate) * -1;
                                if (!AccountTypeCode.Contains("," + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                {
                                    IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE"].ToString() == Val.ToString(DRDist["LEDGER_CODE_COMBINE"]));
                                    if (rowsOpening != null && rowsOpening.Count() > 0)
                                        DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;
                                }
                                // Add : Narendra ; 31-July-2015 :: Commented : Narendra : 19-Aug-2015
                                //DouOpening = FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]), pStrFromDate, pStrFromDate);

                                // Add : Narendra : 31-July-2015
                                DouAmount += DouOpening;
                                //DouAmount += DouOpening;
                                // Add : Narendra : 31-July-2015

                                // Add : Narendra : 22-Oct-2015
                                DouIncomeTot = DouIncomeTot + DouAmount;
                                // End : Narendra : 22-Oct-2015

                                DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                DRNew["INCOME_AMOUNT"] = DouAmount;
                                //DTabIncome.Rows.Add(DRNew);
                                //if (boolDetails)
                                {
                                    if ((DouOpening + DouAmount) != 0)
                                        DTabIncome.Rows.Add(DRNew);
                                }
                            }
                            else if (Val.ToString(DRDist["DETAIL_MODE"]) == "GROUP")
                            {
                                // Commented ; Narendra ; 01-Oct-2015
                                //DataRow[] UDRowGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "");
                                var QueryUDRowGroupDistinct = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("TYPE_LEVEL") == 2 && row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"])
                                                               orderby (decimal)row["ACCOUNT_TYPE_SRNO"] ascending
                                                               select new
                                                               {
                                                                   ACCOUNT_TYPE_CODE = (decimal)row["ACCOUNT_TYPE_CODE"],
                                                                   UPPER_ACCOUNT_TYPE_CODE = (decimal)row["UPPER_ACCOUNT_TYPE_CODE"],
                                                                   ACCOUNT_TYPE_NAME = (string)row["ACCOUNT_TYPE_NAME"],
                                                                   ACCOUNT_TYPE_SRNO = (decimal)row["ACCOUNT_TYPE_SRNO"],
                                                                   TYPE_LEVEL = (decimal)row["TYPE_LEVEL"],
                                                               }).Distinct();

                                DataTable DTabGroupDistinct = new DataTable();

                                /*DataTable DTabGroupDistinct = DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").Count() > 0 ?
                                                             DTab.Select("TYPE_LEVEL=2 AND UPPER_ACCOUNT_TYPE_CODE = " + Val.ToInt(DRDist["ACCOUNT_TYPE_CODE"]) + "").CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL")
                                                             : null;*/
                                // if (UDRowGroupDistinct != null && UDRowGroupDistinct.Count() > 0) // Commented : Narendra : 01-Oct-2015
                                if (QueryUDRowGroupDistinct.Count() > 0) // ADD ; NARENDRA ; 29-SEP-2015                                
                                {
                                    DTabGroupDistinct = LINQToDataTable(QueryUDRowGroupDistinct); // ADD ; NARENDRA ; 29-SEP-2015

                                    /*DTabGroupDistinct = UDRowGroupDistinct.CopyToDataTable().DefaultView.ToTable(true, "ACCOUNT_TYPE_CODE", "UPPER_ACCOUNT_TYPE_CODE", "ACCOUNT_TYPE_NAME", "ACCOUNT_TYPE_SRNO", "TYPE_LEVEL");
                                    DTabGroupDistinct.DefaultView.Sort = "ACCOUNT_TYPE_SRNO";
                                    DTabGroupDistinct = DTabGroupDistinct.DefaultView.ToTable();*/

                                    foreach (DataRow DRGroup in DTabGroupDistinct.Rows)
                                    {
                                        // Commented : Narendra ; 01-Oct-2015
                                        //DataRow[] UDRowGroup = DTab.Select("ACCOUNT_TYPE_CODE = '" + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + "'");
                                        //DataTable DTabGroupLedgerDistinct = UDRowGroup.CopyToDataTable().DefaultView.ToTable(true, "LEDGER_CODE", "LEDGER_NAME");

                                        // Add : Narendra : 28-Sep-2015
                                        var QueryUDRowGroup = (from row in DTab.AsEnumerable()
                                                               where row.Field<decimal>("ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) || row.Field<decimal>("UPPER_ACCOUNT_TYPE_CODE") == Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"])
                                                               select new
                                                               {
                                                                   LEDGER_CODE = (decimal)row["LEDGER_CODE"],
                                                                   LEDGER_NAME = (string)row["LEDGER_NAME"],
                                                               })
                                                              .Distinct();
                                        DataTable DTabGroupLedgerDistinct = QueryUDRowGroup.Count() > 0 ? LINQToDataTable(QueryUDRowGroup) : null;
                                        // Add : Narendra : 28-Sep-2015

                                        double DouAmount = 0, DouOpening = 0;

                                        double DouGrpTotal = 0.00;
                                        foreach (DataRow DRow in DTabGroupLedgerDistinct.Rows)
                                        {
                                            DouAmount = 0.00;
                                            IEnumerable<DataRow> rows = DtTempAmount.Rows.Cast<DataRow>().Where(r => r["LEDGER_CODE_COMBINE"].ToString() == Val.ToString(DRow["LEDGER_CODE"]));
                                            if (rows != null && rows.Count() > 0)
                                                DouAmount = Val.Val(rows.CopyToDataTable().Rows[0]["AMOUNT"]);

                                            // Add : Narendra : 22-Oct-2015
                                            if (Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) == 15)
                                            {
                                                DouAmount *= -1;
                                            }
                                            // End : Narendra : 22-Oct-2015

                                            DouOpening = 0;
                                            if (!AccountTypeCode.Contains("," + Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]) + ",")) // Add : Narendra : 05-OCT-2015
                                            {
                                                IEnumerable<DataRow> rowsOpening = DTabOpeningAmount.Rows.Cast<DataRow>().Where(r => (decimal)r["LEDGER_CODE"] == Val.ToInt(DRow["LEDGER_CODE"]));
                                                if (rowsOpening != null && rowsOpening.Count() > 0)
                                                    DouOpening = Val.Val(rowsOpening.CopyToDataTable().Rows[0]["OPENING_AMOUNT"]) * -1;
                                            }
                                            // Commented  : Narendra ; 01-Oct-2015
                                            //DouAmount = Val.Val(DTab.Compute("(Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)) ", " DETAIL_MODE='LEDGER' AND  LEDGER_CODE = " + Val.Val(DRow["LEDGER_CODE"]) + ""));

                                            //DouOpening = -1 * FindLedger_Opening_Balance(pIntCompanyCode, pIntBranchCode, pIntLocationCode, Val.ToInt(DRow["LEDGER_CODE"]), Val.DBDate(pStrFromDate), Val.DBDate(pStrFromDate));

                                            // Add : Narendra : 31-July-2015
                                            //DouAmount += DouOpening;                                            
                                            DouAmount += DouOpening;

                                            DouIncomeTot = DouIncomeTot + DouAmount;
                                            DouGrpTotal = DouGrpTotal + DouAmount;
                                            // Add : Narendra : 31-July-2015

                                            // Commented : Narendra : 31-July-2015
                                            //DouIncomeTot = DouIncomeTot + DouOpening + DouAmount;
                                            //DouGrpTotal = DouGrpTotal + DouOpening + DouAmount;

                                        }

                                        DRNew = DTabIncome.NewRow();
                                        DRNew["INCOME_ACCOUNT_CODE"] = Val.ToInt(DRGroup["ACCOUNT_TYPE_CODE"]);
                                        DRNew["INCOME_ACCOUNT_NAME"] = "          " + Val.ToString(DRGroup["ACCOUNT_TYPE_NAME"]);
                                        DRNew["INCOME_SRNO"] = IntExpenseRNO;
                                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DRDist["ACCOUNT_TYPE_NAME"];
                                        DRNew["INCOME_DETAIL_MODE"] = DRDist["DETAIL_MODE"];

                                        DRNew["INCOME_UPPER_ACCOUNT_TYPE_CODE"] = DRGroup["ACCOUNT_TYPE_CODE"];
                                        DRNew["INCOME_TYPE_LEVEL"] = Val.ToInt(DRGroup["TYPE_LEVEL"]) + 1;

                                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpening;
                                        DRNew["INCOME_AMOUNT"] = DouGrpTotal;
                                        //if (boolDetails)
                                        DTabIncome.Rows.Add(DRNew);
                                    }
                                }
                            }// END OF GROUP 

                            /* Commented : Narendra : 22-Oct-2015
                             * DRNew = DTabIncome.NewRow();
                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                            DTabIncome.Rows.Add(DRNew);

                            // Add : Narendra : 22-Oct-2015
                            DRNew = DTabIncome.NewRow();

                            DouGrossProfitAmount = DouGrossProfitAmount - DouIncomeTot;
                            if (true)
                                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossProfitAmount);
                            else
                            {
                                DRNew["INCOME_ACCOUNT_NAME"] = "Net Profit :-";
                                DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossProfitAmount);
                            }
                            DTabIncome.Rows.Add(DRNew);*/
                            // End : Narendra : 22-Oct-2015
                        }
                        // Add : Narendra : 22-Oct-2015
                        DRNew = DTabIncome.NewRow();
                        DRNew["INCOME_DETAIL_MODE"] = "";
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = DTabDistinct.Rows[0]["ACCOUNT_TYPE_NAME"] + " TOTAL ";
                        DRNew["INCOME_OPENING_AMOUNT"] = 0;
                        // DRNew["INCOME_AMOUNT"] = DouIncomeTot;
                        DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouIncomeTot);

                        DTabIncome.Rows.Add(DRNew);

                        // Add : Narendra : 22-Oct-2015
                        DRNew = DTabIncome.NewRow();


                        if (Val.ToInt(DTabDistinct.Rows[0]["ACCOUNT_TYPE_CODE"]) == 14) // 14 = INDIRECT INCOME
                        {
                            DouGrossProfitAmount = DouGrossProfitAmount + DouIncomeTot;
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossProfitAmount);
                        }
                        if (Val.ToInt(DTabDistinct.Rows[0]["ACCOUNT_TYPE_CODE"]) == 15 && IsPrintNettProfit) // 14 = INDIRECT EXPENSE
                        {
                            DouGrossProfitAmount = DouGrossProfitAmount - DouIncomeTot;
                            DRNew["INCOME_ACCOUNT_NAME"] = "NET PROFIT :-";
                            DRNew["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossProfitAmount);
                            IsPrintNettProfit = false;
                        }
                        DTabIncome.Rows.Add(DRNew);
                        // End : Narendra : 22-Oct-2015
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
                    {
                        IntIncomeRNO++;
                        DTIncomeView.Sort = "ACCOUNT_TYPE_GROUP_SRNO";

                        DataTable DtabSubGroup = DTIncomeView.ToTable();

                        //DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME"); // Commeted : Narendra : 19-11-2014
                        DataTable DTabDistinct = DtabSubGroup.DefaultView.ToTable(true, "ACCOUNT_TYPE_GROUP_CODE", "ACCOUNT_TYPE_GROUP_NAME", "ACCOUNT_TYPE_CODE", "DETAIL_MODE"); // Add : Narendra : 19-11-2014

                        foreach (DataRow DRDist in DTabDistinct.Rows)
                        {
                            double DouAmount = 0;
                            double DouOpeningAmount = 0;

                            foreach (DataRow DR1 in DtabSubGroup.Rows)
                            {
                                if (Val.Val(DR1["ACCOUNT_TYPE_GROUP_CODE"]) == Val.Val(DRDist["ACCOUNT_TYPE_GROUP_CODE"]))
                                {
                                    DouAmount = DouAmount + (Val.Val(DR1["CREDIT_AMOUNT"]) - Val.Val(DR1["DEBIT_AMOUNT"]));
                                    DouOpeningAmount = DouOpeningAmount + Val.Val(DR1["OPENING_AMOUNT"]);
                                }
                            }


                            DataRow DRNew = DTabIncome.NewRow();
                            //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_CODE"] = DRDist["ACCOUNT_TYPE_GROUP_CODE"]; // Add :Narendra : 19-11-2014
                            DRNew["INCOME_ACCOUNT_NAME"] = "       " + DRDist["ACCOUNT_TYPE_GROUP_NAME"];
                            DRNew["INCOME_SRNO"] = IntIncomeRNO;
                            DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                            //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                            DRNew["INCOME_DETAIL_MODE"] = "GROUP"; // Add : Narendra : 19-11-2014 

                            DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                            DRNew["INCOME_AMOUNT"] = DouAmount;
                            DTabIncome.Rows.Add(DRNew);
                        }
                    }
                    else if (pStrReportTYpe == "ACCOUNT_TYPE")
                    {
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""));
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", ""));

                        /* // Add : Narendra : 19-11-2014*/
                        //double DouOpeningAmount = Val.Val(DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + "")); 
                        //double DouAmount = Val.Val(DTView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_NAME"]) + ""));

                        // Add : Narendra : 19-11-2014
                        double DouOpeningAmount = Val.Val(DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        double DouAmount = Val.Val(DTIncomeView.ToTable().Compute("Sum(CREDIT_AMOUNT)-Sum(DEBIT_AMOUNT)", " ACCOUNT_TYPE_CODE = " + Val.ToInt(DIRow["ACCOUNT_TYPE_CODE"]) + ""));
                        // End : Narendra : 19-11-2014

                        IntIncomeRNO++;

                        DataRow DRNew = DTabIncome.NewRow();
                        //DRNew["INCOME_ACCOUNT_CODE"] = 0; // Commeted: Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_CODE"] = DTIncomeView.ToTable().Rows[0]["ACCOUNT_TYPE_GROUP_CODE"]; // Add : Narendra : 19-11-2014
                        DRNew["INCOME_ACCOUNT_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        DRNew["INCOME_SRNO"] = IntIncomeRNO;
                        DRNew["INCOME_ACCOUNT_TYPE_NAME"] = DIRow["ACCOUNT_TYPE_NAME"];
                        //DRNew["INCOME_DETAIL_MODE"] = "";// Commeted : Narendra : 19-11-2014
                        DRNew["INCOME_DETAIL_MODE"] = "GROUP";// Add : Narendra : 19-11-2014

                        DRNew["INCOME_OPENING_AMOUNT"] = DouOpeningAmount;
                        DRNew["INCOME_AMOUNT"] = DouAmount;
                        DTabIncome.Rows.Add(DRNew);

                    }
                }
            }
            // Add : Narendra : 22-Oct-2015
            if (IsPrintNettProfit) // 14 = INDIRECT EXPENSE
            {
                DataRow DrNettProfit = DTabIncome.NewRow();
                DrNettProfit["INCOME_ACCOUNT_NAME"] = "NET PROFIT :-";
                DrNettProfit["INCOME_TOTAL_AMOUNT"] = Val.FormatWithSeperator(DouGrossProfitAmount);
                DTabIncome.Rows.Add(DrNettProfit);
            }
            // End : Narendra : 22-Oct-2015
            #endregion

            // Add : Narendra : 22-Oct-2015
            if (DTabExpense != null && DTabExpense.Rows.Count > 0)
            {
                foreach (DataRow Drow in DTabExpense.Rows)
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = Drow["EXPENSE_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = Drow["EXPENSE_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = Drow["EXPENSE_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = (Val.Val(Drow["EXPENSE_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["EXPENSE_OPENING_AMOUNT"]);
                    DRNew["AMOUNT"] = (Val.Val(Drow["EXPENSE_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["EXPENSE_AMOUNT"]);
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = Drow["EXPENSE_UPPER_ACCOUNT_TYPE_CODE"];
                    DRNew["TYPE_LEVEL"] = Drow["EXPENSE_TYPE_LEVEL"];                    
                    DRNew["TOTAL_AMOUNT"] = (Val.Val(Drow["EXPENSE_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["EXPENSE_TOTAL_AMOUNT"]);
                    DTabCombine.Rows.Add(DRNew);
                }
            }

            if (DTabIncome != null && DTabIncome.Rows.Count > 0)
            {
                foreach (DataRow Drow in DTabIncome.Rows)
                {
                    DataRow DRNew = DTabCombine.NewRow();
                    DRNew["DETAIL_MODE"] = Drow["INCOME_DETAIL_MODE"];
                    DRNew["ACCOUNT_CODE"] = Drow["INCOME_ACCOUNT_CODE"];
                    DRNew["ACCOUNT_NAME"] = Drow["INCOME_ACCOUNT_NAME"];
                    DRNew["OPENING_AMOUNT"] = (Val.Val(Drow["INCOME_OPENING_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["INCOME_OPENING_AMOUNT"]);
                    DRNew["AMOUNT"] = (Val.Val(Drow["INCOME_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["INCOME_AMOUNT"]);
                    DRNew["UPPER_ACCOUNT_TYPE_CODE"] = Drow["INCOME_UPPER_ACCOUNT_TYPE_CODE"];
                    DRNew["TYPE_LEVEL"] = Drow["INCOME_TYPE_LEVEL"];
                    DRNew["TOTAL_AMOUNT"] = (Val.Val(Drow["INCOME_TOTAL_AMOUNT"]) < 0 ? "(-) " : string.Empty) + Val.FormatWithSeperator(Drow["INCOME_TOTAL_AMOUNT"]);
                    DTabCombine.Rows.Add(DRNew);
                }
            }
            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
            //DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);

            // Add : Narendra : 19-11-2014
            if (pStrReportTYpe != "ACCOUNT_TYPE")
            {
                if (DTabCombine.Rows.Count > 5)
                {
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                    DTabCombine.Rows.RemoveAt(DTabCombine.Rows.Count - 5);
                }
            }

            return DTabCombine;
        }

        public DataTable Get_Profit_and_Loss_Vertical(ReportParams_Property pClsProperty, string StrTableName) // ADD ; NARENDRA ; 19-OCT-2015
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            // Commented : Narendra : 26-Oct-2015
            //Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            
            string StrQuery = string.Empty;
            if (StrTableName.Equals("LEDGER_TRANSACTION"))
            {
                StrQuery = "SELECT * FROM LEDGER_TRANSACTION WHERE COMPANY_CODE = " + pClsProperty.Company_Code
                            + " AND BRANCH_CODE = " + pClsProperty.Branch_Code
                            + " AND LOCATION_CODE = " + pClsProperty.Location_Code
                            + " AND TRANSACTION_ENTRY_DATE >= '" + pClsProperty.From_Date + "'"
                            + " AND TRANSACTION_ENTRY_DATE <= '" + pClsProperty.To_Date + "'";
            }
            else
                StrQuery = "SELECT * FROM " + StrTableName;

            Request.CommandText = StrQuery;
            Request.CommandType = CommandType.Text;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }

        private DataTable GetProfitLossAmount(int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string pStrToDate) // Add : Narendra : 26-Oct-2015
        {
            string StrProfitLoss = " SELECT" +
              " NVL(SUM(TOTALRUNNING),0) AS AMOUNT" +
              " FROM" +
              " (" +
                  " SELECT" +
                  " distinct" +
                  " TRAN.LEDGER_CODE," +
                  " SUM(TRAN.CREDIT_AMOUNT) - SUM(TRAN.DEBIT_AMOUNT) AS TOTALRUNNING," +
                    
                  " LEDGER.LEDGER_NAME," +
                  " LEDGER.ACCOUNT_TYPE_CODE," +
                  " ACCTYPE.ACCOUNT_TYPE_NAME," +
                  " LEDGER.ACCOUNT_TYPE_GROUP_CODE," +
                  " HEAD.TRIAL_BALANCE_SIDE," +
                  " LED_LEVEL.TYPE_LEVEL" +
                    
                  " FROM LEDGER_TRANSACTION TRAN" +
                    
                  " LEFT JOIN LEDGER_MASTER LEDGER ON LEDGER.LEDGER_CODE  = TRAN.LEDGER_CODE" +
                  " LEFT JOIN ACCOUNT_TYPE_MASTER ACCTYPE ON ACCTYPE.ACCOUNT_TYPE_CODE = LEDGER.ACCOUNT_TYPE_CODE" +
                  " LEFT JOIN ACCOUNT_HEAD_MASTER HEAD ON HEAD.ACCOUNT_HEAD_CODE = ACCTYPE.ACCOUNT_HEAD_CODE" +
                  " LEFT JOIN LEDGER_LEVEL_MASTER LED_LEVEL ON LED_LEVEL.LEDGER_CODE = LEDGER.LEDGER_CODE" +
                                                           " AND LED_LEVEL.ACCOUNT_TYPE_CODE = ACCTYPE.ACCOUNT_TYPE_CODE" +
                    
                    
                  " WHERE 1 = 1" +
                  " AND ( HEAD.In_Balancesheet  = 1)" +
                  " AND TRAN.COMPANY_CODE = " + pIntCompanyCode +
                  " AND ( TRAN.BRANCH_CODE=" + pIntBranchCode + " )" +
                  " AND ( TRAN.LOCATION_CODE=" + pIntLocationCode + " )" +
                  " AND TRAN.TRANSACTION_ENTRY_DATE >= '" + Val.DBDate(GlobalDec.gFinancialYear_StartDate) + "'" +
                  " AND TRAN.TRANSACTION_ENTRY_DATE <= '" + Val.DBDate(pStrToDate) + "'" +
                    
                  " GROUP BY" +
                  " TRAN.LEDGER_CODE," +
                  " LEDGER.LEDGER_NAME," +
                  " LEDGER.ACCOUNT_TYPE_CODE," +
                  " ACCTYPE.ACCOUNT_TYPE_NAME," +
                  " LEDGER.ACCOUNT_TYPE_GROUP_CODE," +
                  " HEAD.TRIAL_BALANCE_SIDE," +
                  " LED_LEVEL.TYPE_LEVEL" +
                    
                  " ORDER BY" +
                  " ACCTYPE.BS_SRNO" +
              " )A" +
              " WHERE" +
              " A.TOTALRUNNING != 0";
            Request Request = new DLL.Request();
            DataTable DtAmount = new DataTable();
            Request.CommandText = StrProfitLoss;
            Request.CommandType = CommandType.Text;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtAmount, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DtAmount, Request, "");

            return DtAmount;
        }

        // Add : Narendra : 02-Apr-2016
        public DataTable ConfirmationLedgerReport(ReportParams_Property pClsProperty, string pStrSPName)  // Khushbu 05/05/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Book_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //else
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

            return DTab;
        }
        // End : Narendra : 02-Apr-2016
        #endregion
    }
}
