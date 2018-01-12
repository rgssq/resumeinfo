<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobEdit2.aspx.cs" Inherits="Pages_JobEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  background="../Images/defaultbg.png">
     <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
     <table cellpadding="0" style="table-layout:fixed;">
        <tr style="height:34px;">
            <td align="left" style="width:100px;">
            <asp:Label ID="name1" runat="server" class="black_14" >职位名称： </asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:TextBox ID ="name2" runat="server" TextMode="SingleLine" class="black_14_2" Width="220px"></asp:TextBox>
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
            <asp:Label ID="education1" runat="server" class="black_14" Width="100px">学历要求：</asp:Label>
            </td>
            <td align="left">
            <asp:TextBox ID = "education2" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left">
            <asp:Label ID="number1" runat="server" class="black_14" Width="100px">招聘人数： </asp:Label>
            </td>
            <td align="left">
            <asp:TextBox ID = "number2" TextMode="SingleLine" runat="server" class="black_14" Width="220px"></asp:TextBox>
            </td>
        </tr>
     </table cellpadding="0" style="table-layout:fixed;">
    <table>
       <tr style="height:34px;">
            <td align="left" style="width:100px;">
                <asp:Label ID="display" Text="在外部主页上显示： " Visible="false" runat="server" class="black_14" Width="200px"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
                 <asp:DropDownList ID="dropdownlist" runat="server" Visible="false" class="black_14_2" Width="120px">
                <asp:ListItem Text="是" Selected="True"></asp:ListItem>
                <asp:ListItem Text="否"></asp:ListItem>
                </asp:DropDownList>
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
