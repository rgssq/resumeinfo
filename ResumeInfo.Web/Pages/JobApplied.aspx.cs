using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_JobApplied : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WebHelper.IsSessionValid(Session, Response);
            setBlock();
            int skipcnt = int.Parse(ViewState["CurBlock"].ToString()) * int.Parse(ViewState["PageSize"].ToString());
            IQueryable q = getApplied(skipcnt, int.Parse(ViewState["PageSize"].ToString()));
            fillPage(q);
        }
    }
    protected void fillPage(IQueryable query)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("招聘类型"));
        dt.Columns.Add(new DataColumn("职位名称"));
        dt.Columns.Add(new DataColumn("详情"));
        dt.Columns.Add(new DataColumn("地区"));
        dt.Columns.Add(new DataColumn("状态"));
        
        int skipcnt = int.Parse(ViewState["CurBlock"].ToString()) * int.Parse(ViewState["PageSize"].ToString());

        foreach (object n in query)
        {
            DataRow dr = dt.NewRow();
            dr[0] = DataBinder.Eval(n, "typename", "");
            dr[1] = DataBinder.Eval(n, "cname", "");
            dr[2] = "JobShowApplicant.aspx?type=" + DataBinder.Eval(n,"ctype","") + "&id=" + DataBinder.Eval(n, "cid", "");
            dr[3] = DataBinder.Eval(n, "cpot", "");
            

            if (DataBinder.Eval(n,"cvalid","").Equals("True"))
                dr[4] = "正在招聘";
            else
                dr[4] = "已过期";
            dt.Rows.Add(dr);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private IQueryable getApplied(int skipcnt, int pagecnt)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int uid = int.Parse(Session["UserID"].ToString());
        IQueryable q = (from m in db.Application
                       where m.auid == uid
                       select new { typename=m.Career.enuCtype.Name, cname=m.Career.cname, cpot=m.Career.cpot, cvalid=m.Career.cvalid, ctype=m.Career.ctype, cid=m.Career.cid }).Skip(skipcnt).Take(pagecnt);
        return q;
    }
    private int getAppliedCount()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int uid = int.Parse(Session["UserID"].ToString());
        return db.Application.Count(p => p.auid == uid);
    }
    private void setBlock()
    {
        if (ViewState["PageSize"] == null) ViewState["PageSize"] = 20;

        ViewState["FirstBlock"] = 0;
        ViewState["CurBlock"] = 0;
        ViewState["PreBlock"] = 0;
        int count = getAppliedCount();
        if (count > int.Parse(ViewState["PageSize"].ToString()))
        {
            ViewState["NextBlock"] = 1;
            ViewState["FinalBlock"] = (count - 1) / int.Parse(ViewState["PageSize"].ToString());
        }
        else
        {
            ViewState["NextBlock"] = 0;
            ViewState["FinalBlock"] = 0;
        }


    }
    protected void showPage(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        
        switch (lb.ID.ToString())
        {
            case "firstPage":
                ViewState["CurBlock"] = 0;
                ViewState["PreBlock"] = 0;
                if (int.Parse(ViewState["FinalBlock"].ToString()) > 0)
                    ViewState["NextBlock"] = 1;
                else
                    ViewState["NextBlock"] = 0;  
                break;
            case "previousPage":
                ViewState["CurBlock"] = ViewState["PreBlock"];
                if (int.Parse(ViewState["PreBlock"].ToString()) > 0)
                {
                    ViewState["NextBlock"] = int.Parse(ViewState["CurBlock"].ToString()) + 1;
                    ViewState["PreBlock"] = int.Parse(ViewState["PreBlock"].ToString()) - 1;
                }
                else
                {

                }
                break;
            case "nextPage":
                ViewState["CurBlock"] = ViewState["NextBlock"];
                if (int.Parse(ViewState["NextBlock"].ToString()) < int.Parse(ViewState["FinalBlock"].ToString()))
                {
                    ViewState["PreBlock"] = int.Parse(ViewState["CurBlock"].ToString()) - 1;
                    ViewState["NextBlock"] = int.Parse(ViewState["NextBlock"].ToString()) + 1;
                }
                break;
            case "finalPage":
                ViewState["CurBlock"] = ViewState["FinalBlock"];
                ViewState["NextBlock"] = ViewState["FinalBlock"];
                if (int.Parse(ViewState["FinalBlock"].ToString()) > 0)
                    ViewState["PreBlock"] = int.Parse(ViewState["FinalBlock"].ToString()) - 1;
                else
                    ViewState["PreBlock"] = 0;
                break;
            default: break;
        }
       
        int skipcnt = int.Parse(ViewState["CurBlock"].ToString()) * int.Parse(ViewState["PageSize"].ToString());
        IQueryable q = getApplied(skipcnt, int.Parse(ViewState["PageSize"].ToString()));
        fillPage(q);
    }
}