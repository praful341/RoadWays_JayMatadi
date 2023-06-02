using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmCompanyMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        
        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState= new StateMaster();
        CityMaster objCity = new CityMaster();
        CompanyMaster objCompany = new CompanyMaster();
            
        public FrmCompanyMaster()
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
            txtCompanyCode.Text = "0";
            txtCompanyName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;           
            txtContactPerson.Text = "";
            txtWebsite.Text = "";
            txtEmailID.Text = "";
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
            txtBankName.Text = "";
            txtBankBranch.Text = "";
            txtBankIFSC.Text = "";
            txtBankAccNo.Text = "";
            txtAccName.Text = "";

            TabRegisterDetail.SelectedTabPageIndex = 0;
            LookupCity.EditValue = null;
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
            txtCompanyName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtCompanyName.Text.Length == 0)
            {
                Global.Confirm("Company Name Is Required");
                txtCompanyName.Focus();
                return false;
            }
            if (!objCompany.ISExists(txtCompanyName.Text, Val.ToInt64(txtCompanyCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Company Name Already Exist.");
                txtCompanyName.Focus();
                txtCompanyName.SelectAll();
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

            Company_MasterProperty CompanyMasterProperty = new Company_MasterProperty();
            int Code = Val.ToInt(txtCompanyCode.Text);
            CompanyMasterProperty.Company_Code = Val.ToInt64(Code);
            CompanyMasterProperty.Company_Name = txtCompanyName.Text;
            CompanyMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            CompanyMasterProperty.Remark = txtRemark.Text;
            CompanyMasterProperty.Contact_Person_Name = Val.ToString(txtContactPerson.Text);
            CompanyMasterProperty.WebSite = Val.ToString(txtWebsite.Text);
            CompanyMasterProperty.EMail = Val.ToString(txtEmailID.Text);
            CompanyMasterProperty.Address = Val.ToString(txtAddress.Text);
            CompanyMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            CompanyMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            CompanyMasterProperty.City_Code = Val.ToInt64(LookupCity.EditValue);
            CompanyMasterProperty.Zip_Code = Val.ToString(txtZipCode.Text);
            CompanyMasterProperty.Phone1 = Val.ToString(txtPhone.Text);
            CompanyMasterProperty.STNO = Val.ToString(txtSTNo.Text);
            CompanyMasterProperty.CSTNO = Val.ToString(txtCSTNo.Text);
            CompanyMasterProperty.EPCGNO = Val.ToString(txtEPCGNo.Text);
            CompanyMasterProperty.WARDNO = Val.ToString(txtWardNo.Text);
            CompanyMasterProperty.TINNO = Val.ToString(txtTINNo.Text);
            CompanyMasterProperty.ESICNO = Val.ToString(txtESICNo.Text);
            CompanyMasterProperty.PANNO = Val.ToString(txtPANNo.Text);
            CompanyMasterProperty.VATNO = Val.ToString(txtVATNo.Text);
            CompanyMasterProperty.PFNO = Val.ToString(txtPFNo.Text);
            CompanyMasterProperty.EXCISENO = Val.ToString(txtExciseNo.Text);
            CompanyMasterProperty.TANNO = Val.ToString(txtTANNo.Text);
            CompanyMasterProperty.Licence_No = Val.ToString(txtLicenceNo.Text);
            CompanyMasterProperty.CPT_No = Val.ToString(txtCPTNo.Text);
            CompanyMasterProperty.TDS_No = Val.ToString(txtTDSNo.Text);
            CompanyMasterProperty.Registration_No = Val.ToString(txtRegNo.Text);
            CompanyMasterProperty.IT_PA_No = Val.ToString(txtITPANo.Text);
            CompanyMasterProperty.ESIC_Coverage_Date = Val.DBDate(DTESICCovDate.Text);
            CompanyMasterProperty.ESIC_Local_Office = Val.ToString(txtESICLocalOff.Text);
            CompanyMasterProperty.PF_Group_Code = Val.ToString(txtPFGrpCode.Text);
            CompanyMasterProperty.CinNo = Val.ToString(txtCINNo.Text);
            CompanyMasterProperty.EPT_No = Val.ToString(txtPTNo.Text);
            CompanyMasterProperty.Bank_Name = Val.ToString(txtBankName.Text);
            CompanyMasterProperty.Bank_Branch = Val.ToString(txtBankBranch.Text);
            CompanyMasterProperty.Bank_IFSC = Val.ToString(txtBankIFSC.Text);
            CompanyMasterProperty.Bank_Acc_No = Val.ToString(txtBankAccNo.Text);
            CompanyMasterProperty.Acc_Name = Val.ToString(txtAccName.Text);

            int IntRes = objCompany.Save(CompanyMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Company Details");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtCompanyName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Company Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Company Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            CompanyMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objCompany.GetData_Search();
            grdCompanyMaster.DataSource = DTab;
            dgvCompanyMaster.BestFitColumns();
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

        private void dgvCompanyMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvCompanyMaster.GetDataRow(e.RowHandle);
                    txtCompanyCode.Text = Convert.ToString(Drow["COMPANY_CODE"]);
                    txtCompanyName.Text = Convert.ToString(Drow["COMPANY_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);

                    txtContactPerson.Text = Convert.ToString(Drow["Contact_Person"]);
                    txtWebsite.Text = Convert.ToString(Drow["Website"]);
                    txtEmailID.Text = Convert.ToString(Drow["EmailID"]);
                    txtAddress.Text = Convert.ToString(Drow["Address"]);

                    LookupCountry.EditValue = Convert.ToInt64(Drow["Country_Code"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["State_Code"]);
                    LookupCity.EditValue = Convert.ToInt64(Drow["City_Code"]);

                    txtZipCode.Text = Convert.ToString(Drow["ZIPCode"]);
                    txtPhone.Text = Convert.ToString(Drow["PHONE"]);

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

                    txtBankName.Text = Convert.ToString(Drow["Bank_Name"]);
                    txtBankBranch.Text = Convert.ToString(Drow["Bank_Branch"]);
                    txtBankIFSC.Text = Convert.ToString(Drow["Bank_IFSC"]);
                    txtBankAccNo.Text = Convert.ToString(Drow["Bank_AccountNo"]);
                    txtAccName.Text = Convert.ToString(Drow["Account_Name"]);
                }
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

        private void FrmCompanyMaster_Shown(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtCompanyName.Focus();

            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
            Global.LOOKUPCity(LookupCity);         
        }
    }
}
