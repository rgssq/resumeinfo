<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnuList.aspx.cs" Inherits="EnuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据字典</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
    <link type="text/css" rel="stylesheet" href="~/Css/GridView.css" />
    <script type="text/javascript" src="../Script/WebHelper.js"></script>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <table width="800px">
            <tr>
                <td colspan="2" class="title">数据字典维护</td>
            </tr>
            <tr>
                <td width="100px" valign="top">
                    <asp:ListBox ID="enuList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="enuList_SelectedIndexChanged" Width="100%" Height="400px">
                        <asp:ListItem Text="专业" Value="enuZy" />
                        <asp:ListItem Text="执业资格" Value="enuZg" />
                        
                        <asp:ListItem Text="职称" Value="enuZc" />
                       
                        <asp:ListItem Text="期望月薪" Value="enuQwyx" />
                        <asp:ListItem Text="政治面貌" Value="enuZzmm" />
                        <asp:ListItem Text="文件类型" Value="enuWjlx" />
                        <asp:ListItem Text="应聘者来源" Value="enuLaiy" />
                        <asp:ListItem Text="简历状态" Value="enuZt" />
                        <asp:ListItem Text="工作地点" Value="enuGzdd" />
                    </asp:ListBox>
                </td>
                <td width="600px" valign="top">
                    <asp:UpdatePanel ID="UPan" runat="server">
                        <ContentTemplate>
                            <wc:GridViewExt ID="ObjGrid" runat="server" OnItemRowBound="ObjGrid_ItemRowBound" OnSorting="ObjGrid_Sorting" ObjID="PKID" MulSelect="true" Width="98%">
                                <Columns>
                                    <wc:LinkField HeaderText="ID" ID="PKID" />
                                    <asp:BoundField HeaderText="名称" DataField="Label" />
                                    <asp:BoundField HeaderText="显示次序" DataField="DisOrder" />
                                    <wc:BoolField HeaderText="是否显示" DataField="IsShow" />
                                </Columns>
                            </wc:GridViewExt>
                            <uc:GridViewPager ID="Pager" runat="server" OnPagerClick="Pager_Click" Width="98%" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:Button ID="btnNew" runat="server" Text="添 加" CausesValidation="false" UseSubmitBehavior="false" />
                    <asp:Button ID="btnDelete" runat="server" Text="删 除" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnDelete_Click" Visible="false" />
                    <asp:Button ID="btnRefresh" runat="server" Text="刷新列表" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnRefresh_Click" />
                </td>
            </tr>
        </table>
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
