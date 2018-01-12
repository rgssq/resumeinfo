<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownFile.aspx.cs" Inherits="DownFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载附件</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css">
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <div align="center">
        <asp:Label ID="labInfo" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <center>
            <asp:Button ID="btnClose" runat="server" Text="关 闭" />
        </center>
    </div>
    </form>
</body>
</html>
