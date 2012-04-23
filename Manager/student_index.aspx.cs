using System;
using System.Collections.Generic;// Dictionary<,> 键值对集合所需
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需


public partial class Manager_student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static string student_insert(string sno, string sname)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        stu_Manage stuManage = new stu_Manage();
        student stu = stuManage.stu_Insert(sno, sname);
        drow.Add("sno", stu.Sno);
        drow.Add("sname", stu.Sname);

        return jss.Serialize(drow);
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string student_select(string selectName, string selectValue)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        List<Dictionary<string, string>> drowList = new List<Dictionary<string, string>>();
        stu_Manage stuManage = new stu_Manage();
        List<student> stuList = stuManage.stu_select(selectName.Trim(), selectValue.Trim());
        for (int i = 0; i < stuList.Count; i++)
        {
            Dictionary<string, string> drow = new Dictionary<string, string>();
            drow.Add("sno", stuList[i].Sno);
            drow.Add("sname", stuList[i].Sname);
            drow.Add("sex", stuList[i].Sex);
            drow.Add("institute", stuList[i].Institute);
            drow.Add("major", stuList[i].Major);
            drow.Add("sclass", stuList[i].Sclass);
            drowList.Add(drow);
        }

        return jss.Serialize(drowList);
    }

}
