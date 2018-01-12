#region Using...
using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
#endregion

public partial class PhotoUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            imgPhoto.ImageUrl = "ShowPhoto.aspx?id=" + Session["UserID"].ToString();
            FileUp.Attributes["onchange"] = "javascript:changeSrc(this)";
            btnNew.Attributes["onclick"] = "javascript:return AskUser();";
        }
        WebHelper.IsSessionValid(Session, Response);
        imgPhoto.ImageUrl = "ShowPhoto.aspx?id=" + Session["UserID"].ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try {
            if (FileUp.HasFile) {
                SaveImageToJpeg(FileUp.FileContent);
                WebHelper.AlertMsg("照片上传成功！", ClientScript);
            }
            else {
                WebHelper.AlertMsg("你没有选择文件，或者你选择的文件无效！", ClientScript);
            }
        }
        catch (Exception ex) {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
    private void SaveImageToJpeg(Stream ms)
    {
        Image img = Image.FromStream(ms);
        Image.GetThumbnailImageAbort cb = new Image.GetThumbnailImageAbort(ImageCB);
        img = img.GetThumbnailImage(90, 110, cb, IntPtr.Zero);
        img.Save(WebHelper.GetPhotoUpDir() + Session["UserID"].ToString() + ".jpg", ImageFormat.Jpeg);
    }
    private bool ImageCB()
    {
        return false;
    }
}