using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Report;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Global = RoadWays.Class.Global;

namespace RoadWays.Report
{
    public partial class FrmGReportViewerBand : Form
    {
        Dictionary<int, double> dic = new Dictionary<int, double>();

        DataTable DTabDiscount = new DataTable();

        public New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        //NewReportMaster ObjReport = new NewReportMaster();


        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();
        
        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;
        Boolean ISFilter = false;
        public Boolean IsPivot = false;

        public int ReceiptDays = 0;

        double DouAnswer = 0;
        double DouQuantity =0;
        double DouAttendance = 0;
        double DouWorkingDays = 0;
        int IntIssuePcs = 0;
        public double DouExpDiff = 0;

        double DouStandardCarat = 0;
        
        double DouCarat = 0;
        double DouAmountDollar = 0;
        double DouAmountLocal = 0;
        double DouAmountPurchase = 0;

        double DouFromCarat = 0;
        double DouFromAmount = 0;

        double DouExpCarat = 0.00;

        public string BandConsumeCaption = "";
        public string BandConsumeWithProcessCaption = "";

        double DouMaterialCost = 0;
        double DouConsumeCarat = 0;
        double DouPerConsumeCarat = 0;
        double DouAvgProduction = 0;
        double DouConsumeAmount = 0;
        double DouOSCarat = 0;
        double DouOSExpCarat = 0;
        double DouIssueCarat = 0;
        double DouConsumeExpCarat = 0;
        double DouIssueExpCarat = 0;
        double DouReadyCarat = 0;
        double DouReadyExpCarat = 0;
        double DouDMCarat = 0;
        
        double DouFactoryCarat = 0;
        double DouFactoryDMCarat = 0;
        //double DouFactoryWTCarat = 0;
        double DouInsFExpCarat = 0;
        double DouInspectionDiff = 0;

        double DouManualCarat = 0;


        double DouManualPer = 0;
        double DouFactoryPer = 0;
        double DouDMPer = 0;
        double DouExpIssPer = 0;
        double DouExpRecPer = 0;
        

        int IntOSPcs = 0;

        double DouExpPolishCarat = 0;
        double DouExpPolishAmount = 0;

        double DouPolishAmount = 0;
        double DouPolishLabAmount = 0;

        double DouLossCarat = 0;
        double DouMinorCarat = 0;
        double DouMajorCarat = 0;
        double IntConsumePcs = 0;
        //ADD BY HARESH ON 26-09-2014

        double IntMfgOSPcs = 0;
        double DouMFGOSCarat = 0;
        double IntRepOSPcs = 0;
        double IntRepConsume = 0;
        double IntTSOSPcs = 0;
        double IntTSConsume = 0;
        
        /// <summary>
        ////
        /// </summary>
        double DouProcessReadyCarat = 0;
        double DouPreviousCarat = 0;

        double DouRoughCarat = 0;
        double DouRoughAmount = 0;
        
        double DouSaleCarat = 0;
        double DouSaleAmount = 0;
        
        double DouPremAmountDollar = 0;
        double DouPremAmountLocal = 0;
        double DouPremAmountPurchase = 0;


        double DouAssortMentCarat = 0;
        double DouAssortMentAmount = 0;
        int IntAssortMentPcs = 0;
        
        double DouBanchAmount = 0;

        // ADD : NARENDAR : 23/07/2014
        int RecCount = 0;
        double DouHour = 0;
        double DouCaratDone = 0;
        double DouStdCarat = 0;

        double DouOTHour = 0;
        double DouOTCarat = 0;
        
        double DouTotalHour = 0;
        double DouTotalIdleHour = 0;       
        double DouTotalCarat = 0;

        /*ADD BY HARESH FOR CALUCATION OF AVG.RATE OF PRDUCTION,EXTRA AND TOTAL PCS-AMOUNT FOR WAGES*/
        int IntProductionPcs = 0;
        double DouProductionAmount = 0.00;
        int IntExtraPcs = 0;
        double DouExtraAmount = 0.00;
        int IntTotalPcs = 0;
        double DouTotalAmount = 0.00;
    
        //----------
        // ADD BY CHIRAG 20-02-16
        double DouInsManPer = 0.00;  //INS_MAN_PER//
        double DouInsDMPer = 0.00;
        double DouTotalPer = 0.00;
        double DouInsExptManual = 0.00; //INS_EXPT_ MAN //
        double DouInsExptDM = 0.00; //INS_EXP_DM //
        double DouInsExpTotal = 0.00; //INS_EXP_TOTAL//      
        double DouManualOrgCarat = 0.00;
        double DouDMOrgCarat = 0.00;
        double DouTotalCrt = 0.00;
        double DouInspDM = 0.00; //INS_FAC_PER //
        double DouFacExpWt = 0.00;
        double DouDMExpWt = 0.00;
        double DouManExpWt = 0.00;
        double DouInsFacExpCarat = 0.00;
     //   double DouFactoryWTCarat = 0.00;
        double DouManualWTCarat = 0.00;
        double DouInsDMExpCrt = 0.00;
        double DouInsDMCarat = 0.00;
        double DouInspFAC = 0.00;
        double DouInspMAN = 0.00;
        double DouInsManualCarat = 0.00;
        double DouFACOrgCarat = 0.00;
        double DouFactoryWTCarat = 0.00;
        double DouDMExpPer = 0.00;
        double DouMANExpPer = 0.00;
        double DouTotalExpPer = 0.00;
        double DouDMExpCarat = 0.00;
        double DouMANExpCarat = 0.00;
        double DouInsReadyCrt = 0.00;
        // ADD BY CHIRAG 20-02-16

        // ADD BY HARESH ON 03-11-2014 FOR QUALITY MONITOR CUSTOM SUMMARY

        double DouOverAllCutting = 0.00;
        double DouOverAllCutting1 = 0.00;
        double DouOverAllFinishing = 0.00;
        double DouOverAllFinishing1 = 0.00;

        double DouWTPer = 0.00;
        double DouWTPer1 = 0.00;

        double DouWP2 = 0.00;
        double DouWP21 = 0.00;
        double DouResult = 0.00;
        double DouWTRank = 0.00;
        
        double DouWP = 0.00;
        double DouWTRank2 = 0.00;
        double DouWTRank21 = 0.00;
        double DouOverCut2 = 0.00;
        double DouProd3 = 0.00;
        double DouProduction = 0.00;
        int  IntCapacity = 0;
        double DouProd31 = 0.00;
        double DouOf2 = 0.00;
        double DouPurityGR3 = 0.00;
        double DouOVERALLFINISHGRP3 = 0.00;
        double DouOVERALLCUTGRP3 = 0.00;
        double DouQualityPer = 0.00;
        double DouQualityPer1 = 0.00;
        string StrRank = "";
        string StrAction = "";

        double DouTotalDays = 0; //TOTAL_DAYS
        double DouAbsentDays = 0; //ABSENT_DAYS
        double DouAbsentPercentage = 0; // formula
        double DouTotalManDays = 0; //TOTAL_MANDAYS
        double DouTotalPresentMandays = 0;  //TOTALPRESENT_MANDAYS
        double DouAbsentPercentMandays = 0; //ABSENTPERCENT_MANDAYS
        double DouPresentPercentMandays = 0;
        double DouMandaysPrs = 0;

        #region Propert Settings

        private DataTable _mDTDetail = new DataTable();

        public DataTable mDTDetail
        {
            get { return _mDTDetail; }
            set { _mDTDetail = value; }
        }
        
        private DataTable _DTab = new DataTable();

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        private string _Group_By_Tag;

        public string Group_By_Tag
        {
            get { return _Group_By_Tag; }
            set { _Group_By_Tag = value; }
        }

        private string _Group_By_Text;

        public string Group_By_Text
        {
            get { return _Group_By_Text; }
            set { _Group_By_Text = value; }
        }


        private bool _BoolShowLabourRate;

        public bool BoolShowLabourRate
        {
            get { return _BoolShowLabourRate; }
            set { _BoolShowLabourRate = value; }
        }

        private string _Order_By;

        public string Order_By
        {
            get { return _Order_By; }
            set { _Order_By = value; }
        }


        private string _ReportHeaderName;

        public string ReportHeaderName
        {
            get { return _ReportHeaderName; }
            set { _ReportHeaderName = value; }
        }

        //---- Add : Narendra : 25-06-2014
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        //--------------------
        private int _Report_Code;

        public int Report_Code
        {
            get { return _Report_Code; }
            set { _Report_Code = value; }
        }


        private string _Report_Type;

        public string Report_Type
        {
            get { return _Report_Type; }
            set { _Report_Type = value; }
        }


        private string _FormToBeOpen;

        public string FormToBeOpen
        {
            get { return _FormToBeOpen; }
            set { _FormToBeOpen = value; }
        }


        private string _FilterBy;

        public string FilterBy
        {
            get { return _FilterBy; }
            set { _FilterBy = value; }
        }

        // Add By Khushbu 04/06/2014

        public string R_Date;
        public string Shape_Name;
        public string Article_Name;
        public string MSize_Name;        
        
        // ---------
        // Add : Narendra : 27-09-2014
        private ReportParams_Property _ReportParams_Property;

        public ReportParams_Property ReportParams_Property
        {
            get { return _ReportParams_Property; }
            set { _ReportParams_Property = value; }
        }

        private string _Procedure_Name;

        public string Procedure_Name
        {
            get { return _Procedure_Name; }
            set { _Procedure_Name = value; }
        }

        private bool _ChkExportAsaCostingPattern;

        public bool ChkExportAsaCostingPattern
        {
            get { return _ChkExportAsaCostingPattern; }
            set { _ChkExportAsaCostingPattern = value; }
        }

        private string _FromIssue_Date;

        public string FromIssue_Date
        {
            get { return _FromIssue_Date; }
            set { _FromIssue_Date = value; }
        }

        private string _ToIssue_Date;

        public string ToIssue_Date
        {
            get { return _ToIssue_Date; }
            set { _ToIssue_Date = value; }
        }

        private string _FilterByFormName;

        public string FilterByFormName
        {
            get { return _FilterByFormName; }
            set { _FilterByFormName = value; }
        }

        //End : Narendra : 27-09-2014
        #endregion

        // Add : Narendra : 29-Jun-2015
        private int _Company_Code;
        public int Company_Code
        {
            get { return _Company_Code; }
            set { _Company_Code = value; }
        }

        private int _Branch_Code;
        public int Branch_Code
        {
            get { return _Branch_Code; }
            set { _Branch_Code = value; }
        }

        private int _Location_Code;
        public int Location_Code
        {
            get { return _Location_Code; }
            set { _Location_Code = value; }
        }

        public bool IS_Local { get; set; }
        public bool IS_Purchase { get; set; }
        public bool IS_Dollar { get; set; }

        // End : Narendra : 29-Jun-2015

        #region Constructor

        public FrmGReportViewerBand()
        {
            InitializeComponent();

            DTabDiscount.Columns.Add("key");
            DTabDiscount.Columns.Add("value");
        }

        public FrmGReportViewerBand(DataTable pDTab, string pStrOrderBy, string pStrGroupBy, string pStrReportName, int pIntReportCode)
        {
            InitializeComponent();

            DTab = pDTab;
            Group_By_Tag = pStrGroupBy;
            Order_By = pStrOrderBy;
            ReportHeaderName = pStrReportName;
            Report_Code = pIntReportCode;
        }

        public void ShowForm()
        {
            //ObjPer.Report_Code = Report_Code;
            AttachFormEvents();
            lblReportHeader.Text = ReportHeaderName;

            if (Group_By_Text == null || Group_By_Text == "")
            {
                lblGroupBy.Visible = false;
                label2.Visible = false;
            }
            else
            {
                lblGroupBy.Visible = true;
                label2.Visible = true;
                lblGroupBy.Text = Group_By_Text;
                lblGroupBy.Tag = Group_By_Tag;
            }

            lblFilter.Text = FilterBy;
            this.Text = lblReportHeader.Text;// +" With Group : " + lblGroupBy.Text;
            this.Show();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;            
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Menu Events

        private void MNUExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToExcel_Click(object sender, EventArgs e)
        {
            Export("xls", "Export to Excel", "Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*");
        }
        private void ToExcelx_Click(object sender, EventArgs e)
        {
            Export("xlsx", "Export to Excel", "Excel 2007 Onwards (*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void ToText_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void ToHTML_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void ToRTF_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void ToPDF_Click(object sender, EventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
        }

        private void ExpandTool_Click(object sender, EventArgs e)
        {
            GridView1.ExpandAllGroups();
        }

        private void Collapse_Click(object sender, EventArgs e)
        {
            GridView1.CollapseAllGroups();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ObjPer.AllowPrint == false) // If Condition Add by Khushbu 07/04/2014
                //{
                //    Global.Message(BLL.GlobalDec.gStrPermissionPrintMsg);
                //    return;
                //}

                DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

                PrinterSettingsUsing pst = new PrinterSettingsUsing();

                //foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
                //{
                //    if (Val.ToString(CmbPageKind.SelectedItem) == foo.ToString())
                //    {
                //        PrintSystem.PageSettings.PaperKind = foo;
                //        PrintSystem.PageSettings.PaperName = foo.ToString();
                //    }
                //}
                
                PrintSystem.PageSettings.AssignDefaultPrinterSettings(pst);
                

                PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

                link.Component = GridControl1;

                foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
                {
                    if (Val.ToString(CmbPageKind.SelectedItem) == foo.ToString())
                    {
                        link.PaperKind = foo;
                        link.PaperName = foo.ToString();
                        
                    }
                }

                if (Val.ToString(cmbOrientation.SelectedItem) == "Landscape")
                {
                    link.Landscape = true;
                }
                if (Val.ToString(cmbExpand.SelectedItem) == "Yes")
                {
                    GridView1.OptionsPrint.ExpandAllGroups = true;
                }
                else
                {
                    GridView1.OptionsPrint.ExpandAllGroups = false;
                }

                GridView1.OptionsPrint.AutoWidth = true;
                
                //link.PrintingSystem.Document.ScaleFactor = 80;

                link.Margins.Left = 40;
                link.Margins.Right = 40;
                link.Margins.Bottom = 40;
                link.Margins.Top = 130;
                link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
                link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterArea);
                link.CreateDocument();
                link.ShowPreview();
                link.PrintDlg();
            }
            catch (Exception EX)
            {
                Global.Confirm(EX.Message);
            }
        }

      

        #endregion

        #region Events

        private void FrmGReportViewer_Load(object sender, EventArgs e)
        {
            int IntIndex = 0;
            int IntSelectedIndex = 0;
            CmbPageKind.Items.Clear();
            foreach (System.Drawing.Printing.PaperKind foo in Enum.GetValues(typeof(System.Drawing.Printing.PaperKind)))
            {
                CmbPageKind.Items.Add(foo.ToString());
                //if (foo.ToString() == ObjReportDetailProperty.Page_Kind.ToString())
                //{
                //    CmbPageKind.SelectedIndex = IntIndex;
                //    IntSelectedIndex = IntIndex;
                //}
                IntIndex++;
            }
            CmbPageKind.SelectedIndex = IntSelectedIndex;
            lblDateTime.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
            FillGrid();

            //if (ObjReportDetailProperty.Remark == "POLISH_CONSUME_VALUATION") // If Condition Add By Khushbu 31/05/2014
            //{
            //    TsmExportData.Visible = true;
            //}
            //if (FilterByFormName != null && !FilterByFormName.Trim().Equals(string.Empty))
            //{
            //    if (
            //        Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryIssueTrnFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryOSTrnFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryPolishTrnFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryTrnFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryWorkerOSFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryWorkerTrnFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixFactoryWorkerWagesFilterBy")
            //        || Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveEmpFilterBy")

            //        || Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveStaffProductionFilterBy") // Add : Narendra : 17-10-2014
            //        || Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveOutSideFilterBy") // Add : Narendra : 17-10-2014 
            //        || Val.ToString(FilterByFormName).Equals("FrmMixIssueReceiveMachineFilterBy") // Add : Narendra : 17-10-2014  
            //        || Val.ToString(FilterByFormName).Equals("FrmRoughTransfereFilterBy") // Add : Narendra : 17-10-2014  

            //        || Val.ToString(FilterByFormName).Equals("FrmEmpPerformanceFilterBy") // Add : Haresh : 31-10-2014  

            //        || Val.ToString(FilterByFormName).Equals("FrmValuationPolishIssueFilterBy")// Add : Narendra : 29-09-2014 

            //        || Val.ToString(FilterByFormName).Equals("FrmMixRealizationFilterBy"))// Add : Narendra : 29-09-2014 

            //    {
            //        pnlRefresh.Visible = true;
            //    }
            //}
        }

        #endregion

