using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._05
{
    public sealed class Polynomial
    {
        /// <summary>
        /// The accuracy of counting
        /// </summary>
        public static double epsilon = 0.001;

        private double[] coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial" /> class.
        /// </summary>
        /// <param name="coef">The coefficient</param>
        /// <remarks>
        /// (Uncorrect: 0*x^3 + 0*x^2+ 0*x + 0)
        /// Nulcoef avoids this problem.
        /// </remarks>
        public Polynomial(params double[] coef)
        {
            if (coef == null)
            {
                throw new ArgumentNullException("Polynomial can not be null", nameof(coef));
            }
            Degree = coef.Length - 1;
            coefficients = new double[Degree + 1];
            int nullCoef = 0;
            for (int i = 0; i <= Degree; i++)
            {
                if (coef[i] == 0)
                {
                    nullCoef++;
                }
                this[i] = coef[i];
            }

            if (nullCoef == Degree + 1)
            {
                Degree = 0;
                coefficients = new double[Degree + 1];
                coefficients[0] = 0;
            }
        }

        private Polynomial(int degree)
        {
            Degree = degree;
            coefficients = new double[Degree + 1];
        }

        /// <summary>
        /// Gets the degree.
        /// </summary>
        public int Degree { get; private set; }

        /// <summary>
        /// Indexer
        /// </summary>
        public double this[int i]
        {
            get
            {
                if (Degree > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException("Wrong index");
                }
                return coefficients[i];
            }
            private set
            {
                if (i < 0 && i >= coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException("Wrong index");
                }
                coefficients[i] = value;
            }
        }

        /// <summary>
        /// Operator + overload for polynomial objects
        /// </summary>
        /// <param name="pFirst">First polynomial</param>
        /// <param name="pSecond">Second polynomial</param>
        /// <returns>
        /// The sum of polynomials
        /// </returns>
        public static Polynomial operator +(Polynomial pFirst, Polynomial pSecond)
        {
            if (pFirst is null)
            {
                throw new ArgumentNullException("First polynomial can not be null");
            }
            if (pSecond is null)
            {
                throw new ArgumentNullException("Second potynomial ca not be null");
            }

            Polynomial larger, smaller;
            if (pFirst.Degree > pSecond.Degree)
            {
                larger = pFirst.Clone();
                smaller = pSecond.Clone();
            }
            else
            {
                larger = pSecond.Clone();
                smaller = pFirst.Clone();
            }

            for (int i = 0; i <= smaller.Degree; i++)
            {
                larger[i] += smaller[i];
            }

            Polynomial resultPolynomial = new Polynomial(larger.coefficients);
            return resultPolynomial;
        }

        /// <summary>
        /// Operator - overload for polynomial objects
        /// </summary>
        /// <param name="pFirst">First polynomial</param>
        /// <param name="pSecond">Second polynomial</param>
        /// <returns>
        /// The substract of polynomials.
        /// </returns>
        public static Polynomial operator -(Polynomial pFirst, Polynomial pSecond)
        {
            if (pFirst is null)
            {
                throw new ArgumentNullException("First polynomial can not be null");
            }
            if (pSecond is null)
            {
                throw new ArgumentNullException("Second potynomial ca not be null");
            }

            Polynomial larger, smaller;
            if (pFirst.Degree > pSecond.Degree)
            {
                larger = pFirst.Clone();
                smaller = pSecond.Clone();
            }
            else
            {
                larger = pSecond.Clone();
                smaller = pFirst.Clone();
            }

            for (int i = 0; i <= smaller.Degree; i++)
            {
                larger[i] -= smaller[i];
            }

            Polynomial resultPolynomial = new Polynomial(larger.coefficients);
            return resultPolynomial;
        }

        /// <summary>
        /// Operator * overload for polynomial objects
        /// </summary>
        /// <param name="pFirst">First polynomial</param>
        /// <param name="pSecond">Second polynomial</param>
        /// <returns>
        /// The multiplication of polynomials.
        /// </returns>
        public static Polynomial operator *(Polynomial pFirst, Polynomial pSecond)
        {
            Polynomial resultPolynomial = new Polynomial(pFirst.Degree + pSecond.Degree);
            for (int i = 0; i <= pFirst.Degree; i++)
            {
                for (int j = 0; j <= pSecond.Degree; j++)
                {
                    resultPolynomial.coefficients[i + j] += pFirst[i] * pSecond[j];
                }
            }
            return resultPolynomial;
        }

        /// <summary>
        /// Operator == overload for polynomial objects
        /// </summary>
        /// <param name="pFirst">First polynomial</param>
        /// <param name="pSecond">Second polynomial</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, pSecond))
            {
                return true;
            }

            if (pFirst is null || pSecond is null)
            {
                return false;
            }

            if (pFirst.Degree != pSecond.Degree)
            {
                return false;
            }
            else
            {
                for (int i = 0; i <= pFirst.Degree; i++)
                {
                    if (Math.Abs(pFirst[i] - pSecond[i]) >= epsilon)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Operator != overload for polynomial objects
        /// </summary>
        /// <param name="pFirst">First polynomial</param>
        /// <param name="pSecond">Second polynomial</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial pFirst, Polynomial pSecond)
        {
            return !(pFirst.Degree == pSecond.Degree);
        }

        public override string ToString()
        {
            string stringRepresentation = null;
            for (int i = 0; i <= Degree; i++)
            {
                if (this[i] == 0)
                {
                    continue;
                }
                if (stringRepresentation != null)
                {
                    if (this[i] > 0)
                    {
                        stringRepresentation += "+";
                    }
                }
                if (i == 0)
                {
                    stringRepresentation += this[i];
                    continue;
                }
                if (i == 1)
                {
                    stringRepresentation += this[i];
                    stringRepresentation += $"x";
                    continue;
                }
                if (this[i] != 1)
                {
                    if (this[i] == -1)
                    {
                        stringRepresentation += "-";
                    }
                    else
                    {
                        stringRepresentation += this[i];
                    }
                }
                stringRepresentation += $"x^{i}";
            }
            return stringRepresentation;
        }

        /// <summary>
        /// Equalses the specified polynomials.
        /// </summary>
        /// <param name="other">The other polynomial.</param>
        public bool Equals(Polynomial other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (coefficients.Length != other.coefficients.Length)
            {
                return false;
            }
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i <= Degree; i++)
            {
                hashCode += this[i].GetHashCode() * i.GetHashCode();
            }
            return hashCode;
        }

        private Polynomial Clone()
        {
            return new Polynomial
            {
                coefficients = coefficients,
                Degree = Degree
            };
        }
    }
}
