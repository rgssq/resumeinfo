<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FindIntBox.ascx.cs" Inherits="FindIntBox" %>
<uc:IntTexBox ID="tb" runat="server" Width="50px" />
<asp:DropDownList ID="mlist" runat="server">
    <asp:ListItem Value="=" />
    <asp:ListItem Value=">" />
    <asp:ListItem Value="<" />
    <asp:ListItem Value=">=" />
    <asp:ListItem Value="<=" />
    <asp:ListItem Value="!=" />
    <asp:ListItem Value="[]" />
</asp:DropDownList>
<uc:IntTexBox ID="tbend" runat="server" Width="50px" />
