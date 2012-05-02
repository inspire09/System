using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///note_Manage 的摘要说明
/// </summary>
public class note_Manage
{
	public note_Manage()
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
    public string write(string sender, string receiver, string topic, string content,DateTime date)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "insert into note(sender,receiver,topic,content,date) values(@sender,@receiver,@topic,@content,@date)";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@sender", sender);
        myCmd.Parameters.AddWithValue("@receiver", receiver);
        myCmd.Parameters.AddWithValue("@topic", topic);
        myCmd.Parameters.AddWithValue("@content", content);
        myCmd.Parameters.AddWithValue("@date", date);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }
}
