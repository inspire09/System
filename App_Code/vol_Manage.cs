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

    public string vol_Delete(string sno, string priority)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "delete from volunteer where sno=@sno and priority=@priority";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@priority", priority);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }


    private string status(string sno, string num)
    {
        string str="";
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "select * from status where sno=@sno";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        SqlDataReader reader = myCmd.ExecuteReader();
        if (reader.Read())
        {
            string submit = reader["submit_" + num].ToString();
            string result = reader["result_" + num].ToString();
            string ending = reader["ending_" + num].ToString();
            if (submit.Trim() == "已提交")
                str = str + "<span class='label label-warning'>已提交</span>&nbsp;";
            if (result.Trim() == "已通过")
                str = str + "<span class='label label-success'>已通过</span>&nbsp;";
            if (result == "未通过")
                str = str + "<span class='label label-important'>未通过</span>&nbsp;";
            if (ending.Trim() == "已结束")
                str = str + "<span class='label'>已结束</span>";
        }
        reader.Close();
        myConn.Close();
        return str;
    }

    public List<Dictionary<string, string>> myVol(string sno)
    {
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "select * from volunteer,teacherInfo where volunteer.sno=@sno and volunteer.tno=teacherInfo.tno";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        SqlDataReader reader = myCmd.ExecuteReader();
        //int num = 0;
        while (reader.Read())
        {
            Dictionary<string, string> drow = new Dictionary<string, string>();
            drow.Add("tno", reader["tno"].ToString());
            drow.Add("tname", reader["tname"].ToString());
            drow.Add("sex", reader["sex"].ToString());
            drow.Add("room", reader["room"].ToString());
            drow.Add("photo", reader["photo"].ToString());
            drow.Add("tel", reader["tel"].ToString());
            drow.Add("email", reader["email"].ToString());
            drow.Add("title", reader["title"].ToString());
            drow.Add("education", reader["education"].ToString());
            drow.Add("course", reader["course"].ToString());
            drow.Add("research", reader["research"].ToString());
            drow.Add("article", reader["article"].ToString());
            drow.Add("demand", reader["demand"].ToString());
            drow.Add("institute", reader["institute"].ToString());
            drow.Add("priority", reader["priority"].ToString());
            drow.Add("status", status(sno, reader["priority"].ToString()));
            
            drowList.Add(drow);
            //num++;
        }
        reader.Close();
        myConn.Close();
        return drowList;
    }

}
