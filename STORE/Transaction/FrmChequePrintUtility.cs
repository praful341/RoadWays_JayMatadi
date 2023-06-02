using RoadWays.Report;
using System;
using System.Data;
using System.Windows.Forms;
using Global = RoadWays.Class.Global;

namespace RoadWays.Transaction
{
    public partial class FrmChequePrintUtility : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        public FrmChequePrintUtility()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            Val.frmGenSet(this);
            this.Show();
            DTPChequeDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPChequeDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPChequeDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPChequeDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPChequeDate.EditValue = DateTime.Now;
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAmount.Text = "0";
            radiobank.SelectedIndex = 3;
            DTPChequeDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPChequeDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPChequeDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPChequeDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPChequeDate.EditValue = DateTime.Now;
            DTPChequeDate.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtExcel = new DataTable();
            //if (txtName.Text.Length == 0)
            //{
            //    Global.Message("Name Is Required .. ");
            //    txtName.Focus();
            //    return;
            //}
            if (txtAmount.Text.Length == 0)
            {
                Global.Message("Amount Is Required .. ");
                txtAmount.Focus();
                return;
            }
            string Name = Val.ToString(txtName.Text);
            double Amount = Val.Val(this.txtAmount.Text);
            string Amount_In_Word = (Global.NumberToWords(Val.ToInt(Amount)).Replace("-", " ") + " ONLY").ToUpper();
            string Date = Convert.ToString(Convert.ToDateTime(DTPChequeDate.Text).ToString("ddMMyyyy"));

            dtExcel.Columns.Add("PAYTO", typeof(string));
            dtExcel.Columns.Add("CDATE", typeof(string));
            dtExcel.Columns.Add("AMT", typeof(string));
            dtExcel.Columns.Add("AMTINWORD", typeof(string));
            DataRow Dr = dtExcel.NewRow();
            Dr["PAYTO"] = Name;
            Dr["CDATE"] = Date;
            Dr["AMT"] = Amount;
            Dr["AMTINWORD"] = Amount_In_Word;
            dtExcel.Rows.Add(Dr);

            dtExcel.AcceptChanges();

            FrmReportViewer FrmReportViewer = new Report.FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(dtExcel);
            if (radiobank.EditValue == "I")
            {
                FrmReportViewer.ShowForm("Cheque_Indus_Print", 120, Report.FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else if (radiobank.EditValue == "Y")
            {
                FrmReportViewer.ShowForm("Cheque_Print_Utility", 120, Report.FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else if (radiobank.EditValue == "IDBI")
            {
                FrmReportViewer.ShowForm("Cheque_IDBI_Utility", 120, Report.FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else if (radiobank.EditValue == "KOTAK")
            {
                FrmReportViewer.ShowForm("Cheque_HDFC_Utility", 120, Report.FrmReportViewer.ReportFolder.ACCOUNT);
            }

            dtExcel.Dispose();
            dtExcel = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChequePrintUtility_Load(object sender, EventArgs e)
        {
            DTPChequeDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPChequeDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPChequeDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPChequeDate.Properties.CharacterCasing = CharacterCasing.Upper;
            DTPChequeDate.EditValue = DateTime.Now;
            DTPChequeDate.Focus();
        }
    }
}
