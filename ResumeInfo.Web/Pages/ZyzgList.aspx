﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZyzgList.aspx.cs" Inherits="ZyzgList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>执业资格信息</title>
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
                <td class="title">执业资格信息</td>
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
                <asp:BoundField HeaderText="资质名称" DataField="zgmc" />
                <asp:BoundField HeaderText="获得时间" DataField="hdsj" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText="注册地" DataField="zcd" />
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
