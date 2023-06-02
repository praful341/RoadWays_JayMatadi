using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Master
{
    public class LedgerMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int From_Party_Save(Ledger_MasterProperty pClsProperty)
        {
            int IntRes = 0;

            Request Request = new Request();

            Request.AddParams("@Ledger_code", pClsProperty.Ledger_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Ledger_Name", pClsProperty.Ledger_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Mobile", pClsProperty.Mobile_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_PanNo", pClsProperty.Pan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Type", pClsProperty.Party_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Email", pClsProperty.EMail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Address", pClsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Country_Code", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_State_Code", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_City_Code", pClsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_Pincode", pClsProperty.Zip_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Phone", pClsProperty.Phone, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Name", pClsProperty.Bank_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Branch", pClsProperty.Bank_Branch, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_IFSC", pClsProperty.Bank_IFSC, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_AccountNo", pClsProperty.Bank_Acc_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@GSTIN", pClsProperty.GSTTIN, DbType.String, ParameterDirection.Input);
            Request.AddParams("@GSTIN_EFFECTIVE_DATE", pClsProperty.GSTIN_Effective_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "From_Party_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //if (IntRes != -1)
            //{
            //    foreach (Ledger_MasterProperty Obj in AL)
            //    {
            //        Request = new Request();

            //        Request.AddParams("@COMPANY_CODE_", Obj.Company_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@BRANCH_CODE_", Obj.Branch_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LOCATION_CODE_", Obj.Location_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LEDGER_CODE_", Obj.Ledger_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LEDGER_OPENING_ID_", Obj.LEDGER_OPENING_ID, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@DEBIT_AMT_", Obj.Debit_Amt, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("@CREDIT_AMT_", Obj.Credit_Amt, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("@FIN_YEAR_CODE_", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@OPENING_DATE_", Obj.Opening_Date, DbType.Date, ParameterDirection.Input);

            //        Request.CommandText = "Ledger_Opening_Save";
            //        Request.CommandType = CommandType.StoredProcedure;
            //        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //    }
            //}
            return IntRes;
        }

        public DataTable From_Party_GetData(Ledger_MasterProperty Type)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", Type.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Type", Type.Party_Type, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "From_Party_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable From_Party_GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "From_Party_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists_From_Party(string LedgerName, Int64 LedgerCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "From_Party_Master", "From_Party_NAME", "AND From_Party_NAME = '" + LedgerName + "' AND NOT From_Party_CODE =" + LedgerCode));
        }

        public DataTable GetLedgerOpeningDetail(Int64 pIntLedgerCode = 0)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@LEDGER_CODE_", pIntLedgerCode, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Ledger_Opening_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int To_Party_Save(Ledger_MasterProperty pClsProperty)
        {
            int IntRes = 0;

            Request Request = new Request();

            Request.AddParams("@Ledger_code", pClsProperty.Ledger_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Ledger_Name", pClsProperty.Ledger_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Mobile", pClsProperty.Mobile_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_PanNo", pClsProperty.Pan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Type", pClsProperty.Party_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Email", pClsProperty.EMail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Address", pClsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Country_Code", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_State_Code", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_City_Code", pClsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_Pincode", pClsProperty.Zip_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Phone", pClsProperty.Phone, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Name", pClsProperty.Bank_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Branch", pClsProperty.Bank_Branch, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_IFSC", pClsProperty.Bank_IFSC, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_AccountNo", pClsProperty.Bank_Acc_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@GSTIN", pClsProperty.GSTTIN, DbType.String, ParameterDirection.Input);
            Request.AddParams("@GSTIN_EFFECTIVE_DATE", pClsProperty.GSTIN_Effective_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "To_Party_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //if (IntRes != -1)
            //{
            //    foreach (Ledger_MasterProperty Obj in AL)
            //    {
            //        Request = new Request();

            //        Request.AddParams("@COMPANY_CODE_", Obj.Company_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@BRANCH_CODE_", Obj.Branch_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LOCATION_CODE_", Obj.Location_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LEDGER_CODE_", Obj.Ledger_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@LEDGER_OPENING_ID_", Obj.LEDGER_OPENING_ID, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@DEBIT_AMT_", Obj.Debit_Amt, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("@CREDIT_AMT_", Obj.Credit_Amt, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("@FIN_YEAR_CODE_", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("@OPENING_DATE_", Obj.Opening_Date, DbType.Date, ParameterDirection.Input);

            //        Request.CommandText = "Ledger_Opening_Save";
            //        Request.CommandType = CommandType.StoredProcedure;
            //        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //    }
            //}
            return IntRes;
        }

        public DataTable To_Party_GetData(Ledger_MasterProperty Type)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", Type.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Type", Type.Party_Type, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "To_Party_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable To_Party_GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "To_Party_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists_To_Party(string LedgerName, Int64 LedgerCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "To_Party_Master", "To_Party_NAME", "AND To_Party_NAME = '" + LedgerName + "' AND NOT To_Party_CODE =" + LedgerCode));
        }
        public DataTable From_Party_Distinct_GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "MST_From_Party_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable To_Party_Distinct_GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "MST_To_Party_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable Description_Distinct_GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "MST_Description_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        #endregion

    }
}

