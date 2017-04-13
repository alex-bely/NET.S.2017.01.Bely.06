using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    
    /// <summary>
    /// Provides method of bubble sorting for jagged integer array
    /// </summary>

    public static class BubbleSorter
    {
        #region Public method
        /// <summary>
        /// Sorts rows of array by given comparer
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <param name = "comparer">Comparer with rule of comparing</param>
        /// <exception cref="ArgumentNullException">One of the arguments is null referenced</exception>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (array == null || comparer==null) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (comparer.Compare(array[j],array[j+1])>0) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array by given comparison feature
        /// </summary>
        /// <param name="array">Jagged array for sorting</param>
        /// <param name="comparer">Delegate with the rule of comparing</param>
        /// <exception cref="ArgumentNullException">Comparer is null referenced</exception>
        public static void Sort(int[][] array, Func<int[],int[],int> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            Sort(array, new DelegateToComparer(comparer));
        }


        #endregion

        #region Private and internal members
        /// <summary>
        /// Creates comparer based on delegate
        /// </summary>
        internal class DelegateToComparer:IComparer
        {
            private Func<int[], int[], int> localFunc;
            /// <summary>
            /// Initialize local delegate with external delegate
            /// </summary>
            /// <param name="source">External delegate</param>
            internal DelegateToComparer(Func<int[],int[],int> source)
            {
                localFunc = source;
            }

            /// <summary>
            /// Compares two integer arrays by the maximal element of array
            /// </summary>
            /// <param name = "lhs">First array for comparison</param>
            /// <param name = "rhs">Second array for comparison</param>
            /// <returns>An integer that indicates the relative values of lhs and rhs</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                return localFunc(lhs,rhs);
            }
        }

      

        /// <summary>
        /// Swaps two integer array references
        /// </summary>
        /// <param name = "number1">First array reference</param>
        /// <param name = "number2">Second array reference</param>
        private static void Swap(ref int[] number1, ref int[] number2)
        {
            int[] temp = number1;
            number1 = number2;
            number2 = temp;
        }
        #endregion
    }
}
