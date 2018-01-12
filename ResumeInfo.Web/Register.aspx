<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网上招聘系统注册</title>
    <link type="text/css" rel="stylesheet" href="Css/BaseElement.css" />
    <script type="text/javascript" src="Script/WebHelper.js"></script>
</head>
<body background="Images/logbg.png">
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    <br />
                    <span style="font-size: 20pt; font-family: 华文新魏; color: Black">上海市政工程设计研究总院(集团)有限公司<br />
                        招聘管理系统</span>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="width: 450px">
                        <legend><b>◆用户注册区</b></legend>
                        <table style="width: 100%">
                            <tr>
                                <td align="left">身份证号码： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPID" runat="server" Width="250px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">有效邮箱（用于找回密码）： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMail" runat="server" Width="250px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">密码： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPwd" runat="server" Width="250px" TextMode="Password" />
                                </td>
                            </tr>
                             <tr>
                                <td align="left">确认密码： </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPwd1" runat="server" Width="250px" TextMode="Password" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="35" valign="middle" align="center">
                                    <input type="reset" value="重 置" />
                                    <asp:Button ID="btnRegNew" runat="server" Text="注册新用户" OnClick="btnRegNew_Click" />
                                    <asp:Button ID="btnLogin" runat ="server" Text="直接登录" OnClick="btnLogin_Click" />
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
