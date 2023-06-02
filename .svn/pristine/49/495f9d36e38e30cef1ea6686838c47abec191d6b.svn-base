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
   public class BM_ReportParams
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();


        public DataTable Get_Realization_Summary_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_ROUGH_CODE_", pClsProperty.Sub_Rough_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_RATE_DATE_", pClsProperty.ROUGH_RATE_DATE, DbType.String, ParameterDirection.Input);

            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("REF_NO_", pClsProperty.Ref_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOT_NO_", pClsProperty.Lot_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_Realization_Kapan_InterMixing_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            
            Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("FROM_ROUGH_", pClsProperty.From_Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_ROUGH_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_TEAM_", pClsProperty.From_Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_TEAM_", pClsProperty.To_Team_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_GROUP_", pClsProperty.From_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_GROUP_", pClsProperty.To_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOT_NO_", pClsProperty.Lot_No, DbType.String, ParameterDirection.Input);
            
            Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("OPERATION_", pClsProperty.Operation, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }
     
    }
}
