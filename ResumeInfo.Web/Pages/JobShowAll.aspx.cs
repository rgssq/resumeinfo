
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class Pages_JobShowAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillPage();
        }
    }
    protected void FillPage()
    {
        List<Control> lctrl = new List<Control>();
        lctrl.Add(a3);
        lctrl.Add(a1);
        lctrl.Add(a2);
        lctrl.Add(a4);
        List<Control> llabel = new List<Control>();
        llabel.Add(Label3);
        llabel.Add(Label4);
        llabel.Add(Label2);
        llabel.Add(Label5);
        List<GridView> lgrid = new List<GridView>();
        lgrid.Add(GridView2);
        lgrid.Add(GridView3);
        lgrid.Add(GridView1);
        lgrid.Add(GridView4);
        for(int i = 0; i < 4 ; i++)
        {
            if (getJobCount(i + 1) > 0)
            {

                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn("职位名称"));
                dt.Columns.Add(new DataColumn("详情"));
                dt.Columns.Add(new DataColumn("地区"));
                dt.Columns.Add(new DataColumn("职位号"));
                dt.Columns.Add(new DataColumn("申请"));
                lctrl[i].Visible = true;
                foreach (object n in getJob(i + 1))
                {
                   
                    DataRow dr = dt.NewRow();
                    dr[0] = DataBinder.Eval(n, "cname", "");
                    dr[1] = "JobShowApplicant.aspx?type=" + Convert.ToString(i+1) + "&id=" + DataBinder.Eval(n, "cid", "");
                    dr[2] = DataBinder.Eval(n, "cpot", "");
                    dr[3] = DataBinder.Eval(n,"cid","");
                    if ((Session["UserID"] != null) && applied(DataBinder.Eval(n, "cid", "")))
                        dr[4] = "已申请";
                    else
                        dr[4] = "申请";
                    dt.Rows.Add(dr);
                }
                lgrid[i].DataSource = dt;
                lgrid[i].DataBind();

            }
            else
            {
                lctrl[i].Visible = false;
                llabel[i].Visible = false;
                
            }
        }
       
    }
    private int getJobCount(int type)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (type == 4)
            return (from m in db.Career
                    where m.ctype == type && m.cvalid == true && m.cdisplay == true
                    orderby m.ctime descending
                    select new { m.cname, m.cpot, m.cid }).Count();
        return (from m in db.Career
                where m.ctype == type && m.cvalid == true
                orderby m.ctime descending
                select new { m.cname, m.cpot, m.cid }).Count();
    }
    private IQueryable getJob(int type)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        if (type == 4)
            q = (from m in db.Career
                 where m.ctype == type && m.cvalid == true && m.cdisplay == true
                 orderby m.ctime descending
                 select new { m.cname, m.cpot, m.cid }).Take(2);
        else
            q = (from m in db.Career
                 where m.ctype == type && m.cvalid == true
                 orderby m.ctime descending
                 select new { m.cname, m.cpot, m.cid }).Take(2);
        return q;
    }
    protected void LbApply_Onclick(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            WebHelper.AlertMsg("请先登录！至我的简历->在招岗位中查看", ClientScript);
        }
        else
        {
            LinkButton lb = (LinkButton)sender;
            applyJob(lb.CommandArgument);
        }
    }
    private void applyJob(string job)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int cid = int.Parse(job);
        int uid = int.Parse(Session["UserID"].ToString());
        if (db.Application.Count(p => p.acid == cid && p.auid == uid) > 0)
            WebHelper.AlertMsg("已申请该岗位，无法重复申请！", ClientScript);
        else
        {
            Application app = new Application();
            app.acid = cid;
            app.auid = uid;
            db.Application.InsertOnSubmit(app);
            db.SubmitChanges();
            WebHelper.AlertMsg("您已申请成功，请至已申请岗位查看", ClientScript);
            
            IQueryable<BaseInfo> items = db.BaseInfo.Where(o => o.UserID == uid).Take(1);
            IQueryable<Career> careers = db.Career.Where(o => o.cid == cid).Take(1);
            string from = "rczp@smedi.com";
            string title = "上海市政工程设计研究总院（集团）有限公司岗位申请";
            SmtpClient sc = new SmtpClient("smedi-server04.smedi.com");
            MailMessage me;
            try
            {
                foreach (BaseInfo user in items)
                {
                    string body = "    用户（" + user.PID+")已申请 ";
                    foreach (Career career in careers)
                    {
                        if (career.ctransfer == true && !career.cmail.Equals(""))
                        {
                            string body1 = body + career.enuCtype.Name + "中的" + career.cname + "岗位，请及时审核。";
                            me = new MailMessage(from, career.cmail, title, body1);
                            sc.Send(me);
                        }
                        else
                            break;
                    }
                    
                }
            }
            catch
            {
            }
        }
    }
    private bool applied(string job)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int cid = int.Parse(job);
        int uid = int.Parse(Session["UserID"].ToString());
        if (db.Application.Count(p => p.acid == cid && p.auid == uid) > 0)
            return true;
        return false;

    }

    
}