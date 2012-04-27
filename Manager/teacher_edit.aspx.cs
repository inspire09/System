using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Manager_teacher_edit : System.Web.UI.Page
{
    private static string tno = "";
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
            tno = Request.QueryString["tno"].ToString();
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

    [WebMethod]
    public static string teacher_del()
    {
        tea_Manage teaManage = new tea_Manage();
        return string.Format(teaManage.tea_Delete(tno));
    }


}
