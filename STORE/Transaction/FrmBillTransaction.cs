using BLL.FunctionClasses.Account;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using RoadWays.Class;
using RoadWays.Report;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays.Transaction
{
    public partial class FrmBillTransaction : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ItemPurchase ObjItemPurchase = new ItemPurchase();
        ItemPurchaseMaster ObjPurchase = new ItemPurchaseMaster();
        Invoice_Entry ObjInvoiceEntry = new Invoice_Entry();
        string Form_Type = "";

        public FrmBillTransaction()
        {
            InitializeComponent();
        }
        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            if (Global.Confirm("Are You Sure To Save ?", "RoadWays", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            Int64 IntRes = 0;
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();

            Invoice_EntryProperty.TransactionMasterID = Val.ToInt64(txtTransactionID.Text);
            Invoice_EntryProperty.Invoice_No = Val.ToString(txtInvoiceNo.Text);
            Invoice_EntryProperty.Transaction_Date = Val.DBDate(DTPTranDate.Text);

            Invoice_EntryProperty.From_Party_Name = Val.ToString(LookupFromParty.Text);
            Invoice_EntryProperty.From_Party_GSTNo = Val.ToString(txtFromPartyGSTNo.Text);
            Invoice_EntryProperty.To_Party_Name = Val.ToString(LookupToParty.Text);
            Invoice_EntryProperty.To_Party_GSTNo = Val.ToString(txtToPartyGSTNo.Text);

            Invoice_EntryProperty.From_Destination = Val.ToInt64(LookupFromDestination.EditValue);
            Invoice_EntryProperty.To_Destination = Val.ToInt64(LookupToDestination.EditValue);
            Invoice_EntryProperty.Truck_No = Val.ToInt64(LookupTruckNo.EditValue);
            Invoice_EntryProperty.LR_No = Val.ToString(txtLRNo.Text);
            Invoice_EntryProperty.Remark = Val.ToString(txtRemark.Text);
            Invoice_EntryProperty.Item_Code = Val.ToInt64(LookUpUnit.EditValue);
            Invoice_EntryProperty.Description = Val.ToString(LookUpDescription.EditValue);

            Invoice_EntryProperty.Quantity = Val.ToDecimal(txtQty.Text);
            Invoice_EntryProperty.Weight = Val.ToDecimal(txtWeight.Text);
            Invoice_EntryProperty.Amount = Val.ToDecimal(txtAmount.Text);

            IntRes = ObjInvoiceEntry.SaveBillTransaction(Invoice_EntryProperty);

            if (IntRes != 0)
            {
                //Global.Confirm("Save Data Successfully");
                DialogResult result = MessageBox.Show("Bill Entry Save Succesfully and Invoice no is : " + Val.ToInt64(txtInvoiceNo.Text) + " Are you sure print this Bill Entry?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    btnClear_Click(null, null);
                    return;
                }
                Invoice_EntryProperty = new Invoice_EntryProperty();
                ObjInvoiceEntry = new Invoice_Entry();

                Invoice_EntryProperty.Invoice_Date = Val.DBDate(DTPTranDate.Text);
                Invoice_EntryProperty.Trn_Id = Val.ToInt64(txtTransactionID.Text);

                DataTable dtOriginal = ObjInvoiceEntry.GetTransactionPrintRoadWaysData(Invoice_EntryProperty); //ObjInvoice.GetPrintData(Property);


                FrmReportViewer FrmReportViewer = new FrmReportViewer();
                FrmReportViewer.DS.Tables.Add(dtOriginal);
                FrmReportViewer.GroupBy = "";
                FrmReportViewer.RepName = "";
                FrmReportViewer.RepPara = "";
                this.Cursor = Cursors.Default;
                FrmReportViewer.AllowSetFormula = true;
                btnClear_Click(null, null);
                if (Global.gStrStrHostName == "PRAFUL-PC")
                {
                    FrmReportViewer.ShowForm("Bill_Detail_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                }
                else
                {

                    FrmReportViewer.ShowForm("Bill_Detail_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                }
                Invoice_EntryProperty = null;
                FrmReportViewer.DS.Tables.Clear();
                FrmReportViewer.DS.Clear();
                FrmReportViewer = null;

                dtOriginal = null;
                GetData();
            }
            else
            {
                Global.Confirm("Error in Data Save");
                txtInvoiceNo.Focus();
            }

            //if (IntRes != 0)
            //{
            //    Global.Confirm("Save Data Successfully");
            //    GetData();
            //    btnClear_Click(null, null);
            //}
            //else
            //{
            //    Global.Confirm("Error in Data Save");
            //    txtInvoiceNo.Focus();
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";

            txtTransactionID.Text = "";
            //DTPUnloadDate.Text = "";
            //LookupFromParty.EditValue = null;
            //LookupToParty.EditValue = null;
            //CmbPaymentMode.Text = "";
            //txtPaymentDays.Text = "";
            LookUpDescription.EditValue = null;
            txtRemark.Text = "";
            //txtHolding.Text = "0";

            //LookupFromDestination.EditValue = null;
            //LookupToDestination.EditValue = null;
            //LookupTruckNo.EditValue = null;

            if (lblMode.Text == "Add Mode")
            {
                string Invoice_No = Val.ToString(ObjInvoiceEntry.GEtMaximumID("Bill_Entry"));
                txtInvoiceNo.Text = Invoice_No.ToString();
            }

            //txtAdvance.Text = "0";
            //txtDiesel.Text = "0";
            //txtCommission.Text = "0";

            //ChkOwnTruck.Checked = false;
            //txtCommission.Enabled = true;

            //txtInvoiceNo.Text = "";

            //txtSGST.Text = "";
            //txtCGST.Text = "";
            //txtIGST.Text = "";
            txtQty.Text = "0";
            txtWeight.Text = "0";
            txtAmount.Text = "0";
            //txtNetAmt.Text = "0";
            DTPTranDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPTranDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPTranDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPTranDate.Properties.CharacterCasing = CharacterCasing.Upper;

            //DTPUnloadDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            //DTPUnloadDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            //DTPUnloadDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DTPUnloadDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPTranDate.EditValue = DateTime.Now;
            //DTPUnloadDate.EditValue = DateTime.Now;

            //CmbPaymentMode.SelectedIndex = 0;
            txtTransactionID.Text = ObjInvoiceEntry.FindNewRoadWays_TranID(Form_Type).ToString();
            //txtChallanNo.Text = "";

            txtLRNo.Text = "";
            //txtMT.Text = "";
            //txtBaki.Text = "0";
            //txtFreight.Text = "0";
            txtRemark.Text = "";

            PanelShow.Enabled = true;

            DTPTranDate.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region functions

        private bool ValSave()
        {
            if (string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                Global.Confirm("Invoice No Is Required");
                txtInvoiceNo.Focus();
                return false;
            }

            if (Val.ToString(LookupFromParty.Text.Trim()) == "")
            {
                Global.Confirm("From Party Is Required");
                LookupFromParty.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(DTPTranDate.Text.Trim()))
            {
                Global.Confirm("Party Tansaction Date Is Required");
                DTPTranDate.Focus();
                return false;
            }

            return true;
        }

        #endregion

        private void FrmItemPurchaseMaster_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            //Ledger_MasterProperty Party = new Ledger_MasterProperty();
            //Party.Party_Type = "";
            //Global.LOOKUPFromParty(LookupFromParty, Party);
            //Global.LOOKUPToParty(LookupToParty, Party);
            //Party = null;
            Global.LOOKUPFrom_PartyName(LookupFromParty);
            Global.LOOKUPTo_PartyName(LookupToParty);
            Global.LOOKUPTo_Description(LookUpDescription);

            Global.LOOKUPUnitType(LookUpUnit);


            Global.LOOKUPCity(LookupFromDestination);
            Global.LOOKUPCity(LookupToDestination);
            Global.LOOKUPTruck(LookupTruckNo);

            LookupFromDestination.Text = "SURAT";
            LookupToDestination.Text = "ULHASNAGAR";

            //this.Text = "Purchase Invoice";
            dtpSearchFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpSearchFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            dtpSearchFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpSearchFromDate.Properties.CharacterCasing = CharacterCasing.Upper;

            dtpSearchToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dtpSearchToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            dtpSearchToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtpSearchToDate.Properties.CharacterCasing = CharacterCasing.Upper;

            dtpSearchFromDate.EditValue = DateTime.Now;
            dtpSearchToDate.EditValue = DateTime.Now;
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PanelShow.Enabled = true;
        }

        private Boolean ValDelete()
        {
            if (Val.Val(txtInvoiceNo.Text) == 0)
            {
                Global.Message("Invoice No Is Required");
                txtInvoiceNo.Focus();
                return false;
            }
            return true;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow DRow = GrdBillTransaction.GetDataRow(e.RowHandle);

                    lblMode.Text = "Edit Mode";
                    txtTransactionID.Text = Val.ToString(DRow["transaction_id"]);
                    txtInvoiceNo.Text = Val.ToString(DRow["invoice_no"]);
                    DTPTranDate.EditValue = Val.DBDate(DRow["transaction_date"].ToString());
                    LookupFromParty.Text = Val.ToString(DRow["from_party_name"]);
                    LookupToParty.Text = Val.ToString(DRow["To_Party_name"]);
                    txtFromPartyGSTNo.Text = Val.ToString(DRow["from_party_gstno"]);
                    txtToPartyGSTNo.Text = Val.ToString(DRow["to_party_gstno"]);
                    LookupFromDestination.EditValue = Val.ToInt64(DRow["from_city_code"]);
                    LookupToDestination.EditValue = Val.ToInt64(DRow["to_city_code"]);
                    LookupTruckNo.EditValue = Val.ToInt64(DRow["truck_id"]);
                    txtRemark.Text = Val.ToString(DRow["remark"]);
                    txtLRNo.Text = Val.ToString(DRow["lr_no"]);
                    LookUpUnit.EditValue = Val.ToInt64(DRow["Unit_ID"]);
                    LookUpDescription.Text = Val.ToString(DRow["description"]);
                    txtWeight.Text = Val.ToString(DRow["weight"]);
                    txtQty.Text = Val.ToString(DRow["qty"]);
                    txtAmount.Text = Val.ToString(DRow["amount"]);
                    DTPTranDate.Focus();
                }
            }
        }

        public DataTable GetData()
        {
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
            Invoice_EntryProperty.From_Date = Val.DBDate(dtpSearchFromDate.Text);
            Invoice_EntryProperty.To_Date = Val.DBDate(dtpSearchToDate.Text);
            DataTable DTab = ObjInvoiceEntry.Bill_Transaction_GetData(Invoice_EntryProperty);
            dgvBillTransaction.DataSource = DTab;
            dgvBillTransaction.RefreshDataSource();
            GrdBillTransaction.BestFitColumns();
            Invoice_EntryProperty = null;
            return DTab;
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
            ObjInvoiceEntry = new Invoice_Entry();

            Invoice_EntryProperty.Invoice_Date = Val.DBDate(DTPTranDate.Text);
            Invoice_EntryProperty.Trn_Id = Val.ToInt64(txtTransactionID.Text);

            DataTable dtOriginal = ObjInvoiceEntry.GetTransactionPrintRoadWaysData(Invoice_EntryProperty); //ObjInvoice.GetPrintData(Property);


            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(dtOriginal);
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;
            if (Global.gStrStrHostName == "PRAFUL-PC")
            {
                //FrmReportViewer.ShowForm_SubReport("Bill_Detail_New_Duplicate_Surat", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                FrmReportViewer.ShowForm_SubReport("Bill_Detail_Duplicate_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else
            {

                FrmReportViewer.ShowForm_SubReport("Bill_Detail_Duplicate_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }
            Invoice_EntryProperty = null;
            FrmReportViewer.DS.Tables.Clear();
            FrmReportViewer.DS.Clear();
            FrmReportViewer = null;
            dtOriginal = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure To Delete ?", "RoadWays", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            int IntRes = 0;
            Invoice_EntryProperty Invoice_EntryPropertyNew = new Invoice_EntryProperty();
            Invoice_EntryPropertyNew.TransactionMasterID = Val.ToInt64(txtTransactionID.Text);
            IntRes = ObjInvoiceEntry.DeleteBillTransaction(Invoice_EntryPropertyNew);

            if (IntRes != 0)
            {
                Global.Confirm("Data Deleted Successfully");
                GetData();
                btnClear_Click(null, null);
            }
            else
            {
                Global.Confirm("Error in Data Delete");
                txtInvoiceNo.Focus();
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void LookupFromDestination_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCityMaster frmCnt = new FrmCityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCity(LookupFromDestination);
            }
        }
        private void LookupToDestination_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCityMaster frmCnt = new FrmCityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCity(LookupToDestination);
            }
        }
        private void LookupTruckNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmTruckMaster frmCnt = new FrmTruckMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPTruck(LookupTruckNo);
            }
        }

        private void LookUpUnit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmUnitTypeMaster frmCnt = new FrmUnitTypeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPUnitType(LookUpUnit);
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal Qty = Val.ToDecimal(txtQty.Text);
            decimal Weight = Val.ToDecimal(txtWeight.Text);
            txtAmount.Text = Val.ToDecimal(Qty * Weight).ToString();
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            decimal Qty = Val.ToDecimal(txtQty.Text);
            decimal Weight = Val.ToDecimal(txtWeight.Text);
            txtAmount.Text = Val.ToDecimal(Qty * Weight).ToString();
        }

        private void LookupFromParty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LedgerMaster objFromParty = new LedgerMaster();
            DataTable From_Party = objFromParty.From_Party_Distinct_GetData();

            for (int i = 0; i <= From_Party.Rows.Count - 1; i++)
            {
                string From_Party_Name = LookupFromParty.Text;

                if (From_Party_Name == From_Party.Rows[i]["from_party_name"].ToString())
                {
                    txtFromPartyGSTNo.Text = From_Party.Rows[i]["From_Party_GSTNo"].ToString();
                    break;
                }
                else
                {
                    txtFromPartyGSTNo.Text = "0";
                }
            }
        }

        private void LookupToParty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LedgerMaster objToParty = new LedgerMaster();
            DataTable To_Party = objToParty.To_Party_Distinct_GetData();

            for (int i = 0; i <= To_Party.Rows.Count - 1; i++)
            {
                string To_Party_Name = LookupToParty.Text;

                if (To_Party_Name == To_Party.Rows[i]["to_party_name"].ToString())
                {
                    txtToPartyGSTNo.Text = To_Party.Rows[i]["To_Party_GSTNo"].ToString();
                    break;
                }
                else
                {
                    txtToPartyGSTNo.Text = "0";
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
            ObjInvoiceEntry = new Invoice_Entry();

            Invoice_EntryProperty.Invoice_Date = Val.DBDate(DTPTranDate.Text);
            Invoice_EntryProperty.Trn_Id = Val.ToInt64(txtTransactionID.Text);

            DataTable dtOriginal = ObjInvoiceEntry.GetTransactionPrintRoadWaysData(Invoice_EntryProperty); //ObjInvoice.GetPrintData(Property);


            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(dtOriginal);
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;
            if (Global.gStrStrHostName == "PRAFUL-PC")
            {
                //FrmReportViewer.ShowForm_SubReport("Bill_Detail_New_Duplicate_Surat", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                FrmReportViewer.ShowForm_SubReport_NEW("Bill_Detail_Duplicate_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else
            {

                FrmReportViewer.ShowForm_SubReport_NEW("Bill_Detail_Duplicate_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }
            Invoice_EntryProperty = null;
            FrmReportViewer.DS.Tables.Clear();
            FrmReportViewer.DS.Clear();
            FrmReportViewer = null;
            dtOriginal = null;
        }
    }
}