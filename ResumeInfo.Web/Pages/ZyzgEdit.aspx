<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZyzgEdit.aspx.cs" Inherits="ZyzgEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>执业资格信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="600px">
            <hr size="1px" color="#FF6600" />
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td align="right">资质名称：</td>
                    <td align="left">
                        <asp:DropDownList ID="zg" runat="server" />
                    </td>
                    <td align="right">获得时间：</td>
                    <td align="left">
                        <uc:DateTexBox ID="hdsj" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">注册地：</td>
                    <td align="left">
                        <asp:TextBox ID="zcd" runat="server" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="center">
        <span class="tip">信息更新后请在“简历预览”中进行提交。</span>
        <br />
        <asp:Button ID="btnNew" runat="server" Text="添 加" OnClick="btnNew_Click" />
        <asp:Button ID="btnEdit" runat="server" Text="修 改" OnClick="btnEdit_Click" />
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
