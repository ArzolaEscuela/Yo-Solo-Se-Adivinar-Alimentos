using System;
using System.Collections.Generic;

namespace Proyecto_1
{
    public static class Extensions
    {
        private static Random rnd = new Random();

        public static T GetRandomElement<T>(this T[] array)
        {
            return array[rnd.Next(array.Length)];
        }

        public static List<T> CloneList<T>(this List<T> list)
        {
            int listSize = list.Count;
            List<T> newList = new List<T>();
            for (int i = 0; i < listSize; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
    }
}