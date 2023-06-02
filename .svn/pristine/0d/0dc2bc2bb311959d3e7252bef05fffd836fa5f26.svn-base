using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmFromPartyMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        LedgerMaster objLedger = new LedgerMaster();

        public FrmFromPartyMaster()
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLedgerCode.Text = "0";
            txtLedgerName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtEmailID.Text = "";
            txtZipCode.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtMobileNo.Text = "";
            txtPANNo.Text = "";
            CmbPartyType.SelectedIndex = 0;
            txtBankName.Text = "";
            txtBankBranch.Text = "";
            txtBankIFSC.Text = "";
            txtBankAccNo.Text = "";

            LookupCity.EditValue = null;
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
            txtGSTINNo.Text = "";
            DTPGSTINEffDate.EditValue = null;
            dgvOpeningStock.DataSource = null;
            TabRegisterDetail.SelectedTabPageIndex = 0;
            //GetLedgerDetail();
            txtLedgerName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtLedgerName.Text.Length == 0)
            {
                Global.Confirm("Ledger Name Is Required");
                txtLedgerName.Focus();
                return false;
            }
            if (!objLedger.ISExists_From_Party(txtLedgerName.Text, Val.ToInt64(txtLedgerCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Ledger Name Already Exist.");
                txtLedgerName.Focus();
                txtLedgerName.SelectAll();
                return false;
            }
            return true;
        }

        private bool ValDuplicate()
        {
            System.Data.DataTable DTab = (System.Data.DataTable)dgvOpeningStock.DataSource;
            DTab.AcceptChanges();
            int j = 0;
            foreach (DataRow DRowMain in DTab.Rows)
            {
                if (Val.Val(DRowMain["DEBIT_AMT"]) == 0)
                {
                    continue;
                }
                j = j + 1;
                int i = 0;
                foreach (DataRow DRow in DTab.Rows)
                {
                    i = i + 1;
                    if (i != j
                        && Val.ToInt64(DRow["COMPANY_CODE"]) == Val.ToInt64(DRowMain["COMPANY_CODE"])
                        && Val.ToInt64(DRow["BRANCH_CODE"]) == Val.ToInt64(DRowMain["BRANCH_CODE"])
                        && Val.ToInt64(DRow["LOCATION_CODE"]) == Val.ToInt64(DRowMain["LOCATION_CODE"])
                        )
                    {
                        Global.Confirm("Row : " + i.ToString() + " Company-Branch-Location Already Exists In Previous Record");
                        TabRegisterDetail.SelectedTabPageIndex = 1;
                        GrdOpeningStock.FocusedRowHandle = i;
                        GrdOpeningStock.FocusedColumn = GrdOpeningStock.Columns["COMPANY_CODE"];
                        GrdOpeningStock.ShowEditor();
                        GrdOpeningStock.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            //if (ValDuplicate() == false)
            //{
            //    return;
            //}

            //if (txtGSTINNo.Text.Length > 0 && DTPGSTINEffDate.Text == string.Empty)
            //{
            //    Global.Message("GSTIN Effective Date is Required");
            //    DTPGSTINEffDate.Focus();
            //    return;
            //}

            if (txtGSTINNo.Text.Length < 15 && DTPGSTINEffDate.Text != "")
            {
                Global.Message("GSTIN is Required");
                txtGSTINNo.Focus();
                return;
            }

            //ArrayList AL = new ArrayList();
            //DataTable DTab = (System.Data.DataTable)dgvOpeningStock.DataSource;

            //foreach (DataRow DRow in DTab.Rows)
            //{
            //    Ledger_MasterProperty LedgerMasterProperty = new Ledger_MasterProperty();
            //    if (Val.Val(DRow["DEBIT_AMT"]) == 0)
            //    {
            //        continue;
            //    }

            //    LedgerMasterProperty.Ledger_Code = Val.ToInt(txtLedgerCode.Text);
            //    LedgerMasterProperty.LEDGER_OPENING_ID = Val.ToInt64(DRow["LEDGER_OPENING_ID"]);
            //    LedgerMasterProperty.Company_Code = Val.ToInt64(DRow["COMPANY_CODE"]);
            //    LedgerMasterProperty.Branch_Code = Val.ToInt64(DRow["BRANCH_CODE"]);
            //    LedgerMasterProperty.Location_Code = Val.ToInt64(DRow["LOCATION_CODE"]);
            //    LedgerMasterProperty.Debit_Amt = Val.Val(DRow["DEBIT_AMT"]);
            //    LedgerMasterProperty.Credit_Amt = Val.Val(DRow["CREDIT_AMT"]);
            //    LedgerMasterProperty.Opening_Date = Val.DBDate(DRow["OPENING_DATE"].ToString());
            //    AL.Add(LedgerMasterProperty);
            //}

            Ledger_MasterProperty PartyMasterProperty = new Ledger_MasterProperty();
            Int64 Code = Val.ToInt64(txtLedgerCode.Text);
            PartyMasterProperty.Ledger_Code = Val.ToInt64(Code);
            PartyMasterProperty.Ledger_Name = txtLedgerName.Text;
            PartyMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            PartyMasterProperty.Remark = txtRemark.Text;
            PartyMasterProperty.Pan_No = Val.ToString(txtPANNo.Text);
            PartyMasterProperty.Party_Type = Val.ToString(CmbPartyType.EditValue);
            PartyMasterProperty.Mobile_No = Val.ToString(txtMobileNo.Text);
            PartyMasterProperty.EMail = Val.ToString(txtEmailID.Text);
            PartyMasterProperty.Address = Val.ToString(txtAddress.Text);
            PartyMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            PartyMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            PartyMasterProperty.City_Code = Val.ToInt64(LookupCity.EditValue);
            PartyMasterProperty.Zip_Code = Val.ToString(txtZipCode.Text);
            PartyMasterProperty.Phone = Val.ToString(txtPhone.Text);
            PartyMasterProperty.Bank_Name = Val.ToString(txtBankName.Text);
            PartyMasterProperty.Bank_Branch = Val.ToString(txtBankBranch.Text);
            PartyMasterProperty.Bank_IFSC = Val.ToString(txtBankIFSC.Text);
            PartyMasterProperty.Bank_Acc_No = Val.ToString(txtBankAccNo.Text);

            PartyMasterProperty.GSTTIN = Val.ToString(txtGSTINNo.Text);
            PartyMasterProperty.GSTIN_Effective_Date = Val.DBDate(DTPGSTINEffDate.Text);

            int IntRes = objLedger.From_Party_Save(PartyMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save From Party Details");
                txtLedgerName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("From Party Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("From Party Details Data Update Successfully");
                }

                btnClear_Click(sender, e);
                GetData();
            }
            PartyMasterProperty = null;
        }

        private void GetLedgerDetail()
        {
            this.Cursor = Cursors.WaitCursor;
            dgvOpeningStock.DataSource = null;
            DataTable DTab = objLedger.GetLedgerOpeningDetail(Val.ToInt64(txtLedgerCode.Text));

            dgvOpeningStock.DataSource = DTab;
            this.Cursor = Cursors.Default;
        }

        public void GetData()
        {
            DataTable DTab = objLedger.From_Party_GetData_Search();
            grdLedgerMaster.DataSource = DTab;
            dgvLedgerMaster.BestFitColumns();
            //GetLedgerDetail();
        }

        private void LookupCountry_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCountryMaster frmCnt = new FrmCountryMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCountry(LookupCountry);
            }
        }

        private void LookupState_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmStateMaster frmCnt = new FrmStateMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPState(LookupState);
            }
        }

        private void LookupCity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCityMaster frmCnt = new FrmCityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCity(LookupCity);
            }
        }

        private void LookupCity_EditValueChanged(object sender, EventArgs e)
        {
            LookupState.EditValue = LookupCity.GetColumnValue("STATE_CODE");
            LookupCountry.EditValue = LookupCity.GetColumnValue("COUNTRY_CODE");
        }

        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            LookupCountry.EditValue = LookupState.GetColumnValue("COUNTRY_CODE");
        }

        private void txtGSTINNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtGSTINNo.Text.Length < 15)
                {
                    Global.Message("GSTIN No 15 Digit are Required");
                    txtGSTINNo.Focus();
                    return;
                }
            }
        }

        private void FrmLedgerMaster_Shown(object sender, EventArgs e)
        {
            GetData();
            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
            Global.LOOKUPCity(LookupCity);
            Global.LOOKUPCompanyRep(LookUpRepCompany);
            Global.LOOKUPBranchRep(LookUpRepBranch);
            Global.LOOKUPLocationRep(LookUpRepLocation);
            txtLedgerName.Focus();
        }

        private void dgvLedgerMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvLedgerMaster.GetDataRow(e.RowHandle);
                    txtLedgerCode.Text = Convert.ToString(Drow["From_Party_CODE"]);
                    txtLedgerName.Text = Convert.ToString(Drow["From_Party_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["Active"]);
                    txtRemark.Text = Convert.ToString(Drow["Remarks"]);
                    txtMobileNo.Text = Convert.ToString(Drow["From_Party_Mobile"]);
                    txtPANNo.Text = Convert.ToString(Drow["From_Party_PanNo"]);
                    CmbPartyType.EditValue = Convert.ToString(Drow["From_Party_Type"]);
                    txtEmailID.Text = Convert.ToString(Drow["From_Party_Email"]);
                    txtAddress.Text = Convert.ToString(Drow["From_Party_Address"]);
                    LookupCountry.EditValue = Convert.ToInt64(Drow["From_Party_Country_Code"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["From_Party_State_Code"]);
                    LookupCity.EditValue = Convert.ToInt64(Drow["From_Party_City_Code"]);
                    txtZipCode.Text = Convert.ToString(Drow["From_Party_Pincode"]);
                    txtPhone.Text = Convert.ToString(Drow["From_Party_Phone"]);
                    txtBankName.Text = Convert.ToString(Drow["Bank_Name"]);
                    txtBankBranch.Text = Convert.ToString(Drow["Bank_Branch"]);
                    txtBankIFSC.Text = Convert.ToString(Drow["Bank_IFSC"]);
                    txtBankAccNo.Text = Convert.ToString(Drow["Bank_AccountNo"]);
                    txtGSTINNo.Text = Convert.ToString(Drow["GSTIN"]);
                    DTPGSTINEffDate.EditValue = Val.DBDate(Drow["GSTIN_EFFECTIVE_DATE"].ToString());

                    //GetLedgerDetail();
                    txtLedgerName.Focus();
                }
            }
        }

        private void LookUpRepCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompanyRep(LookUpRepCompany);
            }
        }

        private void LookUpRepBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranchRep(LookUpRepBranch);
            }
        }

        private void LookUpRepLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocationRep(LookUpRepLocation);
            }
        }
    }
}
