<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobEdit1.aspx.cs" Inherits="Pages_JobEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/mystyle.css" rel="stylesheet" type="text/css" />
</head>
<body  style="background-image:url('../Images/defaultbg.png');background-repeat: repeat;">
     <form id="form1" runat="server" >
     <table cellpadding="0" style="table-layout:fixed; padding-left:60px; padding-top:20px;">
     <tr style="height:34px;">
            <td align="left" style="width:100px;">
            <asp:Label id="department1" Text="招聘部门: " Visible="false" runat="server" class="black_14"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:DropDownList ID="department2" Visible="false" runat="server" class="black_14_2" Width="223px"></asp:DropDownList>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="mail1" Text="联络邮箱： " runat="server" class="black_14" Width="100px"  ></asp:Label>
            </td>
            <td align="left">
            <asp:TextBox ID="mail2" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
             <asp:Label ID="transfer1" runat="server" class="black_14" Width="100px">将应聘简历自动转发至该邮箱:</asp:Label>
            </td>
            <td align="left">
            <asp:DropDownList ID = "transfer2" runat="server" class="black_14_2" Width="223px"><asp:ListItem Selected = "True">是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="name1" runat="server" class="black_14" Width="100px">职位名称：</asp:Label>
            </td>
            <td align="left">
            <asp:TextBox ID = "name2" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></asp:TextBox>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="pot1" runat="server" class="black_14" Width="100px">工作地点：</asp:Label>
            </td>
            <td align="left">
            <asp:TextBox ID = "pot2" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></asp:TextBox>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="responsbility1" runat="server" class="black_14" Width="100px">工作职责：</asp:Label>
            </td>  
        </tr>
        <tr style="height:100px;">
            <td align="left" colspan="2">
            <asp:TextBox ID="responsbility2" TextMode="MultiLine" runat="server" class="black_14" Width="320px" Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="quality1" runat="server" class="black_14" Width="100px">任职资格：</asp:Label>
            </td> 
        </tr>
         <tr style="height:100px">
            <td align="left" colspan="2">
            <asp:TextBox ID="quality2" TextMode="MultiLine" runat="server" class="black_14" Width="320px" Height="100px"></asp:TextBox>
            </td>
        </tr>
        
     </table>
     <div style="height:34px; width:320px;">
     <center>
     <asp:Button ID="submit" runat="server" Text="修改" OnClick="submit_click"  />
     </center>
     </div>
    </form>
</body>
</html>
