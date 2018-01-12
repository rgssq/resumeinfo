<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileInfoEdit.aspx.cs" Inherits="FileInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>附件信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="600px">
            <hr size="1px" color="#FF6600" />
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td align="right">文件类型：</td>
                    <td align="left">
                        <asp:DropDownList ID="wjlx" runat="server" />
                    </td>
                    <td align="right">附件说明：</td>
                    <td align="left">
                        <asp:TextBox ID="fjsm" runat="server" Width="250px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">上传附件：</td>
                    <td align="left" colspan="3">
                        <asp:FileUpload ID="FileUp" runat="server" Width="450px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4"><font color="red">注意：附件大小不要超过4M。</font></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="center">
        <div id="LodingMsg" class="HideProgressDiv">
            正在等待服务器回应...<br />
            <img src="../Images/pleasewait.gif" />
        </div>
    </div>
    <div align="center">
        <span class="tip">信息更新后请在“简历预览”中进行提交。</span>
        <br />
        <asp:Button ID="btnNew" runat="server" Text="添 加" OnClick="btnNew_Click" />
        <asp:Button ID="btnEdit" runat="server" Text="修 改" OnClick="btnEdit_Click" />
    </div>

    <script type="text/javascript">
        function AskUser()
        {
            if(confirm("确定要上传附件吗？\r\n这个操作可能需要一定时间才能完成。")) {
                LodingMsg.className = "ShowProgressDiv";
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    </form>
</body>
</html>
