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
        SqlCommand myCmd = new SqlCommand("userLogin", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        myCmd.Parameters.Add("@userID", SqlDbType.Char, 20).Value = userID;
        myCmd.Parameters.Add("@userPass", SqlDbType.Char, 20).Value = userPass;
        myCmd.Parameters.Add("@privilege", SqlDbType.Char, 20).Value = privilege;
        int result = (int)myCmd.ExecuteScalar();
        myConn.Close();
        if (result > 0)
        {
            Session["userID"] = userID;
            if(privilege=="学生")
                Response.Redirect("Student/SDefault.aspx");
            else if(privilege=="教师")
                Response.Redirect("Student/SDefault.aspx");
            else if (privilege == "管理员")
                Response.Redirect("Student/SDefault.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误！')</script>");
        }   
    }
}
