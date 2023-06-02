using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmCityMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        CityMaster objCity = new CityMaster();
        StateMaster objState = new StateMaster();
        CountryMaster objCountry = new CountryMaster();

        public FrmCityMaster()
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
            txtCityCode.Text = "0";
            txtCityName.Text = "";
            txtRemark.Text = "";
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
            RBtnStatus.SelectedIndex = 0;
            txtCityName.Focus();
        }

        #region Validation
 
        private bool ValSave()
        {
            if (txtCityName.Text.Length == 0)
            {
                Global.Confirm("City Name is Required");
                txtCityName.Focus();
                return false;
            }

            if (!objCity.ISExists(txtCityName.Text, Val.ToInt64(txtCityCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("City Name Already Exist.");
                txtCityName.Focus();
                txtCityName.SelectAll();
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

            City_MasterProperty CityMasterProperty = new City_MasterProperty();
            int Code = Val.ToInt(txtCityCode.Text);
            CityMasterProperty.City_Code = Val.ToInt64(Code);
            CityMasterProperty.City_Name = txtCityName.Text;
            CityMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            CityMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            CityMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            CityMasterProperty.Remark = txtRemark.Text;

            int IntRes = objCity.Save(CityMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save City Details");
                txtCityName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("City Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("City Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            CityMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objCity.GetData_Search();
            grdCityMaster.DataSource = DTab;
        }
                
        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {           
            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
          
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvCityMaster.GetDataRow(e.RowHandle);
                    txtCityCode.Text = Convert.ToString(Drow["CITY_CODE"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["STATE_CODE"]);
                    LookupCountry.EditValue = Convert.ToInt64(Drow["COUNTRY_CODE"]);
                    txtCityName.Text = Convert.ToString(Drow["CITY_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                }
            }
        }

        private void LookupState_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmStateMaster frmCnt = new FrmStateMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPState(LookupCountry);
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

        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            LookupCountry.EditValue = LookupState.GetColumnValue("COUNTRY_CODE");
        }
    }
}
