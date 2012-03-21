using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Text;

/// <summary>
///student 的摘要说明
/// </summary>
public class student
{
    private string sno;
    private string sname;
    private string sex;
    private string institute;
    private string major;
    private string Class;
    private string tel;
    private string email;
    private string englishLevel;
    private string honour;
    private string intro;
    private string remark;

	public student()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public string sno
    {
        get { return this.sno; }
        set { this.sno = value; }
    }
    public string sname
    {
        get { return this.sname; }
        set { this.sname = value; }
    }
    public string sex
    {
        get { return this.sex; }
        set { this.sex = value; }
    }
    public string institute
    {
        get { return this.institute; }
        set { this.institute = value; }
    }
    public string major
    {
        get { return this.major; }
        set { this.major = value; }
    }
    public string Class
    {
        get { return this.Class; }
        set { this.Class = value; }
    }
    public string tel
    {
        get { return this.tel; }
        set { this.tel = value; }
    }
    public string email
    {
        get { return this.email; }
        set { this.email = value; }
    }
    public string englishLevel
    {
        get { return this.englishLevel; }
        set { this.englishLevel = value; }
    }
    public string honour
    {
        get { return this.honour; }
        set { this.honour = value; }
    }
    public string intro
    {
        get { return this.intro; }
        set { this.intro = value; }
    }
    public string remark
    {
        get { return this.remark; }
        set { this.remark = value; }
    }
}
