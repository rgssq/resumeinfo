<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttentionShow.aspx.cs" Inherits="Pages_Attention" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
    <div style="width:440px; border-style: solid; border-width: 0px 0px 1px 0px; ">
    <center>
    <asp:Label ID="title1" runat="server" style="width:100%; text-align:center;" Font-Bold="true"  Font-Size="Larger">注 意 事 项</asp:Label>
    </center>
    </div>
    <div>
    <asp:Label ID="attention" runat="server" Width="440px" ></asp:Label>
    </div>
    </form>
</body>
</html>
