using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DLL;
using System.Security.Cryptography;
using System.Net;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;
using System.Reflection;

namespace BLL
{
    public enum ReturnTypeMode
    {
        DataTable = 0,
        DataRow = 1,
        String = 2
    }

    public class DBConnections
    {

        private static string _ConnectionString;

        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private static string _ProviderName;

        public static string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }

        private static string _ConnectionDeveloper;

        public static string ConnectionDeveloper
        {
            get { return _ConnectionDeveloper; }
            set { _ConnectionDeveloper = value; }
        }

        private static string _ConnectionStringWeb;

        public static string ConnectionStringWeb
        {
            get { return _ConnectionStringWeb; }
            set { _ConnectionStringWeb = value; }
        }

        private static string _ProviderDeveloper;

        public static string ProviderDeveloper
        {
            get { return _ProviderDeveloper; }
            set { _ProviderDeveloper = value; }
        }

        private static string _ProviderNameWeb;

        public static string ProviderNameWeb
        {
            get { return _ProviderNameWeb; }
            set { _ProviderNameWeb = value; }
        }


        public enum LOCKTYPE
        {
            LOGIN_USER = 1,
            PARCEL_SYSTEM = 2,
            PARCEL_MANUAL = 3,
            ROUGH_SYSTEM = 4
        }

        public static string SecurityKey
        {
            get { return "MARGO"; }
        }



        private static string _gStrDBName;

        public static string gStrDBName
        {
            get { return _gStrDBName; }
            set { _gStrDBName = value; }
        }

        private static string _gStrDBDataSource;

        public static string gStrDBDataSource
        {
            get { return _gStrDBDataSource; }
            set { _gStrDBDataSource = value; }
        }


        private static string _gStrUserName;

        public static string gStrUserName
        {
            get { return _gStrUserName; }
            set { _gStrUserName = value; }
        }

        private static string _gStrPasssword;

        public static string gStrPasssword
        {
            get { return _gStrPasssword; }
            set { _gStrPasssword = value; }
        }

        public static string MailPagesURL
        {
            get
            {
                //return "Data Source=GKC;User ID=DNK;Password=dnk123;"; 
                return System.Configuration.ConfigurationManager.AppSettings["MailPagesURL"].ToString();
            }
        }
    }

    public class GlobalDec
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        
        public static System.Drawing.Color ABColor = System.Drawing.Color.Red;

        public enum SERVERTYPE
        {
            A = 0,
            B = 1
        }
        public enum LEDGEROPENING
        {
            OPENING = 0,
            CLOSING = 1
        }

        private static string _gStrUserName;

        public static string gStrUserName
        {
            get { return _gStrUserName; }
            set { _gStrUserName = value; }
        }

        public static string gStrComputerIP
        {
            get
            {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();

                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                foreach (IPAddress a in localIPs)
                {
                    if (a.AddressFamily == AddressFamily.InterNetwork)
                    {
                        strHostName = a.ToString();
                    }
                }
                if (localIPs.Length == 0)
                {
                    return System.Environment.MachineName.ToString();
                }
                else
                {
                    return strHostName;
                }
            }
        }

        private static PropertyClasses.Master.User_MasterProperty _gEmployeeProperty = new PropertyClasses.Master.User_MasterProperty();

        public static PropertyClasses.Master.User_MasterProperty gEmployeeProperty
        {
            get { return _gEmployeeProperty; }
            set { _gEmployeeProperty = value; }
        }

        public static string WebServiceDownloadUrl
        {
            get
            {
                //return "http://192.168.1.55:8081/FileUpload/Storage/";
                return System.Configuration.ConfigurationManager.AppSettings["DownloadURL"].ToString();
            }
        }

        private static string _gFinancialYear;

        public static string gFinancialYear
        {
            get { return _gFinancialYear; }
            set { _gFinancialYear = value; }
        }

        private static string _gFinancialYear_StartDate;

        public static string gFinancialYear_StartDate
        {
            get { return _gFinancialYear_StartDate; }
            set { _gFinancialYear_StartDate = value; }
        }
        private static string _gFinancialYear_EndDate;

        public static string gFinancialYear_EndDate
        {
            get { return _gFinancialYear_EndDate; }
            set { _gFinancialYear_EndDate = value; }
        }

        public static string gStrMsgTitle
        {
            get { return "STORE"; }
        }

        public static string gStrPermissionViwMsg
        {
            get { return "You are not authorized to do View operation"; }
        }

        public static string gStrPermissionInsUpdMsg
        {
            get { return "You are not authorized to do Save (Insert-Update) operation"; }
        }

        public static string gStrPermissionDelMsg
        {
            get { return "You are not authorized to do Delete operation"; }
        }

        public static string gStrPermissionPrintMsg
        {
            get { return "You are not authorized to do Print operation"; }
        }

        public static string gStrPermissionEMailMsg
        {
            get { return "You are not authorized to do EMail operation"; }
        }

        public static string gStrPermissionExpMsg
        {
            get { return "You are not authorized to do Export operation"; }
        }

        public static string gStrServerDate
        {
            get
            {
                InterfaceLayer Ope = new InterfaceLayer();

                DataRow DRow = Ope.GetDataRow(DBConnections.ConnectionString, DBConnections.ProviderName, "Dual", "SysDate", "");
                string StrDate = "";
                if (DRow != null)
                {
                    StrDate = DRow[0].ToString();
                }

                Ope = null;
                DRow = null;
                return StrDate;
            }
        }

        public static string gStrServerDate2Days
        {
            get
            {
                InterfaceLayer Ope = new InterfaceLayer();

                DataRow DRow = Ope.GetDataRow(DBConnections.ConnectionString, DBConnections.ProviderName, "Dual", "SysDate -2", "");
                string StrDate = "";
                if (DRow != null)
                {
                    StrDate = DRow[0].ToString();
                }

                Ope = null;
                DRow = null;
                return StrDate;
            }
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            if (cipherString == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = DBConnections.SecurityKey;

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return (UTF8Encoding.UTF8.GetString(resultArray));
        }
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            if (toEncrypt == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            // Dim toEncryptArray As Byte() = UTF32Encoding.UTF32.GetBytes(toEncrypt)

            string key = DBConnections.SecurityKey;
            //key = "AdeF5ty6Fr456Mw###"
            //System.Windows.Forms.MessageBox.Show(key)
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                //keyArray = UTF32Encoding.UTF32.GetBytes(key)
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return (Convert.ToBase64String(resultArray, 0, resultArray.Length));
        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }
}
