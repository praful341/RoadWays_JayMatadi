using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Report;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;
namespace RoadWays.Report
{
    public partial class FrmBillPrintSurat : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        string mStrReportGroup = string.Empty;
        string RptName = "";
        ReportParams ObjReportParams = new ReportParams();
        New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();
        DataSet DSet;
        DataTable DTab;
        #region Counstructor

        public FrmBillPrintSurat()
        {
            InitializeComponent();
            DSet = new DataSet();
        }

        public void ShowForm(string pStrReportGroup)
        {
            mStrReportGroup = pStrReportGroup;
            Val.frmGenSet(this);
            AttachFormEvents();
            RptName = pStrReportGroup;
            this.Text = mStrReportGroup + " Report";
            this.Show();

            DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPFromDate.EditValue = DateTime.Now;
            DTPToDate.EditValue = DateTime.Now;

            Ledger_MasterProperty Party = new Ledger_MasterProperty();
            Party.Party_Type = "";
            Global.LOOKUPFromParty(LookupFromParty, Party);
            //Global.LOOKUPToParty(LookupToParty, Party);

            Global.ComboToParty(chkToParty, Party);

            Party = null;

            DTPFromDate.EditValue = DateTime.Now;
            DTPToDate.EditValue = DateTime.Now;
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPToDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPFromDate.EditValue = DateTime.Now;
            DTPToDate.EditValue = DateTime.Now;
            LookupFromParty.EditValue = null;
            LookupToParty.EditValue = null;
            DTPFromDate.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ReportParams_Property ReportParams_Property = new BLL.PropertyClasses.Report.ReportParams_Property();


        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            ReportParams_Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
            //ReportParams_Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
            ReportParams_Property.To_Party_Code = Val.Trim(chkToParty.Properties.GetCheckedItems());
            ReportParams_Property.Stock_From_Issue_Date = Val.DBDate(DTPFromDate.Text);
            ReportParams_Property.Stock_To_Issue_Date = Val.DBDate(DTPToDate.Text);

            RptName = "Bill Report";
            DSet = new DataSet();
        

            if (this.backgroundWorker1.IsBusy)
            {
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string s = Val.Trim(chkToParty.Properties.GetCheckedItems());
            int[] nums = Array.ConvertAll(s.Split(','), int.Parse);
            DataTable DTab1 = new DataTable();

            for (int i = 0; i < nums.Length; i++)
            {
                DTab = ObjReportParams.Get_Bill_Tansaction_Surat_Report(ReportParams_Property, "BILL_REPORT_PRINT", nums[i]);

                DSet.Tables.Add(DTab);
            }

            DSet.Tables.Add(DTab1);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            //DataView view = new DataView(DTab);
            //DataTable dtparty = view.ToTable(true, "TO_PARTY");
            //for (int i = 0; i < dtparty.Rows.Count; i++)
            //{
            //    DataTable dtTemp = new DataTable();
            //    dtTemp = DTab.Select("TO_PARTY='" + Convert.ToString(dtparty.Rows[i]["TO_PARTY"]) + "'").CopyToDataTable();
            //    FrmReportViewer.DS.Tables.Add(dtTemp);
            //}

            FrmReportViewer.DS = DSet;
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;

            //FrmReportViewer.ShowForm("Bill_Detail_Surat", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            FrmReportViewer.ShowForm_SubReport("Bill_Detail_Surat_Main", 120, FrmReportViewer.ReportFolder.ACCOUNT);

            DTab = null;
            FrmReportViewer.DS.Tables.Clear();
            FrmReportViewer.DS.Clear();
            FrmReportViewer = null;
        }
    }
}
