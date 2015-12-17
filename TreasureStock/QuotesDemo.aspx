<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuotesDemo.aspx.cs" Inherits="TreasureStock.QuotesDemo" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quotes Demo</title>
    <style type="text/css">
        .percentChangePositive {
            color: Green;
        }

        .percentChangeNegative {
            color: Red;
        }

        .percentChangeNeutral {
            color: Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Chart ID="Chart1" runat="server">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Line"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>

                    <asp:Chart ID="Chart2" runat="server" Height="500" Width="1000">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Candlestick"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Maximum="Auto" Minimum="Auto" Interval="Auto"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Timer ID="StockTimer" runat="server" Interval="15000" OnTick="StockTimer_Tick">
            </asp:Timer>
        </div>
    </form>
</body>
</html>
