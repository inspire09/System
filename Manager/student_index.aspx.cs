using System;
using System.Collections.Generic;// Dictionary<,> 键值对集合所需
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需


public partial class Manager_student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static string student_insert(string sno, string sname)
    {
        stu_Manage stuManage = new stu_Manage();
        return string.Format(stuManage.stu_Insert(sno, sname));
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string student_select(string selectName, string selectValue)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        stu_Manage stuManage = new stu_Manage();
        return jss.Serialize(stuManage.stu_select(selectName.Trim(), selectValue.Trim()));
    }

}
