<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DoubleTexBox.ascx.cs" Inherits="DoubleTexBox" %>
<asp:TextBox ID="tb" runat="server" />
<asp:RangeValidator ID="v" runat="server" ControlToValidate="tb" Display="None" Type="Double" MaximumValue="999999999" MinimumValue="-999999999"
    ErrorMessage="<br/><font size='2px' color='black'>请输入数值！</font>" />
<ajaxToolkit:ValidatorCalloutExtender ID="ajx" runat="Server" TargetControlID="v" HighlightCssClass="InvaliTip" Width="180px" />
