using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ZtView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            int id = int.Parse(Session["UserID"].ToString());
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            BaseInfo item = db.BaseInfo.Single(p => p.UserID == id);
            userid.Text = "身份证号码：" + item.PID;
            username.Text = "姓名：" + item.PName;
            if (item.enuZt == null) {
                info.Text = "您的简历状态：还未阅读";
            }
            else {
                info.Text = "您的简历状态：" + item.enuZt.Label;
            }
        }
    }
}