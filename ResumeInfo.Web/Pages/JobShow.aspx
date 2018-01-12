<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobShow.aspx.cs" Inherits="Pages_JobShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    td 
    {
    border-style: solid; border-width: 0px 0px 1px 0px;
    }
    </style>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
    <table cellpadding="0" style="table-layout:fixed; ">
        <tr style="height:34px;">
            <td align="left" style="width:220px;">
             <asp:Label id="department1" Text="招聘部门：　" runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label id="department2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left" style="width:220px;">
             <asp:Label ID="mail1" Text="联络邮箱：　" runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="mail2" Visible="false" runat="server"> </asp:Label>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left" style="width:220px;">
             <asp:Label ID="transfer1" Text="是否转发:"  runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="transfer2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left" style="width:220px;">
            <asp:Label ID="name1" Text="职位名称： " runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="name2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left" style="width:220px;">
            <asp:Label ID="pot1" Text="工作地点： " runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="pot2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
         <tr style="height:34px;">
            <td align="left" style="width:220px;">
            <asp:Label ID="education1" Text="学历要求： " runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="education2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="height:34px;">
            <td align="left" style="width:220px;">
            <asp:Label ID="number1" Text="招聘人数： " runat="server"></asp:Label>
            </td>
            <td align="left" style="width:220px;">
            <asp:Label ID="number2" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        
    </table>

    
    <div style="height:34px; width:440px; line-height:34px">
    <asp:Label ID="responsbility1" Text="工作职责： " runat="server" style="vertical-align:middle"></asp:Label>
    </div>
    <div style="width:440px; border-style: solid; border-width: 0px 0px 1px 0px; ">
    <asp:Label ID="responsbility2" Visible="false" runat="server"></asp:Label>
    </div>
    <div style="height:34px; width:440px; line-height:34px">
    <asp:Label ID="quality1" Text="任职资格： " runat="server"></asp:Label>
    </div>
    <div style="width:440px; border-style: solid; border-width: 0px 0px 1px 0px; ">
    <asp:Label ID="quality2" Visible="false" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
