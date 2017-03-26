using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public class Polynomial
    {
        #region Properties
        /// <summary>
        /// Array with polynomial's coefficients
        /// </summary>
        private double[] Coefficients { get; }

        /// <summary>
        /// Degree of polynomial
        /// </summary>
        private int Degree { get; }
        #endregion

        #region Construcrors

        /// <summary>
        /// Creates new Polynomial object with given coefficient
        /// </summary>
        /// <param name="firstCoefficient">Polynomial's coefficient</param>

        public Polynomial(double firstCoefficient)
        {
            this.Degree = 0;
            Coefficients = new double[] { firstCoefficient };
        }

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="firstCoefficient">Polynomial's first coefficient</param>
        /// <param name="secondCoefficient">Polynomial's second coefficient</param>
        public Polynomial(double firstCoefficient, double secondCoefficient)
        {
            if (secondCoefficient == 0)
            {
                this.Degree = 0;
                Coefficients = new double[] { firstCoefficient };
            }
            else
            {
                this.Degree = 1;
                this.Coefficients = new double[] { firstCoefficient, secondCoefficient };
            }

        }

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="firstCoefficient">Polynomial's first coefficient</param>
        /// <param name="firstCoefficient">Polynomial's second coefficient</param>
        /// <param name="thirdCoefficient">Polynomial's third coefficient</param>
        public Polynomial(double firstCoefficient, double secondCoefficient, double thirdCoefficient)
        {
            if (thirdCoefficient == 0 && secondCoefficient == 0)
            {
                this.Degree = 0;
                Coefficients = new double[] { firstCoefficient };
            }
            else if (thirdCoefficient == 0)
            {
                this.Degree = 1;
                this.Coefficients = new double[] { firstCoefficient, secondCoefficient };
            }
            else
            {
                this.Degree = 2;
                this.Coefficients = new double[] { firstCoefficient, secondCoefficient, thirdCoefficient };
            }

        }

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="coefficients">Polynomial's coefficients</param>
        /// <exception cref="ArgumentNullException">Array of arguments is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Array is blank</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients));
            if (coefficients.Length==0) throw new ArgumentOutOfRangeException(nameof(coefficients));
            this.Degree = coefficients.Length - 1;
            
            while (coefficients[Degree] == 0 && Degree > 0)
            {
                Degree--;
            }
            
            this.Coefficients = new double[Degree + 1];
            Array.Copy(coefficients, this.Coefficients, Degree + 1);
        }

        /// <summary>
        /// Creates new Polynomial object based on another polynomial
        /// </summary>
        /// <param name="polynomial">Base Polynomial object</param>
        /// <exception cref="ArgumentNullException">Base polynomial is null referenced</exception>
        
        public Polynomial(Polynomial polynomial)
        {
            if (polynomial==null) throw new ArgumentNullException();
            this.Degree = polynomial.Degree;
            this.Coefficients = new double[polynomial.Coefficients.Length];
            Array.Copy(polynomial.Coefficients, this.Coefficients, polynomial.Coefficients.Length);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator +(Polynomial value1, Polynomial value2)
        {
            return new Polynomial(Polynomial.Add(value1, value2));
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator -(Polynomial value1, Polynomial value2)
        {
            return new Polynomial(Polynomial.Sub(value1, value2));
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator *(Polynomial value1, Polynomial value2)
        {
            return new Polynomial(Polynomial.Mul(value1, value2));
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are equal, false if they are not</returns>
        public static bool operator ==(Polynomial value1, Polynomial value2)
        {
            return ReferenceEquals(value1, value2);
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are not equal, false if the are</returns>
        public static bool operator !=(Polynomial value1, Polynomial value2)
        {
            return !(value1 == value2);
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Calculates the result of the expression for the specified variable
        /// </summary>
        /// <param name="value">Source variable to calculate the result of the polynomial expression</param>
        /// <returns>The result of the expression</returns>
        public double ValueAt(double value)
        {
            int n = Coefficients.Length - 1;
            double result = Coefficients[n];
            for (int i = n - 1; i >= 0; i--)
            {
                result = value * result + Coefficients[i];
            }
            return result;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Polynomial object
        /// </summary>
        /// <param name="obj">The object to compare with the current Polynomial object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            Polynomial temp = obj as Polynomial;
            if (temp == null) return false;

            if (this.Coefficients.Length != temp.Coefficients.Length) return false;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (this.Coefficients[i] != temp.Coefficients[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Represents the current polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        /// <exception cref="ArgumentNullException">Polynomial is null referenced</exception>
        public override string ToString()
        {
            if (this == null) throw new ArgumentNullException();
            if (Degree == 0) return Coefficients[0].ToString();

            StringBuilder temp = new StringBuilder();
            temp.Append(Coefficients[Degree] + "x^" + Degree);

            for (int i = Degree - 1; i > 0; i--)
                if (Coefficients[i] > 0)
                    temp.Append("+" + Coefficients[i] + "x^" + i);
                else
                {
                    temp.Append(Coefficients[i] + "x^" + i);
                }

            if (Coefficients[0] > 0)
                temp.Append("+" + Coefficients[0]);
            else temp.Append(Coefficients[0]);

            return temp.ToString();
        }

        /// <summary>
        /// Calculates hash code for current polynomial
        /// </summary>
        /// <returns>Hash code of the Polynomial object</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Coefficients.Length; i++)
                hash += (Coefficients[i] + i).GetHashCode();
            return hash;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Add(Polynomial value1, Polynomial value2)
        {
            if (value1 == null || value2 == null) throw new ArgumentNullException();
            
            if (value1.Coefficients.Length >= value2.Coefficients.Length)
            {
                double[] newCoefficients = new double[value1.Coefficients.Length];
                Array.Copy(value1.Coefficients, newCoefficients, value1.Coefficients.Length);
                for (int i = 0; i < value2.Coefficients.Length; i++)
                {
                    newCoefficients[i] += value2.Coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
            else
            {
                double[] newCoefficients = new double[value2.Coefficients.Length];
                Array.Copy(value2.Coefficients, newCoefficients, value2.Coefficients.Length);
                for (int i = 0; i < value1.Coefficients.Length; i++)
                {
                    newCoefficients[i] += value1.Coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Sub(Polynomial value1, Polynomial value2)
        {
            if (value1 == null || value2 == null) throw new ArgumentNullException();


            if (value1.Coefficients.Length >= value2.Coefficients.Length)
            {
                double[] newCoefficients = new double[value1.Coefficients.Length];
                Array.Copy(value1.Coefficients, newCoefficients, value1.Coefficients.Length);
                for (int i = 0; i < value2.Coefficients.Length; i++)
                {
                    newCoefficients[i] -= value2.Coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
            else
            {
                double[] newCoefficients = new double[value2.Coefficients.Length];
                Array.Copy(value2.Coefficients, newCoefficients, value2.Coefficients.Length);
                for (int i = 0; i < value1.Coefficients.Length; i++)
                {
                    newCoefficients[i] -= value1.Coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Mul(Polynomial value1, Polynomial value2)
        {
            if (value1 == null || value2 == null) throw new ArgumentNullException();
            int tempDegree = value1.Degree + value2.Degree;
            double[] newPol = new double[tempDegree + 1];
            for (int i = value1.Degree; i >= 0; i--)
                for (int j = value2.Degree; j >= 0; j--)
                    newPol[i + j] += value1.Coefficients[i] * value2.Coefficients[j];

            return new Polynomial(newPol);
            
        }
        #endregion
    }
}
