<%@ Page Language="C#" %>

<html>
<head>
    <title>网上招聘系统&nbsp;<%=Session["UserName"]%></title>
</head>
<frameset rows="70,*" border="0" frameborder="0" framespacing="0">
    <frame id="ITop" name="ITop" scrolling="no" noresize src="TopPage.aspx" frameborder="0" marginheight="0" marginwidth="0">
    <frameset id="FrmBottom" cols="105,*" border="0" frameborder="0" framespacing="0">
        <frame id="ILeft" name="ILeft" scrolling="auto" noresize src="LeftPage.aspx" frameborder="0" marginheight="0" marginwidth="0">
        <frame name="IMain" frameborder="0" marginheight="0" marginwidth="0">
    </frameset>
    <noframes>
        <body>
            <form id="form1" runat="server">
            <div>
                <p>
                    此网页使用了框架，但您的浏览器不支持框架。
                </p>
            </div>
            </form>
        </body>
    </noframes>
</frameset>
</html>