        #region Operation

        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            //if (ObjPer.AllowExp == false) // If Condition Add by Khushbu 07/04/2014
            //{
            //    Global.Message(BLL.GlobalDec.gStrPermissionExpMsg);
            //    return;
            //}

            GridView1.OptionsPrint.ExpandAllDetails = true;
            //DevExpress.XtraGrid.Export.GridViewExportLink gvlink;
            try
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                string Filepath = "";
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    Filepath = svDialog.FileName;
                    switch (format)
                    {
                        case "pdf":
                            GridView1.ExportToPdf(Filepath);

                            break;
                        case "xls":

                            GridView1.ExportToXls(Filepath);

                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportXlsProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
                        case "xlsx":
                            GridView1.ExportToXlsx(Filepath);
                            break;
                        case "xml":
                            GridView1.ExportToRtf(Filepath);
                            break;
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportXlsxProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                        case "rtf":
                            GridView1.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GridView1.ExportToText(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportTxtProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);
                            break;
                        case "html":
                            GridView1.ExportToHtml(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);
                            break;
                    }
                }

                if (Global.Confirm("Press Yes To Open the File.") == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Filepath, "CMD");
                }
            }
            catch (Exception ex)
            {
                Global.Confirm(ex.Message.ToString(), "Error in Export");
            }
        }

        public void FillGrid()
        {

            //InsertReportTrace();

            int IntError = 0;

            try
            {
               // DataView dv = new DataView(mDTDetail);
                // dv.Sort = "Sequence_No";
                //mDTDetail = dv.ToTable();

                //int IntIndex = 0;
                //foreach (DataRow DRow in mDTDetail.Rows)
                //{
                //    foreach (DataColumn DCol in DTab.Columns)
                //    {
                //        // Arrancge  Column in Order by User
                //        if (DCol.ColumnName == DRow["FIELD_NAME"].ToString())
                //        {
                //            DTab.Columns[DCol.ColumnName].SetOrdinal(IntIndex);
                //            IntIndex++;
                //            DTab.AcceptChanges();
                //            break;
                //        }
                //    }
                //}


                //Delete And Merge 
                //foreach (DataRow DRow in mDTDetail.Rows)
                //{

                //    if (Val.ToInt(DRow["VISIBLE"].ToString()) == 0)
                //    {
                //        //DTab.Columns.Remove(DRow["FIELD_NAME"].ToString());
                //    }
                //    else
                //    {
                //        if (DRow["MERGEON"].ToString() != "")
                //        {
                //            MergeOn = DRow["MERGEON"].ToString();

                //            if (MergeOnStr == "")
                //            {
                //                MergeOnStr = DRow["MERGEON"].ToString();
                //            }
                //            else
                //            {
                //                MergeOnStr = MergeOnStr + "," + DRow["FIELD_NAME"].ToString();
                //            }
                //        }
                //    }
                //}


                //List<GridBand> AL = new List<GridBand>();


                //DataView view = new DataView(mDTDetail);
                //DataTable distinctValues = view.ToTable(true, "BANDS");

                //foreach (DataRow DRow in distinctValues.Rows)
                //{
                //    var gridBand = new GridBand();
                //    gridBand.Caption = Val.ToString(DRow["BANDS"]);
                //    gridBand.RowCount = 2;
                //    AL.Add(gridBand);                 
                //}



                GridControl1.DataSource = mDTDetail;// DTab;
                GridView1.OptionsView.AllowCellMerge = true;

                //GridView1.Bands.AddBand(lblReportHeader.Text);   //  + "Date : " + lblDateTime.Text


                //foreach (DataRow DRow in mDTDetail.Rows)
                //{
                //    if (Val.ToInt(DRow["VISIBLE"].ToString()) == 1 && Val.ToInt(DRow["IS_UNBOUND"]) == 1)
                //    {
                //        DevExpress.XtraGrid.Columns.GridColumn unbColumn = GridView1.Columns.AddField(Val.ToString(DRow["FIELD_NAME"]));
                //        unbColumn.VisibleIndex = Val.ToInt(DRow["SEQUENCE_NO"]);
                //        unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                //        unbColumn.Caption = Val.ToString(DRow["COLUMN_NAME"]);
                //        unbColumn.Tag = DRow["FIELD_NAME"].ToString();
                //        unbColumn.OptionsColumn.AllowEdit = false;
                //        // Specify format settings.
                //        unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                //        if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N1")
                //        {
                //            unbColumn.DisplayFormat.FormatString = "###################0.0";
                //        }
                //        if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N2")
                //        {
                //            unbColumn.DisplayFormat.FormatString = "###################0.00";
                //        }
                //        else if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N3")
                //        {
                //            unbColumn.DisplayFormat.FormatString = "###################0.000";
                //        }
                //        else if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N4")
                //        {
                //            unbColumn.DisplayFormat.FormatString = "###################0.0000";
                //        }

                //        //unbColumn.DisplayFormat.FormatString = "{0:" + Val.ToString(DRow["FORMAT"]).ToUpper() + "}";
                //        unbColumn.UnboundExpression = Val.ToString(DRow["EXPRESSION"]);
                //        unbColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //    }
                //    else
                //    {

                //        bool iBool = false;
                //        foreach (DataColumn DCol in DTab.Columns)
                //        {
                //            if (DCol.ColumnName == DRow["FIELD_NAME"].ToString())
                //            {
                //                iBool = true;
                //                break;
                //            }

                //        }

                //        if (iBool == false)
                //        {
                //            continue;
                //        }

                //        if (Val.ToInt(DRow["VISIBLE"].ToString()) == 0)
                //        {
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Visible = false;
                //            continue;
                //        }

                //        // If Not Merge Then Dont Allow to Merge
                //        if (Val.ToInt(DRow["ISMERGE"].ToString()) == 0)
                //        {
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //        }

                //        //Set Column Caption
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].Caption = DRow["COLUMN_NAME"].ToString();
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].Tag = DRow["FIELD_NAME"].ToString();
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //    }
                ////Set Column Default Format as per data commnig

                //string StrFormat = string.Empty;
                //string StrSummryFormat = string.Empty;

                //switch (DRow["TYPE"].ToString().ToUpper())
                //{
                //    case "I":
                //        StrFormat = "###################0";
                //        StrSummryFormat = "{0:N0}";
                //        //StrFormat = "##########0";
                //        break;
                //    case "F":
                //        if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N0")
                //        {
                //            StrFormat = "###################0";
                //        }
                //        if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N1")
                //        {
                //            StrFormat = "###################0.0";
                //        }
                //        if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N2")
                //        {
                //            StrFormat = "###################0.00";
                //        }
                //        else if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N3")
                //        {
                //            StrFormat = "###################0.000";
                //        }
                //        else if (Val.ToString(DRow["FORMAT"]).ToUpper() == "N4")
                //        {
                //            StrFormat = "###################0.0000";
                //        }
                //        StrSummryFormat = "{0:" + Val.ToString(DRow["FORMAT"]).ToUpper() + "}";
                //        break;
                //    case "D":
                //        StrFormat = "dd-MMM-yyyy";
                //        break;
                //    case "T":
                //        StrFormat = "hh:mm tt";
                //        break;
                //    default:
                //        StrFormat = "";
                //        break;
                //}

                ///* Add By Vipul 04/09/2014
                ///* Add Alignment */
                //switch (DRow["ALIGNMENT"].ToString().ToUpper())
                //{
                //    case "LEFT":
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                //        break;
                //    case "RIGHT":
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //        break;
                //    case "CENTER":
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //        break;
                //    default:
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                //        break;
                //}

                ///* Set Order */
                //switch (DRow["ORDER_BY"].ToString().ToUpper())
                //{
                //    case "ASC":
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.Ascending;
                //        break;
                //    case "DESC":
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.Descending;
                //        break;
                //    default:
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.None;
                //        break;
                //}

                //GridView1.Columns[DRow["FIELD_NAME"].ToString()].OptionsColumn.AllowEdit = false;
                //GridView1.Columns[DRow["FIELD_NAME"].ToString()].DisplayFormat.FormatString = StrFormat;
                //GridView1.Columns[DRow["FIELD_NAME"].ToString()].VisibleIndex = Val.ToInt(DRow["SEQUENCE_NO"]);

                //foreach (GridBand band in AL)
                //{
                //    if (band.Caption == Val.ToString(DRow["BANDS"]))
                //    {
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].OwnerBand = band;

                //        bool ISExists = false;

                //        foreach (GridBand band1 in GridView1.Bands[0].Children)
                //        {
                //            if (band1.Caption == band.Caption)
                //            {
                //                ISExists = true;
                //                break;
                //            }
                //        }

                //        //foreach (GridBand band1 in GridView1.Bands)
                //        //{
                //        //    if (band1.Caption == band.Caption)
                //        //    {
                //        //        ISExists = true;
                //        //        break;
                //        //    }

                //        //}
                //        if (ISExists == false)
                //        {
                //            //GridView1.Bands.Add(band);
                //            GridView1.Bands[0].Children.Add(band);   
                //        }

                //        break;
                //    }
                //}


                //// Set Summry Field and group Summry Also

                //if (Val.ToInt(DRow["VISIBLE"].ToString()) == 1 && Val.ToInt(DRow["ISMERGE"].ToString()) == 0)
                //{

                //    switch (DRow["AGGREGATE"].ToString().ToUpper())
                //    {
                //        case "SUM":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Sum, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Sum, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "AVG":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Average, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Average, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "COUNT":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Count, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Count, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "MAX":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Max, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Max, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "MIN":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Min, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Min, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "WEI.AVG":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Custom, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);
                //            break;
                //        case "CUSTOME":
                //            GridView1.Columns[DRow["FIELD_NAME"].ToString()].Summary.Add(SummaryItemType.Custom, DRow["FIELD_NAME"].ToString(), StrSummryFormat);
                //            GridView1.GroupSummary.Add(SummaryItemType.Custom, DRow["FIELD_NAME"].ToString(), GridView1.Columns[DRow["FIELD_NAME"].ToString()], StrSummryFormat);

                //            break;
                //        default:
                //            break;
                //    }
                //}


                //}

                //Group By Setting
                //GridView1.ClearSorting();

                //string[] StrGroupBy = new string[] { }; if (Group_By_Tag != null) StrGroupBy = Group_By_Tag.Split(',');
                //////string[] StrGroupBy = Group_By_Tag.Split(',');

                //int IntCount = 0;




                //if (IsPivot == false)
                //{                   
                //    for (int IntI = 0; IntI < IntCount; IntI++)
                //    {
                //        if (StrGroupBy[IntI] != "")
                //        {
                //            GridView1.Columns[StrGroupBy[IntI]].GroupIndex = IntI;
                //            GridView1.Columns[StrGroupBy[IntI]].Group();
                //            GridView1.Columns[StrGroupBy[IntI]].OwnerBand = null;
                //            //GridView1.Columns[StrGroupBy[IntI]].FieldNameSortGroup = Order_By;
                //        }
                //    }

                //    if (Group_By_Tag == "")
                //    {
                //        foreach (string Str in Val.ToString(Order_By).Split(','))
                //        {
                //            if (Str != "")
                //            {
                //                GridView1.Columns[Str].SortMode = DevExpress.XtraGrid.ColumnSortMode.Default;
                //                GridView1.Columns[Str].SortOrder = ColumnSortOrder.Ascending;
                //            }
                //        }
                //    }
                //}



                //string[] StrCaption = BandConsumeCaption.Split(',');
                //string[] StrCaptionValue = BandConsumeWithProcessCaption.Split(',');

                //if (StrCaptionValue.Length == StrCaption.Length)
                //{
                //    foreach (GridBand gridBand in GridView1.Bands[0].Children)
                //    {
                //        for (int IntI = 0; IntI < StrCaption.Length; IntI++)
                //        {
                //            if (StrCaption[IntI].ToUpper() == gridBand.Caption.ToUpper())
                //            {
                //                gridBand.Caption = StrCaptionValue[IntI];
                //            }
                //        }

                //        if (BoolShowLabourRate == true)
                //        {
                //            if (gridBand.Caption.ToUpper() == "LABOUR")
                //            {
                //                gridBand.Visible = true;
                //            }
                //        }
                //        else
                //        {
                //            if (gridBand.Caption.ToUpper() == "LABOUR")
                //            {
                //                gridBand.Visible = false;
                //            }
                //        }
                //    }
                //}



                //if (BoolShowLabourRate == true)
                //{
                //    if (DTab.Columns.Contains("LABOUR_RATE"))
                //    {
                //        GridView1.Columns["LABOUR_RATE"].Visible = true;
                //    }
                //    if (DTab.Columns.Contains("LABOUR_AMOUNT"))
                //    {
                //        GridView1.Columns["LABOUR_AMOUNT"].Visible = true;
                //    }
                //}
                //else
                //{
                //    if (DTab.Columns.Contains("LABOUR_RATE"))
                //    {
                //        GridView1.Columns["LABOUR_RATE"].Visible = false;
                //    }
                //    if (DTab.Columns.Contains("LABOUR_AMOUNT"))
                //    {
                //        GridView1.Columns["LABOUR_AMOUNT"].Visible = false;
                //    }
                //}

                //GridView1.Appearance.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Regular);
                //GridView1.AppearancePrint.Row.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Regular);

                //GridView1.Appearance.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                //GridView1.AppearancePrint.BandPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                //GridView1.Appearance.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                //GridView1.AppearancePrint.HeaderPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                //GridView1.Appearance.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);
                //GridView1.AppearancePrint.GroupRow.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size)), FontStyle.Bold);

                //GridView1.Appearance.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size-1)), FontStyle.Bold);
                //GridView1.AppearancePrint.GroupFooter.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size-1)), FontStyle.Bold);

                //GridView1.Appearance.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size-1)), FontStyle.Bold);
                //GridView1.AppearancePrint.FooterPanel.Font = new Font(ObjReportDetailProperty.Font_Name, float.Parse(Val.ToString(ObjReportDetailProperty.Font_Size-1)), FontStyle.Bold);

                //GridView1.OptionsPrint.UsePrintStyles = true;
                //GridView1.OptionsSelection.MultiSelect = true;
                //GridView1.OptionsSelection.MultiSelectMode =  GridMultiSelectMode.CellSelect;

                //cmbOrientation.SelectedItem = ObjReportDetailProperty.Page_Orientation;

                //GridView1.ExpandAllGroups();
                //GridView1.BestFitColumns();


                //GridView1.ShowFilterPopupCheckedListBox += new FilterPopupCheckedListBoxEventHandler(GridView1_ShowFilterPopupCheckedListBox); // Add : Narendra : 18-10-2014

                //// ---------------------------------------------- //

                //// Add Code By Khushbu 18/06/2014
                //    if (ObjReportDetailProperty.Remark == "PREM_SUMMARY"
                //        || ObjReportDetailProperty.Remark == "PREM_DETAIL"
                //        || ObjReportDetailProperty.Remark == "PURCHASE_PIVOT"
                //        || ObjReportDetailProperty.Remark == "PURCHASE_OS"
                //        || ObjReportDetailProperty.Remark == "PURCHASE_OS_PIVOT"
                //        || ObjReportDetailProperty.Remark == "SALES_EXPORT"
                //        || ObjReportDetailProperty.Remark == "TEAM_TRANSFER"
                //        || ObjReportDetailProperty.Remark == "ROUGH_LOT"
                //        || ObjReportDetailProperty.Remark == "BRANCH_TRANSFER"
                //       )
                //{
                //    for (int i = 0; i < GridView1.Bands[0].Children.Count; i++) // Add : Narendra : 08-11-2014
                //    {
                //        if (GridView1.Bands[0].Children[i].Caption.ToUpper() == "DOLLAR" && IS_Dollar == false)
                //            GridView1.Bands[0].Children[i].Visible = false;
                //        if (GridView1.Bands[0].Children[i].Caption.ToUpper() == "LOCAL" && IS_Local == false)
                //            GridView1.Bands[0].Children[i].Visible = false;
                //        if (GridView1.Bands[0].Children[i].Caption.ToUpper() == "PURCHASE" && IS_Purchase == false)
                //            GridView1.Bands[0].Children[i].Visible = false;
                //        if (GridView1.Bands[0].Children[i].Caption.ToUpper() == "SALE" && IS_Purchase == false)
                //            GridView1.Bands[0].Children[i].Visible = false;
                //    }


                //    //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                //    //{
                //    //    if (DTab.Columns.Contains("PREM_DISC")) GridView1.Columns["PREM_DISC"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_RATE_DOLLAR")) GridView1.Columns["PREM_RATE_DOLLAR"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_RATE_LOCAL")) GridView1.Columns["PREM_RATE_LOCAL"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_RATE_PURCHASE")) GridView1.Columns["PREM_RATE_PURCHASE"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_DOLLAR")) GridView1.Columns["PREM_AMOUNT_DOLLAR"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_LOCAL")) GridView1.Columns["PREM_AMOUNT_LOCAL"].Visible = false;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_PURCHASE")) GridView1.Columns["PREM_AMOUNT_PURCHASE"].Visible = false;

                //    //    if (DTab.Columns.Contains("THIRD_PARTY_NAME")) GridView1.Columns["THIRD_PARTY_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("THIRD_SUB_PARTY_NAME")) GridView1.Columns["THIRD_SUB_PARTY_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("TEAM_NAME")) GridView1.Columns["TEAM_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("GROUP_NAME")) GridView1.Columns["GROUP_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("MSIZE_NAME")) GridView1.Columns["MSIZE_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("ARTICLE_NAME")) GridView1.Columns["ARTICLE_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("QUALITY_NAME")) GridView1.Columns["QUALITY_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("SUBQUALITY_NAME")) GridView1.Columns["SUBQUALITY_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("SOURCE_NAME")) GridView1.Columns["SOURCE_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("SOURCE_COMPANY_NAME")) GridView1.Columns["SOURCE_COMPANY_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("SIGHT_TYPE_NAME")) GridView1.Columns["SIGHT_TYPE_NAME"].Visible = false;
                //    //    if (DTab.Columns.Contains("ISSUE_TYPE")) GridView1.Columns["ISSUE_TYPE"].Visible = false;
                //    //}

                //    //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 1 && BLL.GlobalDec.gEmployeeProperty.User_Type == "PREMIUM")
                //    //{
                //    //    if (DTab.Columns.Contains("PREM_DISC")) GridView1.Columns["PREM_DISC"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_RATE_DOLLAR")) GridView1.Columns["PREM_RATE_DOLLAR"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_RATE_LOCAL")) GridView1.Columns["PREM_RATE_LOCAL"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_RATE_PURCHASE")) GridView1.Columns["PREM_RATE_PURCHASE"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_DOLLAR")) GridView1.Columns["PREM_AMOUNT_DOLLAR"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_LOCAL")) GridView1.Columns["PREM_AMOUNT_LOCAL"].Visible = true;
                //    //    if (DTab.Columns.Contains("PREM_AMOUNT_PURCHASE")) GridView1.Columns["PREM_AMOUNT_PURCHASE"].Visible = true;
                //    //}

                //    //if (BLL.GlobalDec.gEmployeeProperty.Allow_Developer == 1 && BLL.GlobalDec.gEmployeeProperty.User_Type == "PREMIUM")
                //    //{                     
                //    //    if (ObjReportDetailProperty.Remark == "TEAM_TRANSFER")//Add If Condition By Khushbu 07/11/2014
                //    //    {
                //    //        for (int i = 0; i < GridView1.Bands.Count; i++) // Add : Narendra : 08-11-2014
                //    //        {
                //    //            if (GridView1.Bands[i].Caption == "PREMIUM")
                //    //                GridView1.Bands[i].Visible = false;
                //    //        }
                //    //    }
                //    //    else if (ObjReportDetailProperty.Remark != "PREM_SUMMARY")
                //    //    {
                //    //        GridView1.Columns["PREM_DISC"].Visible = true;                            
                //    //    }

                //    //    GridView1.Columns["PREM_RATE_DOLLAR"].Visible = true;
                //    //    GridView1.Columns["PREM_AMOUNT_DOLLAR"].Visible = true;
                //    //}
                //    //else
                //    //{                       

                //    //    if (ObjReportDetailProperty.Remark == "PREM_DETAIL") //Add If Condition By Khushbu 05/11/2014
                //    //    {
                //    //        GridView1.Columns["THIRD_PARTY_NAME"].Visible = false;
                //    //        GridView1.Columns["THIRD_SUB_PARTY_NAME"].Visible = false;

                //    //        // Add : Narendra : 08-11-2014
                //    //        GridView1.Columns["TEAM_NAME"].Visible = false;
                //    //        GridView1.Columns["GROUP_NAME"].Visible = false;
                //    //        GridView1.Columns["MSIZE_NAME"].Visible = false;
                //    //        GridView1.Columns["ARTICLE_NAME"].Visible = false;
                //    //        GridView1.Columns["QUALITY_NAME"].Visible = false;
                //    //        GridView1.Columns["SUBQUALITY_NAME"].Visible = false;
                //    //        GridView1.Columns["SOURCE_NAME"].Visible = false;
                //    //        GridView1.Columns["SOURCE_COMPANY_NAME"].Visible = false;
                //    //        GridView1.Columns["SIGHT_TYPE_NAME"].Visible = false;
                //    //        // End : Narendra : 08-11-2014
                //    //    }

                //    //    else if (ObjReportDetailProperty.Remark == "TEAM_TRANSFER")//Add If Condition By Khushbu 07/11/2014
                //    //    {
                //    //        for (int i = 0; i < GridView1.Bands.Count; i++)// Add : Narendra : 08-11-2014
                //    //        {
                //    //            if (GridView1.Bands[i].Caption == "PREMIUM")
                //    //                GridView1.Bands[i].Visible = false;                       
                //    //        }
                //    //    }

                //    //    else if (ObjReportDetailProperty.Remark != "PREM_SUMMARY")
                //    //    {
                //    //        GridView1.Columns["PREM_DISC"].Visible = false;
                //    //    }

                //    //    GridView1.Columns["PREM_RATE_DOLLAR"].Visible = false;
                //    //    GridView1.Columns["PREM_AMOUNT_DOLLAR"].Visible = false;
                //    //}
                //}


                ////for (int IntI = 0; IntI < GridView1.RowCount; IntI++)
                ////{
                ////    //string Str = Val.ToString(GridView1.GetRowCellValue(IntI, "TEAM_NAME"));
                ////    //Str = Str.Remove(0, Str.IndexOf(" ") + 1);

                ////    //GridView1.SetFocusedRowCellValue("TEAM_NAME", Str);
                ////    //GridView1.RefreshRow(IntI);

                ////    DataRow DRow = GridView1.GetDataRow(IntI);
                ////    string Str = Val.ToString(DRow["TEAM_NAME"]);
                ////    Str = Str.Remove(0, Str.IndexOf(" ") + 1);

                ////    DRow["TEAM_NAME"] = Str;

                ////}

                //// ----------------------

                GridView1.ExpandAllGroups();
                GridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                Global.Confirm("Error In Column Index : " + IntError.ToString() + "    " + Ex.Message);
            }
        }        

        private void SetGridBand(BandedGridView bandedView, string gridBandCaption, string[] columnNames)
        {
            var gridBand = new GridBand();
            gridBand.Caption = gridBandCaption;
            int nrOfColumns = columnNames.Length;
            BandedGridColumn[] bandedColumns = new BandedGridColumn[nrOfColumns];
            for (int i = 0; i < nrOfColumns; i++)
            {
                bandedColumns[i] = (BandedGridColumn)bandedView.Columns.AddField(columnNames[i]);
                bandedColumns[i].OwnerBand = gridBand;                
                bandedColumns[i].Visible = true;                
            }
            bandedView.Bands.Add(gridBand);
        }

        public void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // ' For Report Title

            TextBrick BrickTitle = e.Graph.DrawString(lblReportHeader.Text, System.Drawing.Color.Navy, new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;


            // ' For Group 
            TextBrick BrickTitleseller = e.Graph.DrawString("Group :- " + lblGroupBy.Text, System.Drawing.Color.Navy, new RectangleF(0, 25, e.Graph.ClientPageSize.Width, 20), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitleseller.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitleseller.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitleseller.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitleseller.ForeColor = Color.Black;
          
            // ' For Filter 
            TextBrick BrickTitlesParam = e.Graph.DrawString("Parameters :- " + lblFilter.Text, System.Drawing.Color.Navy, new RectangleF(0, 40, e.Graph.ClientPageSize.Width, 60), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitlesParam.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitlesParam.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitlesParam.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitlesParam.ForeColor = Color.Black;


            int IntX = Convert.ToInt32(Math.Round(e.Graph.ClientPageSize.Width - 400, 0));
            TextBrick BrickTitledate = e.Graph.DrawString("Print Date :- " + lblDateTime.Text, System.Drawing.Color.Navy, new RectangleF(IntX, 25, 400, 18), DevExpress.XtraPrinting.BorderSide.None);
            BrickTitledate.Font = new Font("Tahoma", 8, FontStyle.Bold);
            BrickTitledate.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            BrickTitledate.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            BrickTitledate.ForeColor = Color.Black;
        }

        public void Link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            int IntX = Convert.ToInt32(Math.Round(e.Graph.ClientPageSize.Width - 100, 0));

            PageInfoBrick BrickPageNo = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", System.Drawing.Color.Navy, new RectangleF(IntX, 0, 100, 15), DevExpress.XtraPrinting.BorderSide.None);
            BrickPageNo.LineAlignment = BrickAlignment.Far;
            BrickPageNo.Alignment = BrickAlignment.Far;
           // BrickPageNo.AutoWidth = true;
            BrickPageNo.Font = new Font("Tahoma", 8, FontStyle.Bold); ;
            BrickPageNo.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            BrickPageNo.VertAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        //public void InsertReportTrace() // Khushbu 07/04/2014
        //{
        //    string MM = Val.ToString(DateTime.Today.Month);
        //    if (Val.ToInt(MM) < 10)
        //    {
        //        MM = "0" + MM;
        //    }
        //    int YYMM =Val.ToInt(Val.ToString(DateTime.Today.Year) + MM);
        //    //int SRNO = ObjReport.FindNewSrNo(YYMM);

        //    ObjReport.SaveReportTrace(YYMM, 0, Report_Code, Report_Type);
        //}

        #endregion

        #region Grid Events

        private void GridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (MergeOnStr.Contains(e.Column.FieldName))
            {
                int val1 = Val.ToInt(GridView1.GetRowCellValue(e.RowHandle1, GridView1.Columns[MergeOn]));
                int val2 = Val.ToInt(GridView1.GetRowCellValue(e.RowHandle2, GridView1.Columns[MergeOn]));
                if (val1 == val2)
                    e.Merge = true;
                e.Handled = true;
            }
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //int IntSrNo = Val.ToInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "INVOICE_NO"));
            //if (e.Clicks == 2)
            //{
            //    if (FormToBeOpen == "FRMPURCHASEMASTER")
            //    {
            //        FrmPurchase FrmPurchase = new FrmPurchase();
            //        FrmPurchase.ShowForm(IntSrNo);    
            //    }                
            //}
        }

        
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                //if (e.Column.DisplayFormat.FormatString == "{0:N3}" && e.DisplayText.Contains(","))
                //if (e.DisplayText.Contains(","))
                //{
                //    e.DisplayText = e.DisplayText.Replace(",","");
                //    // e.Appearance.ForeColor = System.Drawing.Color.White;
                //}
                
                //if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
                //{
                //    //e.DisplayText = String.Empty;
                //   // e.Appearance.ForeColor = System.Drawing.Color.White;
                //}
                e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void GridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            //try
            //{
            //    if (e.Column.DisplayFormat.FormatString == "{0:N3}" && GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Contains(","))
            //    {
            //        GridView1.SetRowCellValue(e.RowHandle, e.Column, GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Replace(",", ""));
            //        // e.Appearance.ForeColor = System.Drawing.Color.White;
            //    }
            //    //if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
            //    //{
            //    //    //e.DisplayText = String.Empty;
            //    //   // e.Appearance.ForeColor = System.Drawing.Color.White;
            //    //}
            //    e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }

        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            // Add : Narendra : 30/Jun/2015 :: Format Credit/Debit Amount Of Ledger Transaction Report.
            if (Val.ToString(Remark).ToUpper().Equals("LEDGER_TRANSACTION"))
            {
                if (e.Column.FieldName.ToUpper().Contains("CREDIT") || e.Column.FieldName.ToUpper().Contains("DEBIT") || e.Column.FieldName.ToUpper().Contains("AMOUNT"))
                {
                    e.DisplayText = Val.FormatWithSeperator(e.DisplayText);
                }
            }

            else if (!Val.ToString(Remark).ToUpper().Equals("HR_SALARY_REPORT"))
            {
                if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
                {
                    e.DisplayText = String.Empty;
                    // e.Appearance.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        #endregion     

        private void GridView1_StartGrouping(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
        }

        private void MNGroupEnableDisable_Click(object sender, EventArgs e)
        {

            if (MNRemoveGroup.Text == "Disable Groups")
            {
                while (GridView1.GroupedColumns.Count != 0)
                {
                    GridView1.GroupedColumns[GridView1.GroupedColumns.Count - 1].UnGroup();
                }
                MNRemoveGroup.Text = "Enable Groups";

            }
            else
            {
                foreach (string Str in Val.ToString(Group_By_Tag).Split(','))
                {
                    if (Str != "")
                    {
                        GridView1.Columns[Str].Group();
                    }
                }
                MNRemoveGroup.Text = "Disable Groups";
            }
            ExpandTool_Click(null, null);
        }

        private void MNFilter_Click(object sender, EventArgs e)
        {
            GridView1.BeginUpdate();
            if (ISFilter == true)
            {
                ISFilter = false;
                MNFilter.Text = "Add Filter";
                GridView1.OptionsView.ShowAutoFilterRow = false; 
            }
            else
            {
                ISFilter = true;
                MNFilter.Text = "Remove Filter";
                GridView1.OptionsView.ShowAutoFilterRow = true;
            }
            GridView1.EndUpdate();
        }

        private void MNColumnChooser_Click(object sender, EventArgs e)
        {
         
        }

        private void EmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ObjPer.AllowEMail == false) // If Condition Add by Khushbu 07/04/2014
            {
                Global.Confirm(BLL.GlobalDec.gStrPermissionEMailMsg);
                return;
            }

            string StrFile = Global.DataGridExportToExcel(GridView1, "Report");

            //GridView1.ExportToXls(StrFile);

            //Utility.FrmEmailSend FrmEmailSend = new Utility.FrmEmailSend();
            //FrmEmailSend.mStrSubject = lblReportHeader.Text;
            //FrmEmailSend.mStrAttachments = StrFile;
            //FrmEmailSend.ShowForm();
            //FrmEmailSend = null;

            if (File.Exists(StrFile))
            {
                File.Delete(StrFile);
            }
            this.Focus();

        }

        #region Custome Calculation
              
        private void GridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData == false)
            {
                return;
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MACHINE_WORK_DOWN" || Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MACHINE_DOWN")
            {
                if (e.Column.FieldName == "WORK_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "DOWN_HOURS");                 
                }    
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "TOTAL_ROUGH_TRANSFER")
            {
                if (e.Column.FieldName == "RR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "RR_CARAT");
                }
                
                if (e.Column.FieldName == "READY_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "READY_CARAT");
                }
                
                if (e.Column.FieldName == "READY_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "READY_CARAT");
                }
                if (e.Column.FieldName == "CONSUME_CARAT_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CONSUME_CARAT");
                }
                if (e.Column.FieldName == "CONSUME_PCS_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CONSUME_PCS");
                }
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_BROKEN_PCS")
            {
                if (e.Column.FieldName == "CARAT_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CARAT");
                }
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "CONSIDATE_VALUATION_CONSUME_RR")
            {
                if (e.Column.FieldName == "OS_CARAT_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "OS_CARAT");
                }
                if (e.Column.FieldName == "OS_VALUE_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CONSUME_VALUE");
                }
                if (e.Column.FieldName == "RR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "RR_CARAT");
                }
            }
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BREAKAGE_SUMMARY")
            {
                if (e.Column.FieldName == "MINOR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "MINOR_CARAT");
                }
                if (e.Column.FieldName == "MAJOR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "MAJOR_CARAT");
                }                
            }


            // Khushbu 29/03/2014
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BREAKAGE_SUMMARY")
            {
                if (e.Column.FieldName == "MAJOR_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "MAJOR_CARAT");
                }
            }

            // ------

            // Khushbu 16/10/2014
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "REAL_SUM")
            {
                if (e.Column.FieldName == "CARAT_PER")
                {
                    e.Value = GetPercent(e.ListSourceRowIndex, "CARAT");
                }
            }

            // ------
        }

        public int GetGroupSummryIndex(string pStrFieldName)
        {
            int IntIndex = 0;
            foreach (GridGroupSummaryItem item in GridView1.GroupSummary)
            {
                if (item.FieldName.ToUpper() == pStrFieldName)
                {
                    IntIndex = item.Index;
                    break;
                }
            }
            return IntIndex;
        }

        /// <summary>
        /// FOr Row Percentage Column
        /// </summary>
        /// <param name="rowHandle">Current Focused or active row</param>
        /// <param name="pStrGrandSummryColumnName">the grand summry column name when no grouping is there</param>
        /// <param name="pStrCellValueColumnName">column name which is used for calculate the percentage</param>
        /// <param name="pIntVisibleSummryColumnIndex">summry index of calculated column</param>
        /// <returns></returns>
        private double GetPercent(int rowHandle, string pStrFieldName)
        {

            int IntIndex = GetGroupSummryIndex(pStrFieldName);
            

            int groupRow = GridView1.GetParentRowHandle(rowHandle);

            double part = 0;
            double total = 0;

            if (GridView1.IsGroupRow(groupRow))
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    //total = Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[IntIndex] as DevExpress.XtraGrid.GridGroupSummaryItem));
                    //part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));

                    //IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                    //total += Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[IntIndex] as DevExpress.XtraGrid.GridGroupSummaryItem));

                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[GetGroupSummryIndex("CONSUME_CARAT")] as DevExpress.XtraGrid.GridGroupSummaryItem));
                }
                else
                {
                    total = Val.Val(GridView1.GetGroupSummaryValue(groupRow, GridView1.GroupSummary[IntIndex] as DevExpress.XtraGrid.GridGroupSummaryItem));
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));                    
          
                }
            }
            else
            {
                if (pStrFieldName == "RR_CARAT")
                {
                    //total = Val.Val(GridView1.Columns[pStrFieldName].Summary[0].SummaryValue);
                    //total += Val.Val(GridView1.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    //part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));

                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.GetRowCellValue(rowHandle, "CONSUME_CARAT"));
                    total += Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }
                else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                {
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                    total = Val.Val(GridView1.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);                    
                }
                else
                {
                    total = Val.Val(GridView1.Columns[pStrFieldName].Summary[0].SummaryValue);
                    part = Val.Val(GridView1.GetRowCellValue(rowHandle, pStrFieldName));
                }

            }
            return (total == 0) ? 0 : (part / total) * 100;
        }

        public void GetGroupRowPercentage(object sender, CustomSummaryEventArgs e, string pStrFieldName)
        {

            GridView view = sender as GridView;

            int IntIndex = GetGroupSummryIndex(pStrFieldName);

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                int IntParentSummryRowHandle = 0;
                int IntCurrentGroupRowHandle = 0;
                double total = 0;
                double part = 0;

                if (e.GroupLevel == -1)
                {
                    if (pStrFieldName == "RR_CARAT")
                    {
                        //part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        //total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        //total += Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);

                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total += Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);

                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    }
                    else
                    {
                        part = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);                    
                    }

                }

                else if (e.GroupLevel == 0)
                {
                    IntCurrentGroupRowHandle = e.GroupRowHandle;

                    if (pStrFieldName == "RR_CARAT")
                    {
                        //part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        //total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                        //total += Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);

                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                        total += Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));

                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.Columns["CONSUME_CARAT"].Summary[0].SummaryValue);
                    }
                    else
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.Columns[pStrFieldName].Summary[0].SummaryValue);
                    }
                }

                else if (e.GroupLevel >= 1)
                {
                    IntParentSummryRowHandle = view.GetParentRowHandle(view.GetParentRowHandle(e.RowHandle));
                    IntCurrentGroupRowHandle = view.GetParentRowHandle(e.RowHandle);

                    if (pStrFieldName == "RR_CARAT")
                    {
                        //part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        //total = Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        //IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                        //total += Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));

                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        IntIndex = GetGroupSummryIndex("CONSUME_CARAT");
                        total += Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));

                    }
                    else if (pStrFieldName == "MAJOR_CARAT" || pStrFieldName == "MINOR_CARAT")
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("CONSUME_CARAT")]));                    
                    }
                    else
                    {
                        part = Val.Val(view.GetGroupSummaryValue(IntCurrentGroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));
                        total = Val.Val(view.GetGroupSummaryValue(IntParentSummryRowHandle, (GridGroupSummaryItem)view.GroupSummary[IntIndex]));                    
                    }
               
                    //IntParentSummryRowHandle = view.GetParentRowHandle(e.GroupRowHandle);
                    //IntCurrentGroupRowHandle = e.GroupRowHandle;

                }

                e.TotalValue = (total == 0) ? 0 : (part / total) * 100;
            }
        }

        private void GridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;

            #region BREAKAGE_SUMMARY
            
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BREAKAGE_SUMMARY")
            {
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MAJOR_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "MAJOR_CARAT");
                //}
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MINOR_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "MINOR_CARAT");
                //}

                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouLossCarat = 0;
                    DouConsumeCarat = 0;
                    IntConsumePcs = 0;
                    DouMinorCarat = 0;
                    DouMajorCarat = 0;                    
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    IntConsumePcs = IntConsumePcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_PCS"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouLossCarat = DouLossCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "LOSS_CARAT"));
                    DouMajorCarat = DouMajorCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MAJOR_CARAT"));
                    DouMinorCarat = DouMinorCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MINOR_CARAT"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("LOSS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouLossCarat / DouConsumeCarat) * 100, 2);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MINOR_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouMinorCarat / DouConsumeCarat) * 100, 2);
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MAJOR_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouMajorCarat / DouConsumeCarat) * 100, 2);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_SIZE") == 0)
                    {
                        if (IntConsumePcs != 0)
                        {
                            e.TotalValue = Math.Round((DouConsumeCarat / (IntConsumePcs / 2)) , 2);
                        }
                    }
                }
            }

            #endregion

            #region CONSIDATE_VALUATION_CONSUME_RR
            
            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "CONSIDATE_VALUATION_CONSUME_RR")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    IntOSPcs = 0;
                    DouIssueCarat = 0;
                    DouPolishAmount = 0;
                    DouPolishLabAmount = 0;
                    DouOSCarat = 0;
                    DouConsumeAmount = 0;
                    DouMaterialCost = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    IntOSPcs = IntOSPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "OS_PCS"));
                    DouOSCarat = DouOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OS_CARAT"));

                    DouConsumeExpCarat = DouConsumeExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OS_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_CONS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);                    
                
                    DouConsumeAmount = DouConsumeAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_VALUE"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MATERIAL_COST_PER_CARAT") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouConsumeAmount / DouOSCarat, 2);
                        }
                    }                   
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_CONS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouConsumeExpCarat / DouConsumeCarat) * 100, 2);
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouReadyCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyExpCarat / DouReadyCarat) * 100, 2);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_DIFF") == 0)
                    {
                        if (e.GroupLevel < 0)
                        {
                            double ExpConsPer = Val.Val(view.Columns["EXP_CONS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                        else
                        {
                            double ExpConsPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_CONS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                    }
                }
            }

            #endregion

            #region POLISH_ISSUE_CONSUME_OUTSTAND_CONSOLIDATE_VALUATION

            else if (
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_ISSUE_VALUATION" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_CONSUME_VALUATION" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "COMPLETE_VALUATION" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_OUTSTAND_VALUATION" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "CONSIDATE_VALUATION" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ABNORMAL_DIFFERENCE"                
               )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    IntOSPcs = 0;
                    DouIssueCarat = 0;
                    DouPolishAmount = 0;
                    DouPolishLabAmount = 0;
                    DouOSCarat = 0;
                    DouConsumeAmount = 0;
                    DouMaterialCost = 0;

                    DouExpPolishCarat = 0;
                    DouExpPolishAmount = 0;

                    DouBanchAmount = 0;
                    DouAmountDollar = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    IntOSPcs = IntOSPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "OS_PCS"));
                    DouOSCarat = DouOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OS_CARAT"));

                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "POLISH_CARAT"));
                    DouExpPolishCarat = DouExpPolishCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_POLISH_CARAT"));

                    DouPolishAmount = DouPolishAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "POLISH_AMOUNT"));
                    DouExpPolishAmount = DouExpPolishAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_POLISH_AMOUNT"));
                    

                    DouPolishLabAmount = DouPolishLabAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "POL_LAB_AMOUNT"));

                    DouMaterialCost = DouMaterialCost + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MATERIAL_COST"));
                    
                    DouConsumeAmount = DouConsumeAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_VALUE"));


                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "BILL_AMOUNT"));
                    DouBanchAmount = DouBanchAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "BENCHMARK_AMOUNT"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POLISH_RATE") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouPolishAmount / DouIssueCarat, 2);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POL_LAB_RATE") == 0)
                    {
                        if (IntOSPcs != 0)
                        {
                            e.TotalValue = Math.Round(DouPolishLabAmount / IntOSPcs, 2);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CONSUME_RATE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouExpPolishCarat / DouOSCarat, 2);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MATERIAL_COST_PER_CARAT") == 0)
                    {
                        if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "CONSIDATE_VALUATION")
                        {
                            if (DouOSCarat != 0)
                            {
                                e.TotalValue = Math.Round(DouConsumeAmount / DouOSCarat, 2);
                            }
                        }
                        else
                        {
                            if (DouOSCarat != 0)
                            {
                                e.TotalValue = Math.Round(DouMaterialCost / DouOSCarat, 2);
                            }
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_POLISH_RATE") == 0)
                    {
                        if (DouExpPolishCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouExpPolishAmount / DouExpPolishCarat, 2);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_POLISH_PER") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouExpPolishCarat / DouOSCarat) * 100, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouIssueCarat / DouOSCarat) * 100, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACTUAL_DIFFERENCE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round(( (DouExpPolishCarat - DouReadyCarat) / DouOSCarat) * 100, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("NET_DIFFERENCE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((((DouExpPolishCarat - DouReadyCarat) / DouOSCarat) * 100) + DouExpDiff, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DIFFERENCE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((((DouReadyCarat - DouExpPolishCarat) / DouOSCarat) * 100) + DouExpDiff, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OS_AVG_SIZE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round(IntOSPcs / DouOSCarat, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("BILL_RATE") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouOSCarat) * 100, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("BENCHMARK_RATE") == 0)
                    {
                        if (DouExpPolishCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouBanchAmount / IntOSPcs) * 100, 2);
                        }
                    }
                }

                /*
                #region Complete Valuation

                if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "COMPLETE_VALUATION")
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        DouOSCarat = 0;
                        IntOSPcs = 0;

                        DouExpPolishCarat = 0;
                        DouExpPolishAmount = 0;

                        DouBanchAmount = 0;
                        DouAmount = 0;

                    }
                    else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        DouOSCarat = DouOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OS_CARAT"));
                        IntOSPcs = IntOSPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "OS_PCS"));

                        DouExpPolishCarat = DouExpPolishCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_POL_CARAT"));
                        DouExpPolishAmount = DouExpPolishAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_POL_AMOUNT"));

                        DouAmount = DouAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "BILL_AMOUNT"));
                        DouBanchAmount = DouBanchAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "BENCHMARK_AMOUNT"));
                    }
                    else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    {
                        if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OS_AVG_SIZE") == 0)
                        {
                            if (DouOSCarat != 0)
                            {
                                e.TotalValue = Math.Round(IntOSPcs / DouOSCarat, 2);
                            }
                        }
                        else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_POL_RATE") == 0)
                        {
                            if (DouExpPolishCarat != 0)
                            {
                                e.TotalValue = Math.Round((DouExpPolishAmount / DouExpPolishCarat) * 100, 2);
                            }

                        }
                        else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("BILL_RATE") == 0)
                        {
                            if (DouOSCarat != 0)
                            {
                                e.TotalValue = Math.Round((DouAmount / DouOSCarat) * 100, 2);
                            }
                        }

                        else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("BENCHMARK_RATE") == 0)
                        {
                            if (DouExpPolishCarat != 0)
                            {
                                e.TotalValue = Math.Round((DouBanchAmount / IntOSPcs) * 100, 2);
                            }
                        }
                    }
                }
                #endregion
                */
            }

            #endregion

            #region OUTSIDE_RECEIPT_TOTAL_ROUGH_TRANSFER

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "OUTSIDE_RECEIPT" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "TOTAL_ROUGH_TRANSFER" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "OUTSIDE_ISSUE" ||
                Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "OUTSIDE_OUTSTANDING"
                )
            {


                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RR_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "RR_CARAT");
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("READY_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "READY_CARAT");
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CONSUME_CARAT_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "CONSUME_CARAT");
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CONSUME_PCS_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "CONSUME_PCS");
                }

                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouAvgProduction = 0;
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;

                    DouOSCarat = 0;
                    DouOSExpCarat = 0;

                    IntIssuePcs = 0;
                    IntConsumePcs = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    IntIssuePcs += Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_PCS"));
                    IntConsumePcs += Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_PCS"));

                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));

                    DouAvgProduction = DouAvgProduction + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AVG_PER_PROD"));

                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouOSCarat = DouOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_CARAT"));
                    DouOSExpCarat = DouOSExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_EXP_PER")) / 100);

                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouConsumeExpCarat = DouConsumeExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_CONS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouIssueExpCarat / DouIssueCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OUTSTAND_EXP_PER") == 0)
                    {
                        if (DouOSCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouOSExpCarat / DouOSCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_CONS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouConsumeExpCarat / DouConsumeCarat) * 100, 3);
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_DAYS") == 0)
                    {
                        if (DouAvgProduction != 0)
                        {
                            e.TotalValue = Math.Round((DouConsumeCarat / DouAvgProduction), 0);
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyCarat / DouPerConsumeCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ISSUE_EXP_DIFF") == 0)
                    {
                        if (e.GroupLevel < 0)
                        {
                            double ExpConsPer = Val.Val(view.Columns["EXP_CONS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                        else
                        {
                            double ExpConsPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_CONS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpConsPer - ExpRecPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ISSUE_SIZE") == 0)
                    {
                        e.TotalValue = DouIssueCarat != 0 ? Math.Round(IntIssuePcs / DouIssueCarat, 3) : 0.00;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("READY_SIZE") == 0)
                    {
                        e.TotalValue = DouReadyCarat != 0 ? Math.Round(IntConsumePcs / DouReadyCarat, 3) : 0.00;
                    }
                }
            }



            #endregion

            #region LABOUR_PERFORMANCE_INSPECTION

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "LABOUR_PERFORMANCE_INSPECTION")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;
                    DouDMCarat = 0;
                    DouFactoryCarat = 0;
                    DouFactoryDMCarat = 0;
                    DouManualCarat = 0;

                    IntConsumePcs = 0;
                    IntMfgOSPcs = 0;
                    DouMFGOSCarat = 0;

                    IntRepOSPcs = 0;
                    IntRepConsume = 0;

                    IntTSOSPcs = 0;
                    IntTSConsume = 0;
                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT

                    DouInsManPer = 0;  //INS_MAN_PER//
                    DouInsDMPer = 0;
                    DouTotalPer = 0;
                    DouInsExptManual = 0; //INS_EXPT_ MAN //
                    DouInsExptDM = 0; //INS_EXP_DM //
                    DouInsExpTotal = 0; //INS_EXP_TOTAL//                 
                    DouManualOrgCarat = 0;
                    DouDMOrgCarat = 0;
                    DouTotalCrt = 0;
                    DouInspDM = 0; //INS_FAC_PER //
                    DouFacExpWt = 0;
                    DouDMExpWt = 0;
                    DouManExpWt = 0;
                    DouInsFacExpCarat = 0;
                    DouManualWTCarat = 0;
                    DouInsDMExpCrt = 0;
                    DouInsDMCarat = 0;
                    DouInspFAC = 0;
                    DouInspMAN = 0;

                    DouInsManualCarat = 0;
                    DouFACOrgCarat = 0;
                    DouFactoryWTCarat = 0;

                    DouDMExpPer = 0;
                    DouMANExpPer = 0;
                    DouDMExpCarat = 0;
                    DouMANExpCarat = 0;
                    DouInsReadyCrt = 0;


                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    /*ADD BY HARESH ON 26-09-2014 FOR TA PCS AND TA CARAT CUSTOM SUMMARY*/
                    IntConsumePcs = IntConsumePcs + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_PCS"));
                    IntMfgOSPcs = IntMfgOSPcs + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MFG_OS_PCS"));
                    DouMFGOSCarat = DouMFGOSCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MFG_OS_CARAT"));

                    IntRepOSPcs = IntRepOSPcs + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "REP_OS_PCS"));
                    IntRepConsume = IntRepConsume + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "REP_CONSUME_PCS"));

                    IntTSOSPcs = IntTSOSPcs + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TS_OS_PCS"));
                    IntTSConsume = IntTSConsume + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TS_CONSUME_PCS"));

                    /*----*/
                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);


                    DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_PER")) / 100);
                    DouFactoryCarat = DouFactoryCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_PER")) / 100);
                    DouManualCarat = DouManualCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_PER")) / 100);
                    DouFactoryDMCarat = DouFactoryDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_DM_PER")) / 100);

                    DouFactoryWTCarat = DouFactoryWTCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_CRT"));
                    DouManualWTCarat = DouManualWTCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_WT_CRT"));

                    DouInsDMCarat = DouInsDMCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_CARAT"));
                    DouInsManualCarat = DouInsManualCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_CARAT")));

                    DouInsDMExpCrt = DouInsDMExpCrt + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_DM_EXP_CRT"));

                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT

                    // DouInsReadyCrt = DouInsReadyCrt + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_READY_CARAT"));


                    DouManualOrgCarat = DouManualOrgCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_ORG_CARAT")));

                    DouFACOrgCarat = DouFACOrgCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_ORG_CARAT")));

                    DouFactoryWTCarat = DouFactoryWTCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_CARAT"));

                    DouDMOrgCarat = DouDMOrgCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_ORG_CARAT")));

                    DouTotalCrt = DouTotalCrt + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_CARAT")));
                    //add by chirag 29-02-16 
                    //                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouInsReadyCrt = DouInsReadyCrt + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_READY_CARAT"));
                    //add by chirag 29-02-16 
                    if ((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_ORG_CARAT"))) != 0)
                    {
                        DouFacExpWt = DouFacExpWt + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_WT_CRT")));   /*INS_FAC_EXP_CRT*/
                    }
                    if ((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_ORG_CARAT"))) != 0)
                    {
                        //   DouDMExpWt = DouDMExpWt + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_CARAT")));
                        DouDMExpWt = DouDMExpWt + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_DM_EXP_CRT")));
                    }
                    DouManExpWt = DouManExpWt + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_MAN_EXP_CRT")));
                    if (DouManualOrgCarat > 0)
                    {
                        DouInsFacExpCarat = DouInsFacExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_ORG_CARAT")));
                    }

                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT

                    //ADD BY HARESH ON 03-FEB-2016
                    DouDMExpCarat = DouDMExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "D_EXP_CARAT")));
                    DouMANExpCarat = DouMANExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "M_EXP_CARAT")));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouExpIssPer = Math.Round((DouIssueExpCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpIssPer;
                        }
                    }
                    // add by chirag 01-02-16
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_EXP_PER") == 0)
                    {
                        if (DouDMOrgCarat != 0)
                        {
                            DouDMExpPer = Math.Round((DouDMExpCarat / DouDMOrgCarat) * 100, 3);
                            e.TotalValue = DouDMExpPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MAN_EXP_PER") == 0)
                    {
                        if (DouManualOrgCarat != 0)
                        {
                            DouMANExpPer = Math.Round((DouMANExpCarat / DouManualOrgCarat) * 100, 3);
                            e.TotalValue = DouMANExpPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_EXP_PER") == 0)
                    {
                        if (DouManualOrgCarat != 0)
                        {
                            DouTotalExpPer = Math.Round((DouMANExpCarat / DouManualOrgCarat) * 100, 3);
                            e.TotalValue = DouTotalExpPer;
                        }
                        else if (DouDMOrgCarat != 0)
                        {
                            DouTotalExpPer = Math.Round((DouDMExpCarat / DouDMOrgCarat) * 100, 3);
                            e.TotalValue = DouTotalExpPer;
                        }
                    }
                    // add by chirag 01-02-16


                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MFG_STOCK_FOR_DAYS_PCS") == 0)
                    {
                        if (IntConsumePcs != 0 && ReceiptDays != 0)
                        {
                            e.TotalValue = Math.Round(IntMfgOSPcs / (IntConsumePcs / ReceiptDays), 2).ToString();
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MFG_STOCK_FOR_DAYS_CARAT") == 0)
                    {
                        if (DouConsumeCarat != 0 && ReceiptDays != 0)
                        {
                            e.TotalValue = Math.Round(DouMFGOSCarat / (DouConsumeCarat / ReceiptDays), 2).ToString();
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REP_STOCK_FOR_DAYS") == 0)
                    {
                        if (IntRepConsume != 0 && ReceiptDays != 0)
                        {
                            e.TotalValue = Math.Round(IntRepOSPcs / (IntRepConsume / ReceiptDays), 2).ToString();
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TS_STOCK_FOR_DAYS") == 0)
                    {
                        if (IntTSConsume != 0 && ReceiptDays != 0)
                        {
                            e.TotalValue = Math.Round(IntTSOSPcs / (IntTSConsume / ReceiptDays), 2).ToString();
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            DouExpRecPer = Math.Round((DouReadyCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }
                    //ADD BY CHIRAG ON 29-02-16 
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_REC_PER") == 0)
                    {
                        if (DouTotalCrt != 0)
                        {
                            DouExpRecPer = Math.Round((DouInsReadyCrt / DouTotalCrt) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }
                    //ADD BY CHIRAG ON 29-02-16 

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_DM_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouFactoryDMCarat / DouPerConsumeCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            DouDMPer = Math.Round((DouDMCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouDMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            DouFactoryPer = Math.Round((DouFactoryCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouFactoryPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            DouManualPer = Math.Round((DouManualCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouManualPer;
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouDMPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["DM_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("DM_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_DIFF") == 0)
                    {
                        // e.TotalValue = DouExpRecPer - DouFactoryPer;

                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["FAC_WT_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("FAC_WT_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouManualPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["MANUAL_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("MANUAL_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouExpIssPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["EXP_ISS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_ISS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                    }
                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT - Start
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_MAN_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouInsManPer = Math.Round(((DouManualOrgCarat * 100) / DouIssueCarat), 3);
                            e.TotalValue = DouInsManPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_DM_PER") == 0)
                    {
                        if (DouDMOrgCarat != 0)
                        {
                            DouInsDMPer = Math.Round((DouDMOrgCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouInsDMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouTotalPer = Math.Round((DouTotalCrt / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouTotalPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXPT_MAN") == 0)
                    {
                        if (DouManualOrgCarat != 0)
                        {
                            //DouInsExptManual = Math.Round((DouInsFacExpCarat * 100) / DouManualOrgCarat, 3);
                            DouInsExptManual = Math.Round((DouFacExpWt * 100) / DouManualOrgCarat, 3);
                            e.TotalValue = DouInsExptManual;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_DM") == 0)
                    {
                        if (DouDMOrgCarat != 0)
                        {
                            DouInsExptDM = Math.Round((DouDMExpWt * 100) / DouDMOrgCarat, 3);
                            e.TotalValue = DouInsExptDM;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_TOTAL") == 0)
                    {
                        if (DouManualOrgCarat + DouDMOrgCarat != 0)
                        {
                            DouInsExpTotal = Math.Round(((DouInsDMExpCrt + DouManualWTCarat) * 100) / (DouManualOrgCarat + DouDMOrgCarat), 3);

                            e.TotalValue = DouInsExpTotal;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_DM") == 0)
                    {
                        if (DouDMOrgCarat != 0)
                        {
                            DouInspDM = Math.Round((DouInsDMExpCrt * 100) / DouDMOrgCarat, 3);

                            e.TotalValue = DouInspDM;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_MAN") == 0)
                    {
                        if (DouManualOrgCarat != 0)
                        {
                            DouInspMAN = Math.Round((DouManualWTCarat * 100) / DouManualOrgCarat, 3);

                            e.TotalValue = DouInspMAN;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_FAC") == 0)
                    {
                        if (DouManualOrgCarat != 0)
                        {
                            DouInspFAC = Math.Round((DouManualWTCarat * 100) / DouManualOrgCarat, 3);

                            e.TotalValue = DouInspFAC;
                        }
                        else if (DouDMOrgCarat != 0)
                        {
                            DouInspFAC = Math.Round((DouInsDMExpCrt * 100) / DouDMOrgCarat, 3);

                            e.TotalValue = DouInspFAC;
                        }
                    }

                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_FAC") == 0)
                    //{
                    //    if (DouFACOrgCarat != 0)
                    //    {
                    //        DouInspFAC = Math.Round((DouFactoryWTCarat * 100) / DouFACOrgCarat, 3);

                    //        e.TotalValue = DouInspFAC;
                    //    }
                    //}
                    // ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT -End

                }
            }

            #endregion

            #region INSPECTION ENTRY

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "INSPECTION_ENTRY")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;
                    DouDMCarat = 0;
                    DouFactoryCarat = 0;
                    DouFactoryDMCarat = 0;
                    DouManualCarat = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);

                    DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_PER")) / 100);
                    DouFactoryCarat = DouFactoryCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_PER")) / 100);
                    DouManualCarat = DouManualCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_PER")) / 100);
                    DouFactoryDMCarat = DouFactoryDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_DM_PER")) / 100);

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouExpIssPer = Math.Round((DouIssueExpCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouExpIssPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouExpRecPer = Math.Round((DouReadyCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_DM_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouFactoryDMCarat / DouIssueCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouDMPer = Math.Round((DouDMCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouDMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouFactoryPer = Math.Round((DouFactoryCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouFactoryPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouManualPer = Math.Round((DouManualCarat / DouIssueCarat) * 100, 3);
                            e.TotalValue = DouManualPer;
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouDMPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["DM_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("DM_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_DIFF") == 0)
                    {
                        // e.TotalValue = DouExpRecPer - DouFactoryPer;

                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["FAC_WT_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("FAC_WT_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouManualPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["MANUAL_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("MANUAL_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouExpIssPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["EXP_ISS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_ISS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                }
            }

            #endregion

            #region MACHINE_PRODUCTION

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MACHINE_PRODUCTION")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouIssueCarat = 0;
                    DouLossCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouLossCarat = DouLossCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "LOSS_CARAT"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_LOSS") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouLossCarat / DouIssueCarat) * 100, 2);
                        }
                        else
                        {
                            e.TotalValue = 0;
                        }
                    }
                }
            }
            #endregion

            #region MACHINE_WORK_DOWN / MACHINE_DOWN

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MACHINE_WORK_DOWN" || Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MACHINE_DOWN")
            {
                if (

                ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DOWN_HOURS") == 0
                ||
                ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CUT_TIME_HOURS") == 0
                ||
                ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("WORK_HOURS") == 0
                ||
                ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACTUAL_HOURS") == 0
                )
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        DouAnswer = 0;
                    }
                    else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        DouAnswer += Val.Val(e.FieldValue);

                        if (DouAnswer == 0)
                        {
                            e.TotalValue = "0.00";
                        }
                        else
                        {

                            string[] parts = DouAnswer.ToString("########0.00").Split('.');
                            int i1 = Val.ToInt(parts[0]);
                            int i2 = Val.ToInt(parts[1]);

                            while (i2 > 60)
                            {
                                i1 = i1 + 1;
                                i2 = i2 - 60;
                            }
                            double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                            DouAnswer = answer;
                        }
                    }
                    else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    {
                        /*
                        if (DouAnswer == 0)
                        {
                            e.TotalValue = "0.00";
                        }
                        else
                        {
                            string[] parts = DouAnswer.ToString("########0.00").Split('.');
                            int i1 = Val.ToInt(parts[0]);
                            int i2 = Val.ToInt(parts[1]);

                            while (i2 > 60)
                            {
                                i1 = i1 + 1;
                                i2 = i2 - 60;
                            }
                            double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                            e.TotalValue = answer;
                        }*/
                        e.TotalValue = DouAnswer;
                    }
                }

                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("WORK_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "DOWN_HOURS");
                }

            }

            #endregion

            #region MFG_BROKEN_PCS

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MFG_BROKEN_PCS")
            {
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CARAT_PER") == 0)
                {
                    GetGroupRowPercentage(sender, e, "CARAT");
                }
            }

            #endregion

            #region PROCESS TRASNFER FOR FACTORY
            //add by chirag - 17-02-16

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PROCESS_TRANSFER_REPORT"
                )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouIssueCarat = 0;
                    DouIssueExpCarat = 0;
                    DouConsumeCarat = 0;
                    DouDMCarat = 0;
                    DouProcessReadyCarat = 0;
                    DouPreviousCarat = 0;
                    DouReadyCarat = 0;

                    DouExpCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouExpCarat = DouExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_PER")) / 100);
                    DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DMEXP_PER")) / 100);

                    DouProcessReadyCarat = DouProcessReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PROC_READY_CARAT"));
                    DouPreviousCarat = DouPreviousCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREV_CARAT"));


                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round(((DouExpCarat * 100) / DouIssueCarat), 3);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DMEXP_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round(((DouDMCarat * 100) / DouIssueCarat), 3);
                            //                            e.TotalValue = Math.Round((DouDMCarat / DouIssueCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PROC_REC") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyCarat / DouPreviousCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                        }
                    }
                }
            }

            #endregion

            #region POLISH PROCESS TRASNFER FOR FACTORY

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PROCESS_TRANSFER"
                )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouIssueCarat = 0;
                    DouIssueExpCarat = 0;
                    DouDMCarat = 0;
                    DouProcessReadyCarat = 0;
                    DouPreviousCarat = 0;
                    DouReadyCarat = 0;
                    DouConsumeCarat = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));

                    DouProcessReadyCarat = DouProcessReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PROC_READY_CARAT"));
                    DouPreviousCarat = DouPreviousCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREV_CARAT"));

                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));

                    DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_PER")) / 100);
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouIssueExpCarat / DouIssueCarat) * 100, 3);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouDMCarat / DouIssueCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PROC_REC") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouProcessReadyCarat / DouPreviousCarat) * 100, 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                        }
                    }
                }
            }

            #endregion

            #region POLISH TRANSFER FOR FACTORY

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "POLISH_TRANSFER")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;
                    DouDMCarat = 0;
                    DouFactoryCarat = 0;
                    DouFactoryDMCarat = 0;
                    DouManualCarat = 0;
                    DouFactoryWTCarat = 0;
                    DouInsFExpCarat = 0;

                    DouExpDiff = 0;
                    DouInspectionDiff = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouFactoryWTCarat = DouFactoryWTCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_CARAT"));
                    DouInsFExpCarat = DouInsFExpCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "INS_F_EXP_CARAT"));

                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);

                    DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_PER")) / 100);
                    DouFactoryCarat = DouFactoryCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_PER")) / 100);
                    DouManualCarat = DouManualCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_PER")) / 100);
                    DouFactoryDMCarat = DouFactoryDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_DM_PER")) / 100);

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouIssueCarat != 0)
                        {
                            DouExpIssPer = Math.Round((DouIssueExpCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpIssPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouExpRecPer = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouExpRecPer = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_DM_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouFactoryDMCarat / DouConsumeCarat) * 100, 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouDMPer = Math.Round((DouDMCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouDMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_PER") == 0)
                    {
                        if (DouReadyCarat != 0)
                        {
                            DouFactoryPer = Math.Round((DouFactoryWTCarat / DouReadyCarat) * 100, 3);
                            e.TotalValue = DouFactoryPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_F_EXP_PER") == 0)
                    {
                        if (DouReadyCarat != 0)
                        {
                            DouFactoryPer = Math.Round((DouInsFExpCarat / DouReadyCarat) * 100, 3);
                            e.TotalValue = DouFactoryPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXPECTED_DIFF") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouExpDiff = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3) - Math.Round((DouIssueExpCarat / DouConsumeCarat) * 100, 3);
                            //DouExpDiff = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3) - Math.Round((DouIssueExpCarat / DouIssueCarat) * 100, 3);  --03-06-2016 Done by chirag
                            e.TotalValue = DouExpDiff;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_F_EXP_DIFF") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouInspectionDiff = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3) - Math.Round((DouInsFExpCarat / DouReadyCarat) * 100, 3);
                            e.TotalValue = DouInspectionDiff;
                        }
                    }    


                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            DouManualPer = Math.Round((DouManualCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouManualPer;
                        }
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouDMPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["DM_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("DM_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_DIFF") == 0)
                    {
                        // e.TotalValue = DouExpRecPer - DouFactoryPer;

                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["FAC_WT_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("FAC_WT_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouManualPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["MANUAL_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("MANUAL_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC_DIFF") == 0)
                    {
                        //e.TotalValue = DouExpRecPer - DouExpIssPer;
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["EXP_ISS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = ExpRecPer - DMPer;
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_ISS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = ExpRecPer - DMPer;
                        }

                    }
                }
            }

            #endregion

            #region ROUGH TO ROUGH TRANSFER

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ROUGH_TRANSFER"
               )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouRoughCarat = 0;
                    DouRoughAmount = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouRoughCarat = DouRoughCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CRTS"));

                    DouRoughAmount = DouRoughAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_DOLLAR"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        if (DouRoughCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouRoughAmount / DouRoughCarat), 3);
                        }
                    }
                }
            }


            #endregion

            #region PROCESS REJECTION LESS DATA

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ROUGH_PRL"
               )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouRoughCarat = 0;
                    DouRoughAmount = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouRoughCarat = DouRoughCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT"));

                    DouRoughAmount = DouRoughAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        if (DouRoughCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouRoughAmount / DouRoughCarat), 3);
                        }
                    }
                }
            }


            #endregion

            #region Rough Summary Pivot Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ASSORT_PARAMETER"
               )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouAssortMentCarat = 0;
                    DouAssortMentAmount = 0;
                    IntAssortMentPcs = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouAssortMentCarat = DouAssortMentCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"));
                    DouAssortMentAmount = DouAssortMentAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));
                    IntAssortMentPcs = IntAssortMentPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "PCS"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        if (DouAssortMentCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouAssortMentAmount / DouAssortMentCarat), 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_SIZE") == 0)
                    {
                        if (DouAssortMentCarat != 0)
                        {
                            e.TotalValue = Math.Round((IntAssortMentPcs / DouAssortMentCarat), 3);
                        }
                    }

                }
            }


            #endregion

            // Add By Khushbu 16/06/2014

            // ----------------- //

            #region Purchase Transfer Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "TEAM_TRANSFER")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0;
                    DouAmountDollar = 0;
                    //   DouPremCarat = 0;
                    DouPremAmountDollar = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT"));

                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));

                   // DouPremAmount = DouPremAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREM_AMOUNT_DOLLAR"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_DOLLAR") == 0)
                    {
                        if (DouCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouCarat), 3);
                        }
                    }

                    // Comment By Khushbu 05/11/2014
                    //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PREM_RATE_DOLLAR") == 0)
                    //{
                    //    if (DouCarat != 0)
                    //    {
                    //        e.TotalValue = Math.Round((DouPremAmount / DouCarat), 3);
                    //    }
                    //}
                }
            }


            #endregion

            #region Rough Lot Detail Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ROUGH_LOT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0;
                    DouAmountDollar = 0;
                    DouPremAmountDollar = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));

                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));

                    DouPremAmountDollar = DouPremAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREM_AMOUNT_DOLLAR"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_DOLLAR") == 0)
                    {
                        if (DouCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouCarat), 3);
                        }
                    }
                }

                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PREM_RATE_DOLLAR") == 0)
                {
                    if (DouCarat != 0)
                    {
                        e.TotalValue = Math.Round((DouPremAmountDollar / DouCarat), 3);
                    }
                }

            }


            #endregion

            #region Purchase Import Full Detail Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PREM_DETAIL"
                || Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PREM_SUMMARY"
                || Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "SALE_EXPORT"
                || Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BRANCH_TRANSFER"
                )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0;
                    DouAmountDollar = 0;
                    DouAmountLocal = 0;
                    DouAmountPurchase = 0;

                    DouPremAmountDollar = 0;
                    DouPremAmountLocal = 0;
                    DouPremAmountPurchase = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT"));

                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_DOLLAR"));
                    DouAmountLocal = DouAmountLocal + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_LOCAL"));
                    DouAmountPurchase = DouAmountPurchase + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_PURCHASE"));
                    DouAmountPurchase = DouAmountPurchase + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_SALE"));


                    DouPremAmountDollar = DouPremAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREM_AMOUNT_DOLLAR"));
                    DouPremAmountLocal = DouPremAmountLocal + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREM_AMOUNT_LOCAL"));
                    DouPremAmountPurchase = DouPremAmountPurchase + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PREM_AMOUNT_PURCHASE"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_DOLLAR") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouAmountDollar / DouCarat), 10);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PREM_RATE_DOLLAR") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouPremAmountDollar / DouCarat), 10);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_LOCAL") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouAmountLocal / DouCarat), 10);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PREM_RATE_LOCAL") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouPremAmountLocal / DouCarat), 10);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_PURCHASE") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouAmountPurchase / DouCarat), 10);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_SALE") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouAmountPurchase / DouCarat), 10);
                    }


                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PREM_RATE_PURCHASE") == 0)
                    {
                        e.TotalValue = DouCarat == 0 ? 0 : Math.Round((DouPremAmountPurchase / DouCarat), 10);
                    }
                }
            }


            #endregion

            #region Employee Efficiency Report

            // Khushbu 25/06/2014 
            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "EMP_COST_HOUR")
            {
                //if ( ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("HOURS") == 0 )
                //{
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouAnswer = 0;
                    DouCarat = 0;
                    DouStandardCarat = 0;
                    DouTotalIdleHour = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    string[] StrHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "HOURS")).ToString("########0.00").Split('.');
                    DouAnswer = DouAnswer + (Val.Val(StrHour[0]) * 60) + (Val.Val(StrHour[1]));

                    string[] StrIdleHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "IDLE_TIME")).ToString("########0.00").Split('.');
                    DouTotalIdleHour = DouTotalIdleHour + (Val.Val(StrIdleHour[0]) * 60) + (Val.Val(StrIdleHour[1]));

                    DouStandardCarat = DouStandardCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "STANDARD_CARAT"));
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT_DONE"));

                    /*if (DouAnswer == 0)
                    {
                        e.TotalValue = "0.00";
                    }
                    else
                    {

                        string[] parts = DouAnswer.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouAnswer = answer;
                    }

                    
                    if (DouTotalIdleHour == 0)
                    {
                        e.TotalValue = "0.00";
                    }
                    else
                    {
                        string[] parts = DouTotalIdleHour.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouTotalIdleHour = answer;
                    }*/
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    double DouSHour = Global.FindHHMMFormat(DouAnswer);
                    double DouSTotalIdleHour = Global.FindHHMMFormat(DouTotalIdleHour);  

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("HOURS") == 0)
                    {
                        e.TotalValue = DouSHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_STANDARD_HOURS") == 0)
                    {
                        e.TotalValue = DouCarat / DouStandardCarat;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("STANDARD_DAY") == 0)
                    {
                        e.TotalValue = ((DouCarat / DouStandardCarat) / 9);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("IDLE_TIME") == 0)
                    {
                        e.TotalValue = DouSTotalIdleHour;
                    }
                }

            }

            #endregion

            #region Employee Activity And Size Wise Report

            // Narendra : 23/07/2014
            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ACTIVITY_SIZE")
            {
                //if ( ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("HOURS") == 0 )
                //{
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouHour = 0;
                    DouCaratDone = 0;
                    DouStdCarat = 0;

                    DouOTHour = 0;
                    DouOTCarat = 0;

                    DouTotalHour = 0;
                    DouTotalCarat = 0;
                    DouTotalIdleHour = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                     //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.Equals("HOURS"))
                    RecCount = Math.Abs(e.GroupRowHandle);

                    DouCaratDone = DouCaratDone + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT_DONE"));
                    DouStdCarat = DouStdCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "STD_CARAT"));
                    DouOTCarat = DouOTCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OT_CARAT"));
                    DouTotalCarat = DouTotalCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_CARAT"));

                    string []StrHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "HOURS")).ToString("########0.00").Split('.');
                    DouHour = DouHour + (Val.Val(StrHour[0]) * 60) + (Val.Val(StrHour[1]));

                    string[] StrOTHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OT_HOUR")).ToString("########0.00").Split('.');
                    DouOTHour = DouOTHour + (Val.Val(StrOTHour[0]) * 60 ) + (Val.Val(StrOTHour[1]) );

                    string[] StrTotalHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_HOURS")).ToString("########0.00").Split('.');
                    DouTotalHour = DouTotalHour + (Val.Val(StrTotalHour[0]) * 60 ) + (Val.Val(StrTotalHour[1]) );

                    string[] StrIdleHour = Val.Val(GridView1.GetRowCellValue(e.RowHandle, "IDLE_TIME")).ToString("########0.00").Split('.');
                    DouTotalIdleHour = DouTotalIdleHour + (Val.Val(StrIdleHour[0]) * 60 ) + (Val.Val(StrIdleHour[1]) );

                    /*
                    DouHour =  DouHour + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "HOURS"));
                    DouOTHour = DouOTHour + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OT_HOUR"));
                    
                    DouTotalHour = DouTotalHour + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_HOURS"));
                    DouTotalIdleHour = DouTotalIdleHour + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "IDLE_TIME"));

                    if (DouHour == 0)
                    {
                        e.TotalValue = "0.00";
                    }
                    else
                    {

                        string[] parts = DouHour.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouHour = answer;
                    }

                    if (DouTotalIdleHour == 0)
                    {
                        e.TotalValue = "0.00";
                    }
                    else
                    {
                        string[] parts = DouTotalIdleHour.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouTotalIdleHour = answer;
                    }

                    if (DouOTHour == 0)
                    {
                        //e.TotalValue = "0.00";
                    }
                    else
                    {

                        string[] parts = DouOTHour.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouOTHour = answer;
                    }

                    if (DouTotalHour == 0)
                    {
                        //e.TotalValue = "0.00";
                    }
                    else
                    {

                        string[] parts = DouTotalHour.ToString("########0.00").Split('.');
                        int i1 = Val.ToInt(parts[0]);
                        int i2 = Val.ToInt(parts[1]);

                        while (i2 > 60)
                        {
                            i1 = i1 + 1;
                            i2 = i2 - 60;
                        }
                        double answer = Val.Val(i1.ToString() + "." + ((i2 < 10) == true ? "0" + i2.ToString() : i2.ToString()));
                        DouTotalHour = answer;
                    }*/
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    //TimeSpan tHour = TimeSpan.FromMinutes(DouHour);
                    double DouSHour = Global.FindHHMMFormat(DouHour);  
                    //double DouSHour = Val.Val(string.Format("{0:D2}.{1:D2}", Convert.ToInt32(tHour.TotalHours), Convert.ToInt32(tHour.Minutes)));

                    //TimeSpan tIdleHour = TimeSpan.FromMinutes(DouTotalIdleHour);
                    double DouSTotalIdleHour = Global.FindHHMMFormat(DouTotalIdleHour);  

                    //TimeSpan tOTHour = TimeSpan.FromMinutes(DouOTHour);
                    double DouSOTHour = Global.FindHHMMFormat(DouOTHour);  

                    //TimeSpan tTotalHour = TimeSpan.FromMinutes(DouTotalHour);
                    double DouSTotalHour = Global.FindHHMMFormat(DouTotalHour);  
                    
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("HOURS") == 0)
                    {
                        e.TotalValue = DouSHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("IDLE_TIME") == 0)
                    {
                        e.TotalValue = DouSTotalIdleHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CARAT_AVG") == 0)
                    {
                        // Modify : Narendra : 29-07-2014
                        //double TotMinute=0;
                        //if (DouHour > 0)
                        //{
                        //    var timeSpan = TimeSpan.FromSeconds(DouSHour);
                        //    int hh = timeSpan.Hours;
                        //    double mm = (DouSHour - timeSpan.Hours) * 100;
                        //    TotMinute = (hh * 60) + mm;
                        //    e.TotalValue = (DouCaratDone / TotMinute) * 60;
                        //}
                        //else
                        //    e.TotalValue = "0.00";

                        //ADD BY HARESH ON 16-DEC-2014
                        if (DouSHour != 0)
                        {
                            e.TotalValue = DouCaratDone / DouSHour;
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("STD_CARAT") == 0)
                    {
                        e.TotalValue = DouStdCarat / RecCount;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("NORMAL_VARIATION") == 0)
                    {
                        e.TotalValue = DouCaratDone - ( (DouStdCarat / RecCount) * DouSHour);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OT_HOUR") == 0)
                    {
                        e.TotalValue = DouSOTHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("STD_HOURS") == 0)
                    {
                        if (DouStdCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouCaratDone / DouStdCarat, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OT_HOURS") == 0)
                    {
                        if (DouStdCarat != 0)
                        {
                            e.TotalValue = Math.Round(DouOTCarat / DouStdCarat, 2);
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OT_CARAT_AVG") == 0)
                    {
                        //ADD BY HARESH ON 16-DEC-14
                        if (DouSOTHour != 0)
                        {
                            e.TotalValue = DouOTCarat / DouSOTHour;
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OT_NORMAL_VARIATION") == 0)
                    {
                        e.TotalValue = DouOTCarat - ( (DouStdCarat / RecCount) * DouSOTHour);
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_HOURS") == 0)
                    {
                        e.TotalValue = DouSTotalHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_CARAT") == 0)
                    {
                        e.TotalValue = DouTotalCarat;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CARAT_PER_HOURS") == 0)
                    {
                        e.TotalValue = DouTotalCarat / DouSTotalHour;
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOT_VAR") == 0)
                    {
                        e.TotalValue = DouTotalCarat - ( (DouStdCarat / RecCount) * DouSTotalHour);
                    }


                   // }
                }

            }

            #endregion

            #region Asset Issue Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ASSET_ISSUE")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouQuantity = 0;
                    DouAmountDollar = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouQuantity = DouQuantity + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "QTY"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        if (DouQuantity != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouQuantity), 3);
                        }
                    }
                }
            }
            #endregion

            #region Asset Return Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ASSET_RETURN")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouQuantity = 0;
                    DouAmountDollar = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouQuantity = DouQuantity + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "QTY"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        if (DouQuantity != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouQuantity), 3);
                        }
                    }
                }
            }
            #endregion

            #region Production Wages Report

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "PRODUCTION_WAGES")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouAttendance = 0;
                    DouWorkingDays = 0;
                    IntProductionPcs = 0;
                    DouProductionAmount = 0.00;
                    IntExtraPcs = 0;
                    DouExtraAmount = 0.00;
                    IntTotalPcs = 0;
                    DouTotalAmount = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouAttendance = DouAttendance + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ATTEND")); ;
                    DouWorkingDays = DouWorkingDays + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WORKING_DAYS")); ;

                    IntProductionPcs = IntProductionPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "PRODUCTION_PCS"));
                    DouProductionAmount = DouProductionAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PRODUCTION_AMT"));

                    IntExtraPcs = IntExtraPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "EXTRA_PCS"));
                    DouExtraAmount = DouExtraAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXTRA_AMT"));

                    IntTotalPcs = IntTotalPcs + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_PCS"));
                    DouTotalAmount = DouTotalAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_AMT"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PRODUCTION_AVG_RATE") == 0)
                    {
                        if (IntProductionPcs != 0)
                        {
                            e.TotalValue = Math.Round((DouProductionAmount / IntProductionPcs), 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_EMP") == 0)
                    {
                        if (DouWorkingDays != 0)
                        {
                            e.TotalValue = Math.Round((DouAttendance / DouWorkingDays), 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXTRA_AVG_RATE") == 0)
                    {
                        if (IntExtraPcs != 0)
                        {
                            e.TotalValue = Math.Round((DouExtraAmount / IntExtraPcs), 3);
                        }
                    }
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_AVG_RATE") == 0)
                    {
                        if (IntTotalPcs != 0)
                        {
                            e.TotalValue = Math.Round((DouTotalAmount / IntTotalPcs), 3);
                        }
                    }
                }
            }
            #endregion
                
            #region PURCHASE BRANCH TRANSFER

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "BRANCH_TRANSFER")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouQuantity = 0;
                    DouAmountDollar = 0;

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouQuantity = DouQuantity + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_DOLLAR"));
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_DOLLAR") == 0)
                    {
                        if (DouQuantity != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouQuantity), 3);
                        }
                    }
                }
            }
            #endregion

            #region Realization Report

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "REAL_SUM")
            {
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CARAT_PER") == 0)
                {
                   GetGroupRowPercentage(sender, e, "CARAT");
                }

                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0;
                    DouFromCarat = 0;
                    DouAmountDollar = 0;
                    DouFromAmount = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARAT"));
                    DouFromCarat = DouFromCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FROM_CARAT"));

                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));
                    DouFromAmount = DouFromAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FROM_AMOUNT"));

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CP") == 0)
                    {
                        if (DouCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouAmountDollar / DouCarat), 3);
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FROM_CP") == 0)
                    {
                        if (DouFromCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouFromAmount / DouFromCarat), 3);
                        }
                    }
                }
            }

            //else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "REAL_SUM")
            //{
                

            //}

            #endregion

            #region Quality Monitor Report
            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "QUALITY_MONITOR")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouWTRank = 0.00;
                    DouCarat = 0.00;
                    DouWP = 0.00;
                    
                    DouOverAllCutting1 = 0.00;
                    DouOverAllCutting = 0.00;

                    DouOverAllFinishing = 0.00;
                    DouOverAllFinishing1 = 0.00;

                    DouWTPer = 0.00;
                    DouWTPer1 = 0.00;

                    DouWP2 = 0.00;
                    DouWP21 = 0.00;

                    DouWTRank2 = 0.00;
                    DouWTRank21 = 0.00;
                    DouOverCut2 = 0.00;
                    DouOf2 = 0.00;

                    DouOVERALLCUTGRP3 = 0.00;
                    
                    DouOVERALLFINISHGRP3 = 0.00;
                    DouPurityGR3 = 0.00;
                    DouQualityPer = 0.00;
                    DouQualityPer1 = 0.00;

                    DouProd3 = 0.00;
                    DouProd31 = 0.00;

                    DouProduction = 0.00;
                    IntCapacity = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouWTRank = DouWTRank + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WT_RANK"));
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"));

                    DouOverAllCutting = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OVER_ALL_CUT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"))),3);
                    DouOverAllCutting1 = DouOverAllCutting1 + DouOverAllCutting;

                    DouOverAllFinishing = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OVER_ALL_FINISH")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"))),3);
                    DouOverAllFinishing1 = DouOverAllFinishing1 + DouOverAllFinishing;

                    DouWTPer = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WT_PER")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"))),3);
                    DouWTPer1 = DouWTPer1 + DouWTPer;

                    DouWP = Math.Round(Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WEAK_CLARITY_CODE")),3);
                    DouWP2 = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WEAK_CLARITY_CODE")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"))),3);
                    DouWP21 = DouWP21 + DouWP2;

                    DouWTRank2 = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "WT_RANK")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CARATS"))),3);
                    DouWTRank21 = DouWTRank21 + DouWTRank2;

                    DouProduction = DouProduction +Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PRODUCTION"));
                    IntCapacity = IntCapacity + Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "CAPACITY"));

                    if ( Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CAPACITY")) !=0)
                    {
                        //DouProd3 = Math.Round((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PRODUCTION")) / Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CAPACITY")) * 100), 3);
                        DouProd3 = Math.Round((DouProduction / IntCapacity * 100), 2);
                        DouProd31 = DouProd3;    
                    }
                    
                    DouOverCut2 = DouOverCut2 +Math.Round(DouOverAllCutting1 / DouCarat, 3);

                    DouOf2 = DouOf2 + Math.Round(DouOverAllFinishing1 / DouCarat, 3);

                    if (GridView1.GetRowCellValue(e.RowHandle, "PURITYN").ToString() == "A" || GridView1.GetRowCellValue(e.RowHandle, "PURITYN").ToString() == "B")
                    {
                        DouOVERALLCUTGRP3 = (DouOverCut2 * 25) / 100;
                    }

                    else if (GridView1.GetRowCellValue(e.RowHandle, "PURITYN").ToString() == "C"
                             || GridView1.GetRowCellValue(e.RowHandle, "PURITYN").ToString() == "D"
                             || GridView1.GetRowCellValue(e.RowHandle, "PURITYN").ToString() == "E")
                    {
                        DouOVERALLCUTGRP3 = (DouOverCut2 * 10) / 100;
                    }
                    
                    DouOVERALLFINISHGRP3 = Math.Round((DouOf2 * 10) / 100,3);
                    DouPurityGR3 = Math.Round((DouWP * 40) / 100,3);

                    DouQualityPer = (100 - Math.Round((DouOVERALLCUTGRP3 + DouOVERALLFINISHGRP3 + DouPurityGR3 + DouWTRank), 3));
                    DouQualityPer1 = DouQualityPer;

                    DouResult = (DouQualityPer1 + DouProd31) / 2;
                    // RANK CUSTOM FORMULA

                    if (DouQualityPer >=95)
                    {
                        StrRank = GridView1.GetRowCellValue(e.RowHandle, "PURITYN") + "A";
                    }
                    else if (DouQualityPer < 95 && DouQualityPer >=87)
                    {
                        StrRank = GridView1.GetRowCellValue(e.RowHandle, "PURITYN") + "B";
                    }
                    else if (DouQualityPer < 87 && DouQualityPer >= 80)
                    {
                        StrRank = GridView1.GetRowCellValue(e.RowHandle, "PURITYN") + "C";
                    }
                    else if (DouQualityPer < 80 && DouQualityPer >= 70)
                    {
                        StrRank = GridView1.GetRowCellValue(e.RowHandle, "PURITYN") + "D";
                    }
                    else if (DouQualityPer < 70)
                    {
                        StrRank = GridView1.GetRowCellValue(e.RowHandle, "PURITYN") + "E";
                    }

                    // ACTION CUSTOM FORMULA
                    if (StrRank == "AA" || StrRank =="BA" || StrRank =="CA" || StrRank =="DA" || StrRank =="EA")
                    {
                        StrAction = "To Promote";
                    }

                    else if (StrRank == "AB" || StrRank == "BB" || StrRank == "CB" || StrRank == "DB" || StrRank == "EB")
                    {
                        StrAction = "Ok";
                    }
                    else if (StrRank == "AC" || StrRank == "BC" || StrRank == "CC" || StrRank == "DC" || StrRank == "EC")
                    {
                        StrAction = "Improvement";
                    }
                    else if (StrRank == "AD" || StrRank == "BD" || StrRank == "CD" || StrRank == "DD" || StrRank == "ED")
                    {
                        StrAction = "Worning/Stop";
                    }
                    if (StrRank == "AE" || StrRank == "BE" || StrRank == "CE" || StrRank == "DE" || StrRank == "EE")
                    {
                        StrAction = "CLOSE";
                    }
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("QUALITY_PER") == 0)
                    {
                        if (DouCarat != 0)
                        {
                            e.TotalValue = DouQualityPer1;
                        }
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RANK") == 0)
                    {
                        e.TotalValue = StrRank;
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OVER_ALL_CUT") == 0)
                    {
                        e.TotalValue = DouOverAllCutting1 / DouCarat;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OVER_ALL_FINISH") == 0)
                    {
                        e.TotalValue = DouOverAllFinishing1 / DouCarat;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("WT_PER") == 0)
                    {
                        e.TotalValue = DouWTPer1 / DouCarat;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("WT_RANK") == 0)
                    {
                        e.TotalValue = DouWTRank21 / DouCarat;
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("WEAK_CLARITY_CODE") == 0)
                    {
                        e.TotalValue = DouWP21 / DouCarat;
                    }

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ACTION") == 0)
                    {
                        e.TotalValue = StrAction;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PROD1") == 0)
                    {
                        e.TotalValue = DouProd31;
                    }
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RESULT") == 0)
                    {
                        e.TotalValue = DouResult;
                    }

                }
            }
            #endregion

            #region Inspection Outstanding  

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "INSPECTION_OS") //Add By Khushbu 21/11/2014
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouSaleCarat = 0;
                    DouSaleAmount = 0;                 
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouSaleCarat = DouSaleCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OS_CARAT"));

                    DouSaleAmount = DouSaleAmount + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT_DOLLAR"));

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE_DOLLAR") == 0)
                    {
                        if (DouSaleCarat != 0)
                        {
                            e.TotalValue = Math.Round((DouSaleAmount /Math.Abs(DouSaleCarat)), 3);
                        }
                    }
               
                }
            }


            #endregion

            #region OUTSTANDING VALUATION

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "VALUATION_OUTSTAND")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0.00;
                    DouAmountDollar = 0.00;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_CARAT"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "OUTSTAND_AMOUNT"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("OUTSTAND_RATE") == 0)
                    {
                        e.TotalValue = DouAmountDollar / DouCarat;
                    }
                }

            }
            #endregion

            //ADD BY SANDIP

            #region ISSUE DEPARTMENT VALUATION

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "ISSUE_DEPARTMENT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0.00;
                    DouAmountDollar = 0.00;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CLOSING_CARAT"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CLOSING_AMOUNT"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MATERIAL_RATE") == 0)
                    {
                        e.TotalValue = DouAmountDollar / DouCarat;
                    }
                }

            }
            #endregion

            //END BY SANDIP

            #region ISSUE VALUATION

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "VALUATION_ISSUE")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0.00;
                    DouAmountDollar = 0.00;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AMOUNT"));
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RATE") == 0)
                    {
                        e.TotalValue = DouAmountDollar / DouCarat;
                    }
                }
            }
            #endregion

            //add by chirag - 02-03-16

            #region ABSENTISM REPORT

            else if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "HR_ABSENTISM_REPORT"
                )
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    //absentism report add by chirag - 02-03-16 
                    DouTotalDays = 0; //TOTAL_DAYS
                    DouAbsentDays = 0; //ABSENT_DAYS
                    DouAbsentPercentage = 0; // formula
                    DouTotalManDays = 0; //TOTAL_MANDAYS
                    DouTotalPresentMandays = 0;  //TOTALPRESENT_MANDAYS
                    DouAbsentPercentMandays = 0; //ABSENTPERCENT_MANDAYS
                    DouPresentPercentMandays = 0; //PRESENTPERCENT_MANDAYS
                    DouMandaysPrs = 0;
                    //absentism report add by chirag - 02-03-16 

                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouTotalDays = DouTotalDays + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_DAYS"));
                    DouAbsentDays = DouAbsentDays + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ABSENT_DAYS"));
                    DouTotalPresentMandays = DouTotalPresentMandays + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTALPRESENT_MANDAYS"));
                    DouMandaysPrs = DouMandaysPrs + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PRESENTPERCENT_MANDAYS"));
                    DouTotalManDays = DouTotalManDays + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS"));
                    if ((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_DAYS"))) != 0 || (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ABSENT_DAYS"))) != 0)
                    {
                        DouAbsentPercentage = DouAbsentPercentage + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ABSENT_DAYS")) / Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_DAYS")) * 100);
                    }
                    if ((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS"))) != 0 || (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTALPRESENT_MANDAYS"))) != 0)
                    {
                        DouAbsentPercentMandays = DouAbsentPercentMandays + (((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS")) - Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTALPRESENT_MANDAYS"))) / Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS"))) * 100);
                    }
                    if ((Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS"))) != 0 || (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTALPRESENT_MANDAYS"))) != 0)
                    {
                        DouPresentPercentMandays = DouPresentPercentMandays + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTALPRESENT_MANDAYS")) / Val.Val(GridView1.GetRowCellValue(e.RowHandle, "TOTAL_MANDAYS")) * 100);
                    }
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ABSENT_PERCENT") == 0)
                    {
                        if (DouAbsentDays != 0 || DouTotalDays != 0)
                        {
                            DouAbsentPercentage = Math.Round(((DouAbsentDays / DouTotalDays) * 100), 3);
                            e.TotalValue = DouAbsentPercentage;
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ABSENTPERCENT_MANDAYS") == 0)
                    {
                        if (DouTotalManDays != 0 || DouTotalPresentMandays != 0)
                        {
                            DouAbsentPercentMandays = Math.Round((((DouTotalManDays - DouTotalPresentMandays) / DouTotalManDays) * 100), 3);
                            e.TotalValue = DouAbsentPercentMandays;
                        }
                    }

                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("PRESENTPERCENT_MANDAYS") == 0)
                    {
                        if (DouTotalManDays != 0 || DouTotalPresentMandays != 0)
                        {
                            DouPresentPercentMandays = Math.Round(((DouTotalPresentMandays / DouTotalManDays) * 100), 3);
                            e.TotalValue = DouPresentPercentMandays;
                        }
                    }
                }
            }

            #endregion    

            #region Manual Valuatio Report Entry

            if (Val.ToString(ObjReportDetailProperty.Remark).ToUpper() == "MANUAL_ROUGH_SUMMARY_REPORT")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouCarat = 0.00;
                    DouAmountDollar = 0.00;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    //DouCarat = DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouCarat = Math.Round(DouCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT")), 2, MidpointRounding.AwayFromZero);
                    //DouAmountDollar = DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ASSORTMENTAMOUNT"));
                    DouAmountDollar = Math.Round(DouAmountDollar + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ASSORTMENTAMOUNT")), 0, MidpointRounding.AwayFromZero);
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ASSORTMENTRATE") == 0)
                    {
                        e.TotalValue = Math.Round(DouAmountDollar / DouCarat, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            #endregion

        }

        #endregion

        public double GenerateTimeFieldSummry(GridView view, string Field)
        {
            if (view == null) return 0;

            if (Val.ToString(Field) == "") return 0;

            GridColumn TimetCol = view.Columns[Field];

            if (TimetCol == null) return 0;

            try
            {
                double totalWeight = 0;

                for (int i = 0; i < view.DataRowCount; i++)
                {
                    if (view.IsNewItemRow(i)) continue;

                    object temp;

                    double weight;

                    if (view.IsGroupRow(i))
                    {
                        temp = view.GetRowCellValue(i, TimetCol);
                    }
                    else
                    {
                        temp = view.GetRowCellValue(i, TimetCol);
                    }

                    temp = view.GetRowCellValue(i, TimetCol);

                    weight = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);

                    totalWeight += weight;

                }

                if (totalWeight == 0) return 0;

                string[] parts = totalWeight.ToString().Split('.');
                int i1 = Val.ToInt(parts[0]);
                int i2 = Val.ToInt(parts[1]);

                while (i2 > 60)
                {
                    i1 = i1 + 1;
                    i2 = i2 - 60;
                }

                return Val.Val(i1.ToString() + "." + i2.ToString());

            }
            catch
            {
                return 0;
            }
        }

        public double GetWeightedAverage(GridView view, string weightField, string valueField)
        {
            if (view == null) return 0;

            if (Val.ToString(weightField) == "" || Val.ToString(valueField) == "") return 0;
            
            GridColumn weightCol = view.Columns[weightField];

            GridColumn valueCol = view.Columns[valueField];
            
            if (weightCol == null || valueCol == null) return 0; 
            
            try
            {
                double totalWeight = 0, totalValue = 0;

                for (int i = 0; i < view.DataRowCount; i++)
                {

                    if (view.IsNewItemRow(i)) continue;

                    object temp;

                    double weight, val;

                    temp = view.GetRowCellValue(i, weightCol);

                    weight = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);

                    temp = view.GetRowCellValue(i, valueCol);

                    val = (temp == DBNull.Value || temp == null) ? 0 : Val.Val(temp);

                    totalWeight += weight;

                    totalValue += weight * val;

                }

                if (totalWeight == 0) return 0;

                return Val.Val(totalValue / totalWeight);

            }
            catch
            {
                return 0;
            }
        }

        //private void TsmExportData_Click(object sender, EventArgs e)
        //{
        //    if (Article_Name == "")
        //    {
        //        Global.Confirm("Enter Article Name For Export Data ...");
        //        return;
        //    }

        //    if (MSize_Name == "")
        //    {
        //        Global.Confirm("Enter MSize Name For Export Data ...");
        //        return;
        //    }
        //    FrmMixRoughRate FrmMixRoughRate = new FrmMixRoughRate();
        //    FrmMixRoughRate.Flag = false;

        //    DataTable DTabTemp = DTab.DefaultView.ToTable(true, "ROUGH_TYPE_NAME", "MFG_CLARITY_NAME", "SIEVE_NAME", "MATERIAL_COST_PER_CARAT", "SHAPE_NAME");
        //    DTabTemp.Columns["MFG_CLARITY_NAME"].ColumnName = "CLARITY_NAME";
        //    DTabTemp.Columns["SIEVE_NAME"].ColumnName = "SIZE_NAME";
        //    DTabTemp.Columns["MATERIAL_COST_PER_CARAT"].ColumnName = "NVALUE";

        //    DTabTemp.Columns.Add("R_DATE", typeof(string));
        //  //  DTabTemp.Columns.Add("CP_CODE", typeof(int));
        //    DTabTemp.Columns.Add("ARTICLE_NAME", typeof(string));
        //   // DTabTemp.Columns.Add("SHAPE_NAME", typeof(string));         
        //    DTabTemp.Columns.Add("MSIZE_NAME", typeof(string));

        //    foreach (DataRow DRow in DTabTemp.Rows)
        //    {
        //        DRow["R_DATE"] = R_Date;
        //        DRow["ARTICLE_NAME"] = Article_Name;
        //     //   DRow["SHAPE_NAME"] = Shape_Name;
        //        DRow["MSIZE_NAME"] = MSize_Name;
        //    }

        //    FrmMixRoughRate.DTabValuation = DTabTemp;
        //    FrmMixRoughRate.ShowDialog();
        //}

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e) // Add : Narendra : 25-06-2014
        {
            //if (!Val.ToString(Remark).Trim().Equals(string.Empty)) 
            //{
            //    if (Remark.ToUpper().Equals("ACTIVITY_SIZE"))
            //    {
            //        if (e.RowHandle >= 0)
            //        {
            //            DataRow DRow = GridView1.GetDataRow(e.RowHandle);

            //            if (DRow["HOURS"].ToString().Trim().Equals(string.Empty) || DRow["SIZE"].ToString().Contains("----") || DRow["SIZE"].ToString().ToUpper().Contains("TOTAL"))
            //            {
            //                e.Appearance.Font = new Font(GridView1.Appearance.Row.Font, FontStyle.Bold);
            //            }
            //        }
            //    }
            //}

            if (!Val.ToString(Remark).Trim().Equals(string.Empty))// Add : Narendra : 27-Aug-2014
            {
                if (Remark.ToUpper().Equals("EMP_DAILY_REPORT"))
                {
                    if (e.RowHandle >= 0)
                    {
                        for (int i = 0; i < GridView1.Columns.Count; i++)
                        {
                            GridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                        }
                    }
                }
            }
        }

        private void FrmGReportViewerBand_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        //private void btnRefresh_Click(object sender, EventArgs e) // Add : Narendra : 29-10-2014
        //{
        //    ReportParams ObjReportParams = new ReportParams();
        //    BM_ReportParams ObjReportBMParams = new BM_ReportParams();

        //    this.Cursor = Cursors.WaitCursor;
        //    btnRefresh.Enabled = false;
        //    if (FilterByFormName.Equals("FrmMixIssueReceiveFilterBy"))
        //    {
        //        if (Remark.Equals("SERIES_LOCK"))
        //        {
        //            DTab = ObjReportParams.Get_Valuation_Stock_ReportWith_RoughDate(ReportParams_Property, Procedure_Name);
        //        }
        //        else if (Remark.Equals("DEPARTMENT_WISE_ISSREC") && ChkExportAsaCostingPattern == true)
        //        {
        //            string StrFromDate = FromIssue_Date;
        //            string StrToDate = ToIssue_Date;

        //            ReportParams_Property.From_Issue_Date = StrFromDate;
        //            ReportParams_Property.To_Issue_Date = StrFromDate;

        //            DTab = ObjReportParams.Get_MIX_Prepolishing_Stock_Report(ReportParams_Property, Procedure_Name);

        //            if (DTab.Columns.Contains("ENTRY_DATE") == false)
        //            {
        //                DTab.Columns.Add(new DataColumn("ENTRY_DATE"));
        //            }

        //            foreach (DataRow DRow in DTab.Rows)
        //            {
        //                DRow["ENTRY_DATE"] = StrFromDate.Replace(" ", "/");
        //            }

        //            StrFromDate = Val.DBDate(DateTime.Parse(StrFromDate).AddDays(1).ToShortDateString());
        //            while (DateTime.Parse(StrFromDate) <= DateTime.Parse(StrToDate))
        //            {
        //                ReportParams_Property.From_Issue_Date = StrFromDate;
        //                ReportParams_Property.To_Issue_Date = StrFromDate;
        //                DataTable DTabNew = ObjReportParams.Get_MIX_Prepolishing_Stock_Report(ReportParams_Property, Procedure_Name);

        //                if (DTabNew.Columns.Contains("ENTRY_DATE") == false)
        //                {
        //                    DTabNew.Columns.Add(new DataColumn("ENTRY_DATE"));
        //                }


        //                foreach (DataRow DRow in DTabNew.Rows)
        //                {
        //                    DRow["ENTRY_DATE"] = StrFromDate.Replace(" ", "/");
        //                }

        //                StrFromDate = Val.DBDate(DateTime.Parse(StrFromDate).AddDays(1).ToShortDateString());
        //                DTab.Merge(DTabNew);
        //            }
        //        }
        //        else
        //        {
        //            DTab = ObjReportParams.Get_MIX_Prepolishing_Stock_Report(ReportParams_Property, Procedure_Name);
        //        }
        //    }
        //    else if (FilterByFormName.Equals("FrmMixIssueReceiveEmpFilterBy"))
        //    {
        //        DTab = ObjReportParams.Get_MIX_Prepolishing_Emp_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }

        //    else if (FilterByFormName.Equals("FrmEmpPerformanceFilterBy"))
        //    {
        //        if (Remark.Equals("ACTIVITY_SIZE"))
        //        {
        //            DTab = ObjReportParams.Get_Employee_Performance_Activity_And_Size_Wise_Report(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);
        //        }
        //        else if (Remark.Equals("EMP_COST_HOUR"))
        //        {
        //            DTab = ObjReportParams.Get_Emp_EfficiencyDetail_Report(ReportParams_Property, Procedure_Name);
        //        }
        //    }

        //    else if (FilterByFormName.Equals("FrmMixFactoryIssueTrnFilterBy"))
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }

        //    else if (FilterByFormName.Equals("FrmMixFactoryOSTrnFilterBy"))
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Outstanding_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixFactoryPolishTrnFilterBy"))
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixFactoryTrnFilterBy")) // 01-10-2014
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixFactoryWorkerOSFilterBy")) // 01-10-2014 
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Worker_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixFactoryWorkerTrnFilterBy")) // 01-10-2014 
        //    {
        //        DTab = ObjReportParams.Get_MIX_Factory_Worker_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixFactoryWorkerWagesFilterBy")) // 01-10-2014 
        //    {
        //        DTab = ObjReportParams.Get_Worker_Wage_Report(ReportParams_Property, ObjReportDetailProperty.Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmValuationPolishIssueFilterBy")) // 01-10-2014 
        //    {
        //        DTab = ObjReportParams.Get_Valuation_Polish_Issue_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixIssueReceiveStaffProductionFilterBy")) // 17-10-2014  : Narendra 
        //    {
        //        DTab = ObjReportParams.Get_MIX_Prepolishing_Machine_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmMixIssueReceiveOutSideFilterBy")) // 17-10-2014  : Narendra 
        //    {
        //        if (Val.ToString(Remark).ToUpper() == "VALUATION_ISSUE" ||
        //                        Val.ToString(Remark).ToUpper() == "VALUATION_OUTSTAND" ||
        //                        Val.ToString(Remark).ToUpper() == "SERIES_LOCK"
        //                        )
        //        {
        //            DTab = ObjReportParams.Get_Valuation_Report(ReportParams_Property, Procedure_Name);
        //        }
        //        else
        //        {
        //            DTab = ObjReportParams.Get_MIX_Prepolishing_OutSide_Stock_Report(ReportParams_Property, Procedure_Name);
        //        }
        //    }
        //    else if (FilterByFormName.Equals("FrmMixIssueReceiveMachineFilterBy")) // 17-10-2014  : Narendra 
        //    {
        //        DTab = ObjReportParams.Get_MIX_Prepolishing_Machine_Stock_Report(ReportParams_Property, Procedure_Name);
        //    }
        //    else if (FilterByFormName.Equals("FrmRoughTransfereFilterBy")) // 17-10-2014  : Narendra 
        //    {
        //        DTab = ObjReportParams.Get_MIX_Rough_ToRough_Transfer_Report(ReportParams_Property, Procedure_Name);
        //    }

        //    else if (FilterByFormName.Equals("FrmMixRealizationFilterBy"))
        //    {
        //        DTab = ObjReportBMParams.Get_Realization_Kapan_InterMixing_Report(ReportParams_Property, Procedure_Name);
        //    }

        //    GridControl1.DataSource = DTab;
        //    GridControl1.RefreshDataSource();
        //    GridControl1.Refresh();
        //    GridView1.RefreshData();
            
        //    this.Cursor = Cursors.Default;
        //    btnRefresh.Enabled = true;
        //}

        
        private void GridView1_ColumnFilterChanged(object sender, EventArgs e)
        {            
            //GridView1.ShowFilterPopupCheckedListBox += new FilterPopupCheckedListBoxEventHandler(GridView1_ShowFilterPopupCheckedListBox);            
        }
       
        void GridView1_ShowFilterPopupCheckedListBox(object sender, FilterPopupCheckedListBoxEventArgs e)
        {   
         /*
            if (GridView1.FilterPanelText.Trim().Equals(string.Empty))
                return;
           // if (!IsFirstTime) return;
           // DevExpress.XtraEditors.Controls.CheckedListBoxItemCollection collection = e.CheckedComboBox.Items;
            //var items = collection.OfType<FilterItem>().OrderBy(o => o, new FilterItemComparer()).ToArray();
            //collection.Clear();
            //collection.AddRange(items);
            
            
            DataTable Dt = new System.Data.DataTable();
            Dt.Columns.Add(e.Column.FieldName, e.Column.ColumnType);
            for (int i = 0; i < GridView1.DataRowCount; i++)
            {
                Dt.Rows.Add(GridView1.GetRowCellValue(i, e.Column.FieldName));
            }
            DataTable Temp = Dt.DefaultView.ToTable(true, e.Column.FieldName);
            Temp.DefaultView.Sort = e.Column.FieldName;
            Temp = Temp.DefaultView.ToTable();

            for (int i = 0; i < e.CheckedComboBox.Items.Count; i++)
            {
                bool _Flag = false;
                string StrSql = e.Column.FieldName + "=" + (e.Column.ColumnType.ToString().Contains("String") ? "'" + e.CheckedComboBox.Items[i].Value.ToString() + "'" : e.CheckedComboBox.Items[i].Value.ToString());
                _Flag = Temp.Select(StrSql).Count() > 0 ? true : false;
               

                if (_Flag == false)
                {
                    e.CheckedComboBox.Items.RemoveAt(i);
                    i = 0;
                }

            }
           */
        }

        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) // Add : Narendra : 29-Jun-2015
        {
            if (Remark == null || Remark.ToString().Trim().Equals(string.Empty))
                return;
            DataRow DR = GridView1.GetDataRow(e.RowHandle);
            if (DR == null)
                return;

            if (e.Clicks.Equals(2))
            {
                //JV ObjJV = new JV();
                //BillPaymentRecSingle ObjPayment = new BillPaymentRecSingle();

                //if (Remark.Equals("LEDGER_TRANSACTION"))
                //{
                //    if (!DR.Table.Columns.Contains("Voucher"))
                //        return;

                //    string StrType = "";
                //    string StrFormName = "";
                //    if (DR["Voucher"].ToString().Trim().Equals(string.Empty))
                //        return;
                //    if (DR["Voucher"].ToString().ToUpper().Contains("JV"))
                //    {
                //        StrType = ObjJV.GetDataByPK(DR["Voucher"].ToString());
                //        StrFormName = ObjPayment.GetFormName(Val.ToInt(ObjPayment.GetJVFormCode(DR["Voucher"].ToString())));
                //    }
                //    else
                //    {
                //        StrType = ObjPayment.GetDataByPK(DR["Voucher"].ToString());
                //        StrFormName = ObjPayment.GetFormName(Val.ToInt(ObjPayment.GetFormCode(DR["Voucher"].ToString())));
                //    }

                //    if (e.Column.FieldName.ToUpper().ToString() == "VOUCHER" || e.Column.FieldName.ToUpper().ToString() == "DEBIT" || e.Column.FieldName.ToUpper().ToString() == "CREDIT")
                //    {
                //        Company_Code = Val.ToInt(DR["COMPANY_CODE"]);
                //        Branch_Code = Val.ToInt(DR["BRANCH_CODE"]);
                //        Location_Code = Val.ToInt(DR["LOCATION_CODE"]);

                //        OpenTransaction_Form(e.Column.FieldName.ToUpper().ToString(), StrFormName, StrType, DR["Voucher"].ToString());
                //    }
                //}
            }
        }

        //private void OpenTransaction_Form(string StrCol_Field, string StrFormName, string StrType, string StrVoucher) // Add : Narendra : 29-Jun-2015
        //{
        //    if (StrCol_Field.ToUpper().ToString() == "VOUCHER" ||
        //        StrCol_Field.ToUpper().ToString() == "DEBIT" ||
        //        StrCol_Field.ToUpper().ToString() == "CREDIT" ||
        //        StrCol_Field.ToUpper().ToString() == "VOUCHER_NO")
        //    {

        //        if (StrVoucher.ToString().ToUpper().Contains("JV"))
        //        {
        //            if (StrFormName.ToUpper().Equals("FRMJV"))
        //            {
        //                FrmJV FrmJV = new FrmJV();
        //                FrmJV.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                FrmJV.StartPosition = FormStartPosition.CenterScreen;
        //                FrmJV.StrVoucher = StrVoucher.ToString();
        //                FrmJV.ShowDialog();
        //            }
        //            else if (StrFormName.ToUpper().Equals("FRMJVMULTIENTRY"))
        //            {
        //                FrmJVMultiEntry FrmJVMulti = new FrmJVMultiEntry();
        //                FrmJVMulti.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                FrmJVMulti.StartPosition = FormStartPosition.CenterScreen;
        //                FrmJVMulti.StrVoucher = StrVoucher.ToString();
        //                FrmJVMulti.ShowDialog();
        //            }

        //            else if (StrFormName.ToUpper().Equals("FRMJVMULTIENTRYNEW"))
        //            {
        //                FrmJVMultiEntryNew FrmJVMulti = new FrmJVMultiEntryNew();
        //                FrmJVMulti.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                FrmJVMulti.StartPosition = FormStartPosition.CenterScreen;
        //                FrmJVMulti.StrVoucher = StrVoucher.ToString();
        //                //Add : Narendra : 08-Apr-2015
        //                FrmJVMulti.CompanyCode = Company_Code;
        //                FrmJVMulti.BranchCode = Branch_Code;
        //                FrmJVMulti.LocationCode = Location_Code;
        //                //End : Narendra : 08-Apr-2015
        //                FrmJVMulti.ShowDialog();

        //                // Add : Narendra : 27-May-2015 :: Refresh Report If Voucher Edited On Report.
        //                /*if (Global.gBool_Voucher_Update_On_Report)
        //                {
        //                    DTPFromDate.Value = Convert.ToDateTime(FromDate);
        //                    DTPToDate.Value = Convert.ToDateTime(ToDate);
        //                    DTPFromDate.Text = FromDate;
        //                    DTPToDate.Text = ToDate;
        //                    //StartDate = DTPFromDate.Value.ToString("dd/MMM/yyyy");
        //                    BtnGenerateReport_Click(null, null);
        //                    Is_Voucher_Updated = true; // Add : Narendra : 27-Jun-2015
        //                    Global.gBool_Voucher_Update_On_Report = false;
        //                }*/
        //                // End : Narendra : 27-May-2015
        //            }
        //        }
        //        else
        //        {

        //            if (StrType.Contains("ONE"))
        //            {
        //                if (StrFormName.ToUpper() == "FRMBILLPAYMENTRECSINGLE")
        //                {
        //                    FrmBillPaymentRecSingle FrmBillPaymentRecSingle = new FrmBillPaymentRecSingle();
        //                    FrmBillPaymentRecSingle.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                    FrmBillPaymentRecSingle.StartPosition = FormStartPosition.CenterScreen;
        //                    FrmBillPaymentRecSingle.StrVoucher = StrVoucher.ToString();
        //                    FrmBillPaymentRecSingle.ShowDialog();
        //                }
        //                //else if (StrFormName.ToUpper() == "FRMBILLPAYMENTREC")
        //                //{
        //                //    FrmBillPaymentRec FrmBillPaymentRec = new FrmBillPaymentRec();
        //                //    FrmBillPaymentRec.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                //    FrmBillPaymentRec.StartPosition = FormStartPosition.CenterScreen;
        //                //    FrmBillPaymentRec.StrVoucher = StrVoucher.ToString();
        //                //    FrmBillPaymentRec.ShowDialog();
        //                //}
        //            }
        //            else
        //            {
        //                FrmBillPaymentRecMulti FrmBillPaymentRecMulti = new FrmBillPaymentRecMulti();
        //                FrmBillPaymentRecMulti.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        //                FrmBillPaymentRecMulti.StartPosition = FormStartPosition.CenterScreen;
        //                FrmBillPaymentRecMulti.StrVoucher = StrVoucher.ToString();

        //                //Add : Narendra : 08-Apr-2015
        //                FrmBillPaymentRecMulti.CompanyCode = Company_Code;
        //                FrmBillPaymentRecMulti.BranchCode = Branch_Code;
        //                FrmBillPaymentRecMulti.LocationCode = Location_Code;
        //                //End : Narendra : 08-Apr-2015

        //                FrmBillPaymentRecMulti.ShowDialog();

        //                // Add : Narendra : 28-11-2014 :: Refresh Report If Voucher Edited On Report.
        //                /*if (Global.gBool_Voucher_Update_On_Report)
        //                {
        //                    DTPFromDate.Value = Convert.ToDateTime(FromDate);
        //                    DTPToDate.Value = Convert.ToDateTime(ToDate);
        //                    DTPFromDate.Text = FromDate;
        //                    DTPToDate.Text = ToDate;
        //                    StartDate = DTPFromDate.Value.ToString("dd/MMM/yyyy");
        //                    Is_Voucher_Updated = true; // Add : Narendra : 27-Jun-2015
        //                    BtnGenerateReport_Click(null, null);
        //                    Global.gBool_Voucher_Update_On_Report = false;
        //                }*/
        //                // End : Narendra : 28-11-2014
        //            }
        //        }

        //    }
        //}

    }
}
