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

    public student stu_Info(string sno)
    {
        student stu = new student();
        SqlConnection myConn = GetConnection();
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.AddWithValue("@sno", sno);
        SqlDataReader reader = myCmd.ExecuteReader();
        if (reader.Read())
        {
            stu.Sno = sno;
            stu.Sname = reader["sname"].ToString();
            stu.Sex = reader["sex"].ToString();
            stu.Institute = reader["institute"].ToString();
            stu.Major = reader["major"].ToString();
            stu.Sclass = reader["sclass"].ToString();
            stu.Tel = reader["tel"].ToString();
            stu.Email = reader["email"].ToString();
            stu.EnglishLevel = reader["englishLevel"].ToString();
            stu.Honour = reader["honour"].ToString();
            stu.Intro = reader["intro"].ToString();
            stu.Remark = reader["remark"].ToString();
        }   
        myConn.Close();
        return stu;
    }

    public student stu_Insert(string sno, string sname)
    {
        student stu = new student();
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

    public bool stu_Update(student stu)
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
        myCmd.Parameters.AddWithValue("@Honour", stu.Honour);
        myCmd.Parameters.AddWithValue("@Intro", stu.Intro);
        myCmd.Parameters.AddWithValue("@Remark", stu.Remark);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return true;
        else
            return false;
    }

    public bool stu_Delete(string sno)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        string myStr = "delete from studentInfo where sno=@sno";
        SqlCommand myCmd = new SqlCommand(myStr, myConn);
        myCmd.Parameters.AddWithValue("@sno", sno);
        int i = myCmd.ExecuteNonQuery();
        myConn.Close();
        if (i > 0)
            return true;
        else
            return false;
    }

    public List<student> stu_select(string selectName, string selectValue)
    {
        List<student> stuList = new List<student>();
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
            student stu = new student();
            stu.Sno = reader["sno"].ToString();
            stu.Sname = reader["sname"].ToString();
            stu.Sex = reader["sex"].ToString();
            stu.Institute = reader["institute"].ToString();
            stu.Major = reader["major"].ToString();
            stu.Sclass = reader["sclass"].ToString();
            stuList.Add(stu);
        }
        myConn.Close();
        return stuList;
    }

}
