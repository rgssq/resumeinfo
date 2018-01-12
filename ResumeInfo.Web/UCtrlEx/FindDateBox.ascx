<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FindDateBox.ascx.cs" Inherits="FindDateBox" %>
<uc:DateTexBox ID="tb" runat="server" Width="70px" type="date" />
<asp:DropDownList ID="mlist" runat="server">

    <asp:ListItem Value="[]" Selected = "True"/>
</asp:DropDownList>
<uc:DateTexBox ID="tbend" runat="server" Width="70px" />
