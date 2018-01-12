<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobShowCategory.aspx.cs" Inherits="Pages_JobShowCategory" %>

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
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <div style="margin:0 auto;width:80%;">
    <asp:Label runat="server" class="black_18" style="padding-left:20px; font-weight:bold;" >在招职位</asp:Label>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label runat="server">专 业</asp:Label> 
    <asp:TextBox ID="searchMajor" runat="server"></asp:TextBox>
    <asp:Label runat="server">地 区</asp:Label>
    <asp:TextBox ID="searchPot" runat="server"></asp:TextBox>
    <asp:LinkButton ID="search" runat="server" OnClick="searchResult">搜 索</asp:LinkButton>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:label ID="Label1" runat="server" class="black_18" style="padding-left:20px; font-weight:bold;"></asp:label>
    </div>
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />  
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>' NavigateUrl='<%#Eval("详情") %>'/>  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' Width="50px"/>  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:LinkButton ID="LbApply" runat="server" OnClick="LbApply_Onclick" CommandArgument='<%#Eval("职位号") %>' Text='<%#Eval("申请") %>'></asp:LinkButton>
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
