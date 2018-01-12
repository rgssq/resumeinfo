<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttentionEdit.aspx.cs" Inherits="Pages_Attention" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" style="padding-left:60px; padding-top:20px;">
    <div style="height:200px; line-height:200px; width:440px">
    <asp:TextBox id = "interiorAttention" runat = "server" TextMode="MultiLine" Style="overflow:hidden; height:200px; width:440px;" Visible = "false" ></asp:TextBox>
    
    <asp:TextBox ID = "outerAttention" runat = "server" TextMode = "MultiLine"  Style="overflow:hidden; height:200px; width:440px;" Visible = "false"></asp:TextBox>
    </div>
    <div style="height:50px; line-height:50px; width:440px">
    <asp:Button ID = "editAttention" runat = "server" Text ="修改"  CausesValidation ="false" UseSubmitBehavior ="false" OnClick = "editAttentionClick" Visible ="false"/>
    <asp:Button ID = "cancelEdit" runat = "server" Text ="撤销"  CausesValidation ="false" UseSubmitBehavior ="false" OnClick = "cancelEditClick" Visible ="false"/>
    </div>
    
    </form>
</body>
</html>
