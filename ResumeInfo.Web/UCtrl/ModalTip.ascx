<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalTip.ascx.cs" Inherits="ModalTip" %>
<asp:Button ID="hidebtn" runat="server" Style="display: none" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="hidebtn" PopupControlID="ModalDiv" BehaviorID="PopUp"
    BackgroundCssClass="ModalBackground" DropShadow="true" />
<div id="ModalDiv" class="ModalDiv" style="display: none">
    服务器正在处理请求，请稍侯...<br />
    <img src="../Images/pleasewait.gif" />
</div>
