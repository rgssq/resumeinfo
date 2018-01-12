<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JybjList.aspx.cs" Inherits="JybjList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教育背景信息</title>
    <link type="text/css" rel="stylesheet" href="~/Css/BaseElement.css" />
    <link type="text/css" rel="stylesheet" href="~/Css/GridView.css" />

    <script type="text/javascript" src="../Script/WebHelper.js"></script>

</head>
<body  background="../Images/defaultbg.png">
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tsm" runat="Server" EnableScriptGlobalization="true" />
    <div align="center">
        <table width="98%">
            <tr>
                <td class="title">教育背景信息</td>
            </tr>
        </table>
    </div>
    <br />
    <div align="center">
        <wc:GridViewExt ID="ObjGrid" runat="server" OnItemRowBound="ObjGrid_ItemRowBound" OnSorting="ObjGrid_Sorting" ObjID="PKID"
            Width="98%">
            <Columns>
                <wc:ImageField HeaderText="删除" ID="ImgDel" ImageUrl="~/Images/delete.gif" ToolTip="点击删除该记录" />
                <wc:ImageField HeaderText="修改" ID="ImgInfo" ImageUrl="~/Images/property.gif" ToolTip="点击可修改记录" />
                <asp:BoundField HeaderText="教育阶段" DataField="jyjd" />
                <asp:BoundField HeaderText="开始时间" DataField="kssj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="结束时间" DataField="jssj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="毕业院校" DataField="byyx" />
                <asp:BoundField HeaderText="所学专业" DataField="sxzy" />
               
                <asp:BoundField HeaderText="导师" DataField="ds" />
            </Columns>
        </wc:GridViewExt>
        <div align="left" style="width: 98%">
            <br />
            <asp:Button ID="btnRefresh" runat="server" Text="刷新列表" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnRefresh_Click"/>
        </div>
    </div>
    <uc:ModalTip ID="mtip" runat="server" />
    </form>
</body>
</html>
