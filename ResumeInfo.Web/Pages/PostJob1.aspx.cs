using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Pages_PostJob1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
            ArrayList ar = new ArrayList();
            foreach(object m in getDept()){
                ar.Add(DataBinder.Eval(m,"dname",""));
            }
            department.List.DataSource = ar;
            department.List.DataBind();
        }
    }
    protected void post_Click(object sender, EventArgs e)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        string sql = "insert Career (cdept,cmail,ctransfer,cname,cpot,ccontent,cquality,ctype,cvalid,ctime) Values (@id,'@mail',@transfer,'@name','@pot','@content','@quality',@type,@valid,'@time')";
        sql=sql.Replace("@id", getDeptId(department.List.SelectedItem.Text));
        sql=sql.Replace("@mail",email.Text);
        if(transfer.SelectedItem.Text.Equals("是"))
            sql=sql.Replace("@transfer","1");
        else
            sql=sql.Replace("@transfer","0");
        sql=sql.Replace("@name",jobname.Text);
        sql=sql.Replace("@pot",location.Text);
        sql = sql.Replace("@content", responsbility.Text.Replace("\r\n", "<br>"));
        sql = sql.Replace("@quality", quality.Text.Replace("\r\n", "<br>"));
        sql=sql.Replace("@type",Request["type"]);
        sql = sql.Replace("@valid", "1");
        sql = sql.Replace("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        db.ExecuteCommand(sql);
        
        Response.Redirect(Request.Url.ToString());

    }
    private IQueryable getDept()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        q = from m in db.Department
            orderby m.did
            select new {m.did,m.dname};
        return q;
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

}