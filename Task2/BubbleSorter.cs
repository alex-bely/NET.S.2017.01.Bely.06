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
        /// Sorts rows of array by given comparison feature
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">One of the arguments is null referenced</exception>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (array == null || comparer==null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (comparer.Compare(array[j],array[j+1])>0) Swap(ref array[j], ref array[j + 1]);
        }

        #endregion
        
        #region Private methods
        /// <summary>
        /// Defines whether the array contains null referenced rows
        /// </summary>
        /// <param name = "array">Jagged array for checking</param>
        /// <returns>Boolean result of verification</returns> 
        private static bool IsContainNull(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == null) return true;
            return false;
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
