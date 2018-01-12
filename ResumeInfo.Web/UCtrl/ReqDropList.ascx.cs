using System;
using System.Web.UI.WebControls;

public partial class ReqDropList : System.Web.UI.UserControl
{
    public string Text
    {
        get { return list.SelectedValue; }
        set
        {
            ListItem li = list.Items.FindByValue(value);
            if (li != null) {
                list.ClearSelection();
                li.Selected = true;
            }
        }
    }
    public Unit Width
    {
        get { return list.Width; }
        set { list.Width = value; }
    }
    public DropDownList List
    {
        get { return list; }
    }
}
