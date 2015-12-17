using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreasureStockEngine;

namespace TreasureStock
{
    public partial class QuotesDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] symbols = { "AAPL", "MSFT", "IBM", "AMZN", "AMD" };
                Quotes quotes = new Quotes(symbols);

                QuotesCollection quotesCollection = new QuotesCollection();
                quotesCollection.Add(quotes);

                Session.Add("CollectionOfQuotes", quotesCollection);

                Label1.Text = "Collection Count: " + quotesCollection.Count.ToString();

                System.Web.UI.DataVisualization.Charting.Series appleSeries = Chart1.Series["Series1"];

                Quote appleQuote = quotes.QuoteBySymbol("AAPL");

                appleSeries.Points.AddXY(quotes.TimeStamp.ToLongTimeString(), appleQuote.LastTradePrice);


                Quote microsoft = quotes.QuoteBySymbol("MSFT");
                Quote ibm = quotes.QuoteBySymbol("IBM");
                Quote amazon = quotes.QuoteBySymbol("AMZN");
                Quote amd = quotes.QuoteBySymbol("AMD");

                System.Web.UI.DataVisualization.Charting.Series candlestickSeries = Chart2.Series["Series1"];
                
                candlestickSeries.Points.AddXY("Apple", appleQuote.DailyHigh, appleQuote.DailyLow, appleQuote.Open, appleQuote.LastTradePrice );
                candlestickSeries.Points.AddXY("Microsoft", microsoft.DailyHigh, microsoft.DailyLow, microsoft.Open, microsoft.LastTradePrice);
                candlestickSeries.Points.AddXY("IBM", ibm.DailyHigh, ibm.DailyLow, ibm.Open, ibm.LastTradePrice);
                candlestickSeries.Points.AddXY("Amazon", amazon.DailyHigh, amazon.DailyLow, amazon.Open, amazon.LastTradePrice);
                candlestickSeries.Points.AddXY("AMD", amd.DailyHigh, amd.DailyLow, amd.Open, amd.LastTradePrice);
            }
        }

        protected void StockTimer_Tick(object sender, EventArgs e)
        {
            string[] symbols = { "AAPL", "MSFT", "IBM", "AMZN", "AMD" };
            Quotes quotes = new Quotes(symbols);

            QuotesCollection quotesCollection = (QuotesCollection)Session["CollectionOfQuotes"];

            quotesCollection.Add(quotes);

            Session["CollectionOfQuotes"] = quotesCollection;

            Label1.Text = "Collection Count: " + quotesCollection.Count.ToString();

            foreach (Quotes collectionQuote in quotesCollection)
            {
                System.Web.UI.DataVisualization.Charting.Series appleSeries = Chart1.Series["Series1"];
                appleSeries.Points.AddXY(collectionQuote.TimeStamp.ToLongTimeString(), collectionQuote.QuoteBySymbol("AAPL").LastTradePrice);
            }
        }
    }
}