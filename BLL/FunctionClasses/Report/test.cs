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

namespace BLL.FunctionClasses.Report
{
    public class TEST
    {

        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        double DblLedgerOpBal = 0.00;
        double DblOpeningBalance = 0.00;

        string StrAccType = "";
        string StrDrCrType = "";

        //LedgerMaster ObjLedger = new LedgerMaster();
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
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

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
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Trail_Balance_Report(ReportParams_Property pClsProperty, string pStrSPName)
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
            Request.CommandText = pStrSPName + "1";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Balance_Sheet(ReportParams_Property pClsProperty, string pStrSPName) //Khushbu 11/04/2014 // Changes DataSet To DataTable By Khushbu 11/09/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            // Request.REF_CUR_OUT = 2;
            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("START_DATE_", pClsProperty.Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            // Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Temp, Request, "");
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
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
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");

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
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

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
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");

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

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

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

                            //foreach (DataRow DVRow in DTabDistinct.Rows)
                            //{
                            //    if (Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) == Val.ToInt(DVRow["LEDGER_CODE_COMBINE"]))
                            //    {
                            //        DouAmount += (Val.Val(DVRow["CREDIT_AMOUNT"]) - Val.Val(DVRow["DEBIT_AMOUNT"]));
                            //        DouOpening += Val.Val(DVRow["OPENING_AMOUNT"]);
                            //    }                               
                            //}
                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);
                        }
                    }
                    /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
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
                    }*/
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
                    /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
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
                    }*/
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

                        /*if (IntI < 3 && DouGrossDiff < 0)
                        {
                            DouLastExpenseGrossProfit = DouGrossDiff;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff*-1, "###############0.00");

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff > 0)
                        {
                            DouLastIncomeGrossProfit = DouGrossDiff;
                            
                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);
                        }
                        */

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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

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
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                            DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
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

                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Format(DouExpenseOpening, "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Format(DouExpenseAmount, "#################0.00");
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Format(DouIncomeOpening, "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Format(DouIncomeAmount, "#################0.00");

                        DTabCombine.Rows.Add(DRNew);

                        DouGrossDiff += DouIncomeAmount - DouExpenseAmount;

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;

                        if (IntI < 2 && DouGrossDiff > 0)
                        {
                            DouLastExpenseGrossProfit = DouGrossDiff + DouLastIncomeAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

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
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 2 && DouGrossDiff < 0)
                        {
                            DouLastIncomeGrossProfit = DouGrossDiff + DouLastExpenseAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }
                    }
                }
            }

            //DTabCombine.Rows.Add("EXPENSE ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_OPENING_AMOUNT)", ""))), "###############0.00"),
            //                                                Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"),
            //                     "INCOME ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_OPENING_AMOUNT)", ""))), "###############0.00"),
            //                                                Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00")
            //                                                );



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
                DRNew["EXPENSE_AMOUNT"] = Val.Format((DblSumIncome - DblSumExpense), "###############0.00");

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
                DRNew["EXPENSE_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");
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
                DRNew["INCOME_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format((DblSumExpense - DblSumIncome), "###############0.00");
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
                DRNew["EXPENSE_AMOUNT"] = Val.Format((DouLastExpenseAmount + DouLastExpenseGrossProfit), "###############0.00");

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format((DouLastIncomeAmount + DouLastIncomeGrossProfit), "###############0.00");
                DTabCombine.Rows.Add(DRNew);
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
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

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
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");

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

            Request.CommandText = pStrName;
            Request.REF_CUR_OUT = 2;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Temp, Request, "");

            //return DS;

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

            Request.CommandText = pStrName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

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
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

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
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

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

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");

            return DS; ;
        }

        #endregion

        #region  Account Report Function

        public DataTable GenerateLedgerReport(DataTable DTab, ReportParams_Property pClsProperty) // Khushbu 07/07/2014
        {
            //DataTable DTabLedger = new LedgerMaster().GetDataForSearch();
            DataTable DTabLedger = new DataTable();
            DataRow[] DRowLedger = DTabLedger.Select("LEDGER_CODE =" + Val.ToInt(pClsProperty.Ledger_Code));

            foreach (DataRow DR in DRowLedger)
            {
                if (DR["LEDGER_NAME"].ToString() == "CAPITAL A/C")
                {
                }
                else
                {
                }
                //StrAccType = DR["ACCOUNT_TYPE_NAME"].ToString(); MODIFY : NARENDRA : 24-05-20144
                StrAccType = DR["LEDGER_NAME"].ToString();

                StrDrCrType = DR["DR_CR_TYPE"].ToString();
            }

            DataTable DTabFinal = DTab.Clone();

            //if (pClsProperty.IsOpening == true)
            //{
            //    DTabFinal = GetLedgerCurrBal(DTabFinal, pClsProperty);
            //}

            double DouDebitAmount = Val.Val(DTab.Compute("Sum(DEBIT_AMOUNT)", ""));
            double DouCreditAmount = Val.Val(DTab.Compute("Sum(CREDIT_AMOUNT)", ""));

            DTabFinal.Merge(DTab);

            DTabFinal.Rows.Add(DTabFinal.NewRow());

            double DblTotDr = 0.00, DblTotCr = 0.00;

            for (int IntI = 0; IntI < DTabFinal.Rows.Count - 1; IntI++)
            {
                if (Val.ToInt(DTabFinal.Rows[IntI]["DEBIT_AMOUNT"]) != 0)
                {
                    DblTotDr = DblTotDr + Val.ToDouble(DTabFinal.Rows[IntI]["DEBIT_AMOUNT"]);
                }

                if (Val.ToInt(DTabFinal.Rows[IntI]["CREDIT_AMOUNT"]) != 0)
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
            if (Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) != 0.0)
            {
                //DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["DEBIT_AMOUNT"]);
                DouClosing = Val.Val(DTabFinal.Rows[0]["DEBIT_AMOUNT"]) + DouDebitAmount - DouCreditAmount;
            }
            else if (Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) != 0.0)
            {
                //DblLedgerOpBal = DblLedgerOpBal - Val.ToDouble(DTabFinal.Rows[0]["CREDIT_AMOUNT"]);
                DouClosing = Val.Val(DTabFinal.Rows[0]["CREDIT_AMOUNT"]) - DouDebitAmount + DouCreditAmount;
            }


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

        //public DataTable GetLedgerCurrBal(DataTable DTabFinal, ReportParams_Property pClsProeprty) // Khushbu 07/07/2014
        //{
        //    LedgerOpeningBalance_MasterProperty Property = new LedgerOpeningBalance_MasterProperty();
        //    Property.Ledger_Code = Val.ToInt(pClsProeprty.Ledger_Code);
        //    Property.Company_Code = Val.ToInt(pClsProeprty.Company_Code);
        //    Property.Location_Code = Val.ToInt(pClsProeprty.Location_Code);
        //    Property.Branch_Code = Val.ToInt(pClsProeprty.Branch_Code);


        //    Property.Start_Date = pClsProeprty.Start_Date;
        //    Property.From_Date = Val.ToString(pClsProeprty.From_Date);

        //    if (Val.ToInt(pClsProeprty.IntStatus) == 0)
        //    {
        //        Property.Is_Cr_Dr = 0;
        //    }
        //    else if (Val.ToInt(pClsProeprty.IntStatus) == 1)
        //    {
        //        Property.Is_Cr_Dr = 1;
        //    }
        //    else if (Val.ToInt(pClsProeprty.IntStatus) == 2)
        //    {
        //        Property.Is_Cr_Dr = 2;
        //    }

        //    DataRow DRow = ObjLedger.GetLedgerOpeningBalDetail(Property);

        //    if (DRow == null)
        //    {
        //        DblLedgerOpBal = 0.00;
        //        DblOpeningBalance = 0.00;
        //    }
        //    else
        //    {
        //        DblLedgerOpBal = Val.ToDouble(DRow["DEBIT_LOCAL"]) - Val.ToDouble(DRow["CREDIT_LOCAL"]);

        //    }

        //    double DblCurrBal = 0.00;
        //    double DblTotalDebit = 0.00, DblTotalCredit = 0.00;

        //    DataTable DTabTotal = ObjLedger.GetLedgerTotalBalance(Property);

        //    if (DTabTotal.Rows.Count > 0)
        //    {
        //        DataRow DR = DTabTotal.Rows[0];
        //        DblTotalDebit = Val.ToDouble(DR["TOTALDEBIT"]);
        //        DblTotalCredit = Val.ToDouble(DR["TOTALCREDIT"]);
        //    }
        //    else
        //    {
        //        DblTotalDebit = 0.00;
        //        DblTotalCredit = 0.00;
        //    }

        //    DblCurrBal = DblLedgerOpBal + DblTotalDebit - DblTotalCredit;
        //    DblOpeningBalance = DblLedgerOpBal + DblTotalDebit - DblTotalCredit;

        //    DataRow Dr = DTabFinal.NewRow();

        //    if (Val.ToInt(DblCurrBal) > 0)
        //    {
        //        Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
        //        Dr["DEBIT_AMOUNT"] = Math.Abs(DblCurrBal);
        //        Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Dr";
        //        DblLedgerOpBal = Math.Abs(DblCurrBal);
        //        DblCurrBal = Math.Abs(DblCurrBal);
        //    }
        //    else if (Val.ToInt(DblCurrBal) == 0)
        //    {
        //        Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
        //        if (StrDrCrType == "CR")
        //        {
        //            Dr["CREDIT_AMOUNT"] = Math.Abs(DblCurrBal);
        //            Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Cr";
        //            DblLedgerOpBal = Math.Abs(DblCurrBal) * -1;
        //            DblCurrBal = Math.Abs(DblCurrBal) * -1;
        //        }
        //        else
        //        {
        //            Dr["DEBIT_AMOUNT"] = Math.Abs(DblCurrBal);
        //            Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Dr";
        //            DblLedgerOpBal = Math.Abs(DblCurrBal);
        //            DblCurrBal = Math.Abs(DblCurrBal);
        //        }
        //    }
        //    else
        //    {
        //        Dr["REF_LEDGER_NAME"] = "OPENING BALANCE";
        //        Dr["CREDIT_AMOUNT"] = Math.Abs(DblCurrBal);
        //        Dr["RUNNING_LEDGER"] = Math.Abs(DblCurrBal).ToString() + "Cr";
        //        DblLedgerOpBal = Math.Abs(DblCurrBal) * -1;
        //        DblCurrBal = Math.Abs(DblCurrBal) * -1;
        //    }
        //    DTabFinal.Rows.Add(Dr);

        //    return DTabFinal;
        //}

        //public double Get_LedgerWise_OpeningBalance_Cash_Bank_Book(ReportParams_Property pClsProeprty) // Khushbu 16/07/2014
        //{
        //    LedgerOpeningBalance_MasterProperty Property = new LedgerOpeningBalance_MasterProperty();
        //    Property.Ledger_Code = Val.ToInt(pClsProeprty.Ledger_Code);
        //    Property.Company_Code = Val.ToInt(pClsProeprty.Company_Code);
        //    Property.Location_Code = Val.ToInt(pClsProeprty.Location_Code);
        //    Property.Branch_Code = Val.ToInt(pClsProeprty.Branch_Code);


        //    Property.Start_Date = pClsProeprty.Start_Date;
        //    Property.From_Date = Val.ToString(pClsProeprty.From_Date);

        //    if (Val.ToInt(pClsProeprty.IntStatus) == 0)
        //    {
        //        Property.Is_Cr_Dr = 0;
        //    }
        //    else if (Val.ToInt(pClsProeprty.IntStatus) == 1)
        //    {
        //        Property.Is_Cr_Dr = 1;
        //    }
        //    else if (Val.ToInt(pClsProeprty.IntStatus) == 2)
        //    {
        //        Property.Is_Cr_Dr = 2;
        //    }

        //    DataRow DRow = ObjLedger.GetLedgerOpeningBalDetail(Property);

        //    if (DRow == null)
        //    {
        //        DblLedgerOpBal = 0.00;
        //    }
        //    else
        //    {
        //        DblLedgerOpBal = Val.ToDouble(DRow["DEBIT_LOCAL"]) - Val.ToDouble(DRow["CREDIT_LOCAL"]);
        //    }

        //    double DblCurrBal = 0.00;
        //    double DblTotalDebit = 0.00, DblTotalCredit = 0.00;

        //    DataTable DTabTotal = ObjLedger.GetLedgerTotalBalance(Property);

        //    if (DTabTotal.Rows.Count > 0)
        //    {
        //        DataRow DR = DTabTotal.Rows[0];
        //        DblTotalDebit = Val.ToDouble(DR["TOTALDEBIT"]);
        //        DblTotalCredit = Val.ToDouble(DR["TOTALCREDIT"]);
        //    }
        //    else
        //    {
        //        DblTotalDebit = 0.00;
        //        DblTotalCredit = 0.00;
        //    }

        //    DblCurrBal = DblLedgerOpBal + DblTotalDebit - DblTotalCredit;

        //    return DblCurrBal;

        //}
        /*   public DataTable GenerateBalanceSheet(DataSet DS, ReportParams_Property pClsProeprty) // Khushbu 08/07/2014
           {
               DataTable DTabExpense = new DataTable();
               DataTable DTabIncome = new DataTable();

               double DblTempCapitalAmt = 0.00;
               double DblTempPlAmt = 0.00;


               DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
               DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
               DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));

               DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
               DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
               DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

               // ADD : 26-05-2014 :   NARENDRA 

               DTabExpense.Columns.Add(new DataColumn("CODE_", typeof(string)));
               DTabExpense.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
               DTabExpense.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
               DTabExpense.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

               DTabIncome.Columns.Add(new DataColumn("CODE_", typeof(string)));
               DTabIncome.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
               DTabIncome.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
               DTabIncome.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

               if (DS.Tables[0].Rows.Count > 0)
               {
                   if (DS.Tables[0].Rows[0]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("NET "))
                   {
                       DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
                   }
               }

               DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
               DTAccountType.DefaultView.Sort = "BS_SRNO";
               DTAccountType = DTAccountType.DefaultView.ToTable();
               //ADD : NARENDRA : 23-05-2014
               DataTable DTAccountTypeGroup = new AccTypeGroupMaster().GetDataForSearch();
               DTAccountTypeGroup.DefaultView.Sort = "BS_SRNO";
               DTAccountTypeGroup = DTAccountTypeGroup.DefaultView.ToTable();
               //-------------------------
               DataView DTView = new DataView(DS.Tables[0]);

               DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

               DataRow[] DTRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

               // ----------------------- FOR EXPENSE -------------------------//
               foreach (DataRow DR in DTRow)
               {
                   DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                   if (DTView.ToTable().Rows.Count > 0)
                   {
                       if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary.
                       {
                           DTabExpense.NewRow();
                           DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
                           DTabExpense.Rows.Add(Regex.Replace(DR["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

                       }
                       foreach (DataRow DRG in DTRowGroup)
                       {
                           DataView DTViewGroup = new DataView(DTView.ToTable());
                           DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
                           if (DTViewGroup.ToTable().Rows.Count > 0)
                           {
                               if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
                               {
                                   //--------
                                   if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
                                   {
                                       DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
                                       DTabExpense.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
                                       foreach (DataRow DVRow in DTViewGroup.ToTable().Rows)
                                       {
                                           if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper().Contains("CAPITAL") || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper().Contains("RESERVE")
                                                   || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper().Contains("PROFIT "))
                                           {
                                               ObjComp.GetCompanyCapitalMaster(Val.ToInt(pClsProeprty.Company_Code));

                                               DataTable DTabCapital = ObjComp.DS.Tables["Company_Capital_Master"];

                                               DataRow[] DTFilterRow = DTabCapital.Select("COMPANY_CODE = " + Val.ToInt(pClsProeprty.Company_Code) + " AND LEDGER_CODE = " + DVRow["EXPENSE_ACCOUNT_CODE"]);

                                               if (DTFilterRow.Length > 0)
                                               {
                                                   DTabExpense.Rows.Add("          " + DVRow["EXPENSE_ACCOUNT_NAME"] + "(" + DTFilterRow[0]["shere_per"].ToString() + "% )", DVRow["OPENING_AMOUNT"], Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100, DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);

                                                   if (DS.Tables[0].Rows.Count > 0)
                                                   {
                                                       if (DS.Tables[0].Rows[0]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("NET "))
                                                       {
                                                           DblTempCapitalAmt = DblTempCapitalAmt + Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100;
                                                       }
                                                   }

                                               }
                                               else
                                               {
                                                   DTabExpense.Rows.Add("          " + DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt, DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);
                                               }
                                           }
                                           else
                                           {
                                               DTabExpense.Rows.Add("          " + DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);
                                           }
                                       }
                                       DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
                                   }//---end of rbt
                                   if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
                                   {
                                       DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, DR["ACCOUNT_TYPE_CODE"], "LEDGER_TRANSACTION", DRG["ACCOUNT_TYPE_GROUP_CODE"], ""); // "" => DVRow["EXPENSE_ACCOUNT_CODE"]
                                   }
                                   else
                                   {
                                       DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL ", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

                                   }

                               }// End Of Summary Data.
                           }
                       }// END OF MAIN TOTAL
                       //if (Val.ToInt(RbtReportType.SelectedValue) == 0)
                       //  DTabExpense.Rows.Add("", "-------------------", "---------------------");
                       if (DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper().Contains("CAPITAL") || DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper().Contains("RESERVE"))
                       {
                           DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
                       }
                       else
                       {
                           if (Val.ToInt(pClsProeprty.IntReportType) > 0)
                           {
                               DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");

                           }
                           DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

                       }

                   }
                   //-----------------------------

               }
               if (DS.Tables[0].Rows.Count > 0)
               {
                   if (Val.ToInt(pClsProeprty.IntReportType) == 0)
                       DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
                   DTabExpense.Rows.Add("LIABILITIES ACCOUNT TOTAL", DS.Tables[0].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "", "");
               }

               //-----------------------------------------//

               // ---------------- FOR INCOME ---------------------------------

               DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
               DataRow[] DTIncomeRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
               DataView DTIncomeView = new DataView(DS.Tables[1]);
               foreach (DataRow DIRow in DTIncomeRow)
               {
                   DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
                   if (DTIncomeView.ToTable().Rows.Count > 0)
                   {

                       if (Val.ToInt(pClsProeprty.IntReportType) > 0)
                       {
                           DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
                           DTabIncome.Rows.Add(Regex.Replace(DIRow["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
                       }
                       foreach (DataRow DRG in DTIncomeRowGroup)
                       {
                           DataView DTViewGroup = new DataView(DTIncomeView.ToTable());
                           DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DIRow["ACCOUNT_TYPE_CODE"];
                           if (DTViewGroup.ToTable().Rows.Count > 0)
                           {
                               if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
                               {
                                   //--------
                                   if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
                                   {
                                       DTabIncome.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
                                       // DTabIncome.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

                                       //----------
                                       foreach (DataRow DR in DTViewGroup.ToTable().Rows)
                                       {
                                           DTabIncome.Rows.Add("          " + DR["INCOME_ACCOUNT_NAME"], DR["OPENING_AMOUNT"], DR["INCOME_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DR["INCOME_ACCOUNT_CODE"]);
                                       }

                                       DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
                                   }
                                   DTabIncome.Rows.Add("          " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DRG["ACCOUNT_TYPE_CODE"], "");


                               }
                           }

                       }
                       if (Val.ToInt(pClsProeprty.IntReportType) > 0)
                       {
                           DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
                       }
                       DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"] + " TOTAL", DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");

                   }
               }

               if (DS.Tables[1].Rows.Count > 0)
               {
                   if (Val.ToInt(pClsProeprty.IntReportType) == 0)
                       DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
                   DTabIncome.Rows.Add("ASSETS ACCOUNT TOTAL", DS.Tables[1].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""), "", "", "", "");
               }

               DataTable DTabOuter = DTabIncome;
               DataTable DTabInner = DTabExpense;

               if (!DTabInner.Columns.Contains("INCOME_ACCOUNT_NAME"))
               {
                   DTabInner.Columns.Add("INCOME_ACCOUNT_NAME").SetOrdinal(5);
               }

               if (!DTabInner.Columns.Contains("OPENING_AMOUNT1"))
               {
                   DTabInner.Columns.Add("OPENING_AMOUNT1").SetOrdinal(6);
               }

               if (!DTabInner.Columns.Contains("INCOME_AMOUNT"))
               {
                   DTabInner.Columns.Add("INCOME_AMOUNT").SetOrdinal(7);
               }

               if (!DTabInner.Columns.Contains("CODE_1"))
               {
                   DTabInner.Columns.Add("CODE_1").SetOrdinal(8);
               }

               if (!DTabInner.Columns.Contains("TABLE_NAME_1"))
               {
                   DTabInner.Columns.Add("TABLE_NAME_1").SetOrdinal(9);
               }

               if (!DTabInner.Columns.Contains("ACC_TYPE_CODE"))
               {
                   DTabInner.Columns.Add("ACC_TYPE_CODE_1").SetOrdinal(10);
               }

               if (!DTabInner.Columns.Contains("LEDGER_CODE"))
               {
                   DTabInner.Columns.Add("LEDGER_CODE_1").SetOrdinal(11);
               }

               if (DTabExpense.Rows.Count > DTabIncome.Rows.Count)
               {
                   for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
                   {
                       DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
                       DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
                       DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
                       DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
                       DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

                       DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
                       DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
                   }
               }
               else
               {
                   for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
                   {
                       if (IntI <= DTabInner.Rows.Count - 1)
                       {
                           DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
                           DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
                           DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
                           DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
                           DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

                           DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
                           DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
                       }
                       else
                       {
                           DTabInner.Rows.Add("", "", "", "", "", DTabOuter.Rows[IntI][0], DTabOuter.Rows[IntI][1], DTabOuter.Rows[IntI][2], DTabOuter.Rows[IntI][3], DTabOuter.Rows[IntI][4], DTabOuter.Rows[IntI][5], DTabOuter.Rows[IntI][6]);
                       }
                   }
               }

               // Difference opening balance
               if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) != Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
               {
                   DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");

                   if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) > Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
                   {
                       DTabInner.Rows.Add("", "", "", "", "", "DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")));

                       DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "", "", "-------------------");
                       DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "ASSETS GRAND TOTAL", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""))));

                   }
                   else
                   {
                       DTabInner.Rows.Add("DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")), "", "", "");

                       DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");
                       DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""))), "", "", "ASSETS GRAND TOTAL", "", DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
                       DTabInner.Rows.Add("", "", "===============", "", "", "", "", "===============");
                   }
               }

               //for (int IntI = 0; IntI < DTabInner.Rows.Count; IntI++)
               //{
               //    if ((!DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
               //        !DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")) ||
               //        (!DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
               //        !DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")))

               //        {
               //            DTabInner.Rows[IntI].Delete();
               //            DTabInner.AcceptChanges();
               //        }
               //} 

               return DTabInner;
           }

           //public DataTable GenerateBalanceSheet(DataSet DS, ReportParams_Property pClsProeprty) // Khushbu 08/07/2014
           //{
           //    DataTable DTabExpense = new DataTable();
           //    DataTable DTabIncome = new DataTable();

           //    double DblTempCapitalAmt = 0.00;
           //    double DblTempPlAmt = 0.00;

           //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
           //    DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
           //    DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));

           //    DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
           //    DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
           //    DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

           //    // ADD : 26-05-2014 :   NARENDRA 

           //    DTabExpense.Columns.Add(new DataColumn("CODE_", typeof(string)));
           //    DTabExpense.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
           //    DTabExpense.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
           //    DTabExpense.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

           //    DTabIncome.Columns.Add(new DataColumn("CODE_", typeof(string)));
           //    DTabIncome.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
           //    DTabIncome.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
           //    DTabIncome.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

           //    if (DS.Tables[0].Rows.Count > 0)
           //    {
           //        if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "31")
           //        {
           //            // DTabExpense.Rows.Add(DS.Tables[0].Rows[0]["EXPENSE_ACCOUNT_NAME"], DS.Tables[0].Rows[0]["OPENING_AMOUNT"], DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
           //            DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
           //        }
           //    }

           //    DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
           //    DTAccountType.DefaultView.Sort = "BS_SRNO";
           //    DTAccountType = DTAccountType.DefaultView.ToTable();
           //    //ADD : NARENDRA : 23-05-2014
           //    DataTable DTAccountTypeGroup = new AccTypeGroupMaster().GetDataForSearch();
           //    DTAccountTypeGroup.DefaultView.Sort = "BS_SRNO";
           //    DTAccountTypeGroup = DTAccountTypeGroup.DefaultView.ToTable();
           //    //-------------------------
           //    DataView DTView = new DataView(DS.Tables[0]);

           //    DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

           //    DataRow[] DTRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
           */
        //    // -----------------------
        public DataTable GenerateBalanceSheet(DataSet DS, ReportParams_Property pClsProeprty) // Khushbu 08/07/2014
        {
            //DataTable DTabExpense = new DataTable();
            //DataTable DTabIncome = new DataTable();

            //double DblTempCapitalAmt = 0.00;
            //double DblTempPlAmt = 0.00;


            //DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));

            //DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

            //// ADD : 26-05-2014 :   NARENDRA 

            //DTabExpense.Columns.Add(new DataColumn("CODE_", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
            //DTabExpense.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

            //DTabIncome.Columns.Add(new DataColumn("CODE_", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("TABLE_NAME_", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("ACC_TYPE_CODE_", typeof(string)));
            //DTabIncome.Columns.Add(new DataColumn("LEDGER_CODE_", typeof(string)));

            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
            //    {
            //        // DTabExpense.Rows.Add(DS.Tables[0].Rows[0]["EXPENSE_ACCOUNT_NAME"], DS.Tables[0].Rows[0]["OPENING_AMOUNT"], DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
            //        DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
            //    }
            //}

            ////DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
            ////DTAccountType.DefaultView.Sort = "BS_SRNO";
            ////DTAccountType = DTAccountType.DefaultView.ToTable();
            ////ADD : NARENDRA : 23-05-2014
            ////DataTable DTAccountTypeGroup = new AccTypeGroupMaster().GetDataForSearch();
            ////DTAccountTypeGroup.DefaultView.Sort = "BS_SRNO";
            ////DTAccountTypeGroup = DTAccountTypeGroup.DefaultView.ToTable();
            //////-------------------------
            ////DataView DTView = new DataView(DS.Tables[0]);

            ////DataRow[] DTRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

            ////DataRow[] DTRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");

            //// ----------------------- FOR EXPENSE -------------------------//
            //foreach (DataRow DR in DTRow)
            //{
            //    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
            //    if (DTView.ToTable().Rows.Count > 0)
            //    {
            //        if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary.
            //        {
            //            DTabExpense.NewRow();
            //            DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
            //            DTabExpense.Rows.Add(Regex.Replace(DR["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

            //        }
            //        foreach (DataRow DRG in DTRowGroup)
            //        {
            //            DataView DTViewGroup = new DataView(DTView.ToTable());
            //            DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
            //            if (DTViewGroup.ToTable().Rows.Count > 0)
            //            {
            //                if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
            //                {
            //                    //--------
            //                    if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
            //                    {
            //                        DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
            //                        DTabExpense.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
            //                        foreach (DataRow DVRow in DTViewGroup.ToTable().Rows)
            //                        {
            //                            if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
            //                            {
            //                                ObjComp.GetCompanyCapitalMaster(Val.ToInt(pClsProeprty.Company_Code));

            //                                DataTable DTabCapital = ObjComp.DS.Tables["Company_Capital_Master"];

            //                                DataRow[] DTFilterRow = DTabCapital.Select("COMPANY_CODE = " + Val.ToInt(pClsProeprty.Company_Code) + " AND LEDGER_CODE = " + DVRow["EXPENSE_ACCOUNT_CODE"]);

            //                                if (DTFilterRow.Length > 0)
            //                                {
            //                                    DTabExpense.Rows.Add("      " + DVRow["EXPENSE_ACCOUNT_NAME"] + "(" + DTFilterRow[0]["shere_per"].ToString() + "% )", DVRow["OPENING_AMOUNT"], Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100, DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);

            //                                    if (DS.Tables[0].Rows.Count > 0)
            //                                    {
            //                                        if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
            //                                        {
            //                                            DblTempCapitalAmt = DblTempCapitalAmt + Val.ToDouble(DVRow["EXPENSE_AMOUNT"]) + DblTempPlAmt * Val.ToDouble(DTFilterRow[0]["shere_per"]) / 100;
            //                                        }
            //                                    }

            //                                }
            //                            }
            //                            else
            //                            {
            //                                DTabExpense.Rows.Add("      " + DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DVRow["EXPENSE_ACCOUNT_CODE"]);
            //                            }
            //                        }
            //                        DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
            //                    }//---end of rbt
            //                    if (DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DRG["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
            //                    {
            //                        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, DR["ACCOUNT_TYPE_CODE"], "LEDGER_TRANSACTION", DRG["ACCOUNT_TYPE_GROUP_CODE"], ""); // "" => DVRow["EXPENSE_ACCOUNT_CODE"]
            //                    }
            //                    else
            //                    {
            //                        DTabExpense.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL ", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

            //                    }
            //                    //if (Val.ToInt(RbtReportType.SelectedValue) > 0)
            //                    //{
            //                    //    DTabExpense.Rows.Add("", "-------------------", "---------------------");

            //                    //}
            //                }// End Of Summary Data.
            //            }
            //        }// END OF MAIN TOTAL
            //        //if (Val.ToInt(RbtReportType.SelectedValue) == 0)
            //        //  DTabExpense.Rows.Add("", "-------------------", "---------------------");
            //        if (DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "CAPITAL A/C" || DR["ACCOUNT_TYPE_NAME"].ToString().ToUpper() == "RESERVE AND SERPLUS")
            //        {
            //            DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", 0, DblTempCapitalAmt, "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");
            //        }
            //        else
            //        {
            //            if (Val.ToInt(pClsProeprty.IntReportType) > 0)
            //            {
            //                DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");

            //            }
            //            DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DR["ACCOUNT_TYPE_CODE"], "");

            //        }

            //    }
            //    //-----------------------------

            //}
            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    if (Val.ToInt(pClsProeprty.IntReportType) == 0)
            //        DTabExpense.Rows.Add("", "-------------------", "---------------------", "", "", "", "");
            //    DTabExpense.Rows.Add("LIABILITIES ACCOUNT TOTAL", DS.Tables[0].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "", "");
            //}

            ////-----------------------------------------//

            //// ---------------- FOR INCOME ---------------------------------

            //DataRow[] DTIncomeRow = DTAccountType.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
            //DataRow[] DTIncomeRowGroup = DTAccountTypeGroup.Select("IN_BALANCESHEET= 1 AND TRIAL_BALANCE_SIDE ='DEBIT' OR (ACCOUNT_TYPE_NAME = 'CLOSING STOCK')");
            //DataView DTIncomeView = new DataView(DS.Tables[1]);
            //foreach (DataRow DIRow in DTIncomeRow)
            //{
            //    DTIncomeView.RowFilter = "ACCOUNT_TYPE_CODE = " + DIRow["ACCOUNT_TYPE_CODE"];
            //    if (DTIncomeView.ToTable().Rows.Count > 0)
            //    {

            //        if (Val.ToInt(pClsProeprty.IntReportType) > 0)
            //        {
            //            DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"], "", "", "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
            //            DTabIncome.Rows.Add(Regex.Replace(DIRow["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "", "", "", "", "");
            //        }
            //        foreach (DataRow DRG in DTIncomeRowGroup)
            //        {
            //            DataView DTViewGroup = new DataView(DTIncomeView.ToTable());
            //            DTViewGroup.RowFilter = "ACCOUNT_TYPE_GROUP_CODE ='" + DRG["ACCOUNT_TYPE_GROUP_CODE"] + "' AND ACCOUNT_TYPE_CODE =" + DIRow["ACCOUNT_TYPE_CODE"];
            //            if (DTViewGroup.ToTable().Rows.Count > 0)
            //            {
            //                if (Val.ToInt(pClsProeprty.IntReportType) > 0) // To Show Summary Data.
            //                {
            //                    //--------
            //                    if (Val.ToInt(pClsProeprty.IntReportType) > 1) // To Show All Data.
            //                    {
            //                        DTabIncome.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"], "", "", DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");
            //                        DTabIncome.Rows.Add("    " + Regex.Replace(DRG["ACCOUNT_TYPE_GROUP_NAME"].ToString(), ".", "="), "", "", "", "", "", "");

            //                        //----------
            //                        foreach (DataRow DR in DTViewGroup.ToTable().Rows)
            //                        {
            //                            DTabIncome.Rows.Add("      " + DR["INCOME_ACCOUNT_NAME"], DR["OPENING_AMOUNT"], DR["INCOME_AMOUNT"], DRG["ACCOUNT_TYPE_GROUP_CODE"], "LEDGER_TRANSACTION", DR["ACCOUNT_TYPE_CODE"], DR["INCOME_ACCOUNT_CODE"]);
            //                        }

            //                        DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
            //                    }
            //                    DTabIncome.Rows.Add("    " + DRG["ACCOUNT_TYPE_GROUP_NAME"] + " TOTAL", DTViewGroup.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTViewGroup.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), DRG["ACCOUNT_TYPE_GROUP_CODE"], "ACCOUNT_TYPE_GROUP_MASTER", DRG["ACCOUNT_TYPE_CODE"], "");

            //                    //if (Val.ToInt(RbtReportType.SelectedValue) == 0)
            //                    //{
            //                    //    DTabIncome.Rows.Add("", "-------------------", "-------------------");
            //                    //}
            //                }
            //            }

            //        }
            //        if (Val.ToInt(pClsProeprty.IntReportType) > 0)
            //        {
            //            DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
            //        }
            //        DTabIncome.Rows.Add(DIRow["ACCOUNT_TYPE_NAME"] + " TOTAL", DTIncomeView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTIncomeView.ToTable().Compute("SUM(INCOME_AMOUNT)", ""), "", "ACCOUNT_TYPE_MASTER", DIRow["ACCOUNT_TYPE_CODE"], "");

            //    }
            //}

            //if (DS.Tables[1].Rows.Count > 0)
            //{
            //    if (Val.ToInt(pClsProeprty.IntReportType) == 0)
            //        DTabIncome.Rows.Add("", "-------------------", "-------------------", "", "", "", "");
            //    DTabIncome.Rows.Add("ASSETS ACCOUNT TOTAL", DS.Tables[1].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""), "", "", "", "");
            //}

            //DataTable DTabOuter = DTabIncome;
            //DataTable DTabInner = DTabExpense;

            //if (!DTabInner.Columns.Contains("INCOME_ACCOUNT_NAME"))
            //{
            //    DTabInner.Columns.Add("INCOME_ACCOUNT_NAME").SetOrdinal(5);
            //}

            //if (!DTabInner.Columns.Contains("OPENING_AMOUNT1"))
            //{
            //    DTabInner.Columns.Add("OPENING_AMOUNT1").SetOrdinal(6);
            //}

            //if (!DTabInner.Columns.Contains("INCOME_AMOUNT"))
            //{
            //    DTabInner.Columns.Add("INCOME_AMOUNT").SetOrdinal(7);
            //}

            //if (!DTabInner.Columns.Contains("CODE_1"))
            //{
            //    DTabInner.Columns.Add("CODE_1").SetOrdinal(8);
            //}

            //if (!DTabInner.Columns.Contains("TABLE_NAME_1"))
            //{
            //    DTabInner.Columns.Add("TABLE_NAME_1").SetOrdinal(9);
            //}

            //if (!DTabInner.Columns.Contains("ACC_TYPE_CODE"))
            //{
            //    DTabInner.Columns.Add("ACC_TYPE_CODE_1").SetOrdinal(10);
            //}

            //if (!DTabInner.Columns.Contains("LEDGER_CODE"))
            //{
            //    DTabInner.Columns.Add("LEDGER_CODE_1").SetOrdinal(11);
            //}

            //if (DTabExpense.Rows.Count > DTabIncome.Rows.Count)
            //{
            //    for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
            //    {
            //        DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
            //        DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
            //        DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
            //        DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
            //        DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

            //        DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
            //        DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
            //    }
            //}
            //else
            //{
            //    for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
            //    {
            //        if (IntI <= DTabInner.Rows.Count - 1)
            //        {
            //            DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][0];
            //            DTabInner.Rows[IntI][6] = DTabOuter.Rows[IntI][1];
            //            DTabInner.Rows[IntI][7] = DTabOuter.Rows[IntI][2];
            //            DTabInner.Rows[IntI][8] = DTabOuter.Rows[IntI][3];
            //            DTabInner.Rows[IntI][9] = DTabOuter.Rows[IntI][4];

            //            DTabInner.Rows[IntI][10] = DTabOuter.Rows[IntI][5];
            //            DTabInner.Rows[IntI][11] = DTabOuter.Rows[IntI][6];
            //        }
            //        else
            //        {
            //            DTabInner.Rows.Add("", "", "", "", "", DTabOuter.Rows[IntI][0], DTabOuter.Rows[IntI][1], DTabOuter.Rows[IntI][2], DTabOuter.Rows[IntI][3], DTabOuter.Rows[IntI][4], DTabOuter.Rows[IntI][5], DTabOuter.Rows[IntI][6]);
            //        }
            //    }
            //}

            //// Difference opening balance
            //if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) != Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
            //{
            //    DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");

            //    if (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) > Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")))
            //    {
            //        DTabInner.Rows.Add("", "", "", "", "", "DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")));

            //        DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "", "", "-------------------");
            //        DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""), "", "", "ASSETS GRAND TOTAL", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) - Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""))));

            //    }
            //    else
            //    {
            //        DTabInner.Rows.Add("DIFF. IN OPENING BALANCE", "", Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")), "", "", "");

            //        DTabInner.Rows.Add("", "", "-------------------", "", "", "", "", "-------------------");
            //        DTabInner.Rows.Add("LIABILITIES GRAND TOTAL", "", Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", "")) + (Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", "")) - Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""))), "", "", "ASSETS GRAND TOTAL", "", DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            //        DTabInner.Rows.Add("", "", "===============", "", "", "", "", "===============");
            //    }
            //}

            ////for (int IntI = 0; IntI < DTabInner.Rows.Count; IntI++)
            ////{
            ////    if ((!DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
            ////        !DTabInner.Rows[IntI]["EXPENSE_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")) ||
            ////        (!DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("TOTAL") &&
            ////        !DTabInner.Rows[IntI]["INCOME_ACCOUNT_NAME"].ToString().ToUpper().Contains("DIFF. IN OPENING BALANCE")))

            ////        {
            ////            DTabInner.Rows[IntI].Delete();
            ////            DTabInner.AcceptChanges();
            ////        }
            ////} 
            DataTable DTabInner = new DataTable();
            return DTabInner;
        }

        public DataTable GenerateTradingAccountReport(DataSet DS) //Khushbu 08/07/2014
        {
            DataTable DTabExpense = new DataTable();
            DataTable DTabIncome = new DataTable();

            DTabExpense.Columns.Add(new DataColumn("EXPENSE_ACCOUNT_NAME", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("OPENING_AMOUNT", typeof(string)));
            DTabExpense.Columns.Add(new DataColumn("EXPENSE_AMOUNT", typeof(string)));


            DTabIncome.Columns.Add(new DataColumn("INCOME_ACCOUNT_NAME", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("OPENING_AMOUNT1", typeof(string)));
            DTabIncome.Columns.Add(new DataColumn("INCOME_AMOUNT", typeof(string)));

            double DblTempPlAmt = 0.00;

            if (DS.Tables[0].Rows.Count > 0)
            {
                if (DS.Tables[0].Rows[0]["ACCOUNT_TYPE_CODE"].ToString() == "0")
                {
                    DblTempPlAmt = Val.ToDouble(DS.Tables[0].Rows[0]["EXPENSE_AMOUNT"]);
                }
            }

            //DataTable DTAccountType = new AccountTypeMaster().GetDataForSearch();
            DataView DTView = new DataView(DS.Tables[0]);

            //DataRow[] DTRow = DTAccountType.Select("IN_TRADING= 1 AND TRIAL_BALANCE_SIDE ='DEBIT'");

            // ----------------------- FOR EXPENSE -------------------------//
            //foreach (DataRow DR in DTRow)
            //{
            //    DTView.RowFilter = "ACCOUNT_TYPE_CODE =" + DR["ACCOUNT_TYPE_CODE"];
            //    if (DTView.ToTable().Rows.Count > 0)
            //    {
            //        DTabExpense.NewRow();

            //        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"], "", "");
            //        DTabExpense.Rows.Add(Regex.Replace(DR["ACCOUNT_TYPE_NAME"].ToString(), ".", "="), "", "");

            //        foreach (DataRow DVRow in DTView.ToTable().Rows)
            //        {
            //            DTabExpense.Rows.Add(DVRow["EXPENSE_ACCOUNT_NAME"], DVRow["OPENING_AMOUNT"], DVRow["EXPENSE_AMOUNT"]);
            //        }
            //        DTabExpense.Rows.Add("", "-------------------", "---------------------");

            //        DTabExpense.Rows.Add(DR["ACCOUNT_TYPE_NAME"] + " TOTAL ", DTView.ToTable().Compute("SUM(OPENING_AMOUNT)", ""), DTView.ToTable().Compute("SUM(EXPENSE_AMOUNT)", ""));

            //        DTabExpense.Rows.Add("", "-------------------", "---------------------");
            //    }
            //}
            if (DS.Tables[0].Rows.Count > 0)
            {
                DTabExpense.Rows.Add("EXPENSE ACCOUNT TOTAL", DS.Tables[0].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""));
            }

            //-----------------------------------------//

            // ---------------- FOR INCOME ---------------------------------

            //DataRow[] DTIncomeRow = DTAccountType.Select("IN_TRADING = 1 AND TRIAL_BALANCE_SIDE ='CREDIT'");
            DataView DTIncomeView = new DataView(DS.Tables[1]);
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

            if (DS.Tables[1].Rows.Count > 0)
            {
                DTabIncome.Rows.Add("INCOME ACCOUNT TOTAL", DS.Tables[1].Compute("SUM(OPENING_AMOUNT)", ""), DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            }

            DataTable DTabOuter = DTabIncome;
            DataTable DTabInner = DTabExpense;

            if (!DTabInner.Columns.Contains("INCOME_ACCOUNT_NAME"))
            {
                DTabInner.Columns.Add("INCOME_ACCOUNT_NAME").SetOrdinal(3);
            }

            if (!DTabInner.Columns.Contains("OPENING_AMOUNT1"))
            {
                DTabInner.Columns.Add("OPENING_AMOUNT1").SetOrdinal(4);
            }

            if (!DTabInner.Columns.Contains("INCOME_AMOUNT"))
            {
                DTabInner.Columns.Add("INCOME_AMOUNT").SetOrdinal(5);
            }

            if (DTabExpense.Rows.Count > DTabIncome.Rows.Count)
            {
                for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
                {
                    DTabInner.Rows[IntI][3] = DTabOuter.Rows[IntI][0];
                    DTabInner.Rows[IntI][4] = DTabOuter.Rows[IntI][1];
                    DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][2];
                }
            }
            else
            {
                for (int IntI = 0; IntI < DTabOuter.Rows.Count; IntI++)
                {
                    if (IntI <= DTabInner.Rows.Count - 1)
                    {
                        DTabInner.Rows[IntI][3] = DTabOuter.Rows[IntI][0];
                        DTabInner.Rows[IntI][4] = DTabOuter.Rows[IntI][1];
                        DTabInner.Rows[IntI][5] = DTabOuter.Rows[IntI][2];
                    }
                    else
                    {
                        DTabInner.Rows.Add("", "", "", DTabOuter.Rows[IntI][0], DTabOuter.Rows[IntI][1], DTabOuter.Rows[IntI][2]);
                    }
                }
            }


            double DblSumIncome = Val.ToDouble(DS.Tables[1].Compute("SUM(INCOME_AMOUNT)", ""));
            double DblSumExpense = Val.ToDouble(DS.Tables[0].Compute("SUM(EXPENSE_AMOUNT)", ""));

            if (DblSumIncome - DblSumExpense < 0)
            {
                DTabInner.Rows.Add("", "", "", "GROSS LOSS TRANS. TO PL A/C", "", System.Math.Round(Math.Abs(DblSumIncome - DblSumExpense), 2));
                DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
                DTabInner.Rows.Add("EXPENSE GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2), "INCOME GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2));
                DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            }

            else
            {
                DTabInner.Rows.Add("", "", "", "GROSS PROFIT TRANS. TO PL A/C", "", System.Math.Round(Math.Abs(DblSumIncome - DblSumExpense), 2));
                DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
                DTabInner.Rows.Add("EXPENSE GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2), "INCOME GRAND TOTAL", "", System.Math.Round(DblSumExpense, 2));
                DTabInner.Rows.Add("", "", "------------------------", "", "", "------------------------");
            }
            return DTabInner;
        }

        public DataTable tGenerateProfitLossreport(DataSet DS, string pStrReportTYpe) //Khushbu 08/07/2014
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
            double DouExpenseNetToTal = 0, DouIncomeNetTotal = 0;
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

                if (UDRowIncome.Count() != 0 && UDRowExpense.Count() != 0)
                {
                    if (pStrReportTYpe != "ACCOUNT_TYPE")
                    {
                        if (DouGrossDiff < 0)
                        {
                            DouLastExpenseGross = DouGrossDiff * -1;
                            DTabCombine.Rows.Add("GROSS LOSS c/o", "", Val.Format(DouGrossDiff * -1, "###############0.00"), "", "", "");
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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");


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
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                            DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
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
                            DTabCombine.Rows.Add("", "", "", "GROSS LOSS b/f", "", Val.Format(DouGrossDiff * -1, "###############0.00"));
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
                DTabCombine.Rows.Add("TOTAL", "", Val.Format((DouExpenseNetToTal + DouLastExpenseGross), "###############0.00"), "TOTAL", "", Val.Format((DouIncomeNetTotal + DouLastIncomeGross), "###############0.00"));
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

        public DataTable Generate_LedgerGroup_Detail(DataTable DTab, string start_Date)
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
            //                // DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(douOpening);
            //                DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(douOpening) + " CR";
            //            }
            //            else
            //            {
            //                DTNewRow["CREDIT_AMOUNT"] = "0.00";
            //                DTNewRow["DEBIT_AMOUNT"] = Val.ToString(Math.Abs(douOpening));
            //                DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(Math.Abs(douOpening)) + " DR";
            //                // DTNewRow["RUNNING_LEDGER_BALANCE"] = Val.ToString(Math.Abs(douOpening));
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
            //            if (DouTotal >= 0)
            //            {
            //                DTNewRow["CREDIT_AMOUNT"] = DouTotal;
            //            }
            //            else
            //            {
            //                DTNewRow["DEBIT_AMOUNT"] = Math.Abs(DouTotal);
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

        public DataTable Generate_BalanceSheet_Report(DataTable DTab, string pStrReportTYpe) //Khushbu 11/09/2014
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
            DTAccountType.Columns.Add("IN_BALANCESHEET", typeof(int));
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

                            //foreach (DataRow DVRow in DTabDistinct.Rows)
                            //{
                            //    if (Val.ToInt(DRDist["LEDGER_CODE_COMBINE"]) == Val.ToInt(DVRow["LEDGER_CODE_COMBINE"]))
                            //    {
                            //        DouAmount += (Val.Val(DVRow["CREDIT_AMOUNT"]) - Val.Val(DVRow["DEBIT_AMOUNT"]));
                            //        DouOpening += Val.Val(DVRow["OPENING_AMOUNT"]);
                            //    }                               
                            //}
                            DRNew["EXPENSE_OPENING_AMOUNT"] = DouOpening;
                            DRNew["EXPENSE_AMOUNT"] = DouAmount;
                            DTabExpense.Rows.Add(DRNew);
                        }
                    }
                    /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
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
                    }*/
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
                    /*else if (pStrReportTYpe == "ACCOUNT_TYPE_PLUS_GROUP")
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
                    }*/
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

                        /*if (IntI < 3 && DouGrossDiff < 0)
                        {
                            DouLastExpenseGrossProfit = DouGrossDiff;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff*-1, "###############0.00");

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 3 && DouGrossDiff > 0)
                        {
                            DouLastIncomeGrossProfit = DouGrossDiff;
                            
                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS PROFIT b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);
                        }
                        */

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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

                        DRNew["INCOME_DETAIL_MODE"] = UDRowIncome[IntJ]["INCOME_DETAIL_MODE"];
                        DRNew["INCOME_ACCOUNT_CODE"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_CODE"];
                        DRNew["INCOME_ACCOUNT_NAME"] = UDRowIncome[IntJ]["INCOME_ACCOUNT_NAME"];
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
                            DRNew["EXPENSE_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_AMOUNT"], "#################0.00");

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
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                            DRNew["INCOME_OPENING_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_OPENING_AMOUNT"], "#################0.00");
                            DRNew["INCOME_AMOUNT"] = Val.Val(UDRowIncome[IntJ]["INCOME_AMOUNT"]) == 0 ? "" : Val.Format(UDRowIncome[IntJ]["INCOME_AMOUNT"], "#################0.00");

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
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Val(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"]) == 0 ? "" : Val.Format(UDRowExpense[IntJ]["EXPENSE_OPENING_AMOUNT"], "#################0.00");
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

                        DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                        DRNew["EXPENSE_ACCOUNT_NAME"] = Val.ToString(UDRowExpense[0]["EXPENSE_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["EXPENSE_OPENING_AMOUNT"] = Val.Format(DouExpenseOpening, "#################0.00");
                        DRNew["EXPENSE_AMOUNT"] = Val.Format(DouExpenseAmount, "#################0.00");
                        DRNew["INCOME_ACCOUNT_CODE"] = 0;
                        DRNew["INCOME_ACCOUNT_NAME"] = Val.ToString(UDRowIncome[0]["INCOME_ACCOUNT_TYPE_NAME"]) + "  TOTAL";
                        DRNew["INCOME_OPENING_AMOUNT"] = Val.Format(DouIncomeOpening, "#################0.00");
                        DRNew["INCOME_AMOUNT"] = Val.Format(DouIncomeAmount, "#################0.00");

                        DTabCombine.Rows.Add(DRNew);

                        DouGrossDiff += DouIncomeAmount - DouExpenseAmount;

                        DouLastExpenseAmount = DouExpenseAmount;
                        DouLastIncomeAmount = DouIncomeAmount;

                        if (IntI < 2 && DouGrossDiff > 0)
                        {
                            DouLastExpenseGrossProfit = DouGrossDiff + DouLastIncomeAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS PROFIT c/o";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

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
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);

                        }
                        else if (IntI < 2 && DouGrossDiff < 0)
                        {
                            DouLastIncomeGrossProfit = DouGrossDiff + DouLastExpenseAmount;

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = "";

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

                            DTabCombine.Rows.Add(DRNew);

                            DRNew = DTabCombine.NewRow();

                            DRNew["EXPENSE_DETAIL_MODE"] = "";
                            DRNew["EXPENSE_ACCOUNT_CODE"] = 0;
                            DRNew["EXPENSE_ACCOUNT_NAME"] = "GROSS LOSS b/f";
                            DRNew["EXPENSE_OPENING_AMOUNT"] = "";
                            DRNew["EXPENSE_AMOUNT"] = Val.Format(DouGrossDiff * -1, "###############0.00");

                            DRNew["INCOME_DETAIL_MODE"] = "";
                            DRNew["INCOME_ACCOUNT_CODE"] = 0;
                            DRNew["INCOME_ACCOUNT_NAME"] = "";
                            DRNew["INCOME_OPENING_AMOUNT"] = 0;
                            DRNew["INCOME_AMOUNT"] = "";

                            DTabCombine.Rows.Add(DRNew);

                        }
                    }
                }
            }

            //DTabCombine.Rows.Add("EXPENSE ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_OPENING_AMOUNT)", ""))), "###############0.00"),
            //                                                Val.Format((Val.ToDouble(DTabExpense.Compute("SUM(EXPENSE_AMOUNT)", ""))), "###############0.00"),
            //                     "INCOME ACCOUNT TOTAL", Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_OPENING_AMOUNT)", ""))), "###############0.00"),
            //                                                Val.Format((Val.ToDouble(DTabIncome.Compute("SUM(INCOME_AMOUNT)", ""))), "###############0.00")
            //                                                );



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
                DRNew["EXPENSE_AMOUNT"] = Val.Format((DblSumIncome - DblSumExpense), "###############0.00");

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
                DRNew["EXPENSE_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format(DouLastExpenseGrossProfit, "###############0.00");
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
                DRNew["INCOME_ACCOUNT_NAME"] = "NET PROFIT TRANS. TO CAPITAL A/C";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format((DblSumExpense - DblSumIncome), "###############0.00");
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
                DRNew["EXPENSE_AMOUNT"] = Val.Format((DouLastExpenseAmount + DouLastExpenseGrossProfit), "###############0.00");

                DRNew["INCOME_DETAIL_MODE"] = "";
                DRNew["INCOME_ACCOUNT_CODE"] = 0;
                DRNew["INCOME_ACCOUNT_NAME"] = "TOTAL";
                DRNew["INCOME_OPENING_AMOUNT"] = 0;
                DRNew["INCOME_AMOUNT"] = Val.Format((DouLastIncomeAmount + DouLastIncomeGrossProfit), "###############0.00");
                DTabCombine.Rows.Add(DRNew);
            }

            return DTabCombine;
        }

        #endregion

        #endregion
    }
}
