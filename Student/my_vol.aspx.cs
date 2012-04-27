using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Student_myvolunteer : System.Web.UI.Page
{
    public static string sno = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            sno = "1001";
    }

    [WebMethod]
    public static string myvol()
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        vol_Manage volManage = new vol_Manage();

        return jss.Serialize(volManage.myVol(sno));
    }

    [WebMethod]
    public static string vol_delete(string priority)
    {
        vol_Manage volManage = new vol_Manage();
        return string.Format(volManage.vol_Delete(sno, priority));
    }

}
