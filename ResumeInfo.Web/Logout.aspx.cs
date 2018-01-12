using System;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType"] != null) {
            if (Session["UserType"].ToString() == "0" || Session["UserType"].ToString() == "-1")
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
        }
        else {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}
