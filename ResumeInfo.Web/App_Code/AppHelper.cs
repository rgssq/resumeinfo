using System;
using System.Linq;
using System.Linq.Dynamic;
using Aspose.Words;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;

public static class AppHelper
{
    public static void ExportDoc(int id)
    {
        string rootpath = @"E:\project\ResumeInfo\ResumeInfo.Web\";
        string filename = rootpath + "Pages\\ResumeRpt.doc";
      

        License license = new License();
        license.SetLicense(rootpath + "bin\\Aspose.Word.lic");
        Document doc = new Document(filename);
        string[] fieldNames = doc.MailMerge.GetFieldNames();
        Dictionary<string, object> fvlist = new Dictionary<string, object>();
        ResumeInfoDataContext db = new ResumeInfoDataContext();
        var baseinfo = db.BaseInfo.Select(b => new {
            b.UserID,
            b.PName,
            b.PID,
            Sex = b.enuSex.Label,
            csrq = WebHelper.ShortDateTime(b.csrq),
            zzmm = b.enuZzmm.Label,
            b.jg,
            b.csd,
            b.hkszd,
            b.mz,
            hyzk = b.enuHyzk.Label,
            b.jkzk,
            b.grtc,
            b.sj,
            b.yxdh,
            b.lxdz,
            b.email,
            qwyx = b.enuQwyx.Label,
            b.tz,
            b.sg,
            b.dywy,
            b.dewy,
            b.jsj,
            zc = b.enuZc.Label,
            jypx = b.jypx.Replace("<br>","\r\n"),
            xsky = b.xsky.Replace("<br>","\r\n"),
            stqk = b.stqk.Replace("<br>","\r\n"),
            jcqk = b.jcqk.Replace("<br>","\r\n"),
            b.gzdd1,
            b.cszy,
            ModifyTime = GetModifyTime(b.ModifyTime)
        }).Single(b => b.UserID == id);
        foreach (string s in fieldNames) {
            if (!s.StartsWith("l_")) {
                fvlist.Add(s, DataBinder.Eval(baseinfo, s));
            }
        }
        doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        fvlist.Clear();

        var Jtshgx = db.Jiatshgx.Select(o => new
        {
            o.UserID,
            o.cw,
            o.xm,
            o.nl,
            zzmm = o.enuZzmm.Label,
            o.gzdw,
            o.bmzw
        }).Where(o => o.UserID == id).Take(3);
        int index = 0;
        string[] arrf = new string[] { "l_cw", "l_xm", "l_nl", "l_zzmm", "l_gzdw", "l_bmzw" };
        foreach (var o in Jtshgx)
        {
            foreach (string f in arrf)
            {
                fvlist.Add(f + index, DataBinder.Eval(o, f.Substring(2)));
            }
            index++;
        }
        doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        ClearRest(3, index, arrf, fvlist, doc);

        var zyzg = db.Zhiyzg.Select(o => new
        {
            o.UserID,
            zg = o.enuZg.Label,
            hdsj = WebHelper.ShortDateTime(o.hdsj),
            o.zcd
        }).Where(o => o.UserID == id).Take(3);
        index = 0;
        arrf = new string[] { "l_zg", "l_hdsj", "l_zcd" };
        foreach (var o in zyzg)
        {
            foreach (string f in arrf)
            {
                fvlist.Add(f + index, DataBinder.Eval(o, f.Substring(2)));
            }
            index++;
        }
        doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        ClearRest(3, index, arrf, fvlist, doc);

        var gzsx = db.Gongzsx.Select(o => new
        {
            o.UserID,
            qzsj = Getqzsj(o.kssj, o.jssj),
            o.dw,
            o.cszy,
            o.bmjzw,
            o.zmr,
            lb = o.enuGzsxlb.Label
        }).Where(o => o.UserID == id).Take(4);
        index = 0;
        arrf = new string[] { "l_lb", "l_qzsj", "l_dw", "l_cszy", "l_bmjzw", "l_zmr" };
        foreach (var o in gzsx)
        {
            foreach (string f in arrf)
            {
                fvlist.Add(f + index, DataBinder.Eval(o, f.Substring(2)));
            }
            index++;
        }
        doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        ClearRest(4, index, arrf, fvlist, doc);

        var jybj = db.Jiaoybj.Select(o => new
        {
            o.UserID,
            jqzsj = Getqzsj(o.kssj, o.jssj),
            o.byyx,
            o.sxzy,
            o.ds,
            o.jyjd
        }).Where(o => o.UserID == id);
        arrf = new string[] { "l_jqzsj", "l_byyx", "l_sxzy", "l_ds" };
        SetJybj(1, 0, jybj, arrf, fvlist, doc);
        SetJybj(2, 1, jybj, arrf, fvlist, doc);
        SetJybj(3, 2, jybj, arrf, fvlist, doc);
        SetJybj(4, 3, jybj, arrf, fvlist, doc);
        SetJybj(5, 4, jybj, arrf, fvlist, doc);

        string picname = WebHelper.GetPhotoUpDir() + id + ".jpg";
        if (File.Exists(picname))
        {
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveToBookmark("pic");
            builder.InsertImage(picname, 70, 90);
        }

        string pname = GetDocName(baseinfo.PName, id) + ".doc";
        doc.Save(@"E:\project\ResumeInfo\简历导出\" + pname, SaveFormat.Doc);
    }
    private static void SetJybj(int jyjd, int index, IQueryable jybj, string[] arrf, Dictionary<string, object> fvlist, Document doc)
    {
        jybj = jybj.Where("jyjd == " + jyjd).Take(1);
        foreach (var o in jybj) {
            foreach (string f in arrf) {
                fvlist.Add(f + index, DataBinder.Eval(o, f.Substring(2)));
            }
        }
        if (fvlist.Count > 0) {
            doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        }
        else {
            foreach (string f in arrf) {
                fvlist.Add(f + index, "");
            }
            doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
        }
        fvlist.Clear();
    }
    private static void ClearRest(int count, int index, string[] arrf, Dictionary<string, object> fvlist, Document doc)
    {
        fvlist.Clear();
        for (int i = index; i < count; i++) {
            foreach (string f in arrf) {
                fvlist.Add(f + i, "");
            }
        }
        if (fvlist.Count > 0) {
            doc.MailMerge.Execute(fvlist.Keys.ToArray(), fvlist.Values.ToArray());
            fvlist.Clear();
        }
    }
    private static string Getqzsj(DateTime? kssj, DateTime? jssj)
    {
        string ks = "";
        string js = "";
        if (kssj.HasValue) {
            ks = kssj.Value.Year.ToString().Substring(2) + "." + kssj.Value.Month;
        }
        if (jssj.HasValue) {
            js = jssj.Value.Year.ToString().Substring(2) + "." + jssj.Value.Month;
        }
        return ks + "～" + js;
    }

    private static string GetDocName(string pname, int id)
    {
        try {
            ResumeInfoDataContext db = new ResumeInfoDataContext();
            var q = from j in db.Jiaoybj
                    where j.UserID == id
                    orderby j.enuJyjd.DisOrder descending
                    select new { j.byyx, j.sxzy, xl = j.enuJyjd.Label };
            var o = q.First();
            return o.sxzy + "-" + o.byyx + "-" + o.xl + "-" + pname;
        }
        catch {
            return pname;
        }
    }
    private static string GetModifyTime(DateTime? d)
    {
        if (!d.HasValue) return "";
        DateTime m = d.Value;
        return "提交日期：" + m.Year + "年" + m.Month + "月" + m.Day + "日";
    }
}