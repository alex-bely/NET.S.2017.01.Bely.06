using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2
{
   public static class BubbleSorterOpposite
    {
        #region Public method
        /// <summary>
        /// Sorts rows of array by given comparison feature
        /// </summary>
        /// <param name = "array">Jagged array for sorting</param>
        /// <exception cref="ArgumentNullException">One of the arguments is null referenced</exception>
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (array == null || comparer == null) throw new ArgumentNullException();
            Sort(array, new Func<int[],int[],int>(comparer.Compare));
        }

        /// <summary>
        /// Sorts rows of array by given comparison feature
        /// </summary>
        /// <param name="array">Jagged array for sorting</param>
        /// <param name="comparer">Delegate with the rule of comparing</param>
        /// <exception cref="ArgumentNullException">Comparer is null referenced</exception>
        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            if (comparer == null) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (comparer(array[j], array[j + 1]) > 0) Swap(ref array[j], ref array[j + 1]);
        }


        #endregion

        #region Private method
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

