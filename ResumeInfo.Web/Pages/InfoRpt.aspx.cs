#region Using...
using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Linq;
using System.Web.UI;
#endregion

public partial class ViewInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
           
            int id = 0;
            if (Request.QueryString["id"] != null) {
                if (int.Parse(Session["UserType"].ToString()) > 1) {
                    Response.Redirect("~/NoUser.htm");
                }
                id = int.Parse(Request.QueryString["id"]);
            }
            else {
                id = int.Parse(Session["UserID"].ToString());
            }
            ViewState["userid"] = id;
            imgPhoto.ImageUrl = "ShowPhoto.aspx?id=" + id;
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            FillForm(db, id);
            gvJybj.FillGrid(JybjQuery(db, id));
            gvZyzg.FillGrid(ZyzgQuery(db, id));
            gvGzsx.FillGrid(GzsxQuery(db, id));

            gvJtshgx.FillGrid(JtshgxQuery(db, id));
            gvFileInfo.FillGrid(FileInfoQuery(db, id));
        }
    }
    private void FillForm(ResumeInfoDataContext db, int id)
    {
        BaseInfo item = db.BaseInfo.Single(p => p.UserID == id);
        WebHelper.BindObjectToControls(item, PanField);
        csrq.Text = WebHelper.ShortDateTime(item.csrq);
        FindEnuLabel(db);
    }
    private void FindEnuLabel(ResumeInfoDataContext db)
    {
        GetEnuLabel(Sex, db, typeof(enuSex));
        GetEnuLabel(zzmm, db, typeof(enuZzmm));
        GetEnuLabel(hyzk, db, typeof(enuHyzk));

        GetEnuLabel(qwxc, db, typeof(enuQwyx));

        GetEnuLabel(zc, db, typeof(enuZc));
        GetEnuLabel(gzdd1, db, typeof(enuGzdd));
        GetEnuLabel(gzdd2, db, typeof(enuGzdd));
        GetEnuLabel(gzdd3, db, typeof(enuGzdd));
    }
    private void GetEnuLabel(Label lb, DataContext db, Type enutable)
    {
        if (lb.Text != "") {
            IQueryable q = db.GetTable(enutable).Where("PKID == " + lb.Text).Select("new(Label)");
            foreach (object o in q) {
                lb.Text = DataBinder.Eval(o, "Label", "");
            }
        }
    }
    private IQueryable JybjQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.Jiaoybj
                       where p.UserID == id
                       orderby p.enuJyjd.DisOrder
                       select new {
                           p.PKID,
                           jyjd = p.enuJyjd.Label,
                           p.kssj,
                           p.jssj,
                           p.byyx,
                           p.sxzy,
                           p.ds,
                       };
        return q;
    }
    private IQueryable ZyzgQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.Zhiyzg
                       where p.UserID == id
                       orderby p.hdsj
                       select new {
                           p.PKID,
                           zgmc = p.enuZg.Label,
                           p.hdsj,
                           p.zcd,
                       };
        return q;
    }
    private IQueryable GzsxQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.Gongzsx
                       where p.UserID == id
                       orderby p.enuGzsxlb.DisOrder
                       select new {
                           p.PKID,
                           lb = p.enuGzsxlb.Label,
                           p.kssj,
                           p.jssj,
                           p.dw,
                           p.cszy,
                           p.bmjzw,
                           p.zmr,
                       };
        return q;
    }
    private IQueryable GzsxnrQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.Gongzsx
                       where p.UserID == id
                       orderby p.enuGzsxlb.DisOrder
                       select new
                       {
                           p.PKID,
                           lb = p.enuGzsxlb.Label,
                           p.kssj,
                           p.jssj,
                           p.sxnr
                       };
        return q;
    }
    private IQueryable JtshgxQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.Jiatshgx
                       where p.UserID == id
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
    private IQueryable FileInfoQuery(ResumeInfoDataContext db, int id)
    {
        IQueryable q = from p in db.FileInfo
                       where p.UserID == id
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
    protected void gvFileInfo_ItemRowBound(object sender, GridViewRowEventArgs e)
    {
        string id = sender.ToString();
        HyperLink FName = (HyperLink)e.Row.FindControl("FName");
        FName.ToolTip = "点击可以下载该附件";
        FName.Text = DataBinder.Eval(e.Row.DataItem, "FName", "");
        FName.NavigateUrl = "javascript:PopWinFix('DownFile.aspx?id=@id','df',300,100,'c');".Replace("@id", id);
    }
    protected void gvFileInfo_Sorting(object sender, GridViewSortEventArgs e)
    {
    }
 
    private void CheckJybj(int id)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int count = db.Jiaoybj.Where(o => o.UserID == id).Count();
        if (count == 0) {
            throw new Exception("您没有填写“教育背景”信息，不能提交简历！");
        }
    }
}