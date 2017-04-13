using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{

    
    /// <summary>
    /// Implements a method to compare two integer arrays
    /// </summary>
    /// <see cref="Task2.IComparer"/>
    public class SortBySumAscending : IComparer
    {
        /// <summary>
        /// Compares two integer arrays by the sum of its elements
        /// </summary>
        /// <param name = "lhs">First array for comparison</param>
        /// <param name = "rhs">Second array for comparison</param>
        /// <returns>An integer that indicates the relative values of lhs and rhs</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return 0;
            if (ReferenceEquals(lhs, null))
                return -1;
            if (ReferenceEquals(rhs, null))
                return 1;

            return lhs.Sum().CompareTo(rhs.Sum());
        }
    }

    /// <summary>
    /// Implements a method to compare two integer arrays
    /// </summary>
    /// <see cref="Task2.IComparer"/>
    public class SortBySumDescending : IComparer
    {
        /// <summary>
        /// Compares two integer arrays by the sum of its elements
        /// </summary>
        /// <param name = "lhs">First array for comparison</param>
        /// <param name = "rhs">Second array for comparison</param>
        /// <returns>An integer that indicates the relative values of lhs and rhs</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))  return 0;
            if (ReferenceEquals(lhs, null)) return 1;
            if (ReferenceEquals(rhs, null)) return -1;

            return rhs.Sum().CompareTo(lhs.Sum());
        }
    }

    /// <summary>
    /// Implements a method to compare two integer arrays
    /// </summary>
    /// <see cref="Task2.IComparer"/>
    public class SortByMaxAscending : IComparer
    {
        /// <summary>
        /// Compares two integer arrays by the maximal element of array
        /// </summary>
        /// <param name = "lhs">First array for comparison</param>
        /// <param name = "rhs">Second array for comparison</param>
        /// <returns>An integer that indicates the relative values of lhs and rhs</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return 0;
            if (ReferenceEquals(lhs, null))
                return -1;
            if (ReferenceEquals(rhs, null))
                return 1;

            return lhs.Max().CompareTo(rhs.Max());
        }
    }


    /// <summary>
    /// Implements a method to compare two integer arrays
    /// </summary>
    /// <see cref="Task2.IComparer"/>
    public class SortByMaxDescending : IComparer
    {
        /// <summary>
        /// Compares two integer arrays by the maximal element of array
        /// </summary>
        /// <param name = "lhs">First array for comparison</param>
        /// <param name = "rhs">Second array for comparison</param>
        /// <returns>An integer that indicates the relative values of lhs and rhs</returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return 0;
            if (ReferenceEquals(lhs, null))
                return 1;
            if (ReferenceEquals(rhs, null))
                return -1;

            return rhs.Max().CompareTo(lhs.Max());
        }
    }
    
}
