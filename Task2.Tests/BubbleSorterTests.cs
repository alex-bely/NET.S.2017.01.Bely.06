using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    [TestFixture]
    public class BubbleSorterTests
    {
        [Test]
        public void SortBySumAscending_JaggedArray_ExpectedSortedBySumOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };

            int[][] expected = {
                new int[] {0,25,0,0,0},
                new int[] {1,3,6,7,9},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };

            BubbleSorter.Sort(actual,new SortBySumAscending());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBySumDescending_JaggedArray_ExpectedSortedBySumOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            int[][] expected = {
                new int[] {13,15,42,-7,16},
                new int[] {11,22,24},
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0}
            };

            BubbleSorter.Sort(actual, new SortBySumDescending());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMaxAscending_JaggedArray_ExpectedSortedByMaxElementsOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            int[][] expected = {
                 new int[] {1,3,6,7,9},
                 new int[] {11,22,24},
                 new int[] {0,25,0,0,0},
                 new int[] {13,15,42,-7,16}
            };

            BubbleSorter.Sort(actual, new SortByMaxAscending());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SortByMaxDescending_JaggedArray_ExpectedSortedByMaxElementsOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            int[][] expected = {
                new int[] {13,15,42,-7,16},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {1,3,6,7,9}
            };

            BubbleSorter.Sort(actual, new SortByMaxDescending());

            Assert.AreEqual(expected, actual);
        }

       
        
        [TestCase(null)]
        public void SortBySumAscending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(jaggedArray, new SortBySumAscending()));
        }

        [TestCase(null)]
        public void SortBySumDescending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(jaggedArray, new SortBySumDescending()));
        }

        [TestCase(null)]
        public void SortByMaxAscending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(jaggedArray, new SortByMaxAscending()));
        }

        [TestCase(null)]
        public void SortByMaxDescending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(jaggedArray, new SortByMaxDescending()));
        }

     
        [TestCase()]
        public void SortBySumAscending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, new SortBySumAscending()));
        }

        [TestCase()]
        public void SortBySumDescending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, new SortBySumDescending()));
        }

        [TestCase()]
        public void SortByMaxAscending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, new SortByMaxAscending()));
        }

        [TestCase()]
        public void SortByMaxDescending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, new SortByMaxDescending()));
        }


        [TestCase()]
        public void Sort_NullComparer_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {1,3,6,7,9},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, null));
        }

    }
 
}
