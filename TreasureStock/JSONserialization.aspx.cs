﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreasureStockEngine;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TreasureStock 
{
    public partial class JSONserialization : System.Web.UI.Page
    {
        public ObservableCollection<TreasureStockEngine.Quote> Quotes { get; set; }
        public ObservableCollection<TreasureStockEngine.Stock> Stocks { get; set; }

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
          
            //write my onw class that inherits from that colletion  type, 
            //this will be a custom method
            //add new methods that will be able to do thin
            //it will inherit from objervableCollection. 
            //class object inherts form objervColleciton, 
            //add methods from the collection. 
            //IN the method, iterage through the actual collection. 
            //I can then do something with each item. 
            //if I want to find the thing that has the biggest number of percentae
            //compart most recent to the 

            //mayble linq would be to 
            //write a loop that would go into the that 

            List<Quote> lstQuote = new List<Quote>();
            //This is where I will refresh all of the stock quotes
            Quotes = new ObservableCollection<Quote>();
            //Stocks = new ObservableCollection<Stock>();

            var StockListPath = Server.MapPath("~/App_Data/StockList.txt");
            //System.IO.File.WriteAllText(StockListPath, "Stocks List");
            int BatchRowCount = 300;
            int totalBatches = (File.ReadAllLines(StockListPath).Count() / BatchRowCount) + 1;
            int CurrentRowBatch = 0; // 32751;// 0;   //8536145;THIS NUMBER WAS WHERE WE STARTED START IMPORT IN THE MIDDLE OF FILE
            for (int i = 0; i < totalBatches; i++)
            {
               string s = File.ReadAllLines(StockListPath)[0].ToString();
                //Add just the batch of items
                //I need to add the 300 items to a file, move to the next 300-
                CurrentRowBatch += BatchRowCount;
            }

            List<string> StockList = new List<string>();
            if (File.Exists(StockListPath))
            {
               
                    int rowsInBatch = 300;
                int counter = 0;
               counter = File.ReadAllLines(StockListPath).Count();
                foreach (var line in File.ReadAllLines(StockListPath))
                {
               
                    //Add 300 stocks per batch to a Dataset List. 
                    List<DataSet> lds = new List<DataSet>();
                    if (!StockList.Contains(line.ToUpper().ToString().Trim()))
                    {
                        StockList.Add(line.ToString().ToUpper().Trim());
                        Quotes.Add(new Quote(line.ToString().Trim().ToUpper()));

                        //AddStock(line.ToString().ToUpper().Trim());

                    }

                    counter += 1;
                }
            }



            if (!File.Exists(StockListPath))
            { using (StreamWriter sw = File.CreateText(StockListPath)) { } }

            if (File.Exists(StockListPath))
            { using (StreamWriter sw = File.AppendText(StockListPath)) { } }

            //Quotes.Add(new Quote("AAPL"));
            //Quotes.Add(new Quote("MSFT"));
            //Quotes.Add(new Quote("IBM"));
            //Quotes.Add(new Quote("AMZN"));
            //Quotes.Add(new Quote("AMD"));
            //Quotes.Add(new Quote("DELL"));

            YahooFinanceQuoteEngine.Fetch(Quotes);

            foreach (Quote quote in Quotes)
            {
                switch (quote.Symbol)
                {
                    
                }

            }

            //Use Linq to select the Top Priced Objects. 
            //Use Linq to select the top 10 prices objects. 
            //

            //Quotes.Add(new Quote("AAPL"));
            //Stocks.Add(new Stock("DRNE"));

            DataTable dt = new DataTable();
            dt.Columns.Add("Symbol");
            dt.Columns.Add("Name");
            dt.Columns.Add("LastTradePrice");
            dt.Columns.Add("ChangeInPercent");
            dt.Columns.Add("ChangePercent");
            dt.Columns.Add("Volume");
            dt.Columns.Add("AverageDailyVolume");
            dt.Columns.Add("Change");
            dt.Columns.Add("Open");
            //Here I will add all of the list to the Quotes

            foreach (Quote quote in Quotes)
            {
                Quote q = quote.GetStockData(quote.Symbol);
                //AppleSymbolLabel.Text = quote.Symbol;
                //string name = quote.Name;
                //AppleUpDownLabel.Text = DetermineIfUpOrDown(AppleLastTradePriceLabel.Text, quote.LastTradePrice);
                //AppleLastTradePriceLabel.Text = quote.LastTradePrice.ToString();
                //AppleLastUpdateLabel.Text = quote.LastUpdate.ToLongTimeString();
                //break;
                DataRow workRow = dt.NewRow();
                workRow["Symbol"] = quote.Symbol;
                workRow["Name"] = quote.Name;
                workRow["LastTradePrice"] = quote.LastTradePrice;
                workRow["ChangeInPercent"] = quote.ChangeInPercent; //What is the difference between ChagenInPercent and ChangePercent
                workRow["ChangePercent"] = quote.ChangePercent;
                workRow["Volume"] = quote.Volume;
                workRow["AverageDailyVolume"] = quote.AverageDailyVolume;
                workRow["Change"] = quote.Change;
                workRow["Open"] = quote.Open;
                dt.Rows.Add(workRow);

                lstQuote.Add(quote);

                #region Log Quotes
                //JSon
                //Serialize quote object
                //var jsonString = JsonConvert.SerializeObject(quote);

                //String SerializedQuotesPath = Path.e

                //string filePath = Path.Combine(Environment.CurrentDirectory, "SerializedQuotes.txt");
                //if (!File.Exists(filePath))
                //{
                //    using (StreamWriter sw = File.CreateText(filePath))
                //    {
                //        if (!String.IsNullOrEmpty(filePath))
                //        {
                //        //    sw.WriteLine(jsonString);
                //        }
                //    }
                //}

                #endregion

            }
            Calculation calc = new Calculation();
          ObservableCollection<Quote> lstQuote2 =  calc.top10(Quotes);
                   
            var sortedList = (from q in lstQuote orderby q.BookValue descending select q);

            //Sort by priceMovement(dt);
            //sort by percentMovement
            //Selete Top 100 out of a database. 
            //Do function to get the top 100 out of 3333 records. 

            var jsonString = JsonConvert.SerializeObject(lstQuote2);
            grvTopMovers.DataSource = lstQuote2.ToArray();
            grvTopMovers.DataBind();
        }

    }
}