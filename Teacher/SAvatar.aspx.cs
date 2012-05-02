using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using System.Web.Script.Serialization;  //JavaScriptSerializer 类所需
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class Student_SAvatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static string upload_avatar(string origin_width, string origin_height, string to_width, string to_height, string scalex, string scaley, string x, string y)
    {
        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
        string filePath = "d:" + "\\" + filename;
        int partWidth = Convert.ToInt32(to_width);
        int partHeight = Convert.ToInt32(to_height);
        int orig_x = Convert.ToInt32(x);
        int orig_y = Convert.ToInt32(y);
        int orig_w = (int)(partWidth / Convert.ToDouble(scalex));
        int orig_h = (int)(partHeight / Convert.ToDouble(scaley));

        string pPath = "E:\\VS2008\\System-bbd0710\\assets\\sample\\pool.jpg";
        System.Drawing.Image originalImg = System.Drawing.Image.FromFile(pPath);
        Bitmap thumimg = new Bitmap(originalImg);
        Bitmap partImg = new Bitmap(partWidth, partHeight);

        Graphics graphics = Graphics.FromImage(partImg);
        Rectangle destRect = new Rectangle(new Point(0, 0), new Size(partWidth, partHeight)); //目标位置 
        Rectangle origRect = new Rectangle(new Point(orig_x, orig_y), new Size(orig_w,orig_h)); //原图位置（默认从原图中截取的图片大小等于目标图片的大小）

        ///文字水印   
        Graphics G = Graphics.FromImage(partImg);
        //Font f = new Font("Lucida Grande", 6); 
        //Brush b = new SolidBrush(Color.Gray); 
        G.Clear(Color.White);
        // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        // 指定高质量、低速度呈现。 
        G.SmoothingMode = SmoothingMode.HighQuality;

        graphics.DrawImage(thumimg, destRect, origRect, GraphicsUnit.Pixel);
        //G.DrawString("Xuanye", f, b, 0, 0); 
        G.Dispose();

        originalImg.Dispose();
        if (File.Exists(filePath))
        {
            File.SetAttributes(filePath, FileAttributes.Normal);
            File.Delete(filePath);
        }
        partImg.Save(filePath, ImageFormat.Jpeg);
        
        partImg.Dispose();
        thumimg.Dispose();
        return filename; 
    }

}
