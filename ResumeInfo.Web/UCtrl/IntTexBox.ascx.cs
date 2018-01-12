using System;
using System.Web.UI.WebControls;

public partial class IntTexBox : System.Web.UI.UserControl
{
    public string Text
    {
        get { return tb.Text; }
        set { tb.Text = value; }
    }
    public Unit Width
    {
        get { return tb.Width; }
        set { tb.Width = value; }
    }
}
