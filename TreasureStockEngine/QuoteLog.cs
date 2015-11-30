using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TreasureStockEngine
{
    class QuoteLog
    {
        #region Declarations

        List<Quotes> quoteLog = new List<Quotes>();

        #endregion

        #region Constructors

        public QuoteLog()
        { }

        #endregion

        #region Propertiess



        #endregion  

        #region Public Methods

        public void Add(Quotes quotes)
        {
            quoteLog.Add(quotes);
        }

        public List<Quotes> SortByTimeStamp()
        {
            return SortByTimeStamp(true);
        }

        public List<Quotes> SortByTimeStamp(bool Ascending)
        {
            if (Ascending)
            {
                quoteLog.OrderBy(o => o.TimeStamp);
            }
            else
            {
                quoteLog.OrderByDescending(o => o.TimeStamp);
            }

            return quoteLog;
        }

        #endregion  
    }
}
