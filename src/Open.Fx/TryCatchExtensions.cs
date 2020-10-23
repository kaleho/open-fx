namespace System
{
    public static class TryCatchExtensions
    {
        /// <summary>
        ///     Returns false if the try func throws an exception
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue">Value to return if the try func is not successful</param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool TryCatchDefault<TIn, TOut>(
            this TIn source,
            Func<TIn, TOut> func,
            TOut defaultValue,
            out TOut returnValue)
        {
            try
            {
                returnValue = func(source);

                return true;
            }
            catch
            {
                returnValue = defaultValue;

                return false;
            }
        }

        public static bool TryCatchIgnore<T>(
            this T source,
            Action<T> action)
        {
            try
            {
                action(source);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryCatchIgnore<TIn, TOut>(
            this TIn source,
            Func<TIn, TOut> func,
            out TOut returnValue)
        {
            try
            {
                returnValue = func(source);

                return true;
            }
            catch
            {
                returnValue = default;

                return false;
            }
        }
    }
}