using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_PostJob2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["type"].Equals("4"))
            {
                display.Visible = true;
                dropdwonlist.Visible = true;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("职位名称", typeof(string)));
            dt.Columns.Add(new DataColumn("工作地点", typeof(string)));
            dt.Columns.Add(new DataColumn("学历要求", typeof(string)));
            dt.Columns.Add(new DataColumn("招聘人数", typeof(string)));
            DataRow dr;
            for (int i = 0; i < 10; i++)
            {
                dr = dt.NewRow();
                dr.ItemArray = new object[]{"","","",""};
                dt.Rows.Add(dr);
            }
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
    }
    protected void onClickAdd(object sender, EventArgs e)
    {
        DataTable dt = readGridView();
        DataRow dr = dt.NewRow();
        dr.ItemArray = new object[] {"","","","" };
        dt.Rows.Add(dr);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
    private DataTable readGridView()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("职位名称",typeof(string)));
        dt.Columns.Add(new DataColumn("工作地点",typeof(string)));
        dt.Columns.Add(new DataColumn("学历要求",typeof(string)));
        dt.Columns.Add(new DataColumn("招聘人数",typeof(string)));

        for(int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            dr = dt.NewRow();

            dr[0] = ((TextBox)(this.GridView1.Rows[i].Cells[0].FindControl("TextBox1"))).Text.Trim();
            dr[1] = ((TextBox)(this.GridView1.Rows[i].Cells[1].FindControl("TextBox2"))).Text.Trim();
            dr[2] = ((TextBox)(this.GridView1.Rows[i].Cells[2].FindControl("TextBox3"))).Text.Trim();
            dr[3] = ((TextBox)(this.GridView1.Rows[i].Cells[3].FindControl("TextBox4"))).Text.Trim();
            dt.Rows.Add(dr);
            
        }
        return dt;
    }
    protected void onClickSubmit(object sender, EventArgs e)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            string sql = "insert Career (ctype,cname,cpot,ceducation,cnumber,cdisplay,cvalid,ctime) Values (@type,'@name','@pot','@education',@num,@display,@valid,'@time')";
            if (!((TextBox)(this.GridView1.Rows[i].Cells[0].FindControl("TextBox1"))).Text.Trim().Equals(""))
            {
                sql = sql.Replace("@type", Request["type"]);
                sql = sql.Replace("@name", ((TextBox)(this.GridView1.Rows[i].Cells[0].FindControl("TextBox1"))).Text.Trim());
                sql = sql.Replace("@pot", ((TextBox)(this.GridView1.Rows[i].Cells[1].FindControl("TextBox2"))).Text.Trim());
                sql = sql.Replace("@education", ((TextBox)(this.GridView1.Rows[i].Cells[2].FindControl("TextBox3"))).Text.Trim());
                sql = sql.Replace("@num", ((TextBox)(this.GridView1.Rows[i].Cells[3].FindControl("TextBox4"))).Text.Trim());
                if (Request["type"].Equals("4"))
                {
                    if (dropdwonlist.SelectedItem.Text.Equals("是"))
                        sql = sql.Replace("@display", "1");
                    else
                        sql = sql.Replace("@dispay", "0");
                }
                else
                    sql = sql.Replace("@display", "1");
                sql = sql.Replace("@valid", "1");
                sql = sql.Replace("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
               

            }
            else
                break;
            db.ExecuteCommand(sql);
            Response.Redirect(Request.Url.ToString());
        }
    }
}