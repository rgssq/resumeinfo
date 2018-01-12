#region Using...
using System;
using System.Linq;
using System.Web.UI.WebControls;
#endregion

public partial class BaseInfoEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            if (Request.QueryString["es"] != null) {
                btnClose.Visible = true;
                btnClose.Attributes["onclick"] = "javascript:window.close();return false;";
            }
            ViewState["id"] = Session["UserID"];
            FillForm(int.Parse(ViewState["id"].ToString()));
            btnOK.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
        }
    }
    private void FillNewForm()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        WebHelper.FillEnuList(Sex.List, db, typeof(enuSex), true, "");
        WebHelper.FillEnuList(zzmm.List, db, typeof(enuZzmm), true, "");
        WebHelper.FillEnuList(hyzk.List, db, typeof(enuHyzk), true, "");
        WebHelper.FillEnuList(cszy.List, db, typeof(enuZy), true, "");
        WebHelper.FillEnuList(gzdd1.List, db, typeof(enuGzdd), true, "");
        WebHelper.FillEnuList(gzdd2.List, db, typeof(enuGzdd), true, "");
        WebHelper.FillEnuList(gzdd3.List, db, typeof(enuGzdd), true, "");
        WebHelper.FillEnuList(qwxc, db, typeof(enuQwyx), true, "");

        WebHelper.FillEnuList(zc, db, typeof(enuZc), true, "");
        WebHelper.FillEnuList(ypzly.List, db, typeof(enuLaiy), true, "");
    }
    private void FillForm(int id)
    {
        FillNewForm();
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        BaseInfo item = db.BaseInfo.Single(p => p.UserID == id);
        WebHelper.BindObjectToControls(item, PanField);
    }
    private void ModifyItem(int id)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        BaseInfo item = db.BaseInfo.Single(p => p.UserID == id);
        WebHelper.BindControlsToObject(item, PanField);
        db.SubmitChanges();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try {
            CheckPID();
            CheckRepeat();
            ModifyItem(int.Parse(ViewState["id"].ToString()));
            WebHelper.AlertMsg("信息修改成功！", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg("数据库写入失败！\\r\\n" + ex.Message.Replace(Environment.NewLine, "\\r\\n"), ClientScript);
        }
    }
    private void CheckPID()
    {
        if (!(PID.Text.Length == 15 || PID.Text.Length == 18)) {
            throw new Exception("身份证号码只能是15位或者18位，请仔细检查。");
        }
    }
    private void CheckRepeat()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int count = db.BaseInfo.Count(o => o.UserID != int.Parse(Session["UserID"].ToString()) && (o.PID == PID.Text && o.PName == PName.Text));
        if (count > 0) {
            throw new Exception("该身份证号码和姓名已经存在，您不能修改！");
        }
    }
}