<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindZF.aspx.cs" Inherits="FindZF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>作废简历查询结果</title>
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
                <td class="title">作废简历查询结果列表</td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <asp:UpdatePanel ID="UPan" runat="server">
            <ContentTemplate>
                <wc:GridViewExt ID="ObjGrid" runat="server" OnItemRowBound="ObjGrid_ItemRowBound" OnSorting="ObjGrid_Sorting" ObjID="UserID" MulSelect="true"
                    Width="98%">
                    <Columns>
                        <wc:ImageField ID="Inforpt" ImageUrl="~/Images/Inforpt.gif" ToolTip="点击可打印该简历" />
                        <wc:LinkField HeaderText="姓名" ID="PName" />
                        <asp:BoundField HeaderText="性别" DataField="SexLabel" />
                        <asp:BoundField HeaderText="身份证号码" DataField="PID" />
                        <asp:BoundField HeaderText="提交时间" DataField="ModifyTime" DataFormatString="{0:d}" />
                    </Columns>
                </wc:GridViewExt>
                <uc:GridViewPager ID="Pager" runat="server" OnPagerClick="Pager_Click" Width="98%" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="btnUndozf" runat="server" Text="取消作废" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnUndozf_Click" Visible="false" />
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
