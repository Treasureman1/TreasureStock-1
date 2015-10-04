<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PercentageRating.aspx.cs"
    Inherits="TreasureStock.PercentageRating" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .percentChangePositive
        {
            color: Green;
        }
        .percentChangeNegative
        {
            color: Red;
        }
        .percentChangeNeutral
        {
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
                <asp:GridView ID="PercentageRatingGridView" runat="server" AllowSorting="true" OnSorting="PercentageRatingGridView_Sorting"
                    AutoGenerateColumns="false" OnRowDataBound="PercentageRatingGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Symbol" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateSymbolLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Prev Close" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePreviousCloseLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Open" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateOpenLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateLastLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% &Delta;" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePercentChangeFromPreviousCloseLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="50 Day Avg" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateFiftyDayAverageLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% &Delta;" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePercentChangeFiftyDayAverageLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="200 Day Avg" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateTwoHundredDayAverageLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% &Delta;" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePercentChangeTwoHundredDayMovingAverageLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year High" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateYearHighLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% &Delta;" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePercentChangeYearHighLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year Low" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplateYearLowLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% &Delta;" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="ItemTemplatePercentChangeYearLowLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="LastUpdatedLabel" runat="server" Text="Last Update ?"></asp:Label>
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
