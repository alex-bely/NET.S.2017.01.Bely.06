using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task.Tests
{
    [TestFixture]
    public class PolynomialTests
    {

        [TestCase(2,2, ExpectedResult = 2)]
        [TestCase(0,2, ExpectedResult = 0)]
        [TestCase(4,2, ExpectedResult = 4)]

        public double ValueAt_OneCoefficientAndValue_ResultOfPolynomialExpression(double coefficients, double variable)
        {
            return (new Polynomial(coefficients)).ValueAt(variable);
        }


        [TestCase(2, 2, 2, ExpectedResult = 6)]
        [TestCase(0, 2, 2, ExpectedResult = 4)]
        [TestCase(2, 0, 2, ExpectedResult = 2)]
        [TestCase(0, 0, 2, ExpectedResult = 0)]
        [TestCase(2, 4, 2, ExpectedResult = 10)]
        [TestCase(2, -4, 2, ExpectedResult = -6)]
        [TestCase(2, 0, -2, ExpectedResult = 2)]
        public double ValueAt_TwoCoefficientsAndValue_ResultOfPolynomialExpression(double coefficient1, double coefficient2, double variable)
        {
            return (new Polynomial(coefficient1,coefficient2)).ValueAt(variable);
        }


        [TestCase(-2, -2, -2, 2, ExpectedResult = -14)]
        [TestCase(0, 2, -2, 2, ExpectedResult = -4)]
        [TestCase(-2, 0, 2, 2, ExpectedResult = 6)]
        [TestCase(0, 0, -2, 2, ExpectedResult = -8)]
        [TestCase(0, 0, 0, 2, ExpectedResult = 0)]
        [TestCase(2, -4, 2, 2, ExpectedResult = 2)]

        public double ValueAt_ThreeCoefficientsAndValue_ResultOfPolynomialExpression(double coefficient1, double coefficient2, double coefficient3, double variable)
        {
            return (new Polynomial(coefficient1, coefficient2, coefficient3)).ValueAt(variable);
        }

         [TestCase( 1, -2, 3,5, 2, ExpectedResult = 81)]
         [TestCase( 2, 5, 1, -2, 3 , 3, ExpectedResult = 144)]
         [TestCase( 0, 0, 0, 0, 0 , 5, ExpectedResult = 160)]
         [TestCase( 3, 4, 0 , 2, ExpectedResult = 27)]
         [TestCase( 7, 8, 9, 3 , 0, ExpectedResult = 83)]
         [TestCase( 0, 0, 0, 0, 0 , 0, ExpectedResult = 0)]
         public double ValueAt_SeveralCoefficientsAndValue_ResultOfPolynomialExpression(params double[] coefficients)
         {
            double variable = 2;
             return (new Polynomial(coefficients)).ValueAt(variable);
         }
         
        

        [TestCase(new double[]  { 1, -2, 3,4 }, new double[] { 0, 0, 0 }, 4, ExpectedResult = 297)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3, ExpectedResult = 215)]
        [TestCase(new double[] { 1, 2,3,5 }, new double[] { -1, -2,-3, -5 }, 6, ExpectedResult = 0)]
        [TestCase(new double[] { 5, 2, 3, 5 }, new double[] { -4, -2, -3, -5 }, 7, ExpectedResult = 1)]
        [TestCase(new double[] { 6 }, new double[] { 1, -2, 3 }, 2, ExpectedResult = 15)]
        public double AddAndValueAt_TwoPolynomials_ResultOfPolynomialExpression(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) + new Polynomial(coefficients2)).ValueAt(variable);
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, 2, ExpectedResult = 9)]
        [TestCase(new double[] { 1, -2, -3 }, new double[] { 0, 0, 0 }, 3, ExpectedResult = -32)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4, ExpectedResult = 678)]
        [TestCase(new double[] { 9,15 }, new double[] { 1, -2, 3 }, 4, ExpectedResult = -28)]
        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { 1, 2, 3, 5 }, 5, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { 2, 2, 3, 5 }, 6, ExpectedResult = -1)]
        public double SubstractAndValueAt_TwoPolynomials_ResultOfPolynomialExpression(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) - new Polynomial(coefficients2)).ValueAt(variable);
        }

        [TestCase(new double[] { 1, -2, 3, 4 }, new double[] { 0, 0, 0 }, 2, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 1, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4, ExpectedResult = 2712)]
        [TestCase(new double[] { 6,21 }, new double[] { 1, -2, 3 }, 5, ExpectedResult = 7326)]
        public double MultiplyAndValueAt_TwoPolynomials_ResultOfPolynomialExpression(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) * new Polynomial(coefficients2)).ValueAt(variable);
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 },1,  ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 },2,  ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double []{ 0,0},3, ExpectedResult = false)]
        public bool OperatorEqual_CompareTwoPolynomials_False(double[] coefficients1, double[] coefficients2, int number)
        {
             return new Polynomial(coefficients1) == new Polynomial(coefficients2);
        }


        
        [TestCase(new double[] { 1, -5, 3 },1, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 0 },2, ExpectedResult = true)]
        [TestCase(new double[] { 7, 1, -2, 3 },3, ExpectedResult = true)]
        public bool OperatorEqual_CompareTwoPolynomials_True(double[] coefficients, int number)
        {
            
            var polynomial1 = new Polynomial(coefficients);
            var polynomial2 = polynomial1;
            return polynomial1 == polynomial2;
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 },1, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 },2, ExpectedResult = true)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 },3, ExpectedResult = true)]
        public bool OperatorNotEqual_CompareTwoPolynomials_True(double[] coefficients1, double[] coefficients2,int number)
        {
            return new Polynomial(coefficients1) != new Polynomial(coefficients2);
        }

        [TestCase(new double[] { 1, -2, 3 }, 1,ExpectedResult = false)]
        [TestCase(new double[] { 0, 0 },2, ExpectedResult = false)]
        [TestCase(new double[] { 1, -2, 3 }, 3,ExpectedResult = false)]
        public bool OperatorNotEqual_CompareTwoPolynomials_False(double[] coefficients, int number)
        {
            var polynomial1 = new Polynomial(coefficients);
            var polynomial2 = polynomial1;
            return polynomial1 != polynomial2;
        }

        [TestCase(new double[] { })]
        public void Constructor_BlankArray_ThrowsArgumentException(double[] coefficients)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Polynomial(coefficients));
        }
        
        [TestCase()]
        public void Constructor_NullReferenceArray_ThrowsArgumentNullException()
        {
            Polynomial temp = null;
            Assert.Throws<ArgumentNullException>(() => new Polynomial(temp));
        }
        
        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorAdd_OneOfArgumetsIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null)
                polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null)
                polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 + polynomial2);
        }

        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorSub_OneOfArgumetsIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null)
                polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null)
                polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 - polynomial2);
        }

        [TestCase(null, null)]
        [TestCase(null, new double[] { 1, -2, 3 })]
        [TestCase(new double[] { 1, -2, 3 }, null)]
        public void OperatorMul_OneOfArgumetsIsNull_ThrowsArgumentNullException(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null)
                polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null)
                polynomial2 = new Polynomial(coefficients2);

            Assert.Throws<ArgumentNullException>(() => polynomial1 = polynomial1 * polynomial2);
        }

       

        [TestCase(new double[] { 1, -2, 3 }, null,1, ExpectedResult = false)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, 2,ExpectedResult = false)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3,ExpectedResult = false)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 },4, ExpectedResult = true)]
        public bool Equals_TwoPolynomials_ComparePolynomials(double[] coefficients1, double[] coefficients2, int number)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null)
                polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null)
                polynomial2 = new Polynomial(coefficients2);

            return polynomial1.Equals(polynomial2);
        }
    }
}
