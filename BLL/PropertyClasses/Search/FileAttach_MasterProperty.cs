using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Search
{
    public class FileAttach_MasterProperty
    {

        private int _SrNo;

        public int SrNo
        {
            get { return _SrNo; }
            set { _SrNo = value; }
        }


        private int _Employee_Code;

        public int Employee_Code
        {
            get { return _Employee_Code; }
            set { _Employee_Code = value; }
        }


        private string _Other_Code;

        public string Other_Code
        {
            get { return _Other_Code; }
            set { _Other_Code = value; }
        }

        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private int _Invoice_No;

        public int Invoice_No
        {
            get { return _Invoice_No; }
            set { _Invoice_No = value; }
        }


        private string _Form_Name;

        public string Form_Name
        {
            get { return _Form_Name; }
            set { _Form_Name = value; }
        }


        private int _Form_Code;

        public int Form_Code
        {
            get { return _Form_Code; }
            set { _Form_Code = value; }
        }


        private string _Original_File_Name;

        public string Original_File_Name
        {
            get { return _Original_File_Name; }
            set { _Original_File_Name = value; }
        }


        private string _Uploaded_FileName;

        public string Uploaded_FileName
        {
            get { return _Uploaded_FileName; }
            set { _Uploaded_FileName = value; }
        }


        private int _Upload_By_UserName;

        public int Upload_By_UserName
        {
            get { return _Upload_By_UserName; }
            set { _Upload_By_UserName = value; }
        }


        private string _Upload_Date;

        public string Upload_Date
        {
            get { return _Upload_Date; }
            set { _Upload_Date = value; }
        }


        private string _Upload_Time;

        public string Upload_Time
        {
            get { return _Upload_Time; }
            set { _Upload_Time = value; }
        }

        private string _Computer_IP;

        public string Computer_IP
        {
            get { return _Computer_IP; }
            set { _Computer_IP = value; }
        }


        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }


    }
}
