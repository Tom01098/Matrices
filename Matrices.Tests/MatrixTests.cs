using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Matrices.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Instantiation()
        {
            var arr = new int[3, 2]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };

            var matrix = new Matrix(arr);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(1, matrix[1, 1]);
            Assert.AreEqual(2, matrix[1, 2]);
            Assert.AreEqual(3, matrix[2, 1]);
            Assert.AreEqual(4, matrix[2, 2]);
            Assert.AreEqual(5, matrix[3, 1]);
            Assert.AreEqual(6, matrix[3, 2]);
        }

        [TestMethod]
        public void Casting()
        {
            Matrix matrix = new int[3, 2]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(1, matrix[1, 1]);
            Assert.AreEqual(2, matrix[1, 2]);
            Assert.AreEqual(3, matrix[2, 1]);
            Assert.AreEqual(4, matrix[2, 2]);
            Assert.AreEqual(5, matrix[3, 1]);
            Assert.AreEqual(6, matrix[3, 2]);
        }

        [TestMethod]
        public void Addition()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix sum = a + b;

            Assert.AreEqual(2, sum[1, 1]);
            Assert.AreEqual(4, sum[1, 2]);
            Assert.AreEqual(6, sum[2, 1]);
            Assert.AreEqual(8, sum[2, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AdditionException()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[1, 2]
            {
                { 1, 2 }
            };

            Matrix sum = a + b;
        }

        [TestMethod]
        public void Subtraction()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix sum = a - b;

            Assert.AreEqual(0, sum[1, 1]);
            Assert.AreEqual(0, sum[1, 2]);
            Assert.AreEqual(0, sum[2, 1]);
            Assert.AreEqual(0, sum[2, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubtractionException()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[1, 2]
            {
                { 1, 2 }
            };

            Matrix sum = a - b;
        }

        [TestMethod]
        public void ScalarMultiplication()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix result = a * 3;

            Assert.AreEqual(3, result[1, 1]);
            Assert.AreEqual(6, result[1, 2]);
            Assert.AreEqual(9, result[2, 1]);
            Assert.AreEqual(12, result[2, 2]);
        }

        [TestMethod]
        public void ScalarMultiplication2()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix result = 3 * a;

            Assert.AreEqual(3, result[1, 1]);
            Assert.AreEqual(6, result[1, 2]);
            Assert.AreEqual(9, result[2, 1]);
            Assert.AreEqual(12, result[2, 2]);
        }

        [TestMethod]
        public void Equality()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            bool result = a == b;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Inequality()
        {
            Matrix a = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };

            Matrix b = new int[2, 2]
            {
                { 1, 3 },
                { 3, 4 }
            };

            bool result = a == b;

            Assert.AreEqual(false, result);
        }
    }
}
