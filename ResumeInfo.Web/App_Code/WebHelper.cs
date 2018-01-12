#region Using...
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data.Linq;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Web.SessionState;
using System.Web;

#endregion

public static class WebHelper
{
    #region ListControl相关
    public static void FillEnuList(ListControl list, DataContext db, Type enutable, bool addnull, string value)
    {
        IQueryable q = db.GetTable(enutable).Where("IsShow == null || IsShow == True").OrderBy("DisOrder", null);
        list.DataSource = q;
        list.DataValueField = "PKID";
        list.DataTextField = "Label";
        list.DataBind();
        if (addnull) list.Items.Insert(0, new ListItem("请选择", ""));
        if (value != "") {
            if (list.Items.Count > 0) {
                list.ClearSelection();
                list.Items.FindByValue(value).Selected = true;
            }
        }
    }
    public static void FillListCtrl(ListControl list, IQueryable q, bool addnull, string value)
    {
        list.DataSource = q;
        if (q.ElementType != typeof(string)) {
            list.DataValueField = q.ElementType.GetProperties()[0].Name;
            list.DataTextField = q.ElementType.GetProperties()[1].Name;
        }
        list.DataBind();
        if (addnull) list.Items.Insert(0, new ListItem("请选择", ""));
        if (value != "") {
            if (list.Items.Count > 0) {
                list.ClearSelection();
                list.Items.FindByValue(value).Selected = true;
            }
        }
    }
    public static void FillListCtrlForBool(ListControl list, bool addnull, string value)
    {
        list.Items.Add(new ListItem("是", "True"));
        list.Items.Add(new ListItem("否", "False"));
        if (addnull) list.Items.Insert(0, new ListItem("请选择", ""));
        if (value != "") {
            list.ClearSelection();
            list.Items.FindByValue(value).Selected = true;
        }
    }
    #endregion

    #region TabStrip相关
    public static void CreateTabPage(Table tab, string id, string title, int width, string url)
    {
        TableCell cd = new TableCell();
        cd.CssClass = "TabSplit";
        cd.Width = Unit.Pixel(1);

        TableCell c = new TableCell();
        c.ID = id;
        c.Text = title;
        c.Width = Unit.Pixel(width);
        c.CssClass = "Tab";
        c.Attributes["onmouseover"] = "javascript:HoverTabPage(this);";
        c.Attributes["onmouseleave"] = "javascript:LeaveTabPage(this);";
        c.Attributes["onmousedown"] = "javascript:SelectTabPage(this,\"" + url + "\");";

        TableCell cd1 = new TableCell();
        cd1.CssClass = "TabSplit";
        cd1.Width = Unit.Pixel(1);

        tab.Rows[0].Cells.Add(cd);
        tab.Rows[0].Cells.Add(c);
        tab.Rows[0].Cells.Add(cd1);
    }
    #endregion

