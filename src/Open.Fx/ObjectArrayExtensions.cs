using System.Linq;

namespace System
{
    public static class ObjectArrayExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool HasType<T>(
            this object[] array)
        {
            return array.HasType(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasType(
            this object[] array,
            Type type)
        {
            var returnValue = array.Any(x => x.GetType() == type);

            return returnValue;
        }
    }
}