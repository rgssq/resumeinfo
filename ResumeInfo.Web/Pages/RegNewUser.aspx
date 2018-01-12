<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegNewUser.aspx.cs" Inherits="RegNewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册新用户</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
    <script type="text/javascript" src="../Script/WebHelper.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td align="right">姓名*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="PName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">身份证号*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="PID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">密码：</td>
                    <td align="left">
                        <asp:TextBox ID="pwd" runat="server" TextMode="Password" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="center">
        <br />
        <asp:Button ID="btnOK" runat="server" Text="确 认" OnClick="btnOK_Click" />
        <asp:Button ID="btnClose" runat="server" Text="关 闭" UseSubmitBehavior="False" CausesValidation="False" />
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
