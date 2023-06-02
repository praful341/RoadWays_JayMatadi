using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmBranchMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        BranchMaster objBranch = new BranchMaster();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState = new StateMaster();
        CityMaster objCity = new CityMaster();
        CompanyMaster objCompany = new CompanyMaster();
        LocationMaster objLocation = new LocationMaster();

        public FrmBranchMaster()
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
            //objBOFormEvents.ObjToDispose.Add(ObjGroup);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBranchCode.Text = "0";
            txtBranchName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;  
            txtZipCode.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";

            txtSTNo.Text = "";
            txtCSTNo.Text = "";
            txtEPCGNo.Text = "";
            txtWardNo.Text = "";
            txtTINNo.Text = "";
            txtESICNo.Text = "";
            txtPTNo.Text = "";
            txtTDSNo.Text = "";
            txtRegNo.Text = "";
            txtESICLocalOff.Text = "";
            txtCINNo.Text = "";
            txtPANNo.Text = "";
            txtVATNo.Text = "";
            txtPFNo.Text = "";
            txtExciseNo.Text = "";
            txtTANNo.Text = "";
            txtLicenceNo.Text = "";
            txtCPTNo.Text = "";
            txtITPANo.Text = "";
            txtPFGrpCode.Text = "";
            DTESICCovDate.Text = "";
            TabRegisterDetail.SelectedTabPageIndex = 0;
            LookupCity.EditValue = null;
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
            LookupLocation.EditValue = null;
            LookupCompany.EditValue = null;
            txtBranchName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtBranchName.Text.Length == 0)
            {
                Global.Confirm("Branch Name Is Required");
                txtBranchName.Focus();
                return false;
            }
            if (!objBranch.ISExists(txtBranchName.Text, Val.ToInt64(txtBranchCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Branch Name Already Exist.");
                txtBranchName.Focus();
                txtBranchName.SelectAll();
                return false;
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

            Branch_MasterProperty BranchMasterProperty = new Branch_MasterProperty();
            int Code = Val.ToInt(txtBranchCode.Text);
            BranchMasterProperty.Branch_Code = Val.ToInt64(Code);
            BranchMasterProperty.Branch_Name = txtBranchName.Text;
            BranchMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            BranchMasterProperty.Remark = txtRemark.Text;
            BranchMasterProperty.Company_Code = Val.ToInt64(LookupCompany.EditValue);
            BranchMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);
            BranchMasterProperty.Address = Val.ToString(txtAddress.Text);
            BranchMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            BranchMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            BranchMasterProperty.City_Code = Val.ToInt64(LookupCity.EditValue);
            BranchMasterProperty.Zip_Code = Val.ToString(txtZipCode.Text);
            BranchMasterProperty.Phone1 = Val.ToString(txtPhone.Text);
            BranchMasterProperty.STNO = Val.ToString(txtSTNo.Text);
            BranchMasterProperty.CSTNO = Val.ToString(txtCSTNo.Text);
            BranchMasterProperty.EPCGNO = Val.ToString(txtEPCGNo.Text);
            BranchMasterProperty.WARDNO = Val.ToString(txtWardNo.Text);
            BranchMasterProperty.TINNO = Val.ToString(txtTINNo.Text);
            BranchMasterProperty.ESICNO = Val.ToString(txtESICNo.Text);
            BranchMasterProperty.PANNO = Val.ToString(txtPANNo.Text);
            BranchMasterProperty.VATNO = Val.ToString(txtVATNo.Text);
            BranchMasterProperty.PFNO = Val.ToString(txtPFNo.Text);
            BranchMasterProperty.EXCISENO = Val.ToString(txtExciseNo.Text);
            BranchMasterProperty.TANNO = Val.ToString(txtTANNo.Text);
            BranchMasterProperty.Licence_No = Val.ToString(txtLicenceNo.Text);
            BranchMasterProperty.CPT_No = Val.ToString(txtCPTNo.Text);
            BranchMasterProperty.TDS_No = Val.ToString(txtTDSNo.Text);
            BranchMasterProperty.Registration_No = Val.ToString(txtRegNo.Text);
            BranchMasterProperty.IT_PA_No = Val.ToString(txtITPANo.Text);
            BranchMasterProperty.ESIC_Coverage_Date = Val.DBDate(DTESICCovDate.Text);
            BranchMasterProperty.ESIC_Local_Office = Val.ToString(txtESICLocalOff.Text);
            BranchMasterProperty.PF_Group_Code = Val.ToString(txtPFGrpCode.Text);
            BranchMasterProperty.CinNo = Val.ToString(txtCINNo.Text);
            BranchMasterProperty.EPT_No = Val.ToString(txtPTNo.Text);

            int IntRes = objBranch.Save(BranchMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Branch Details");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtBranchName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Branch Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Branch Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            BranchMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objBranch.GetData_Serch();
            grdBranchMaster.DataSource = DTab;
            dgvBranchMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtBranchName.Focus();

            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
            Global.LOOKUPCity(LookupCity);
            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPLocation(LookupLocation);            
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
            }           
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

        private void dgvBranchMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvBranchMaster.GetDataRow(e.RowHandle);
                    txtBranchCode.Text = Convert.ToString(Drow["BRANCH_CODE"]);
                    txtBranchName.Text = Convert.ToString(Drow["BRANCH_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);

                    LookupCompany.EditValue = Convert.ToInt64(Drow["COMPANY_CODE"]);
                    LookupLocation.EditValue = Convert.ToInt64(Drow["LOCATION_CODE"]);
                    txtAddress.Text = Convert.ToString(Drow["Address"]);

                    LookupCountry.EditValue = Convert.ToInt64(Drow["Country_Code"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["State_Code"]);
                    LookupCity.EditValue = Convert.ToInt64(Drow["City_Code"]);

                    txtZipCode.Text = Convert.ToString(Drow["PINCODE"]);
                    txtPhone.Text = Convert.ToString(Drow["PHONENO"]);

                    txtSTNo.Text = Convert.ToString(Drow["STNO"]);
                    txtCSTNo.Text = Convert.ToString(Drow["CSTNO"]);
                    txtEPCGNo.Text = Convert.ToString(Drow["EPCGNO"]);

                    txtWardNo.Text = Convert.ToString(Drow["WARDNO"]);

                    txtTINNo.Text = Convert.ToString(Drow["TINNO"]);

                    txtESICNo.Text = Convert.ToString(Drow["ESICNO"]);
                    txtPANNo.Text = Convert.ToString(Drow["PANNO"]);
                    txtVATNo.Text = Convert.ToString(Drow["VATNO"]);
                    txtPFNo.Text = Convert.ToString(Drow["PFNO"]);
                    txtExciseNo.Text = Convert.ToString(Drow["EXCISENO"]);
                    txtTANNo.Text = Convert.ToString(Drow["TANNO"]);
                    txtLicenceNo.Text = Convert.ToString(Drow["LICENCE_NO"]);
                    txtPTNo.Text = Convert.ToString(Drow["PT_NO"]);
                    txtCPTNo.Text = Convert.ToString(Drow["CPT_NO"]);
                    txtTDSNo.Text = Convert.ToString(Drow["TDS_NO"]);
                    txtRegNo.Text = Convert.ToString(Drow["REG_NO"]);
                    txtITPANo.Text = Convert.ToString(Drow["IT_PA_NO"]);
                    DTESICCovDate.Text = Val.DBDate(Drow["ESIC_COVERAGE_DATE"].ToString());
                    txtESICLocalOff.Text = Convert.ToString(Drow["ESIC_LOCAL_OFFICE"]);
                    txtPFGrpCode.Text = Convert.ToString(Drow["PF_GROUP_CODE"]);
                    txtCINNo.Text = Convert.ToString(Drow["CIN_NO"]);
                }
            }
        }

        private void LookupLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocation(LookupLocation);
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

        private void LookupCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompany(LookupCompany);
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
    }
}
