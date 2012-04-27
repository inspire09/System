using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///tea_Manage 的摘要说明
/// </summary>
public class tea_Manage
{
	public tea_Manage()
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

    public Dictionary<string, string> tea_Info(string tno)
    {
        Dictionary<string, string> drow = new Dictionary<string, string>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "select * from teacherInfo where tno=@tno";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        SqlDataReader reader = myCmd.ExecuteReader();
        if (reader.Read())
        {
            drow.Add("tno", tno);
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
        }
        reader.Close();
        myConn.Close();
        return drow;
    }

    public string tea_Insert(string tno, string tname)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "insert into teacherInfo(tno,tname) values(@tno,@tname)";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        myCmd.Parameters.AddWithValue("@tname", tname);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }

    public string tea_Update(teacher tea)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "update teacherInfo set tname=@tname,sex=@sex,room=@room,tel=@tel,email=@email,title=@title,";
        sqlStr = sqlStr + "education=@education,course=@course,research=@research,article=@article,demand=@demand,";
        sqlStr = sqlStr + "institute=@institute where tno=@tno";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tea.tno);
        myCmd.Parameters.AddWithValue("@tname", tea.tname);
        myCmd.Parameters.AddWithValue("@sex", tea.sex); 
        myCmd.Parameters.AddWithValue("@room", tea.room);
        myCmd.Parameters.AddWithValue("@tel", tea.tel);
        myCmd.Parameters.AddWithValue("@email", tea.email);
        myCmd.Parameters.AddWithValue("@title", tea.title);
        myCmd.Parameters.AddWithValue("@education", tea.education);
        myCmd.Parameters.AddWithValue("@course", tea.course);
        myCmd.Parameters.AddWithValue("@research", tea.research);
        myCmd.Parameters.AddWithValue("@article", tea.article);
        myCmd.Parameters.AddWithValue("@demand", tea.demand);
        myCmd.Parameters.AddWithValue("@institute", tea.institute);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "修改信息成功";
        else
            return "修改信息失败";
    }

    public string tea_Delete(string tno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "delete from teacherInfo where tno=@tno";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "删除成功";
        else
            return "删除失败";
    }

    public List<Dictionary<string, string>> tea_select(string selectName, string selectValue)
    {
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "select tno,tname,sex,room,title,institute from teacherInfo";
        if (selectName == "员工号")
            myStr = myStr + " where tno like '%" + selectValue + "%'";
        else if (selectName == "姓名")
            myStr = myStr + " where tname like '%" + selectValue + "%'";
        else if (selectName == "教研室")
            myStr = myStr + " where room like '%" + selectValue + "%'";
        else if (selectName == "职称")
            myStr = myStr + " where title like '%" + selectValue + "%'";
        else if (selectName == "所在学院")
            myStr = myStr + " where institute like '%" + selectValue + "%'";       
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        SqlDataReader reader = myCmd.ExecuteReader();
        while (reader.Read())
        {
            Dictionary<string, string> drow = new Dictionary<string, string>();
            drow.Add("tno", reader["tno"].ToString());
            drow.Add("tname", reader["tname"].ToString());
            drow.Add("sex", reader["sex"].ToString());
            drow.Add("room", reader["room"].ToString());
            drow.Add("title", reader["title"].ToString());
            drow.Add("institute", reader["institute"].ToString());
            drowList.Add(drow);
        }
        reader.Close();
        myConn.Close();
        return drowList;
    }

}
