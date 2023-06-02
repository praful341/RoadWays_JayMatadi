using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Account;
using BLL.FunctionClasses.Account;
using BLL.PropertyClasses.Master;
using BLL.FunctionClasses.Master;
using System.Data;
using DLL;
namespace BLL.FunctionClasses.Account
{
     public class TexMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        public enum EnumPayHeads
        {
            OTHER_ALL = 0,
            MOTOR_REI = 1,
            MEDICAL_ALL = 2,
            BOOKS_ALL = 3,
            LUNCH_ALL = 4,
            OW_ALL = 5,
            MEDICAL_REI = 6,
            BONUS_ALL = 7,
            TRANS_ALL = 8,
            LT_ALL = 9,
            PRED_ALL = 10,
            HELPER_ALL = 11,
            BASIC = 12,
            HRA = 13,
            MOBILE_REI = 14,
            EDU_ALL = 15,
            CONV_REI = 16
        }

        #region Property Settings

        private DataTable _DTab = new DataTable("Tax_Master");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        #endregion

        #region Other Function

        public int FindNewID()
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Tax_Master", "MAX(TAX_CODE)", "");
        }

        //public int Save(Tax_MasterProperty pClsProperty)
        //{
        //    pClsProperty.Record_Code = FindRecordCode(pClsProperty.Tax_Code);
        //    pClsProperty.Record_Code = new RecordMaster().Save(pClsProperty.Record_Code);

        //    Request Request = new Request();
        //    Request.AddParams("TAX_CODE_", pClsProperty.Tax_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TAX_NAME_", pClsProperty.Tax_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TAX_TYPE_", pClsProperty.Tax_Type, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECORD_CODE_", pClsProperty.Record_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SEQUENCE_NO_", pClsProperty.Sequence_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("KEY_FIELD_", pClsProperty.Key_Field, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("APPLICABLE_ON_", pClsProperty.Applicable_On, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("IS_PERCENTAGE_", pClsProperty.Is_Percentage, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_EDITABLE_", pClsProperty.Is_Editable, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TAX_VALUE_", pClsProperty.Tax_Value, DbType.Double, ParameterDirection.Input);

        //    //Request.AddParams("IS_PF_", pClsProperty.IS_PF, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("IS_ESIC_", pClsProperty.IS_ESIC, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("IS_PT_", pClsProperty.IS_PT, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("IS_LWF_", pClsProperty.IS_LWF, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("APPLY_IN_SALARY_BIFURCATION_", pClsProperty.Apply_IN_Salary_Bifurcation, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = "Tax_Master_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        //public int Delete(Tax_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("TAX_CODE_", pClsProperty.Tax_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Tax_Master_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public void GetData()
        {
            Request Request = new Request();
            Request.CommandText = "Tax_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        }

        public DataTable GetDataForSearch()
        {
            Request Request = new Request();

            Request.AddParams("ACTIVE_", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Tax_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public int FindRecordCode(int pIntCode)
        {
            Validation Val = new Validation();
            int IntRes = Val.ToInt(Val.SearchText(DTab, "TAX_CODE", pIntCode.ToString(), "Record_Code"));
            Val = null;
            return IntRes;
        }


        #endregion

    }
}
