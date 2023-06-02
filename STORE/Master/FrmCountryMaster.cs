using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmCountryMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();

        public FrmCountryMaster()
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
            txtCountryCode.Text = "0";
            txtCountryName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtCountryName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtCountryName.Text.Length == 0)
            {
                Global.Confirm("Country Name Is Required");
                txtCountryName.Focus();
                return false;
            }
            if (!objCountry.ISExists(txtCountryName.Text, Val.ToInt64(txtCountryCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Country Name Already Exist.");
                txtCountryName.Focus();
                txtCountryName.SelectAll();
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

            Country_MasterProperty CountryeMasterProperty = new Country_MasterProperty();
            int Code = Val.ToInt(txtCountryCode.Text);
            CountryeMasterProperty.Country_Code = Val.ToInt64(Code);
            CountryeMasterProperty.Country_Name = txtCountryName.Text;
            CountryeMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            CountryeMasterProperty.Remark = txtRemark.Text;

            int IntRes = objCountry.Save(CountryeMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Country Details");
                txtCountryName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Country Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Country Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            CountryeMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objCountry.GetData_Search();
            grdCountryMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvCountryMaster.GetDataRow(e.RowHandle);
                    txtCountryCode.Text = Convert.ToString(Drow["COUNTRY_CODE"]);
                    txtCountryName.Text = Convert.ToString(Drow["COUNTRY_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                }
            }
        }
    }
}
