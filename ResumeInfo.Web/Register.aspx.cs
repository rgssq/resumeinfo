using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtPID.Focus();
        }
        //ResumeInfoDataContext db = new ResumeInfoDataContext();
        //db.CreateDatabase();

    }
    protected void btnRegNew_Click(object sender, EventArgs e)
    {
        try
        {
            CheckPID();
            CheckMail();
            CheckPwd();
            CheckItem();
            CreateItem();
            WebHelper.AlertMsg("注册新用户成功！您可以关闭该窗口。", ClientScript);
        }
        catch (Exception ex)
        {
            WebHelper.AlertMsg(ex.Message, ClientScript);
        }
    }
    private void CheckPID()
    {
        if (!(txtPID.Text.Length == 15 || txtPID.Text.Length == 18))
        {
            throw new Exception("身份证号码只能是15位或者18位，请仔细检查。");
        }
    }
    private void CheckMail()
    {
        if(!txtMail.Text.Contains("@"))
            throw new Exception("非有效Email地址，请仔细检查。");
    }
    private void CheckItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        int count = db.BaseInfo.Count(p => p.PID == txtPID.Text);
        if (count > 0)
        {
            throw new Exception("注册失败，该用户已经存在！");
        }
    }
    private void CheckPwd()
    {
        if(!txtPwd.Text.Equals(txtPwd1.Text))
            throw new Exception("密码不一致，请仔细检查。");
    }
    private void CreateItem()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        BaseInfo item = new BaseInfo();
        item.PID = txtPID.Text;
        item.pwd = txtPwd.Text;
        item.email = txtMail.Text;
        item.CreateTime = DateTime.Now;
        db.BaseInfo.InsertOnSubmit(item);
        db.SubmitChanges();
        BaseInfo rlt = db.BaseInfo.Single(p => p.PID == txtPID.Text);
        Session["UserID"] = rlt.UserID;
        Session["UserType"] = 2;
        Session["UserPID"] = rlt.PID;
        Server.Transfer("FrmMain.aspx");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
   
}