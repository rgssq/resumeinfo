<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopPageApplicant.aspx.cs" Inherits="TopPageApplicant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body background="Images/topbg.png" >
    <form id="form1" runat="server">
    <div >
        <table border="0" cellpadding="0" cellspacing="0" height="70" width="100%">
        <tr align="center" valign="middle">
        <td width="70%" ></td>
        <td width="30%">
        <a style="cursor :pointer;font-size: 10pt; font-family: 华文新魏; color: Black; text-decoration:underline" onclick="javascript:Register();" >注 册</a>
        <a style="cursor :pointer;font-size: 10pt; font-family: 华文新魏; color: Black; text-decoration:underline" onclick="javascript:Login();">登 陆</a>
        </td>
        </tr>
        <tr align="center" valign="middle">
        <td rowspan="2" colspan="7">
        <span style="font-size: 20pt; font-family: 华文新魏; color: Black">上海市政工程设计研究总院（集团）有限公司<br />招聘管理系统</span>
        </td>
        <td rowspan="2" ></td>
        </tr>
        
        
        
        </table>
    </div>
    </form>
    <script language="javascript">
            function Register() {
                top.window.location.href="Register.aspx";
            }
            function Login() {
                top.window.location.href="Login.aspx";
            }
    </script>
</body>
</html>
