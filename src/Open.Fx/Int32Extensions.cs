using System.Collections.Generic;

namespace System
{
    public static class Int32Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iterations"></param>
        /// <param name="generatorFunction"></param>
        /// <returns></returns>
        public static List<T> Items<T>(
            this int iterations,
            Func<int, T> generatorFunction)
        {
            var returnValue = new List<T>();

            for (var i = 0; i < iterations; i++)
            {
                returnValue.Add(generatorFunction(i));
            }

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterations"></param>
        /// <param name="action"></param>
        public static void Times(
            this int iterations,
            Action<int> action)
        {
            for (var i = 0; i < iterations; i++)
            {
                action(i);
            }
        }
    }
}