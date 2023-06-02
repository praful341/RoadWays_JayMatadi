using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Utility;
using RoadWays.Class;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmLogin : Form
    {
        Validation Val = new Validation();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //string Name = GlobalDec.Decrypt("sQqoq9CMHiOI1ErUtb8jHw==", true);
            //string Name1 = GlobalDec.Decrypt("/l79/vEFU54=", true);
            //string Name1 = GlobalDec.Encrypt("Data Source=SQL5092.site4now.net;Initial Catalog=DB_A4B382_LeoAccount;User Id=DB_A4B382_LeoAccount_admin;Password=admin@123", true);
            //string Name1 = GlobalDec.Encrypt("DERP_MFG_B", true);
            //string Name2 = GlobalDec.Encrypt("DERP_MFG_Restore", true);         

            //Global.gStrStrHostName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerHostName"].ToString(), true);
            //Global.gStrStrServiceName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerServiceName"].ToString(), true);
            //Global.gStrStrUserName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerUserName"].ToString(), true);
            //Global.gStrStrPasssword = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerPassWord"].ToString(), true);

            //BLL.DBConnections.ConnectionString = "Data Source=" + Global.gStrStrHostName + ";Initial Catalog=" + Global.gStrStrServiceName + ";User ID=" + Global.gStrStrUserName + ";Password=" + Global.gStrStrPasssword + ";";
            //BLL.DBConnections.ProviderName = "System.Data.SqlClient";

            string appPath = Application.StartupPath.ToString();
            //ClassINI iniCl = new ClassINI(appPath + "\\JayMatadi.CONFIG");
            ClassINI iniCl = new ClassINI(appPath + "\\ShreeNathji.CONFIG");
            if (!File.Exists(appPath + "\\ShreeNathji.CONFIG"))
            //if (!File.Exists(appPath + "\\JayMatadi.CONFIG"))

            {
                //iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt(".", true));
                //iniCl.IniWriteValue("LOGIN", "DBName", GlobalDec.Encrypt("STORE", true));
                //iniCl.IniWriteValue("LOGIN", "ServerUserName", GlobalDec.Encrypt("Praful\\Praful-it", true));
                //iniCl.IniWriteValue("LOGIN", "ServerPassWord", GlobalDec.Encrypt("", true));
                //iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt("MADHURAM-PC", true));
                iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt("192.168.1.11", true));
                iniCl.IniWriteValue("LOGIN", "DBName", GlobalDec.Encrypt("Store", true));
                iniCl.IniWriteValue("LOGIN", "ServerUserName", GlobalDec.Encrypt("sa", true));
                iniCl.IniWriteValue("LOGIN", "ServerPassWord", GlobalDec.Encrypt("admin@123", true));
            }

            ////string gStrHostName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerHostName"), true);
            ////string gStrDBName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "DBName"), true);
            ////string gStrUserName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerUserName"), true);
            ////string gStrPasssword = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerPassWord"), true);
            //Global.gStrStrHostName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerHostName"].ToString(), true);
            //Global.gStrStrServiceName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerServiceName"].ToString(), true);
            //Global.gStrStrUserName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerUserName"].ToString(), true);
            //Global.gStrStrPasssword = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerPassWord"].ToString(), true);

            Global.gStrStrHostName = iniCl.IniReadValue("LOGIN", "ServerHostName");
            Global.gStrStrServiceName = iniCl.IniReadValue("LOGIN", "DBName");
            Global.gStrStrUserName = iniCl.IniReadValue("LOGIN", "ServerUserName");
            Global.gStrStrPasssword = iniCl.IniReadValue("LOGIN", "ServerPassWord");

            BLL.DBConnections.ConnectionString = "Data Source=" + Global.gStrStrHostName + ";Initial Catalog=" + Global.gStrStrServiceName + ";User ID=" + Global.gStrStrUserName + ";Password=" + Global.gStrStrPasssword + ";";

            BLL.DBConnections.ProviderName = "System.Data.SqlClient";

            txtUserName.Text = "PRAFUL";
            txtPassword.Text = "123";
            btnLogin_Click(null, null);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                Global.Confirm("Please Enter UserName");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                Global.Confirm("Please Enter Password");
                txtPassword.Focus();
                return;
            }

            //if (txtUserName.Text == GlobalDec.gEmployeeProperty.UserName)
            //{
            //    MARGO.Class.Global.Message("Your are already Loged In");
            //    txtUserName.Focus();
            //    return;
            //}

            this.Cursor = Cursors.WaitCursor;

            Login objLogin = new Login();
            int IntRes = objLogin.CheckLogin(txtUserName.Text, GlobalDec.Encrypt(txtPassword.Text, true));

            this.Cursor = Cursors.Default;
            if (IntRes == -1)
            {
                Global.Confirm("Enter Valid UserName And Password");
                txtUserName.Focus();
                //panelControl1.Enabled = false;
                return;
            }
            else
            {
                FinancialYearMaster ObjFinancial = new FinancialYearMaster();
                DataTable tdt = ObjFinancial.GetData();
                GlobalDec.gEmployeeProperty.gFinancialYear = Val.ToString(tdt.Rows[0]["FINANCIAL_YEAR"]);
                GlobalDec.gEmployeeProperty.gFinancialYear_Code = Val.ToInt64(tdt.Rows[0]["FIN_YEAR_CODE"]);

                this.Close();
                //txtUserName.Text = "";
                //txtPassword.Text = "";
                //panelControl1.Enabled = true;
                //FrmLogin Log = new FrmLogin();
                //Log.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
