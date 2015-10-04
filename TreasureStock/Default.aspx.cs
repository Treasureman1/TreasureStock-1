using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreasureStockEngine;

namespace TreasureStock
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public ObservableCollection<TreasureStockEngine.Quote> Quotes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshStockQuotes();
        }

        protected void StockTimer_Tick(object sender, EventArgs e)
        {
            RefreshStockQuotes();
        }

        private void RefreshStockQuotes()
        {
            Quotes = new ObservableCollection<Quote>();

            Quotes.Add(new Quote("AAPL"));
            Quotes.Add(new Quote("MSFT"));
            Quotes.Add(new Quote("IBM"));
            Quotes.Add(new Quote("AMZN"));
            Quotes.Add(new Quote("AMD"));
            Quotes.Add(new Quote("DELL"));

            YahooFinanceQuoteEngine.Fetch(Quotes);

            foreach (Quote quote in Quotes)
            {
                switch (quote.Symbol)
                {
                    case "AAPL":
                        AppleSymbolLabel.Text = quote.Symbol;
                        AppleUpDownLabel.Text = DetermineIfUpOrDown(AppleLastTradePriceLabel.Text, quote.LastTradePrice);
                        AppleLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        OpenLabel.Text = quote.Open.ToString();

                        PreviousCloseLabel.Text = quote.PreviousClose.ToString();
                        //PercentChangeFromPreviousCloseLabel.Text = quote.PreviousClose.ToString();

                        FiftyDayMovingAverageLabel.Text = quote.FiftyDayMovingAverage.ToString();
                        PercentChangeFromFiftyDayMovingAverageLabel.Text = quote.PercentChangeFromFiftyDayMovingAverage.ToString();

                        TwoHundredMovingAverageLabel.Text = quote.TwoHundredDayMovingAverage.ToString();
                        PercentChangeFromTwoHundredDayMovingAverageLabel.Text = quote.PercentChangeFromTwoHundredDayMovingAverage.ToString();

                        YearHighLabel.Text = quote.YearlyHigh.ToString();
                        PercentChangeFromYearHighLabel.Text = quote.PercentChangeFromYearHigh.ToString();

                        YearLowLabel.Text = quote.YearlyLow.ToString();
                        PercentChangeFromYearLowLabel.Text = quote.PercentChangeFromYearLow.ToString();
                        
                        AppleLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        
                        break;

                    case "MSFT":
                        MicrosoftSymbolLabel.Text = quote.Symbol;
                        MicrosoftUpDownLabel.Text = DetermineIfUpOrDown(MicrosoftLastTradePriceLabel.Text, quote.LastTradePrice);
                        MicrosoftLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        MicrosoftLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        break;

                    case "IBM":
                        IBMSymbolLabel.Text = quote.Symbol;
                        IBMUpDownLabel.Text = DetermineIfUpOrDown(IBMLastTradePriceLabel.Text, quote.LastTradePrice);
                        IBMLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        IBMLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        break;

                    case "AMZN":
                        AmazonSymbolLabel.Text = quote.Symbol;
                        AmazonUpDownLabel.Text = DetermineIfUpOrDown(AmazonLastTradePriceLabel.Text, quote.LastTradePrice);
                        AmazonLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        AmazonLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        break;

                    case "AMD":
                        AMDSymbolLabel.Text = quote.Symbol;
                        AMDUpDownLabel.Text = DetermineIfUpOrDown(AMDLastTradePriceLabel.Text, quote.LastTradePrice);
                        AMDLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        AMDLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        break;

                    case "DELL":
                        DellSymbolLabel.Text = quote.Symbol;
                        DellUpDownLabel.Text = DetermineIfUpOrDown(DellLastTradePriceLabel.Text, quote.LastTradePrice);
                        DellLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                        DellLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                        break;
                }
            }
        }

        private string DetermineIfUpOrDown(string OldTradePrice, decimal? NewTradePrice)
        {
            decimal oldTradePrice;
            string upDownSame = "ERROR";

            if (decimal.TryParse(OldTradePrice, out oldTradePrice))
            {
                if (NewTradePrice == oldTradePrice)
                {
                    upDownSame = "Same";
                }
                else if (NewTradePrice > oldTradePrice)
                {
                    upDownSame = "Up";
                }
                else
                {
                    upDownSame = "Down";
                }
            }
            else
            {
                upDownSame = "Unknown" + " [Old: " + OldTradePrice + " New: " + NewTradePrice.ToString() + "]";
            }

            return upDownSame;
        }
    }
}