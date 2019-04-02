using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._05.Tests
{
    class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, new double[] { 0 })]
        [TestCase(new double[] { 1.204, -2.569, 3.987, 4.879, -0.896, 9 }, new double[] { 1, -2, -3, 4 }, new double[] { 0.204, -0.569, 6.987, 0.879, -0.896, 9 })]
        public static void Polynomial_Substract(double[] array1, double[] array2, double[] expected)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 - p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 }, new double[] { 1, 4, 10, 20, 25, 24, 16 })]
        [TestCase(new double[] { -0.251, 0.652, -0.983, 4.11 }, new double[] { -89.23, 0.1278, 0.9873 }, new double[] { 22.396700, -58.2100, 87.548600, -366.21700, -0.4452002, 4.0578 })]
        public static void Polynomial_Multiply(double[] array1, double[] array2, double[] expected)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p3 = new Polynomial(expected);
            Assert.AreEqual(p1 * p2, p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, ExpectedResult = "1+2x+3x^2+4x^3-x^5+11,2564x^6-1E-05x^7")]
        public static string Polynomial_ToString(double[] array)
        {
            Polynomial p1 = new Polynomial(array);
            return p1.ToString();
        }

        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.00001 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.20 }, new double[] { 1, 2, 3, 4, 0, -1, 11.2564, -0.19 }, ExpectedResult = false)]
        public static bool Polynomial_Equals(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return p1.Equals(p2);
        }
    }
}
