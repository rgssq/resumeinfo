#region Using...
using System;
using System.Linq;
using System.Web.UI.WebControls;
#endregion

public partial class JtshgxEdit : System.Web.UI.Page
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
            btnNew.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
            btnEdit.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
        }
    }
    private void FillNewForm()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        WebHelper.FillEnuList(zzmm, db, typeof(enuZzmm), true, "");
    }
    private void FillForm(int id)
    {
        FillNewForm();
        ResumeInfoDataContext db = new ResumeInfoDataContext();


        Jiatshgx item = db.Jiatshgx.Single(p => p.PKID == id);
        WebHelper.BindObjectToControls(item, PanField);
    }
    private void CreateItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        Jiatshgx item = new Jiatshgx();
        WebHelper.BindControlsToObject(item, PanField);
        item.UserID = int.Parse(Session["UserID"].ToString());
        db.Jiatshgx.InsertOnSubmit(item);
        db.SubmitChanges();
    }
    private void ModifyItem(int id)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        Jiatshgx item = db.Jiatshgx.Single(p => p.PKID == id);
        WebHelper.BindControlsToObject(item, PanField);
        db.SubmitChanges();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try {
            CreateItem();
            WebHelper.AlertMsg("添加成功！", ClientScript);
            WebHelper.WriteScript("window.parent.frames[0].location.href='JtshgxList.aspx';window.parent.frames[0].location.reload();", ClientScript);
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
            WebHelper.WriteScript("window.parent.frames[0].location.href='JtshgxList.aspx';window.parent.frames[0].location.reload();", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg("数据库写入失败！\\r\\n" + ex.Message.Replace(Environment.NewLine, "\\r\\n"), ClientScript);
        }
    }
}