    #region 浏览器脚本、安全
    public static void IsSessionValid(HttpSessionState session, HttpResponse response)
    {
        if (session["UserType"] == null) {
            response.Redirect("~/NoUser.htm");
        }
    }
    public static void WriteScript(string script, ClientScriptManager csm)
    {
        csm.RegisterStartupScript(typeof(string), "runscript", CSScript(script));
    }
    public static void AlertMsg(string msg, ClientScriptManager csm)
    {
        csm.RegisterStartupScript(typeof(string), "alertmsg", CSScript("alert(\"" + msg + "\");"));
    }
    private static string CSScript(string sc)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<script type=\"text/javascript\">");
        sb.AppendLine(sc);
        sb.AppendLine("</script>");
        return sb.ToString();
    }
    /// <summary>
    /// 在浏览器上显示提示信息
    /// </summary>
    /// <param name="stip">提示信息</param>
    /// <returns>HTML表现字符串</returns>
    public static string SetUITipString(string stip)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<fieldset style=\"width: 400px\">");
        sb.Append("<legend><b>◆提示信息</b></legend>");
        sb.Append("<p align=\"center\"><font size=\"Medium\" color=\"blue\"><B>" + stip + "</B></font></p><br/>");
        sb.Append("</fieldset>");
        return sb.ToString();
    }
    #endregion

    #region 查询相关
    public static string GetQueryExpress(Panel ctlpan)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Control c in ctlpan.Controls) {
            if (c is UserControl) {
                string ft = DataBinder.Eval(c, "FieldType", "");
                string value = DataBinder.Eval(c, "Value", "");
                string mc = DataBinder.Eval(c, "MatchCond", "");
                string vend = DataBinder.Eval(c, "ValueEnd", "");
                string r = "";
                string name = c.ID.Replace("_", ".");
                switch (ft) {
                    case "string":
                        if (value != "") r = GetExpressForString(name, value, mc);
                        break;
                    case "int":
                        if (value != "") r = GetExpressForInt(name, value, mc, vend);
                        break;
                    case "date":
                        if (value != "") r = GetExpressForDate(name, value, mc, vend);
                        break;
                    case "select":
                        if (value != "") {
                            //value = "\"" + value + "\"";
                           
                                r = name + "==" + value;
                        }
                        break;
                    default:
                        r = "";
                        break;
                }
                if (r != "") sb.Append("(" + r + ") && ");
            }
        }
        if (sb.Length > 0) {
            return sb.ToString().Substring(0, sb.Length - 4);
        }
        else {
            return "";
        }
    }
    private static string GetExpressForString(string name, string value, string matchcond)
    {
        value = "\"" + value + "\"";
        switch (matchcond) {
            case "≈": //包含
                return name + ".Contains(" + value + ")";
            case "=": //等于
                return name + "==" + value;
            case "!≈": //不包含
                return "!" + name + ".Contains(" + value + ")";
            case "!=": //不等于
                return name + "!=" + value;
            case "x..": //以...开头
                return name + ".StartsWith(" + value + ")";
            case "..x": //以...结尾
                return name + ".EndsWith(" + value + ")";
            case "!x..": //不以...开头
                return "!" + name + ".StartsWith(" + value + ")";
            case "!..x": //不以...结尾
                return "!" + name + ".EndsWith(" + value + ")";
            default:
                return "";
        }
    }
    private static string GetExpressForInt(string name, string value, string matchcond, string vend)
    {
        switch (matchcond) {
            case "=": //等于
                return name + "==" + value;
            case ">": //大于
                return name + ">" + value;
            case "<": //小于
                return name + "<" + value;
            case ">=": //大于等于
                return name + ">=" + value;
            case "<=": //小于等于
                return name + "<=" + value;
            case "!=": //不等于
                return name + "!=" + value;
            case "[]": //两者之间
                return "(" + name + ">=" + value + " && " + name + "<= " + vend + ")";
            default:
                return "";
        }
    }
    private static string GetExpressForDate(string name, string value, string matchcond, string vend)
    {
        value = "\"" + value + "\"";
        switch (matchcond) {
            case "=": //等于
                return name + ".Value==Convert.ToDateTime(" + value + ")";
            case ">": //大于
                return name + ".Value>Convert.ToDateTime(" + value + ")";
            case "<": //小于
                return name + ".Value<Convert.ToDateTime(" + value + ")";
            case ">=": //大于等于
                return name + ".Value>=Convert.ToDateTime(" + value + ")";
            case "<=": //小于等于
                return name + ".Value<=Convert.ToDateTime(" + value + ")";
            case "!=": //不等于
                return name + ".Value!=Convert.ToDateTime(" + value + ")";
            case "[]": //两者之间
                return "(" + name + ".Value>=Convert.ToDateTime(" + value + ") && " + name + ".Value<=Convert.ToDateTime(\"" + vend + "\"))";
            default:
                return "";
        }
    }
    #endregion

    #region DataContext SQL Log...
    public static StringBuilder SetSqlLog(DataContext db)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        db.Log = sw;
        return sb;
    }
    public static Control WriteSqlLog(StringBuilder sb)
    {
        TextBox t = new TextBox();
        t.TextMode = TextBoxMode.MultiLine;
        t.Width = Unit.Parse("98%");
        t.Wrap = false;
        t.Rows = 20;
        t.Text = sb.ToString();
        return t;
    }
    #endregion

    #region 对象绑定
    public static void BindObjectToControls(object obj, Control container)
    {
        foreach (PropertyInfo p in obj.GetType().GetProperties()) {
            string pvalue = DataBinder.Eval(obj, p.Name, "");

            Control c = container.FindControl(p.Name);
            if (c != null) {
                if (c is ListControl) {
                    ListControl list = (ListControl)c;
                    ListItem li = list.Items.FindByValue(pvalue);
                    if (li != null) {
                        list.ClearSelection();
                        li.Selected = true;
                    }
                }
                else if (c is TextBox)
                {
                    PropertyInfo pf = c.GetType().GetProperty("Text");
                    //if (pf != null) pf.SetValue(c, pvalue.Replace("<br>","\r\n"), null);
                    if (pf != null) pf.SetValue(c, pvalue.Replace("<br>","\r\n"), null);
                    
                }
                else
                {
                    PropertyInfo pf = c.GetType().GetProperty("Text");
                    if (pf != null) pf.SetValue(c, pvalue, null);
                }
            }
        }
    }
    public static void BindControlsToObject(object obj, Control container)
    {
        foreach (PropertyInfo p in obj.GetType().GetProperties()) {
            Control c = container.FindControl(p.Name);
            if (c != null) {
                if (c is ListControl) {
                    ListControl list = (ListControl)c;
                    p.SetValue(obj, getTypeValue(p.PropertyType.FullName, list.SelectedValue), null);
                }
                else if(c is TextBox) 
                {
                    
                    p.SetValue(obj, getTypeValue(p.PropertyType.FullName, DataBinder.Eval(c, "Text", "")), null);
                   

                }
                else
                {
                    p.SetValue(obj, getTypeValue(p.PropertyType.FullName, DataBinder.Eval(c, "Text", "")), null);
                }
            }
        }
    }
    private static object getTypeValue(string tname, string value)
    {
        if (value == "") return null;
        if (tname.Contains("System.String")) {
            return Convert.ToString(value).Replace("\r\n","<br>");
        }
        else if (tname.Contains("System.Int32")) {
            return Convert.ToInt32(value);
        }
        else if (tname.Contains("System.Int16")) {
            return Convert.ToInt16(value);
        }
        else if (tname.Contains("System.Decimal")) {
            return Convert.ToDecimal(value);
        }
        else if (tname.Contains("System.Double")) {
            return Convert.ToDouble(value);
        }
        else if (tname.Contains("System.Boolean")) {
            return Convert.ToBoolean(value);
        }
        else if (tname.Contains("System.DateTime")) {
            return Convert.ToDateTime(value);
        }
        return Convert.ToString(value);
    }
    #endregion

    #region 其他...
    public static string GetRefreshPagePath(Page p)
    {
        string dir = p.AppRelativeTemplateSourceDirectory;
        string path = p.AppRelativeVirtualPath;
        string r = path.Replace(dir, "");
        string q = p.ClientQueryString;
        return (q == "") ? r : r + "?" + q;
    }
    public static void ResetControl(Control container)
    {
        foreach (Control c in container.Controls) {
            if (c is TextBox) ((TextBox)c).Text = "";
            if (c is ListControl) ((ListControl)c).SelectedIndex = 0;
            ResetControl(c);
        }
    }
    public static string ShortDateTime(string s)
    {
        if (s == "") return "";
        DateTime d = DateTime.Parse(s);
        return d.ToShortDateString();
    }
    public static string ShortDateTime(DateTime? value)
    {
        if (value.HasValue) {
            return value.Value.ToShortDateString();
        }
        else {
            return "";
        }
    }
    public static string GetAttachUpDir()
    {
        return @"E:\project\ResumeInfo\UpFiles\Attach\";
    }
    public static string GetPhotoUpDir()
    {
        return @"E:\project\ResumeInfo\UpFiles\Photo\";
    }
    public static Type GetEnuType(string s)
    {
        Type type = null;
        switch (s) {
            case "enuZy":
                type = typeof(enuZy);
                break;
            case "enuZg":
                type = typeof(enuZg);
                break;
            case "enuZc":
                type = typeof(enuZc);
                break;
            case "enuQwyx":
                type = typeof(enuQwyx);
                break;
            case "enuZzmm":
                type = typeof(enuZzmm);
                break;
            case "enuWjlx":
                type = typeof(enuWjlx);
                break;
            case "enuLaiy":
                type = typeof(enuLaiy);
                break;
            case "enuZt":
                type = typeof(enuZt);
                break;
            case "enuGzdd":
                type = typeof(enuGzdd);
                break;
        }
        return type;
    }
    #endregion
}