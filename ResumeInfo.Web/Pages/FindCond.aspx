<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindCond.aspx.cs" Inherits="FindCond" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>简历查询</title>
    <link type="text/css" rel="stylesheet" href="../Css/BaseElement.css" />
    <script type="text/javascript" src="../Script/WebHelper.js"></script>
</head>
<body background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <br />
        <span class="title">请指定查询条件，可以多条件组合。指定后点击【查询】按钮。</span>
        <asp:Button ID="btnOK" runat="server" Text="查 询" OnClick="btnOK_Click" />
        <asp:Panel ID="PanBaseInfo" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td colspan="4" class="title">基 本 信 息</td>
                </tr>
                <tr>
                    <td align="right">姓名：</td>
                    <td align="left">
                        <uc:FindTextBox ID="PName" runat="server" FieldType="string" />
                    </td>
                    <td align="right">性别：</td>
                    <td align="left">
                        <uc:FindSelect ID="Sex" runat="server" FieldType="select" />
                    </td>
                </tr>
                <tr>
                    <td align="right">政治面貌：</td>
                    <td align="left">
                        <uc:FindSelect ID="zzmm" runat="server" FieldType="select" />
                    </td>
                    <td align="right">出生地：</td>
                    <td align="left">
                        <uc:FindTextBox ID="csd" runat="server" FieldType="string" />
                    </td>
                </tr>
                <tr>
                    <td align="right">籍贯：</td>
                    <td align="left">
                        <uc:FindTextBox ID="jg" runat="server" FieldType="string" />
                    </td>
                     <td align="right">户口所在地：</td>
                    <td align="left">
                        <uc:FindTextBox ID="hkszd" runat="server" FieldType="string" />
                    </td>
                </tr>
                <tr>
                   
                    <td align="right">健康状况：</td>
                    <td align="left">
                        <uc:FindTextBox ID="jkzk" runat="server" FieldType="string" />
                    </td>
                     <td align="right">婚姻状况：</td>
                    <td align="left">
                        <uc:FindSelect ID="hyzk" runat="server" FieldType="select" />
                    </td>
                </tr>
               
              
                       
                <tr>
                    <td align="right">期望薪酬：</td>
                    <td align="left">
                        <uc:FindSelect ID="qwxc" runat="server" FieldType="select" />
                    </td>
                    <td align="right">第一外语：</td>
                    <td align="left">
                        <uc:FindTextBox ID="dywy" runat="server" FieldType="string" />
                    </td>
                </tr>
                <tr>
                    <td align="right">第二外语：</td>
                    <td align="left">
                        <uc:FindTextBox ID="dewy" runat="server" FieldType="string" />
                    </td>
                    <td align="right">职称：</td>
                    <td align="left">
                        <uc:FindSelect ID="zc" runat="server" FieldType="select" />
                    </td>
                </tr>
                <tr>
                    
                    <td align="right">提交时间：</td>
                    <td align="left">
                        <uc:FindDateBox ID="ModifyTime" runat="server" FieldType="date" />
                    </td>
                    <td align="right">期待从事专业：</td>
                    <td align="left">
                        <uc:FindSelect ID="cszy" runat="server" FieldType="select" />
                    </td>
                </tr>
                 <tr>
                    
                    <td align="right">期待工作地点1：</td>
                    <td align="left">
                        <uc:FindSelect ID="gzdd1" runat="server" FieldType="select" />
                    </td>
                    <td align="right">期待工作地点2：</td>
                    <td align="left">
                        <uc:FindSelect ID="gzdd2" runat="server" FieldType="select" />
                    </td>
                </tr>
                <tr>
                    
                    <td align="right">期待工作地点3：</td>
                    <td align="left">
                        <uc:FindSelect ID="gzdd3" runat="server" FieldType="select" />
                    </td>
                    <td align="right"></td>
                    <td align="left"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanJybj" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td colspan="4" class="title">教 育 背 景</td>
                </tr>
                <tr>
                    <td align="right">最高学历：</td>
                    <td align="left">
                        <uc:FindSelect ID="jyjd" runat="server" FieldType="select" />
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">毕业院校：</td>
                    <td align="left">
                        <uc:FindTextBox ID="byyx" runat="server" FieldType="string" />
                    </td>
                    <td align="right">所学专业：</td>
                    <td align="left">
                        <uc:FindTextBox ID="sxzy" runat="server" FieldType="string" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanZyzg" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td colspan="2" class="title">执 业 资 格</td>
                </tr>
                <tr>
                    <td align="right">资质名称：</td>
                    <td align="left">
                        <uc:FindSelect ID="zg" runat="server" FieldType="select" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanGzsx" runat="server" Width="650px">
            <table cellpadding="0" cellspacing="4" width="98%">
                <tr>
                    <td colspan="4" class="title">工作实习经历</td>
                </tr>
                <tr>
                    <td align="right">曾工作或实习单位：</td>
                    <td align="left">
                        <uc:FindTextBox ID="dw" runat="server" FieldType="string" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp; </td>
                </tr>
              
            </table>
        </asp:Panel>
       
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
