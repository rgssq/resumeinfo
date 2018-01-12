using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Pages_JobEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if ((Request["type"].Equals("1") || Request["type"].Equals("2")) && (!Request["id"].Equals("")) && int.Parse(Session["UserType"].ToString()) < 2)
            {
                foreach (object n in getCarrer(Request["type"], int.Parse(Request["id"])))
                {
                    department1.Visible = true;
                    ArrayList ar = new ArrayList();
                    foreach (object m in getDept())
                    {
                        ar.Add(DataBinder.Eval(m, "dname", ""));
                    }
                    department2.DataSource = ar;
                    department2.DataBind();
                    department2.SelectedIndex = getDeptIndex(DataBinder.Eval(n, "dname", ""));
                    department2.Visible = true;
                    mail1.Visible = true;
                    mail2.Text = DataBinder.Eval(n, "cmail", "");
                    mail2.Visible = true;
                    transfer1.Visible = true;
                    if (DataBinder.Eval(n, "ctransfer", "").Equals("True"))
                        transfer2.SelectedIndex = 0;
                    else
                        transfer2.SelectedIndex = 1;

                    transfer2.Visible = true;
                    name1.Visible = true;
                    name2.Text = DataBinder.Eval(n, "cname", "");
                    name2.Visible = true;
                    pot1.Visible = true;
                    pot2.Text = DataBinder.Eval(n, "cpot", "");
                    pot2.Visible = true;
                    responsbility1.Visible = true;
                    responsbility2.Text = DataBinder.Eval(n, "ccontent", "").Replace("<br>","\r\n");
                    responsbility2.Visible = true;
                    quality1.Visible = true;
                    quality2.Text = DataBinder.Eval(n, "cquality", "").Replace("<br>", "\r\n");
                    quality2.Visible = true;
                }
            }
        }
        

    }

    private IQueryable getCarrer(string type, int id)
    {
        IQueryable q;
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (type.Equals("1") || type.Equals("2"))
        {
            q = from m in db.Career
                where (m.cid == id)
                select new { dname = m.Department.dname, m.cmail, m.ctransfer, m.cname, m.cpot, m.ccontent, m.cquality };
        }
        else if (type.Equals("3") || type.Equals("4"))
        {
            q = from m in db.Career
                where (m.cid == id)
                select new { m.cname, m.cpot, m.ceducation, m.cnumber };
        }
        else
            q = null;
        return q;
    }
    private IQueryable getDept()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        q = from m in db.Department
            orderby m.did
            select new { m.did, m.dname };
        return q;
    }
    private int getDeptIndex(string dname)
    {
        int index = 0;
        foreach (object n in getDept())
        {
            if (DataBinder.Eval(n, "dname", "").Equals(dname))
                return index;
            else
                index++;
        }
        return 0;
    }
    private string getDeptId(string dname)
    {
        foreach (object m in getDept())
        {
            if (dname.Equals(DataBinder.Eval(m, "dname", "")))
            {
                return DataBinder.Eval(m, "did", "");
            }
        }
        return "-1";
    }
    protected void submit_click(object sender, EventArgs e)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string sql;
        if (Request["type"].Equals("1") || Request["type"].Equals("2"))
        {
            sql = "Update Career set cdept=@dept,cmail='@mail',ctransfer=@transfer,cname='@name',cpot='@pot',ccontent='@content',cquality='@quality',ctime='@time' where cid = @id";
            sql = sql.Replace("@dept", getDeptId(department2.SelectedItem.Text));
            sql = sql.Replace("@mail", mail2.Text);
            if (transfer2.SelectedItem.Text.Equals("是"))
                sql = sql.Replace("@transfer", "1");
            else
                sql = sql.Replace("@transfer", "0");
            sql = sql.Replace("@name", name2.Text);
            sql = sql.Replace("@pot", pot2.Text);
            sql = sql.Replace("@content", responsbility2.Text.Replace("\r\n", "<br>"));
            sql = sql.Replace("@quality", quality2.Text.Replace("\r\n","<br>"));
            sql = sql.Replace("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sql = sql.Replace("@id", Request["id"]);
            db.ExecuteCommand(sql);
            Response.Redirect("~/Pages/JobMgt.aspx?type="+Request["type"]);
        }
       
    }
}