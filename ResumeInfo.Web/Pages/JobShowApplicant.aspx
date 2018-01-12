<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobShowApplicant.aspx.cs" Inherits="Pages_JobShowApplicant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    #div1
    {
    height:34px; width:440px; border-style: solid; border-width: 0px 0px 1px 0px; line-height:34px;
    }
    #div2
    {
    width:440px; border-style: solid; border-width: 0px 0px 1px 0px; 
    }
    #div3
    {
    height:34px; width:440px; line-height:34px;
    }
    </style>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
    <div id="div1">
    <asp:Label id="department1" Text="招聘部门：　"  runat="server" style="width:220px; text-align:left;"></asp:Label>
    <asp:Label id="department2" Visible="false" runat="server" style="width:220px; text-align:left;"></asp:Label>
    </div>
    <div id="div1">
    <asp:Label ID="name1" Text="职位名称： "  runat="server" style="width:220px; text-align:left;"></asp:Label>
    <asp:Label ID="name2" Visible="false" runat="server" style="width:220px; text-align:left;"></asp:Label>
    </div>
    <div id="div1">
    <asp:Label ID="pot1" Text="工作地点： "  runat="server" style="width:220px; text-align:left;"></asp:Label>
    <asp:Label ID="pot2" Visible="false" runat="server" style="width:220px; text-align:left;"></asp:Label>
    </div>

    <div id="div1">
    <asp:Label ID="education1" Text="学历要求： "  runat="server" style="width:220px; text-align:left;"></asp:Label>
    <asp:Label ID="education2" Visible="false" runat="server" style="width:220px; text-align:left;"></asp:Label>
    </div>
    <div id="div1">
    <asp:Label ID="number1" Text="招聘人数： "  runat="server" style="width:220px; text-align:left;"></asp:Label>
    <asp:Label ID="number2" Visible="false" runat="server" style="width:220px; text-align:left;"></asp:Label>
    </div>
    <div id="div3">
    <asp:Label ID="responsbility1" Text="工作职责： "  runat="server"></asp:Label>
    </div>
    <div id="div2">
    <asp:Label ID="responsbility2" Visible="false" runat="server"></asp:Label>
    </div>
    <div id="div3">
    <asp:Label ID="quality1" Text="任职资格： "  runat="server"></asp:Label>
    </div>
    <div id="div2">
    <asp:Label ID="quality2" Visible="false" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
