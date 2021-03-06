//using log4net;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using BMS.Exceptions;
using BMS.Model;
using BMS.Utils;
using BMS.Facade;

using System.Globalization;

namespace BMS.Facade
{
    public class BaseFacade
    {
        public static readonly string strcon = Global.ConnectionString;
        public string className;
        public string tableName;
        public EventsLogModel mEL;

        public BaseModel baseModel = new BaseModel();
        //protected static ILog log;

        public BaseFacade()
        {
        }
        public String Audit(BaseModel obj)//Make sure that obj contain iD
        {
            string Changes = "";
            if (obj != null)
            {
                string name = obj.GetType().Name;
                name.Substring(0, name.Length - 5);
                Int64 id = Int64.Parse(PropertyUtils.GetValue(obj, name.Substring(0, name.Length - 5) + "iD").ToString());
                BaseModel oldObject = null;
                oldObject = FindByPK(id);
                Changes = obj.CompareTo(oldObject);
            }
            return Changes;
        }

        public string fordate(DateTime dt)
        {
            return DateTime.Parse(dt.ToShortDateString(), new CultureInfo("en-US", true)).ToString("MM/dd/yyyy");
        }
        public string fordate(string dt)
        {
            return DateTime.Parse(dt, new CultureInfo("en-US", true)).ToString("MM/dd/yyyy");
        }
        public BaseFacade(BaseModel baseModel)
        {
            this.baseModel = baseModel;
            className = this.GetType().Name;
            className = className.Substring(0, className.Length - 6) + "Model";
            tableName = className.Substring(0, className.Length - 5);
        }

        //**************************************************************************	
        public virtual BaseModel GetObjectByID(Int64 value)
        {
            //for speed
            return FindModel(string.Format("exec spGet{0}_ByID {1}", tableName, value));
        }

        public virtual BaseModel FindByPK(Int64 value)
        {
            //for speed
            return FindModel(string.Format("SELECT * FROM [{0}] with (nolock) WHERE ID = {2}", tableName, tableName, value));
        }

        public virtual BaseModel FindByCode(string value)
        {
            //for speed
            return FindModel(string.Format("SELECT * FROM [{0}] with (nolock) WHERE Code = '{1}'", tableName, value));
        }

        public virtual BaseModel FindByField(string field, string value)
        {
            //for speed
            return FindModel(string.Format("SELECT top 1 * FROM [{0}] with (nolock) WHERE {1} = '{2}'", tableName, field, value));
        }
        public virtual BaseModel FindByField(string field, long value)
        {
            //for speed
            return FindModel(string.Format("SELECT top 1 * FROM [{0}] with (nolock) WHERE {1} = {2}", tableName, field, value));
        }

        public virtual ArrayList FindByPK(ArrayList list) //list of PKs
        {
            return FindByPK(PropertyUtils.ToListWithComma(list));
        }

        public virtual ArrayList FindHierarchicallyByPK(int PK, string parentFieldName)
        {
            ArrayList arr = new ArrayList();
            arr.Add(FindByPK(PK));
            ArrayList chilrenArr = FindByAttr(parentFieldName, PK);
            if (chilrenArr.Count > 0)
            {
                foreach (BaseModel child in chilrenArr)
                {
                    int childPK = Convert.ToInt32(child.GetType().GetProperty("iD").GetValue(child, null));
                    arr.AddRange(FindHierarchicallyByPK(childPK, parentFieldName));
                }
            }
            return arr;
        }

        public virtual ArrayList FindByPK(string list) //string of PKs separated by comma
        {
            //for speed
            return ExecuteSQL(string.Format("SELECT * FROM {0} with (nolock) WHERE {1}iD IN ({2})", tableName, tableName, list));
        }

        public BaseModel FindByUK(string field, string value)
        {
            //for speed
            if (value.IndexOf('\'') >= 0)
            {
                value = value.Replace("'", "\''");
            }
            return FindModel(string.Format("SELECT * FROM {0} with (nolock) WHERE {1} = '{2}'", tableName, field, value));
        }

