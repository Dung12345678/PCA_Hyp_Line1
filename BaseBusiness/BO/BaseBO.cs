using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using BMS.Exceptions;
using BMS.Facade;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
namespace BMS.Business
{
    /// <summary>
    ///    <NameSpace>
    ///       BMS.Business
    ///    </Namespace>
    ///    <ClassName>
    ///       BaseBO
    ///    </ClassName>
    ///    <Description>
    ///       All Business classes inherit from BaseBO class
    ///    </Description>
    ///    <Authors>
    //CSSOLUTION
    ///    </Authors>
    ///    <History>
    ///       2006
    ///    </History>
    /// </summary>
    public class BaseBO
    {
        public BaseFacade baseFacade = null;

        public BaseBO()
        {
        }
        /// <Function>
        ///    <MethodName>
        ///       Update
        ///    </MethodName>
        ///    <Description>
        ///       Update Model's information  to database
        ///    </Description>
        ///    <Inputs>
        ///       Model
        ///    </Inputs>
        ///    <Returns>
        ///    </Returns>
        /// </Function>
        public virtual Decimal Insert(BaseModel model)
        {
            try
            {
                return baseFacade.Insert(model);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not Insert to database" + ex.Message);
            }
        }
        public virtual void InsertTrans(BaseModel model, SqlConnection sqlConn, SqlTransaction sqlTran)
        {
            try
            {
                baseFacade.Insert(model);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not Insert to database" + ex.Message);
            }
        }

        /*public int UpdateField(int who, ArrayList list, string field, int value)
        {
            try
            {
                return baseFacade.UpdateField(list, field, value);
            }
            catch(Exception ex)
            {
                throw new BOException("Can not update to database" + ex.Message);
            }
        }*/
        public virtual void Update(BaseModel model, string field)
        {
            try
            {
                baseFacade.Update(model, field);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not update to database" + ex.Message);
            }
        }

        public virtual void Update(BaseModel model)
        {
            try
            {
                baseFacade.Update(model);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not update to database" + ex.Message);
            }
        }
        /// <Function>
        ///    <MethodName>
        ///       Delete
        ///    </MethodName>
        ///    <Description>
        ///       Remove Model's information  from database
        ///    </Description>
        ///    <Inputs>
        ///       Model's iD
        ///    </Inputs>
        ///    <Returns>
        ///    </Returns>
        /// </Function>
        public virtual void Delete(int IDValue)
        {
            try
            {
                baseFacade.Delete(IDValue);
            }
            catch (FacadeException ex)
            {
                
            }
        }

        public virtual void DeleteByExpression(Expression exp)
        {
            try
            {
                baseFacade.DeleteByExpression(exp);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not delete from database" + ex.Message);
            }
        }

        public virtual void Delete(Int64 IDValue)
        {
            try
            {
                baseFacade.Delete(IDValue);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not delete from database" + ex.Message);
            }
        }

        /// <Function>
        ///    <MethodName>
        ///       Delete
        ///    </MethodName>
        ///    <Description>
        ///       Remove list of Model's information  from database
        ///    </Description>
        ///    <Inputs>
        ///       List of Model's iD
        ///    </Inputs>
        ///    <Returns>
        ///    </Returns>
        /// </Function>
        public virtual void Delete(ArrayList list)
        {
            try
            {
                baseFacade.Delete(list);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not delete from database" + ex.Message);
            }
        }

        public BaseModel GetObjectByID(Int64 value)
        {
            try
            {
                return baseFacade.GetObjectByID(value);
            }
            catch (FacadeException fx)
            {
                return null;
            }
        }

        /// <Function>
        ///    <MethodName>
        ///       FindByPK
        ///    </MethodName>
        ///    <Description>
        ///       Find a Model by Primary Key
        ///    </Description>
        ///    <Inputs>
        ///       Value of Primary Key
        ///    </Inputs>
        ///    <Returns>
        ///		  Model
        ///    </Returns>
        /// </Function>
        public BaseModel FindByPK(Int64 value)
        {
            try
            {
                return baseFacade.FindByPK(value);
            }
            catch (FacadeException fx)
            {
                return null;
            }
        }
        public BaseModel FindByField(string field, string value)
        {
            try
            {
                return baseFacade.FindByField(field,  value);
            }
            catch (FacadeException fx)
            {
                return null;
            }
        }
        public BaseModel FindByField(string field, long value)
        {
            try
            {
                return baseFacade.FindByField(field, value);
            }
            catch (FacadeException fx)
            {
                return null;
            }
        }
        public BaseModel FindByCode(string value)
        {
            try
            {
                return baseFacade.FindByCode(value);
            }
            catch (FacadeException fx)
            {
                return null;
            }
        }
        public ArrayList FindByPK(ArrayList list) //list of PKs
        {
            try
            {
                return baseFacade.FindByPK(list);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not find user " + fx.Message);
            }
        }
        public ArrayList FindByPK(string list) //list of PKs separated with comma
        {
            try
            {
                return baseFacade.FindByPK(list);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not find user " + fx.Message);
            }
        }

