using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Manager_teacher_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string teacher_insert(string tno, string tname)
    {
        tea_Manage teaManage = new tea_Manage();
        return string.Format(teaManage.tea_Insert(tno, tname));
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string teacher_select(string selectName, string selectValue)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        tea_Manage teaManage = new tea_Manage();
        return jss.Serialize(teaManage.tea_select(selectName.Trim(), selectValue.Trim()));
    }

}
