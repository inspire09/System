using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///volunteer 的摘要说明
/// </summary>
public class volunteer
{
    private string Sno;
    private string Tno;
    private string Priority;  

	public volunteer()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public string sno
    {
        get { return this.Sno; }
        set { this.Sno = value; }
    }
    public string tno
    {
        get { return this.Tno; }
        set { this.Tno = value; }
    }
    public string priority
    {
        get { return this.Priority; }
        set { this.Priority = value; }
    }
}
