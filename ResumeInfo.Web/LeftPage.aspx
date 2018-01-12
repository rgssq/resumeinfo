<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftPage.aspx.cs" Inherits="LeftPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="Css/BaseElement.css" />
    <link type="text/css" rel="stylesheet" href="Css/Menu.css" />

    <script type="text/javascript" src="Script/WebHelper.js"></script>

</head>
<body topmargin="0" leftmargin="2" background="Images/leftbg.png">
    <form id="form1" runat="server">
    <div>
    <asp:TreeView ID = "treeT" runat = "server"></asp:TreeView>
    </div>
    </form>

    <script type="text/javascript">
        document.onreadystatechange = init
        function init()
        {
            var o = document.getElementById("ctl06_MenuItem_0");
            if (o != null) {
                o.click();
            }
        }
    </script>

</body>
</html>
