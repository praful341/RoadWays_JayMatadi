using BLL;
using BLL.FunctionClasses.Master;
using DevExpress.XtraBars;
using RoadWays.Class;
using RoadWays.Report;
using RoadWays.Search;
using RoadWays.Transaction;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Validation Val = new Validation();
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        EmployeeMaster Emp = new EmployeeMaster();
        public FrmMain()
        {
            InitializeComponent();
            //if (!ISActive())
            //{
            //    if (Global.Confirm("Licence Expire...\n Do You Want To Register Product?", "STORE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            //    {
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        FrmUnlock frmlock = new FrmUnlock();
            //        frmlock.ShowDialog();
            //    }
            //}

            FrmLogin frmlg = new FrmLogin();
            frmlg.ShowDialog();
            if (BLL.GlobalDec.gEmployeeProperty.User_Code == 0)
            {
                Application.Exit();
            }
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = false;
            //objBOFormEvents.FormClosing = false;            
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void barbtnComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCompanyMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCompanyMaster frmcomp = new FrmCompanyMaster();
                frmcomp.MdiParent = this;
                frmcomp.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            AttachFormEvents();
        }

        public void Backup()
        {
            try
            {
                string appPath = Application.StartupPath.ToString();
                ClassINI iniCl = new ClassINI(appPath + "\\RoadWays.CONFIG"); //new ClassINI(Application.StartupPath.ToString() + "\\RoadWays.CONFIG");
                string gStrHostName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerHostName"), true);
                if (gStrHostName == "192.168.2.218") //GlobalDec.gStrComputerIP)
                {
                    string Bnm = "Backup_STORE_" + DateTime.Now.Date.ToShortDateString().Replace("/", "");
                    if ((File.Exists(Application.StartupPath + "\\BackUp\\" + Bnm + ".bak") == false))
                    {
                        if (MessageBox.Show("Do you want to take Backup?", "STORE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (Directory.Exists(Application.StartupPath + "\\BackUp") == false)
                                Directory.CreateDirectory(Application.StartupPath + "\\BackUp");

                            //      MCSLibrary.ModConnection.MExecuteStr("backup database MARGO  to disk='" + Txtpath.Text + "\\MFull.bak'");
                            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(BLL.DBConnections.ConnectionString);
                            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
                            comm.Connection = conn;
                            if (conn.State == ConnectionState.Closed) { conn.Open(); }
                            comm.CommandText = "backup database  STORE  to disk = '" + Application.StartupPath + "\\BackUp\\" + Bnm + ".bak'";
                            int i = comm.ExecuteNonQuery();
                            conn.Close();
                            //DataTable tdt = new DataTable();
                            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request);

                            //Process sc = new Process();
                            //sc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            //sc.StartInfo.FileName = Application.StartupPath + "\\7z.exe";
                            //sc.StartInfo.Arguments = " a " + Application.StartupPath.ToString() + "\\" + Bnm + ".MAR" + " " + Application.StartupPath.ToString() + "\\MarFull.bak";
                            //sc.Start();
                            //sc.WaitForExit();

                            //if (File.Exists( Application.StartupPath.ToString() + "\\MarFull.bak"))
                            //    File.Delete( Application.StartupPath.ToString() + "\\MarFull.bak");

                            MessageBox.Show("Backup Successfully Completed.", "STORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch { }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Global.gMainFormRef = this;
            DevExpress.UserSkins.BonusSkins.Register();
            //    DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.XtraBars.Ribbon.GalleryDropDown skins = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            skins.Ribbon = ribbonControl1;
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
            barBtnTheme.DropDownControl = skins;
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";

            skins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(gallery_GalleryItemClick);

            Global.Gwidth = this.Width;
            Global.Gheight = this.Height;

            Ribbon.AllowMinimizeRibbon = true;

            DataTable DTabThemes = Emp.Get_Theme_Master();

            if (DTabThemes.Rows.Count > 0)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Val.ToString(DTabThemes.Rows[0]["Theme_Name"]);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
            }

            //  Ribbon.Minimized = true;
            barComp.Caption = "Company : " + BLL.GlobalDec.gEmployeeProperty.Company_Name;
            BarBranch.Caption = "Branch : " + BLL.GlobalDec.gEmployeeProperty.Branch_Name;
            barLocation.Caption = "Location : " + BLL.GlobalDec.gEmployeeProperty.Location_Name;
            barFinYear.Caption = "Fin. Year : " + BLL.GlobalDec.gEmployeeProperty.gFinancialYear;
            AttachFormEvents();
        }

        void gallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {

            try

            {
                // MessageBox.Show(e.Item.Tag.ToString());
                Int32 Res = Emp.SaveThemes(e.Item.Tag.ToString());

                if (Res != 0)
                {

                }
            }
            catch (Exception)
            { }
            //using (ConfigManager cfgMgr = new ConfigManager())
            //{
            //    cfgMgr.SetLocalConfigData(Config.LocalConfigValue.SkinName, e.Item.Tag.ToString());
            //}
        }

        private void barbtnBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmBranchMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmBranchMaster frmbranch = new FrmBranchMaster();
                frmbranch.MdiParent = this;
                frmbranch.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmLocationMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmLocationMaster frmLoc = new FrmLocationMaster();
                frmLoc.MdiParent = this;
                frmLoc.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmEmployeeMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmEmployeeMaster frmemp = new FrmEmployeeMaster();
                frmemp.MdiParent = this;
                frmemp.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCountryMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCountryMaster frmcountry = new FrmCountryMaster();
                frmcountry.MdiParent = this;
                frmcountry.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnState_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmStateMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmStateMaster frmState = new FrmStateMaster();
                frmState.MdiParent = this;
                frmState.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnCity_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCityMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCityMaster frmCity = new FrmCityMaster();
                frmCity.MdiParent = this;
                frmCity.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barmenubtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close(); // Application.Exit();
        }

        private void barbtnItemCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmItemCategoryMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmItemCategoryMaster frmItemCategory = new FrmItemCategoryMaster();
                frmItemCategory.MdiParent = this;
                frmItemCategory.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnItemGroup_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmItemGroupMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmItemGroupMaster frmItemGroup = new FrmItemGroupMaster();
                frmItemGroup.MdiParent = this;
                frmItemGroup.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmItemMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmItemMaster frmItem = new FrmItemMaster();
                frmItem.MdiParent = this;
                frmItem.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            LocationMaster ObjLocation = new LocationMaster();
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            DataTable tdt = ObjLocation.GetData();
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["LOCATION_CODE"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["LOCATION_NAME"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["ACTIVE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["REMARK"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.Location_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["Location_Code"]));
                barLocation.Caption = "Location : " + Val.ToString(FrmDevExpPopupGrid.DRow["Location_Name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void barComp_ItemClick(object sender, ItemClickEventArgs e)
        {
            CompanyMaster ObjCompany = new CompanyMaster();
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            DataTable tdt = ObjCompany.GetData();
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["COMPANY_CODE"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["COMPANY_NAME"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["ACTIVE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["REMARK"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.Company_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["Company_Code"]));
                barComp.Caption = "Company : " + Val.ToString(FrmDevExpPopupGrid.DRow["Company_Name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void BarBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            BranchMaster ObjBranch = new BranchMaster();
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            DataTable tdt = ObjBranch.GetData();
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["BRANCH_CODE"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["BRANCH_NAME"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["ACTIVE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["REMARK"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.Branch_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["Branch_Code"]));
                BarBranch.Caption = "Branch : " + Val.ToString(FrmDevExpPopupGrid.DRow["Branch_Name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void barbtnItemPurchaseMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmItemPurchaseMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmItemPurchaseMaster frmItem = new FrmItemPurchaseMaster();
                frmItem.MdiParent = this;
                frmItem.Show();
            }
            else
            {
                k.Activate();
            }
        }

        //private void barButtonItemPurchaseReturn_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var k = MdiChildren.Where(c => c.GetType() == typeof(Transaction.FrmItemPurchaseRtnMaster)).FirstOrDefault();
        //    if (k == null)
        //    {
        //        Transaction.FrmItemPurchaseRtnMaster frmItem = new Transaction.FrmItemPurchaseRtnMaster("PR");
        //        frmItem.MdiParent = this;
        //        frmItem.Show();
        //    }
        //    else
        //    {
        //        k.Activate();
        //    }
        //}

        //private void barButtonSalesMaster_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var k = MdiChildren.Where(c => c.GetType() == typeof(Transaction.FrmItemSaleMaster)).FirstOrDefault();
        //    if (k == null)
        //    {
        //        Transaction.FrmItemSaleMaster frmItem = new Transaction.FrmItemSaleMaster("S");
        //        frmItem.MdiParent = this;
        //        frmItem.Show();
        //    }
        //    else
        //    {
        //        k.Activate();
        //    }
        //}

        //private void barButtonSalesReturnMaster_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var k = MdiChildren.Where(c => c.GetType() == typeof(Transaction.FrmItemSaleRetMaster)).FirstOrDefault();
        //    if (k == null)
        //    {
        //        Transaction.FrmItemSaleRetMaster frmItem = new Transaction.FrmItemSaleRetMaster("SR");
        //        frmItem.MdiParent = this;
        //        frmItem.Show();
        //    }
        //    else
        //    {
        //        k.Activate();
        //    }
        //}

        private void barbtnParty_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmFromPartyMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmFromPartyMaster frmParty = new FrmFromPartyMaster();
                frmParty.MdiParent = this;
                frmParty.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnItemHSN_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmItemHSNMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmItemHSNMaster frmItemHSN = new FrmItemHSNMaster();
                frmItemHSN.MdiParent = this;
                frmItemHSN.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnCompanyYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCompanyYearMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCompanyYearMaster frmCompanyYear = new FrmCompanyYearMaster();
                frmCompanyYear.MdiParent = this;
                frmCompanyYear.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void lblFinYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            FinancialYearMaster ObjFinancial = new FinancialYearMaster();
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            DataTable tdt = ObjFinancial.GetData_Search();
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["FINANCIAL_YEAR"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["ACTIVE"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["FIN_YEAR_CODE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["START_DATE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["END_DATE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["SHORT_NAME"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["START_YEARMONTH"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["END_YEARMONTH"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.gFinancialYear_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["FIN_YEAR_CODE"]));
                barFinYear.Caption = "Fin. Year : " + Val.ToString(FrmDevExpPopupGrid.DRow["FINANCIAL_YEAR"]);
                GlobalDec.gEmployeeProperty.gFinancialYear = Val.ToString(FrmDevExpPopupGrid.DRow["FINANCIAL_YEAR"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Backup();
        }

        private void barBtnTransactionReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmReportList)).FirstOrDefault();
            if (k == null)
            {
                FrmReportList ReportList = new FrmReportList();
                ReportList.MdiParent = this;
                ReportList.ShowForm("", "TransactionReport");
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnUnitType_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmUnitTypeMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmUnitTypeMaster FrmUnitTypeMaster = new FrmUnitTypeMaster();
                FrmUnitTypeMaster.MdiParent = this;
                FrmUnitTypeMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnToParty_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmToPartyMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmToPartyMaster ToParty = new FrmToPartyMaster();
                ToParty.MdiParent = this;
                ToParty.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnTruck_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmTruckMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmTruckMaster Truck = new FrmTruckMaster();
                Truck.MdiParent = this;
                Truck.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnBillEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmBillTransaction)).FirstOrDefault();
            if (k == null)
            {
                FrmBillTransaction BillTran = new FrmBillTransaction();
                BillTran.MdiParent = this;
                BillTran.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnBillReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmBillPrintRajkot)).FirstOrDefault();
            if (k == null)
            {
                FrmBillPrintRajkot ReportList = new FrmBillPrintRajkot();
                ReportList.MdiParent = this;
                ReportList.ShowForm("Bill");
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnBillSuratReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmBillPrintSurat)).FirstOrDefault();
            if (k == null)
            {
                FrmBillPrintSurat ReportList = new FrmBillPrintSurat();
                ReportList.MdiParent = this;
                ReportList.ShowForm("Bill");
            }
            else
            {
                k.Activate();
            }
        }

        private void barButtonCheckPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmChequePrintUtility)).FirstOrDefault();
            if (k == null)
            {
                FrmChequePrintUtility FrmChequePrintUtility = new FrmChequePrintUtility();
                FrmChequePrintUtility.MdiParent = this;
                FrmChequePrintUtility.Show();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnTruckWiseDetailReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmReportList)).FirstOrDefault();
            if (k == null)
            {
                FrmReportList ReportList = new FrmReportList();
                ReportList.MdiParent = this;
                ReportList.ShowForm("", "TruckWise");
            }
            else
            {
                k.Activate();
            }
        }
    }
}
