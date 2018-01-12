#region Using...
using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
#endregion

public partial class FindCond : System.Web.UI.Page
{
    public Dictionary<Type, string> QueryList = new Dictionary<Type, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            WebHelper.IsSessionValid(Session, Response);
            btnOK.Attributes["onclick"] = "javascript:if(Page_ClientValidate('')) $find('PopUp').show();";
            FillNewForm();
        }
    }
    private void FillNewForm()
    {
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        WebHelper.FillEnuList(Sex.List, db, typeof(enuSex), true, "");
        WebHelper.FillEnuList(zzmm.List, db, typeof(enuZzmm), true, "");
        WebHelper.FillEnuList(hyzk.List, db, typeof(enuHyzk), true, "");

        WebHelper.FillEnuList(qwxc.List, db, typeof(enuQwyx), true, "");
        
        WebHelper.FillEnuList(zc.List, db, typeof(enuZc), true, "");
        
       

        WebHelper.FillEnuList(jyjd.List, db, typeof(enuJyjd), true, "");
        

        WebHelper.FillEnuList(zg.List, db, typeof(enuZg), true, "");
        WebHelper.FillEnuList(cszy.List, db, typeof(enuZy), true, "");
        WebHelper.FillEnuList(gzdd1.List, db, typeof(enuGzdd), true, "");
        WebHelper.FillEnuList(gzdd2.List, db, typeof(enuGzdd), true, "");
        WebHelper.FillEnuList(gzdd3.List, db, typeof(enuGzdd), true, "");

       
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string cond = WebHelper.GetQueryExpress(PanBaseInfo);
        if (cond != "") {
            QueryList.Add(typeof(BaseInfo), cond);
        }
        cond = WebHelper.GetQueryExpress(PanJybj);
        if (cond != "") {
            QueryList.Add(typeof(Jiaoybj), cond);
        }
        cond = WebHelper.GetQueryExpress(PanZyzg);
        if (cond != "") {
            QueryList.Add(typeof(Zhiyzg), cond);
        }
        cond = WebHelper.GetQueryExpress(PanGzsx);
        if (cond != "") {
            QueryList.Add(typeof(Gongzsx), cond);
        }
       
        Server.Transfer("FindResult.aspx");
    }
}