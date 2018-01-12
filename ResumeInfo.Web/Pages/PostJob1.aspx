<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostJob1.aspx.cs" Inherits="Pages_PostJob1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/mystyle.css" rel="stylesheet" type="text/css" />
</head>

<body  style="background-image:url('../Images/defaultbg.png');background-repeat: repeat;">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <table cellpadding="0" style="table-layout:fixed; padding-left:60px; padding-top:20px;">
        <tr style="height:34px;">
            <td align="left" style="width:100px;">
            <asp:Label ID="Label1" runat="server" class="black_14" >招聘部门*：</asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <uc:ReqDropList ID ="department" runat="server" class="black_14_2" Width="223px"></uc:ReqDropList>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="Label2" runat="server" class="black_14" Width="100px"  >联络邮箱*：</asp:Label>
            </td>
            <td align="left">
            <uc:ReqTextBox ID ="email" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></uc:ReqTextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
             <asp:Label ID="Label3" runat="server" class="black_14" Width="100px">将应聘简历自动转发至该邮箱:</asp:Label>
            </td>
            <td align="left">
            <asp:DropDownList ID = "transfer" runat="server" class="black_14_2" Width="223px"><asp:ListItem Selected = "True">是</asp:ListItem><asp:ListItem>否</asp:ListItem></asp:DropDownList>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="Label4" runat="server" class="black_14" Width="100px">职位名称*：</asp:Label>
            </td>
            <td align="left">
            <uc:ReqTextBox ID = "jobname" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></uc:ReqTextBox >
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="Label5" runat="server" class="black_14" Width="100px">工作地点*：</asp:Label>
            </td>
            <td align="left">
            <uc:ReqTextBox  ID = "location" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></uc:ReqTextBox >
            </td>
        </tr>
       
         <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="Label7" runat="server" class="black_14" Width="100px">工作职责*：</asp:Label>
            </td>
           
        </tr>
         <tr style="height:100px;">
            <td align="left" colspan="2">
            <uc:ReqTextBox  ID="responsbility" TextMode="MultiLine" runat="server" class="black_14" Width="320px" Height="100px"></uc:ReqTextBox >
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="Label8" runat="server" class="black_14" Width="100px">任职资格*：</asp:Label>
            </td> 
        </tr>
         <tr style="height:50px">
            <td align="left" colspan="2">
            <uc:ReqTextBox  ID="quality" TextMode="MultiLine" runat="server" class="black_14" Width="320px" Height="100px"></uc:ReqTextBox >
            </td>
        </tr>
        <tr style="height:34px; width:320px;" >
        <td align="center" colspan="2" >
        <asp:Button ID="post" runat="server" Text="确认发布" OnClick="post_Click"  />
        </td>
        
        </tr>
    </table>



    </form>
    
</body>
</html>
