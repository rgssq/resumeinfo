using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class Pages_JobShowCategory : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["Major"] = "";
            ViewState["Pot"] = "";
            setBlock("","");
            
        }
        int skipcnt = int.Parse(ViewState["CurBlock"].ToString()) * int.Parse(ViewState["PageSize"].ToString());
        IQueryable q = getJobOnCondition(skipcnt, int.Parse(ViewState["PageSize"].ToString()), "", "");
        fillPage(q);
    }
    private void setBlock(string major,string pot)
    {
        if (ViewState["PageSize"] == null) ViewState["PageSize"] = 20;
       
        ViewState["FirstBlock"] = 0;
        ViewState["CurBlock"] = 0;
        ViewState["PreBlock"] = 0;
        int count = getJobCountOnCondition(major, pot);
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
    private void fillPage(IQueryable query)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("职位名称"));
        dt.Columns.Add(new DataColumn("地区"));
        dt.Columns.Add(new DataColumn("职位号"));
        dt.Columns.Add(new DataColumn("详情"));
        dt.Columns.Add(new DataColumn("申请"));
        switch (Request["type"])
        {
            case "1": Label1.Text = "社会招聘";break;
            case "2": Label1.Text = "实习生招聘"; break;
            case "3": Label1.Text = "校园招聘";break;
            case "4": Label1.Text = "暑期实习生招聘计划"; break;
            default: break;
        }
        int skipcnt = int.Parse(ViewState["CurBlock"].ToString())*int.Parse(ViewState["PageSize"].ToString());
        
        foreach (object n in query)
        {
            DataRow dr = dt.NewRow();
            dr[0] = DataBinder.Eval(n, "cname", "");
            dr[1] = DataBinder.Eval(n, "cpot", "");
            dr[2] = DataBinder.Eval(n,"cid","");
            dr[3] = "JobShowApplicant.aspx?type=" + Request["type"] + "&id=" + DataBinder.Eval(n, "cid", "");
            if ((Session["UserID"] != null) && applied(DataBinder.Eval(n, "cid", "")))
                dr[4] = "已申请";
            else
                dr[4] = "申请";
            dt.Rows.Add(dr);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private int getJobCountOnCondition(string major,string pot)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (major.Equals("") && pot.Equals(""))
        {
            if(Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Count();
            return (from m in db.Career
                    where m.ctype == int.Parse((Request["type"])) && m.cvalid == true
                    select new { m.cid, m.cname, m.cpot }).Count();

        }
        else if (major.Equals("") && !pot.Equals(""))
        {
            if (Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cpot.Contains(pot) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Count();
            return (from m in db.Career
                    where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cpot.Contains(pot)
                    select new { m.cid, m.cname, m.cpot }).Count();
        }
        else if (!major.Equals("") && pot.Equals(""))
        {
            if ((Request["type"] == "1") || (Request["type"] == "2"))
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cquality.Contains(major)
                        select new { m.cid, m.cname, m.cpot }).Count();
            else if (Request["type"] == "4")
            {
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Count();
            }
            else
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major)
                        select new { m.cid, m.cname, m.cpot }).Count();
        }
        else
        {
            if ((Request["type"] == "1") || (Request["type"] == "2"))
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cquality.Contains(major) && m.cpot.Contains(pot)
                        select new { m.cid, m.cname, m.cpot }).Count();
            else if(Request["type"] == "3")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cpot.Contains(pot) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Count();
            else
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cpot.Contains(pot)
                        select new { m.cid, m.cname, m.cpot }).Count();
        }
    }

    private IQueryable getJobOnCondition(int skipcnt, int pagecnt,string major,string pot)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (major.Equals("") && pot.Equals(""))
        {
            if(Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            return (from m in db.Career
                    where m.ctype == int.Parse((Request["type"])) && m.cvalid == true
                    select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
        }
        else if (major.Equals("") && !pot.Equals(""))
        {
            if (Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cpot.Contains(pot) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            return (from m in db.Career
                    where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cpot.Contains(pot)
                    select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);

        }
        else if (!major.Equals("") && pot.Equals(""))
        {
            if ((Request["type"] == "1") || (Request["type"] == "2"))
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cquality.Contains(major)
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            else if (Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            else
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major)
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
        }
        else
        {
            if ((Request["type"] == "1") || (Request["type"] == "2"))
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.cquality.Contains(major) && m.cpot.Contains(pot)
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            else if (Request["type"] == "4")
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cpot.Contains(pot) && m.cdisplay == true
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
            else
                return (from m in db.Career
                        where m.ctype == int.Parse((Request["type"])) && m.cvalid == true && m.ceducation.Contains(major) && m.cpot.Contains(pot)
                        select new { m.cid, m.cname, m.cpot }).Skip(skipcnt).Take(pagecnt);
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
        IQueryable q = getJobOnCondition(skipcnt, int.Parse(ViewState["PageSize"].ToString()), ViewState["Major"].ToString(), ViewState["Pot"].ToString());
        fillPage(q);
    }
    protected void  searchResult(object sender,EventArgs e)
    {
        setBlock(searchMajor.Text, searchPot.Text);
        int skipcnt = int.Parse(ViewState["CurBlock"].ToString()) * int.Parse(ViewState["PageSize"].ToString());
        IQueryable q = getJobOnCondition(skipcnt, int.Parse(ViewState["PageSize"].ToString()), searchMajor.Text, searchPot.Text);
        fillPage(q);
        ViewState["Major"] = searchMajor.Text;
        ViewState["Pot"] = searchPot.Text;
        searchPot.Text = "";
        searchPot.Text = "";
    }
    protected void LbApply_Onclick(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            WebHelper.AlertMsg("请先登录！", ClientScript);
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
                    string body = "    用户（" + user.PID + ")已申请 ";
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