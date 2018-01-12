<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上招聘系统登录</title>
    <link type="text/css" rel="stylesheet" href="Css/BaseElement.css" />

    <script type="text/javascript" src="Script/WebHelper.js"></script>

</head>
<body background="Images/logbg.png">
    <form id="form1" runat="server">
    <div align="center" >
        <table>
            <tr>
                <td>
                    <br />
                    <span style="font-size: 20pt; font-family: 华文新魏; color: Black">上海市政工程设计研究总院(集团)有限公司<br />
                        网上招聘系统(管理)</span>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="width: 450px">
                        <legend><b>◆用户登录区</b></legend>
                        <table style="width: 100%">
                            <tr>
                                <td align="left">身份证号码： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLogPID" runat="server" Width="250px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">密码： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="250px" TextMode="Password" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="35" valign="middle" align="center">
                                    <asp:Button ID="btnLogin" runat="server" Text="登 录" OnClick="btnLogin_Click" />
                                    <asp:Button ID="btnRegister" runat="server" Text="尚未注册" OnClick="btnRegister_Click" />
                                    <asp:Button ID="btnGetPwd" runat="server" Text="找回密码" OnClick="btnGetPwd_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>本系统要求您的浏览器版本为：IE6.0及以上； 屏幕分辨率不低于：[1024*768] </td>
            </tr>
        </table>
    </div>
    </form>
    
</body>
</html>
