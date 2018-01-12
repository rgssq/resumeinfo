using System;
using System.Linq;
using System.Net.Mail;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            txtLogPID.Focus();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string pid = txtLogPID.Text.Trim();
        string pwd = txtPassword.Text;
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (db.BaseInfo.Count(p => p.PID == pid) > 0)
        {
            BaseInfo user = db.BaseInfo.First(p => p.PID == pid);
            if(pwd.Equals(user.pwd))
            {
                Session["UserType"] = 2;
                Session["UserPID"] = pid;
                Session["UserID"] = user.UserID;
                Response.Redirect("FrmMain.aspx");
            }
            

        }
        else if (db.User.Count(p => p.uname == pid) > 0)
        {


            User user = db.User.First(p => p.uname == Convert.ToString(pid));
            if (pwd.Equals(user.upwd))
            {
               
                Session["UserType"] = user.utype;
                Session["UserPID"] = pid;
                Response.Redirect("FrmMain.aspx");
            }
        }
         WebHelper.AlertMsg("请输入正确的用户名和密码！", ClientScript);
          
       
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    protected void btnGetPwd_Click(object sender, EventArgs e)
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        if (!txtLogPID.Text.ToString().Equals("") && db.BaseInfo.Where(o => o.PID == txtLogPID.Text.ToString().Trim()).Count() > 0)
        {
            IQueryable<BaseInfo> items = db.BaseInfo.Where(o => o.PID == txtLogPID.Text.ToString().Trim());
            SmtpClient client = new SmtpClient("smtp.smedi.com", 25); 
            client.UseDefaultCredentials = false; 
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("zzrs", "111");
            client.Credentials = basicAuthenticationInfo; 
            client.EnableSsl = false;  
            
            string title = "找回密码";
           

            try
            {
                foreach (BaseInfo user in items)
                {
                    string body = user.PName + " 您好：" + Environment.NewLine + "您的密码是" + user.pwd;
                    MailMessage msg = new MailMessage("rgssq@163.com",user.email,title,body); 
                    client.Send(msg);
                }
            }
            catch
            {
            }
            WebHelper.AlertMsg("密码已发送至您注册所用邮箱！", ClientScript);
        }
        else
        {
            WebHelper.AlertMsg("身份证号码有误或您未注册！", ClientScript);
        }
    }
}
