﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///SqlClass 的摘要说明
/// </summary>
public class SqlClass
{

	public SqlClass()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public SqlConnection GetConnection()
    {
        string myStr = ConfigurationManager.ConnectionStrings["ChoiceSystem"].ConnectionString;
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }

    public int Login(string userID,string userPass,string privilege)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("userLogin", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.Add("@userID", SqlDbType.Char, 20).Value = userID;
        myCmd.Parameters.Add("@userPass", SqlDbType.Char, 20).Value = userPass;
        myCmd.Parameters.Add("@privilege", SqlDbType.Char, 20).Value = privilege;
        int result = (int)myCmd.ExecuteScalar();
        myConn.Close();
        return result;        
    }
}
