using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmTruckMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        TruckMaster objTruck = new TruckMaster();

        public FrmTruckMaster()
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
            txtTruckCode.Text = "0";
            txtTruckNo.Text = "";
            txtTruckNo.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtTruckNo.Text.Length == 0)
            {
                Global.Confirm("Truck No Is Required");
                txtTruckNo.Focus();
                return false;
            }
            if (!objTruck.ISExists(txtTruckNo.Text, Val.ToInt64(txtTruckCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Truck No Already Exist.");
                txtTruckNo.Focus();
                txtTruckNo.SelectAll();
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

            Truck_MasterProperty TruckMasterProperty = new Truck_MasterProperty();
            int Code = Val.ToInt(txtTruckCode.Text);
            TruckMasterProperty.Truck_Code = Val.ToInt64(Code);
            TruckMasterProperty.Truck_No = txtTruckNo.Text;

            int IntRes = objTruck.Save(TruckMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Truck Details");
                txtTruckNo.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Truck No Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Truck No Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            TruckMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objTruck.GetData_Search();
           grdUnitTypeMaster.DataSource = DTab;
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
                    DataRow Drow = dgvUnitTypeMaster.GetDataRow(e.RowHandle);
                    txtTruckCode.Text = Convert.ToString(Drow["Truck_ID"]);
                    txtTruckNo.Text = Convert.ToString(Drow["Truck_No"]);
                }
            }
        }
    }
}
