using System.Linq;

namespace System
{
    public static class ObjectArrayExtensions
    {
        public static bool HasType<T>(
            this object[] array)
        {
            return array.HasType(typeof(T));
        }

        public static bool HasType(
            this object[] array,
            Type type)
        {
            var returnValue = array.Any(x => x.GetType() == type);

            return returnValue;
        }
    }
}