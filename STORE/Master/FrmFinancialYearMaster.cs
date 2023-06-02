using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using RoadWays.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace RoadWays
{
    public partial class FrmCompanyYearMaster : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        FinancialYearMaster objCompany = new FinancialYearMaster();

        public FrmCompanyYearMaster()
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
            txtYearCode.Text = "0";
            txtFinancialYear.Text = "";
            txtShortName.Text = "";
            DTPStartDate.Text = Val.DBDate(System.DateTime.Now.ToString());
            DTPEndDate.Text = Val.DBDate(System.DateTime.Now.ToString());
            ChkActive.Checked = false;
            DTPStartDate.Focus();
        }

        #region Validation
 
        private bool ValSave()
        {
            if (txtFinancialYear.Text.Length == 0)
            {
                Global.Message("Financial Year Is Required");
                txtFinancialYear.Focus();
                return false;
            }
            DateTime fromdate = Convert.ToDateTime(DTPStartDate.Text);
            DateTime todate = Convert.ToDateTime(DTPEndDate.Text); 
            if (fromdate > todate)
            {
                Global.Message("End Date Is Not Proper Please Check End Date:");
                DTPEndDate.Focus();
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

            Financial_Year_MasterProperty CompanyYearProperty = new Financial_Year_MasterProperty();
            CompanyYearProperty.Fin_Year_Code = Val.ToInt64(txtYearCode.Text);
            CompanyYearProperty.Financial_year = Val.ToString(txtFinancialYear.Text);
            CompanyYearProperty.Start_Date = Val.DBDate(DTPStartDate.Text);
            CompanyYearProperty.End_Date = Val.DBDate(DTPEndDate.Text);
            CompanyYearProperty.Short_Name = Val.ToString(txtShortName.Text);
            CompanyYearProperty.Active = Val.ToInt64(ChkActive.Checked == true ? 1 : 0);
            string StrStart_YearMonth = Global.GetFinancialYearNew(DTPStartDate.Text.ToString());
            string StrEnd_YearMonth = Global.GetFinancialYearNew(DTPEndDate.Text.ToString());
            CompanyYearProperty.Start_YearMonth = Val.ToInt64(StrStart_YearMonth.ToString());
            CompanyYearProperty.End_YearMonth = Val.ToInt64(StrEnd_YearMonth.ToString());
           
            int IntRes = objCompany.Save(CompanyYearProperty);


            if (IntRes == -1)
            {
                Global.Message("Error In Save Year  Details");
                DTPStartDate.Focus();
            }
            else
            {
                Global.Message("Company Year Data save successfully");
                GetData();
                btnClear_Click(sender, e);
            }
            CompanyYearProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objCompany.GetData_Search();
            grdCompanyYearMaster.DataSource = DTab;
            dgvCompanyYearMaster.BestFitColumns();
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow DRow = dgvCompanyYearMaster.GetDataRow(e.RowHandle);                  

                    txtYearCode.Text = Val.ToString(DRow["FIN_YEAR_CODE"]);
                    txtFinancialYear.Text = Val.ToString(DRow["FINANCIAL_YEAR"]);
                    DTPStartDate.Text = Val.DBDate(DRow["START_DATE"].ToString());
                    DTPEndDate.Text = Val.DBDate(DRow["END_DATE"].ToString());
                    txtShortName.Text = Val.ToString(DRow["SHORT_NAME"]);
                    ChkActive.Checked = Val.ToInt(DRow["ACTIVE"]) == 1 ? true : false;
                }
            }
        }

        private void FrmCompanyYearMaster_Shown(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            DTPStartDate.Focus();         
        }

        private void DTPStartDate_EditValueChanged(object sender, EventArgs e)
        {
            DTPEndDate.EditValue = new DateTime(DTPStartDate.DateTime.Year + 1, DTPStartDate.DateTime.Month, DTPStartDate.DateTime.Day).AddDays(-1);
            txtFinancialYear.Text = DTPStartDate.DateTime.Year + "-" + DTPEndDate.DateTime.Year;
            txtShortName.Text = DTPStartDate.DateTime.Year + "-" + txtFinancialYear.Text.Substring(7, 2);            
        }
    }
}
