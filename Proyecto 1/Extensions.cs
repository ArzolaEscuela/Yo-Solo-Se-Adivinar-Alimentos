using System;

namespace Proyecto_1
{
    public static class Extensions
    {
        private static Random rnd = new Random();

        public static T GetRandomElement<T>(this T[] array)
        {
            return array[rnd.Next(array.Length)];
        }
    }
}