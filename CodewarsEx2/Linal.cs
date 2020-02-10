using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodewarsEx2
{
    class Linal                                                 //Linear algebra
    /**
     1. Determinant founder for int or double
        (Шестая задача
        https://www.codewars.com/kata/52a382ee44408cea2500074c/train/csharp)
    
     2. Matrix Multiply
     */

    {
        public int Determinant(int[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)             //We can take determinant only in
                if (matrix[i].Length != matrix[0].Length)       //square-matrix
                {
                    Console.WriteLine("I can't found determinant, because this matrix " +
                                      "isn't square-matrix");
                    return Convert.ToInt32(null);
                }
            return DeterminantFounder(matrix);
        }

        public double Determinant(double[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
                if (matrix[i].Length != matrix[0].Length)
                {
                    Console.WriteLine("I can't found determinant, because this matrix " +
                                      "isn't square-matrix");
                    return Convert.ToInt32(null);
                }
            return DeterminantFounder(matrix);
        }

        public int Determinant(int[,] matrix)
        {
            return DeterminantFounder(matrix);          //Because we already have the square-matrix
        }

        public double Determinant(double[,] matrix)
        {
            return DeterminantFounder(matrix);
        }

        protected int DeterminantFounder(int[][] matrix)
        {
            int counter = 0;
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }
            else
            {
                int[][] detMatrix = new int[matrix.Length - 1][];
                for (int i = 0; i < detMatrix.Length; i++)
                {
                    detMatrix[i] = new int[detMatrix.Length];
                }
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    for (int j = 1; j < matrix.Length; j++)
                    {
                        int d = 0;
                        for (int k = 0; k < matrix[j].Length; k++)
                        {
                            if (k != i)
                            {
                                detMatrix[j - 1][k + d] = matrix[j][k];
                            }
                            else
                            {
                                d = -1;
                                continue;
                            }
                        }
                    }
                    counter += Convert.ToInt32(Math.Pow(-1, Convert.ToDouble(i))) * matrix[0][i] * DeterminantFounder(detMatrix);
                }
                return counter;
            }
        }
        protected double DeterminantFounder(double[][] matrix)
        {
            double counter = 0;
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }
            else
            {
                double[][] detMatrix = new double[matrix.Length - 1][];
                for (int i = 0; i < detMatrix.Length; i++)
                {
                    detMatrix[i] = new double[detMatrix.Length];
                }
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    for (int j = 1; j < matrix.Length; j++)
                    {
                        int d = 0;
                        for (int k = 0; k < matrix[j].Length; k++)
                        {
                            if (k != i)
                            {
                                detMatrix[j - 1][k + d] = matrix[j][k];
                            }
                            else
                            {
                                d = -1;
                                continue;
                            }
                        }
                    }
                    counter += Convert.ToInt32(Math.Pow(-1, Convert.ToDouble(i))) * matrix[0][i] * DeterminantFounder(detMatrix);
                }
                return counter;
            }
        }

        protected int DeterminantFounder(int[,] matrix)
        {
            int counter = 0;
            if (matrix.GetLength(0) == 1)
            {
                return matrix[0, 0];
            }
            else
            {
                int[,] detMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        int d = 0;
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            if (k != i)
                            {
                                detMatrix[j - 1, k + d] = matrix[j, k];
                            }
                            else
                            {
                                d = -1;
                                continue;
                            }
                        }
                    }
                    counter += Convert.ToInt32(Math.Pow(-1, Convert.ToDouble(i))) * matrix[0, i] * DeterminantFounder(detMatrix);
                }
                return counter;
            }
        }

        protected double DeterminantFounder(double[,] matrix)
        {
            double counter = 0;
            if (matrix.GetLength(0) == 1)
            {
                return matrix[0, 0];
            }
            else
            {
                double[,] detMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        int d = 0;
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            if (k != i)
                            {
                                detMatrix[j - 1, k + d] = matrix[j, k];
                            }
                            else
                            {
                                d = -1;
                                continue;
                            }
                        }
                    }
                    counter += Convert.ToInt32(Math.Pow(-1, Convert.ToDouble(i))) * matrix[0, i] * DeterminantFounder(detMatrix);
                }
                return counter;
            }
        }
    }
}

