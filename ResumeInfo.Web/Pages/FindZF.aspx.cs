#region Using...
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
#endregion

public partial class FindZF : System.Web.UI.Page
{
    #region 通用过程
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
    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            if (Session["UserID"].ToString() == "0") {
                btnUndozf.Visible = true;
                btnUndozf.Attributes["onclick"] = "javascript:if (window.confirm('你确定要取消作废选择的记录吗？')) { $find('PopUp').show(); } else { return false; }";
            }

            ObjGrid.FillGrid(GetQuery(true));
            //form1.Controls.Add(WebHelper.WriteSqlLog(sb));
        }
    }
    private IQueryable GetRawQuery()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        //sb = WebHelper.SetSqlLog(db);
        var q = from b in db.BaseInfo
                where b.ModifyTime.HasValue && b.zfflag.Value
                select new {
                    b.UserID,
                    b.PName,
                    b.PID,
                    b.ModifyTime,
                    SexLabel = b.enuSex.Label,
                };
        return q;
    }
    protected void ObjGrid_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        string id = sender.ToString();
        Image Inforpt = (Image)e.Row.FindControl("Inforpt");
        Inforpt.Attributes["onclick"] = "javascript:PopWin('InfoRpt.aspx?id=@id','rpt',300,100,'c');".Replace("@id", id);

        HyperLink PName = (HyperLink)e.Row.FindControl("PName");
        PName.ToolTip = "点击可以查看简历详细信息";
        PName.Text = DataBinder.Eval(e.Row.DataItem, "PName", "");
        PName.NavigateUrl = "javascript:PopWin('ViewInfo.aspx?es=open&id=@id','df',750,680,'c');".Replace("@id", id);
    }
    protected void btnUndozf_Click(object sender, EventArgs e)
    {
        if (ObjGrid.SelectedRows.Count > 0) {
            try {
                UndozfItem();
                ObjGrid.SelectedRows.Clear();
                ObjGrid.FillGrid(GetQuery(true));
                WebHelper.AlertMsg("你选择的记录已经被取消作废！", ClientScript);
            }
            catch (Exception ex) {
                WebHelper.AlertMsg(ex.Message, ClientScript);
            }
        }
        else {
            WebHelper.AlertMsg("请先选择你要取消作废的记录！", ClientScript);
        }
    }
    private bool UndozfItem()
    {
        string sql = "Update BaseInfo Set zfflag = 'False' Where UserID In (@UserID)";
        string userid = "";
        foreach (int id in ObjGrid.SelectedRows) {
            userid += id.ToString() + ",";
        }
        if (userid.Length > 0) userid = userid.Substring(0, userid.Length - 1);
        sql = sql.Replace("@UserID", userid);
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        db.ExecuteCommand(sql);
        return true;
    }
}