using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Global = RoadWays.Class.Global;

namespace RoadWays.Report
{
    public partial class FrmGReportViewer : Form
    {

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BLL.FormPer ObjPer = new BLL.FormPer();

        //NewReportMaster ObjReport = new NewReportMaster();

        string MergeOnStr = string.Empty;
        string MergeOn = string.Empty;
        Boolean ISFilter = false;

        // double DouAnswer = 0;

        Double DouIssueExpCarat = 0;
        Double DouReadyExpCarat = 0;
        Double DouConsumeCarat = 0;
        Double DouPerConsumeCarat = 0;
        Double DouReadyCarat = 0;
        Double DouIssueCarat = 0;
        Double DouConsumeExpCarat = 0;
        Double DouOSCarat = 0;
        Double DouOSExpCarat = 0;
        string str = string.Empty;

        #region Property Settings

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

        //---- Add : Narendra : 25-06-2014
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        //--------------------
        #endregion

        #region Constructor

        public FrmGReportViewer()
        {
            InitializeComponent();
        }

        public FrmGReportViewer(DataTable pDTab, string pStrOrderBy, string pStrGroupBy, string pStrReportName, int pIntReportCode)
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
                labelControl1.Visible = false;
            }
            else
            {
                lblGroupBy.Visible = true;
                labelControl1.Visible = true;
                lblGroupBy.Text = Group_By_Text;
                lblGroupBy.Tag = Group_By_Tag;
            }
            if (ReportHeaderName == "Jay Matadi Transport")
            {
                labelControl1.Visible = false;
                lblGroupBy.Visible = true;
                labelControl1.Visible = false;
                labelControl15.Visible = false;
            }

            lblFilter.Text = FilterBy;
            this.Text = lblReportHeader.Text;
            //str = "Equitas bank" + System.Environment.NewLine;
            //str += "Ifsc Code : ESFB 0007005" + System.Environment.NewLine;
            //str += "Ac No. 200000567797" + System.Environment.NewLine;
            str = "";
            lblGroupBy.Text = str;

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

        #region Events

        private void FrmGReportViewer_Load(object sender, EventArgs e)
        {
            //lblDateTime.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
            FillGrid();
            //GridView1.GroupedColumns[0].FieldName = "ROUGH_NAME";
            //GridView1.GroupedColumns[0].Group();
        }

        #endregion

        #region Operation

        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            //if (ObjPer.AllowExp == false) // If Condition Add by Khushbu 07/04/2014
            //{
            //    Global.Confirm(BLL.GlobalDec.gStrPermissionExpMsg);
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
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;
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


                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GridView1.CreateExportLink(new DevExpress.XtraExport.ExportXlsxProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
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
                //DataView dv = new DataView(mDTDetail);
                //dv.Sort = "Sequence_No";
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

                GridControl1.DataSource = mDTDetail;
                GridView1.OptionsView.AllowCellMerge = false;


                //foreach (DataRow DRow in mDTDetail.Rows)
                //{
                //    if (Val.ToInt(DRow["VISIBLE"].ToString()) == 1 && Val.ToInt(DRow["IS_UNBOUND"]) == 1)
                //    {
                //        DevExpress.XtraGrid.Columns.GridColumn unbColumn = GridView1.Columns.AddField(Val.ToString(DRow["FIELD_NAME"]));
                //        unbColumn.VisibleIndex = Val.ToInt(DRow["SEQUENCE_NO"]);
                //        unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                //        unbColumn.Caption = Val.ToString(DRow["COLUMN_NAME"]);
                //        unbColumn.OptionsColumn.AllowEdit = false;
                //        // Specify format settings.
                //        unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //        unbColumn.DisplayFormat.FormatString = "{0:N3}";
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
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //    }
                //        //Set Column Default Format as per data commnig

                //        string StrFormat = string.Empty;

                //        switch (DRow["TYPE"].ToString().ToUpper())
                //        {
                //            case "I":
                //                StrFormat = "{0:N0}";
                //                break;
                //            case "F":
                //                StrFormat = "{0:N3}";
                //                break;
                //            default:
                //                StrFormat = "";
                //                break;
                //        }

                //        /* Add By Vipul 04/09/2014
                //           /* Add Alignment */
                //        switch (DRow["ALIGNMENT"].ToString().ToUpper())
                //        {
                //            case "LEFT":
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                //                break;
                //            case "RIGHT":
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //                break;
                //            case "CENTER":
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //                break;
                //            default:
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                //                break;
                //        }

                //        /* Set Order */
                //        switch (DRow["ORDER_BY"].ToString().ToUpper())
                //        {
                //            case "ASC":
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.Ascending;
                //                break;
                //            case "DESC":
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.Descending;
                //                break;
                //            default:
                //                GridView1.Columns[DRow["FIELD_NAME"].ToString()].SortOrder = ColumnSortOrder.None;
                //                break;
                //        }

                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].DisplayFormat.FormatString = StrFormat;
                //        GridView1.Columns[DRow["FIELD_NAME"].ToString()].VisibleIndex = Val.ToInt(DRow["SEQUENCE_NO"]);
                //        // Set Summry Field and group Summry Also

