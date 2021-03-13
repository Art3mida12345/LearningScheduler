using System.Collections.Generic;

namespace DistanceLearning.BL
{
    public class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}