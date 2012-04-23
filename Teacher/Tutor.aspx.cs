using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Teacher_choose : System.Web.UI.Page
{
    public static string tno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            tno = "2001";
    }

    [WebMethod]
    public static string student_count()
    {
        tutor_Manage tutorManage = new tutor_Manage();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        return jss.Serialize(tutorManage.stu_Count(tno));
    }

    [WebMethod]
    public static string student_select(string selectName, string selectValue)
    {
       
        tutor_Manage tutorManage = new tutor_Manage();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        return jss.Serialize(tutorManage.tutor_stuInfo(selectName, selectValue, tno));
    }

    [WebMethod]
    public static string tutor_insert(string sno)
    {
        tutor_Manage tutorManage = new tutor_Manage();
        return string.Format(tutorManage.tutor_Insert(sno, tno)); 
    }

    [WebMethod]
    public static string tutor_delete(string sno)
    {
        tutor_Manage tutorManage = new tutor_Manage();
        return string.Format(tutorManage.tutor_Delete(sno)); 
    }

}
