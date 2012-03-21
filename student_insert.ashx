<%@ WebHandler Language="C#" Class="student_insert" %>

using System;
using System.Web;

public class student_insert : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        stu_Manage stuManage = new stu_Manage();
        student stu = stuManage.stu_Insert(sno, sname);
        drow.Add("sno", stu.sno);
        drow.Add("sname", stu.sname);

        context.Response.Write(jss.Serialize(drow));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}