<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobMgt.aspx.cs" Inherits="Pages_JobMgt" %>

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
    <asp:Label runat="server" class="black_18" style="padding-left:20px; font-weight:bold;" >在招职位</asp:Label>
    </div>
    <div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="80%" align="center" CssClass="table" CellPadding="3" GridLines="None" BackColor="#ECF5FF" CellSpacing="0" >  
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />   
        <Columns>  
           <asp:TemplateField HeaderText="职位名称" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <asp:Label ID="Lb1" runat="server" Text='<%#Eval("职位名称") %>'  />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" >  
            <ItemTemplate>  
            <asp:Label ID="Lb2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="发布时间" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" >  
            <ItemTemplate>  
            <asp:Label ID="Lb3" runat="server" Text='<%#Eval("发布时间") %>'  />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <a href='<%#Eval("收到简历") %>'>收到简历</a>
            </ItemTemplate>  
           </asp:TemplateField> 
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <a href='<%#Eval("查看") %>'>查看 </a> 
            <a href='<%#Eval("修改") %>'>修改 </a>
            <asp:LinkButton CommandArgument='<%#Eval("停止") %>' runat="server" OnClick="cancelJob">停止</asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField>  
        </Columns>  
        </asp:GridView>  
    </div>
    <div style="margin:0 auto;width:80%;">
    <asp:Label runat="server" class="black_18" style="padding-left:20px; font-weight:bold;" >历史职位</asp:Label>
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
            <asp:Label ID="Lb1" runat="server" Text='<%#Eval("职位名称") %>'  />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="地区" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px" >  
            <ItemTemplate>  
            <asp:Label ID="Lb2" runat="server" Text='<%#Eval("地区") %>' />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="发布时间" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <asp:Label ID="Lb3" runat="server" Text='<%#Eval("发布时间") %>'  />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">  
            <ItemTemplate>  
            <a href='<%#Eval("收到简历") %>'>收到简历</a>
            </ItemTemplate>  
           </asp:TemplateField> 
           <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">  
            <ItemTemplate>  
            <a href='<%#Eval("查看") %>'>查看 </a> 
            <asp:LinkButton CommandArgument='<%#Eval("重新发布") %>' runat="server" OnClick="rePostJob">重新发布</asp:LinkButton>
            </ItemTemplate>  
           </asp:TemplateField>  
        </Columns>  
        </asp:GridView>
    </div>
    </form>
</body>
</html>
