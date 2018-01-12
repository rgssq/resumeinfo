<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobApplied.aspx.cs" Inherits="Pages_JobApplied" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../css/mystyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .table{border:solid 1px black}
    .table th{border-bottom:solid 1px black;}
    .table td{border-bottom:solid 1px black;}
    </style>
</head>
<body  style="background-image:url('../Images/defaultbg.png');background-repeat: repeat;">
    <form id="form1" runat="server">
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label1" runat="server" class="black_18" style="padding-left:20px; font-weight:bold;" >我的申请</asp:Label>
    </div>
     <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label2" runat="server" class="black_18" style="padding-left:20px; font-weight:bold;" >已申请职位</asp:Label>
    </div>
   
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />   
        <Columns>  
           <asp:TemplateField HeaderText="招聘类型" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="Label" runat="server" Text='<%#Eval("招聘类型") %>' />  
            </ItemTemplate> 
            </asp:TemplateField>
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>' NavigateUrl='<%#Eval("详情") %>'  />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
            <asp:TemplateField HeaderText="状态" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("状态") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
        </Columns>  
     </asp:GridView>  
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:LinkButton ID="firstPage" runat="server" OnClick="showPage">首页</asp:LinkButton>
    <asp:LinkButton ID="previousPage" runat="server" OnClick="showPage">前一页</asp:LinkButton>
    <asp:LinkButton ID="nextPage" runat="server" OnClick="showPage" >下一页</asp:LinkButton>
    <asp:LinkButton ID="finalPage" runat="server" OnClick="showPage">最后页</asp:LinkButton>
    </div>
    </form>
</body>
</html>
