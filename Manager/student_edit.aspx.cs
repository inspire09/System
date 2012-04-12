using System;
using System.Collections.Generic;// Dictionary<,> 键值对集合所需
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public partial class Manager_student_edit : System.Web.UI.Page
{
    private static string sno="";
    public string showClass = "";
    public string editClass = "";
    public string delClass = "";
    public string showLi = "";
    public string editLi = "";
    public string delLi = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //sno = Request.QueryString["sno"].ToString();
            //string operat = Request.QueryString["operat"].ToString();
            sno = Request.Params["sno"].ToString();
            string operat = Request.Params["operat"].ToString();
            //sno = "1003";
            //string operat = "del";
            
            if (operat == "show")
            {
                showClass = "tab-pane fade active in";
                editClass = "tab-pane fade";
                delClass = "tab-pane fade";
                showLi = "active";
                
            }
            else if (operat == "edit")
            {
                showClass = "tab-pane fade";
                editClass = "tab-pane fade active in";
                delClass = "tab-pane fade";
                editLi = "active";
            }
            else if (operat == "del")
            {
                showClass = "tab-pane fade";
                editClass = "tab-pane fade";
                delClass = "tab-pane fade active in";
                delLi = "active";
            }       
        }
    }

    [WebMethod]
    public static string student_info()
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        stu_Manage stuManage = new stu_Manage();
        student stu = stuManage.stu_Info(sno);
        drow.Add("sno", stu.Sno);
        drow.Add("sname", stu.Sname);
        drow.Add("sex", stu.Sex);
        drow.Add("institute", stu.Institute);
        drow.Add("major", stu.Major);
        drow.Add("sclass", stu.Sclass);
        drow.Add("tel", stu.Tel);
        drow.Add("email", stu.Email);
        drow.Add("englishLevel", stu.EnglishLevel);
        drow.Add("honour", stu.Honour);
        drow.Add("intro", stu.Intro);
        drow.Add("remark", stu.Remark);

        return jss.Serialize(drow);
        //return string.Format("欢迎你{0} {1}", sno, sname);
    }

    [WebMethod]
    public static string student_edit(string sname,string sex,string institute,string major,
        string sclass,string tel,string email,string eng, string honour,string intro,string remark)
    {
        student stu = new student();
        stu.Sno = sno;
        stu.Sname = sname;
        stu.Sex = sex;
        stu.Institute = institute;
        stu.Major = major;
        stu.Sclass = sclass;
        stu.Tel = tel;
        stu.Email = email;
        stu.EnglishLevel = eng;
        stu.Honour = honour;
        stu.Intro = intro;
        stu.Remark = remark;
        stu_Manage stuManage = new stu_Manage();
        if (stuManage.stu_Update(stu) == true)
            return string.Format("{0} {1}<br/>修改信息成功", sno, sname);
        else
            return string.Format("{0} {1}<br/>修改信息失败", sno, sname);
        
    }

    [WebMethod]
    public static string student_del()
    {
        stu_Manage stuManage = new stu_Manage();
        if (stuManage.stu_Delete(sno) == true)
            return string.Format("删除成功");
        else
            return string.Format("删除失败");

    }
}
