<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GzsxEdit.aspx.cs" Inherits="GzsxEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作实习经历信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="700px">
            <hr size="1px" color="#FF6600" />
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td align="right">类别：</td>
                    <td align="left">
                        <asp:DropDownList ID="gzsxlb" runat="server" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">开始时间(yyyy/mm/dd)：</td>
                    <td align="left">
                        <uc:ReqDateBox ID="kssj" runat="server" />
                    </td>
                    <td align="right">结束时间(yyyy/mm/dd)：</td>
                    <td align="left">
                        <uc:ReqDateBox ID="jssj" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">工作或实习单位：</td>
                    <td align="left">
                        <asp:TextBox ID="dw" runat="server" />
                    </td>
                    <td align="right">部门及职务：</td>
                    <td align="left">
                        <asp:TextBox ID="bmjzw" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">从事专业：</td>
                    <td align="left">
                        <asp:TextBox ID="cszy" runat="server" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" valign="top">工作或实习内容：<br />
                        （限250字）</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="sxnr" runat="server" Rows="5" TextMode="MultiLine" Width="500px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">证明人：</td>
                    <td align="left">
                        <asp:TextBox ID="zmr" runat="server" />
                    </td>
                    <td align="right">证明人联系电话：</td>
                    <td align="left">
                        <asp:TextBox ID="zmrlxdh" runat="server" />
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
