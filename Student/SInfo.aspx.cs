using System;
using System.Collections;
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

public partial class Student_SInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userID"] = "1001";
        if (IsPostBack == false)
        {
            //从Session对象中获取用户登录名，以验证用户登录状态
            if (Session["userID"] == null)
                Response.Redirect("../Default.aspx");
            else
            {
                TextBoxSno.Text = Session["userID"].ToString();
                string myStr = ConfigurationManager.ConnectionStrings["ChoiceSystem"].ConnectionString;
                SqlConnection myConn = new SqlConnection(myStr);
                myConn.Open();
                SqlCommand myCmd = new SqlCommand("stuSelect", myConn);
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.Parameters.Add("@userID", SqlDbType.Char, 20).Value = TextBoxSno.Text;
                //创建数据读取对象(注意：ExecuteReader()方法获取的数据只读，而且只能向后移动记录)
                SqlDataReader reader = myCmd.ExecuteReader();
                //读取当前登录用户的信息，并显示到相应的控件中               
                if (reader.Read())
                {
                    TextBoxName.Text = reader["sname"].ToString();
                    DropDownListSex.SelectedValue = reader["sex"].ToString();
                    TextBoxInstitute.Text = reader["institute"].ToString();
                    TextBoxMajor.Text = reader["major"].ToString();
                    TextBoxClass.Text = reader["class"].ToString();
                    TextBoxTel.Text = reader["tel"].ToString();
                    TextBoxEmail.Text = reader["email"].ToString();
                    TextBoxEng.Text = reader["englishLevel"].ToString();
                    TextBoxHonour.Text = reader["honour"].ToString();
                    TextBoxIntro.Text = reader["intro"].ToString();
                    TextBoxRemark.Text = reader["remark"].ToString();
                }
                //关闭数据读取对象
                reader.Close();
                myConn.Close();
            }
        }
    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        string myStr = ConfigurationManager.ConnectionStrings["ChoiceSystem"].ConnectionString;
        SqlConnection myConn = new SqlConnection(myStr);
        myConn.Open();
        SqlCommand myCmd = new SqlCommand("stuUpdate", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
         
        myCmd.Parameters.AddWithValue("@sno", TextBoxSno.Text);
        myCmd.Parameters.AddWithValue("@sname", TextBoxName.Text);
        myCmd.Parameters.AddWithValue("@sex", DropDownListSex.SelectedValue);
        myCmd.Parameters.AddWithValue("@institute", TextBoxInstitute.Text);
        myCmd.Parameters.AddWithValue("@major", TextBoxMajor.Text);
        myCmd.Parameters.AddWithValue("@class", TextBoxClass.Text);
        myCmd.Parameters.AddWithValue("@tel", TextBoxTel.Text);
        myCmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
        myCmd.Parameters.AddWithValue("@englishLevel", TextBoxEng.Text);
        myCmd.Parameters.AddWithValue("@Honour", TextBoxHonour.Text);
        myCmd.Parameters.AddWithValue("@Intro", TextBoxIntro.Text);
        myCmd.Parameters.AddWithValue("@Remark", TextBoxRemark.Text);

        /* myCmd.Parameters.Add("@sno", SqlDbType.Char, 20).Value = TextBoxSno.Text;
        myCmd.Parameters.Add("@sname", SqlDbType.Char, 20).Value = TextBoxName.Text;
        myCmd.Parameters.Add("@sex", SqlDbType.Char, 20).Value = DropDownListSex.SelectedValue;
        myCmd.Parameters.Add("@institute", SqlDbType.Char, 20).Value = TextBoxInstitute.Text;
        myCmd.Parameters.Add("@major", SqlDbType.VarChar, 50).Value = TextBoxMajor.Text;
        myCmd.Parameters.Add("@class", SqlDbType.Char, 20).Value = TextBoxClass.Text;
        myCmd.Parameters.Add("@tel", SqlDbType.Char, 20).Value = TextBoxTel.Text;
        myCmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TextBoxEmail.Text;
        myCmd.Parameters.Add("@englishLevel", SqlDbType.Char, 20).Value = TextBoxEng.Text;
        myCmd.Parameters.Add("@Honour", SqlDbType.Text).Value = TextBoxHonour.Text;
        myCmd.Parameters.Add("@Intro", SqlDbType.Text).Value = TextBoxIntro.Text;
        myCmd.Parameters.Add("@Remark", SqlDbType.Text).Value = TextBoxRemark.Text;*/


        if (myCmd.ExecuteNonQuery() > 0)
            Response.Write("<script>alert('修改个人信息成功！')</script>");
        else
            Response.Write("<script>alert('修改个人信息失败！')</script>");

        //关闭数据库连接对象
        myConn.Close();
    }
}
