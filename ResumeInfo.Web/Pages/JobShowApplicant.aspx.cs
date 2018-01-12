using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_JobShowApplicant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if ((Request["type"].Equals("1") || Request["type"].Equals("2")) && (!Request["id"].Equals("")))
            {
                foreach (object n in getCarrer(Request["type"], int.Parse(Request["id"])))
                {
                    department1.Visible = true;
                    department2.Text = DataBinder.Eval(n, "dname", "");
                    department2.Visible = true;
                    
                    name1.Visible = true;
                    name2.Text = DataBinder.Eval(n, "cname", "");
                    name2.Visible = true;
                    pot1.Visible = true;
                    pot2.Text = DataBinder.Eval(n, "cpot", "");
                    pot2.Visible = true;
                    responsbility1.Visible = true;
                    responsbility2.Text = DataBinder.Eval(n, "ccontent", "");
                    responsbility2.Visible = true;
                    quality1.Visible = true;
                    quality2.Text = DataBinder.Eval(n, "cquality", "");
                    quality2.Visible = true;
                }
            }
            else if ((Request["type"].Equals("3") || Request["type"].Equals("4")) && (!Request["id"].Equals("")))
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
            else
                ;
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
                select new { dname = m.Department.dname,  m.cname, m.cpot, m.ccontent, m.cquality };
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
   
}