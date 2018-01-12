<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopPage.aspx.cs" Inherits="TopPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="Css/BaseElement.css">
</head>
<body background="Images/topbg.png">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" height="70" width="100%">
        <tr align="center" valign="middle">
        <td width="70%" ></td>
        <td width="30%">
        <asp:Label ID="labInfo" runat="server" style="font-size: 10pt; font-family: 华文新魏; color:Black"></asp:Label>
        
        <a style="cursor :pointer;font-size: 10pt; font-family: 华文新魏; color: Black; text-decoration:underline" onclick="javascript:Logout();" >
                  退出</a>
        </td>
        </tr>
        <tr align="center" valign="middle">
        <td rowspan="1" colspan="7">
        <span style="font-size: 20pt; font-family: 华文新魏; color: Black">上海市政工程设计研究总院（集团）有限公司<br />招聘管理系统</span>
        </td>
        <td rowspan="1" ></td>
        </tr>
        
        
        
        </table>
    </div>
    </form>

    <script language="javascript">
        function Logout()
        {
            top.window.location.href = "Logout.aspx";
        }
    </script>

</body>
</html>
