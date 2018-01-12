using System;

public partial class TopPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            labInfo.Text = "<b><i>欢迎您：</i></b>";
            labInfo.Text += Session["UserPID"];
            labInfo.Text += "!  ";
        }
    }
}
