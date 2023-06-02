using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RoadWays.Class;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace RoadWays.Report
{
    public partial class FrmReportViewer : Form
    {
        Validation Val = new Validation();
        private DataSet _DS = new DataSet();

        PrinterSettings printerSettings = new PrinterSettings();
        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }


        public string mStrRefreshFormType = "";

        public enum ReportFolder
        {

            NONE = 0,
            JANGED = 1,
            EMP = 2,
            PURCHASE_ROUGH = 3,
            MIX = 4,
            HRACTS = 5,
            HR_REPORT = 6,
            ACCOUNT = 7
        }

        public string RepHead = string.Empty;
        public string RepName = string.Empty;
        public string PROCESS = string.Empty;
        public string RepPara = string.Empty;
        public string RepType = string.Empty;

        public string AddressType = string.Empty;

        public string GroupBy = string.Empty;
        public string FromDate = string.Empty;
        public string ToDate = string.Empty;

        public string Address = string.Empty;
        public string PhoneNo = string.Empty;

        public double DollarRate = 0.000;
        public double ProcessCost = 0.000;
        public double OverHead = 0.000;

        // Add : Narendra ; 14-Aug-2015
        public bool IsPrintDate = false;
        // End : Narendra ; 14-Aug-2015

        /// <summary>
        /// Property For Set Dynamic Grouping Formulas
        /// </summary>
        public bool AllowSetFormula = false;


        public FrmReportViewer()
        {
            InitializeComponent();
        }

        public void ShowForm(string pStrRPTName, DataTable pDTab, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Add : Narendra : 06-Apr-2016
                if (pStrRPTName == "Acc_Confirmation")
                    CryViewer.EnableDrillDown = false;
                // End : Narendra : 06-Apr-2016

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);
                // SetFormula(); 
                RepDoc.SetDataSource(pDTab);

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //crConnectionInfo.ServerName = BLL.DBConnections.gStrDBDataSource;
                //crConnectionInfo.DatabaseName = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.UserID = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.Password = BLL.DBConnections.gStrDBPassWord;

                //CrTables = RepDoc.Database.Tables;
                //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                //{
                //        crtableLogoninfo = CrTable.LogOnInfo;
                //        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                //        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                //}

                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.Refresh(); 

                CryViewer.ReportSource = RepDoc;

                //ADD BY HARESH ON 01-08-2016
                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //END AS

                CryViewer.Refresh();

                CryViewer.Zoom(pIntZoom);

                // RepDoc.SetDatabaseLogon(BLL.DBConnections.gStrDBName, BLL.DBConnections.gStrDBPassWord);

                SetParaMeter();
                this.Cursor = Cursors.Default;

                this.Show();

            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }

        public void ShowForm(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                //SetFormula(); 
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                        RepDoc.SetDataSource(DS.Tables[0]);
                }


                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //crConnectionInfo.ServerName = BLL.DBConnections.gStrDBDataSource;
                //crConnectionInfo.DatabaseName = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.UserID = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.Password = BLL.DBConnections.gStrDBPassWord;

                //CrTables = RepDoc.Database.Tables;
                //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                //{
                //    crtableLogoninfo = CrTable.LogOnInfo;
                //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                //}

                for (int IntI = 0; IntI < RepDoc.Subreports.Count; IntI++)
                {
                    RepDoc.Subreports[IntI].SetDataSource(DS.Tables[IntI + 1]);
                }

                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.Refresh(); 

                CryViewer.ReportSource = RepDoc;

                //ADD BY HARESH ON 01-08-2016
                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //END AS

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                //RepDoc.SetDatabaseLogon(BLL.DBConnections.gStrDBName, BLL.DBConnections.gStrDBPassWord);

                SetParaMeter();
                this.Cursor = Cursors.Default;

                PrinterSettings getprinterName = new PrinterSettings();
                RepDoc.PrintOptions.PrinterName = getprinterName.PrinterName;
                //Global.Message(getprinterName.PrinterName);
                //RepDoc.PrintToPrinter(1, true, 1, 1);
                RepDoc.PrintToPrinter(2, false, printerSettings.FromPage, printerSettings.ToPage);

                //this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }

        public void ShowForm_SubReport(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                if (pStrRPTName == "Bill_Detail_Duplicate_JayMataji")
                {
                    RepDoc.Subreports["Bill_Detail_JayMataji.rpt"].SetDataSource(DS.Tables[0]);
                    RepDoc.Subreports["Bill_Detail_JayMataji1.rpt"].SetDataSource(DS.Tables[0]);
                }
                else
                {
                    //SetFormula(); 
                    if (DS != null)
                    {
                        if (DS.Tables.Count > 0)
                        {
                            RepDoc.Subreports[0].SetDataSource(DS.Tables[0]);
                            RepDoc.Subreports[1].SetDataSource(DS.Tables[0]);
                        }
                    }
                }


                //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                //ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //string appPath = Application.StartupPath.ToString();
                //ClassINI iniCl = new ClassINI(appPath + "\\RoadWays.CONFIG");
                //RepDoc.SetDatabaseLogon(iniCl.IniReadValue("LOGIN", "ServerUserName"), iniCl.IniReadValue("LOGIN", "ServerPassWord"));
                //CryViewer.ReportSource = RepDoc;

                ////ADD BY HARESH ON 01-08-2016
                //CryViewer.ShowParameterPanelButton = false;
                //CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                ////END AS

                //CryViewer.Refresh();
                //CryViewer.Zoom(pIntZoom);

                ////RepDoc.SetDatabaseLogon(BLL.DBConnections.gStrDBName, BLL.DBConnections.gStrDBPassWord);

                //SetParaMeter();
                //this.Cursor = Cursors.Default;

                //this.Show();

                RepDoc.SetDatabaseLogon(Global.gStrStrUserName, Global.gStrStrPasssword);
                CryViewer.ReportSource = RepDoc;

                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                this.Cursor = Cursors.Default;

                PrinterSettings getprinterName = new PrinterSettings();
                RepDoc.PrintOptions.PrinterName = getprinterName.PrinterName;
                RepDoc.PrintToPrinter(2, false, printerSettings.FromPage, printerSettings.ToPage);

                //this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }
        public void ShowForm_SubReport_NEW(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                if (pStrRPTName == "Bill_Detail_Duplicate_JayMataji")
                {
                    RepDoc.Subreports["Bill_Detail_JayMataji.rpt"].SetDataSource(DS.Tables[0]);
                    RepDoc.Subreports["Bill_Detail_JayMataji1.rpt"].SetDataSource(DS.Tables[0]);
                }
                else
                {
                    //SetFormula(); 
                    if (DS != null)
                    {
                        if (DS.Tables.Count > 0)
                        {
                            RepDoc.Subreports[0].SetDataSource(DS.Tables[0]);
                            RepDoc.Subreports[1].SetDataSource(DS.Tables[0]);
                        }
                    }
                }


                //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                //ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //string appPath = Application.StartupPath.ToString();
                //ClassINI iniCl = new ClassINI(appPath + "\\RoadWays.CONFIG");
                //RepDoc.SetDatabaseLogon(iniCl.IniReadValue("LOGIN", "ServerUserName"), iniCl.IniReadValue("LOGIN", "ServerPassWord"));
                //CryViewer.ReportSource = RepDoc;

                ////ADD BY HARESH ON 01-08-2016
                //CryViewer.ShowParameterPanelButton = false;
                //CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                ////END AS

                //CryViewer.Refresh();
                //CryViewer.Zoom(pIntZoom);

                ////RepDoc.SetDatabaseLogon(BLL.DBConnections.gStrDBName, BLL.DBConnections.gStrDBPassWord);

                //SetParaMeter();
                //this.Cursor = Cursors.Default;

                //this.Show();

                RepDoc.SetDatabaseLogon(Global.gStrStrUserName, Global.gStrStrPasssword);
                CryViewer.ReportSource = RepDoc;

                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                this.Cursor = Cursors.Default;

                //PrinterSettings getprinterName = new PrinterSettings();
                //RepDoc.PrintOptions.PrinterName = getprinterName.PrinterName;
                //RepDoc.PrintToPrinter(printerSettings.Copies, false, printerSettings.FromPage, printerSettings.ToPage);

                this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }

        public void ShowForm_New(string pStrRPTName, int pIntZoom = 120, ReportFolder pEnumReportFolder = ReportFolder.NONE, string[,] Formulas = null)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string StrPath = Application.StartupPath + "\\RPT\\";

                StrPath = StrPath + pEnumReportFolder.ToString() + "\\";

                StrPath = StrPath + pStrRPTName + ".rpt";

                RepDoc.Load(StrPath);

                //SetFormula(); 
                if (DS != null)
                {
                    RepDoc.SetDataSource(DS.Tables[0]);
                }


                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //crConnectionInfo.ServerName = BLL.DBConnections.gStrDBDataSource;
                //crConnectionInfo.DatabaseName = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.UserID = BLL.DBConnections.gStrDBName;
                //crConnectionInfo.Password = BLL.DBConnections.gStrDBPassWord;

                //CrTables = RepDoc.Database.Tables;
                //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                //{
                //    crtableLogoninfo = CrTable.LogOnInfo;
                //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                //}

                if (Formulas != null)
                {
                    for (int x = 0; x < Formulas.GetLength(0); x++)
                    {
                        RepDoc.DataDefinition.FormulaFields[Formulas[x, 0].ToString()].Text = " '" + Formulas[x, 1].ToString() + "'";
                        // MessageBox.Show(Formulas[0][0].ToString());
                        //MessageBox.Show(Formulas[x][0].ToString());
                    }

                }
                for (int IntI = 0; IntI < RepDoc.Subreports.Count; IntI++)
                {
                    RepDoc.Subreports[IntI].SetDataSource(DS.Tables[IntI]);
                }

                //crystalReportViewer1.ReportSource = cryRpt;
                //crystalReportViewer1.Refresh(); 

                CryViewer.ReportSource = RepDoc;
                //ADD BY HARESH ON 01-08-2016
                CryViewer.ShowParameterPanelButton = false;
                CryViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //END AS

                CryViewer.Refresh();
                CryViewer.Zoom(pIntZoom);

                //RepDoc.SetDatabaseLogon(BLL.DBConnections.gStrDBName, BLL.DBConnections.gStrDBPassWord);

                SetParaMeter();
                this.Cursor = Cursors.Default;

                this.Show();
            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm(Ex.ToString());
            }
        }
        private void SetFormula()
        {
            if (AllowSetFormula == false)
            {
                return;
            }
            FormulaFieldDefinitions FormulaFieldDefs;
            FormulaFieldDefs = RepDoc.DataDefinition.FormulaFields;

            int IntFormula = 0;

            string[] splitStr = GroupBy.Split(',');

            foreach (string Str in splitStr)
            {
                if (Str != "")
                {
                    IntFormula++;
                    FormulaFieldDefs["Grp" + IntFormula.ToString()].Text = "{MIX_MACHINE_WORKDOWN." + Str + "}";
                    FormulaFieldDefs["Str" + IntFormula.ToString()].Text = "{MIX_MACHINE_WORKDOWN." + Str + "}";
                }
            }

            IntFormula = 0;
            for (int IntI = 0; IntI < splitStr.Length; IntI++)
            {
                IntFormula++;
                FormulaFieldDefs["showGroup" + IntFormula.ToString()].Text = "0";
            }

            for (int IntI = splitStr.Length; IntI > 1; IntI--)
            {
                FormulaFieldDefs["showGroup" + IntI.ToString()].Text = "1";
            }

            IntFormula = 0;
            foreach (string Str in splitStr)
            {
                if (Str != "")
                {
                    IntFormula++;

                }
            }
        }

        private void SetParaMeter()
        {
            RepDoc.DataDefinition.ParameterFields.Reset();
            ParameterFieldDefinitions ParamFieldDefs;
            ParameterValues ParamValues = new ParameterValues();
            ParameterDiscreteValue ParamDisValue;




            ParamFieldDefs = RepDoc.DataDefinition.ParameterFields;


            ParamDisValue = new ParameterDiscreteValue();

            foreach (ParameterFieldDefinition ParamFieldDef in ParamFieldDefs)
            {
                switch (ParamFieldDef.ParameterFieldName.ToUpper())
                {

                    case "REPHEAD":
                        if (Val.Val(RepHead.Length) != 0)
                        {
                            ParamDisValue.Value = RepHead;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPNAME":
                        if (Val.Val(RepName.Length) != 0)
                        {
                            ParamDisValue.Value = RepName;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPPARA":
                        if (Val.Val(RepPara.Length) != 0)
                        {
                            ParamDisValue.Value = RepPara;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "FROMDATE":
                        if (Val.Val(FromDate.Length) != 0)
                        {
                            ParamDisValue.Value = FromDate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "TODATE":
                        if (Val.Val(ToDate.Length) != 0)
                        {
                            ParamDisValue.Value = ToDate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "PROCESS":
                        if (Val.Val(ToDate.Length) != 0)
                        {
                            ParamDisValue.Value = PROCESS;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "DOLLARRATE":
                        if (Val.Val(DollarRate) != 0)
                        {
                            ParamDisValue.Value = DollarRate;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "PROCESSCOST":
                        if (Val.Val(ProcessCost) != 0)
                        {
                            ParamDisValue.Value = ProcessCost;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "OVERHEAD":
                        if (Val.Val(OverHead) != 0)
                        {
                            ParamDisValue.Value = OverHead;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "COMPANYNAME":
                        if (Val.Val(CompanyName.Length) != 0)
                        {
                            ParamDisValue.Value = CompanyName;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "ADDRESS":
                        if (Val.Val(Address.Length) != 0)
                        {
                            ParamDisValue.Value = Address;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "PHONENO":
                        if (Val.Val(PhoneNo.Length) != 0)
                        {
                            ParamDisValue.Value = PhoneNo;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;
                    case "REPTYPE":
                        if (Val.Val(RepType.Length) != 0)
                        {
                            ParamDisValue.Value = RepType;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;

                    case "ADDRESSTYPE":
                        if (Val.Val(AddressType.Length) != 0)
                        {
                            ParamDisValue.Value = AddressType;
                        }
                        else
                        {
                            ParamDisValue.Value = "  ";
                        }
                        break;

                    // Add : Narendra : 14-Aug-2015
                    case "ISPRINTDATE":
                        ParamDisValue.Value = IsPrintDate;

                        break;
                        // End : Narendra : 14-Aug-2015
                }
                if (Val.Left(ParamFieldDef.ParameterFieldName.ToUpper(), 1) != "@")
                {
                    ParamValues.Add(ParamDisValue);
                    ParamFieldDef.ApplyCurrentValues(ParamValues);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //PrintPreviewDialog printpreview = new PrintPreviewDialog();
            //printpreview.Document = RepDoc;
            //printpreview.ShowDialog(); 

            //CryViewer.PrintReport();
            //RepDoc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            // RepDoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            // RepDoc.PrintToPrinter(1, false, 0, 0);

            //PrinterSettings getprinterName = new PrinterSettings();
            //RepDoc.PrintOptions.PrinterName = getprinterName.PrinterName;
            //RepDoc.PrintToPrinter(1, true, 1, 1);
        }

        private void FrmReportViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrinterSettings = printerSettings;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;
            printDialog.AllowSelection = true;
            printDialog.AllowCurrentPage = true;
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }
            RepDoc.PrintOptions.PrinterName = printerSettings.PrinterName;
            //RepDoc.PrintToPrinter(printerSettings.Copies, false, printerSettings.FromPage, printerSettings.ToPage);
            //this.report.PrintOptions.PrinterName = printerSettings.PrinterName;
            //this.report.PrintToPrinter(printerSettings.Copies, false, 0, 0);
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            if (mStrRefreshFormType != "")
            {
                BtnRefresh.Visible = true;
            }
            else
            {
                BtnRefresh.Visible = false;
            }

            CryViewer.Refresh();


            //BtnPrint_Click(null, null);
            //this.Close();
        }
    }
}