        public ArrayList FindAll()
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, null));
        }

        public ArrayList FindAllNoLimit()
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, null));
        }
        //
        public ArrayList FindByAttr(string field, string value)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, field, value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param> 
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByAttrWithOrder(string field, string value, string FieldOrder, string OrderBy)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, field, value) + " " + baseModel.GetOrderBy(FieldOrder, OrderBy));
        }
        //

        //
        public ArrayList FindByAttr(string field, long value)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, field, value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param> 
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByAttrWithOrder(string field, long value, string FieldOrder, string OrderBy)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, field, value) + " " + baseModel.GetOrderBy(FieldOrder, OrderBy));
        }
        //

        //
        public ArrayList FindByExpression(Expression exp)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, exp));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByExpressionWithOrder(Expression exp, string FieldOrder, string OrderBy)
        {
            return ExecuteSQL(DBUtils.SQLSelect(tableName, exp) + " " + baseModel.GetOrderBy(FieldOrder, OrderBy));
        }
        //


        public Hashtable LazyLoad()
        {
            return LazyLoad(tableName + "Name");
        }

        public Hashtable LazyLoad(string name)
        {
            string Field_ID = "iD";

            string sql = string.Format("SELECT {0} AS f1, {1} AS f2 FROM {2} with (nolock) ", Field_ID, name, tableName);
            return LazyLoadToHashtable(sql);
        }

        //the sql must have only 2 fields [f1] [f2] in SELECT
        protected Hashtable LazyLoadToHashtable(string sql)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            //DateTime time = DateTime.Now;
            //log.Debug(sql);
            //log.Debug("Start query at " + time);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Hashtable result = new Hashtable();
                while (reader.Read())
                {
                    if (!result.Contains(reader["f1"]))
                        result.Add(reader["f1"], reader["f2"]);
                }
                //log.Debug("finish query at " + time + ", duration(s) = " + (DateTime.Now - time));
                return result;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        protected BaseModel FindModel(string sql)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            //log.Debug(sql);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = sql;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                    return PropertyUtils.PopulateModel(reader, className);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public virtual Decimal Insert(BaseModel baseModel)
        {
            #region Get systemDate
            DateTime sysTime = (DateTime)this.ExecuteScalar("EXEC spGetDateSystem");// (DateTime)((DataTable)LoadDataFromSP("spGetDateSystem", "spGetDateSystem", null, null)).Rows[0][0];
            #endregion

            #region Khai bao bien connection

            string TableName = baseModel.GetType().Name.Substring(0, baseModel.GetType().Name.Length - 5);
            object value;
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string sql = DBUtils.SQLInsert(baseModel);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            #endregion

            #region Gan gia tri cho command goc

            PropertyInfo[] propertiesName = baseModel.GetType().GetProperties();
            for (int i = 0; i < propertiesName.Length; i++)
            {
                value = propertiesName[i].GetValue(baseModel, null);

                if (!TableName.Equals("Tree_Members") && !TableName.Equals("PaymentTrans"))
                {
                    if (!propertiesName[i].Name.Equals("ID") && !propertiesName[i].Name.Equals("iD"))
                    {
                        if (propertiesName[i].Name.ToLower().Equals("createdby") || propertiesName[i].Name.ToLower().Equals("updatedby"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.NVarChar).Value = !String.IsNullOrEmpty(Global.AppUserName) ? Global.AppUserName : (value ?? "");
                        }
                        else if (propertiesName[i].Name.ToLower().Equals("createddate") || propertiesName[i].Name.ToLower().Equals("updateddate") || propertiesName[i].Name.ToLower().Equals("createdate") || propertiesName[i].Name.ToLower().Equals("updatedate"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.DateTime).Value = sysTime;
                        }
                        else if (propertiesName[i].Name.ToLower().Equals("userinsertid") || propertiesName[i].Name.ToLower().Equals("userupdateid"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Int).Value = Global.UserID != 0 ? Global.UserID : (value ?? 0);
                        }
                        else if (value != null)
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                            {
                                if ((DateTime)value == DateTime.MinValue)
                                    value = DefValues.Sql_MinDate;
                            }
                            if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, DBUtils.ConvertToSQLType(propertiesName[i].PropertyType)).Value = value;
                            }
                        }
                        else
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime?)))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, DBUtils.ConvertToSQLType(propertiesName[i].PropertyType)).Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, DBUtils.ConvertToSQLType(propertiesName[i].PropertyType)).Value = "";
                            }
                            
                        }
                    }
                }
                else
                {
                    if (value != null)
                    {
                        if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, DBUtils.ConvertToSQLType(propertiesName[i].PropertyType)).Value = value;
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, DBUtils.ConvertToSQLType(propertiesName[i].PropertyType)).Value = "";
                    }
                }
                
            }

            #endregion

            try
            {
                conn.Open();
                decimal id = (decimal)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
              //  cmd.ExecuteNonQuery();
                return id;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected virtual int UpdateField(ArrayList list, string field, int value)
        {
            if (list == null || list.Count == 0) return 0;
            string sql = string.Format("UPDATE {0} SET {1} = {2} WHERE {0}iD IN ({3})", tableName, field, value, PropertyUtils.ToListWithComma(list));
            return ExecuteNonQuerySQL(sql);
        }

        public virtual int Update(BaseModel baseModel, string field)
        {
            #region Khai bao bien connection

            string TableName = baseModel.GetType().Name.Substring(0, baseModel.GetType().Name.Length - 5);
            object value;
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string sql = DBUtils.SQLUpdate(baseModel, field);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = 6000;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            #endregion

            #region Gan gia tri cho command Goc
            PropertyInfo[] propertiesName = baseModel.GetType().GetProperties();
            for (int i = 0; i < propertiesName.Length; i++)
            {
                SqlDbType dbType = DBUtils.ConvertToSQLType(propertiesName[i].PropertyType);
                value = propertiesName[i].GetValue(baseModel, null);

                if (value != null)
                {
                    if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                    {
                        if ((DateTime)value == DateTime.MinValue)
                            value = DefValues.Sql_MinDate;
                    }
                    if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = value;
                    }
                }
                else
                    cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = "";
            }
            #endregion

            //#region Khai bao Log
            //if (!TableName.Equals("History"))
            //{
            //    mEL = new EventsLogModel();
            //    mEL.ObjectID = Convert.ToInt32(propertiesName[0].GetValue(baseModel, null));
            //    mEL.Action = "Update";
            //    mEL.TableName = TableName;
            //    mEL.UserID = Global.UserID;
            //}
            //#endregion

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                //#region Gan gia tri cho EventsLog

                //if (!TableName.Equals("History"))
                //{
                //    PropertyInfo[] propertiesName1 = mEL.GetType().GetProperties();
                //    sql = DBUtils.SQLInsert(mEL);

                //    for (int i = 0; i < propertiesName1.Length; i++)
                //    {
                //        value = propertiesName1[i].GetValue(mEL, null);

                //        if (!propertiesName1[i].Name.Equals("iD"))
                //        {
                //            if (value != null)
                //            {
                //                cmd.Parameters.Add("@" + propertiesName1[i].Name, DBUtils.ConvertToSQLType(propertiesName1[i].PropertyType)).Value = value;
                //            }
                //            else
                //            {
                //                cmd.Parameters.Add("@" + propertiesName1[i].Name, DBUtils.ConvertToSQLType(propertiesName1[i].PropertyType)).Value = "";
                //            }
                //        }
                //    }
                //}
                //#endregion

            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public virtual int Update(BaseModel baseModel)
        {
            #region Get systemDate
            DateTime sysTime = (DateTime)this.ExecuteScalar("EXEC spGetDateSystem"); //(DateTime)((DataTable)LoadDataFromSP("spGetDateSystem", "spGetDateSystem", null, null)).Rows[0][0];
            #endregion

            #region Khai bao bien connection

            string TableName = baseModel.GetType().Name.Substring(0, baseModel.GetType().Name.Length - 5);
            object value;
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string sql = DBUtils.SQLUpdate(baseModel);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            #endregion

            #region Gan gia tri cho command Goc
            PropertyInfo[] propertiesName = baseModel.GetType().GetProperties();
            for (int i = 0; i < propertiesName.Length; i++)
            {
                object[] arrAtt = propertiesName[i].GetCustomAttributes(true);
                if (arrAtt.Length > 0)
                {
                    continue;
                }
                SqlDbType dbType = DBUtils.ConvertToSQLType(propertiesName[i].PropertyType);
                value = propertiesName[i].GetValue(baseModel, null);

                if (propertiesName[i].Name.ToLower().Equals("updatedby"))
                {
                    cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.NVarChar).Value = !String.IsNullOrEmpty(Global.AppUserName) ? Global.AppUserName : (value ?? "");
                }
                else if (propertiesName[i].Name.ToLower().Equals("updateddate") || propertiesName[i].Name.ToLower().Equals("updatedate"))
                {
                    cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.DateTime).Value = sysTime;
                }
                else if (propertiesName[i].Name.ToLower().Equals("userupdateid"))
                {
                    cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Int).Value = Global.UserID != 0 ? Global.UserID : (value ?? 0);
                }
                else if (value != null)
                {
                    if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                    {
                        if ((DateTime)value == DateTime.MinValue)
                            value = DefValues.Sql_MinDate;
                    }
                    if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = value;
                    }
                }
                else
                {
                    if (propertiesName[i].PropertyType.Equals(typeof(DateTime?)))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = DBNull.Value;
                    }
                    else
                        cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = "";
                }
            }
            #endregion

            try
            {
                conn.Open();
                int rs = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rs;
                //cmd.CommandText = sql;
                //return cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw new FacadeException(se.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected int ExecuteNonQuerySQL(string sql)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw new FacadeException(se);
            }
            finally
            {
                conn.Close();
            }
        }

        protected int ExecuteNonQuerySQL(string sql, EventsLogModel mE)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                #region Gan gia tri cho EventsLog
                PropertyInfo[] propertiesName1 = mE.GetType().GetProperties();
                sql = DBUtils.SQLInsert(mE);
                object value;
                for (int i = 0; i < propertiesName1.Length; i++)
                {
                    value = propertiesName1[i].GetValue(mE, null);

                    if (!propertiesName1[i].Name.Equals("iD"))
                    {
                        if (value != null)
                        {
                            cmd.Parameters.Add("@" + propertiesName1[i].Name, DBUtils.ConvertToSQLType(propertiesName1[i].PropertyType)).Value = value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@" + propertiesName1[i].Name, DBUtils.ConvertToSQLType(propertiesName1[i].PropertyType)).Value = "";
                        }
                    }
                }
                #endregion

                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw new FacadeException(se);
            }
            finally
            {
                conn.Close();
            }
        }

        public virtual void Delete(Int64 IDValue)
        {
            string sql = DBUtils.SQLDelete(tableName, IDValue);
            try
            {
                //mEL = new EventsLogModel();
                //mEL.Action = "Delete";
                //mEL.ObjectID = Convert.ToInt32(IDValue);
                //mEL.TableName = tableName;
                //mEL.UserID = Global.UserID;
                ExecuteNonQuerySQL(sql);//, mEL);
            }
            catch
            {
                throw new FacadeException("Can not delete item");
            }
        }

        public virtual void DeleteByExpression(Expression exp)
        {
            string sql = DBUtils.SQLDelete(tableName, exp);
            ExecuteNonQuerySQL(sql);
        }

        public virtual void Delete(ArrayList listID)
        {
            string sql = "DELETE FROM " + tableName + " WHERE iD IN (" + PropertyUtils.ToListWithComma(listID) + ")";
            ExecuteNonQuerySQL(sql);
        }

        public void DeleteByAttribute(string name, string value)
        {
            string sql = DBUtils.SQLDelete(tableName, name, value);
            ExecuteNonQuerySQL(sql);
        }

        public void DeleteByAttribute(string name, Int64 value)
        {
            string sql = DBUtils.SQLDelete(tableName, name, value);
            ExecuteNonQuerySQL(sql);
        }

        public void DeleteByExpression(string tableName, Expression exp)
        {
            string sql = DBUtils.SQLDelete(tableName, exp);
            ExecuteNonQuerySQL(sql);
        }

        public object FindByMax(string field, string field1, string value)
        {
            return ExecuteScalar(DBUtils.SQLSelectMax(tableName, field, field1, value));
        }

        public object FindByMaxRoot(string field)
        {
            return ExecuteScalar(DBUtils.SQLSelectMaxRoot(tableName, field));
        }

        public object FindByMinRoot(string field)
        {
            return ExecuteScalar(DBUtils.SQLSelectMinRoot(tableName, field));
        }

        protected ArrayList ExecuteSQL(string sql)
        {
            SqlConnection conn = new SqlConnection(DBUtils.GetDBConnectionString());
            //DateTime time = DateTime.Now;
            //log.Debug(sql);
            //log.Debug("Start query at " + time);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                ArrayList result = new ArrayList();
                while (reader.Read())
                {
                    result.Add(PropertyUtils.PopulateModel(reader, className));
                }
                //log.Debug("finish query at " + time + ", duration(s) = " + (DateTime.Now - time));
                return result;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public virtual ArrayList GetListObject(string procedureName, string[] paramName, object[] paramValue)
        {
            SqlConnection conn = new SqlConnection(DBUtils.GetDBConnectionString());

            SqlCommand mySqlCommand = new SqlCommand(procedureName, conn);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam;
            if (paramName != null)
            {
                for (int i = 0; i < paramName.Length; i++)
                {
                    sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                    mySqlCommand.Parameters.Add(sqlParam);
                }
            }
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                ArrayList result = new ArrayList();
                while (reader.Read())
                {
                    result.Add(PropertyUtils.PopulateModel(reader, className));
                }
                
                return result;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        protected ArrayList ExecuteSQLNotFW(string sql)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            DateTime time = DateTime.Now;
            //log.Debug(sql);
            //log.Debug("Start query at " + time);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                ArrayList result = new ArrayList();
                while (reader.Read())
                {
                    result.Add(reader["column_name"]);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void AssignNN(string table1, string table2, int id, ArrayList list)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string sqlDelete = DBUtils.SQLDelete((table1 + table2), table1 + "iD", id);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlDelete;
            cmd.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new FacadeException(ex);
            }
            string sqlInsert = "insert into " + (table1 + table2) + " (" + table1 + "iD," + table2 + "iD) ";
            IEnumerator ie = list.GetEnumerator();
            while (ie.MoveNext())
            {
                cmd.CommandText = sqlInsert + " VALUES(" + id + ", " + ie.Current + ")";
                cmd.CommandType = CommandType.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw new FacadeException(ex);
                }
            }
            conn.Close();
        }

        public string DataTableName
        {
            get
            {
                string className = this.GetType().Name;
                return className.Substring(0, className.Length - 6);
            }

        }
        public bool CheckExist(string field, string value)
        {
            string sql = string.Format("SELECT top 1 {0} FROM {1} WITH (NOLOCK) WHERE {0} = '{2}'", field, tableName, value);
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            //log.Debug(sql);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckExist(string field, Int64 value)
        {
            string sql = string.Format("SELECT TOP 1 {0} FROM {1} WITH (NOLOCK) WHERE {0} = {2}", field, tableName, value);
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            //log.Debug(sql);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public object SelectTOP(string field, string order)
        {
            string sql = string.Format("SELECT TOP 1 {0} AS T FROM {1} with (nolock) ORDER BY {0} {2}", field, tableName, order);
            return ExecuteScalar(sql);
        }

        protected object ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            //log.Debug(sql);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new FacadeException(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //TUANLA defined
        public string GenerateNo(string code)
        {
            string sql = "SELECT TOP 1 " + code + " FROM " + tableName + " with (nolock) ORDER BY iD DESC";
            string lastBillNo = "";
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            ArrayList result = new ArrayList();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    lastBillNo = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (lastBillNo.Length == 0)
            {
                return "0001";
            }
            else
            {
                string digitPart = "", stringPart = lastBillNo, newDigitPart;
                int i = lastBillNo.Length - 1;
                while (i >= 0)
                {
                    try
                    {
                        Convert.ToInt32(lastBillNo.Substring(i, 1));
                        digitPart = lastBillNo.Substring(i, 1) + digitPart;
                        i--;
                    }
                    catch
                    {
                        break;
                    }
                }
                if (digitPart.Length > 0)
                {
                    stringPart = lastBillNo.Substring(0, i + 1);
                    newDigitPart = Convert.ToString(Convert.ToInt32(digitPart) + 1);
                    switch (newDigitPart.Length)
                    {
                        case 1:
                            newDigitPart = "000" + newDigitPart;
                            break;
                        case 2:
                            newDigitPart = "00" + newDigitPart;
                            break;
                        case 3:
                            newDigitPart = "0" + newDigitPart;
                            break;
                    }
                    return stringPart + newDigitPart;
                }
                else
                {
                    return lastBillNo + "0001";
                }

            }

        }

        public string GenerateNo1(string code, int ClassID)
        {
            string sql = "SELECT TOP 1 " + code + " FROM " + tableName + " with (nolock)  WHERE   ClassID = " + ClassID + " And Right(" + code + ",2)!='GV' ORDER BY " + tableName + "iD DESC";
            string lastBillNo = "";
            string lastBillNo1 = "";
            string sql1 = "";

            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            ArrayList result = new ArrayList();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    lastBillNo = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.Close();
            }


            //			sql1 = "Select * from VoucherClass Where VoucherClassID = " + ClassID;
            //
            //			SqlConnection conn1 = new SqlConnection(Global.ConnectionString);
            //			SqlCommand cmd1 = conn1.CreateCommand();
            //			cmd1.CommandText = sql1;
            //			cmd1.CommandType = CommandType.Text;
            //			SqlDataReader reader1 = null;
            //			try
            //			{
            //				conn1.Open();
            //				reader1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);
            //				if(reader1.Read())
            //				{
            //					lastBillNo1 = reader1["VoucherClassCode"].ToString();
            //				}
            //			}
            //			catch (Exception ex)
            //			{
            //				throw ex;
            //			}
            //			conn1.Close();


            if (lastBillNo.Length == 0)
            {
                return lastBillNo1 + "0001";
            }
            else
            {
                string digitPart = "", stringPart = lastBillNo, newDigitPart;
                int i = lastBillNo.Length - 1;
                while (i >= 0)
                {
                    try
                    {
                        Convert.ToInt32(lastBillNo.Substring(i, 1));
                        digitPart = lastBillNo.Substring(i, 1) + digitPart;
                        i--;
                    }
                    catch
                    {
                        break;
                    }
                }
                if (digitPart.Length > 0)
                {
                    stringPart = lastBillNo.Substring(0, i + 1);
                    newDigitPart = Convert.ToString(Convert.ToInt32(digitPart) + 1);
                    switch (newDigitPart.Length)
                    {
                        case 1:
                            newDigitPart = "000" + newDigitPart;
                            break;
                        case 2:
                            newDigitPart = "00" + newDigitPart;
                            break;
                        case 3:
                            newDigitPart = "0" + newDigitPart;
                            break;
                    }
                    return stringPart + newDigitPart;
                }
                else
                {
                    return lastBillNo + "0001";
                }

            }

        }

        public string GenerateNo2(string code, int ClassID)
        {
            string sql = "SELECT TOP 1 " + code + " FROM " + tableName + " with (nolock)  WHERE  parentID = " + ClassID + " ORDER BY iD DESC";
            string lastBillNo = "";
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            ArrayList result = new ArrayList();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    lastBillNo = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (lastBillNo.Length == 0)
            {
                return "0001";
            }
            else
            {
                string digitPart = "", stringPart = lastBillNo, newDigitPart;
                int i = lastBillNo.Length - 1;
                while (i >= 0)
                {
                    try
                    {
                        Convert.ToInt32(lastBillNo.Substring(i, 1));
                        digitPart = lastBillNo.Substring(i, 1) + digitPart;
                        i--;
                    }
                    catch
                    {
                        break;
                    }
                }
                if (digitPart.Length > 0)
                {
                    stringPart = lastBillNo.Substring(0, i + 1);
                    newDigitPart = Convert.ToString(Convert.ToInt32(digitPart) + 1);
                    switch (newDigitPart.Length)
                    {
                        case 1:
                            newDigitPart = "000" + newDigitPart;
                            break;
                        case 2:
                            newDigitPart = "00" + newDigitPart;
                            break;
                        case 3:
                            newDigitPart = "0" + newDigitPart;
                            break;
                    }
                    return stringPart + newDigitPart;
                }
                else
                {
                    return lastBillNo + "0001";
                }

            }

        }

        public virtual DataTable LoadDataFromSP(string procedureName, string nameSetToTable, string[] paramName, object[] paramValue)
        {
            DataTable table = new DataTable();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                
                DataSet myDataSet = new DataSet();
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.Fill(myDataSet, nameSetToTable);

                table = myDataSet.Tables[nameSetToTable];
            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return table;
        }

        public virtual DataSet GetDataSet(string procedureName, string[] paramName, object[] paramValue)
        {
            DataSet myDataSet = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.Fill(myDataSet);
            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataSet;
        }

        public virtual DataTable LoadDataFromSPNotTimeOut(string procedureName, string nameSetToTable, string[] paramName, object[] paramValue)
        {
            DataTable table = new DataTable();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString());
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandTimeout = 0;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);

                DataSet myDataSet = new DataSet();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                //mySqlCommand.ExecuteNonQuery();

                mySqlDataAdapter.Fill(myDataSet, nameSetToTable);

                table = myDataSet.Tables[nameSetToTable];
            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return table;
        }
        
        /// <summary>
        /// Lấy giá trị lớn nhất của Code
        /// -- datdp, 04/01/2010
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GenerateNo3(string code)
        {
            string sql = "SELECT TOP 1 MAX(Convert(int," + code + ")) FROM " + tableName + " WITH (NOLOCK) ";
            string lastBillNo = "";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            ArrayList result = new ArrayList();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    lastBillNo = reader[0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (lastBillNo.Length == 0)
            {
                return "00001";
            }
            else
            {
                string digitPart = "", stringPart = lastBillNo, newDigitPart;
                int i = lastBillNo.Length - 1;
                while (i >= 0)
                {
                    try
                    {
                        Convert.ToInt32(lastBillNo.Substring(i, 1));
                        digitPart = lastBillNo.Substring(i, 1) + digitPart;
                        i--;
                    }
                    catch
                    {
                        break;
                    }
                }
                if (digitPart.Length > 0)
                {
                    stringPart = lastBillNo.Substring(0, i + 1);
                    newDigitPart = Convert.ToString(Convert.ToInt32(digitPart) + 1);
                    switch (newDigitPart.Length)
                    {
                        case 1:
                            newDigitPart = "0000" + newDigitPart;
                            break;
                        case 2:
                            newDigitPart = "000" + newDigitPart;
                            break;
                        case 3:
                            newDigitPart = "00" + newDigitPart;
                            break;
                        case 4:
                            newDigitPart = "0" + newDigitPart;
                            break;
                    }
                    return stringPart + newDigitPart;
                }
                else
                {
                    return lastBillNo + "00001";
                }

            }
        }
    }
}