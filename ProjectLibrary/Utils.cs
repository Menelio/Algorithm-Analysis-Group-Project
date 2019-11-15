using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    class Utils
    {
        /// <summary>
        /// Gets a specified row of a 2d array
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="array">2d array </param>
        /// <param name="row">index of row to get</param>
        /// <returns></returns>
        public static T[] GetRow<T>(T[,] array, int row)
        {
            var rowLength = array.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++) { 
                rowVector[i] = array[row, i];
            }
            return rowVector;
        }
    }
}
