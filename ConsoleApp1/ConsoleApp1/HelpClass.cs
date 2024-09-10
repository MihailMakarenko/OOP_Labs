using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HelpClass : IComparer<Edition>
    {
        public int Compare(Edition? x, Edition? y)
        {
            if (x is null && y is null)
                return 0;
            else if (x is null)
                return -1;
            else if (y is null)
                return 1;
            else
                return x.Circulation.CompareTo(y.Circulation);
        }
    }
}
