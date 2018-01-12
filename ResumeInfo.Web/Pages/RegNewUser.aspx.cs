#region Using...
using System;
using System.Linq;
using System.Web.UI.WebControls;
#endregion

public partial class RegNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            btnOK.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
            btnClose.Attributes["onclick"] = "javascript:window.close();return false;";
        }
    }
    private void CreateItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        BaseInfo item = new BaseInfo();
        item.PID = PID.Text;
        item.PName = PName.Text;
        item.pwd = pwd.Text;
        item.CreateTime = DateTime.Now;
        db.BaseInfo.InsertOnSubmit(item);
        db.SubmitChanges();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try {
            CheckPID();
            CheckItem();
            CreateItem();
            WebHelper.AlertMsg("注册新用户成功！您可以关闭该窗口。", ClientScript);
        }
        catch (Exception ex) {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
    private void CheckPID()
    {
        if (!(PID.Text.Length == 15 || PID.Text.Length == 18)) {
            throw new Exception("身份证号码只能是15位或者18位，请仔细检查。");
        }
    }
    private void CheckItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int count = db.BaseInfo.Count(p => p.PID == PID.Text && p.PName == PName.Text);
        if (count > 0) {
            throw new Exception("注册失败，该用户已经存在！");
        }
    }
}