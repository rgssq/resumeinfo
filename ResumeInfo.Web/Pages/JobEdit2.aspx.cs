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
            if ((Request["type"].Equals("3")) && (!Request["id"].Equals("")) && int.Parse(Session["UserType"].ToString()) < 2)
            {
                foreach (object n in getCarrer(Request["type"], int.Parse(Request["id"])))
                {
                    name1.Visible = true;
                    name2.Text = DataBinder.Eval(n, "cname", "");
                    name2.Visible = true;
                    pot1.Visible = true;
                    pot2.Text = DataBinder.Eval(n, "cpot", "");
                    pot2.Visible = true;
                    education1.Visible = true;
                    education2.Text = DataBinder.Eval(n, "ceducation", "");
                    education2.Visible = true;
                    number1.Visible = true;
                    number2.Text = DataBinder.Eval(n, "cnumber", "");
                    number2.Visible = true;


                }
            }
            else if ((Request["type"].Equals("4")) && (!Request["id"].Equals("")) && int.Parse(Session["UserType"].ToString()) < 2)
            {
                display.Visible = true;
                dropdownlist.Visible = true;
                foreach (object n in getCarrer(Request["type"], int.Parse(Request["id"])))
                {
                    name1.Visible = true;
                    name2.Text = DataBinder.Eval(n, "cname", "");
                    name2.Visible = true;
                    pot1.Visible = true;
                    pot2.Text = DataBinder.Eval(n, "cpot", "");
                    pot2.Visible = true;
                    education1.Visible = true;
                    education2.Text = DataBinder.Eval(n, "ceducation", "");
                    education2.Visible = true;
                    number1.Visible = true;
                    number2.Text = DataBinder.Eval(n, "cnumber", "");
                    number2.Visible = true;
                    if (DataBinder.Eval(n, "cdisplay", "").Equals("True"))
                        dropdownlist.SelectedIndex = 0;
                    else
                        dropdownlist.SelectedIndex = 1;

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
                select new { m.cname, m.cpot, m.ceducation, m.cnumber,m.cdisplay};
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
       
       if (Request["type"].Equals("3") || Request["type"].Equals("4"))
        {
            if(Request["type"].Equals("3"))
                sql = "Update Career set cname='@name',cpot='@pot',ceducation='@education',cnumber='@number',ctime='@time' where cid = @id";
            else
            {
                 sql = "Update Career set cname='@name',cpot='@pot',ceducation='@education',cnumber='@number',ctime='@time',cdisplay=@display where cid = @id";
                 if (dropdownlist.SelectedItem.Text.Equals("是"))
                     sql = sql.Replace("@display", "1");
                 else
                     sql = sql.Replace("@display", "0");
            }
            sql = sql.Replace("@name", name2.Text);
            sql = sql.Replace("@pot", pot2.Text);
            sql = sql.Replace("@education", education2.Text);
            sql = sql.Replace("@number", number2.Text);
            sql = sql.Replace("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sql = sql.Replace("@id", Request["id"]);

            db.ExecuteCommand(sql);
            Response.Redirect("~/Pages/JobMgt.aspx?type=" + Request["type"]);
            
        }

       
    }
}