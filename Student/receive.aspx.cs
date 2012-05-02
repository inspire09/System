using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_receive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["userID"] = "1002";
            if (Session["userID"] == null)
                Response.Redirect("../Default.aspx");
            
        }
    }
}
