using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmEmployeeMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState = new StateMaster();
        CityMaster objCity = new CityMaster();
        CompanyMaster objCompany = new CompanyMaster();
        LocationMaster objLocation = new LocationMaster();
        BranchMaster objBranch = new BranchMaster();
        EmployeeMaster objEmployee = new EmployeeMaster();

        public FrmEmployeeMaster()
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
            txtEmployeeCode.Text = "0";
            txtEmployeeName.Text = "";
            txtIDCardNo.Text = "";
            DTDOJ.Text = "";
            DTDOB.Text = "";
            txtEmailID.Text = "";
            RBtnGender.SelectedIndex = 0;
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtPinCode.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtOfficeExtNo.Text = "";
            txtPANNo.Text = "";
            CmbMaritalStatus.SelectedIndex = 0;
            txtBloodGroup.Text = "";
            DTAnniversaryDate.Text = "";
            txtOccupation.Text = "";
            txtOccupation.Text = "";
            txtVehicalNo.Text = "";
            txtIdentityMark.Text = "";
            txtNationality.Text = "";
            txtReligion.Text = "";
            txtCastSubCast.Text = "";
            txtHobbies.Text = "";
            txtPassportNo.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtSkypeID.Text = "";
            txtDrivLicNo.Text = "";
            txtAdharCardNo.Text = "";
            txtElecCardNo.Text = "";
            txtLanguageKnown.Text = "";
            TabRegisterDetail.SelectedTabPageIndex = 0;
            LookupCity.EditValue = null;
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
            LookupCompany.EditValue = null;
            LookupBranch.EditValue = null;
            LookupLocation.EditValue = null;
            txtEmployeeName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtEmployeeName.Text.Length == 0)
            {
                Global.Confirm("Employee Name Is Required");
                txtEmployeeName.Focus();
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

            User_MasterProperty EmployeeMasterProperty = new User_MasterProperty();
            int Code = Val.ToInt(txtEmployeeCode.Text);
            EmployeeMasterProperty.User_Code = Val.ToInt64(Code);
            EmployeeMasterProperty.User_Name = txtEmployeeName.Text;
            EmployeeMasterProperty.Company_Code = Val.ToInt64(LookupCompany.EditValue);
            EmployeeMasterProperty.Branch_Code = Val.ToInt64(LookupBranch.EditValue);
            EmployeeMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);
            EmployeeMasterProperty.ID_Card_No = Val.ToString(txtIDCardNo.Text);
            EmployeeMasterProperty.DOJ = Val.DBDate(DTDOJ.Text);
            EmployeeMasterProperty.Address = Val.ToString(txtAddress.Text);
            EmployeeMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            EmployeeMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            EmployeeMasterProperty.City_Code = Val.ToInt64(LookupCity.EditValue);
            EmployeeMasterProperty.Pincode = Val.ToString(txtPinCode.Text);
            EmployeeMasterProperty.DOB = Val.DBDate(DTDOB.Text);
            EmployeeMasterProperty.Gender = Val.ToString(RBtnGender.Text);
            EmployeeMasterProperty.Blood_Group = Val.ToString(txtBloodGroup.Text);
            EmployeeMasterProperty.Maritile_Status = Val.ToString(CmbMaritalStatus.Text);
            EmployeeMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            EmployeeMasterProperty.Remark = txtRemark.Text;
            EmployeeMasterProperty.EMail = Val.ToString(txtEmailID.Text);
            EmployeeMasterProperty.Anniversary = Val.DBDate(DTAnniversaryDate.Text);
            EmployeeMasterProperty.Occupation = Val.ToString(txtOccupation.Text);
            EmployeeMasterProperty.Vehicle_No = Val.ToString(txtVehicalNo.Text);
            EmployeeMasterProperty.Identity_Mark = Val.ToString(txtIdentityMark.Text);
            EmployeeMasterProperty.Nationality = Val.ToString(txtNationality.Text);
            EmployeeMasterProperty.Religion = Val.ToString(txtReligion.Text);
            EmployeeMasterProperty.Cast_SubCast = Val.ToString(txtCastSubCast.Text);

            EmployeeMasterProperty.Hobbies = Val.ToString(txtHobbies.Text);
            EmployeeMasterProperty.Language_Known = Val.ToString(txtLanguageKnown.Text);
            EmployeeMasterProperty.Passport_No = Val.ToString(txtPassportNo.Text);
            EmployeeMasterProperty.Phone_No = Val.ToString(txtPhone.Text);
            EmployeeMasterProperty.PAN_NO = Val.ToString(txtPANNo.Text);
            EmployeeMasterProperty.UserName = Val.ToString(txtUserName.Text);
            EmployeeMasterProperty.PassWord = BLL.GlobalDec.Encrypt(txtPassword.Text, true);
            EmployeeMasterProperty.OfficeExtNo = Val.ToString(txtOfficeExtNo.Text);
            EmployeeMasterProperty.SkypeId = Val.ToString(txtSkypeID.Text);
            EmployeeMasterProperty.Driving_Lic_No = Val.ToString(txtDrivLicNo.Text);
            EmployeeMasterProperty.Adhar_Card_No = Val.ToString(txtAdharCardNo.Text);
            EmployeeMasterProperty.Election_Card_No = Val.ToString(txtElecCardNo.Text);

            int IntRes = objEmployee.Save(EmployeeMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Employee Master Details");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtEmployeeName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Employee Master Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Employee Master Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            EmployeeMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objEmployee.GetData();
            grdEmployeeMaster.DataSource = DTab;
            dgvEmployeeMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtEmployeeName.Focus();

            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
            Global.LOOKUPCity(LookupCity);
            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPBranch(LookupBranch);             
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

        private void LookupCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompany(LookupCompany);
            }
        }

        private void LookupBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranch(LookupBranch);
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

        private void txtPANNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
                //CmbMaritalStatus.Focus();
            }
        }

        private void dgvEmployeeMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvEmployeeMaster.GetDataRow(e.RowHandle);
                    txtEmployeeCode.Text = Convert.ToString(Drow["USER_CODE"]);
                    txtEmployeeName.Text = Convert.ToString(Drow["USER_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    LookupCompany.EditValue = Convert.ToInt64(Drow["COMPANY_CODE"]);
                    LookupLocation.EditValue = Convert.ToInt64(Drow["LOCATION_CODE"]);
                    LookupBranch.EditValue = Convert.ToInt64(Drow["BRANCH_CODE"]);
                    txtAddress.Text = Convert.ToString(Drow["ADDRESS"]);
                    LookupCountry.EditValue = Convert.ToInt64(Drow["COUNTRY_CODE"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["STATE_CODE"]);
                    LookupCity.EditValue = Convert.ToInt64(Drow["CITY_CODE"]);
                    txtPinCode.Text = Convert.ToString(Drow["PINCODE"]);
                    txtPhone.Text = Convert.ToString(Drow["PHONE_NO"]);
                    txtIDCardNo.Text = Convert.ToString(Drow["ID_CARD_NO"]);
                    DTDOJ.Text = Val.DBDate(Drow["DOJ"].ToString()); //Convert.ToString(Drow["DOJ"]);
                    DTDOB.Text = Val.DBDate(Drow["DOB"].ToString()); //Convert.ToString(Drow["DOB"]);
                    DTAnniversaryDate.Text = Val.DBDate(Drow["ANNIVERSARTY"].ToString()); //Convert.ToString(Drow["ANNIVERSARTY"]);
                    RBtnGender.EditValue = Convert.ToString(Drow["GENDER"]);
                    txtBloodGroup.Text = Convert.ToString(Drow["BLOOD_GROUP"]);
                    CmbMaritalStatus.Text = Convert.ToString(Drow["MARITILE_STATUS"]);
                    txtOccupation.Text = Convert.ToString(Drow["OCCUPATION"]);
                    txtEmailID.Text = Convert.ToString(Drow["EMAIL"]);
                    txtVehicalNo.Text = Convert.ToString(Drow["VEHICLE_NO"]);
                    txtIdentityMark.Text = Convert.ToString(Drow["IDENTITY_MARK"]);
                    txtNationality.Text = Convert.ToString(Drow["NATIONALITY"]);
                    txtReligion.Text = Convert.ToString(Drow["RELIGION"]);
                    txtCastSubCast.Text = Convert.ToString(Drow["CAST_SUBCAST"]);
                    txtHobbies.Text = Convert.ToString(Drow["HOBBIES"]);
                    txtLanguageKnown.Text = Convert.ToString(Drow["LANGUAGE_KNOWN"]);
                    txtPassportNo.Text = Convert.ToString(Drow["PASSPORT_NO"]);
                    txtPANNo.Text = Convert.ToString(Drow["PAN_NO"]);
                    txtUserName.Text = Convert.ToString(Drow["USERNAME"]);
                    txtPassword.Text = GlobalDec.Decrypt(Convert.ToString(Drow["PASSWORD"]),true);
                    txtOfficeExtNo.Text = Convert.ToString(Drow["OFF_EXT_NO"]);
                    txtSkypeID.Text = Convert.ToString(Drow["SKYPE_ID"]);
                    txtDrivLicNo.Text = Convert.ToString(Drow["DRIVING_LICENCE_NO"]);
                    txtAdharCardNo.Text = Convert.ToString(Drow["AADHAR_CARD_NO"]);
                    txtElecCardNo.Text = Convert.ToString(Drow["ELECTION_CARD_NO"]);
                }
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
