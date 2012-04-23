using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///tutor_Manage 的摘要说明
/// </summary>
public class tutor_Manage
{
	public tutor_Manage()
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

    public Dictionary<string, string> stu_Count(string tno)
    {
        Dictionary<string, string> drow = new Dictionary<string, string>();
        SqlConnection myConn = GetConnection();
        myConn.Open();

        string sqlStr = "select total from countTable,teacherInfo where tno=@tno and countTable.title=teacherInfo.title";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        SqlDataReader reader = myCmd.ExecuteReader();
        if (reader.Read())
            drow.Add("total", reader["total"].ToString());
        reader.Close();

        sqlStr = "select count(*) from tutor where tno=@tno";
        SqlCommand myCmd1 = new SqlCommand(sqlStr, myConn);
        myCmd1.Parameters.AddWithValue("@tno", tno);
        int count = (int)myCmd1.ExecuteScalar();
        drow.Add("count", count.ToString());

        myConn.Close();
        return drow;
    }

    private int disable(string sno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string str = "select count(*) from tutor where sno=@sno";
        SqlCommand cmd = new SqlCommand(str, myConn);
        cmd.Parameters.AddWithValue("@sno", sno);
        int result = (int)cmd.ExecuteScalar();
        myConn.Close();
        return result;
    }

    public List<Dictionary<string, string>> tutor_stuInfo(string selectName, string selectValue, string tno)
    {
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "select * from volunteer,studentInfo where volunteer.tno=@tno and volunteer.sno=studentInfo.sno";
        if (selectName == "学号")
            sqlStr = sqlStr + " and volunteer.sno like '%" + selectValue + "%'";
        else if (selectName == "姓名")
            sqlStr = sqlStr + " and volunteer.sname like '%" + selectValue + "%'";
        else if (selectName == "学院")
            sqlStr = sqlStr + " and volunteer.institute like '%" + selectValue + "%'";
        else if (selectName == "专业")
            sqlStr = sqlStr + " and volunteer.major like '%" + selectValue + "%'";
        else if (selectName == "班级")
            sqlStr = sqlStr + " and volunteer.sclass like '%" + selectValue + "%'";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        SqlDataReader reader = myCmd.ExecuteReader();
        while (reader.Read())
        {
            Dictionary<string, string> drow = new Dictionary<string, string>();
            string sno = reader["sno"].ToString();
            drow.Add("sno", sno);
            drow.Add("sname", reader["sname"].ToString());
            drow.Add("sex", reader["sex"].ToString());
            drow.Add("institute", reader["institute"].ToString());
            drow.Add("major", reader["major"].ToString());
            drow.Add("sclass", reader["sclass"].ToString());
            drow.Add("tel", reader["tel"].ToString());
            drow.Add("email", reader["email"].ToString());
            drow.Add("eng", reader["englishLevel"].ToString());
            drow.Add("honour", reader["honour"].ToString());
            drow.Add("intro", reader["intro"].ToString());
            drow.Add("remark", reader["remark"].ToString());

            if (disable(sno) > 0)
                drow.Add("disabled", " disabled");
            else
                drow.Add("disabled", "");
            
            drowList.Add(drow);
        }
        reader.Close();
        myConn.Close();
        return drowList;
    }

    public string tutor_Insert(string sno, string tno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "insert into tutor values(@sno,@tno)";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@tno", tno);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }

    public string tutor_Delete(string sno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "delete from tutor where sno=@sno";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }

    public List<Dictionary<string, string>> myTutor(string tno)
    {
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string sqlStr = "select * from tutor,studentInfo where tutor.tno=@tno and tutor.sno=studentInfo.sno";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@tno", tno);
        SqlDataReader reader = myCmd.ExecuteReader();
        while (reader.Read())
        {
            Dictionary<string, string> drow = new Dictionary<string, string>();
            drow.Add("sno", reader["sno"].ToString());
            drow.Add("sname", reader["sname"].ToString());
            drow.Add("sex", reader["sex"].ToString());
            drow.Add("institute", reader["institute"].ToString());
            drow.Add("major", reader["major"].ToString());
            drow.Add("sclass", reader["sclass"].ToString());
            drow.Add("tel", reader["tel"].ToString());
            drow.Add("email", reader["email"].ToString());
            drow.Add("eng", reader["englishLevel"].ToString());
            drow.Add("honour", reader["honour"].ToString());
            drow.Add("intro", reader["intro"].ToString());
            drow.Add("remark", reader["remark"].ToString());
            drowList.Add(drow);
        }
        myConn.Close();
        return drowList;
    }

}
