using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Teacher_myTutor : System.Web.UI.Page
{
    public static string tno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            tno = "2001";
    }

    [WebMethod]
    public static string mytutor()
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        tutor_Manage tutorManage = new tutor_Manage();

        return jss.Serialize(tutorManage.myTutor(tno));
    }

}
