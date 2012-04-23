using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///vol_Manage 的摘要说明
/// </summary>
public class vol_Manage
{
	public vol_Manage()
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

    public Dictionary<string, string> vol_Select(string sno, string priority)
    {
        Dictionary<string, string> drow = new Dictionary<string, string>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "select tno from volunteer where sno=@sno and priority=@priority";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@priority", priority);
        SqlDataReader reader = myCmd.ExecuteReader();

        if (reader.Read())
        {
            tea_Manage teaManage = new tea_Manage();
            drow = teaManage.tea_Info(reader["tno"].ToString());
            drow.Add("msg", "yes");
        }
        else
            drow.Add("msg", "no");
        myConn.Close();
        return drow;
    }

    public string vol_Insert(string sno, string tno, string priority)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "insert into volunteer values(@sno,@tno,@priority)";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@tno", tno);
        myCmd.Parameters.AddWithValue("@priority", priority);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "志愿填选成功";
        else
            return "志愿填选失败";
    }

    public string vol_Update(string sno, string tno, string priority)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "update volunteer set tno=@tno where sno=@sno and priority=@priority";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@tno", tno);
        myCmd.Parameters.AddWithValue("@priority", priority);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "志愿填选成功";
        else
            return "志愿填选失败";
    }

}
