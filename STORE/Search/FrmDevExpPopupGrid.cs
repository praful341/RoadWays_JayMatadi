using System;
using System.Data;
using System.Windows.Forms;
using Global = RoadWays.Class.Global;

namespace RoadWays.Search
{
    public partial class FrmDevExpPopupGrid : Form
    {

        BLL.Validation Val = new BLL.Validation();

        private DataTable _DTab = new DataTable();

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        public DataRow DRow;

        private string _SummrisedColumn = "";

        public string SummrisedColumn
        {
            get { return _SummrisedColumn; }
            set { _SummrisedColumn = value; }
        }


        private string _CountedColumn = "";

        public string CountedColumn
        {
            get { return _CountedColumn; }
            set { _CountedColumn = value; }
        }


        public bool DialogCloseOnEscape = true;

        #region Property

       
        #endregion

        #region Constructor

        public FrmDevExpPopupGrid()
        {
            InitializeComponent();
        }

        #endregion


        #region Context Menu

        private void MNExportToExcelImport_Click(object sender, EventArgs e)
        {
            ExportImport("xls", "Export to Excel", "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }

        private void MNExportToTextImport_Click(object sender, EventArgs e)
        {
            ExportImport("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void MNExportToHTMLImport_Click(object sender, EventArgs e)
        {
            ExportImport("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void MNExportToRTFImport_Click(object sender, EventArgs e)
        {
            ExportImport("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void MNExportToPDFImport_Click(object sender, EventArgs e)
        {
            ExportImport("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void MNExportCSVImport_Click(object sender, EventArgs e)
        {
            ExportImport("csv", "Export Report to CSVB", "csv (*.csv)|*.csv");
        }

        //private void MNExportEmailImport_Click(object sender, EventArgs e)
        //{
        //    string StrFile = Global.DataGridExportToExcel(GrdDet, "Detail");

        //    Utility.FrmEmailSend FrmEmailSend = new Utility.FrmEmailSend();
        //    FrmEmailSend.mStrSubject = "Import Details";
        //    FrmEmailSend.mStrAttachments = StrFile;
        //    FrmEmailSend.ShowForm();
        //    FrmEmailSend = null;

        //    if (File.Exists(StrFile))
        //    {
        //        File.Delete(StrFile);
        //    }
        //    Form Frm = this.FindForm();
        //    if (Frm != null)
        //    {
        //        Frm.Activate();
        //        Frm.Focus();
        //    }
        //}
      
        #endregion
        
        #region Events

        //private void lblExport_Click(object sender, EventArgs e)
        //{
        //    Point ptLowerLeft = new Point(0, lblExport.Height);
        //    ptLowerLeft = lblExport.PointToScreen(ptLowerLeft);
        //    ContextMNExportImport.Width = lblExport.Width;
        //    ContextMNExportImport.Show(ptLowerLeft.X, ptLowerLeft.Y);
        //    ContextMNExportImport.BringToFront();
        //}

        private void FrmDevExpPopupGrid_Load(object sender, EventArgs e)
        {
            try
            {
                //MainGridDetail.DataSource = null;
                //MainGridDetail.RefreshDataSource();

                //MainGridDetail.DataSource = DTab;
                //MainGridDetail.RefreshDataSource();

                //foreach (DevExpress.XtraGrid.Columns.GridColumn Column in GrdDet.Columns)
                //{
                //    if (Column.FieldName != "")
                //    {
                //        Column.Caption = Column.FieldName;
                //        Column.Caption = Column.Caption.Replace("_", " ");
                //        Column.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Column.Caption.ToLower());
                //    }
                //}
                if (Val.ToString(SummrisedColumn) != "")
                {
                    foreach (string Str in SummrisedColumn.Split(','))
                    {
                        GrdDet.Columns[Str].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        GrdDet.Columns[Str].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    } 
                }
                if (Val.ToString(CountedColumn) != "")
                {
                    foreach (string Str in CountedColumn.Split(','))
                    {
                        GrdDet.Columns[Str].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        GrdDet.Columns[Str].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    }
                }
                GrdDet.OptionsView.ShowAutoFilterRow = true;
                GrdDet.BestFitColumns();
                
            }
            catch (Exception Ex)
            {
                Global.Confirm(Ex.Message);

            }
            
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();

        }

        private void FrmDevExpPopupGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (DialogCloseOnEscape = true && e.KeyCode == Keys.Escape)
            {
                lblClose_Click(null, null);
            }
        }
        #endregion

        #region Operation

        private void ExportImport(string format, string dlgHeader, string dlgFilter)
        {            
            GrdDet.OptionsPrint.ExpandAllDetails = true;
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
                            GrdDet.ExportToPdf(Filepath);

                            break;
                        case "xls":
                            GrdDet.ExportToXls(Filepath);


                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDet.CreateExportLink(new DevExpress.XtraExport.ExportXlsProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
                        case "xlsx":
                            GrdDet.ExportToXlsx(Filepath);


                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDet.CreateExportLink(new DevExpress.XtraExport.ExportXlsxProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
                        case "rtf":
                            GrdDet.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GrdDet.ExportToText(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDet.CreateExportLink(new DevExpress.XtraExport.ExportTxtProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);
                            break;
                        case "html":
                            GrdDet.ExportToHtml(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDet.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(Filepath));

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

        #endregion

        private void GrdDet_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                DRow = GrdDet.GetDataRow(e.RowHandle);
                this.Close();
            }
        }

        private void GrdDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DRow = GrdDet.GetDataRow(GrdDet.FocusedRowHandle);
                this.Close();
            }
        }

       
      




    }
}
