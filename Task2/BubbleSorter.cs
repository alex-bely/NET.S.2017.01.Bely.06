using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Provides methods of bubble sorting for jagged integer array
    /// </summary>
  
    public static class BubbleSorter
    {
        #region Public methods
        /// <summary>
        /// Sorts rows of array in ascending order by comparing sums of elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortBySumAscending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Sum() > array[j + 1].Sum()) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array in descending order by comparing sums of elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortBySumDescending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Sum() < array[j + 1].Sum()) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array in ascending order by comparing maximal elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortByMaxAscending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Max() > array[j + 1].Max()) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array in descending order by comparing maximal elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortByMaxDescending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Max() < array[j + 1].Max()) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array in ascending order by comparing minimal elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortByMinAscending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Min() > array[j + 1].Min()) Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Sorts rows of array in descending order by comparing minimal elements of the rows
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">Array or one of the rows is null referenced</exception>
        public static void SortByMinDescending(int[][] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (IsContainNull(array)) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j].Min() < array[j + 1].Min()) Swap(ref array[j], ref array[j + 1]);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Defines whether the array containы null referenced rows
        /// </summary>
        /// <param name = "array">Jagged array for checking</param>
       
        private static bool IsContainNull(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == null) return true;
            return false;
        }

        /// <summary>
        /// Swap two integer array references
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