                //        if (Val.ToInt(DRow["VISIBLE"].ToString()) == 1 && Val.ToInt(DRow["ISMERGE"].ToString()) == 0)
                //        {

                //            switch (DRow["AGGREGATE"].ToString().ToUpper())
                //            {
                //                case "SUM":
                if (ReportHeaderName.ToString() == "Department Transfer")
                {
                    GridView1.Columns["Opening_Carat"].Summary.Add(SummaryItemType.Sum, "Opening_Carat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Opening_Carat", GridView1.Columns["Opening_Carat"]);
                    GridView1.Columns["In_Carat"].Summary.Add(SummaryItemType.Sum, "In_Carat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "In_Carat", GridView1.Columns["In_Carat"]);
                    GridView1.Columns["Out_Carat"].Summary.Add(SummaryItemType.Sum, "Out_Carat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Out_Carat", GridView1.Columns["Out_Carat"]);
                    GridView1.Columns["Closing_BalCarat"].Summary.Add(SummaryItemType.Sum, "Closing_BalCarat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Closing_BalCarat", GridView1.Columns["Closing_BalCarat"]);
                    GridView1.Columns["Closing_PhyCarat"].Summary.Add(SummaryItemType.Sum, "Closing_PhyCarat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Closing_PhyCarat", GridView1.Columns["Closing_PhyCarat"]);
                    GridView1.Columns["Loss_Carat"].Summary.Add(SummaryItemType.Sum, "Loss_Carat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Loss_Carat", GridView1.Columns["Loss_Carat"]);
                    GridView1.Columns["Lost_Carat"].Summary.Add(SummaryItemType.Sum, "Lost_Carat");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Lost_Carat", GridView1.Columns["Lost_Carat"]);
                    GridView1.Columns["Carat_Plus"].Summary.Add(SummaryItemType.Sum, "Carat_Plus");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "Carat_Plus", GridView1.Columns["Carat_Plus"]);
                }
                else if (ReportHeaderName.ToString() == "Party Transfer")
                {
                    GridView1.Columns["ISSUE_LOT"].Summary.Add(SummaryItemType.Sum, "ISSUE_LOT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_LOT", GridView1.Columns["ISSUE_LOT"]);
                    GridView1.Columns["ISSUE_PCS"].Summary.Add(SummaryItemType.Sum, "ISSUE_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_PCS", GridView1.Columns["ISSUE_PCS"]);
                    GridView1.Columns["ISSUE_CARAT"].Summary.Add(SummaryItemType.Sum, "ISSUE_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_CARAT", GridView1.Columns["ISSUE_CARAT"]);
                    GridView1.Columns["CONSUME_PCS"].Summary.Add(SummaryItemType.Sum, "CONSUME_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CONSUME_PCS", GridView1.Columns["CONSUME_PCS"]);
                    GridView1.Columns["CONSUME_CARAT"].Summary.Add(SummaryItemType.Sum, "CONSUME_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CONSUME_CARAT", GridView1.Columns["CONSUME_CARAT"]);
                    GridView1.Columns["LOST_PCS"].Summary.Add(SummaryItemType.Sum, "LOST_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LOST_PCS", GridView1.Columns["LOST_PCS"]);
                    GridView1.Columns["LOST_CARAT"].Summary.Add(SummaryItemType.Sum, "LOST_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LOST_CARAT", GridView1.Columns["LOST_CARAT"]);
                    GridView1.Columns["RR_PCS"].Summary.Add(SummaryItemType.Sum, "RR_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RR_PCS", GridView1.Columns["RR_PCS"]);
                    GridView1.Columns["RR_CARAT"].Summary.Add(SummaryItemType.Sum, "RR_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RR_CARAT", GridView1.Columns["RR_CARAT"]);
                    GridView1.Columns["READY_PCS"].Summary.Add(SummaryItemType.Sum, "READY_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "READY_PCS", GridView1.Columns["READY_PCS"]);
                    GridView1.Columns["READY_CARAT"].Summary.Add(SummaryItemType.Sum, "READY_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "READY_CARAT", GridView1.Columns["READY_CARAT"]);
                    GridView1.Columns["EXP_ISS_PER"].Summary.Add(SummaryItemType.Custom, "EXP_ISS_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_ISS_PER", GridView1.Columns["EXP_ISS_PER"]);
                    GridView1.Columns["EXP_REC_PER"].Summary.Add(SummaryItemType.Custom, "EXP_REC_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_REC_PER", GridView1.Columns["EXP_REC_PER"]);
                    GridView1.Columns["PER_CONSUME_CARAT"].Summary.Add(SummaryItemType.Sum, "PER_CONSUME_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "PER_CONSUME_CARAT", GridView1.Columns["PER_CONSUME_CARAT"]);
                    GridView1.Columns["REC_DIFF"].Summary.Add(SummaryItemType.Custom, "REC_DIFF");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "REC_DIFF", GridView1.Columns["REC_DIFF"]);
                }
                else if (ReportHeaderName.ToString() == "Party OutStanding")
                {
                    GridView1.Columns["ISSUE_LOT"].Summary.Add(SummaryItemType.Sum, "ISSUE_LOT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_LOT", GridView1.Columns["ISSUE_LOT"]);
                    GridView1.Columns["ISSUE_PCS"].Summary.Add(SummaryItemType.Sum, "ISSUE_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_PCS", GridView1.Columns["ISSUE_PCS"]);
                    GridView1.Columns["ISSUE_CARAT"].Summary.Add(SummaryItemType.Sum, "ISSUE_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_CARAT", GridView1.Columns["ISSUE_CARAT"]);
                    GridView1.Columns["RECEIVE_PCS"].Summary.Add(SummaryItemType.Sum, "RECEIVE_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RECEIVE_PCS", GridView1.Columns["RECEIVE_PCS"]);
                    GridView1.Columns["RECEIVE_CARAT"].Summary.Add(SummaryItemType.Sum, "RECEIVE_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RECEIVE_CARAT", GridView1.Columns["RECEIVE_CARAT"]);
                    GridView1.Columns["OUTSTAND_LOT"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_LOT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_LOT", GridView1.Columns["OUTSTAND_LOT"]);
                    GridView1.Columns["OUTSTAND_PCS"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_PCS", GridView1.Columns["OUTSTAND_PCS"]);
                    GridView1.Columns["OUTSTAND_CARAT"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_CARAT", GridView1.Columns["OUTSTAND_CARAT"]);
                    GridView1.Columns["EXP_CARAT"].Summary.Add(SummaryItemType.Sum, "EXP_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "EXP_CARAT", GridView1.Columns["EXP_CARAT"]);
                    GridView1.Columns["EXP_ISS_PER"].Summary.Add(SummaryItemType.Custom, "EXP_ISS_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_ISS_PER", GridView1.Columns["EXP_ISS_PER"]);
                }
                else if (ReportHeaderName.ToString() == "Rough Transfer")
                {
                    GridView1.Columns["ISSUE_LOT"].Summary.Add(SummaryItemType.Sum, "ISSUE_LOT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_LOT", GridView1.Columns["ISSUE_LOT"]);
                    GridView1.Columns["ISSUE_PCS"].Summary.Add(SummaryItemType.Sum, "ISSUE_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_PCS", GridView1.Columns["ISSUE_PCS"]);
                    GridView1.Columns["ISSUE_CARAT"].Summary.Add(SummaryItemType.Sum, "ISSUE_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ISSUE_CARAT", GridView1.Columns["ISSUE_CARAT"]);
                    GridView1.Columns["RR_PCS"].Summary.Add(SummaryItemType.Sum, "RR_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RR_PCS", GridView1.Columns["RR_PCS"]);
                    GridView1.Columns["RR_CARAT"].Summary.Add(SummaryItemType.Sum, "RR_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "RR_CARAT", GridView1.Columns["RR_CARAT"]);
                    GridView1.Columns["CONSUME_PCS"].Summary.Add(SummaryItemType.Sum, "CONSUME_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CONSUME_PCS", GridView1.Columns["CONSUME_PCS"]);
                    GridView1.Columns["CONSUME_CARAT"].Summary.Add(SummaryItemType.Sum, "CONSUME_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CONSUME_CARAT", GridView1.Columns["CONSUME_CARAT"]);
                    GridView1.Columns["PER_CONSUME_CARAT"].Summary.Add(SummaryItemType.Sum, "PER_CONSUME_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "PER_CONSUME_CARAT", GridView1.Columns["PER_CONSUME_CARAT"]);
                    GridView1.Columns["READY_PCS"].Summary.Add(SummaryItemType.Sum, "READY_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "READY_PCS", GridView1.Columns["READY_PCS"]);
                    GridView1.Columns["READY_CARAT"].Summary.Add(SummaryItemType.Sum, "READY_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "READY_CARAT", GridView1.Columns["READY_CARAT"]);
                    GridView1.Columns["LOST_PCS"].Summary.Add(SummaryItemType.Sum, "LOST_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LOST_PCS", GridView1.Columns["LOST_PCS"]);
                    GridView1.Columns["LOST_CARAT"].Summary.Add(SummaryItemType.Sum, "LOST_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LOST_CARAT", GridView1.Columns["LOST_CARAT"]);
                    GridView1.Columns["LOSS_CARAT"].Summary.Add(SummaryItemType.Sum, "LOSS_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LOSS_CARAT", GridView1.Columns["LOSS_CARAT"]);
                    GridView1.Columns["SAW_PCS"].Summary.Add(SummaryItemType.Sum, "SAW_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "SAW_PCS", GridView1.Columns["SAW_PCS"]);
                    GridView1.Columns["SAW_CARAT"].Summary.Add(SummaryItemType.Sum, "SAW_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "SAW_CARAT", GridView1.Columns["SAW_CARAT"]);
                    GridView1.Columns["CANCEL_PCS"].Summary.Add(SummaryItemType.Sum, "CANCEL_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CANCEL_PCS", GridView1.Columns["CANCEL_PCS"]);
                    GridView1.Columns["CANCEL_CARAT"].Summary.Add(SummaryItemType.Sum, "CANCEL_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "CANCEL_CARAT", GridView1.Columns["CANCEL_CARAT"]);
                    GridView1.Columns["LABOUR_AMOUNT"].Summary.Add(SummaryItemType.Sum, "LABOUR_AMOUNT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "LABOUR_AMOUNT", GridView1.Columns["LABOUR_AMOUNT"]);

                    GridView1.Columns["OUTSTAND_LOT"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_LOT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_LOT", GridView1.Columns["OUTSTAND_LOT"]);
                    GridView1.Columns["OUTSTAND_PCS"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_PCS");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_PCS", GridView1.Columns["OUTSTAND_PCS"]);
                    GridView1.Columns["OUTSTAND_CARAT"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_CARAT", GridView1.Columns["OUTSTAND_CARAT"]);
                    GridView1.Columns["EXP_ISS_PER"].Summary.Add(SummaryItemType.Custom, "EXP_ISS_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_ISS_PER", GridView1.Columns["EXP_ISS_PER"]);
                    GridView1.Columns["EXP_REC_PER"].Summary.Add(SummaryItemType.Custom, "EXP_REC_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_REC_PER", GridView1.Columns["EXP_REC_PER"]);
                    GridView1.Columns["EXP_CONS_PER"].Summary.Add(SummaryItemType.Custom, "EXP_CONS_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "EXP_CONS_PER", GridView1.Columns["EXP_CONS_PER"]);
                    GridView1.Columns["OUTSTAND_EXP_CARAT"].Summary.Add(SummaryItemType.Sum, "OUTSTAND_EXP_CARAT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "OUTSTAND_EXP_CARAT", GridView1.Columns["OUTSTAND_EXP_CARAT"]);
                    GridView1.Columns["OUTSTAND_EXP_PER"].Summary.Add(SummaryItemType.Custom, "OUTSTAND_EXP_PER");
                    GridView1.GroupSummary.Add(SummaryItemType.Custom, "OUTSTAND_EXP_PER", GridView1.Columns["OUTSTAND_EXP_PER"]);
                }
                else if (ReportHeaderName.ToString() == "Transaction Report")
                {
                    GridView1.Columns["DIESEL"].Summary.Add(SummaryItemType.Sum, "DIESEL");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "DIESEL", GridView1.Columns["DIESEL"]);

                    GridView1.Columns["ROKDA"].Summary.Add(SummaryItemType.Sum, "ROKDA");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "ROKDA", GridView1.Columns["ROKDA"]);

                    GridView1.Columns["BAKI"].Summary.Add(SummaryItemType.Sum, "BAKI");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "BAKI", GridView1.Columns["BAKI"]);

                    GridView1.Columns["FREIGHT"].Summary.Add(SummaryItemType.Sum, "FREIGHT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "FREIGHT", GridView1.Columns["FREIGHT"]);

                    GridView1.Columns["COMMISSION"].Summary.Add(SummaryItemType.Sum, "COMMISSION");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "COMMISSION", GridView1.Columns["COMMISSION"]);

                    GridView1.Columns["NET_AMOUNT"].Summary.Add(SummaryItemType.Sum, "NET_AMOUNT");
                    GridView1.GroupSummary.Add(SummaryItemType.Sum, "NET_AMOUNT", GridView1.Columns["NET_AMOUNT"]);

                }
                else if (ReportHeaderName.ToString() == "Jay Matadi Transport")
                {
                    GridView1.Columns["Qty"].Summary.Add(SummaryItemType.Sum, "Qty");
                    //GridView1.GroupSummary.Add(SummaryItemType.Sum, "Weight", GridView1.Columns["Weight"]);

                    //GridView1.Columns["Amount"].Summary.Add(SummaryItemType.Sum, "Amount");
                    //GridView1.GroupSummary.Add(SummaryItemType.Sum, "Amount", GridView1.Columns["Amount"]);
                }




                GridView1.ExpandAllGroups();
                GridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                Global.Confirm("Error In Column Index : " + IntError.ToString() + "    " + Ex.Message);
            }
        }

        public void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            // ' For Report Title
            TextBrick BrickTitle = e.Graph.DrawString(lblReportHeader.Text, Color.Black, new RectangleF(0, 0, 500, 20), BorderSide.None);
            BrickTitle.Font = new Font("Tahoma", 15);
            BrickTitle.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickTitle.VertAlignment = DevExpress.Utils.VertAlignment.Center;
            // ' For Filter 
            TextBrick BrickFilter = e.Graph.DrawString("" + lblFilter.Text, Color.Black, new RectangleF(2, 22, 1000, 15), BorderSide.None);
            BrickFilter.Font = new Font("Tahoma", 8);
            BrickFilter.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            BrickFilter.VertAlignment = DevExpress.Utils.VertAlignment.Center;

            // ' For Filter 
            //TextBrick BrickGroup = e.Graph.DrawString("Equitas bank, Ifsc Code : ESFB 0007005,  Ac No. 200000567797", Color.Black, new RectangleF(2, 40, 1000, 15), BorderSide.None);
            //BrickGroup.Font = new Font("Tahoma", 8);
            //BrickGroup.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //BrickGroup.VertAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        public void Link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            // ' for Page No
            PageInfoBrick BrickPageNo = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "", Color.Black, new RectangleF(0, 0, 100, 15), BorderSide.None);
            BrickPageNo.LineAlignment = BrickAlignment.Center;
            BrickPageNo.Alignment = BrickAlignment.Near;
            BrickPageNo.AutoWidth = true;
            BrickPageNo.Font = new Font("Tahoma", 8);
            // ' For date 
            PageInfoBrick BrickDate = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, new RectangleF(0, 0, 100, 20), BorderSide.None);
            BrickDate.LineAlignment = BrickAlignment.Center;
            BrickDate.Alignment = BrickAlignment.Far;
            BrickDate.AutoWidth = true;
            BrickDate.Font = new Font("Tahoma", 8);
        }

        //public void InsertReportTrace()  
        //{
        //    string MM = Val.ToString(DateTime.Today.Month);
        //    if (Val.ToInt(MM) < 10)
        //    {
        //        MM = "0" + MM;
        //    }
        //    int YYMM = Val.ToInt(Val.ToString(DateTime.Today.Year) + MM);
        //    int SRNO = ObjReport.FindNewSrNo(YYMM);

        //    ObjReport.SaveReportTrace(YYMM, SRNO, Report_Code, Report_Type);
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
                if (e.DisplayText == "0.00" || e.DisplayText == "0" || e.DisplayText == "0.000")
                {
                    e.DisplayText = String.Empty;
                    //e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                e.Column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void GridView1_StartGrouping(object sender, EventArgs e)
        {
            GridView1.BestFitColumns();
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

            #region OUTSIDE_RECEIPT_TOTAL_ROUGH_TRANSFER

            if (ReportHeaderName == "Party OutStanding" || ReportHeaderName == "Rough Transfer")
            {
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("RR_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "RR_CARAT");
                //}
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("READY_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "READY_CARAT");
                //}
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CONSUME_CARAT_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "CONSUME_CARAT");
                //}
                //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("CONSUME_PCS_PER") == 0)
                //{
                //    GetGroupRowPercentage(sender, e, "CONSUME_PCS");
                //}

                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    // DouAvgProduction = 0;
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    DouIssueCarat = 0;
                    DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;

                    DouOSCarat = 0;
                    DouOSExpCarat = 0;

                    //IntIssuePcs = 0;
                    //IntConsumePcs = 0;
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    //  IntIssuePcs += Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_PCS"));
                    //  IntConsumePcs += Val.ToInt(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_PCS"));

                    DouIssueCarat = DouIssueCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "ISSUE_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));

                    //    DouAvgProduction = DouAvgProduction + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "AVG_PER_PROD"));

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
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("AVG_DAYS") == 0)
                    //{
                    //    if (DouAvgProduction != 0)
                    //    {
                    //        e.TotalValue = Math.Round((DouConsumeCarat / DouAvgProduction), 0);
                    //    }

                    //}
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
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("ISSUE_SIZE") == 0)
                    //{
                    //    e.TotalValue = DouIssueCarat != 0 ? Math.Round(IntIssuePcs / DouIssueCarat, 3) : 0.00;
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("READY_SIZE") == 0)
                    //{
                    //    e.TotalValue = DouReadyCarat != 0 ? Math.Round(IntConsumePcs / DouReadyCarat, 3) : 0.00;
                    //}
                }
            }

            #endregion

            #region LABOUR_PERFORMANCE_INSPECTION 

            else if (ReportHeaderName == "Party Transfer")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    DouPerConsumeCarat = 0;
                    DouConsumeCarat = 0;
                    //DouIssueCarat = 0;
                    //DouConsumeExpCarat = 0;
                    DouIssueExpCarat = 0;
                    DouReadyCarat = 0;
                    DouReadyExpCarat = 0;

                    //DouDMCarat = 0;
                    //DouFactoryCarat = 0;
                    //DouFactoryDMCarat = 0;
                    //DouManualCarat = 0;

                    //IntConsumePcs = 0;
                    //IntMfgOSPcs = 0;
                    //DouMFGOSCarat = 0;

                    //IntRepOSPcs = 0;
                    //IntRepConsume = 0;

                    //IntTSOSPcs = 0;
                    //IntTSConsume = 0;

                    //DouInsManPer = 0;  //INS_MAN_PER//
                    //DouInsDMPer = 0;
                    //DouTotalPer = 0;
                    //DouInsExptManual = 0; //INS_EXPT_ MAN //
                    //DouInsExptDM = 0; //INS_EXP_DM //
                    //DouInsExpTotal = 0; //INS_EXP_TOTAL//
                    //DouInsDMDiff = 0;
                    //DouInsFacDiff = 0;
                    //DouInsManDiff = 0;
                    //DouTotalDiff = 0;
                    //DouManualOrgCarat = 0;
                    //DouDMOrgCarat = 0;
                    //DouTotalCrt = 0;
                    //DouInspDM = 0; //INS_FAC_PER //
                    //DouFacExpWt = 0;
                    //DouDMExpWt = 0;
                    //DouManExpWt = 0;
                    //DouInsFacExpCarat = 0;
                    //DouManualWTCarat = 0;
                    //DouInsDMExpCrt = 0;
                    //DouInsDMCarat = 0;
                    //DouInspFAC = 0;
                    //DouInspMAN = 0;

                    //DouInsManualCarat = 0;
                    //DouInsFacCarat = 0;
                    //DouFACOrgCarat = 0;
                    //DouFactoryWTCarat = 0;

                    //DouDMExpPer = 0;
                    //DouMANExpPer = 0;
                    //DouDMExpCarat = 0;
                    //DouMANExpCarat = 0;
                    //DouInsReadyCrt = 0;


                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    DouPerConsumeCarat = DouPerConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "PER_CONSUME_CARAT"));
                    DouConsumeCarat = DouConsumeCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                    DouReadyCarat = DouReadyCarat + Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT"));

                    DouIssueExpCarat = DouIssueExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_ISS_PER")) / 100);
                    DouReadyExpCarat = DouReadyExpCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "READY_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "EXP_REC_PER")) / 100);


                    //DouDMCarat = DouDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "DM_PER")) / 100);
                    //DouFactoryCarat = DouFactoryCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_WT_PER")) / 100);
                    //DouManualCarat = DouManualCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "MANUAL_PER")) / 100);
                    //DouFactoryDMCarat = DouFactoryDMCarat + (Val.Val(GridView1.GetRowCellValue(e.RowHandle, "CONSUME_CARAT")) * Val.Val(GridView1.GetRowCellValue(e.RowHandle, "FAC_DM_PER")) / 100);

                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_ISS_PER") == 0)
                    {
                        if (DouConsumeCarat != 0)
                        {
                            double DouExpIssPer = Math.Round((DouIssueExpCarat / DouConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpIssPer;
                        }
                    }
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_EXP_PER") == 0)
                    //{
                    //    if (DouDMOrgCarat != 0)
                    //    {
                    //        DouDMExpPer = Math.Round((DouDMExpCarat / DouDMOrgCarat) * 100, 3);
                    //        e.TotalValue = DouDMExpPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MAN_EXP_PER") == 0)
                    //{
                    //    if (DouManualOrgCarat != 0)
                    //    {
                    //        DouMANExpPer = Math.Round((DouMANExpCarat / DouManualOrgCarat) * 100, 3);
                    //        e.TotalValue = DouMANExpPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_EXP_PER") == 0)
                    //{
                    //    if (DouManualOrgCarat != 0)
                    //    {
                    //        DouTotalExpPer = Math.Round((DouMANExpCarat / DouManualOrgCarat) * 100, 3);
                    //        e.TotalValue = DouTotalExpPer;
                    //    }
                    //    else if (DouDMOrgCarat != 0)
                    //    {
                    //        DouTotalExpPer = Math.Round((DouDMExpCarat / DouDMOrgCarat) * 100, 3);
                    //        e.TotalValue = DouTotalExpPer;
                    //    }
                    //} 
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MFG_STOCK_FOR_DAYS_PCS") == 0)
                    //{
                    //    if (IntConsumePcs != 0 && ReceiptDays != 0)
                    //    {
                    //        e.TotalValue = Math.Round(IntMfgOSPcs / (IntConsumePcs / ReceiptDays), 2).ToString();
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MFG_STOCK_FOR_DAYS_CARAT") == 0)
                    //{
                    //    if (DouConsumeCarat != 0 && ReceiptDays != 0)
                    //    {
                    //        e.TotalValue = Math.Round(DouMFGOSCarat / (DouConsumeCarat / ReceiptDays), 2).ToString();
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REP_STOCK_FOR_DAYS") == 0)
                    //{
                    //    if (IntRepConsume != 0 && ReceiptDays != 0)
                    //    {
                    //        e.TotalValue = Math.Round(IntRepOSPcs / (IntRepConsume / ReceiptDays), 2).ToString();
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TS_STOCK_FOR_DAYS") == 0)
                    //{
                    //    if (IntTSConsume != 0 && ReceiptDays != 0)
                    //    {
                    //        e.TotalValue = Math.Round(IntTSOSPcs / (IntTSConsume / ReceiptDays), 2).ToString();
                    //    }
                    //}

                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("EXP_REC_PER") == 0)
                    {
                        if (DouPerConsumeCarat != 0)
                        {
                            double DouExpRecPer = Math.Round((DouReadyCarat / DouPerConsumeCarat) * 100, 3);
                            e.TotalValue = DouExpRecPer;
                        }
                    }

                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_REC_PER") == 0)
                    //{
                    //    if (DouTotalCrt != 0)
                    //    {
                    //        DouExpRecPer = Math.Round((DouInsReadyCrt / DouTotalCrt) * 100, 3);
                    //        e.TotalValue = DouExpRecPer;
                    //    }
                    //}

                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_DM_PER") == 0)
                    //{
                    //    if (DouPerConsumeCarat != 0)
                    //    {
                    //        e.TotalValue = Math.Round((DouFactoryDMCarat / DouPerConsumeCarat) * 100, 3);
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_PER") == 0)
                    //{
                    //    if (DouPerConsumeCarat != 0)
                    //    {
                    //        DouDMPer = Math.Round((DouDMCarat / DouPerConsumeCarat) * 100, 3);
                    //        e.TotalValue = DouDMPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_PER") == 0)
                    //{
                    //    if (DouPerConsumeCarat != 0)
                    //    {
                    //        DouFactoryPer = Math.Round((DouFactoryCarat / DouPerConsumeCarat) * 100, 3);
                    //        e.TotalValue = DouFactoryPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_PER") == 0)
                    //{
                    //    if (DouPerConsumeCarat != 0)
                    //    {
                    //        DouManualPer = Math.Round((DouManualCarat / DouPerConsumeCarat) * 100, 3);
                    //        e.TotalValue = DouManualPer;
                    //    }
                    //}

                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("DM_DIFF") == 0)
                    //{
                    //    if (e.GroupLevel < 0)
                    //    {
                    //        double DMPer = Val.Val(view.Columns["DM_PER"].SummaryText);
                    //        double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }
                    //    else
                    //    {
                    //        double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("DM_PER")]));
                    //        double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("FAC_WT_DIFF") == 0)
                    //{
                    //    if (e.GroupLevel < 0)
                    //    {
                    //        double DMPer = Val.Val(view.Columns["FAC_WT_PER"].SummaryText);
                    //        double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }
                    //    else
                    //    {
                    //        double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("FAC_WT_PER")]));
                    //        double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }

                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("MANUAL_DIFF") == 0)
                    //{
                    //    if (e.GroupLevel < 0)
                    //    {
                    //        double DMPer = Val.Val(view.Columns["MANUAL_PER"].SummaryText);
                    //        double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }
                    //    else
                    //    {
                    //        double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("MANUAL_PER")]));
                    //        double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                    //        e.TotalValue = ExpRecPer - DMPer;
                    //    }

                    //}
                    else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("REC_DIFF") == 0)
                    {
                        if (e.GroupLevel < 0)
                        {
                            double DMPer = Val.Val(view.Columns["EXP_ISS_PER"].SummaryText);
                            double ExpRecPer = Val.Val(view.Columns["EXP_REC_PER"].SummaryText);
                            e.TotalValue = Math.Round(ExpRecPer - DMPer, 3);
                        }
                        else
                        {
                            double DMPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_ISS_PER")]));
                            double ExpRecPer = Val.Val(view.GetGroupSummaryValue(e.GroupRowHandle, (GridGroupSummaryItem)view.GroupSummary[GetGroupSummryIndex("EXP_REC_PER")]));
                            e.TotalValue = Math.Round(ExpRecPer - DMPer, 3);
                        }
                    }

                    //// ADD BY CHIRAG FOR INSPECTION DIFFERENCE REPORT - Start
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_MAN_PER") == 0)
                    //{
                    //    if (DouIssueCarat != 0)
                    //    {
                    //        DouInsManPer = Math.Round(((DouManualOrgCarat * 100) / DouIssueCarat), 3);
                    //        e.TotalValue = DouInsManPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_DM_PER") == 0)
                    //{
                    //    if (DouDMOrgCarat != 0)
                    //    {
                    //        DouInsDMPer = Math.Round((DouDMOrgCarat / DouIssueCarat) * 100, 3);
                    //        e.TotalValue = DouInsDMPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("TOTAL_PER") == 0)
                    //{
                    //    if (DouIssueCarat != 0)
                    //    {
                    //        DouTotalPer = Math.Round((DouTotalCrt / DouIssueCarat) * 100, 3);
                    //        e.TotalValue = DouTotalPer;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXPT_MAN") == 0)
                    //{
                    //    if (DouManualOrgCarat != 0)
                    //    {
                    //        //DouInsExptManual = Math.Round((DouInsFacExpCarat * 100) / DouManualOrgCarat, 3);
                    //        DouInsExptManual = Math.Round((DouFacExpWt * 100) / DouManualOrgCarat, 3);
                    //        e.TotalValue = DouInsExptManual;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_DM") == 0)
                    //{
                    //    if (DouDMOrgCarat != 0)
                    //    {
                    //        DouInsExptDM = Math.Round((DouDMExpWt * 100) / DouDMOrgCarat, 3);
                    //        e.TotalValue = DouInsExptDM;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INS_EXP_TOTAL") == 0)
                    //{
                    //    if (DouManualOrgCarat + DouDMOrgCarat != 0)
                    //    {
                    //        DouInsExpTotal = Math.Round(((DouInsDMExpCrt + DouManualWTCarat) * 100) / (DouManualOrgCarat + DouDMOrgCarat), 3);

                    //        e.TotalValue = DouInsExpTotal;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_DM") == 0)
                    //{
                    //    if (DouDMOrgCarat != 0)
                    //    {
                    //        DouInspDM = Math.Round((DouInsDMExpCrt * 100) / DouDMOrgCarat, 3);

                    //        e.TotalValue = DouInspDM;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_MAN") == 0)
                    //{
                    //    if (DouManualOrgCarat != 0)
                    //    {
                    //        DouInspMAN = Math.Round((DouManualWTCarat * 100) / DouManualOrgCarat, 3);

                    //        e.TotalValue = DouInspMAN;
                    //    }
                    //}
                    //else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("INSP_FAC") == 0)
                    //{
                    //    if (DouManualOrgCarat != 0)
                    //    {
                    //        DouInspFAC = Math.Round((DouManualWTCarat * 100) / DouManualOrgCarat, 3);

                    //        e.TotalValue = DouInspFAC;
                    //    }
                    //    else if (DouDMOrgCarat != 0)
                    //    {
                    //        DouInspFAC = Math.Round((DouInsDMExpCrt * 100) / DouDMOrgCarat, 3);

                    //        e.TotalValue = DouInspFAC;
                    //    }
                    //}

                }
            }

            #endregion

        }


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

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (Remark != null)
            {
                if (Remark.ToUpper().Equals("ACTIVITY_SIZE"))
                {
                    DataRow DRow = GridView1.GetDataRow(e.RowHandle);
                    if ((DRow["HOUR"].Equals(string.Empty) && !DRow["SIZE"].Equals(string.Empty)) || DRow["SIZE"].ToString().Contains("----"))
                    {
                        e.Appearance.Font = new Font(GridView1.Appearance.Row.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void PrintToolStripMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (ObjPer.AllowPrint == false) // If Condition Add by Khushbu 07/04/2014
            //{
            //    Global.Confirm(BLL.GlobalDec.gStrPermissionPrintMsg);
            //    return;
            //}

            DevExpress.XtraPrinting.PrintingSystem PrintSystem = new DevExpress.XtraPrinting.PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(PrintSystem);

            //int autoFit = PrintSystem.Document.AutoFitToPagesWidth;
            //PrintSystem.Document.AutoFitToPagesWidth = 1;

            //if (PrintSystem.Document.ScaleFactor > 1)
            //{
            //    PrintSystem.Document.AutoFitToPagesWidth = autoFit;
            //}

            link.Component = GridControl1;

            //if (Val.ToString(cmbOrientation.SelectedItem) == "Landscape")
            //{
            //    link.Landscape = true;
            //}
            //if (Val.ToString(cmbExpand.SelectedItem) == "Yes")
            //{
            //    GridView1.OptionsPrint.ExpandAllGroups = true;
            //}
            //else
            //{
            //    GridView1.OptionsPrint.ExpandAllGroups = false;
            //}

            link.Margins.Left = 20;
            link.Margins.Right = 20;
            link.Margins.Bottom = 40;
            link.Margins.Top = 80;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterArea);
            link.CreateDocument();
            link.ShowPreview();
            link.PrintDlg();
        }

        private void ToExcel_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("xls", "Export to Excel", "Excel files (*.xls)|*.xls|All files (*.*)|*.*");
        }

        private void ToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void ToHTML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void ToRTF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void ToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        #region Menu Events

        private void MNUExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Collapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.CollapseAllGroups();
        }

        private void AToolStripMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.BestFitColumns();
        }

        private void ExpandTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.ExpandAllGroups();
        }

        #endregion

        private void MNGroupEnableDisable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MNRemoveGroup.Caption == "Disable Groups")
            {
                while (GridView1.GroupedColumns.Count != 0)
                {
                    GridView1.GroupedColumns[GridView1.GroupedColumns.Count - 1].UnGroup();
                }
                MNRemoveGroup.Caption = "Enable Groups";

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
                MNRemoveGroup.Caption = "Disable Groups";
            }
            ExpandTool_ItemClick(null, null);
        }

        private void MNFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView1.BeginUpdate();
            if (ISFilter == true)
            {
                ISFilter = false;
                MNFilter.Caption = "Add Filter";
                GridView1.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                ISFilter = true;
                MNFilter.Caption = "Remove Filter";
                GridView1.OptionsView.ShowAutoFilterRow = true;
            }
            GridView1.EndUpdate();
        }
    }
}
