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
        public void SortBySumAscending_JaggedArrayWithNullRows_ExpectedSortedBySumOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };

            int[][] expected = {
                null,
                new int[] {1,3,6,7,9},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };

            BubbleSorter.Sort(actual, new SortBySumAscending());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBySumAscending_JaggedArray_ExpectedSortedBySumOfRowsArray_delegate()
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

            BubbleSorter.Sort(actual, new SortBySumAscending().Compare);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SortBySumAscending_JaggedArray_ExpectedSortedBySumOfRowsArray_Opposite()
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

            BubbleSorterOpposite.Sort(actual, new SortBySumAscending());

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
        public void SortBySumDescending_JaggedArray_ExpectedSortedBySumOfRowsArray_delegate()
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

            BubbleSorter.Sort(actual, new SortBySumDescending().Compare);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBySumDescending_JaggedArray_ExpectedSortedBySumOfRowsArray_Opposite()
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

            BubbleSorterOpposite.Sort(actual, new SortBySumDescending());

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

            BubbleSorter.Sort(actual,new SortByMaxAscending());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMaxAscending_JaggedArray_ExpectedSortedByMaxElementsOfRowsArray_delegate()
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

            BubbleSorter.Sort(actual, delegate (int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                    return 0;
                if (ReferenceEquals(lhs, null))
                    return -1;
                if (ReferenceEquals(rhs, null))
                    return 1;

                return lhs.Max().CompareTo(rhs.Max());
            });

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SortByMaxAscending_JaggedArrayWithNullRows_ExpectedSortedByMaxElementsOfRowsArray_delegate()
        {
            int[][] actual = {
                null,
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            int[][] expected = {
                 null,
                 new int[] {11,22,24},
                 new int[] {0,25,0,0,0},
                 new int[] {13,15,42,-7,16}
            };

            BubbleSorter.Sort(actual, new SortByMaxAscending().Compare);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SortByMaxAscending_JaggedArray_ExpectedSortedByMaxElementsOfRowsArray_Opposite()
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

            BubbleSorterOpposite.Sort(actual, new SortByMaxAscending());

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
        public void Sort_NullComparer_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {1,3,6,7,9},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            IComparer temp=null;
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.Sort(actual, temp));
        }

    }
 
}
