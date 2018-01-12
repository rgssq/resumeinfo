#region Using...
using System;
using System.Linq;
using System.Web.UI.WebControls;
#endregion

public partial class FileInfoEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            if (Request.QueryString["id"] != null) {
                ViewState["id"] = Request.QueryString["id"];
                FillForm(int.Parse(ViewState["id"].ToString()));
            }
            else {
                FillNewForm();
                btnEdit.Enabled = false;
            }
            btnNew.Attributes["onclick"] = "javascript:return AskUser();";
            btnEdit.Attributes["onclick"] = "javascript:return AskUser();";
        }
    }
    private void FillNewForm()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        WebHelper.FillEnuList(wjlx, db, typeof(enuWjlx), false, "");
    }
    private void FillForm(int id)
    {
        FillNewForm();
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        FileInfo item = db.FileInfo.Single(p => p.FileID == id);
        WebHelper.BindObjectToControls(item, PanField);
    }
    private void CreateItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        FileInfo item = new FileInfo();
        WebHelper.BindControlsToObject(item, PanField);
        item.UserID = int.Parse(Session["UserID"].ToString());
        item.UpTime = DateTime.Now;
        item.FName = FileUp.FileName;
        item.FLength = FileUp.FileContent.Length;
        db.FileInfo.InsertOnSubmit(item);
        db.SubmitChanges();
        UpLoadFile(item.FileID);
    }
    private void ModifyItem(int id)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        FileInfo item = db.FileInfo.Single(p => p.FileID == id);
        WebHelper.BindControlsToObject(item, PanField);
        if (FileUp.HasFile) {
            item.UpTime = DateTime.Now;
            item.FName = FileUp.FileName;
            item.FLength = FileUp.FileContent.Length;
            UpLoadFile(item.FileID);
        }
        db.SubmitChanges();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try {
            if (FileUp.HasFile) {
                CreateItem();
                WebHelper.AlertMsg("添加成功！", ClientScript);
                WebHelper.WriteScript("window.parent.frames[0].location.href='FileInfoList.aspx';window.parent.frames[0].location.reload();", ClientScript);
            }
            else {
                WebHelper.AlertMsg("你没有选择文件，或者你选择的文件无效！", ClientScript);
            }
        }
        catch (Exception ex) {
            WebHelper.AlertMsg("数据库写入失败！\\r\\n" + ex.Message.Replace(Environment.NewLine, "\\r\\n"), ClientScript);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try {
            ModifyItem(int.Parse(ViewState["id"].ToString()));
            WebHelper.AlertMsg("修改成功！", ClientScript);
            WebHelper.WriteScript("window.parent.frames[0].location.href='FileInfoList.aspx';window.parent.frames[0].location.reload();", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg("数据库写入失败！\\r\\n" + ex.Message.Replace(Environment.NewLine, "\\r\\n"), ClientScript);
        }
    }
    private void UpLoadFile(int FileID)
    {
        string path = WebHelper.GetAttachUpDir();
        SharpZipHelper.ZipFile(FileUp.FileContent, path + FileID.ToString() + ".xmx");
    }
}