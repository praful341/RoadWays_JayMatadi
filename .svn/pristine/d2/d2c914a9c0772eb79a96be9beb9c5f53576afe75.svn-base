using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmLocationMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        LocationMaster objLocation = new LocationMaster();

        public FrmLocationMaster()
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
            txtLocationCode.Text = "0";
            txtLocationName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtLocationName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtLocationName.Text.Length == 0)
            {
                Global.Confirm("Location Name Is Required");
                txtLocationName.Focus();
                return false;
            }
            if (!objLocation.ISExists(txtLocationName.Text, Val.ToInt64(txtLocationCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Location Name Already Exist.");
                txtLocationName.Focus();
                txtLocationName.SelectAll();
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

            Location_MasterProperty LocationMasterProperty = new Location_MasterProperty();
            int Code = Val.ToInt(txtLocationCode.Text);
            LocationMasterProperty.Location_Code = Val.ToInt64(Code);
            LocationMasterProperty.Location_Name = txtLocationName.Text;
            LocationMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            LocationMasterProperty.Remark = txtRemark.Text;

            int IntRes = objLocation.Save(LocationMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Location Details");
                txtLocationName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Location Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Location Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            LocationMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objLocation.GetData_Search();
           grdLocationMaster.DataSource = DTab;
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
                    DataRow Drow = dgvLocationMaster.GetDataRow(e.RowHandle);
                    txtLocationCode.Text = Convert.ToString(Drow["LOCATION_CODE"]);
                    txtLocationName.Text = Convert.ToString(Drow["LOCATION_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                }
            }
        }
    }
}
