using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string userPass = TextBoxUserPass.Text;
        string privilege = DropDownListPrivilege.SelectedValue.ToString();

        string myStr = ConfigurationManager.ConnectionStrings["ChoiceSystem"].ConnectionString;
        SqlConnection myConn = new SqlConnection(myStr);
        myConn.Open();
        string sqlStr = "select count(*) from userTable where userID=@userID and userPass=@userPass and privilege=@privilege";
        SqlCommand myCmd = new SqlCommand(sqlStr, myConn);
        myCmd.Parameters.AddWithValue("@userID", userID);
        myCmd.Parameters.AddWithValue("@userPass", userPass);
        myCmd.Parameters.AddWithValue("@privilege", privilege);
        int result = (int)myCmd.ExecuteScalar();
        myConn.Close();
        if (result > 0)
        {
            Session["userID"] = userID;
            if(privilege=="学生")
                Response.Redirect("Student/SDefault.aspx");
            else if(privilege=="教师")
                Response.Redirect("Teacher/TDefault.aspx");
            else if (privilege == "管理员")
                Response.Redirect("Manager/MDefault.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误！')</script>");
        }   
    }

}
