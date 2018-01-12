<%@ Page Language="C#" %>

<html>
<head>
    <title>招聘管理系统></title>
</head>
<frameset rows="70,*" border="0" frameborder="0" framespacing="0">
    <frame id="ITop" name="ITop" scrolling="no" noresize src="TopPageApplicant.aspx" frameborder="0" marginheight="0" marginwidth="0">
    <frame name="IMain" scrolling="auto" noresize src="Pages/JobShowAll.aspx" frameborder="0" marginheight="0" marginwidth="0">
</frame>
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
