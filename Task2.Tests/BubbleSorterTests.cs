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

            BubbleSorter.SortBySumAscending(actual);

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

            BubbleSorter.SortBySumDescending(actual);

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

            BubbleSorter.SortByMaxAscending(actual);

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

            BubbleSorter.SortByMaxDescending(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMinAscending_JaggedArray_ExpectedSortedByMinElementsOfRowsArray()
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
                new int[] {1,3,6,7,9},
                new int[] {11,22,24}
            };

            BubbleSorter.SortByMinAscending(actual);

            Assert.AreEqual(expected, actual);
        }

       

        
        
        [Test]
        public void SortByMinDescending_JaggedArray_ExpectedSortedByMinElementsOfRowsArray()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            int[][] expected = {
                new int[] {11,22,24},
                new int[] {1,3,6,7,9},
                new int[] {0,25,0,0,0},
                new int[] {13,15,42,-7,16}
            };

            BubbleSorter.SortByMinDescending(actual);

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(null)]
        public void SortBySumAscending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortBySumAscending(jaggedArray));
        }

        [TestCase(null)]
        public void SortBySumDescending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortBySumDescending(jaggedArray));
        }

        [TestCase(null)]
        public void SortByMaxAscending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMaxAscending(jaggedArray));
        }

        [TestCase(null)]
        public void SortByMaxDescending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMaxDescending(jaggedArray));
        }

        [TestCase(null)]
        public void SortByMinAscending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMinAscending(jaggedArray));
        }
        

        [TestCase(null)]
        public void SortByMinDescending_NullReferencedJaggedArray_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMinDescending(jaggedArray));
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
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortBySumAscending(actual));
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
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortBySumDescending(actual));
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
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMaxAscending(actual));
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
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMaxDescending(actual));
        }

        [TestCase()]
        public void SortByMinAscending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMinAscending(actual));
        }


        [TestCase()]
        public void SortByMinDescending_JaggedArrayWithNullReferencedRow_ThrowsArgumentNullException()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMinDescending(actual));
        }



        [Test]
        public void SortBySumAscending_JaggedArray_Exc()
        {
            int[][] actual = {
                new int[] {1,3,6,7,9},
                null,
                new int[] {11,22,24},
                new int[] {13,15,42,-7,16}
            };
           

            Assert.Throws<ArgumentNullException>(() => BubbleSorter.SortByMinDescending(actual));

           
        }
        
    }
}
