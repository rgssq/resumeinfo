using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class ShowPhoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            string id = Request.QueryString["id"];
            if (int.Parse(Session["UserType"].ToString()) > 0 && Session["UserID"].ToString() != id) {
                string s = "您无权查看\r\n其他人的照片";
                Response.BinaryWrite(GetMsgImageByString(s));
            }
            else {
                string fname = WebHelper.GetPhotoUpDir() + id + ".jpg";
                if (File.Exists(fname)) {
                    Response.WriteFile(fname);
                }
                else {
                    string s = "您没有上传照片";
                    Response.BinaryWrite(GetMsgImageByString(s));
                }
            }
        }
    }
    private byte[] GetMsgImageByString(string Msg)
    {
        int width = 90;
        int height = 110;
        Bitmap newBitmap = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(newBitmap);
        RectangleF rectangle = new RectangleF(0, 0, width, height);
        g.FillRectangle(new SolidBrush(Color.White), rectangle);
        Font textFont = new Font("宋体", 9);
        g.DrawString(Msg, textFont, new SolidBrush(Color.Blue), rectangle.X + 1, rectangle.Y + 50);
        MemoryStream ms = new MemoryStream();
        newBitmap.Save(ms, ImageFormat.Jpeg);
        g.Dispose();
        textFont.Dispose();
        newBitmap.Dispose();
        return ms.ToArray();
    }
}
