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
//数据库需要用到以下命名空间
using System.Data.SqlClient;
//哈希加密需要用到以下命名空间
using System.Web.Security;

public partial class Student_SDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        //验证用户登录状态
        if (Session["userID"] == null)
            //显示提示信息框
            Response.Write("<script>alert('请先登录！')</script>");
        else
        {
            //获取输入的用户名和密码
            string userID = Session["userID"].ToString();
            string userOldPwd = TextBoxOldPwd.Text;
            string userNewPwd = TextBoxNewPwd.Text;
            string userNewPwdAgain = TextBoxNewPwdAgain.Text;

            //验证用户填写的信息是否符合要求
            if (userOldPwd == "")
            {
                Response.Write("<script>alert('旧密码不能为空！')</script>");
                return;
            }
            if (userNewPwd == "")
            {
                Response.Write("<script>alert('新密码不能为空！')</script>");
                return;
            }
            if (userNewPwdAgain == "")
            {
                Response.Write("<script>alert('新密码不能为空！')</script>");
                return;
            }
            if (userNewPwd != userNewPwdAgain)
            {
                Response.Write("<script>alert('两次密码输入不一致！')</script>");
                return;
            }

            string myStr = ConfigurationManager.ConnectionStrings["ChoiceSystem"].ConnectionString;
            SqlConnection myConn = new SqlConnection(myStr);
            myConn.Open();
            //采用参数传值的方法来创建SQL查询语句，该语句用来验证原密码是否正确
            string sqlStr = "select count(*) from [userTable] where userID=@userID and userPass=@userOldPwd";
            SqlCommand com = new SqlCommand(sqlStr, myConn);

            //添加参数"@userID"
            com.Parameters.AddWithValue("@userID", userID);
            //添加参数"@userOldPwd"
            com.Parameters.AddWithValue("@userOldPwd", userOldPwd);

            //执行查询，并返回查询结果中的第一行第一列(其它行列全部丢失)
            int result = (int)com.ExecuteScalar();
            //判断返回的查询结果是否大于0，大于0表示原密码正确
            if (result > 0)
            {
                //创建SQL更新语句，该语句用来设置用户的新密码
                string sqlUpdate = "update [userTable] set userPass=@userPass where userID=@userID";
                SqlCommand myCmd = new SqlCommand(sqlUpdate, myConn);
                myCmd.Parameters.AddWithValue("@userPass", userNewPwd);
                myCmd.Parameters.AddWithValue("@userID", userID);
                //判断ExecuteNonQuery方法返回的参数是否大于0，大于0表示密码修改成功
                if (myCmd.ExecuteNonQuery() > 0)
                    Response.Write("<script>alert('密码修改成功！')</script>");
                else
                    Response.Write("<script>alert('密码修改失败！')</script>");
            }
            else
            {
                Response.Write("<script>alert('原密码错误！')</script>");
            }
            myConn.Close();
        }
    }
}
