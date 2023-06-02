using BLL.FunctionClasses.Report;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Report;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;
namespace RoadWays.Report
{
    public partial class FrmReportList : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        string mStrReportGroup = string.Empty;
        string RptName = "";
        string Type = "";
        ReportParams ObjReportParams = new ReportParams();
        New_Report_DetailProperty ObjReportDetailProperty = new New_Report_DetailProperty();

        #region Counstructor

        public FrmReportList()
        {
            InitializeComponent();
        }

        public void ShowForm(string pStrReportGroup, string pStrType)
        {
            mStrReportGroup = pStrReportGroup;
            Val.frmGenSet(this);
            AttachFormEvents();
            RptName = pStrReportGroup;
            Type = pStrType;
            //lblTitle.Text = mStrReportGroup + " Reports..";
            this.Text = mStrReportGroup + " Report";
            this.Show();
            SetControl();
            //ChkCmbCompany.Focus();
            ////DTPStockFromDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            ////DTPStockToDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            ////DTPAcceptFromDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            ////DTPAcceptToDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            //DTPFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            //DTPFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            //DTPFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DTPFromDate.Properties.CharacterCasing = CharacterCasing.Upper;

            //DTPAcceptToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            //DTPAcceptToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            //DTPAcceptToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DTPAcceptToDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPFromDate.EditValue = DateTime.Now;
            DTPToDate.EditValue = DateTime.Now;
            Ledger_MasterProperty Party = new Ledger_MasterProperty();
            Party.Party_Type = "";
            Global.LOOKUPFromParty(LookupFromParty, Party);
            Global.ComboToParty(chkToParty, Party);
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

        private void SetControl()
        {
            //Global.LOOKUPCompanyComboBox(ChkCmbCompany);
            //ChkCmbCompany.SetEditValue(BLL.GlobalDec.gEmployeeProperty.Company_Code);

            //Global.LOOKUPBranchComboBox(ChkCmbBranch);
            //ChkCmbBranch.SetEditValue(BLL.GlobalDec.gEmployeeProperty.Branch_Code);

            //Global.LOOKUPLocationComboBox(ChkCmbLocation);
            //ChkCmbLocation.SetEditValue(BLL.GlobalDec.gEmployeeProperty.Location_Code);

            //Global.LOOKUPCompanyComboBox(ChkCmbFromComp);
            //Global.LOOKUPCompanyComboBox(ChkCmbToComp);
            //Global.LOOKUPBranchComboBox(ChkCmbFromBranch);
            //Global.LOOKUPBranchComboBox(ChkCmbToBranch);
            //Global.LOOKUPLocationComboBox(ChkCmbFromLocation);
            //Global.LOOKUPLocationComboBox(ChkCmbToLocation);

            //Global.LOOKUPItemComboBox(ChkCmbItem);
            //Global.LOOKUPItemCategoryComboBox(ChkCmbCategory);
            //Global.LOOKUPItemGroupComboBox(ChkCmbGroup);

            //Global.LOOKUPDepartment(ChkCmbFromDept);
            //Global.LOOKUPDepartment(ChkCmbToDept);

            //Global.LOOKUPProcess(ChkCmbFromProcess);
            //Global.LOOKUPProcess(ChkCmbToProcess);

            //Global.LOOKUPEmployee(ChkCmbEmployee);
            //Global.LOOKUPRough(ChkCmbRoughName);
            //Global.LOOKUPRoughTypeCode(ChkCmbRoughType);

            //Global.LOOKUPClarity(ChkCmbMfgClarity, "Mfg");
            //Global.LOOKUPClarity(ChkCmbClvClarity, "Clv");
            //Global.LOOKUPShape(ChkCmbShape);
            //Global.LOOKUPSieve(ChkCmbSieve);
            //Global.LOOKUPColor(ChkCmbColor);
            //Global.LOOKUPProcess(ChkCmbProcess);
            //Global.LOOKUPParty(ChkCmbFromParty);
            //Global.LOOKUPParty(ChkCmbToParty);
            //Global.LOOKUPCity(ChkCmbCity);
        }

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
            chkToParty.SetEditValue(null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ReportParams_Property ReportParams_Property = new BLL.PropertyClasses.Report.ReportParams_Property();
        DataTable DTab;

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {

            ReportParams_Property.Stock_From_Issue_Date = Val.DBDate(DTPFromDate.Text).ToString();
            ReportParams_Property.Stock_To_Issue_Date = Val.DBDate(DTPToDate.Text);
            ReportParams_Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
            //ReportParams_Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
            ReportParams_Property.To_Party_Code = Val.Trim(chkToParty.Properties.GetCheckedItems());
            ReportParams_Property.Type = Val.ToString(Type);

            RptName = "Transaction Report Surat";

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
            DTab = ObjReportParams.Get_Tansaction_Report(ReportParams_Property, "BILL_REPORT_GETDATA");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FrmGReportViewer FrmPReportViewer = new Report.FrmGReportViewer();
            FrmPReportViewer.mDTDetail = DTab;
            //FrmPReportViewer.Group_By_Tag = rptMultiSelect1.GetTagValue;
            //FrmPReportViewer.Group_By_Text = rptMultiSelect1.GetTextValue;

            FrmPReportViewer.Report_Type = "Summary";

            FrmPReportViewer.ReportHeaderName = "Jay Matadi Transport";
            FrmPReportViewer.DTab = DTab;
            FrmPReportViewer.FilterBy = GetFilterByValue();

            if (FrmPReportViewer.DTab == null || FrmPReportViewer.DTab.Rows.Count == 0)
            {
                this.Cursor = Cursors.Default;
                FrmPReportViewer.Dispose();
                FrmPReportViewer = null;
                Global.Confirm("Data Not Found");
                return;
            }
            FrmPReportViewer.MdiParent = Global.gMainFormRef;
            FrmPReportViewer.ShowForm();
        }

        private void FrmReportList_Shown(object sender, EventArgs e)
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
        }

        private string GetFilterByValue()
        {
            string Str = string.Empty;
            if (Type == "TransactionReport")
            {
                Str = "";
            }
            else if (Type == "TruckWise")
            {
                Str = "Truck Wise Detail Report";
            }

            //string Str = "";
            return Str;
        }
    }
}
