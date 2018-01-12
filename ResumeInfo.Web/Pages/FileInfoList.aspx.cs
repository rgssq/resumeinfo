#region Using...
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
#endregion

public partial class FileInfoList : System.Web.UI.Page
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
            ObjGrid.FillGrid(GetQuery(true));
        }
    }
    private IQueryable GetRawQuery()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q = from p in db.FileInfo
                       where p.UserID == int.Parse(Session["UserID"].ToString())
                       orderby p.UpTime
                       select new {
                           p.FileID,
                           p.FName,
                           p.FLength,
                           wjlx = p.enuWjlx.Label,
                           p.UpTime,
                           p.fjsm,
                       };
        return q;
    }
    protected void ObjGrid_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onclick"] = "javascript:RowClick(this);";
        string id = sender.ToString();
        Image ImgInfo = (Image)e.Row.FindControl("ImgInfo");
        ImgInfo.Attributes["onclick"] = "javascript:if (window.confirm('你确定要修改选择的记录吗？')) { window.parent.frames['fmBottom'].window.location.href='FileInfoEdit.aspx?id=@id';} else { return false; }".Replace("@id", id);

        Image ImgDel = (Image)e.Row.FindControl("ImgDel");
        ImgDel.Attributes["onclick"] = "javascript:if (window.confirm('你确定要删除选择的记录吗？')) { window.location.href='FileInfoList.aspx?delid=@delid'; } else { return false; }".Replace("@delid", id);

        HyperLink FName = (HyperLink)e.Row.FindControl("FName");
        FName.ToolTip = "点击可以下载该附件";
        FName.Text = DataBinder.Eval(e.Row.DataItem, "FName", "");
        FName.NavigateUrl = "javascript:PopWinFix('DownFile.aspx?id=@id','df',300,100,'c');".Replace("@id", id);
    }
    private void DeleteItem(string id)
    {
        try {
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            FileInfo item = db.FileInfo.Single(o => o.FileID == int.Parse(id));
            db.FileInfo.DeleteOnSubmit(item);
            db.SubmitChanges();
            File.Delete(WebHelper.GetAttachUpDir() + id + ".xmx");
            WebHelper.AlertMsg("你选择的记录已经被删除！", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        WebHelper.WriteScript("window.location.href='FileInfoList.aspx';", ClientScript);
    }
}