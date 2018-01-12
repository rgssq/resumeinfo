<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JtshgxEdit.aspx.cs" Inherits="JtshgxEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家庭社会关系信息</title>
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
                    <td align="right">称谓：</td>
                    <td align="left">
                        <asp:TextBox ID="cw" runat="server" />
                    </td>
                    <td align="right">姓名：</td>
                    <td align="left">
                        <asp:TextBox ID="xm" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">年龄：</td>
                    <td align="left">
                        <uc:IntTexBox ID="nl" runat="server" />
                    </td>
                    <td align="right">政治面貌：</td>
                    <td align="left">
                        <asp:DropDownList ID="zzmm" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">工作单位：</td>
                    <td align="left">
                        <asp:TextBox ID="gzdw" runat="server" />
                    </td>
                    <td align="right">部门及职务</td>
                    <td align="left">
                        <asp:TextBox ID="bmzw" runat="server" />
                    </td>
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
