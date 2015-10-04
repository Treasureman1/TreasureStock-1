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
    public partial class PercentageRating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshPercentageRatingGrid();
        }

        protected void StockTimer_Tick(object sender, EventArgs e)
        {
            RefreshPercentageRatingGrid();
        }

        protected void PercentageRatingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Quote quote = (Quote)e.Row.DataItem;

                    Label SymbolLabel = (Label)e.Row.FindControl("ItemTemplateSymbolLabel");
                    SymbolLabel.Text = quote.Symbol;

                    Label OpenLabel = (Label)e.Row.FindControl("ItemTemplateOpenLabel");
                    OpenLabel.Text = quote.Open.ToString();

                    Label LastLabel = (Label)e.Row.FindControl("ItemTemplateLastLabel");
                    decimal oldTradePrice;
                    if (decimal.TryParse(LastLabel.Text, out oldTradePrice))
                    {
                        if (oldTradePrice > quote.LastTradePrice)
                        {
                            LastLabel.CssClass = "percentChangePositive";
                        }
                        else if (oldTradePrice < quote.LastTradePrice)
                        {
                            LastLabel.CssClass = "percentChangeNegative";
                        }
                        else
                        {
                            LastLabel.CssClass = "percentChangeNeutral";
                        }
                    }
                    else
                    {
                        LastLabel.CssClass = "percentChangeNeutral";
                    }
                    LastLabel.Text = quote.LastTradePrice.ToString();

                    Label PreviousCloseLabel = (Label)e.Row.FindControl("ItemTemplatePreviousCloseLabel");
                    PreviousCloseLabel.Text = quote.PreviousClose.ToString();

                    Label PercentChangeFromPreviousCloseLabel = (Label)e.Row.FindControl("ItemTemplatePercentChangeFromPreviousCloseLabel");
                    PercentChangeFromPreviousCloseLabel.Text = "--";

                    Label FiftyDayAverageLabel = (Label)e.Row.FindControl("ItemTemplateFiftyDayAverageLabel");
                    FiftyDayAverageLabel.Text = quote.FiftyDayMovingAverage.ToString();

                    Label PercentChangeFromFiftyDayAverageLabel = (Label)e.Row.FindControl("ItemTemplatePercentChangeFiftyDayAverageLabel");
                    PercentChangeFromFiftyDayAverageLabel.Text = quote.PercentChangeFromFiftyDayMovingAverage.ToString();

                    Label TwoHundredDayAverageLabel = (Label)e.Row.FindControl("ItemTemplateTwoHundredDayAverageLabel");
                    TwoHundredDayAverageLabel.Text = quote.TwoHundredDayMovingAverage.ToString();

                    Label PercentChangeFromTwoHundredDayAverageLabel = (Label)e.Row.FindControl("ItemTemplatePercentChangeTwoHundredDayMovingAverageLabel");
                    PercentChangeFromTwoHundredDayAverageLabel.Text = quote.PercentChangeFromTwoHundredDayMovingAverage.ToString();

                    Label YearHighLabel = (Label)e.Row.FindControl("ItemTemplateYearHighLabel");
                    YearHighLabel.Text = quote.FiftyDayMovingAverage.ToString();

                    Label PercentChangeFromYearHighLabel = (Label)e.Row.FindControl("ItemTemplatePercentChangeYearHighLabel");
                    PercentChangeFromYearHighLabel.Text = quote.PercentChangeFromYearHigh.ToString();

                    Label YearLowLabel = (Label)e.Row.FindControl("ItemTemplateYearLowLabel");
                    YearLowLabel.Text = quote.FiftyDayMovingAverage.ToString();

                    Label PercentChangeFromYearLowLabel = (Label)e.Row.FindControl("ItemTemplatePercentChangeYearLowLabel");
                    PercentChangeFromYearLowLabel.Text = quote.PercentChangeFromYearLow.ToString();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        protected void PercentageRatingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        private void RefreshPercentageRatingGrid()
        {
            List<Quote> quotes = new List<Quote>();

            quotes.Add(new Quote("AAPL"));
            quotes.Add(new Quote("MSFT"));
            quotes.Add(new Quote("IBM"));
            quotes.Add(new Quote("AMZN"));
            quotes.Add(new Quote("AMD"));

            YahooFinanceQuoteEngine.Fetch(quotes);

            PercentageRatingGridView.DataSource = quotes;
            PercentageRatingGridView.DataBind();

            LastUpdatedLabel.Text = "Last updaed " + DateTime.Now.ToShortTimeString();
        }


    }
}