﻿using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmItemHSNMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        
        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState= new StateMaster();
        CityMaster objCity = new CityMaster();
        ItemHSNMaster objItemHSN = new ItemHSNMaster();

        public FrmItemHSNMaster()
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
            txtHSNID.Text = "0";
            txtHSNName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;           
            txtHSNCode.Text = "";           
            DTCGSTDate.EditValue = null;
            DTIGSTDate.EditValue = null;
            DTSGSTDate.EditValue = null;
            txtCGSTRate.Text = "";
            txtIGSTRate.Text = "";
            txtSGSTRate.Text = "";
            txtHSNCode.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtHSNName.Text.Length == 0)
            {
                Global.Confirm("HSN Name Is Required");
                txtHSNName.Focus();
                return false;
            }

            if (txtHSNCode.Text.Length == 0)
            {
                Global.Confirm("HSN Code Is Required");
                txtHSNCode.Focus();
                return false;
            }

            if (DTCGSTDate.Text.ToString() == "")
            {
                Global.Message("IGST Date Is Required");
                DTCGSTDate.Focus();
                return false;
            }
            if (DTCGSTDate.Text.ToString() == "")
            {
                Global.Message("CGST Date Is Required");
                DTCGSTDate.Focus();
                return false;
            }
            if (DTSGSTDate.Text.ToString() == "")
            {
                Global.Message("SGST Date Is Required");
                txtSGSTRate.Focus();
                return false;
            }
            if (txtIGSTRate.Text.Length == 0)
            {
                Global.Message("IGST Rate Is Required");
                txtIGSTRate.Focus();
                return false;
            }
            if (txtCGSTRate.Text.Length == 0)
            {
                Global.Message("CGST Rate Is Required");
                txtCGSTRate.Focus();
                return false;
            }
            if (txtSGSTRate.Text.Length == 0)
            {
                Global.Message("SGST Rate Is Required");
                txtSGSTRate.Focus();
                return false;
            }

            if (!objItemHSN.ISExists(txtHSNCode.Text, Val.ToInt64(txtHSNID.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("HSN Name Already Exist.");
                txtHSNName.Focus();
                txtHSNName.SelectAll();
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

            ItemHSN_MasterProperty ItemHSNMasterProperty = new ItemHSN_MasterProperty();
            int Code = Val.ToInt(txtHSNID.Text);
            ItemHSNMasterProperty.HSN_ID = Val.ToInt64(Code);
            ItemHSNMasterProperty.HSN_Name = txtHSNName.Text;
            ItemHSNMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            ItemHSNMasterProperty.Remark = txtRemark.Text;
            ItemHSNMasterProperty.HSN_Code = Val.ToString(txtHSNCode.Text);
            ItemHSNMasterProperty.IGST_DATE = Val.DBDate(DTIGSTDate.Text);
            ItemHSNMasterProperty.IGST_RATE = Val.Val(txtIGSTRate.Text);
            ItemHSNMasterProperty.CGST_DATE = Val.DBDate(DTCGSTDate.Text);
            ItemHSNMasterProperty.CGST_RATE = Val.Val(txtCGSTRate.Text);
            ItemHSNMasterProperty.SGST_DATE = Val.DBDate(DTSGSTDate.Text);
            ItemHSNMasterProperty.SGST_RATE = Val.Val(txtSGSTRate.Text);

            ItemHSNMasterProperty.Active = Val.ToInt(RBtnStatus.EditValue);
            ItemHSNMasterProperty.Remark = Val.ToString(txtRemark.Text);

            int IntRes = objItemHSN.Save(ItemHSNMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save HSN Details");
                txtHSNName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Item HSN Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Item HSN Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            ItemHSNMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objItemHSN.GetData_Search();
            grdCompanyMaster.DataSource = DTab;
            dgvCompanyMaster.BestFitColumns();
        }

        private void dgvCompanyMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvCompanyMaster.GetDataRow(e.RowHandle);
                    txtHSNID.Text = Convert.ToString(Drow["HSN_ID"]);
                    txtHSNName.Text = Convert.ToString(Drow["HSN_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    txtHSNCode.Text = Convert.ToString(Drow["HSN_CODE"]);
                    txtIGSTRate.Text = Val.ToString(Drow["IGST_RATE"].ToString());
                    DTIGSTDate.Text = Val.ToString(Drow["IGST_DATE"].ToString());
                    txtSGSTRate.Text = Val.ToString(Drow["SGST_RATE"].ToString());
                    DTSGSTDate.Text = Val.ToString(Drow["SGST_DATE"].ToString());
                    txtCGSTRate.Text = Val.ToString(Drow["CGST_RATE"].ToString());
                    DTCGSTDate.Text = Val.ToString(Drow["CGST_DATE"].ToString());
                }
            }
        }

        private void FrmItemHSNMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtHSNName.Focus();  
        }   
    }
}