using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise6
{
    public class MatrixMultiplicationTable : IMatrixOperationTable
    {
        private int[,] _matrixTable;
        private int _numberOfRows;
        public void Generate(int number)
        {
            _numberOfRows = number;
            _matrixTable = new int[number, number];
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    _matrixTable[i, j] = (i+1) * (j+1);
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < _numberOfRows; i++)
            {
                for (int j = 0; j < _numberOfRows; j++)
                {
                    Console.Write($"{_matrixTable[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
