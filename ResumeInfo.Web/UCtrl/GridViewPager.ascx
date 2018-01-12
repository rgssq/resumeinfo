<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GridViewPager.ascx.cs" Inherits="GridViewPager" %>
<asp:Panel ID="PanPager" runat="server" CssClass="PagerRow" HorizontalAlign="Right">
    <asp:Label ID="TotalCount" runat="server" Text="总数:[xxxxx]" />&nbsp; Page
    <asp:TextBox ID="txtGoPage" runat="server" Width="25px" ToolTip="输入数字后按回车" AutoPostBack="true" OnTextChanged="txtGoPage_TextChanged" />
    Of
    <asp:Label ID="PageCount" runat="server" Text="xxxx" />&nbsp;
    <asp:LinkButton ID="FirstPage" runat="server" Text="首页" CausesValidation="false" OnClick="pager_click" />
    <asp:LinkButton ID="PrePage" runat="server" Text="上一页" CausesValidation="false" OnClick="pager_click" />
    <asp:LinkButton ID="NextPage" runat="server" Text="下一页" CausesValidation="false" OnClick="pager_click" />
    <asp:LinkButton ID="LastPage" runat="server" Text="末页" CausesValidation="false" OnClick="pager_click" />&nbsp; 每页显示:
    <asp:DropDownList ID="LstPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="LstPageSize_SelectedIndexChanged">
        <asp:ListItem Value="5" />
        <asp:ListItem Value="10" Selected="True" />
        <asp:ListItem Value="15" />
        <asp:ListItem Value="20" />
        <asp:ListItem Value="25" />
        <asp:ListItem Value="30" />
    </asp:DropDownList>
</asp:Panel>
