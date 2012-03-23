using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

/// <summary>
///stu_Manage 的摘要说明
/// </summary>
public class stu_Manage
{
	public stu_Manage()
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

    public student stu_Insert(string sno, string sname)
    {
        student stu = new student();
        stu.Sno = sno;
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuInsert", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@sname", sname);
        if (myCmd.ExecuteNonQuery() > 0)
        {
            stu.Sno = sno;
            stu.Sname = sname;
        }   
        myConn.Close();
        return stu;
    }

}
