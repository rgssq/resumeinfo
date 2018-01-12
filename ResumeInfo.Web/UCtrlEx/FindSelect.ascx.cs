using System;
using System.Web.UI.WebControls;

public partial class FindSelect : System.Web.UI.UserControl
{
    public string FieldType
    {
        get;
        set;
    }
    public string MatchCond
    {
        get { return ""; }
    }
    public string Value
    {
        get { return list.SelectedValue; }
    }
    public string ValueEnd
    {
        get { return ""; }
    }
    public DropDownList List
    {
        get { return list; }
    }
}
