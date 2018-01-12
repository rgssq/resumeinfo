<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateTexBox.ascx.cs" Inherits="DateTexBox" %>
<asp:TextBox ID="tb" runat="server" />
<asp:RegularExpressionValidator ID="v" runat="server" ControlToValidate="tb" Display="None" ValidationExpression="^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}(\s+(星期(日|一|二|三|四|五|六)))?$"
    ErrorMessage="<br/><font size='2px' color='black'>日期格式不正确！</font>" />
<ajaxToolkit:CalendarExtender ID="c" runat="server" TargetControlID="tb" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx" runat="Server" TargetControlID="v" HighlightCssClass="InvaliTip" Width="200px" />
