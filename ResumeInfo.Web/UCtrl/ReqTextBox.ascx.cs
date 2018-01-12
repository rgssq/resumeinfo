using System;
using System.Web.UI.WebControls;

public partial class ReqTextBox : System.Web.UI.UserControl
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
    public Unit Height
    {
        get { return tb.Height; }
        set { tb.Height = value; }
    }
    public TextBoxMode TextMode
    {
        get { return tb.TextMode; }
        set { tb.TextMode = value; }
    }
}
