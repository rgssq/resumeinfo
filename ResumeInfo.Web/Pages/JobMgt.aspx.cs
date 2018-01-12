using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_JobMgt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            createJobList();
            createHisJobList();
        }
    }
    private void createJobList()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("职位名称", typeof(string)));
        dt.Columns.Add(new DataColumn("地区", typeof(string)));
        dt.Columns.Add(new DataColumn("发布时间",typeof(string)));
        dt.Columns.Add(new DataColumn("收到简历", typeof(string)));
        dt.Columns.Add(new DataColumn("查看", typeof(string)));
        dt.Columns.Add(new DataColumn("修改", typeof(string)));
        dt.Columns.Add(new DataColumn("停止", typeof(string)));
        int type = int.Parse(Request["type"]);
        foreach (object m in getJobList(type, true))
        {
            DataRow dr = dt.NewRow();
            dr[0] = DataBinder.Eval(m, "cname", "");
            dr[1] = DataBinder.Eval(m, "cpot", "");
            dr[2] = DataBinder.Eval(m, "ctime", "").Split()[0];
            dr[3] = "ResumeRecv.aspx?cid=" + DataBinder.Eval(m, "cid", "");
            dr[4] = "JobShow.aspx?type=" + DataBinder.Eval(m, "ctype", "") + "&id=" + DataBinder.Eval(m, "cid", "");
            if(DataBinder.Eval(m,"ctype","").Equals("1") || DataBinder.Eval(m,"ctype","").Equals("2"))
                dr[5] = "JobEdit1.aspx?type=" + DataBinder.Eval(m, "ctype", "") + "&id=" + DataBinder.Eval(m, "cid", "");
            else
                dr[5] = "JobEdit2.aspx?type=" + DataBinder.Eval(m, "ctype", "") + "&id=" + DataBinder.Eval(m, "cid", "");
            dr[6] = DataBinder.Eval(m,"cid","");
            dt.Rows.Add(dr);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    private void createHisJobList()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("职位名称", typeof(string)));
        dt.Columns.Add(new DataColumn("地区", typeof(string)));
        dt.Columns.Add(new DataColumn("发布时间", typeof(string)));
        dt.Columns.Add(new DataColumn("收到简历", typeof(string)));
        dt.Columns.Add(new DataColumn("查看", typeof(string)));
        dt.Columns.Add(new DataColumn("重新发布", typeof(string)));
        int type = int.Parse(Request["type"]);
        foreach (object m in getJobList(type, false))
        {
            DataRow dr = dt.NewRow();
            dr[0] = DataBinder.Eval(m, "cname", "");
            dr[1] = DataBinder.Eval(m, "cpot", "");
            dr[2] = DataBinder.Eval(m, "ctime", "").Split()[0];
            dr[3] = "ResumeRecv.aspx?cid="+ DataBinder.Eval(m,"cid","");
            dr[4] = "JobShow.aspx?type=" + DataBinder.Eval(m, "ctype", "") + "&id=" + DataBinder.Eval(m, "cid", "");
            dr[5] = DataBinder.Eval(m, "cid", "");
            dt.Rows.Add(dr);
        }
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    private IQueryable getJobList(int type,bool valid)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        q = from m in db.Career
            where (m.ctype == type && m.cvalid == valid)
            orderby m.ctime descending
            select new { m.cname, m.cpot, m.ctime,m.ctype,m.cid };
        return q;
    }
    protected void cancelJob(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string sql = "Update Career set cvalid=@valid where cid = @id";
        sql = sql.Replace("@valid", "0");
        sql = sql.Replace("@id", lb.CommandArgument);
        db.ExecuteCommand(sql);
        Response.Redirect(Request.Url.ToString());
    }
    protected void rePostJob(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string sql = "Update Career set cvalid=@valid, ctime='@time' where cid = @id";
        sql = sql.Replace("@valid", "1");
        sql = sql.Replace("@id", lb.CommandArgument);
        sql = sql.Replace("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        db.ExecuteCommand(sql);
        Response.Redirect(Request.Url.ToString());
    }
   
}