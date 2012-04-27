using System;
using System.Collections.Generic;// Dictionary<,> 键值对集合所需
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Student_SInfo : System.Web.UI.Page
{
    private static string sno = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userID"] = "1001";
        if (IsPostBack == false)
        {
            //从Session对象中获取用户登录名，以验证用户登录状态
            if (Session["userID"] == null)
                Response.Redirect("../Default.aspx");
            else
                sno = Session["userID"].ToString();
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
    public static string student_edit(string sname, string sex, string institute, string major,
        string sclass, string tel, string email, string eng, string honour, string intro, string remark)
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


}
