#region Using...
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.UI.WebControls;
#endregion

public partial class JtshgxList : System.Web.UI.Page
{
    #region 通用过程
    protected void ObjGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpression"] = e.SortExpression;
        ObjGrid.FillGrid(GetQuery(false));
    }
    private IQueryable GetQuery(bool Refresh)
    {
        IQueryable q = GetRawQuery();
        q = GetOrderQuery(q);
        return q;
    }
    private IQueryable GetOrderQuery(IQueryable q)
    {
        if (ViewState["SortExpression"] != null) {
            q = q.OrderBy(ViewState["SortExpression"].ToString());
        }
        return q;
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            if (Request.QueryString["delid"] != null) {
                DeleteItem(Request.QueryString["delid"]);
            }
            btnRefresh.Attributes["onclick"] = "javascript:$find('PopUp').show();";
            
        }
        ObjGrid.FillGrid(GetQuery(true));
    }
    private IQueryable GetRawQuery()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q = from p in db.Jiatshgx
                       where p.UserID == int.Parse(Session["UserID"].ToString())
                       select new {
                           p.PKID,
                           p.cw,
                           p.xm,
                           p.nl,
                           zzmm = p.enuZzmm.Label,
                           p.gzdw,
                           p.bmzw,
                       };
        return q;
    }
    protected void ObjGrid_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        string id = sender.ToString();
        Image ImgInfo = (Image)e.Row.FindControl("ImgInfo");
        ImgInfo.Attributes["onclick"] = "javascript:if (window.confirm('你确定要修改选择的记录吗？')) {window.parent.frames['fmBottom'].window.location.href='JtshgxEdit.aspx?id=@id';}else { return false; }".Replace("@id", id);

        Image ImgDel = (Image)e.Row.FindControl("ImgDel");
        ImgDel.Attributes["onclick"] = "javascript:if (window.confirm('你确定要删除选择的记录吗？')) { window.window.location.href='JtshgxList.aspx?delid=@delid'; } else { return false; }".Replace("@delid", id);

        e.Row.Attributes["onclick"] = "javascript:RowClick(this);";
    }
    private void DeleteItem(string id)
    {
        try {
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            Jiatshgx item = db.Jiatshgx.Single(o => o.PKID == int.Parse(id));
            db.Jiatshgx.DeleteOnSubmit(item);
            db.SubmitChanges();
            WebHelper.AlertMsg("你选择的记录已经被删除！", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        WebHelper.WriteScript("window.loaction.href='JtshgxList.aspx';", ClientScript);
    }
}