using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using TreasureStockEngine;
using System.Collections;
using System.Data;


namespace TreasureStockEngine 
{
    public class Calculation  : ObservableCollection<TreasureStockEngine.Quote>
    {
    List<string> ls = new List<string>();


        public ObservableCollection<TreasureStockEngine.Quote> top10(ObservableCollection<TreasureStockEngine.Quote> qt)
        {
            Quote q = new Quote();
            ObservableCollection<TreasureStockEngine.Quote> refinedQuote = new ObservableCollection<TreasureStockEngine.Quote>();

            //Sort the qt List using LINQ statement

            //Selete only the Quoter objects with index of 10 or lower (Top 10)
            //foreach (Quote qt1 in qt)
            //{
            //    if (qt.IndexOf(qt1) < 10)
            //    {
            //        refinedQuote.Add(qt1);
            //    }
            //}
            List<Quote> SortedList = qt.OrderByDescending(o => o.Ask).ToList();

            //I need to figure out how to write the following
            //Where d.Ask (decimal) is greater then .10 (cents)I get the error that I cannot 
            var result = from d in qt
                         where d.Ask > 0
                         select d;

            var result2 = from d in SortedList
                         where d.Ask > 0
                         select d;

            for (int i = 0; i < 25; i++)
            {
                foreach (Quote q2 in result2)
                {


                    //if (qt.IndexOf(q2) < 10)
                    //{
                        refinedQuote.Add(q2);
                    //}
                }
            }

            //var query = from pro in qt
            //            select new ProjectInfo() { Name = pro.ProjectName, Id = pro.ProjectId };
           // return query.ToList();

            //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
            return refinedQuote;
        }
   
    }
}
