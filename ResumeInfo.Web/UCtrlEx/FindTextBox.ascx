<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FindTextBox.ascx.cs" Inherits="FindTextBox" %>
<asp:TextBox ID="tb" runat="server" Width="90px" />
<asp:DropDownList ID="mlist" runat="server">
    <asp:ListItem Value="≈" Text="包含" />
    <asp:ListItem Value="=" Text="等于" />
    <asp:ListItem Value="!≈" Text="不包含" />
    <asp:ListItem Value="!=" Text="不等于" />
    <asp:ListItem Value="x.." Text="首字匹配" />
    <asp:ListItem Value="..x" Text="尾字匹配" />
    <asp:ListItem Value="!x.." Text="非首字匹配" />
    <asp:ListItem Value="!..x" Text="非尾字匹配" />
</asp:DropDownList>
