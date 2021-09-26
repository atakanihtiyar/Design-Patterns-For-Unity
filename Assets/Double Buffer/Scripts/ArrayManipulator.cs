using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.DoubleBuffer
{
    /// <summary>
    /// Class for manipulate arrays
    /// </summary>
    public static class ArrayManipulator
    {
        /// <summary>
        /// Function for manipulate your array data with value from another array
        /// </summary>
        /// <typeparam name="ArrayType1"> Array type to manipulate </typeparam>
        /// <typeparam name="ArrayType2"> Array type for manipulate information </typeparam>
        /// <param name="data"> Array to manipulate </param>
        /// <param name="fromData"> Array for manipulate information </param>
        /// <param name="applyToCell"> Manipulate function. Function parameters must be data array value, another array value, cell x index, cell y index. Return must be new manipulated cell value. </param>
        /// <returns>Returns manipulated array data </returns>
        public static ArrayType1[,] ManipulateFromAnother<ArrayType1, ArrayType2>(ArrayType1[,] data, ArrayType2[,] fromData, System.Func<ArrayType1, ArrayType2, int, int, ArrayType1> applyToCell)
        {
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    data[x, y] = applyToCell.Invoke(data[x, y], fromData[x, y], x, y);
                }
            }

            return data;
        }

        /// <summary>
        /// Function for manipulate your array data
        /// </summary>
        /// <typeparam name="ArrayType1"> Array type to manipulate </typeparam>
        /// <param name="data"> Array to manipulate </param>
        /// <param name="applyToCell"> Manipulate function. Function parameters must be array value, cell x index, cell y index. Return must be new manipulated cell value. </param>
        /// <returns>Returns manipulated array data </returns>
        public static T[,] Manipulate<T>(T[,] data, System.Func<T, int, int, T> applyToCell)
        {
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    data[x, y] = applyToCell.Invoke(data[x, y], x, y);
                }
            }

            return data;
        }

        /// <summary>
        /// Function for manipulate your 1D array data with value from another 2D array
        /// </summary>
        /// <typeparam name="ArrayType1"> Array type to manipulate </typeparam>
        /// <typeparam name="ArrayType2"> Array type for manipulate information </typeparam>
        /// <param name="data"> 1D array to manipulate </param>
        /// <param name="fromData"> 2D array for manipulate information </param>
        /// <param name="applyToCell"> Manipulate function. Function parameters must be data array value, another array value, cell x index, cell y index. Return must be new manipulated cell value. </param>
        /// <returns>Returns manipulated array data </returns>
        public static T1[] ManipulateFrom2DTo1D<T1, T2>(T1[] data, T2[,] fromData, System.Func<T1, T2, int, int, T1> applyToCell)
        {
            for (int y = 0; y < fromData.GetLength(1); y++)
            {
                for (int x = 0; x < fromData.GetLength(0); x++)
                {
                    int index = y * fromData.GetLength(0) + x;
                    data[index] = applyToCell.Invoke(data[index], fromData[x, y], x, y);
                }
            }

            return data;
        }
    }
}

