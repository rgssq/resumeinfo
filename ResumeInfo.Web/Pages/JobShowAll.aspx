<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobShowAll.aspx.cs" Inherits="Pages_JobShowAll" %>

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
<body  style="background-image:url('../Images/defaultbg.png')">
    <form id="form1" runat="server">
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label1" class="black_18" style="padding-left:20px; font-weight:bold;" runat="server"  >在招职位</asp:Label>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label2" class="black_18" style="padding-left:20px; font-weight:bold;"  runat="server">校园招聘</asp:Label>
    </div>
    <div >
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink  ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>' NavigateUrl='<%#Eval("详情") %>'/>  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" >  
            <ItemTemplate>  
            <asp:LinkButton ID="LbApply" runat="server" OnClick="LbApply_Onclick" CommandArgument='<%#Eval("职位号") %>' Text='<%#Eval("申请") %>'></asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField> 
        </Columns>  
        </asp:GridView>  
    </div>
    <div style="margin:0 auto;width:80%;">
    <a ID="a1" style="padding-left:20px; font-weight:bold; text-decoration:underline"  runat="server" href="JobShowCategory.aspx?type=3">更多职位</a>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label3" class="black_18" style="padding-left:20px; font-weight:bold;"  runat="server">社会招聘</asp:Label>
    </div>
     <div>
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" /> 
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>'  NavigateUrl='<%#Eval("详情") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" >  
            <ItemTemplate>  
           <asp:LinkButton ID="LbApply" runat="server" OnClick="LbApply_Onclick" CommandArgument='<%#Eval("职位号") %>' Text='<%#Eval("申请") %>'></asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField> 
        </Columns>  
        </asp:GridView>  
    </div>
    <div style="margin:0 auto;width:80%;">
    <a ID="a2" runat="server" style="padding-left:20px; font-weight:bold; text-decoration:underline"  href="JobShowCategory.aspx?type=1">更多职位</a>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label4" class="black_18" style="padding-left:20px; font-weight:bold;"  runat="server">实习生招聘</asp:Label>
    </div>
     <div>
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />  
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>' Width="100px"  NavigateUrl='<%#Eval("详情") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:LinkButton ID="LbApply" runat="server" OnClick="LbApply_Onclick" CommandArgument='<%#Eval("职位号") %>' Text='<%#Eval("申请") %>'></asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField> 
        </Columns>  
        </asp:GridView>    
    </div>
    <div style="margin:0 auto;width:80%;">
    <a ID="a3" runat="server" style="padding-left:20px; font-weight:bold; text-decoration:underline"  href="JobShowCategory.aspx?type=2">更多职位</a>
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label ID="Label5" class="black_18" style="padding-left:20px; font-weight:bold;"  runat="server">暑期实习生招聘计划</asp:Label>
    </div>
     <div>
      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />  
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:HyperLink ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>'  NavigateUrl='<%#Eval("详情") %>'/>  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:LinkButton ID="LbApply" runat="server" OnClick="LbApply_Onclick" CommandArgument='<%#Eval("职位号") %>' Text='<%#Eval("申请") %>'></asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField> 
        </Columns>  
        </asp:GridView>    
    </div>
    <div style="margin:0 auto;width:80%;">
    <a ID="a4" runat="server" style="padding-left:20px; font-weight:bold; text-decoration:underline"  href="JobShowCategory.aspx?type=4">更多职位</a>
    </div>
    </form>
</body>
</html>
