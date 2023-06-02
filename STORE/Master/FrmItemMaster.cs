using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmItemMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();

        BLL.Validation Val = new BLL.Validation();
        CountryMaster objCountry = new CountryMaster();
        StateMaster objState = new StateMaster();
        CityMaster objCity = new CityMaster();
        CompanyMaster objCompany = new CompanyMaster();
        ItemMaster ObjItem = new ItemMaster();

        public FrmItemMaster()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void GetData()
        {
            ObjItem.GetData();
            MainGrdItemMaster.DataSource = ObjItem.DTab;
            MainGrdItemMaster.RefreshDataSource();
            GrdDetItemMaster.BestFitColumns();
            GetItemDetail();
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
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtRemark.Text = "";
            lookUpCategoryName.EditValue = null;
            LookupItemGroup.EditValue = null;
            txtLastPurchase.Text = "";
            txtItemCodification.Text = "";
            txtShortName.Text = "";
            CmbUnitType.EditValue = null;
            RbtStatus.SelectedIndex = 0;
            txtDiscPer.Text = "";

            LookupCompany.EditValue = null;
            LookupBranch.EditValue = null;
            LookupLocation.EditValue = null;
            LookupHSNCode.EditValue = null;

            dgvItemGrid.DataSource = null;
            dgvOpeningStock.DataSource = null;
            GetItemDetail();
            TabRegisterDetail.SelectedTabPageIndex = 0;
            txtItemName.Focus();
            txtItemCode.Text = ObjItem.FindNewID().ToString();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtItemName.Text.Length == 0)
            {
                Global.Confirm("Item Name Is Required");
                txtItemName.Focus();
                return false;
            }
            if (!ObjItem.ISExists(txtItemName.Text, Val.ToInt(txtItemCode.Text)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Item Name Already Exist.");
                txtItemName.Focus();
                txtItemName.SelectAll();
                return false;
            }

            //if (txtShortName.Text.Length == 0)
            //{
            //    Global.Confirm("Item Short Name Is Required");
            //    txtShortName.Focus();
            //    return false;
            //}

            if (LookupItemGroup.EditValue == null)
            {
                Global.Confirm("Item Group Name Is Required");
                LookupItemGroup.Focus();
                return false;
            }

            if (lookUpCategoryName.EditValue == null)
            {
                Global.Confirm("Item Category Name Is Required");
                lookUpCategoryName.Focus();
                return false;
            }

            if (txtItemCodification.Text.Length == 0)
            {
                Global.Confirm("Item Codification Is Required");
                txtItemCodification.Focus();
                return false;
            }

            if (CmbUnitType.Text.Length == 0 || CmbUnitType.Text.ToString() == "SELECT")
            {
                Global.Confirm("Unit Type Is Required");
                CmbUnitType.Focus();
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
                if (Val.Val(DRowMain["QUANTITY"]) == 0)
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

            if (ValDuplicate() == false)
            {
                return;
            }

            Item_MasterProperty ItemMasterProperty = new Item_MasterProperty();

            ItemMasterProperty.Item_Code = Val.ToInt(txtItemCode.Text);
            ObjItem.Delete(ItemMasterProperty);

            ItemMasterProperty = SaveItemMaster();

            ArrayList AL = new ArrayList();
            ArrayList ALItem = new ArrayList();

            DataTable DTab = (System.Data.DataTable)dgvOpeningStock.DataSource;

            foreach (DataRow DRow in DTab.Rows)
            {
                Item_DetailProperty ItemDetailProperty = new Item_DetailProperty();
                if (Val.Val(DRow["QUANTITY"]) == 0)
                {
                    continue;
                }

                ItemDetailProperty.Item_Code = Val.ToInt(txtItemCode.Text);
                ItemDetailProperty.ITEM_OPENING_ID = Val.ToInt64(DRow["ITEM_OPENING_ID"]); ;
                ItemDetailProperty.Company_Code = Val.ToInt64(DRow["COMPANY_CODE"]);
                ItemDetailProperty.Branch_Code = Val.ToInt64(DRow["BRANCH_CODE"]);
                ItemDetailProperty.Location_Code = Val.ToInt64(DRow["LOCATION_CODE"]);
                ItemDetailProperty.Quantity = Val.Val(DRow["QUANTITY"]);
                ItemDetailProperty.Rate_Local = Val.Val(DRow["RATE"]);
                ItemDetailProperty.Amount_Local = Val.Val(DRow["AMOUNT"]);
                ItemDetailProperty.Opening_date = Val.DBDate(DRow["OPENING_DATE"].ToString());
                AL.Add(ItemDetailProperty);
            }

            DataTable DTab_Item = (System.Data.DataTable)dgvItemGrid.DataSource;

            foreach (DataRow DRow in DTab_Item.Rows)
            {
                Item_MasterProperty ItemProperty = new Item_MasterProperty();
                if (Val.ToString(DRow["ITEM_NAME"]) == "")
                {
                    continue;
                }
                ItemProperty.ITEM_DETAIL_ID = Val.ToInt64(DRow["ITEM_DETAIL_ID"]);
                ItemProperty.Item_Code = Val.ToInt64(txtItemCode.Text);
                ItemProperty.Item_Name = Val.ToString(DRow["ITEM_NAME"]);
                ItemProperty.Location_Code = Val.ToInt(DRow["LOCATION_CODE"]);
                ItemProperty.Reorder_level = Val.ToString(DRow["REORDER_LEVEL"]);

                ItemProperty.Maximum_Reorder_Period = Val.Val(DRow["MAXIMUM_REORDER_PERIOD"]);
                ItemProperty.Maximum_Consumption = Val.Val(DRow["MAXIMUM_CONSUMPTION"]);
                ItemProperty.NoOfDayStock = Val.Val(DRow["NOOFDAYSOFSTOCK"]);
                ItemProperty.Ordering_Qty = Val.Val(DRow["ORDERING_QTY"]);

                ALItem.Add(ItemProperty);
            }

            int IntRes = ObjItem.SaveItem(ItemMasterProperty, AL, ALItem);

            ItemMasterProperty = null;
            if (IntRes != 0)
            {
                Global.Message("Item Is Saved Successfully");
                btnClear_Click(sender, e);
                GetData();
            }
            else
            {
                Global.Message("Erro In Item Save");
            }
        }

        public Item_MasterProperty SaveItemMaster()
        {
            Item_MasterProperty ItemMasterProperty = new Item_MasterProperty();

            ItemMasterProperty.Company_Code = Val.ToInt64(LookupCompany.EditValue);
            ItemMasterProperty.Branch_Code = Val.ToInt64(LookupBranch.EditValue);
            ItemMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);

            ItemMasterProperty.Item_Code = Val.ToInt64(txtItemCode.EditValue);
            ItemMasterProperty.Item_Name = txtItemName.Text;
            ItemMasterProperty.Item_ShortName = Val.ToString(txtShortName.Text);
            ItemMasterProperty.Item_Codification = Val.ToString(txtItemCodification.Text);
            ItemMasterProperty.Item_Group_Code = Val.ToInt64(LookupItemGroup.EditValue);
            ItemMasterProperty.Item_Category_Code = Val.ToInt64(lookUpCategoryName.EditValue);
            ItemMasterProperty.Active = Val.ToInt(RbtStatus.Text);
            ItemMasterProperty.Remark = txtRemark.Text;
            //if (CmbUnitType.SelectedIndex != 0)
            //{
            ItemMasterProperty.Unit_Type = Val.ToString(CmbUnitType.EditValue);
            //}
            ItemMasterProperty.Last_Purchase_Rate = Val.Val(txtLastPurchase.Text);
            ItemMasterProperty.Disc_Per = Val.Val(txtDiscPer.Text);
            ItemMasterProperty.HSN_ID = Val.ToInt64(LookupHSNCode.EditValue);

            return ItemMasterProperty;
        }

        private void Calc(int rowindex)
        {
            try { GrdOpeningStock.SetRowCellValue(rowindex, "AMOUNT", Math.Round(Convert.ToDouble(GrdOpeningStock.GetRowCellValue(rowindex, "RATE")) * Convert.ToDouble(GrdOpeningStock.GetRowCellValue(rowindex, "QUANTITY")), 2)); }
            catch (Exception) { }
        }

        private void CalcNew(int rowindex)
        {
            try { GrdItemGrid.SetRowCellValue(rowindex, "REORDER_LEVEL", Math.Round(Convert.ToDouble(GrdItemGrid.GetRowCellValue(rowindex, "MAXIMUM_REORDER_PERIOD")) * Convert.ToDouble(GrdItemGrid.GetRowCellValue(rowindex, "MAXIMUM_CONSUMPTION")), 2)); }
            catch (Exception) { }
            try { GrdItemGrid.SetRowCellValue(rowindex, "ORDERING_QTY", Math.Round(Convert.ToDouble(GrdItemGrid.GetRowCellValue(rowindex, "NOOFDAYSOFSTOCK")) * Convert.ToDouble(GrdItemGrid.GetRowCellValue(rowindex, "MAXIMUM_CONSUMPTION")), 2)); }
            catch (Exception) { }
        }

        private void LookupItemGroup_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemGroupMaster frmCnt = new FrmItemGroupMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemGroup(LookupItemGroup);
            }
        }

        private void LookupCategory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemCategoryMaster frmCnt = new FrmItemCategoryMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemCategory(lookUpCategoryName);
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

        private void FrmItemMaster_Shown(object sender, EventArgs e)
        {
            GetData();

            Global.LOOKUPItemGroup(LookupItemGroup);
            Global.LOOKUPItemCategory(lookUpCategoryName);
            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPBranch(LookupBranch);

            Global.LOOKUPCompanyRep(LookUpRepCompany);
            Global.LOOKUPBranchRep(LookUpRepBranch);
            Global.LOOKUPLocationRep(LookUpRepLocation);
            Global.LOOKUPItemHSN(LookupHSNCode);
            Global.LOOKUPUnitType(CmbUnitType);

            Global.LOOKUPLocationRep(repositoryItemLookUpEdit3);
            txtItemName.Focus();
        }

        private void GetItemDetail()
        {
            this.Cursor = Cursors.WaitCursor;
            dgvOpeningStock.DataSource = null;
            DataTable DTab = ObjItem.GetItemOpeningDetail(Val.ToInt(txtItemCode.Text));

            dgvOpeningStock.DataSource = DTab;

            ObjItem = new ItemMaster();
            DataTable DTab1 = ObjItem.GetItemDetail(Val.ToInt(txtItemCode.Text));

            dgvItemGrid.DataSource = DTab1;

            this.Cursor = Cursors.Default;
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

        private void LookUpRepCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompanyRep(LookUpRepCompany);
            }
        }

        private void repositoryItemLookUpEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocationRep(repositoryItemLookUpEdit3);
            }
        }

        private void GrdOpeningStock_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Calc(GrdOpeningStock.FocusedRowHandle);
        }

        private void GrdOpeningStock_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            Calc(GrdOpeningStock.FocusedRowHandle);
        }

        private void GrdOpeningStock_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Calc(e.PrevFocusedRowHandle);
        }

        private void GrdItemGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CalcNew(e.PrevFocusedRowHandle);
        }

        private void GrdItemGrid_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            CalcNew(GrdItemGrid.FocusedRowHandle);
        }

        private void GrdItemGrid_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            CalcNew(GrdItemGrid.FocusedRowHandle);
        }

        private void GrdDetItemMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow DRow = GrdDetItemMaster.GetDataRow(e.RowHandle);

                    txtItemCode.Text = Val.ToString(DRow["ITEM_CODE"]);
                    txtItemName.Text = Val.ToString(DRow["ITEM_NAME"]);
                    txtShortName.Text = Val.ToString(DRow["ITEM_SHORTNAME"]);
                    LookupItemGroup.EditValue = Val.ToInt64(DRow["ITEM_GROUP_CODE"]);
                    lookUpCategoryName.EditValue = Val.ToInt64(DRow["ITEM_CATEGORY_CODE"]);
                    txtItemCodification.Text = Val.ToString(DRow["ITEM_CODIFICATION"]);
                    CmbUnitType.EditValue = Val.ToString(DRow["UNIT_NAME"]);
                    txtLastPurchase.Text = Val.ToString(DRow["LAST_PURCHASE_RATE"]);
                    RbtStatus.EditValue = Convert.ToInt32(DRow["ACTIVE"]);
                    txtRemark.Text = Val.ToString(DRow["REMARK"]);
                    txtDiscPer.Text = Val.ToString(DRow["DISC_PER"]);
                    LookupCompany.EditValue = Val.ToInt64(DRow["ICOMPANY_CODE"]);
                    LookupBranch.EditValue = Val.ToInt64(DRow["IBRANCH_CODE"]);
                    LookupLocation.EditValue = Val.ToInt64(DRow["ILOCATION_CODE"]);
                    LookupHSNCode.EditValue = Val.ToInt64(DRow["HSN_ID"]);

                    GetItemDetail();
                    txtItemName.Focus();
                }
            }
        }

        private void txtItemName_Validated(object sender, EventArgs e)
        {
            GrdItemGrid.SetRowCellValue(0, "ITEM_NAME", txtItemName.Text);
        }

        private void LookupHSNCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmItemHSNMaster frmCnt = new FrmItemHSNMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPItemHSN(LookupHSNCode);
            }
        }

        private void LookupHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
            }
        }
    }
}
