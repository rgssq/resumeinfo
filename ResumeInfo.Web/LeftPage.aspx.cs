using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using AjaxControlToolkit;

public partial class LeftPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            CreateMenu();
        }
    }
    private void CreateMenu()
    {
        int usertype = int.Parse(Session["UserType"].ToString());
        
        foreach(object m in GetMenuItem(usertype,0)){
            TreeNode treeNode = new TreeNode();
            treeNode.Text = DataBinder.Eval(m, "mname", "");
            treeNode.Expanded = false;
            if (DataBinder.Eval(m, "missub", "") == "True")
            {
                foreach (object n in GetMenuItem(usertype, int.Parse(DataBinder.Eval(m, "mid", ""))))
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Target = "IMain";
                    subNode.NavigateUrl = DataBinder.Eval(n, "murl", "");
                    subNode.Text = DataBinder.Eval(n, "mname", "");
                    treeNode.ChildNodes.Add(subNode);
                }
            }
            else
            {
                treeNode.Target = "IMain";
                treeNode.NavigateUrl = DataBinder.Eval(m, "murl", "");
            }
            treeT.Nodes.Add(treeNode);

        }

    }
    private IQueryable GetMenuItem(int usertype,int topMenuID)
    {
        //string userid = Session["UserID"].ToString();
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        q = from m in db.Menu
            where (m.mutype == usertype && m.mtop == topMenuID)
            orderby m.mdisplayorder
            select new { m.mid,m.mutype,m.mtop,m.mname,m.murl,m.missub };
        return q;
    }
    /*private void CreateMenu()
    {
        string OldTopName = "";
        string CurTopName = "";
        Table t = new Table();
        int index = 0;
        foreach (object m in GetMenuItem()) {
            CurTopName = DataBinder.Eval(m, "TopMenuName", "");
            if (OldTopName != CurTopName) {
                t = CreateNewTeam(CurTopName);
            }
            CreateNewItem(t, m, index);
            OldTopName = CurTopName;
            index++;
        }
    }

    private Table CreateNewTeam(string name)
    {
        AccordionPane pan = new AccordionPane();
        Table t = new Table();
        t.CellSpacing = 0;
        t.CellPadding = 8;
        t.Width = new Unit("100%");
        Label lb = new Label();
        lb.Text = name;
        pan.HeaderContainer.Controls.Add(lb);
        pan.ContentContainer.Controls.Add(t);
        accr.Panes.Add(pan);
        return t;
    }
    private void CreateNewItem(Table t, object m, int index)
    {
        TableRow r = new TableRow();
        TableCell c = new TableCell();
        c.Height = new Unit(45);
        c.VerticalAlign = VerticalAlign.Middle;
        c.CssClass = "Row";
        c.Attributes["onmouseover"] = "javascript:ItemHover(this);";
        c.Attributes["onmouseout"] = "javascript:ItemOut(this);";

        HyperLink lk = new HyperLink();
        lk.ID = "MenuItem_" + index;
        lk.NavigateUrl = DataBinder.Eval(m, "URLPath", "");
        lk.Target = "IMain";
        lk.Attributes["onclick"] = "javascript:ItemClick(this.parentElement);";

        Image img = new Image();
        string imgurl = DataBinder.Eval(m, "Icon", "");
        if (imgurl == "") imgurl = "Images/Menu/item.gif";
        img.ImageUrl = imgurl;

        Label lb = new Label();
        lb.Text = "<br/>" + DataBinder.Eval(m, "Name", "");

        lk.Controls.Add(img);
        lk.Controls.Add(lb);
        c.Controls.Add(lk);
        r.Cells.Add(c);
        t.Rows.Add(r);
    }
    private IQueryable GetMenuItem()
    {
        string userid = Session["UserID"].ToString();
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        IQueryable q;
        switch (userid) {
            case "0":
                q = from m in db.MenuItem
                    where m.TopMenuID == 2
                    orderby m.TopMenu.DisplayOrder, m.DisplayOrder
                    select new { m.MenuItemID, TopMenuName = m.TopMenu.Name, m.Name, m.Icon, m.URLPath };
                break;
            case "-1":
                q = from m in db.MenuItem
                    where m.MenuItemID == 8
                    orderby m.TopMenu.DisplayOrder, m.DisplayOrder
                    select new { m.MenuItemID, TopMenuName = m.TopMenu.Name, m.Name, m.Icon, m.URLPath };
                break;
            default:
                q = from m in db.MenuItem
                    where m.TopMenuID == 1
                    orderby m.TopMenu.DisplayOrder, m.DisplayOrder
                    select new { m.MenuItemID, TopMenuName = m.TopMenu.Name, m.Name, m.Icon, m.URLPath };
                break;
        }
        return q;
    }*/
}
