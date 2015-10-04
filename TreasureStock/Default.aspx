<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TreasureStock.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Treasure Stocks</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="treasureStockPage">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="StockTickerUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="treasureStockList">
                    <div class="treasureStockListItem">
                        <h3>
                            <asp:Label ID="AppleSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label></h3>
                        <p>
                            Open:&nbsp;<asp:Label ID="OpenLabel" runat="server" Text="?"></asp:Label><br />
                            Last Trade Price:&nbsp;<asp:Label ID="AppleLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                            Up/Down:&nbsp;<asp:Label ID="AppleUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        </p>
                        <p>
                            Previous Close:&nbsp;<asp:Label ID="PreviousCloseLabel" runat="server" Text="?"></asp:Label><br />
                            % Change from Previous Close:&nbsp;<asp:Label ID="PercentChangeFromPreviousCloseLabel"
                                runat="server" Text="?"></asp:Label>
                        </p>
                        <p>
                            50 Day Avg:&nbsp;<asp:Label ID="FiftyDayMovingAverageLabel" runat="server" Text="?"></asp:Label><br />
                            % Change from 50 Day Avg:&nbsp;<asp:Label ID="PercentChangeFromFiftyDayMovingAverageLabel"
                                runat="server" Text="?"></asp:Label>
                        </p>
                        <p>
                            200 Day Avg:&nbsp;<asp:Label ID="TwoHundredMovingAverageLabel" runat="server" Text="?"></asp:Label><br />
                            % Change from 200 Day Avg:&nbsp;<asp:Label ID="PercentChangeFromTwoHundredDayMovingAverageLabel"
                                runat="server" Text="?"></asp:Label>
                        </p>
                        <p>
                            Year High:&nbsp;<asp:Label ID="YearHighLabel" runat="server" Text="?"></asp:Label><br />
                            % Change from Year High:&nbsp;<asp:Label ID="PercentChangeFromYearHighLabel" runat="server"
                                Text="?"></asp:Label>
                        </p>
                        <p>
                            Year Low:&nbsp;<asp:Label ID="YearLowLabel" runat="server" Text="?"></asp:Label><br />
                            % Change from Year Low:&nbsp;<asp:Label ID="PercentChangeFromYearLowLabel" runat="server"
                                Text="?"></asp:Label>
                        </p>
                        <p>Last Update:&nbsp;<asp:Label ID="AppleLastUpdateLabel" runat="server" Text="?"></asp:Label></p>
                    </div>
                    <div class="treasureStockListItem">
                        <asp:Label ID="MicrosoftSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="MicrosoftLastTradePriceLabel" runat="server"
                            Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="MicrosoftUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="MicrosoftLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>
                    <div class="treasureStockListItem">
                        <asp:Label ID="IBMSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="IBMLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="IBMUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="IBMLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>
                    <div class="treasureStockListItem">
                        <asp:Label ID="AmazonSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="AmazonLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="AmazonUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="AmazonLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>
                    <div class="treasureStockListItem">
                        <asp:Label ID="AMDSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="AMDLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="AMDUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="AMDLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>
                    <div class="treasureStockListItem">
                        <asp:Label ID="DellSymbolLabel" runat="server" Text="?" CssClass="treasureStockListItemHeading"></asp:Label><br />
                        Last Trade Price:&nbsp;<asp:Label ID="DellLastTradePriceLabel" runat="server" Text="?"></asp:Label><br />
                        Up/Down:&nbsp;<asp:Label ID="DellUpDownLabel" runat="server" Text="?"></asp:Label><br />
                        Last Update:&nbsp;<asp:Label ID="DellLastUpdateLabel" runat="server" Text="?"></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="StockTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="StockTimer" runat="server" Interval="25000" OnTick="StockTimer_Tick">
        </asp:Timer>
    </div>
    </form>
</body>
</html>
