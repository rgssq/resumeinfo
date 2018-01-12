<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostJob2.aspx.cs" Inherits="Pages_PostJob2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function insertTable(col, row) {
             if (event.ctrlKey && event.keyCode == 86) {
                 insertTableOnpaste(col, row);
                 return false;
             }
         }

         function insertTableOnpaste(col, row) {
             var table4 = document.getElementById("GridView1");
             var txtObj = window.clipboardData.getData("Text");
             if (txtObj.indexOf("\r\n") != -1) {
                 event.keyCode = 0;

                 var sheetrows = txtObj.split("\r\n");
                 for (var i = 0; i < sheetrows.length - 1; i++) {
                     var sheetcols = sheetrows[i].split("\t");

                     for (var j = 0; j < sheetcols.length; j++) {
                         if (row + i <= table4.rows.length - 1 && col + j <= table4.rows[i].cells.length - 1) {
                             var value1 = table4.rows[row + i].cells[col + j];
                             var aInput = value1.getElementsByTagName("input");
                             aInput[0].value = sheetcols[j];

                         }
                     }
                 }
             }
         }  
        </script>  
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
    <asp:Label ID="display" Text="在外部主页上显示： " Visible="false" runat="server"></asp:Label>
    <asp:DropDownList ID="dropdwonlist" runat="server" Visible="false" >
        <asp:ListItem Text="是" Selected="True"></asp:ListItem>
        <asp:ListItem Text="否"></asp:ListItem>
     </asp:DropDownList>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="500px">  
        <Columns>  
           <asp:TemplateField HeaderText="职位名称">  
            <ItemTemplate>  
            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("职位名称") %>' onpaste="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="工作地点" >  
            <ItemTemplate>  
            <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("工作地点") %>' onpaste="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="学历要求" >  
            <ItemTemplate>  
            <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("学历要求") %>' onpaste="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" />  
            </ItemTemplate>  
           </asp:TemplateField>  
           <asp:TemplateField HeaderText="招聘人数">  
            <ItemTemplate>  
            <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("招聘人数") %>' onpaste="insertTableOnpaste(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" onKeyDown="insertTable(this.parentNode.cellIndex,this.parentNode.parentNode.rowIndex);return false;" />  
            </ItemTemplate>  
           </asp:TemplateField>   
        </Columns>  
        </asp:GridView>
        <table>
        <tr style="width:500px">
        <td style="width:250px;" align="center">
        <asp:Button ID="btn_add" runat="server" Text="添加行" OnClick="onClickAdd" width="100px"/>
        </td>
        <td style="width:250px;" align="center">
        <asp:Button ID="btn_submit" OnClick="onClickSubmit" runat="server" Text="提交" width="100px"/>
        </td>
        </tr>

        </table>  

    </form>
     
</body>
</html>
