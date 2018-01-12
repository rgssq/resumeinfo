using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Attention : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
           string type= Session["UserType"].ToString();
           if ((type == "1") || (type == "2"))
            {
                foreach (object m in GetAttention(int.Parse(type)))
                {
                    attention.Text = DataBinder.Eval(m, "acontent", "");
                }

            }
            else
            {
             
            }
       
    }

    private IQueryable GetAttention(int aid)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        q = from m in db.Attention
            where (m.aid == aid)
            select new { m.acontent };
        return q;
    }

}