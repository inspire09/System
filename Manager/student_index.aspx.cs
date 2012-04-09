using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Web.Services;
using System.Collections.Generic; // Dictionary<,> 键值对集合所需
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Manager_student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static string student_insert(string sno, string sname)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        stu_Manage stuManage = new stu_Manage();
        student stu = stuManage.stu_Insert(sno, sname);
        drow.Add("sno", stu.Sno);
        drow.Add("sname", stu.Sname);

        return jss.Serialize(drow);
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }
}
