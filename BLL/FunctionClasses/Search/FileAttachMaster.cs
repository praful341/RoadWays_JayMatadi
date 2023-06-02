using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLL;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Search;
namespace BLL.FunctionClasses.Search
{
    public class FileAttachMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Property Settings

        private DataTable _DTab = new DataTable("FileAttach_Master");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        #endregion

        #region Other Function

        public int FindNewID(string pStrType, int pIntCode)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "FileAttach_Master", "MAX(SRNO)",
                                                            " AND TYPE = '" + pStrType + "' AND CODE = " + pIntCode);
        }

        public int Save(FileAttach_MasterProperty  pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);	     
            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);	             
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);	     
            
            Request.AddParams("FORM_CODE_", pClsProperty.Form_Code, DbType.Int32, ParameterDirection.Input);            
            Request.AddParams("ORIGINAL_FILENAME_", pClsProperty.Original_File_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("UPLOADED_FILENAME_", pClsProperty.Uploaded_FileName, DbType.String, ParameterDirection.Input);
            Request.AddParams("UPLOAD_BY_", GlobalDec.gEmployeeProperty.User_Code, DbType.Int32, ParameterDirection.Input);	 
            Request.AddParams("UPLOAD_DATE_", pClsProperty.Upload_Date, DbType.Date, ParameterDirection.Input);	     
            Request.AddParams("UPLOAD_TIME_", pClsProperty.Upload_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "FileAttach_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        public int Delete(FileAttach_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("TYPE_", pClsProperty.Type, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);         
            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "FileAttach_Master_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public void GetData(FileAttach_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("INVOICE_NO_", pClsProperty.Invoice_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("OTHER_CODE_", pClsProperty.Other_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FORM_NAME_", pClsProperty.Form_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("FORM_CODE_", pClsProperty.Form_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "FileAttach_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        }

        public int GetAttachmentCount(int pIntEmpCode = 0,int pIntInvoiceNo = 0 ,string pStrFormName = "",int pIntFormCode = 0,string pStrOtherCode= null)
        {
            FileAttach_MasterProperty FileAttach_MasterProperty = new PropertyClasses.Search.FileAttach_MasterProperty();
            FileAttach_MasterProperty.Employee_Code = pIntEmpCode;
            FileAttach_MasterProperty.Invoice_No = pIntInvoiceNo;
            FileAttach_MasterProperty.Form_Name = pStrFormName;
            FileAttach_MasterProperty.Form_Code = pIntFormCode;
            FileAttach_MasterProperty.Other_Code = pStrOtherCode;
            int IntRes = GetAttachmentCount(FileAttach_MasterProperty);
            FileAttach_MasterProperty = null;
            return IntRes;
        }

        public int GetAttachmentCount(FileAttach_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FORM_CODE_", pClsProperty.Form_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "FileAttach_Master_GetCount";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = Val.ToInt(Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request));
            return IntRes;
        }
        
        public string FindFormCode(string pStrFormName) // Add By Khushbu 04/11/2014
        {
            return Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Form_Master", "FORM_CODE", " And FORM_NAME = '" + pStrFormName + "'");
        }

        #endregion
    }
}
