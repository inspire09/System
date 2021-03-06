﻿using System;
using System.Collections.Generic;// Dictionary<,> 键值对集合所需
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Manager_student_edit : System.Web.UI.Page
{
    private static string sno="";
    public string showClass = "";
    public string editClass = "";
    public string delClass = "";
    public string showLi = "";
    public string editLi = "";
    public string delLi = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sno = Request.QueryString["sno"].ToString();
            string operat = Request.QueryString["operat"].ToString();
            
            if (operat == "show")
            {
                showClass = "tab-pane fade active in";
                editClass = "tab-pane fade";
                delClass = "tab-pane fade";
                showLi = "active";
                
            }
            else if (operat == "edit")
            {
                showClass = "tab-pane fade";
                editClass = "tab-pane fade active in";
                delClass = "tab-pane fade";
                editLi = "active";
            }
            else if (operat == "del")
            {
                showClass = "tab-pane fade";
                editClass = "tab-pane fade";
                delClass = "tab-pane fade active in";
                delLi = "active";
            }       
        }
    }

    [WebMethod]
    public static string student_info()
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        stu_Manage stuManage = new stu_Manage();
        return jss.Serialize(stuManage.stu_Info(sno));
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string student_edit(string sname,string sex,string institute,string major,
        string sclass,string tel,string email,string eng, string honour,string intro,string remark)
    {
        student stu = new student();
        stu.Sno = sno;
        stu.Sname = sname;
        stu.Sex = sex;
        stu.Institute = institute;
        stu.Major = major;
        stu.Sclass = sclass;
        stu.Tel = tel;
        stu.Email = email;
        stu.EnglishLevel = eng;
        stu.Honour = honour;
        stu.Intro = intro;
        stu.Remark = remark;
        stu_Manage stuManage = new stu_Manage();
        return string.Format(stuManage.stu_Update(stu));
        
    }

    [WebMethod]
    public static string student_del()
    {
        stu_Manage stuManage = new stu_Manage();
        return string.Format(stuManage.stu_Delete(sno));
    }
}
