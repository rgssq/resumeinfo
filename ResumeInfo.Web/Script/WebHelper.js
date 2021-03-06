/*--------PopWindow-----------*/
function PopWin(sUrl, sWinName, iWidth, iHeight, sPosition)
{
    var sSettings = ",resizable=yes,toolbar=no,menubar=no,location=no,status=yes,scrollbars=yes";
	PopWinEx(sUrl, sWinName, iWidth, iHeight, sSettings, sPosition);
}
function PopWinFix(sUrl, sWinName, iWidth, iHeight, sPosition)
{
    var sSettings = ",resizable=no,toolbar=no,menubar=no,location=no,status=yes";
	PopWinEx(sUrl, sWinName, iWidth, iHeight, sSettings, sPosition);
}
function PopWinMax(sUrl, sWinName)
{
    var sSettings = "left=0,top=0,width=" + (screen.availWidth - 7) + ",height=" + (screen.availHeight - 51) + ",toolbar=no,menubar=no,location=no,status=yes,resizable=yes";
    window.open(sUrl, sWinName, sSettings);
}
function PopWinEx(sUrl, sWinName, iWidth, iHeight, sSetting, sPosition)
{
	var sSettings = "width=" + iWidth + ",height=" + iHeight + sSetting;
	switch (sPosition.toLowerCase()) {
		case "c" :
			sSettings = sSettings + ",left=" + (screen.availWidth - iWidth) / 2 + ",top=" + (screen.availHeight - iHeight) / 2;
			break;
		case "l" :
			sSettings = sSettings + ",left=0,top=" + (screen.availHeight - iHeight) / 2;
			break;
		case "r" :
			sSettings = sSettings + ",left=" + (screen.availWidth - iWidth) + ",top=" + (screen.availHeight - iHeight) / 2;
			break;
		case "t" :
			sSettings = sSettings + ",left=" + (screen.availWidth - iWidth) / 2 + ",top=0";
			break;
		case "b" :
			sSettings = sSettings + ",left=" + (screen.availWidth - iWidth) / 2 + ",top=" + (screen.availHeight - iHeight);
			break;
		case "tl" :
			sSettings = sSettings + ",left=0,top=0";
			break;
	}
	window.open(sUrl, sWinName, sSettings);
}
function ModWin(url, width, height)
{
    window.showModelessDialog(url, "", "dialogWidth:" + width + "px;dialogHeight:" + height + "px;help:no;status:no");
}
/*--------属性Div-----------*/
function SwichPropDiv(DivID)
{
    if (document.all(DivID).style.display == "none") {
	    document.all(DivID).style.display = "";
	    document.all("lk_" + DivID).innerText = "[▲]";
	    document.all("lk_" + DivID).title = "隐藏";
	}
    else {
	    document.all(DivID).style.display = "none";
	    document.all("lk_" + DivID).innerText = "[▼]";
	    document.all("lk_" + DivID).title = "显示";
    }
}
/*-------MenuItem MouseOver------*/
var ItemSelected;
function ItemHover(obj)
{
	if (obj.className != "SelectedRow") {
	    obj.className = "HoverRow";
    }
}
function ItemOut(obj)
{
	if (obj.className != "SelectedRow") {
	    obj.className = "Row";
	}
}
function ItemClick(obj)
{
    if (ItemSelected != null) {
        ItemSelected.className = "Row";
    }
    obj.className = "SelectedRow";
    ItemSelected = obj;
}
/*---------------GridView Row MouseOver-------------*/
var RowCss;
var OldObj;
function RowHover(obj)
{
	if (obj.className != "SelectedRow") {
	    RowCss = obj.className;
	    obj.className = "HoverRow";
    }
}
function RowOut(obj)
{
	if (obj.className != "SelectedRow")	{
	    obj.className = RowCss;
	}
}
function RowClick(obj)
{
    if (OldObj != null) {
        OldObj.className = OldObj.style.type;
    }
    obj.className = "SelectedRow";
    OldObj = obj;
}