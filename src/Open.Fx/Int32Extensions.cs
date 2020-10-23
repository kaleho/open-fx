using System.Collections.Generic;

namespace System
{
    public static class Int32Extensions
    {
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