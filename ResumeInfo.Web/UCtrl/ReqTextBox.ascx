<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReqTextBox.ascx.cs" Inherits="ReqTextBox" %>
<asp:TextBox ID="tb" runat="server" />
<asp:RequiredFieldValidator ID="v" runat="server" ControlToValidate="tb" Display="None" ErrorMessage="<br/><font size='2px' color='black'>不能为空！</font>" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx" runat="Server" TargetControlID="v" HighlightCssClass="InvaliTip" Width="150px"  />
