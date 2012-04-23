using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///teacher 的摘要说明
/// </summary>
public class teacher
{
    private string Tno;
    private string Tname;
    private string Sex;  
    private string Room;
    private string Photo;
    private string Tel;
    private string Email;
    private string Title;
    private string Education;
    private string Course;
    private string Research;
    private string Article;
    private string Demand;
    private string Institute;

	public teacher()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public string tno
    {
        get { return this.Tno; }
        set { this.Tno = value; }
    }
    public string tname
    {
        get { return this.Tname; }
        set { this.Tname = value; }
    }
    public string sex
    {
        get { return this.Sex; }
        set { this.Sex = value; }
    }
    public string room
    {
        get { return this.Room; }
        set { this.Room = value; }
    }
    public string photo
    {
        get { return this.Photo; }
        set { this.Photo = value; }
    }
    public string tel
    {
        get { return this.Tel; }
        set { this.Tel = value; }
    }
    public string email
    {
        get { return this.Email; }
        set { this.Email = value; }
    }
    public string title
    {
        get { return this.Title; }
        set { this.Title = value; }
    }
    public string education
    {
        get { return this.Education; }
        set { this.Education = value; }
    }
    public string course
    {
        get { return this.Course; }
        set { this.Course = value; }
    }
    public string research
    {
        get { return this.Research; }
        set { this.Research = value; }
    }
    public string article
    {
        get { return this.Article; }
        set { this.Article = value; }
    }
    public string demand
    {
        get { return this.Demand; }
        set { this.Demand = value; }
    }
    public string institute
    {
        get { return this.Institute; }
        set { this.Institute = value; }
    }

}
