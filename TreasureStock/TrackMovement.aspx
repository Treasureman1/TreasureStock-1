<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackMovement.aspx.cs" Inherits="TreasureStock.TrackMovement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="treasureStockPage">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="StockTickerUpdatePanel" runat="server">
            <ContentTemplate>
                <%--Add Grid--%>

                <asp:GridView ID="grvTopMovers" runat="server" >

                </asp:GridView> 

                
                <%--<div class="treasureStockList">
                    <div class="treasureStockListItem">
                        <asp:Label ID="AppleSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="AppleLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="AppleUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="AppleLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
              

    </div>
    </form>
</body>
</html>
