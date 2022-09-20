using System.Collections.Generic;

namespace MainController
{
    public class ParaCompare : IComparer<SPara>
    {
        public int Compare(SPara x, SPara y)
        {
            return (x.s.CompareTo(y.s));

        }


    }
}
