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
        myConn.Close();
        return drow;
    }

    public List<teacher> tea_Select(string institute)
    {
        List<teacher> teaList = new List<teacher>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "select * from teacherInfo";
        myStr = myStr + " where institute like '%" + institute + "%'";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        
        SqlDataReader reader = myCmd.ExecuteReader();
        while (reader.Read())
        {
            teacher tea = new teacher();
            //tea.tno = tno;
            tea.tname = reader["tname"].ToString();
            tea.sex = reader["sex"].ToString();
            tea.room = reader["room"].ToString();
            tea.photo = reader["photo"].ToString();
            tea.tel = reader["tel"].ToString();
            tea.email = reader["email"].ToString();
            tea.title = reader["title"].ToString();
            tea.education = reader["education"].ToString();
            tea.course = reader["course"].ToString();
            tea.research = reader["research"].ToString();
            tea.article = reader["article"].ToString();
            tea.demand = reader["demand"].ToString();
            teaList.Add(tea);
        }
        myConn.Close();
        return teaList;
    }


}
