using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System.Collections;

namespace BLL.FunctionClasses.Master
{
    public class ItemMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Property Settings

        private DataTable _DTab = new DataTable("Item_Master");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }
        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }


        public string ItemDetail
        {
            get { return "Item_Detail"; }
        }

        #endregion

        #region Other Function

        public int FindNewID()
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Item_Master", "MAX(ITEM_CODE)", "");
        }

        public int Save(Item_MasterProperty pClsProperty)
        {
            //pClsProperty.Record_Code = FindRecordCode(pClsProperty.Item_Code);
            
            Request Request = new Request();

            // Start Haresh On 02-Dec-2013

            Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);

            // End Haresh 

            Request.AddParams("ITEM_CODE_", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("ITEM_NAME_", pClsProperty.Item_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("ITEM_SHORTNAME_", pClsProperty.Item_ShortName, DbType.String, ParameterDirection.Input);
            Request.AddParams("ITEM_GROUP_CODE_", pClsProperty.Item_Group_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("ITEM_CATEGORY_CODE_", pClsProperty.Item_Category_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("RECORD_CODE_", pClsProperty.Record_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("REORDER_LEVEL_", pClsProperty.Reorder_level, DbType.String, ParameterDirection.Input);
            Request.AddParams("UNIT_TYPE_", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("LAST_PURCHASE_RATE_", pClsProperty.Last_Purchase_Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ITEM_CODIFICATION_", pClsProperty.Item_Codification, DbType.String, ParameterDirection.Input);
            Request.AddParams("VAT_PER_", pClsProperty.Vat_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ADD_VAT_PER_", pClsProperty.Add_Vat_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("DISC_PER_", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "Item_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        public int SaveItem(Item_MasterProperty pClsProperty, ArrayList AL, ArrayList ALItem)
        {
            int IntRes = 0;
           
                try
                {
                    Request Request = new Request();

                    Request.AddParams("@ITEM_CODE_", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@ITEM_NAME_", pClsProperty.Item_Name, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@ITEM_SHORTNAME_", pClsProperty.Item_ShortName, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@ITEM_GROUP_CODE_", pClsProperty.Item_Group_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@ITEM_CATEGORY_CODE_", pClsProperty.Item_Category_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@ACTIVE_", pClsProperty.Active, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@RECORD_CODE_", pClsProperty.Record_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@REORDER_LEVEL_", pClsProperty.Reorder_level, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@UNIT_TYPE_", pClsProperty.Unit_Type, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@LAST_PURCHASE_RATE_", pClsProperty.Last_Purchase_Rate, DbType.Double, ParameterDirection.Input);
                    Request.AddParams("@ITEM_CODIFICATION_", pClsProperty.Item_Codification, DbType.String, ParameterDirection.Input);
                    Request.AddParams("@DISC_PER_", pClsProperty.Disc_Per, DbType.Double, ParameterDirection.Input);
                    Request.AddParams("@COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
                    Request.AddParams("@HSN_ID_", pClsProperty.HSN_ID, DbType.Int64, ParameterDirection.Input);

                    Request.CommandText = "Item_Master_Save";
                    Request.CommandType = CommandType.StoredProcedure;
                    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                    if (IntRes != -1)
                    {
                        foreach (Item_DetailProperty Obj in AL)
                        {
                            Request = new Request();

                            Request.AddParams("@COMPANY_CODE_", Obj.Company_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@BRANCH_CODE_", Obj.Branch_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@LOCATION_CODE_", Obj.Location_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@ITEM_CODE_", Obj.Item_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@ITEM_OPENING_ID_", Obj.ITEM_OPENING_ID, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@QUANTITY_", Obj.Quantity, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@RATE_LOCAL_", Obj.Rate_Local, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@AMOUNT_LOCAL_", Obj.Amount_Local, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@OPENING_DATE_", Obj.Opening_date, DbType.Date, ParameterDirection.Input);
                            Request.AddParams("@FIN_YEAR_CODE_", GlobalDec.gEmployeeProperty.gFinancialYear_Code, DbType.Int64, ParameterDirection.Input);

                            Request.CommandText = "Item_Opening_Save";
                            Request.CommandType = CommandType.StoredProcedure;
                            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                        }
                        foreach (Item_MasterProperty Obj in ALItem) //Khushbu 7/12/2013
                        {
                            Request = new Request();

                            Request.AddParams("@LOCATION_CODE_", Obj.Location_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@ITEM_CODE_", Obj.Item_Code, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@ITEM_DETAIL_ID_", Obj.ITEM_DETAIL_ID, DbType.Int64, ParameterDirection.Input);
                            Request.AddParams("@ITEM_NAME_", Obj.Item_Name, DbType.String, ParameterDirection.Input);
                            Request.AddParams("@REORDER_LEVEL_", Obj.Reorder_level, DbType.String, ParameterDirection.Input);

                            /*ADD BY HARESH ON 29-08-2014 FOR REORDER LEVEL PARAMTER OF ITEM*/

                            Request.AddParams("@MAXIMUM_REORDER_PERIOD_", Obj.Maximum_Reorder_Period, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@MAXIMUM_CONSUMPTION_", Obj.Maximum_Consumption, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@NOOFDAYSOFSTOCK_", Obj.NoOfDayStock, DbType.Double, ParameterDirection.Input);
                            Request.AddParams("@ORDERING_QTY_", Obj.NoOfDayStock, DbType.Double, ParameterDirection.Input);
                            /*-----*/

                            Request.CommandText = "Item_Detail_Save";
                            Request.CommandType = CommandType.StoredProcedure;
                            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                        }

                    }
                  //  Ope.Commit(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
                }
                catch
                {
                    Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
                    IntRes = 0;
                }
                return IntRes;
        }

        public string ISExists(string ItemName, Int64 ItemCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "ITEM_MASTER", "ITEM_NAME", "AND ITEM_NAME = '" + ItemName + "' AND NOT ITEM_CODE =" + ItemCode));
        }  

        public void GetData()
        {
            Request Request = new Request();
            Request.CommandText = "Item_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        }

        public int Delete(Item_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ITEM_CODE", pClsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Item_Master_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }       

        public DataTable GetDataForSearch()
        {
            Request Request = new Request();

            Request.AddParams("@ACTIVE", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Item_Master_GetDataSearch";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetDataForSearch(int pIntLocationCode)
        {
            Request Request = new Request();

            Request.AddParams("ACTIVE_", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Item_Master_GetDataSearch";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetDataOnChallanNo(int From_Party_Code, int To_Party_Code, string Client_Challan_No)
        {
            //ADD : NARENDRA : 08-04-2014
            Request Request = new Request();

            Request.AddParams("ACTIVE_", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_PARTY_CODE_", From_Party_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", To_Party_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CLIENT_CHALLAN_NO_", Client_Challan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", GlobalDec.gFinancialYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Item_Master_GetDataOnChallanNo";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        public int FindRecordCode(int pIntCode)
        {
            Validation Val = new Validation();
            int IntRes = Val.ToInt(Val.SearchText(DTab, "ITEM_CODE", pIntCode.ToString(), "RECORD_CODE"));
            Val = null;
            return IntRes;
        }

        public DataTable GetItemOpeningDetail(int pIntItemCode = 0)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@ITEM_CODE_", pIntItemCode, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Opening_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetItemDetail(int pIntItemCode = 0)//Khushbu 6/12/2013
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@ITEM_CODE_", pIntItemCode, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Detail_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable ItemGetDataForSearch() // Khushbu 7/12/2013
        {
            Request Request = new Request();

            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ACTIVE_", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Item_Master_GetDataSearch";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        #endregion
    }
}
