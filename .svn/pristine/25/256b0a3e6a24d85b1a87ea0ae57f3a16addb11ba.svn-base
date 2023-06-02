using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;

namespace RoadWays
{
    public partial class FrmStateMaster : DevExpress.XtraEditors.XtraForm
    {
        //FrmSearch FrmSearch;

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        StateMaster objState = new StateMaster();
        CountryMaster objCountry = new CountryMaster();

        public FrmStateMaster()
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
            txtStateCode.Text = "0";
            txtStateName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtStateName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtStateName.Text.Length == 0)
            {
                Global.Confirm("State Name Is Required");
                txtStateName.Focus();
                return false;
            }
            if (LookupCountry.Text == "")
            {
                Global.Confirm("Country Name Is Required");
                LookupCountry.Focus();
                return false;
            }

            if (!objState.ISExists(txtStateName.Text, Val.ToInt64(txtStateCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("State Name Already Exist.");
                txtStateName.Focus();
                txtStateName.SelectAll();
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

            State_MasterProperty StateMasterProperty = new State_MasterProperty();
            int Code = Val.ToInt(txtStateCode.Text);
            StateMasterProperty.State_Code = Val.ToInt64(Code);
            StateMasterProperty.State_Name = txtStateName.Text;
            StateMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            StateMasterProperty.Remark = txtRemark.Text;
            StateMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);

            int IntRes = objState.Save(StateMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save State Details");
                txtStateName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("State Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("State Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            StateMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objState.GetData_Search();
            grdStateMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            Global.LOOKUPCountry(LookupCountry);
            btnClear_Click(btnClear, null);
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvStateMaster.GetDataRow(e.RowHandle);
                    txtStateCode.Text = Convert.ToString(Drow["STATE_CODE"]);
                    txtStateName.Text = Convert.ToString(Drow["STATE_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    LookupCountry.EditValue = Convert.ToInt64(Drow["COUNTRY_CODE"]);
                }
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
    }
}
