using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListEntry
    {
  
        public string CollectionName { get; set; }

       
        public string EventMessage { get; set; }

       
        public int ItemIndex { get; set; }

        public ListEntry(string collectionName, string eventMessage, int itemIndex)
        {
            CollectionName = collectionName;
            EventMessage = eventMessage;
            ItemIndex = itemIndex;
        }


        public override string ToString()
        {
            return $"{CollectionName}: {EventMessage} (Индекс: {ItemIndex})";
        }
    }
}
