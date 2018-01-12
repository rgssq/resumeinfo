<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaseInfoEdit.aspx.cs" Inherits="BaseInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>基本信息</title>
    <link type="text/css" rel="stylesheet" href="../Css/BaseElement.css" />

    <script type="text/javascript" src="../Script/WebHelper.js"></script>

</head>
<body  background="../Images/defaultbg.png" >
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <asp:Panel ID="PanField" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td colspan="4" class="title">基 本 信 息</td>
                </tr>
                <tr>
                    <td align="right">姓名*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="PName" runat="server" />
                    </td>
                    <td align="right">性别*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="Sex" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">身份证号*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="PID" runat="server" />
                    </td>
                    <td align="right">出生日期(yyyy/mm/dd)*：</td>
                    <td align="left">
                        <uc:ReqDateBox ID="csrq" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">身高：</td>
                    <td align="left">
                        <asp:TextBox ID="sg" runat="server" />
                    </td>
                    <td align="right">体重：</td>
                    <td align="left">
                        <asp:TextBox ID="tz" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">政治面貌*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="zzmm" runat="server" />
                    </td>
                    <td align="right">民族*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="mz" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">出生地*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="csd" runat="server" />
                    </td>
                    <td align="right">籍贯*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="jg" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">户口所在地*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="hkszd" runat="server" />
                    </td>
                    <td align="right">健康状况*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="jkzk" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">婚姻状况*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="hyzk" runat="server" />
                    </td>
                    <td align="right">个人特长*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="grtc" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">手机*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="sj" runat="server" />
                    </td>
                    <td align="right">固定电话*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="yxdh" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">联系地址*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="lxdz" runat="server" />
                    </td>
                    <td align="right">E-Mail*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="email" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">期待从事专业*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="cszy" runat="server" />
                    </td>
                    <td align="right">期待工作地点1*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="gzdd1" runat="server" />
                    </td>
                </tr>
                     <td align="right">期待工作地点2：</td>
                    <td align="left">
                        <uc:ReqDropList ID="gzdd2" runat="server" />
                    </td>
                     <td align="right">期待工作地点3：</td>
                    <td align="left">
                        <uc:ReqDropList ID="gzdd3" runat="server" />
                    </td>
                </td>
                </tr>
                <tr>
                    <td align="right">期望薪酬：</td>
                    <td align="left">
                        <asp:DropDownList ID="qwxc" runat="server" />
                    </td>
                    <td align="right">应聘类别*：</td>
                    <td align="left">
                        <uc:ReqDropList ID="ypzly" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">第一外语*：</td>
                    <td align="left">
                        <uc:ReqTextBox ID="dywy" runat="server" />
                    </td>
                    <td align="right">第二外语：</td>
                    <td align="left">
                        <asp:TextBox ID="dewy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">计算机：</td>
                    <td align="left">
                        <asp:TextBox ID="jsj" runat="server" />
                    </td>
                    <td align="right">职称：</td>
                    <td align="left">
                        <asp:DropDownList ID="zc" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">教育培训：<br />
                        （限100字）</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="jypx" runat="server" Rows="4" TextMode="MultiLine" Width="500px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">学术科研：<br />
                        （限100字）</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="xsky" runat="server" Rows="4" TextMode="MultiLine" Width="500px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">社团情况：<br />
                        （限100字）</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="stqk" runat="server" Rows="4" TextMode="MultiLine" Width="500px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">奖惩情况：<br />
                        （限100字）</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="jcqk" runat="server" Rows="4" TextMode="MultiLine" Width="500px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="center">
        <span class="tip">填写完成后，请先保存，然后在“简历预览”中进行提交。</span>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />
        <asp:Button ID="btnClose" runat="server" Text="关 闭" UseSubmitBehavior="False" CausesValidation="False" Visible="false" />
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
