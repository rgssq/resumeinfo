using System;
using System.Web.UI.WebControls;

public partial class FindTextBox : System.Web.UI.UserControl
{
    public string FieldType
    {
        get;
        set;
    }
    public string MatchCond
    {
        get { return mlist.SelectedValue; }
    }
    public string Value
    {
        get { return tb.Text; }
    }
    public string ValueEnd
    {
        get { return ""; }
    }
}
