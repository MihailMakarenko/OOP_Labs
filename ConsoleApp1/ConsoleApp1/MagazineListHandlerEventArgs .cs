using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public  class MagazineListHandlerEventArgs: System.EventArgs
    {
        public MagazineListHandlerEventArgs(string nameCollectionWhereChange, string typeChangeInCollection, int numberOfTheElementThatWasChanged) 
        {
            NameCollectionWhereChange = nameCollectionWhereChange;
            TypeChangeInCollection = typeChangeInCollection;
            NumberOfTheElementThatWasChanged = numberOfTheElementThatWasChanged;
        }

        public MagazineListHandlerEventArgs()
        {
            NameCollectionWhereChange = "";
            TypeChangeInCollection = "";
            NumberOfTheElementThatWasChanged = 0;
        }

        public string NameCollectionWhereChange { get; set; }
        public string TypeChangeInCollection { get; set; }
        public int NumberOfTheElementThatWasChanged { get; set; }

        public override string ToString()
        {
            string str = $"Название коллекции в которой были изменения: {NumberOfTheElementThatWasChanged}\n" +
                $"Тип коллекции в которой произошли изменения: {TypeChangeInCollection}\n" +
                $"Номер элемента в коллекции который был изменен: {NumberOfTheElementThatWasChanged}\n";

            return str;
        }



    }
}
