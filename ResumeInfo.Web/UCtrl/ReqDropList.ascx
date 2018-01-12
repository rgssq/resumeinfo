<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReqDropList.ascx.cs" Inherits="ReqDropList" %>
<asp:DropDownList ID="list" runat="server">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="v" runat="server" ControlToValidate="list" Display="None" ErrorMessage="<br/><font size='2px' color='black'>必须选择！</font>" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx" runat="Server" TargetControlID="v" HighlightCssClass="InvaliTip" Width="150px" />
