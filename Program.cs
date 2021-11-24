using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 0, 1, 1, 0, 1},
                                         { 0, 1, 1, 1, 1},
                                         { 1, 1, 0, 1, 1},
                                         { 1, 1, 1, 1, 1},
                                         { 1, 1, 1, 1, 1},
            };

            bool ThereIsZeroInTheCurrentRow = false;
            bool setJIndexToZero = false;
            HashSet<int> indexOfColumnToSetZeroIn = new HashSet<int>();

            Console.WriteLine("\nBefore:\n");
            printMatrixValues(matrix.GetLength(0), matrix.GetLength(1));
            //time complexity is O(M*N)
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if(ThereIsZeroInTheCurrentRow==true)
                    {
                        if (setJIndexToZero == false)
                        {
                            j = 0;
                            setJIndexToZero = true;
                        }
                        else
                        {
                            if(matrix[i,j]==0)
                            {
                                //hashsets contains method time complexity is O(1)
                                if (!indexOfColumnToSetZeroIn.Contains(j))
                                {
                                    indexOfColumnToSetZeroIn.Add(j);
                                }
                            }
                            matrix[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] == 0)
                        {
                            ThereIsZeroInTheCurrentRow = true;
                            if (!indexOfColumnToSetZeroIn.Contains(j))
                            {
                                indexOfColumnToSetZeroIn.Add(j);
                            }
                        }
                        else
                        {
                            if (indexOfColumnToSetZeroIn.Contains(j))
                            {
                                matrix[i, j] = 0;
                            }
                        }
                    }
                }
                ThereIsZeroInTheCurrentRow = false;
                setJIndexToZero = false;
            }
            Console.WriteLine("\nAfter:\n");
            printMatrixValues(matrix.GetLength(0), matrix.GetLength(1));

            void printMatrixValues(int indexI,int indexJ)
            {
                for (int i = 0; i < indexI; i++)
                {
                    for (int j = 0; j < indexJ; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
