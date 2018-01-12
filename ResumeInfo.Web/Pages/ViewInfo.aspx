<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInfo.aspx.cs" Inherits="ViewInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>简历预览</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
    <link type="text/css" rel="stylesheet" href="~/Css/GridView.css" />

    <script type="text/javascript" src="../Script/WebHelper.js"></script>

</head>
<body background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <div align="center">
        <asp:Panel ID="pantip" runat="server">
            <span class="title">请检查您的简历信息，确定无误后点击【提交简历】按钮。</span>
            <asp:Button ID="btnOK" runat="server" Text="提交简历" OnClick="btnOK_Click" />
        </asp:Panel>
        <asp:Panel ID="PanField" runat="server" Width="700px">
            <table cellpadding="2" cellspacing="4" width="700px">
                <tr>
                    <td class="title" colspan="6">基本信息 </td>
                </tr>
                <tr>
                    <td align="right" width="90px">姓名：</td>
                    <td align="left" width="150px">
                        <asp:Label ID="PName" runat="server" />
                    </td>
                    <td align="right" width="90px">性别：</td>
                    <td align="left" width="150px">
                        <asp:Label ID="Sex" runat="server" />
                    </td>
                    <td colspan="2" rowspan="6" width="220px">
                        <asp:Image ID="imgPhoto" runat="server" Height="110" Width="90" /></td>
                </tr>
                <tr>
                    <td align="right">身份证号：</td>
                    <td align="left">
                        <asp:Label ID="PID" runat="server" />
                    </td>
                    <td align="right">出生日期：</td>
                    <td align="left">
                        <asp:Label ID="csrq" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">政治面貌：</td>
                    <td align="left">
                        <asp:Label ID="zzmm" runat="server" />
                    </td>
                    <td align="right">民族：</td>
                    <td align="left">
                        <asp:Label ID="mz" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">出生地：</td>
                    <td align="left">
                        <asp:Label ID="csd" runat="server" />
                    </td>
                    <td align="right">籍贯：</td>
                    <td align="left">
                        <asp:Label ID="jg" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">户口所在地：</td>
                    <td align="left">
                        <asp:Label ID="hkszd" runat="server" />
                    </td>
                    <td align="right">健康状况：</td>
                    <td align="left">
                        <asp:Label ID="jkzk" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">婚姻状况：</td>
                    <td align="left">
                        <asp:Label ID="hyzk" runat="server" />
                    </td>
                    <td align="right">个人特长：</td>
                    <td align="left">
                        <asp:Label ID="grtc" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">手机：</td>
                    <td align="left">
                        <asp:Label ID="sj" runat="server" />
                    </td>
                    <td align="right">固定电话：</td>
                    <td align="left">
                        <asp:Label ID="yxdh" runat="server" />
                    </td>
                    <td align="right" width="80px">E-Mail：</td>
                    <td align="left" width="140px">
                        <asp:Label ID="email" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">联系地址：</td>
                    <td align="left" colspan="5">
                        <asp:Label ID="lxdz" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">职称：</td>
                    <td align="left">
                        <asp:Label ID="zc" runat="server" />
                    </td>
                    <td align="right">期望薪酬：</td>
                    <td align="left">
                        <asp:Label ID="qwxc" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">第一外语：</td>
                    <td align="left">
                        <asp:Label ID="dywy" runat="server" />
                    </td>
                    <td align="right">第二外语：</td>
                    <td align="left">
                        <asp:Label ID="dewy" runat="server" />
                    </td>
                    <td align="right">计算机：</td>
                    <td align="left">
                        <asp:Label ID="jsj" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">工作地点1：</td>
                    <td align="left">
                        <asp:Label ID="gzdd1" runat="server" />
                    </td>
                    <td align="right">工作地点2：</td>
                    <td align="left">
                        <asp:Label ID="gzdd2" runat="server" />
                    </td>
                    <td align="right">工作地点3：</td>
                    <td align="left">
                        <asp:Label ID="gzdd3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">教育培训：</td>
                    <td align="left" colspan="5">
                        <asp:Label ID="jypx" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">学术科研：</td>
                    <td align="left" colspan="5">
                        <asp:Label ID="xsky" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">社团情况：</td>
                    <td align="left" colspan="5">
                        <asp:Label ID="stqk" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">奖惩情况：</td>
                    <td align="left" colspan="5">
                        <asp:Label ID="jcqk" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <span class="title">教育背景</span>
        <wc:GridViewExt ID="gvJybj" runat="server" SimpleList="true" Width="700px">
            <Columns>
                <asp:BoundField HeaderText="教育阶段" DataField="jyjd" />
                <asp:BoundField HeaderText="开始时间" DataField="kssj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="结束时间" DataField="jssj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="毕业院校" DataField="byyx" />
                <asp:BoundField HeaderText="所学专业" DataField="sxzy" />
                
                <asp:BoundField HeaderText="导师" DataField="ds" />
            </Columns>
        </wc:GridViewExt>
        <span class="title">执业资格</span>
        <wc:GridViewExt ID="gvZyzg" runat="server" SimpleList="true" Width="700px">
            <Columns>
                <asp:BoundField HeaderText="资质名称" DataField="zgmc" />
                <asp:BoundField HeaderText="获得时间" DataField="hdsj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="注册地" DataField="zcd" />
            </Columns>
        </wc:GridViewExt>
        <span class="title">工作实习经历</span>
        <wc:GridViewExt ID="gvGzsx" runat="server" SimpleList="true" Width="700px">
            <Columns>
                <asp:BoundField HeaderText="类别" DataField="lb">
                <ItemStyle Width="50px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="开始时间" DataField="kssj" DataFormatString="{0:d}">
                <ItemStyle Width="120px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="结束时间" DataField="jssj" DataFormatString="{0:d}">
                <ItemStyle Width="120px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="工作或实习单位" DataField="dw">
                <ItemStyle Width="100px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="从事专业" DataField="cszy">
                <ItemStyle Width="100px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="部门及职务" DataField="bmjzw">
                <ItemStyle Width="100px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="证明人" DataField="zmr">
                <ItemStyle Width="110px" />  
                </asp:BoundField>
            </Columns>
        </wc:GridViewExt>
        <span class="title">工作实习内容</span>
        <wc:GridViewExt ID="gvGzsxnr" runat="server" SimpleList="true" Width="700px">
            <Columns>
                <asp:BoundField HeaderText="类别" DataField="lb">
                <ItemStyle Width="50px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="开始时间" DataField="kssj" DataFormatString="{0:d}">
                <ItemStyle Width="120px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="结束时间" DataField="jssj" DataFormatString="{0:d}">
                <ItemStyle Width="120px" />  
                </asp:BoundField>
                <asp:BoundField HeaderText="工作或实习内容" DataField="sxnr" HtmlEncode="false">
                <ItemStyle Width="410px" />  
                </asp:BoundField>
            </Columns>
        </wc:GridViewExt>
        <span class="title">家庭社会关系</span>
        <wc:GridViewExt ID="gvJtshgx" runat="server" SimpleList="true" Width="700px">
            <Columns>
                <asp:BoundField HeaderText="称谓" DataField="cw" />
                <asp:BoundField HeaderText="姓名" DataField="xm" />
                <asp:BoundField HeaderText="年龄" DataField="nl" />
                <asp:BoundField HeaderText="政治面貌" DataField="zzmm" />
                <asp:BoundField HeaderText="工作单位" DataField="gzdw" />
                <asp:BoundField HeaderText="部门/职务" DataField="bmzw" />
            </Columns>
        </wc:GridViewExt>
        <span class="title">附件信息</span>
        <wc:GridViewExt ID="gvFileInfo" runat="server" OnItemRowBound="gvFileInfo_ItemRowBound" OnSorting="gvFileInfo_Sorting" ObjID="FileID"
            Width="700px">
            <Columns>
                <wc:LinkField HeaderText="文件名称" ID="FName" />
                <asp:BoundField HeaderText="文件类型" DataField="wjlx" />
                <asp:BoundField HeaderText="长度（字节）" DataField="FLength" DataFormatString="{0:n0}" />
                <asp:BoundField HeaderText="上传时间" DataField="UpTime" />
                <asp:BoundField HeaderText="附件说明" DataField="fjsm" />
            </Columns>
        </wc:GridViewExt>
    </div>
    </form>
</body>
</html>
