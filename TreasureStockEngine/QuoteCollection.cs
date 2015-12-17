using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureStockEngine
{
    public class QuotesCollection : System.Collections.CollectionBase
    {
        public void Add(Quotes quotes)
        {
            List.Add(quotes);
        }

        public void Remove (int index)
        {
            if (index < Count - 1 || index < 0)
            {
                throw new Exception("Index not valid");
            }
            else
            {
                List.RemoveAt(index);
            }
        }

        public Quotes Item(int Index)
        {
            return (Quotes)List[Index];
        }
    }
}
