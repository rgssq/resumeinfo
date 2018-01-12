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
        if (!Page.IsPostBack)
        {


            string type = Session["UserType"].ToString();

            if (type == "0")
            {
                if (Request["Page"] == "2")
                {
                    editAttention.Visible = true;
                    editAttention.Attributes["Click"] = "javascript:if (window.confirm('你确定要修改公告吗？')) { $find('PopUp').show(); } else { return false; }";
                    cancelEdit.Visible = true;
                    cancelEdit.Attributes["Click"] = "javascript:if (window.confirm('你确定要取消修改吗？')) { $find('PopUp').show(); } else { return false; }";
                    foreach (object m in GetAttention(int.Parse(Request["Page"])))
                    {
                        outerAttention.Text = DataBinder.Eval(m, "acontent", "").Replace("<br>", "\r\n");
                    }
                    outerAttention.Visible = true;
                }
                else if (Request["Page"] == "1")
                {

                    editAttention.Visible = true;
                    editAttention.Attributes["Click"] = "javascript:if (window.confirm('你确定要修改公告吗？')) { $find('PopUp').show(); } else { return false; }";
                    cancelEdit.Visible = true;
                    cancelEdit.Attributes["Click"] = "javascript:if (window.confirm('你确定要取消修改吗？')) { $find('PopUp').show(); } else { return false; }";
                    foreach (object m in GetAttention(int.Parse(Request["Page"])))
                    {
                        interiorAttention.Text = DataBinder.Eval(m, "acontent", "").Replace("<br>", "\r\n");
                    }
                    interiorAttention.Visible = true;
                }
                else
                {

                }

            }
        }  
        
    }
    protected void editAttentionClick(object sender, EventArgs e)
    {
        string page = Request["Page"];
        string sql = "Update Attention Set acontent = '@acontent' where aid = @aid";
        string content;
        if (page == "1")
            content = interiorAttention.Text;
        else
            content = outerAttention.Text;
        content = content.Replace("\r\n", "<br>");
        sql = sql.Replace("@acontent", content);
        sql = sql.Replace("@aid", page);
        WebHelper.AlertMsg(sql, ClientScript);
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        db.ExecuteCommand(sql);
    }
    protected void cancelEditClick(object sender, EventArgs e)
    {
        string page = Request["page"];
        if (page == "1")
        {
            foreach (object m in GetAttention(int.Parse(page)))
            {
                interiorAttention.Text = DataBinder.Eval(m, "acontent", "");
            }
        }
        else
        {
            foreach (object m in GetAttention(int.Parse(page)))
            {
                outerAttention.Text = DataBinder.Eval(m, "acontent", "");
            }
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