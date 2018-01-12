<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnuEdit.aspx.cs" Inherits="EnuEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据字典信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />

    <script type="text/javascript" src="../Script/WebHelper.js"></script>

</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="300px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td align="right">名称*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="Label" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">显示次序：</td>
                    <td align="left">
                        <uc:IntTexBox ID="DisOrder" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">是否显示：</td>
                    <td align="left">
                        <asp:DropDownList ID="IsShow" runat="server">
                            <asp:ListItem Text="是" Value="True" />
                            <asp:ListItem Text="否" Value="False" />
                        </asp:DropDownList>
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
