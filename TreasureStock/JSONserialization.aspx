<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSONserialization.aspx.cs" Inherits="TreasureStock.JSONserialization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="StockTickerUpdatePanel" runat="server">
            <ContentTemplate>
        <asp:GridView ID="grvTopMovers" runat="server"></asp:GridView>
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
