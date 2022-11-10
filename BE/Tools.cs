using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Tools
    {
        /// <summary>
        /// This is a way to save the matrix of the taken days, it flattens the original matrix to one dimensional arry, 
        /// so that the Xml will be able to save it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns>the flattend matrix</returns>
        public static T[] Flatten<T>(this T[,] arr) 
        {
            int rows = arr.GetLength(0); 
            int columns = arr.GetLength(1);
            T[] arrFlattened = new T[rows * columns]; // Creating a new arry and sets it length to rows times columms
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    var test = arr[i, j];
                    arrFlattened[i * rows + j] = arr[i, j];
                }
            }
            return arrFlattened; // returns the flattend arry
        }

        /// <summary>
        /// When we want to extricate the flattend arry from the Xml, we need to expand it back to the matrix it was,
        /// so this function creates the original matrix from the arry.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="rows"></param>
        /// <returns>the original matrix</returns>
        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int length = arr.GetLength(0);
            int columns = length / rows;
            T[,] arrExpanded = new T[rows, columns]; // creating a 2 dimensional matrix
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    arrExpanded[i, j] = arr[i * rows + j];
                }
            }
            return arrExpanded; // returns the original matrix
        }
    }
}
