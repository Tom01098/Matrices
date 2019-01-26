using System;

namespace Matrices
{
    public readonly struct Matrix : IEquatable<Matrix>
    {
        public int Rows { get; }
        public int Columns { get; }

        public int this[int x, int y] => arr[x - 1, y - 1];

        private readonly int[,] arr;

        public Matrix(int[,] arr)
        {
            Rows = arr.GetLength(0);
            Columns = arr.GetLength(1);

            this.arr = arr;
        }

        public bool Equals(Matrix other) => this == other;

        public override bool Equals(object obj) =>
            obj is Matrix ? Equals((Matrix)obj) : false;

        public override int GetHashCode() => 
            HashCode.Combine(Rows, Columns, arr);
        
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                return false;
            }

            for (int x = 1; x <= a.Rows; x++)
            {
                for (int y = 1; y <= a.Columns; y++)
                {
                    if (a[x, y] != b[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b) => !(a == b);

        public static Matrix operator +(Matrix lhs, Matrix rhs)
        {
            var arr = lhs.arr;

            if (lhs.Rows != rhs.Rows || lhs.Columns != rhs.Columns)
            {
                throw new InvalidOperationException("Cannot sum two " +
                    "matrices with different dimensions.");
            }

            for (int x = 1; x <= rhs.Rows; x++)
            {
                for (int y = 1; y <= rhs.Columns; y++)
                {
                    arr[x - 1, y - 1] += rhs[x, y];
                }
            }

            return arr;
        }

        public static Matrix operator -(Matrix lhs, Matrix rhs)
        {
            var arr = lhs.arr;

            if (lhs.Rows != rhs.Rows || lhs.Columns != rhs.Columns)
            {
                throw new InvalidOperationException("Cannot subtract two " +
                    "matrices with different dimensions.");
            }

            for (int x = 1; x <= rhs.Rows; x++)
            {
                for (int y = 1; y <= rhs.Columns; y++)
                {
                    arr[x - 1, y - 1] -= rhs[x, y];
                }
            }

            return arr;
        }

        public static Matrix operator *(Matrix matrix, int num)
        {
            var arr = matrix.arr;

            for (int x = 1; x <= matrix.Rows; x++)
            {
                for (int y = 1; y <= matrix.Columns; y++)
                {
                    arr[x - 1, y - 1] *= num;
                }
            }

            return arr;
        }

        public static Matrix operator *(int num, Matrix matrix) => matrix * num;

        public static implicit operator Matrix(int[,] arr) => new Matrix(arr);

        public static explicit operator int[,](Matrix matrix) => matrix.arr;
    }
}
