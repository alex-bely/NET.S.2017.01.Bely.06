using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace Task1
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public class Polynomial:ICloneable
    {
        #region Private members
        /// <summary>
        /// Array with polynomial's coefficients
        /// </summary>
        private double[] coefficients;
        /// <summary>
        /// Precision value
        /// </summary>
        private static double epsilon;


        /// <summary>
        /// Static constructor for initialization precision value
        /// </summary>
        static Polynomial()
        {
            epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Degree of polynomial
        /// </summary>
        private int Degree { get; }
        #endregion

        #region Construcror

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="coefficients">Polynomial's coefficients</param>
        /// <exception cref="ArgumentNullException">Array of arguments is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Array is blank</exception>
        public Polynomial(params double[] coefficients)
        {
            if(ReferenceEquals(coefficients,null))
                throw new ArgumentNullException(nameof(coefficients));
            
            if (coefficients.Length==0) throw new ArgumentOutOfRangeException();
            this.Degree = coefficients.Length - 1;
            
            while (Math.Abs(coefficients[Degree]) < epsilon && Degree > 0)
            {
                Degree--;
            }
            
            this.coefficients = new double[Degree + 1];
            Array.Copy(coefficients, this.coefficients, Degree + 1);
        }

        #endregion

        public double this[int index]
        {
            get
            {
                if (index < 0 || index > coefficients.Length)
                    throw new ArgumentOutOfRangeException();

                return coefficients[index];
            }
        }



     


        #region Operators
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Add(lhs, rhs);
        }


        /// <summary>
        /// Calculates the negation of two polynomials
        /// </summary>
        /// <param name="value">Source polynomial</param>
        /// <returns>Negation of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator -(Polynomial value)
        {
            return Polynomial.Negation(value);
        }



        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Sub(lhs, rhs);
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Polynomial.Mul(lhs, rhs);
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are equal, false if they are not</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null) /*|| ReferenceEquals(rhs,null)*/)
                return false;

            return lhs.Equals(rhs);

        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are not equal, false if the are</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
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
            int n = coefficients.Length - 1;
            double result = coefficients[n];
            for (int i = n - 1; i >= 0; i--)
            {
                if(Math.Abs(coefficients[i])<epsilon)
                    result = value * result + 0;
                else
                    result = value * result + coefficients[i];
            }
            return result;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object
        /// </summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial)obj);
            
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Polynomial object
        /// </summary>
        /// <param name="obj">The object to compare with the current Polynomial object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (this.coefficients.Length != other.coefficients.Length)
                return false;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (!this.coefficients[i].Equals(other.coefficients[i]))
                    return false;
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
            
            if (Degree == 0) return coefficients[0].ToString();

            StringBuilder temp = new StringBuilder();
            temp.Append(coefficients[Degree] + "x^" + Degree);

            for (int i = Degree - 1; i > 0; i--)
                if (coefficients[i] > epsilon)
                    temp.Append("+" + coefficients[i] + "x^" + i);
                else if (coefficients[i] < -epsilon)
                {
                    temp.Append(coefficients[i] + "x^" + i);
                }

            if (coefficients[0] > epsilon)
                temp.Append("+" + coefficients[0]);
            else if (coefficients[0] < -epsilon)
                temp.Append(coefficients[0]);

            return temp.ToString();
        }

        /// <summary>
        /// Calculates hash code for current polynomial
        /// </summary>
        /// <returns>Hash code of the Polynomial object</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.coefficients.Length; i++)
                hash += (coefficients[i] + i).GetHashCode();
            return hash;
        }
        
        
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            if (lhs.coefficients.Length >= rhs.coefficients.Length)
            {
                double[] newCoefficients = new double[lhs.coefficients.Length];
                Array.Copy(lhs.coefficients, newCoefficients, lhs.coefficients.Length);
                for (int i = 0; i < rhs.coefficients.Length; i++)
                {
                    newCoefficients[i] += rhs.coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
            else
            {
                double[] newCoefficients = new double[rhs.coefficients.Length];
                Array.Copy(rhs.coefficients, newCoefficients, rhs.coefficients.Length);
                for (int i = 0; i < lhs.coefficients.Length; i++)
                {
                    newCoefficients[i] += lhs.coefficients[i];
                }
                return new Polynomial(newCoefficients);
            }
        }

        /// <summary>
        /// Calculates the negation of the polynomial
        /// </summary>
        /// <param name="valur">Source polynomial</param>
        /// <returns>The negation of the polynomial</returns>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        public static Polynomial Negation(Polynomial value)
        {
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException();

            double[] newCoefficients = new double[value.Degree + 1];
            for (int i = 0; i < newCoefficients.Length; i++)
                newCoefficients[i] = -value.coefficients[i];
            return new Polynomial(newCoefficients);
        }



        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial Sub(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            return Polynomial.Add(lhs,Polynomial.Negation(rhs));
            
            
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial Mul(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null) throw new ArgumentNullException();
            int tempDegree = lhs.Degree + rhs.Degree;
            double[] newPol = new double[tempDegree + 1];
            for (int i = lhs.Degree; i >= 0; i--)
                for (int j = rhs.Degree; j >= 0; j--)
                    newPol[i + j] += lhs.coefficients[i] * rhs.coefficients[j];

            return new Polynomial(newPol);
            
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance</returns>

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Creates a new polynomial that is a copy of the current Polynomial.
        /// </summary>
        /// <returns>New polynomial that is a copy of the current Polynomial.</returns>

        public Polynomial Clone()
        {
            
            return new Polynomial(this.coefficients);
        }
        #endregion

    }
}
