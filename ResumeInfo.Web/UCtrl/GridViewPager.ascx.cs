using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;

public partial class GridViewPager : System.Web.UI.UserControl
{
    public delegate void PageEventHandler();
    public event PageEventHandler PagerClick;
    
    public Unit Width
    {
        get { return PanPager.Width; }
        set { PanPager.Width = value; }
    }

    public IQueryable PagingQuery(IQueryable q, bool Refresh)
    {
        if (ViewState["PageSize"] == null) ViewState["PageSize"] = 10;
        if (Refresh) {
            ViewState["TotalCount"] = q.Count().ToString();
            ViewState["CurrentPage"] = 1;
            txtGoPage.Text = "1";
            PanPager.Visible = !(ViewState["TotalCount"].ToString() == "0");
        }
        if (int.Parse(ViewState["TotalCount"].ToString()) > int.Parse(ViewState["PageSize"].ToString())) {
            int skip = (int.Parse(ViewState["CurrentPage"].ToString()) - 1) * int.Parse(ViewState["PageSize"].ToString());
            q = q.Skip(skip).Take(int.Parse(ViewState["PageSize"].ToString()));
        }
        double pagecount = double.Parse(ViewState["TotalCount"].ToString()) / double.Parse(ViewState["PageSize"].ToString());
        ViewState["PageCount"] = Math.Ceiling(pagecount);
        PageCount.Text = "[<font color='blue'><b>" + ViewState["PageCount"].ToString() + "</b></font>]";
        TotalCount.Text = "总数:[<font color='red'><b>" + ViewState["TotalCount"].ToString() + "</b></font>]";
        return q;
    }
    protected void pager_click(object sender, EventArgs e)
    {
        int cp = int.Parse(ViewState["CurrentPage"].ToString());
        int pcount = int.Parse(ViewState["PageCount"].ToString());
        int gopage = int.Parse(txtGoPage.Text);
        LinkButton lk = (LinkButton)sender;
        switch (lk.ID) {
            case "FirstPage":
                ViewState["CurrentPage"] = 1;
                break;
            case "PrePage":
                ViewState["CurrentPage"] = Math.Max(cp - 1, 1);
                break;
            case "NextPage":
                ViewState["CurrentPage"] = Math.Min(cp + 1, pcount);
                break;
            case "LastPage":
                ViewState["CurrentPage"] = pcount;
                break;
            case "GoPage":
                gopage = Math.Max(gopage, 1);
                gopage = Math.Min(gopage, pcount);
                ViewState["CurrentPage"] = gopage;
                break;
        }
        txtGoPage.Text = ViewState["CurrentPage"].ToString();
        PagerClick.Invoke();
    }
    protected void txtGoPage_TextChanged(object sender, EventArgs e)
    {
        int cp = int.Parse(ViewState["CurrentPage"].ToString());
        int pcount = int.Parse(ViewState["PageCount"].ToString());
        int gopage;
        if (int.TryParse(txtGoPage.Text, out gopage)) {
            gopage = Math.Max(gopage, 1);
            gopage = Math.Min(gopage, pcount);
            ViewState["CurrentPage"] = gopage;
            txtGoPage.Text = gopage.ToString();
            PagerClick.Invoke();
        }
        else {
            txtGoPage.Text = cp.ToString();
        }
    }
    protected void LstPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PageSize"] = LstPageSize.SelectedValue;
        ViewState["CurrentPage"] = "1";
        txtGoPage.Text = "1";
        PagerClick.Invoke();
    }
}