using BLL;
using BLL.FunctionClasses.Account;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using RoadWays.Class;
using RoadWays.Report;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RoadWays.Transaction
{
    public partial class FrmItemPurchaseMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ItemPurchase ObjItemPurchase = new ItemPurchase();
        ItemPurchaseMaster ObjPurchase = new ItemPurchaseMaster();
        Invoice_Entry ObjInvoiceEntry = new Invoice_Entry();
        string strSMSSend = string.Empty;
        public FrmItemPurchaseMaster()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                Global.Confirm("Invoice No Is Required");
                txtInvoiceNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DTPInvoiceDate.Text.Trim()))
            {
                Global.Confirm("Invoice Date Is Required");
                DTPInvoiceDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(LookupFromParty.Text.Trim()))
            {
                Global.Confirm("Party Name Is Required");
                LookupFromParty.Focus();
                return;
            }
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
            Invoice_EntryProperty.Invoice_No = Val.ToString(txtInvoiceNo.Text);
            DataTable DTab = ObjInvoiceEntry.GetData_New(Invoice_EntryProperty);

            if (DTab.Rows.Count > 0)
            {
                Global.Message("Invoice Already Exists. Please Check...");
                return;
            }
            else
            {
                Global.LOOKUPUnitType(RepLookUpUnit);
                PanelShow.Enabled = false;
                PanelSave.Enabled = true;
                GrdPurchase.Enabled = true;
                GetTransactionDetail();
                dgvPurchase.BestFitColumns();
                dgvPurchase.Focus();
            }
        }

        public Invoice_EntryProperty SaveItemPurchaseMaster()
        {
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();

            Invoice_EntryProperty.TransactionMasterID = Val.ToInt64(txtTransactionID.Text);
            Invoice_EntryProperty.Financial_Year = GlobalDec.gEmployeeProperty.gFinancialYear;

            //string Invoice_No = Val.ToString(ObjInvoiceEntry.GEtMaximumID("Bill_Entry"));
            //txtInvoiceNo.Text = Invoice_No.ToString();

            Invoice_EntryProperty.Invoice_No = Val.ToString(txtInvoiceNo.Text);
            Invoice_EntryProperty.Invoice_Date = Val.DBDate(DTPInvoiceDate.Text);
            Invoice_EntryProperty.Transaction_Date = Val.DBDate(DTPTranDate.Text);
            Invoice_EntryProperty.Payment_Mode = Val.ToString(CmbPaymentMode.SelectedItem);
            Invoice_EntryProperty.Payment_Days = Val.ToString(txtPaymentDays.Text);
            Invoice_EntryProperty.Payment_Date = Val.DBDate(DTPPaymentDate.Text);
            Invoice_EntryProperty.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
            Invoice_EntryProperty.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);

            Invoice_EntryProperty.From_Destination = Val.ToInt64(LookupFromDestination.EditValue);
            Invoice_EntryProperty.To_Destination = Val.ToInt64(LookupToDestination.EditValue);

            Invoice_EntryProperty.Own_Truck = Val.ToInt(ChkOwnTruck.EditValue);

            Invoice_EntryProperty.My_Commission = Val.ToDecimal(txtMyCommission.Text);
            Invoice_EntryProperty.Advance = Val.ToDecimal(txtAdvance.Text);
            Invoice_EntryProperty.Diesel_Expence = Val.ToDecimal(txtDieselExpence.Text);
            Invoice_EntryProperty.Truck_No = Val.ToInt64(LookupTruckNo.EditValue);
            Invoice_EntryProperty.Net_Amt = Val.ToDecimal(txtNetAmtLocal.Text);
            Invoice_EntryProperty.Labour_Amt = Val.ToDecimal(txtLabourAmt.Text);
            Invoice_EntryProperty.Company_Code = Val.ToInt64(GlobalDec.gEmployeeProperty.Company_Code);

            Invoice_EntryProperty.Remark = txtRemark.Text;
            Invoice_EntryProperty.Challan_No = Val.ToString(txtChallanNo.Text);
            Invoice_EntryProperty.T_Amt = Val.ToDouble(txtBillT.Text);

            return Invoice_EntryProperty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                Invoice_EntryProperty Invoice_EntryPropertyNew = new Invoice_EntryProperty();

                if (lblMode.Text == "Add Mode")
                {
                    string Invoice_No = Val.ToString(ObjInvoiceEntry.GEtMaximumID("Bill_Entry"));
                    txtInvoiceNo.Text = Invoice_No.ToString();
                }

                Invoice_EntryPropertyNew = SaveItemPurchaseMaster();
                Invoice_EntryPropertyNew = ObjInvoiceEntry.SaveInvoiceEntryMaster(Invoice_EntryPropertyNew);
                Int64 Newmstid = Val.ToInt64(Invoice_EntryPropertyNew.TransactionMasterID.ToString());

                Invoice_EntryPropertyNew = null;

                ArrayList AL = new ArrayList();

                DataTable DTab = (System.Data.DataTable)GrdPurchase.DataSource;
                DTab.AcceptChanges();

                foreach (DataRow DRow in DTab.Rows)
                {
                    if (Val.Val(DRow["Unit_ID"]) == 0)
                    {
                        continue;
                    }

                    Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();

                    Invoice_EntryProperty.SGST = Val.ToDecimal(DRow["SGST_Per"]);
                    //Invoice_EntryProperty.SGST_Amt = Val.Val(DRow["SGST_Amt"]);
                    Invoice_EntryProperty.CGST = Val.ToDecimal(DRow["CGST_Per"]);
                    //Invoice_EntryProperty.CGST_Amt = Val.Val(DRow["CGST_Amt"]);
                    //Invoice_EntryProperty.IGST = 0;
                    Invoice_EntryProperty.IGST_Amt = Val.ToDecimal(DRow["IGST_Per"]);
                    Int64 TransactionMasterID = Val.ToInt64(DRow["TransactionMasterID"]);
                    if (TransactionMasterID == 0)
                    {
                        Invoice_EntryProperty.TransactionMasterID = Val.ToInt64(Newmstid);
                        Invoice_EntryProperty.TransactionDetailID = Val.ToInt64(DRow["TransactionDetailID"]);
                    }
                    else
                    {
                        Invoice_EntryProperty.TransactionMasterID = Val.ToInt64(DRow["TransactionMasterID"]);
                        Invoice_EntryProperty.TransactionDetailID = Val.ToInt64(DRow["TransactionDetailID"]);
                    }

                    //Invoice_EntryProperty.HSN_ID = Val.ToInt64(DRow["HSN_ID"]);
                    //Invoice_EntryProperty.Item_Code = Val.ToInt64(DRow["Item_Code"]);
                    Invoice_EntryProperty.Unit_ID = Val.ToInt64(DRow["Unit_ID"]);
                    Invoice_EntryProperty.Weight = Val.ToDecimal(DRow["Weight"]);
                    Invoice_EntryProperty.Quantity = Val.ToDecimal(DRow["Quantity"]);
                    Invoice_EntryProperty.Rate_Dollar = Val.ToDecimal(DRow["Rate"]);
                    //Invoice_EntryProperty.Gross_Amt = Val.Val(DRow["Gross_Amt"]);
                    //Invoice_EntryProperty.Disc_Per = Val.Val(DRow["Discount"]);
                    Invoice_EntryProperty.Net_Amt = Val.ToDecimal(DRow["NetAmount"]);
                    //Invoice_EntryProperty.Remark = Val.ToString(DRow["Remarks"]);


                    AL.Add(Invoice_EntryProperty);
                }
                IntRes = ObjInvoiceEntry.SavePurchaseDetail(AL);

                if (IntRes != 0)
                {
                    //Global.Confirm("Save Data Successfully");
                    DialogResult result = MessageBox.Show("Bill Entry Save Succesfully and Invoice no is : " + Val.ToInt64(txtInvoiceNo.Text) + " Are you sure print this Bill Entry?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result != DialogResult.Yes)
                    {
                        btnClear_Click(null, null);
                        return;
                    }
                    Invoice_EntryPropertyNew = new Invoice_EntryProperty();
                    ObjInvoiceEntry = new Invoice_Entry();

                    Invoice_EntryPropertyNew.Invoice_Date = Val.DBDate(DTPInvoiceDate.Text);
                    Invoice_EntryPropertyNew.Trn_Id = Val.ToInt64(txtTransactionID.Text);

                    DataTable dtOriginal = ObjInvoiceEntry.GetTransactionPrintData(Invoice_EntryPropertyNew); //ObjInvoice.GetPrintData(Property);


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
                    Invoice_EntryPropertyNew = null;
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
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMode.Tag = 0;
            lblMode.Text = "Add Mode";
            txtTransactionID.Text = "";
            DTPInvoiceDate.Text = "";
            //LookupFromParty.EditValue = null;
            //LookupToParty.EditValue = null;
            CmbPaymentMode.Text = "";
            txtPaymentDays.Text = "";
            txtRemark.Text = "";

            //LookupFromDestination.EditValue = null;
            //LookupToDestination.EditValue = null;
            //LookupTruckNo.EditValue = null;

            txtAdvance.Text = "";
            txtDieselExpence.Text = "";
            txtMyCommission.Text = "";

            ChkOwnTruck.Checked = false;
            txtMyCommission.Enabled = true;

            //txtInvoiceNo.Text = "";
            //txtInvoiceNo.Enabled = true;

            if (lblMode.Text == "Add Mode")
            {
                string Invoice_No = Val.ToString(ObjInvoiceEntry.GEtMaximumID("Bill_Entry"));
                txtInvoiceNo.Text = Invoice_No.ToString();
            }

            txtSGST.Text = "";
            txtCGST.Text = "";
            txtIGST.Text = "";
            txtTotalAddAmount.Text = "0";
            txtTotalLessAmount.Text = "0";
            txtLabourAmt.Text = "0";
            DTPTranDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPTranDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPTranDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPTranDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPInvoiceDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPInvoiceDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPInvoiceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPInvoiceDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPTranDate.EditValue = DateTime.Now;
            DTPInvoiceDate.EditValue = DateTime.Now;

            CmbPaymentMode.SelectedIndex = 0;
            //CalculateGridAmount(dgvPurchase.FocusedRowHandle);
            txtTransactionID.Text = ObjInvoiceEntry.FindNewTransactionID().ToString();
            txtChallanNo.Text = "";
            txtBillT.Text = "0";

            PanelShow.Enabled = true;
            GrdPurchase.Enabled = false;
            PanelSave.Enabled = false;
            GrdPurchase.DataSource = null;

            txtGrossAmtLocal.Text = "0";
            txtNetAmtLocal.Text = "0";
            lblFPartyMob.Text = "";
            lblTPartyMob.Text = "";
            DTPInvoiceDate.Focus();
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
            if (string.IsNullOrEmpty(DTPInvoiceDate.Text.Trim()))
            {
                Global.Confirm("Invoice Date Is Required");
                DTPInvoiceDate.Focus();
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
            if (string.IsNullOrEmpty(CmbPaymentMode.Text.Trim()))
            {
                Global.Confirm("Payment Type Is Required");
                CmbPaymentMode.Focus();
                return false;
            }

            DataTable DTab = (DataTable)GrdPurchase.DataSource;
            if (DTab != null)
            {
                if (DTab.Rows.Count <= 0)
                {
                    Global.Confirm("Fill Transaction Items list");
                    txtInvoiceNo.Focus();
                    return false;
                }
            }

            //for (int i = 0; i < DTab.Rows.Count; i++)
            //{
            //    if (Val.Val(DTab.Rows[i]["NetAmount"]) == 0)
            //    {
            //        Global.Message("Amount is Zero Please Check Row No :" + i);
            //        return false;
            //    }
            //}

            return true;
        }

        private void GetTransactionDetail()
        {
            this.Cursor = Cursors.WaitCursor;
            GrdPurchase.DataSource = null;
            DataTable DTab = ObjInvoiceEntry.GetPurchaseDetail(Val.ToInt64(txtTransactionID.Text));
            Global.LOOKUPUnitType(RepLookUpUnit);
            GrdPurchase.DataSource = DTab;
            this.Cursor = Cursors.Default;
        }

        #endregion


        private void FrmItemPurchaseMaster_Shown(object sender, EventArgs e)
        {
            //Global.LOOKUPItemRep(RepLookUpItem);
            //Global.LOOKUPItemHSNRep(RepHSNCode);
            //LookupFromParty.EditValue = 86;
            btnClear_Click(btnClear, null);
            Ledger_MasterProperty Party = new Ledger_MasterProperty();
            Party.Party_Type = "";

            Global.LOOKUPFromParty(LookupFromParty, Party);
            Global.LOOKUPToParty(LookupToParty, Party);
            Party = null;

            Global.LOOKUPCity(LookupFromDestination);
            Global.LOOKUPCity(LookupToDestination);
            Global.LOOKUPTruck(LookupTruckNo);

            LookupFromDestination.Text = "SURAT";
            LookupToDestination.Text = "ULHASNAGAR";

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
            GrdPurchase.Enabled = false;
            PanelSave.Enabled = false;
            GrdPurchase.DataSource = null;
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
                    try
                    {
                        DataRow DRow = gridView2.GetDataRow(e.RowHandle);

                        lblMode.Text = "Edit Mode";
                        txtTransactionID.Text = Val.ToString(DRow["TransactionMasterID"]);
                        txtInvoiceNo.Text = Val.ToString(DRow["Inovice_No"]);
                        DTPTranDate.EditValue = Val.DBDate(DRow["Invoice_Date"].ToString());
                        DTPInvoiceDate.EditValue = Val.DBDate(DRow["Invoice_Date"].ToString());
                        LookupFromParty.EditValue = Val.ToInt64(DRow["From_Party_Code"]);
                        LookupToParty.EditValue = Val.ToInt64(DRow["To_Party_Code"]);
                        LookupFromDestination.EditValue = Val.ToInt64(DRow["From_City_Code"]);
                        LookupToDestination.EditValue = Val.ToInt64(DRow["To_City_Code"]);
                        LookupTruckNo.EditValue = Val.ToInt64(DRow["Truck_ID"]);
                        CmbPaymentMode.Text = Val.ToString(DRow["Payment_Type"]);
                        txtPaymentDays.Text = Val.ToString(DRow["Terms"]);
                        DTPPaymentDate.EditValue = Val.DBDate(DRow["Term_Date"].ToString());
                        txtRemark.Text = Val.ToString(DRow["Remark"]);
                        txtChallanNo.Text = Val.ToString(DRow["Challan_No"]);

                        ChkOwnTruck.EditValue = Val.ToInt(DRow["Own_Truck"]);
                        txtMyCommission.Text = Val.ToString(DRow["My_Commission"]);
                        txtAdvance.Text = Val.ToString(DRow["Advance"]);
                        txtDieselExpence.Text = Val.ToString(DRow["Diesel_Expence"]);
                        txtBillT.Text = Val.ToString(DRow["T_Amount"]);
                        txtLabourAmt.Text = Val.ToString(DRow["Labour_Amt"]);

                        GetTransactionDetail();
                        PanelShow.Enabled = true;
                        GrdPurchase.Enabled = true;
                        PanelSave.Enabled = true;
                        //CalculateGridAmount(dgvPurchase.FocusedRowHandle);
                        lblFPartyMob.Text = Val.ToString(((DataRowView)LookupFromParty.GetSelectedDataRow())["From_Party_Mobile"]);
                        lblTPartyMob.Text = Val.ToString(((DataRowView)LookupToParty.GetSelectedDataRow())["To_Party_Mobile"]);

                        txtInvoiceNo.Focus();
                    }
                    catch (Exception ex)
                    {
                        Global.Message(ex.ToString());
                        return;
                    }
                }
            }
        }

        public DataTable GetData()
        {
            Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
            Invoice_EntryProperty.From_Date = Val.DBDate(dtpSearchFromDate.Text);
            Invoice_EntryProperty.To_Date = Val.DBDate(dtpSearchToDate.Text);
            DataTable DTab = ObjInvoiceEntry.GetData(Invoice_EntryProperty);
            gridControl2.DataSource = DTab;
            gridControl2.RefreshDataSource();
            gridView2.BestFitColumns();
            Invoice_EntryProperty = null;
            GetTransactionDetail();
            return DTab;
        }

        private void RepLookUpItem_Validating(object sender, CancelEventArgs e)
        {
            //LookUpEdit type = sender as LookUpEdit;

            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "Unit_Name", type.GetColumnValue("UNIT_NAME"));
            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "HSN_ID", type.GetColumnValue("HSN_ID"));
            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "Rate", type.GetColumnValue("LAST_PURCHASE_RATE"));
            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "SGST_Rate", type.GetColumnValue("SGST_RATE"));
            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "CGST_Rate", type.GetColumnValue("CGST_RATE"));
            //dgvPurchase.SetRowCellValue(dgvPurchase.FocusedRowHandle, "IGST_Rate", type.GetColumnValue("IGST_RATE"));
        }

        private void LookupFromParty_EditValueChanged(object sender, EventArgs e)
        {
            if (LookupFromParty.Text.Trim().Length > 0)
            {
                lblFPartyMob.Text = Val.ToString(((DataRowView)LookupFromParty.GetSelectedDataRow())["From_Party_Mobile"]);// Val.ToString(LookupFromParty.GetColumnValue("From_Party_Mobile"));
                //txtPartyState.Text = LookupFromParty.GetColumnValue("Party_State_Code").ToString();
                //string gst = LookupFromParty.GetColumnValue("GSTIN").ToString();
                //if (gst.Length > 0) { CHKReverse.EditValue = 1; } else { CHKReverse.EditValue = 0; }
                //dgvPurchase.PostEditor();
            }
            else
            {
                lblFPartyMob.Text = "";
            }
            //chkGST();
        }

        //private void chkGST()
        //{
        //    if (txtPartyState.Text == GlobalDec.gEmployeeProperty.State_Code.ToString())
        //    {
        //        txtSGST.Visible = true;
        //        lblSGST.Visible = true;
        //        txtCGST.Visible = true;
        //        lblCGST.Visible = true;
        //        txtIGST.Visible = false;
        //        lblIGST.Visible = false;

        //        dgvPurchase.Columns["SGST_Rate"].Visible = true;
        //        dgvPurchase.Columns["SGST_Amt"].Visible = true;
        //        dgvPurchase.Columns["CGST_Rate"].Visible = true;
        //        dgvPurchase.Columns["CGST_Amt"].Visible = true;
        //        dgvPurchase.Columns["IGST_Rate"].Visible = false;
        //        dgvPurchase.Columns["IGST_Amt"].Visible = false;
        //    }
        //    else
        //    {
        //        txtSGST.Visible = false;
        //        lblSGST.Visible = false;
        //        txtCGST.Visible = false;
        //        lblCGST.Visible = false;
        //        txtIGST.Visible = true;
        //        lblIGST.Visible = true;
        //        dgvPurchase.Columns["SGST_Rate"].Visible = false;
        //        dgvPurchase.Columns["SGST_Amt"].Visible = false;
        //        dgvPurchase.Columns["CGST_Rate"].Visible = false;
        //        dgvPurchase.Columns["CGST_Amt"].Visible = false;
        //        dgvPurchase.Columns["IGST_Rate"].Visible = true;
        //        dgvPurchase.Columns["IGST_Amt"].Visible = true;
        //    }
        //}

        private void txtPaymentDays_EditValueChanged(object sender, EventArgs e)
        {
            dgvPurchase.PostEditor();
            if (DTPInvoiceDate.Text.Length <= 0 || txtPaymentDays.Text == "")
            {
                txtPaymentDays.Text = "";
                DTPPaymentDate.EditValue = null;
            }
            else
            {
                DateTime Date = Convert.ToDateTime(DTPInvoiceDate.EditValue).AddDays(Val.ToDouble(txtPaymentDays.Text));
                DTPPaymentDate.EditValue = Val.DBDate(Date.ToShortDateString());
            }
        }

        private void CalculateGridAmount(int rowindex)
        {
            //try
            //{
            //    decimal GSTPer = Math.Round(Val.ToDecimal(dgvPurchase.GetRowCellValue(rowindex, "SGST_Per")) + Val.ToDecimal(dgvPurchase.GetRowCellValue(rowindex, "IGST_Per")) + Val.ToDecimal(dgvPurchase.GetRowCellValue(rowindex, "CGST_Per")), 2);
            //    decimal Weight = Math.Round(Val.ToDecimal(dgvPurchase.GetRowCellValue(rowindex, "Weight")), 4);
            //    decimal Amount = Math.Round(Val.ToDecimal(dgvPurchase.GetRowCellValue(rowindex, "NetAmount")), 2);
            //    decimal Rate = 0;
            //    if (GSTPer > 0)
            //    {
            //        Amount = Amount + (Amount / 100 * GSTPer);
            //    }

            //    if (Weight > 0)
            //    {
            //        Rate = Math.Round(Val.ToDecimal(Amount) / Val.ToDecimal(Weight), 2);
            //    }

            //    dgvPurchase.SetRowCellValue(rowindex, "Rate", Math.Round(Rate, 2));
            //    dgvPurchase.SetRowCellValue(rowindex, "NetAmount", Math.Round(Amount, 2));

            //    decimal GrossAmt = Val.ToDecimal(dgvPurchase.Columns["NetAmount"].SummaryText) + Val.ToDecimal(txtBillT.Text);

            //    txtGrossAmtLocal.Text = GrossAmt.ToString();
            //    decimal AddAmt = Val.ToDecimal(txtTotalAddAmount.Text);
            //    decimal LessAmt = Val.ToDecimal(txtTotalLessAmount.Text);
            //    decimal LabourAmt = Val.ToDecimal(txtLabourAmt.Text);
            //    txtNetAmtLocal.Text = Val.ToDecimal((GrossAmt + AddAmt + LabourAmt) - LessAmt).ToString();
            //}
            //catch (Exception)
            //{

            //}
        }

        private void dgvPurchase_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //CalculateGridAmount(dgvPurchase.FocusedRowHandle);
            //GetSummary();
        }

        private void dgvPurchase_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //CalculateGridAmount(e.PrevFocusedRowHandle);
            //GetSummary();
        }

        private void dgvPurchase_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //CalculateGridAmount(dgvPurchase.FocusedRowHandle);
            //GetSummary();
        }

        private void GetSummary()
        {
            //double IGST = Val.ToDouble(dgvPurchase.Columns["IGST_Amt"].SummaryText);
            //double CGST = Val.ToDouble(dgvPurchase.Columns["CGST_Amt"].SummaryText);
            //double SGST = Val.ToDouble(dgvPurchase.Columns["SGST_Amt"].SummaryText);
            //double GrossAmt = Val.ToDouble(dgvPurchase.Columns["NetAmount"].SummaryText) + Val.ToDouble(txtBillT.Text);
            //txtIGST.Text = IGST.ToString();
            //txtCGST.Text = CGST.ToString();
            //txtSGST.Text = SGST.ToString();

            //if (txtPartyState.Text == GlobalDec.gEmployeeProperty.State_Code.ToString())
            //{
            //double GrsAmt = Math.Round(GrossAmt + CGST + SGST, 2);
            //txtGrossAmtLocal.Text = GrossAmt.ToString();
            //}
            //else
            //{
            //    //double GrsAmt = Math.Round(GrossAmt + IGST, 2);
            //    txtGrossAmtLocal.Text = GrossAmt.ToString();               
            //}
        }

        private void txtTotalAddAmount_EditValueChanged(object sender, EventArgs e)
        {
            decimal GrsAmt = Val.ToDecimal(txtGrossAmtLocal.Text);
            decimal AddAmt = Val.ToDecimal(txtTotalAddAmount.Text);
            decimal LessAmt = Val.ToDecimal(txtTotalLessAmount.Text);
            decimal LabourAmt = Val.ToDecimal(txtLabourAmt.Text);
            txtNetAmtLocal.Text = Val.ToDecimal((GrsAmt + AddAmt + LabourAmt) - LessAmt).ToString();
        }

        private void txtTotalLessAmount_EditValueChanged(object sender, EventArgs e)
        {
            decimal GrsAmt = Val.ToDecimal(txtGrossAmtLocal.Text);
            decimal AddAmt = Val.ToDecimal(txtTotalAddAmount.Text);
            decimal LessAmt = Val.ToDecimal(txtTotalLessAmount.Text);
            decimal LabourAmt = Val.ToDecimal(txtLabourAmt.Text);
            txtNetAmtLocal.Text = Val.ToDecimal((GrsAmt + AddAmt + LabourAmt) - LessAmt).ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            strSMSSend = string.Empty;
            Invoice_EntryProperty Invoice_EntryPropertyNew = new Invoice_EntryProperty();
            Invoice_EntryPropertyNew.Invoice_Date = Val.DBDate(DTPInvoiceDate.Text);
            // Invoice_EntryPropertyNew.Invoice_No = Val.ToString(txtInvoiceNo.Text);
            Invoice_EntryPropertyNew.Trn_Id = Val.ToInt64(txtTransactionID.Text);
            // Invoice_EntryPropertyNew.Type = Val.ToString(Form_Type);

            DataTable dtOriginal = ObjInvoiceEntry.GetTransactionPrintData(Invoice_EntryPropertyNew); //ObjInvoice.GetPrintData(Property);

            //DataTable dtDuplicate = dtOriginal.Copy();

            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(dtOriginal);
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;

            //FrmReportViewer.ShowForm("Bill_Detail", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            //FrmReportViewer.ShowForm_SubReport("Bill_Detail_Duplicate", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            //FrmReportViewer.ShowForm("Bill_Detail_New", 120, FrmReportViewer.ReportFolder.ACCOUNT);


            if (Global.gStrStrHostName == "PRAFUL-PC")
            {
                //FrmReportViewer.ShowForm_SubReport("Bill_Detail_New_Duplicate_Surat", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                FrmReportViewer.ShowForm("Bill_Detail_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }
            else
            {
                //FrmReportViewer.ShowForm_SubReport("Bill_Detail_New_Duplicate", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                FrmReportViewer.ShowForm("Bill_Detail_JayMataji", 120, FrmReportViewer.ReportFolder.ACCOUNT);
            }

            Invoice_EntryPropertyNew = null;

            FrmReportViewer.DS.Tables.Clear();
            FrmReportViewer.DS.Clear();
            FrmReportViewer = null;

            //if (Global.Confirm("Are You Sure To Send Party Message ?", "RoadWays", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            //{
            //    return;
            //}
            //else
            //{
            //    strSMSSend += "Dear Customer, \n";
            //    strSMSSend += Val.ToString(dtOriginal.Rows[0]["TO_PARTY"]);
            //    strSMSSend += " Your Invoice no is " + Val.ToString(dtOriginal.Rows[0]["INVOICE_NO"]);
            //    strSMSSend += " and Your bill amount is " + Val.ToString(Val.Val(dtOriginal.Rows[0]["T_AMOUNT"]) + Val.Val(dtOriginal.Compute("SUM(Amount)", string.Empty)));
            //    MessageBox.Show(strSMSSend);
            //}

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
            IntRes = ObjInvoiceEntry.DeleteInvoiceEntryMaster(Invoice_EntryPropertyNew);

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

        private void GrdPurchase_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (Global.Confirm("Are you sure delete selected row?", "ROADWAYS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //dgvPurchase.DeleteRow(dgvPurchase.GetRowHandle(dgvPurchase.FocusedRowHandle));
                    Invoice_EntryProperty Invoice_EntryProperty = new Invoice_EntryProperty();
                    int IntRes = 0;
                    Int64 TransactionMasterID = Val.ToInt64(dgvPurchase.GetFocusedRowCellValue("TransactionMasterID").ToString());
                    Invoice_EntryProperty.TransactionMasterID = Val.ToInt64(TransactionMasterID);
                    Invoice_EntryProperty.TransactionDetailID = Val.ToInt64(dgvPurchase.GetFocusedRowCellValue("TransactionDetailID").ToString());

                    if (TransactionMasterID == 0)
                    {
                        dgvPurchase.DeleteRow(dgvPurchase.GetRowHandle(dgvPurchase.FocusedRowHandle));
                    }
                    else
                    {
                        IntRes = ObjInvoiceEntry.DeletePurchaseDetail(Invoice_EntryProperty);
                        dgvPurchase.DeleteRow(dgvPurchase.GetRowHandle(dgvPurchase.FocusedRowHandle));
                    }

                    if (IntRes == -1)
                    {
                        Global.Confirm("Error in Detail Deleted Data.");
                        Invoice_EntryProperty = null;
                    }
                    else
                    {
                        Global.Confirm("Detail Deleted successfully...");
                        Invoice_EntryProperty = null;
                    }
                }
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

        private void ChkOwnTruck_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkOwnTruck.Checked == true)
            {
                txtMyCommission.Text = "0";
                txtMyCommission.Enabled = false;
            }
            else
            {
                txtMyCommission.Text = "0";
                txtMyCommission.Enabled = true;
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

        private void RepLookUpUnit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmUnitTypeMaster frmCnt = new FrmUnitTypeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPUnitType(RepLookUpUnit);
            }
        }

        private void LookupToParty_EditValueChanged(object sender, EventArgs e)
        {
            //if (LookupToParty.Text.Trim().Length > 0)
            //{
            //    lblTPartyMob.Text = Val.ToString(((DataRowView)LookupToParty.GetSelectedDataRow())["To_Party_Mobile"]);
            //}
            //else
            //{
            //    lblTPartyMob.Text = "";
            //}
        }

        private void txtLabourAmt_EditValueChanged(object sender, EventArgs e)
        {
            decimal GrsAmt = Val.ToDecimal(txtGrossAmtLocal.Text);
            decimal AddAmt = Val.ToDecimal(txtTotalAddAmount.Text);
            decimal LessAmt = Val.ToDecimal(txtTotalLessAmount.Text);
            decimal LabourAmt = Val.ToDecimal(txtLabourAmt.Text);
            txtNetAmtLocal.Text = Val.ToDecimal((GrsAmt + AddAmt + LabourAmt) - LessAmt).ToString();
        }
    }
}