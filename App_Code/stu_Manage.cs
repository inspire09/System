using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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

    public Dictionary<string, string> stu_Info(string sno)
    {
        Dictionary<string, string> drow = new Dictionary<string, string>(); 
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.AddWithValue("@sno", sno);
        SqlDataReader reader = myCmd.ExecuteReader();
        if (reader.Read())
        {
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
            
        }
        reader.Close();
        myConn.Close();
        return drow;
    }

    public string stu_Insert(string sno, string sname)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuInsert", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.AddWithValue("@sno", sno);
        myCmd.Parameters.AddWithValue("@sname", sname);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "yes";
        else
            return "no";
    }

    public string stu_Update(student stu)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuUpdate", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.AddWithValue("@sno", stu.Sno);
        myCmd.Parameters.AddWithValue("@sname", stu.Sname);
        myCmd.Parameters.AddWithValue("@sex", stu.Sex);
        myCmd.Parameters.AddWithValue("@institute", stu.Institute);
        myCmd.Parameters.AddWithValue("@major", stu.Major);
        myCmd.Parameters.AddWithValue("@sclass", stu.Sclass);
        myCmd.Parameters.AddWithValue("@tel", stu.Tel);
        myCmd.Parameters.AddWithValue("@email", stu.Email);
        myCmd.Parameters.AddWithValue("@englishLevel", stu.EnglishLevel);
        myCmd.Parameters.AddWithValue("@honour", stu.Honour);
        myCmd.Parameters.AddWithValue("@intro", stu.Intro);
        myCmd.Parameters.AddWithValue("@remark", stu.Remark);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return string.Format("{0} {1} 修改信息成功", stu.Sno.Trim(), stu.Sname.Trim());
        else
            return string.Format("{0} {1} 修改信息失败", stu.Sno.Trim(), stu.Sname.Trim());
    }

    public string stu_Delete(string sno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "delete from studentInfo where sno=@sno";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return "删除成功";
        else
            return "删除失败";
    }

    public List<Dictionary<string, string>> stu_select(string selectName, string selectValue)
    {
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "select sno,sname,sex,institute,major,sclass from studentInfo";
        if (selectName == "学号")
            myStr = myStr + " where sno like '%" + selectValue + "%'";
        else if (selectName == "姓名")
            myStr = myStr + " where sname like '%" + selectValue + "%'";
        else if (selectName == "学院")
            myStr = myStr + " where institute like '%" + selectValue + "%'";
        else if (selectName == "专业")
            myStr = myStr + " where major like '%" + selectValue + "%'";
        else if (selectName == "班级")
            myStr = myStr + " where sclass like '%" + selectValue + "%'";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
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
            drowList.Add(drow);
        }
        reader.Close();
        myConn.Close();
        return drowList;
    }

}
