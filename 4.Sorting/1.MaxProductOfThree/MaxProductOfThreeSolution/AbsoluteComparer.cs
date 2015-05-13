using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProductOfThreeSolution
{
    public class AbsoluteComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return(new CaseInsensitiveComparer()).Compare(Math.Abs((int)x), Math.Abs((int)y));
        }
    }
}
