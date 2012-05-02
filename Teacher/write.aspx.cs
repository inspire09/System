using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Teacher_write : System.Web.UI.Page
{
    private static string tno = "";
    public string receiverID = "";

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

            if (Request.Params["receiverID"] != null)
                receiverID = Request.Params["receiverID"].ToString();
        }
    }

    [WebMethod]
    public static string write(string receiver, string topic, string content)
    {
        note_Manage noteManage = new note_Manage();
        DateTime date = DateTime.Now;
        return string.Format(noteManage.write(tno, receiver, topic, content, date));

    }

}
