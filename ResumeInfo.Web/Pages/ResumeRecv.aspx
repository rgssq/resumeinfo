<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResumeRecv.aspx.cs" Inherits="FindResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收到简历</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
    <link type="text/css" rel="stylesheet" href="~/Css/GridView.css" />
    <script type="text/javascript" src="../Script/WebHelper.js"></script>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <table width="98%">
            <tr>
                <td class="title">收到简历</td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <asp:UpdatePanel ID="UPan" runat="server">
            <ContentTemplate>
                <wc:GridViewExt ID="ObjGrid" runat="server" OnItemRowBound="ObjGrid_ItemRowBound" OnSorting="ObjGrid_Sorting" ObjID="UserID" MulSelect="true" Width="98%">
                    <Columns>
                        <wc:ImageField ID="Inforpt" ImageUrl="~/Images/Inforpt.gif" ToolTip="点击可打印该简历" />
                        <wc:LinkField HeaderText="姓名" ID="PName" />
                        <asp:BoundField HeaderText="专业" DataField="zy" />
                        <asp:BoundField HeaderText="学历" DataField="xl" />
                        <asp:BoundField HeaderText="毕业院校" DataField="byyx" />
                        <asp:BoundField HeaderText="职称" DataField="zc" />
                        
                        <asp:BoundField HeaderText="提交时间" DataField="ModifyTime" DataFormatString="{0:d}" />
                        <asp:BoundField HeaderText="简历状态" DataField="ztLabel" />
                    </Columns>
                </wc:GridViewExt>
                <uc:GridViewPager ID="Pager" runat="server" OnPagerClick="Pager_Click" Width="98%" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="btnExport" runat="server" Text="批量导出简历" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnExport_Click" Visible="false" />
        <asp:Button ID="btnSetzf" runat="server" Text="设置作废" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnSetzf_Click" Visible="false" />
        <asp:Button ID="btnDelete" runat="server" Text="删 除" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnDelete_Click" Visible="false" />
        <asp:Button ID="btnBack" runat="server" Text="返 回" CausesValidation="false" UseSubmitBehavior="false" />
        <br />
        <br />
        <asp:DropDownList ID="ztlist" runat="server" Visible="false" />
        <asp:Button ID="btnSetzt" runat="server" Text="设置简历状态" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnSetzt_Click" Visible="false" />
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
