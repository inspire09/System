using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Teacher_TInfo : System.Web.UI.Page
{
    private static string tno = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userID"] = "2001";
        if (IsPostBack == false)
        {
            //从Session对象中获取用户登录名，以验证用户登录状态
            if (Session["userID"] == null)
                Response.Redirect("../Default.aspx");
            else
                tno = Session["userID"].ToString();
        }
    }

    [WebMethod]
    public static string teacher_info()
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        tea_Manage teaManage = new tea_Manage();
        return jss.Serialize(teaManage.tea_Info(tno));
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string teacher_edit(string tname, string sex, string room, string tel, string email, string title,
        string education, string course, string research, string article, string demand, string institute)
    {
        teacher tea = new teacher();
        tea.tno = tno;
        tea.tname = tname;
        tea.sex = sex;
        tea.room = room;
        tea.tel = tel;
        tea.email = email;
        tea.title = title;
        tea.education = education;
        tea.course = course;
        tea.research = research;
        tea.article = article;
        tea.demand = demand;
        tea.institute = institute;
        tea_Manage teaManage = new tea_Manage();
        return string.Format(teaManage.tea_Update(tea));

    }


}