        public ArrayList FindByExpression(Expression exp)
        {
            try
            {
                return baseFacade.FindByExpression(exp);
            }
            catch (FacadeException e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByExpressionWithOrder(Expression exp, string FieldOrder, string Order)
        {
            try
            {
                return baseFacade.FindByExpressionWithOrder(exp, FieldOrder, Order);
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the FindByExpressionWithOrder method: " + e.Message);
            }
        }

        public ArrayList FindByAttribute(string field, string value)
        {
            try
            {
                return baseFacade.FindByAttr(field, value);
            }
            catch (FacadeException e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByAttributeWithOrder(string field, string value, string FieldOrder, string Order)
        {
            try
            {
                return baseFacade.FindByAttrWithOrder(field, value, FieldOrder, Order);
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the FindByExpression method: " + e.Message);
            }
        }

        public ArrayList FindByAttribute(string field, int value)
        {
            try
            {
                return baseFacade.FindByAttr(field, value);
            }
            catch (FacadeException e)
            {
                return new ArrayList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldOrder">Tên cột cần Order</param>
        /// <param name="OrderBy">ASC or DESC</param>
        /// <returns>ArrayList</returns>
        public ArrayList FindByAttributeWithOrder(string field, int value, string FieldOrder, string Order)
        {
            try
            {
                return baseFacade.FindByAttrWithOrder(field, value, FieldOrder, Order);
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the FindByExpression method: " + e.Message);
            }
        }

        public string GetMax(string field, string field1, int value)
        {
            try
            {
                return baseFacade.FindByMax(field, field1, value.ToString()).ToString();
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the GetMax method: " + e.Message);
            }
        }
        public string GetMaxRoot(string field)
        {
            try
            {
                return baseFacade.FindByMaxRoot(field).ToString();
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the GetMax method: " + e.Message);
            }
        }
        public string GetMinRoot(string field)
        {
            try
            {
                return baseFacade.FindByMinRoot(field).ToString();
            }
            catch (FacadeException e)
            {
                throw new BOException("Can not execute the GetMax method: " + e.Message);
            }
        }
        /// <Function>
        /// 
        ///    <MethodName>
        ///       FindAll
        ///    </MethodName>
        ///    <Description>
        ///       Find All Model
        ///    </Description>
        ///    <Inputs>
        ///    </Inputs>
        ///    <Returns>
        ///		  List of Model
        ///    </Returns>
        /// </Function>
        public ArrayList FindAll()
        {
            try
            {
                return baseFacade.FindAll();
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not find" + fx.Message);
            }
        }
        public ArrayList FindByStatus(byte status, string op)
        {
            Expression exp = new Expression("Status", status, op);
            return FindByExpression(exp);
        }
        public virtual void DeleteByAttribute(string name, string value)
        {
            try
            {
                baseFacade.DeleteByAttribute(name, value);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not delete any entity with condition " + name + " = " + value + ": " + fx.Message);
            }
        }
        public virtual void DeleteByAttribute(string name, Int64 value)
        {
            try
            {
                baseFacade.DeleteByAttribute(name, value);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not delete any entity with condition " + name + " = " + value + ": " + fx.Message);
            }
        }
        public virtual void DeleteByExpression(string name, Expression exp)
        {
            try
            {
                baseFacade.DeleteByExpression(name, exp);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not delete any entity with condition /n"  + fx.Message);
            }
        }
        public Hashtable LazyLoad()
        {
            try
            {
                return baseFacade.LazyLoad();
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not find" + fx.Message);
            }
        }
        public Hashtable LazyLoad(string name)
        {
            try
            {
                return baseFacade.LazyLoad(name);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Can not find" + fx.Message);
            }
        }
        public bool CheckExist(string field, string value)
        {
            try
            {
                return baseFacade.CheckExist(field, value);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
        public bool CheckExist(string field, Int64 value)
        {
            try
            {
                return baseFacade.CheckExist(field, value);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
        public string GenerateNo(string code)
        {
            try
            {
                return baseFacade.GenerateNo(code);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
        public string GenerateNo1(string code, int ClassID)
        {
            try
            {
                return baseFacade.GenerateNo1(code, ClassID);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
        public string GenerateNo2(string code, int ClassID)
        {
            try
            {
                return baseFacade.GenerateNo2(code, ClassID);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
        public String Audit(BaseModel obj)
        {
            return baseFacade.Audit(obj);
        }

        public virtual DataTable LoadDataFromSP(string procedureName, string nameSetToTable, string[] paramName, object[] paramValue)
        {
            try
            {
                return baseFacade.LoadDataFromSP(procedureName, nameSetToTable, paramName, paramValue);
            }
            catch (FacadeException ex)
            {
                return new DataTable();
            }
        }

        public virtual DataSet GetDataSet(string procedureName, string[] paramName, object[] paramValue)
        {
            try
            {
                return baseFacade.GetDataSet(procedureName, paramName, paramValue);
            }
            catch (FacadeException ex)
            {
                return new DataSet();
            }
        }

        public virtual ArrayList GetListObject(string procedureName, string[] paramName, object[] paramValue)
        {
            try
            {
                return baseFacade.GetListObject(procedureName, paramName, paramValue);
            }
            catch (FacadeException ex)
            {
                return new ArrayList();
            }
        }

        public virtual DataTable LoadDataFromSPNotTimeOut(string procedureName, string nameSetToTable, string[] paramName, object[] paramValue)
        {
            try
            {
                return baseFacade.LoadDataFromSPNotTimeOut(procedureName, nameSetToTable, paramName, paramValue);
            }
            catch (FacadeException ex)
            {
                throw new BOException("Can not load data:" + ex.Message);
            }
        }

        public string GenerateNo3(string code)
        {
            try
            {
                return baseFacade.GenerateNo3(code);
            }
            catch (FacadeException fx)
            {
                throw new BOException("Cannot find" + fx.Message);
            }
        }
    }
}