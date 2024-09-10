using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Listener
    {
        private List<ListEntry> changes = new List<ListEntry>();

     
        public void OnMagazineAdded(object sender, MagazineListHandlerEventArgs e)
        {
            var entry = new ListEntry(e.NameCollectionWhereChange, e.TypeChangeInCollection, e.NumberOfTheElementThatWasChanged);
            changes.Add(entry);
        }


        public void OnMagazineReplaced(object sender, MagazineListHandlerEventArgs e)
        {
            var entry = new ListEntry(e.NameCollectionWhereChange, e.TypeChangeInCollection, e.NumberOfTheElementThatWasChanged);
            changes.Add(entry);
        }


        public override string ToString()
        {
            var result = "Изменения:\n";
            foreach (var change in changes)
            {
                result += change.ToString() + "\n";
            }
            return result.Trim(); // Убираем последний перевод строки
        }
    }
}
