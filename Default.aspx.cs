using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    static SqlClass mysql = new SqlClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string userPass = TextBoxUserPass.Text;
        string privilege = "学生";
        //string myStr = "select count(*) from userTable where userID='" + userID + "' and userPass='" + userPass + "' and privilege='" + privilege + "'";       
        int result = mysql.Login(userID,userPass,privilege);
        if (result > 0)
        {
            Session["userID"] = userID;
            Response.Redirect("Student/SDefault.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误！')</script>");
        }   
    }
}
