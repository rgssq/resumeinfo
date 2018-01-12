<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReqDateBox.ascx.cs" Inherits="ReqDateBox" %>
<asp:TextBox ID="tb" runat="server" />
<asp:RegularExpressionValidator ID="v" runat="server" ControlToValidate="tb" Display="None" ValidationExpression="^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}(\s+(星期(日|一|二|三|四|五|六)))?$"
    ErrorMessage="<br/><font size='2px' color='black'>日期格式不正确！</font>" />
<asp:RequiredFieldValidator ID="v2" runat="server" ControlToValidate="tb" Display="None" ErrorMessage="<br/><font size='2px' color='black'>不能为空！</font>" />
<ajaxToolkit:CalendarExtender ID="c" runat="server" TargetControlID="tb" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx" runat="Server" TargetControlID="v" HighlightCssClass="InvaliTip" Width="200px" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx2" runat="Server" TargetControlID="v2" HighlightCssClass="InvaliTip" Width="150px" />
