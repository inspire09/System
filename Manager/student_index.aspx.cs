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

public partial class Manager_student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static string student_insert(string sno, string sname)
    {
        string str = "{sno:" + sno + ",sname:" + sname + "}";

        return string.Format("欢迎你{0} {1}", sno, sname);
    }
}
