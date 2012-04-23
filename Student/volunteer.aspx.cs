using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Student_volunteer : System.Web.UI.Page
{
    public static string sno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            sno = "1001";
            //sno = Session["userID"].ToString();
    }
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
            SqlDataSource1.SelectCommand = "select * from teacherInfo";
        else
            SqlDataSource1.SelectCommand = "select * from teacherInfo where " + DropDownList1.SelectedValue 
                + " like '%" + TextBox1.Text + "%'";
        ListView1.DataBind();
    }

    protected void DropDownListCollege_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList droplist = (DropDownList)sender;
        if (droplist.SelectedValue == "所有学院")
            SqlDataSource1.SelectCommand = "select * from teacherInfo";
        else
            SqlDataSource1.SelectCommand = "select * from teacherInfo where institute='" + droplist.SelectedValue + "'";
        ListView1.DataBind();
    }

    [WebMethod]
    public static string volunteer_select(string priority)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        vol_Manage volManage = new vol_Manage();
        return jss.Serialize(volManage.vol_Select(sno, priority));
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string volunteer_insert(string tno, string priority)
    {
        vol_Manage volManage = new vol_Manage();
        return string.Format(volManage.vol_Insert(sno, tno, priority));

    }

    [WebMethod]
    public static string volunteer_update(string tno, string priority)
    {
        vol_Manage volManage = new vol_Manage();
        return string.Format(volManage.vol_Update(sno, tno, priority));
    }
  
}
