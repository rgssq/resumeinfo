#region Using...
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;
#endregion

public partial class EnuList : System.Web.UI.Page
{
    #region 通用过程
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ObjGrid.SelectedRows.Count > 0) {
            try {
                DeleteItem();
                ObjGrid.SelectedRows.Clear();
                ObjGrid.FillGrid(GetQuery(true));
                WebHelper.AlertMsg("你选择的记录已经被删除！", ClientScript);
            }
            catch (Exception ex) {
                WebHelper.AlertMsg(ex.Message, ClientScript);
            }
        }
        else {
            WebHelper.AlertMsg("请先选择你要删除的记录！", ClientScript);
        }
    }
    protected void ObjGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpression"] = e.SortExpression;
        ObjGrid.FillGrid(GetQuery(false));
    }
    protected void Pager_Click()
    {
        ObjGrid.FillGrid(GetQuery(false));
    }
    private IQueryable GetQuery(bool Refresh)
    {
        IQueryable q = GetRawQuery();
        q = GetWhereQuery(q);
        q = GetOrderQuery(q);
        q = Pager.PagingQuery(q, Refresh);
        return q;
    }
    private IQueryable GetWhereQuery(IQueryable q)
    {
        if (ViewState["WhereCond"] != null) {
            if (ViewState["WhereCond"].ToString() != "") {
                q = q.Where(ViewState["WhereCond"].ToString());
            }
        }
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
            btnDelete.Attributes["onclick"] = "javascript:if (window.confirm('你确定要删除选择的记录吗？')) { $find('PopUp').show(); } else { return false; }";
            enuList.SelectedIndex = 0;
            enuList_SelectedIndexChanged(enuList, null);
        }
    }
    private IQueryable GetRawQuery()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q = db.GetTable((Type)ViewState["enuType"]).OrderBy("DisOrder");
        return q;
    }
    protected void enuList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["enuType"] = WebHelper.GetEnuType(enuList.SelectedValue);
        ObjGrid.FillGrid(GetQuery(true));
        btnNew.Attributes["onclick"] = "javascript:PopWin('EnuEdit.aspx?type=@type','ee',350,160,'c');return false;".Replace("@type", ViewState["enuType"].ToString());
    }
    protected void ObjGrid_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        string id = sender.ToString();
        HyperLink lkPKID = (HyperLink)e.Row.FindControl("PKID");
        lkPKID.ToolTip = "修改记录";
        lkPKID.Text = DataBinder.Eval(e.Row.DataItem, "PKID", "");
        lkPKID.NavigateUrl = "javascript:PopWin('EnuEdit.aspx?type=@type&id=@id','ee',350,160,'c');".Replace("@id", id).Replace("@type", ViewState["enuType"].ToString());
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ObjGrid.FillGrid(GetQuery(true));
    }
    private bool DeleteItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string cond = "";
        foreach (int id in ObjGrid.SelectedRows) {
            cond += "PKID == " + id + " || ";
        }
        cond = cond.Substring(0, cond.Length - 4);
        var item = db.GetTable((Type)ViewState["enuType"]).Where(cond);
        db.GetTable((Type)ViewState["enuType"]).DeleteAllOnSubmit(item);
        db.SubmitChanges();
        return true;
    }
}
