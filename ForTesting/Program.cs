using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary;
namespace ForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,] { { 1,2},
                                    { 3,4 },
                                    { 5,6 }};


            int[] b = GetRow(a, 2);

            Console.WriteLine(a.GetLength(0));

            //Console.WriteLine(b[0]);
           // Console.WriteLine(b[1]);
            //just to puase cuz im lazy
            Console.ReadKey();
        }

        public static T[] GetRow<T>( T[,] matrix, int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }
    }
}
