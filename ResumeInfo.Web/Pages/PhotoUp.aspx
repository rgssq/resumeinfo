<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhotoUp.aspx.cs" Inherits="PhotoUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>照片信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
    <div align="center">
        <table cellpadding="0" cellspacing="4" width="500px">
            <tr>
                <td colspan="2" class="title">照片上传</td>
            </tr>
            <tr>
                <td colspan="2" height="150px">
                    <asp:Image ID="imgPhoto" runat="server" Height="110" Width="90" />
                </td>
            </tr>
           
            <tr>
                <td align="right" width="100px">上传照片：</td>
                <td align="left" width="400px">
                    <asp:FileUpload ID="FileUp" runat="server" Width="100%" />
                </td>
            </tr>
            <tr>
                <td colspan="2"><font color="red">注意：照片尺寸为[90*110]，格式为[.gif,.jpg]，文件大小不超过300K。</font></td>
            </tr>
        </table>
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
        <asp:Button ID="btnNew" runat="server" Text="上传照片" OnClick="btnNew_Click" Enabled="false" />
    </div>

    <script type="text/javascript">
        var oFileChecker = document.getElementById("imgPhoto");
        function changeSrc(filePicker)
        {
            oFileChecker.src = filePicker.value;
      
            
                checkSize();
                
            
            
        }
        function checkSize()
        {
            var limit = 1024 * 300;  //300K

            if (oFileChecker.fileSize > limit) {
                alert("该照片文件大小超过300K，不能上传！");
                document.all("btnNew").disabled = true;
            }
            else {
                document.all("btnNew").disabled = false;
            }
           

            
        }
        function AskUser()
        {
            if(confirm("确定要上传照片吗？\r\n这个操作可能需要一定时间才能完成。")) {
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
