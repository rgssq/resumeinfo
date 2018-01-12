using System;
using System.IO;
using System.Linq;

public partial class DownFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            btnClose.Attributes["onclick"] = "javascript:window.close();return false;";

            string FileID = Request.QueryString["id"];
            string fname = WebHelper.GetAttachUpDir() + FileID + ".xmx";
            if (File.Exists(fname)) {
                ResumeInfoDataContext db = new ResumeInfoDataContext();
                FileInfo item = db.FileInfo.Single(o => o.FileID == int.Parse(FileID));
                if (Session["UserType"].ToString() == "0" || Session["UserType"].ToString() == "1" ||  int.Parse(Session["UserID"].ToString()) == item.UserID)
                {
                    PushFile(fname, item.FName);
                    Response.End();
                }
                else {
                    labInfo.Text = "您无法下载他人上传的附件！";
                }
            }
            else {
                labInfo.Text = "在服务器上找不到该附件！";
            }
        }
    }
    private void PushFile(string fname, string filename)
    {
        MemoryStream ms = SharpZipHelper.UnzipFileToStream(fname);
        Response.ContentType = "file/" + Path.GetExtension(filename);
        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode(filename));
        Response.BinaryWrite(ms.ToArray());
        ms.Close();
    }
}
