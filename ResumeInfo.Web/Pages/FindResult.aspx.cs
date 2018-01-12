#region Using...
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Net.Mail;

#endregion

public partial class FindResult : System.Web.UI.Page
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
    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            if (Session["UserType"].ToString() == "0") {
                btnExport.Visible = true;
                btnExport.Attributes["onclick"] = "javascript:if (window.confirm('你确定要导出选择的记录吗？')) { $find('PopUp').show(); } else { return false; }";
                btnSetzf.Visible = true;
                btnSetzf.Attributes["onclick"] = "javascript:if (window.confirm('你确定要作废选择的记录吗？')) { $find('PopUp').show(); } else { return false; }";
                btnDelete.Visible = true;
                btnDelete.Attributes["onclick"] = "javascript:if (window.confirm('你确定要删除选择的记录吗？')) { $find('PopUp').show(); } else { return false; }";
                btnSetzt.Visible = true;
                btnSetzt.Attributes["onclick"] = "javascript:if (window.confirm('你确定要设置简历状态吗？')) { $find('PopUp').show(); } else { return false; }";
                ztlist.Visible = true;
                ResumeInfoDataContext db = new ResumeInfoDataContext();
                WebHelper.FillEnuList(ztlist, db, typeof(enuZt), false, "");
            }
            btnBack.Attributes["onclick"] = "javascript:$find('PopUp').show(); ";

            ViewState["Query"] = PreviousPage.QueryList;

            ObjGrid.FillGrid(GetQuery(true));
            //form1.Controls.Add(WebHelper.WriteSqlLog(sb));
        }
    }
    private IQueryable GetRawQuery()
    {
        IQueryable<int> Query = null;
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        //sb = WebHelper.SetSqlLog(db);
        Dictionary<Type, string> querylist = (Dictionary<Type, string>)ViewState["Query"];
        foreach (Type tp in querylist.Keys) {
            if (Query == null) {
                if (tp == typeof(Jiaoybj))
                {

                    IQueryable p = from m in db.Jiaoybj
                                   group new { m.UserID, m.byyx, m.sxzy, m.jyjd } by m.UserID into g
                                   orderby g.FirstOrDefault().jyjd
                                   select new
                                   {
                                       UserID = g.FirstOrDefault().UserID,
                                       byyx = g.FirstOrDefault().byyx,
                                       sxzy = g.FirstOrDefault().sxzy,
                                       jyjd = g.FirstOrDefault().jyjd
                                   }
                                  ;
                              
                    
                                    
                    
                    
                    Query = (IQueryable<int>)p.Where(querylist[tp]).Select("UserID");
                }
                else
                    Query = (IQueryable<int>)db.GetTable(tp).Where(querylist[tp]).Select("UserID");
            }
            else {
                if(tp == typeof(Jiaoybj))
                {
                    IQueryable p = from m in db.Jiaoybj
                                   group new { m.UserID, m.byyx, m.sxzy, m.jyjd } by m.UserID into g
                                   orderby g.FirstOrDefault().jyjd
                                   select new
                                   {
                                       UserID = g.FirstOrDefault().UserID,
                                       byyx = g.FirstOrDefault().byyx,
                                       sxzy = g.FirstOrDefault().sxzy,
                                       jyjd = g.FirstOrDefault().jyjd
                                   }
                                 ;
                 
                    Query = Query.Intersect((IQueryable<int>)p.Where(querylist[tp]).Select("UserID"));
                }
                else
                    Query = Query.Intersect((IQueryable<int>)db.GetTable(tp).Where(querylist[tp]).Select("UserID"));
            }
        }
        var q = from b in db.BaseInfo
                where b.ModifyTime.HasValue && (!b.zfflag.Value || !b.zfflag.HasValue)
                select new {
                    b.UserID,
                    b.PName,
                    b.PID,
                    b.sj,
                    b.ModifyTime,
                    SexLabel = b.enuSex.Label,
                    byyx = b.Jiaoybj.Where(o => o.UserID == b.UserID).OrderByDescending(o => o.enuJyjd.DisOrder).First().byyx,
                    xl = b.Jiaoybj.Where(o => o.UserID == b.UserID).OrderByDescending(o => o.enuJyjd.DisOrder).First().enuJyjd.Label,
                    zy = b.Jiaoybj.Where(o => o.UserID == b.UserID).OrderByDescending(o => o.enuJyjd.DisOrder).First().sxzy,
                    b.csd,
                    ztLabel = b.enuZt.Label,
                    ypzly = b.enuLaiy.Label,
                };
        if (Query != null) {
            q = q.Where(o => Query.Contains(o.UserID));
        }
        return q;
    }
    protected void ObjGrid_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        string id = sender.ToString();
        Image Inforpt = (Image)e.Row.FindControl("Inforpt");
        Inforpt.Attributes["onclick"] = "javascript:PopWin('InfoRpt.aspx?id=@id','rpt',700,680,'c');".Replace("@id", id);

        HyperLink PName = (HyperLink)e.Row.FindControl("PName");
        PName.ToolTip = "点击可以查看简历详细信息";
        PName.Text = DataBinder.Eval(e.Row.DataItem, "PName", "");
        PName.NavigateUrl = "javascript:PopWin('ViewInfo.aspx?es=open&id=@id','df',750,680,'c');".Replace("@id", id);
    }
    private bool DeleteItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable<BaseInfo> item = db.BaseInfo.Where(o => ObjGrid.SelectedRows.Contains(o.UserID));
        db.BaseInfo.DeleteAllOnSubmit(item);
        db.SubmitChanges();
        return true;
    }
    protected void btnSetzf_Click(object sender, EventArgs e)
    {
        if (ObjGrid.SelectedRows.Count > 0) {
            try {
                SetzfItem();
                ObjGrid.SelectedRows.Clear();
                ObjGrid.FillGrid(GetQuery(true));
                WebHelper.AlertMsg("你选择的记录已经被设置为作废！", ClientScript);
            }
            catch (Exception ex) {
                WebHelper.AlertMsg(ex.Message, ClientScript);
            }
        }
        else {
            WebHelper.AlertMsg("请先选择你要设置作废的记录！", ClientScript);
        }
    }
    private bool SetzfItem()
    {
        string sql = "Update BaseInfo Set zfflag = 'True' Where UserID In (@UserID)";
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
    private bool Setzt()
    {
        string sql = "Update BaseInfo Set zt = @zt Where UserID In (@UserID)";
        string userid = "";
        foreach (int id in ObjGrid.SelectedRows) {
            userid += id.ToString() + ",";
        }
        if (userid.Length > 0) userid = userid.Substring(0, userid.Length - 1);
        sql = sql.Replace("@UserID", userid);
        sql = sql.Replace("@zt", ztlist.SelectedValue);
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        db.ExecuteCommand(sql);
        return true;
    }
    protected void btnSetzt_Click(object sender, EventArgs e)
    {
        if (ObjGrid.SelectedRows.Count > 0) {
            try {
                Setzt();
                SendEmailToUser();
                ObjGrid.SelectedRows.Clear();
                ObjGrid.FillGrid(GetQuery(true));
                WebHelper.AlertMsg("设置成功！", ClientScript);
            }
            catch (Exception ex) {
                WebHelper.AlertMsg(ex.Message, ClientScript);
            }
        }
        else {
            WebHelper.AlertMsg("请先选择你要设置的简历！", ClientScript);
        }
    }
    private void SendEmailToUser()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable<BaseInfo> items = db.BaseInfo.Where(o => ObjGrid.SelectedRows.Contains(o.UserID));
        string from = "rczp@smedi.com";
        string title = "上海市政工程设计研究总院（集团）有限公司面试通知";
        SmtpClient sc = new SmtpClient("smedi-server04.smedi.com");
        MailMessage me;
        try {
            foreach (BaseInfo user in items) {
                string body = user.PName + " 您好：" + Environment.NewLine + "您投递给我院的简历已阅读，您" + user.enuZt.Label + "。" + Environment.NewLine + "相关人员将会与您联系面试事宜。";
                me = new MailMessage(from, user.email, title, body);
                sc.Send(me);
            }
        }
        catch {
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (ObjGrid.SelectedRows.Count > 0) {
            try {
                foreach (int id in ObjGrid.SelectedRows) {
                    AppHelper.ExportDoc(id);
                }
                ObjGrid.SelectedRows.Clear();
                ObjGrid.FillGrid(GetQuery(true));
                WebHelper.AlertMsg("导出成功！\\r\\n请访问服务器上[简历导出]目录。", ClientScript);
            }
            catch (Exception ex) {
                WebHelper.AlertMsg(ex.Message, ClientScript);
            }
        }
        else {
            WebHelper.AlertMsg("请先选择你要导出的简历！", ClientScript);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        WebHelper.WriteScript("window.location.href='FindCond.aspx';", ClientScript);
    }
}