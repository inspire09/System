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
    private string sclass;
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

    public string Sno
    {
        get { return this.sno; }
        set { this.sno = value; }
    }
    public string Sname
    {
        get { return this.sname; }
        set { this.sname = value; }
    }
    public string Sex
    {
        get { return this.sex; }
        set { this.sex = value; }
    }
    public string Institute
    {
        get { return this.institute; }
        set { this.institute = value; }
    }
    public string Major
    {
        get { return this.major; }
        set { this.major = value; }
    }
    public string Sclass
    {
        get { return this.sclass; }
        set { this.sclass = value; }
    }
    public string Tel
    {
        get { return this.tel; }
        set { this.tel = value; }
    }
    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }
    public string EnglishLevel
    {
        get { return this.englishLevel; }
        set { this.englishLevel = value; }
    }
    public string Honour
    {
        get { return this.honour; }
        set { this.honour = value; }
    }
    public string Intro
    {
        get { return this.intro; }
        set { this.intro = value; }
    }
    public string Remark
    {
        get { return this.remark; }
        set { this.remark = value; }
    }
}
