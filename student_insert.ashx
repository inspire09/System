<%@ WebHandler Language="C#" Class="student_insert" %>

using System;
using System.Web;

using System.Collections.Generic; // Dictionary<,> 键值对集合所需
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需

public class student_insert : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        context.Response.ContentType = "application/json";

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        string sno = context.Request.Form["sno"];
        //string sname = context.Request.Form["sname"];

        if (sno == null)
            drow.Add("name", "null");
        else
            drow.Add("name", "Wang");
        
        context.Response.Write(jss.Serialize(drow));

        /*string sno = context.Request.QueryString["sno"];
        string sname = context.Request.Form["sname"];

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, string> drow = new Dictionary<string, string>();
        stu_Manage stuManage = new stu_Manage();
        student stu = stuManage.stu_Insert(sno, sname);
        drow.Add("sno", stu.Sno);
        drow.Add("sname", stu.Sname);

        context.Response.Write(jss.Serialize(drow));*/
        
        /*JavaScriptSerializer jss = new JavaScriptSerializer();
        context.Response.ContentType = "text/plain";
        Dictionary<string, string> drow = new Dictionary<string, string>();
        drow.Add("name", "Wang");
        drow.Add("age", "24");
        context.Response.Write(jss.Serialize(drow));*/ 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}