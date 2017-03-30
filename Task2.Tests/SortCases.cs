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
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();

            if (lhs.Sum() > rhs.Sum())
                return 1;
            else if (lhs.Sum() < rhs.Sum())
                return -1;
            else return 0;
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
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();

            if (lhs.Sum() > rhs.Sum())
                return -1;
            else if (lhs.Sum() < rhs.Sum())
                return 1;
            else return 0;
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
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();

            if (lhs.Max() > rhs.Max())
                return 1;
            else if (lhs.Max() < rhs.Max())
                return -1;
            else return 0;
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
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();

            if (lhs.Max() > rhs.Max())
                return -1;
            else if (lhs.Max() < rhs.Max())
                return 1;
            else return 0;
        }
    }
    

}
