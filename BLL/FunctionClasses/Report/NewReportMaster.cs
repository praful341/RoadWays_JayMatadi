using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using BLL.FunctionClasses.Master;
using System.Data;
using DLL;
using BLL.PropertyClasses.Report;

namespace BLL.FunctionClasses.Report
{
    public class NewReportMaster
    {
        BLL.Validation Val = new Validation();

        #region Property Settings

        InterfaceLayer Ope = new InterfaceLayer();

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        public string TableName
        {
            get { return "Purchase_Master"; }
        }

        public string TableNameDetail
        {
            get { return "New_Report_Detail"; }
        }

        public string TableNameSettings
        {
            get { return "New_Report_Settings"; }
        }

        #endregion
        //add by haresh

        #region Other Function

        public int FindNewID()
        {

            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "New_Report_Master", "MAX(REPORT_CODE)", "");

        }

        public int FindNewSrNo(int pIntYearMonth) //Used In New_Report_Trace Table. Khushbu 07/04/2014
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "New_Report_Trace", "MAX(SRNO)"," AND YYMM = " + pIntYearMonth);
        }


        /// <summary>
        /// Report Master
        /// </summary>
        /// <param name="pIntReportCode"></param>
        /// <param name="pStrReportGroup"></param>
        /// 
        public void GetData(int pIntReportCode = 0, string pStrReportGroup = null,int pIntEmployeeCode = 0)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pIntEmployeeCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_GROUP_NAME_", pStrReportGroup, DbType.String, ParameterDirection.Input);
            //Request.AddParams("Allow_Developer_", GlobalDec.gEmployeeProperty.Allow_Developer, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "New_Report_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableName, Request, "");
        }

        public void GetReportDetail(int pIntReportCode)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "New_Report_Detail_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameDetail, Request, "");
        }

        public void GetReportSettings(int pIntReportCode, string pStrReportType)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pStrReportType, DbType.String, ParameterDirection.Input);
            Request.CommandText = "New_Report_Settings_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameSettings, Request, "");
        }

        public DataTable GetDataForSearchMaster(int pIntReportCode = 0, string pStrReportGroup = null,int pIntEmployeeCode = 0)
        {
            GetData(pIntReportCode, pStrReportGroup, pIntEmployeeCode);
            return DS.Tables[TableName];
        }

        public DataTable GetDataForSearchDetail(int pIntReportCode = 0)
        {
            GetReportDetail(pIntReportCode);
            return DS.Tables[TableNameDetail];
        }

        public DataTable GetDataForSearchSettings(int pIntReportCode = 0, string pStrReportType=null)
        {
            GetReportSettings(pIntReportCode, pStrReportType);
            return DS.Tables[TableNameSettings];
        }



        public int Save(New_Report_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_NAME_", pClsProperty.Report_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("REPORT_GROUP_NAME_", pClsProperty.Report_Group_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("FORM_NAME_", pClsProperty.Form_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("SEQUENCE_NO_", pClsProperty.Sequence_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("DISP_IN_", pClsProperty.Disp_In, DbType.String, ParameterDirection.Input);

            Request.CommandText = "New_Report_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int SaveReportDetail(New_Report_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCEDURE_NAME_", pClsProperty.Procedure_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("REPORT_HEADER_NAME_", pClsProperty.Report_Header_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("RPT_NAME_", pClsProperty.Rpt_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEFAULT_ORDER_BY_", pClsProperty.Default_Order_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("DEFAULT_GROUP_BY_", pClsProperty.Default_Group_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_PIVOT_", pClsProperty.Is_Pivot, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("FONT_SIZE_", pClsProperty.Font_Size, DbType.Double, ParameterDirection.Input);
            Request.AddParams("FONT_NAME_", pClsProperty.Font_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("PAGE_ORIENTATION_", pClsProperty.Page_Orientation, DbType.String, ParameterDirection.Input);
            Request.AddParams("PAGE_KIND_", pClsProperty.Page_Kind, DbType.String, ParameterDirection.Input);
            Request.AddParams("AUTOFIT_", pClsProperty.Autofit, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "New_Report_Detail_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int SaveReportSettings(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIELD_NO_", pClsProperty.Field_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIELD_NAME_", pClsProperty.Field_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLUMN_NAME_", pClsProperty.Column_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("SEQUENCE_NO_", pClsProperty.Sequence_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("AGGREGATE_", pClsProperty.Aggregate, DbType.String, ParameterDirection.Input);
            Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("VISIBLE_", pClsProperty.Visible, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ISMERGE_", pClsProperty.IsMerge, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MERGEON_", pClsProperty.MergeOn, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_GROUP_", pClsProperty.Is_Group, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_ROW_AREA_", pClsProperty.Is_Row_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_COLUMN_AREA_", pClsProperty.Is_Column_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_DATA_AREA_", pClsProperty.Is_Data_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ORDER_BY_", pClsProperty.Order_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_UNBOUND_", pClsProperty.Is_Unbound, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EXPRESSION_", pClsProperty.Expression, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANDS_", pClsProperty.Bands, DbType.String, ParameterDirection.Input);

            // ADD : NARENDRA : 09-JAN-2015
            Request.AddParams("THEMES_NAME_", pClsProperty.Themes_Name, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.String, ParameterDirection.Input);
            // ADD : NARENDRA : 09-JAN-2015
            Request.AddParams("FORMAT_", pClsProperty.Format, DbType.String, ParameterDirection.Input);
            Request.AddParams("ALIGNMENT_", pClsProperty.Alignment, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLUMN_WIDTH_", pClsProperty.Column_Width, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "New_Report_Settings_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        // Add : Narendra : 03-12-2014 
        public int SaveReportSettings_Template(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIELD_NO_", pClsProperty.Field_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIELD_NAME_", pClsProperty.Field_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLUMN_NAME_", pClsProperty.Column_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("SEQUENCE_NO_", pClsProperty.Sequence_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("AGGREGATE_", pClsProperty.Aggregate, DbType.String, ParameterDirection.Input);
            Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("VISIBLE_", pClsProperty.Visible, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ISMERGE_", pClsProperty.IsMerge, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MERGEON_", pClsProperty.MergeOn, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_GROUP_", pClsProperty.Is_Group, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_ROW_AREA_", pClsProperty.Is_Row_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_COLUMN_AREA_", pClsProperty.Is_Column_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_DATA_AREA_", pClsProperty.Is_Data_Area, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ORDER_BY_", pClsProperty.Order_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_UNBOUND_", pClsProperty.Is_Unbound, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EXPRESSION_", pClsProperty.Expression, DbType.String, ParameterDirection.Input);
            Request.AddParams("BANDS_", pClsProperty.Bands, DbType.String, ParameterDirection.Input);

            Request.AddParams("FORMAT_", pClsProperty.Format, DbType.String, ParameterDirection.Input);
            Request.AddParams("ALIGNMENT_", pClsProperty.Alignment, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLUMN_WIDTH_", pClsProperty.Column_Width, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("THEMES_NAME_", pClsProperty.Themes_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GRID_OR_PIVOT_NAME_", pClsProperty.Grid_Or_Pivot_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("IS_BOLD_", pClsProperty.Is_Bold, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_ITALIC_", pClsProperty.Is_Italic, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("IS_UNDERLINE_", pClsProperty.Is_Underline, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BACKCOLOR_", pClsProperty.BackColor, DbType.String, ParameterDirection.Input);
            Request.AddParams("FORCOLOR_", pClsProperty.ForColor, DbType.String, ParameterDirection.Input);
            Request.AddParams("GRIDCOLOR_", pClsProperty.GridColor, DbType.String, ParameterDirection.Input);
            Request.AddParams("ACTIVE_THEME_", pClsProperty.Active_Theme, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FILTER_EXPRESSION_", pClsProperty.Filter_Expression, DbType.String, ParameterDirection.Input);
            Request.AddParams("GRID_THEME_", pClsProperty.Grid_Theme, DbType.String, ParameterDirection.Input);


            Request.CommandText = "NEW_REPORTSETTING_SAVE_TEMPLAT";// BLL.TPV.SProc.New_Report_Settings_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int DeleteReportSettings_Template(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIELD_NO_", pClsProperty.Field_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("THEMES_NAME_", pClsProperty.Themes_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GRID_OR_PIVOT_NAME_", pClsProperty.Grid_Or_Pivot_Name, DbType.String, ParameterDirection.Input);

            Request.CommandText = "NEW_REPORTSETTING_DELET_TEMPL";// BLL.TPV.SProc.New_Report_Settings_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetReportSettings_For_Template(int pIntReportCode, string pStrReportType)
        {
            DataTable DtResult = new DataTable();
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pStrReportType, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "New_Report_Settings_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtResult, Request,"");

            return DtResult;
            //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameSettings, Request, "");
        }

        public New_Report_MasterProperty GetReportMasterProperty_ForTemplate(int pIntReportCode, string pStrReportGroup = null)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_GROUP_NAME_", pStrReportGroup, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "New_Report_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_MasterProperty New_Report_MasterProperty = new New_Report_MasterProperty();
            New_Report_MasterProperty.Report_code = Val.ToInt(DRow["REPORT_CODE"]);
            New_Report_MasterProperty.Report_Name = Val.ToString(DRow["REPORT_NAME"]);
            New_Report_MasterProperty.Report_Group_Name = Val.ToString(DRow["REPORT_GROUP_NAME"]);
            New_Report_MasterProperty.Form_Name = Val.ToString(DRow["FORM_NAME"]);
            New_Report_MasterProperty.Sequence_No = Val.ToInt(DRow["SEQUENCE_NO"]);
            New_Report_MasterProperty.Active = Val.ToInt(DRow["ACTIVE"]);
            New_Report_MasterProperty.Remark = Val.ToString(DRow["REMARK"]);


            DRow = null;
            return New_Report_MasterProperty;

        }

        // End : Narendra : 03-12-2014 


        public int Delete(int pIntReportCode)
        {
            Request Request = new Request();

            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "New_Report_Master_Delete";
            
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int DeleteSettings(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIELD_NO_", pClsProperty.Field_No, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "New_Report_Settings_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int DeleteDetail(New_Report_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pClsProperty.Report_code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "New_Report_Detail_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        /// <summary>
        /// This Mehtod To Get Import Details
        /// </summary>
        /// 
        
      
        
        public New_Report_MasterProperty GetReportMasterProperty(int pIntReportCode,string pStrReportGroup = null)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_GROUP_NAME_", pStrReportGroup, DbType.String, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", 0, DbType.String, ParameterDirection.Input); // ADD : NAREDNRA : 09-JAN-2015

            Request.CommandText = "New_Report_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_MasterProperty New_Report_MasterProperty = new New_Report_MasterProperty();
            New_Report_MasterProperty.Report_code = Val.ToInt(DRow["REPORT_CODE"]);
            New_Report_MasterProperty.Report_Name = Val.ToString(DRow["REPORT_NAME"]);
            New_Report_MasterProperty.Report_Group_Name = Val.ToString(DRow["REPORT_GROUP_NAME"]);
            New_Report_MasterProperty.Form_Name = Val.ToString(DRow["FORM_NAME"]);
            New_Report_MasterProperty.Sequence_No = Val.ToInt(DRow["SEQUENCE_NO"]);
            New_Report_MasterProperty.Active = Val.ToInt(DRow["ACTIVE"]);
            New_Report_MasterProperty.Remark = Val.ToString(DRow["REMARK"]);
            New_Report_MasterProperty.Disp_In = Val.ToString(DRow["DISP_IN"]);
            
            
            DRow = null;
            return New_Report_MasterProperty;

        }

        public New_Report_DetailProperty GetReportDetailProperty(int pIntReportCode, string pStrReportType)
        {
            Request Request = new Request();
            Request.AddParams("REPORT_CODE_", pIntReportCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REPORT_TYPE_", pStrReportType, DbType.String, ParameterDirection.Input);
            Request.CommandText = "New_Report_Detail_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_DetailProperty New_Report_DetailProperty = new New_Report_DetailProperty();
            New_Report_DetailProperty.Report_code = Val.ToInt(DRow["REPORT_CODE"]);
            New_Report_DetailProperty.Report_Type = Val.ToString(DRow["REPORT_TYPE"]);                                                                          
            New_Report_DetailProperty.Procedure_Name = Val.ToString(DRow["PROCEDURE_NAME"]);                                                                              
            New_Report_DetailProperty.Report_Header_Name = Val.ToString(DRow["REPORT_HEADER_NAME"]);
            New_Report_DetailProperty.Rpt_Name = Val.ToString(DRow["RPT_NAME"]);
            New_Report_DetailProperty.Default_Order_By = Val.ToString(DRow["DEFAULT_ORDER_BY"]);
            New_Report_DetailProperty.Default_Group_By = Val.ToString(DRow["DEFAULT_GROUP_BY"]);
            New_Report_DetailProperty.Active = Val.ToInt(DRow["ACTIVE"]);
            New_Report_DetailProperty.Remark = Val.ToString(DRow["REMARK"]);
            New_Report_DetailProperty.Is_Pivot = Val.ToInt(DRow["IS_PIVOT"]);
            
            New_Report_DetailProperty.Font_Name = Val.ToString(DRow["FONT_NAME"]);
            New_Report_DetailProperty.Font_Size = Val.Val(DRow["FONT_SIZE"]);
            New_Report_DetailProperty.Page_Orientation = Val.ToString(DRow["PAGE_ORIENTATION"]);
            New_Report_DetailProperty.Autofit = Val.Val(DRow["AUTOFIT"]);
            New_Report_DetailProperty.Page_Kind = Val.ToString(DRow["PAGE_KIND"]);

            DRow = null;
            return New_Report_DetailProperty;
        }


        public int SaveReportTrace(int YYMM, int SRNO, int Report_Code, string ReportType) // Khushbu 07/04/2014
        {
            Request Request = new Request();
            Request.AddParams("YY_MM_", YYMM, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SRNO_", SRNO, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_NAME_", GlobalDec.gEmployeeProperty.User_Name, DbType.String, ParameterDirection.Input);

            Request.AddParams("REPORT_CODE_",Report_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", DateTime.Today.Date.ToString("dd/MMM/yyyy"), DbType.String, ParameterDirection.Input);

            Request.AddParams("REPORT_TYPE_", ReportType, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPUTER_IP_",GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

            Request.CommandText = "New_Report_Trace_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public string GetReportCode(string pStrRemark)
        {
            return Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "New_Report_Master", "REPORT_CODE", " And REMARK = '" + pStrRemark + "' ");
        }

        public string GetFormName(string pStrRemark)
        {
            return Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName,"New_Report_Master", "FORM_NAME", " And REMARK = '" + pStrRemark + "' ");
        }

        #endregion]

    }
}
