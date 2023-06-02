using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace DLL
{
    class OperationSql
    {
        SqlConnection Connection = new SqlConnection();
        SqlCommand Command = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        SqlTransaction Transaction;

        #region Private Method

        public void ConnectionBifercation(string pStrConnectionString)
        {
            SqlConnectionStringBuilder Str = new SqlConnectionStringBuilder(pStrConnectionString);
            GlobalDec.gStrDBDataSource = Str.DataSource;
            GlobalDec.gStrDBUserName = Str.UserID;
            GlobalDec.gStrDBPassWord = Str.Password;
            GlobalDec.gStrDBName = Str.InitialCatalog;
            Str = null;
        }

        private void DisposeAllConnObjects(SqlConnection pConn)
        {
            if (Command != null)
            {
                Command.Dispose();
                Command = null;
            }
            if (DataAdapter != null)
            {
                DataAdapter.Dispose();
                DataAdapter = null;
            }
            if (pConn != null)
            {
                if (pConn.State == System.Data.ConnectionState.Open)
                {
                    pConn.Close();
                    pConn.Dispose();
                    pConn = null;
                }
            }
            else
            {
                pConn = null;
            }
        }

        private void CreateAllConnObjects(string pStrConnectionString)
        {
            try
            {
                Connection.ConnectionString = pStrConnectionString;
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection.Open();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Can't Connect To [ " + Connection.DataSource + " ] Server  " + Ex.Message);
                return;
            }
            Command = new SqlCommand();
            DataAdapter = new SqlDataAdapter();
        }

        #endregion

        #region FillDataTable

        public void FillDataTable(string pStrConnectionString, DataTable pDTab, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, string pStrPrimaryKeys = "")
        {
            try
            {
                CreateAllConnObjects(pStrConnectionString);

                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.CommandTimeout = 50000;
                Command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {                    
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }

                if (pDTab != null)
                {
                    pDTab.Rows.Clear();
                    pDTab.Columns.Clear();
                }

                DataAdapter.SelectCommand = Command;

                DataAdapter.Fill(pDTab);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DisposeAllConnObjects(Connection);
                if (pStrPrimaryKeys != "")
                {
                    string[] StrArray;
                    StrArray = pStrPrimaryKeys.Split(',');
                    DataColumn[] DataColumnPrimaryKey;
                    DataColumnPrimaryKey = new DataColumn[StrArray.GetUpperBound(0) + 1];
                    for (int IntCount = 0; IntCount <= StrArray.GetUpperBound(0); IntCount++)
                    {
                        DataColumnPrimaryKey[IntCount] = pDTab.Columns[IntCount];
                    }
                    pDTab.PrimaryKey = DataColumnPrimaryKey;
                    DataColumnPrimaryKey = null;
                }
            }
        }

        #endregion

        #region FillDataset

        public void FillDataSet(string pStrConnectionString, DataSet pDs, string pStrTableName, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, string pStrPrimaryKeys = "")
        {
            FillDataTable(pStrConnectionString, pDs.Tables[pStrTableName], pStrCommandText, pEnmCommandType, null, pStrPrimaryKeys);
        }

        #endregion

        #region FillComboByParameter

        public void FillComboByParameter(string pStrConnectionString, DataSet pDs, string pStrTableName, string pStrDBTableName, string pStrField, string pStrCriteria, string pStrPrimaryKeys = "")
        {
            string StrQuery = "Select " + pStrField + " From " + pStrDBTableName + " Where 1=1 " + pStrCriteria + "";
            FillDataSet(pStrConnectionString, pDs, pStrTableName, StrQuery, CommandType.Text, null, pStrPrimaryKeys);
        }

        public void FillComboByParameter(string pStrConnectionString, DataTable pDTab, string pStrDBTableName, string pStrField, string pStrCriteria, string pStrPrimaryKeys = "")
        {
            string StrQuery = "Select " + pStrField + " From " + pStrDBTableName + " Where 1=1 " + pStrCriteria + "";
            FillDataTable(pStrConnectionString, pDTab, StrQuery, CommandType.Text, null, pStrPrimaryKeys);
        }

        #endregion

        #region GetDataRow

        public DataRow GetDataRow(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                FillDataTable(pStrConnectionString, DTab, pStrCommandText, pEnmCommandType, pParamList);
                if (DTab != null)
                {
                    if (DTab.Rows.Count > 0)
                    {
                        DRow = DTab.Rows[0];
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllConnObjects(Connection);
            }
            return DRow;
        }

        //public DataRow GetDataRowWithConn(SqlConnection pConn, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        //{
        //    DataTable DTab = new DataTable();
        //    try
        //    {
        //        Command = new SqlCommand();
        //        Command.CommandType = CommandType.StoredProcedure;
        //        Command.CommandText = pStrCommandText;
        //        Command.Connection = pConn;
        //        Command.Transaction = MyTransaction;

        //        if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
        //        {
        //            Command.CommandType = CommandType.StoredProcedure;
        //            Command.Parameters.Add("REF_CUR_OUT", SqlDbType..Cursor).Direction = ParameterDirection.Output;
        //            for (int i = 0; i < pParamList.Length; i++)
        //            {
        //                if (pParamList[i] != null)
        //                {
        //                    if (pParamList[i].DbType == DbType.AnsiString && pParamList[i].Direction == ParameterDirection.Output)
        //                    {
        //                        pParamList[i].Size = 500;
        //                    }
        //                    Command.Parameters.Add(pParamList[i]);
        //                }
        //            }
        //        }
        //        else if (pEnmCommandType == CommandType.Text)
        //        {
        //            Command.CommandType = CommandType.Text;
        //        }

        //        DataAdapter.SelectCommand = Command;
        //        DataAdapter.Fill(DTab);

        //        if (DTab == null || DTab.Rows.Count == 0)
        //        {
        //            return null;
        //        }

        //    }
        //    catch (OracleException ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //        return null;
        //    }
        //    return DTab.Rows[0];

        //}

        public void Commit()
        {
            Transaction.Commit();
            DisposeAllConnObjects(Connection);
        }
        public void RollBack()
        {
            Transaction.Rollback();
            DisposeAllConnObjects(Connection);
        }


        public DataRow GetDataRow(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                string StrQuery = "Select " + pStrField + " From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

                DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllConnObjects(Connection);
            }
            return DRow;
        }

        #endregion

        #region FindNewID

        public int FindNewID(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            int IntRes = 0;

            string StrQuery = "Select IsNull(" + pStrField + ",0) As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                IntRes = Convert.ToInt32(DRow["ID"].ToString()) + 1;
            }
            DRow = null;
            return IntRes;
        }

        public Int64 FindNewIDInt64(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            Int64 IntRes = 0;

            string StrQuery = "Select IsNull(" + pStrField + ",0) As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                IntRes = Convert.ToInt64(DRow["ID"].ToString()) + 1;
            }
            DRow = null;
            return IntRes;
        }

        #endregion

        #region FindText

        public string FindText(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            string StrRes = "";

            string StrQuery = "Select " + pStrField + " As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                StrRes = DRow["ID"].ToString();
            }
            DRow = null;
            return StrRes;
        }

        #endregion

        #region OracleDataReader

        public SqlDataReader ExeReader(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            try
            {
                CreateAllConnObjects(pStrConnectionString);

                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;

                Command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }

                return Command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
            finally
            {
                DisposeAllConnObjects(Connection);
            }
        }

        #endregion

        #region Execute Scaler

        public string ExecuteScalar(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            string StrResult = "";
            try
            {
                CreateAllConnObjects(pStrConnectionString);

                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;

                Command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }

                StrResult = Command.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return "";
            }
            finally
            {
                DisposeAllConnObjects(Connection);
            }
            return StrResult;
        }

        #endregion

        #region Execute Non Query

        public int ExecuteNonQuery(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            int IntResult = 0;
            try
            {
                CreateAllConnObjects(pStrConnectionString);
                 
                Transaction = Connection.BeginTransaction("SampleTransaction");

                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.Transaction =  Transaction;




                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }
                else if (pEnmCommandType == CommandType.Text)
                {
                    Command.CommandType = CommandType.Text;
                }

                IntResult = Command.ExecuteNonQuery();
                Transaction.Commit();

            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
            finally
            {
                DisposeAllConnObjects(Connection);
            }
            return IntResult;
        }
     
        public ArrayList ExecuteNonQueryWithRetunValues(ArrayList AL, string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null)
        {
            int IntResult = 0;
            try
            {
                CreateAllConnObjects(pStrConnectionString);

                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                        {
                            Command.Parameters.Add(pParamList[i]);
                        }
                    }
                }
                else if (pEnmCommandType == CommandType.Text)
                {
                    Command.CommandType = CommandType.Text;
                }

                IntResult = Command.ExecuteNonQuery();


                AL.Clear();
                foreach (SqlParameter iParam in pParamList)
                {
                    if (iParam.Direction == ParameterDirection.Output || iParam.Direction == ParameterDirection.InputOutput || iParam.Direction == ParameterDirection.ReturnValue)
                    {
                        AL.Add(iParam.Value);
                    }
                }
                 
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
            finally
            {
                DisposeAllConnObjects(Connection);
            }
            return AL;
        }

        #endregion

    }
}
