using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Utils
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

        /// <summary>
        /// Checks if node apears in array of nodes
        /// </summary>
        /// <param name="n">node to check if it appears</param>
        /// <param name="nodes">array to check for occurance of n</param>
        /// <returns></returns>
        public static Boolean NoRepeateNode(Node n, Node[] nodes )
        {
            for (int i = 0; i < nodes.Length; i++) {
                if (n == nodes[i]) return false; //Must be same by reference
            }
            return true;
        }

        /// <summary>
        /// Merges two Arrays
        /// </summary>
        /// <typeparam name="T"> Template type</typeparam>
        /// <param name="array1">Array1</param>
        /// <param name="array2">Array1</param>
        /// <returns></returns>
        public static T[] MergeArrays<T>(T[] array1, T[] array2)
        {
            int intlength = array1.Length;
            int destinationIndex = array2.Length;

            Array.Resize(ref array2, array1.Length + array2.Length);
            Array.Copy(array1, 0, array2, destinationIndex, intlength);
            return array2;
        }
        /// <summary>
        /// Resize and append element to array
        /// </summary>
        /// <typeparam name="T">Template type</typeparam>
        /// <param name="array">Array to append to</param>
        /// <param name="a">Element to append</param>
        /// <returns></returns>
        public static T[] AppentToArray<T>(T[] array, T a) {
            T[] arrayR = new T[array.Length + 1];
            Array.Copy(array, arrayR, array.Length);
            arrayR[array.Length] = a;
            return arrayR;
        }
        /// <summary>
        /// Remove an element from an array at given index
        /// </summary>
        /// <typeparam name="T">Template type</typeparam>
        /// <param name="source"> source array</param>
        /// <param name="index">index of element to remove</param>
        /// <returns></returns>
        public static T[] RemoveAt<T>( T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        /// <summary>
        /// Check if array of node contains a node with the given name
        /// </summary>
        /// <param name="nodes">Array of nodes</param>
        /// <param name="name">name to look for</param>
        /// <returns></returns>
        public static Boolean ContainsName(Node[] nodes, String name) {
            for (int i = 0; i < nodes.Length; i++) {
                if (nodes[i].name.Equals(name)) return true;
            }
            return false;
        }
    }
}
