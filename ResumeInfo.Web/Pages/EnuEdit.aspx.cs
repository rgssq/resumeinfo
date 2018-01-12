#region Using...
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.UI.WebControls;
using System.Web.UI;
#endregion

public partial class EnuEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            ViewState["type"] = Request.QueryString["type"];
            if (Request.QueryString["id"] != null) {
                ViewState["id"] = Request.QueryString["id"];
                btnOK.Text = "修 改";
                Page.Title = "修改数据字典信息";
                FillForm();
            }
            else {
                btnOK.Text = "添 加";
                Page.Title = "添加数据字典信息";
            }
            btnOK.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
            btnClose.Attributes["onclick"] = "javascript:window.close();return false;";
        }
    }
    private void FillForm()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string sql = "Select PKID, Label, DisOrder, IsShow From @table Where PKID = @PKID";
        sql = sql.Replace("@table", ViewState["type"].ToString());
        sql = sql.Replace("@PKID", ViewState["id"].ToString());
        var q = db.ExecuteQuery(WebHelper.GetEnuType(ViewState["type"].ToString()), sql);
        foreach (object o in q) {
            Label.Text = DataBinder.Eval(o, "Label", "");
            DisOrder.Text = DataBinder.Eval(o, "DisOrder", "");
            string isshow = DataBinder.Eval(o, "IsShow", "");
            if (isshow != "") {
                IsShow.Items.FindByValue(isshow).Selected = true;
            }
            break;
        }
    }
    private void CreateItem(ResumeInfoDataContext db)
    {
        string sql = "Insert @table (Label, DisOrder, IsShow) Values ('@Label', @DisOrder, '@IsShow')";
        sql = sql.Replace("@table", ViewState["type"].ToString());
        sql = sql.Replace("@Label", Label.Text);
        sql = sql.Replace("@DisOrder", "0" + DisOrder.Text);
        sql = sql.Replace("@IsShow", IsShow.SelectedValue);
        db.ExecuteCommand(sql);
    }
    private void ModifyItem(ResumeInfoDataContext db, string id)
    {
        string sql = "Update @table Set Label = '@Label', DisOrder = @DisOrder, IsShow = '@IsShow' Where PKID = @PKID";
        sql = sql.Replace("@table", ViewState["type"].ToString());
        sql = sql.Replace("@Label", Label.Text);
        sql = sql.Replace("@DisOrder", "0" + DisOrder.Text);
        sql = sql.Replace("@IsShow", IsShow.SelectedValue);
        sql = sql.Replace("@PKID", id);
        db.ExecuteCommand(sql);
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try {
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            if (ViewState["id"] == null) {
                CreateItem(db);
                WebHelper.AlertMsg("添加新信息成功！您可以关闭该窗口。", ClientScript);
            }
            else {
                ModifyItem(db, ViewState["id"].ToString());
                WebHelper.AlertMsg("修改信息成功！您可以关闭该窗口。", ClientScript);
            }
        }
        catch (Exception ex) {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
}