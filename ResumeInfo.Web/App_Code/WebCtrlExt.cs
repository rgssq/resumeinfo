#region Using...
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
#endregion

namespace MyWebControlsExt
{
    public class GridViewExt : GridView
    {
        public event GridViewRowEventHandler ItemRowBound;
        public string ObjID { get; set; }
        public bool MulSelect { get; set; }
        public bool SimpleList { get; set; }
        public List<int> SelectedRows
        {
            get
            {
                if (ViewState["SelectedRows"] == null) {
                    ViewState["SelectedRows"] = new List<int>();
                }
                return (List<int>)ViewState["SelectedRows"];
            }
            set { ViewState["SelectedRows"] = value; }
        }
        public void FillGrid(IQueryable q)
        {
            this.DataSource = q;
            this.DataBind();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AutoGenerateColumns = false;
            AllowSorting = true;
            EmptyDataText = "列表中没有记录！";
            EmptyDataRowStyle.CssClass = "NoCount";
            CssClass = "Grid";
            if (MulSelect) {
                this.Columns.Insert(0, new SelectColumn());
            }
            if (!SimpleList) {
                foreach (DataControlField c in this.Columns) {
                    BoundField f = c as BoundField;
                    if (f != null) {
                        f.SortExpression = f.DataField;
                    }
                }
            }
        }
        protected override void OnSorting(GridViewSortEventArgs e)
        {
            string direction = "";
            if (ViewState["SortDirection"] != null) {
                direction = ViewState["SortDirection"].ToString();
            }
            direction = (direction == "ASC") ? "DESC" : "ASC";
            ViewState["SortDirection"] = direction;
            e.SortExpression += " " + direction;
            base.OnSorting(e);
        }
        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            base.OnRowDataBound(e);
            if (!SimpleList) {
                switch (e.Row.RowType) {
                    case DataControlRowType.DataRow:
                        string id = DataBinder.Eval(e.Row.DataItem, ObjID, "");
                        if (MulSelect) {
                            CheckBox chk = (CheckBox)e.Row.FindControl("chk");
                            chk.Style.Add("ObjID", id);
                        }
                        ItemRowBound(id, e);
                        break;
                }
            }
            DrawGridViewRow(e.Row);
        }
        private void DrawGridViewRow(GridViewRow r)
        {
            switch (r.RowType) {
                case DataControlRowType.Header:
                    r.CssClass = "HeadRow";
                    break;
                case DataControlRowType.DataRow:
                    r.Attributes["onmouseover"] = "javascript:RowHover(this);";
                    r.Attributes["onmouseout"] = "javascript:RowOut(this);";
                    switch (r.RowState) {
                        case DataControlRowState.Normal:
                            r.CssClass = "Row";
                            r.Style["type"] = "Row";
                            break;
                        case DataControlRowState.Alternate:
                            r.CssClass = "AltRow";
                            r.Style["type"] = "AltRow";
                            break;
                    }
                    if (MulSelect) DrawSelectedRow(r);
                    break;
            }
        }
        private void DrawSelectedRow(GridViewRow r)
        {
            if (SelectedRows.Count > 0) {
                CheckBox chk = (CheckBox)r.FindControl("chk");
                int id = int.Parse(chk.Style["ObjID"]);
                if (SelectedRows.Contains(id)) {
                    r.CssClass = "SelectedRow";
                    chk.Checked = true;
                }
            }
        }
    }
    public class SelectColumn : TemplateField
    {
        public SelectColumn()
        {
            HeaderTemplate = new ChkAllTemplate();
            ItemTemplate = new ChkTemplate();
        }
        internal class ChkAllTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                CheckBox chkall = new CheckBox();
                chkall.ID = "chkall";
                chkall.AutoPostBack = true;
                chkall.CheckedChanged += new EventHandler(chkall_CheckedChanged);
                container.Controls.Add(chkall);
            }
            void chkall_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox chkall = (CheckBox)sender;
                GridViewExt gv = (GridViewExt)chkall.NamingContainer.NamingContainer;
                foreach (GridViewRow r in gv.Rows) {
                    if (r.RowType == DataControlRowType.DataRow) {
                        CheckBox chk = (CheckBox)r.FindControl("chk");
                        if (chk.Enabled) chk.Checked = chkall.Checked;
                        SetSelectedRow(r, chk);
                    }
                }
            }
        }
        internal class ChkTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                CheckBox chk = new CheckBox();
                chk.ID = "chk";
                chk.AutoPostBack = true;
                chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
                container.Controls.Add(chk);
            }
            void chk_CheckedChanged(object sender, EventArgs e)
            {
                CheckBox chk = (CheckBox)sender;
                GridViewRow r = (GridViewRow)chk.NamingContainer;
                SetSelectedRow(r, chk);
            }
        }
        private static void SetSelectedRow(GridViewRow r, CheckBox chk)
        {
            GridViewExt gv = (GridViewExt)r.NamingContainer;
            int id = int.Parse(chk.Style["ObjID"]);
            if (chk.Checked) {
                if (!gv.SelectedRows.Contains(id)) gv.SelectedRows.Add(id);
            }
            else {
                gv.SelectedRows.Remove(id);
            }
            SetRowCss(r, chk.Checked);
        }
        private static void SetRowCss(GridViewRow r, bool selected)
        {
            if (selected) {
                r.CssClass = "SelectedRow";
            }
            else {
                if (r.RowState == DataControlRowState.Alternate) {
                    r.CssClass = "AltRow";
                }
                else {
                    r.CssClass = "Row";
                }
            }
        }
    }
    public class LinkField : TemplateField
    {
        public string ID { get; set; }
        public override bool Initialize(bool sortingEnabled, Control control)
        {
            ItemTemplate = new LinkTemplate(ID);
            SortExpression = ID;
            return base.Initialize(sortingEnabled, control);
        }
        internal class LinkTemplate : ITemplate
        {
            public string ID;
            public LinkTemplate(string id)
            {
                ID = id;
            }
            public void InstantiateIn(Control container)
            {
                HyperLink lk = new HyperLink();
                lk.ID = ID;
                container.Controls.Add(lk);
            }
        }
    }
    public class LabelField : TemplateField
    {
        public string ID { get; set; }
        public override bool Initialize(bool sortingEnabled, Control control)
        {
            ItemTemplate = new LabelTemplate(ID);
            SortExpression = ID;
            return base.Initialize(sortingEnabled, control);
        }
        internal class LabelTemplate : ITemplate
        {
            public string ID;
            public LabelTemplate(string id)
            {
                ID = id;
            }
            public void InstantiateIn(Control container)
            {
                Label lb = new Label();
                lb.ID = ID;
                container.Controls.Add(lb);
            }
        }
    }
    public class BoolField : BoundField
    {
        protected override object GetValue(Control controlContainer)
        {
            string r = "";
            object o = base.GetValue(controlContainer);
            if (o != null) {
                if (bool.Parse(o.ToString())) {
                    r = "是";
                }
                else {
                    r = "否";
                }
            }
            return r;
        }
    }
    public class ImageField : TemplateField
    {
        public string ID { get; set; }
        public string ImageUrl { get; set; }
        public string ToolTip { get; set; }
        public override bool Initialize(bool sortingEnabled, Control control)
        {
            ItemTemplate = new ImageTemplate(ID, ImageUrl, ToolTip);
            return base.Initialize(sortingEnabled, control);
        }
        internal class ImageTemplate : ITemplate
        {
            public string ID;
            public string ImageUrl;
            public string ToolTip;
            public ImageTemplate(string id, string imageurl, string tooltip)
            {
                ID = id;
                ImageUrl = imageurl;
                ToolTip = tooltip;
            }
            public void InstantiateIn(Control container)
            {
                Image img = new Image();
                img.ID = ID;
                img.ImageUrl = ImageUrl;
                img.ToolTip = ToolTip;
                img.Style["cursor"] = "hand";
                container.Controls.Add(img);
            }
        }
    }
}