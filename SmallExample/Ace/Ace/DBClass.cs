using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Ace.App_Code
{ 
/// <summary>
/// DBClass ��ժҪ˵��
/// </summary>
public class DBClass
{
	public DBClass()
	{
		//
		// TODO: �ڴ˴���ӹ��캯���߼�
		//
	}
    /// <summary>
    /// �������ݿ�
    /// </summary>
    /// <returns>�������ݿ����Ӷ���</returns>
    public SqlConnection GetConnection()
    {
        //string myStr=ConfigurationManager.AppSettings["ConnectionString"].ToString();
        string myStr = "server=(local);database=db_Student;UId=sa2;password=ctesi1234";
        SqlConnection myConn=new SqlConnection(myStr);
        return myConn;
    }
    /// <summary>
    /// ִ��SQL��䣬������Ӱ���������������ӣ��޸ģ�ɾ����
    /// </summary>
    /// <param name="myCmd">ִ��SQL�����������</param>
    public void ExecNonQuery(SqlCommand myCmd)
    {
        try
        {
            if(myCmd.Connection.State!=ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            myCmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if(myCmd.Connection.State==ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    /// <summary>
    /// ִ�в�ѯ�������ز�ѯ�����صĽ�����е�һ�е�һ��
    /// </summary>
    /// <param name="myCmd">ִ��sql���������</param>
    /// <returns></returns>
    public string  ExecScalar(SqlCommand myCmd)
    {
        string strSql;
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            //ִ�в�ѯ�������ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����������л��У�����ֵΪobject����
            strSql = Convert.ToString(myCmd.ExecuteScalar());
            return strSql;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }
    /// <summary>
    /// �����ݿ��м������ݣ����������ݼ��ı���
    /// </summary>
    /// <param name="myCmd">sql����</param>
    /// <param name="TableName">���ص����ݱ�����</param>
    /// <returns></returns>
    public DataTable GetDataSet(SqlCommand myCmd,string TableName)
    {
        SqlDataAdapter adapt;
        DataSet ds = new DataSet();
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            adapt = new SqlDataAdapter(myCmd);
            adapt.Fill(ds, TableName);
            return ds.Tables[TableName];

        }
        catch( Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
           if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
        }
    /// <summary>
    /// ִ�д洢������䣬���� SqlCommand ����
    /// </summary>
    /// <param name="strProcName">�洢��������</param>
    /// <returns>����command</returns>
    public SqlCommand GetCommandProc(string strProcName)
    {
        SqlConnection myConn=GetConnection();
        SqlCommand myCmd=new SqlCommand();
        myCmd.Connection=myConn;
        myCmd.CommandText = strProcName;
        myCmd.CommandType = CommandType.StoredProcedure;
        return myCmd;
    }
    /// <summary>
    /// �����ַ����õ�sqlCommand �����
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public SqlCommand GetCommandStr(string strSql)
    {
        SqlConnection myConn = GetConnection();
        SqlCommand myCmd = new SqlCommand();
        myCmd.Connection = myConn;
        myCmd.CommandText = strSql;
        myCmd.CommandType = CommandType.Text;
        return myCmd;

    }

    public DataTable GetDataSetStr(string sqlStr,string TableName)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapt = new SqlDataAdapter(sqlStr, myConn);
        adapt.Fill(ds, TableName);
        myConn.Close();
        return ds.Tables[TableName];
    }


}
}