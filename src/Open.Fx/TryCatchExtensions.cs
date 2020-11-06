namespace System
{
    public static class TryCatchExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool TryCatch<TIn, TOut>(
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool TryCatch<T>(
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool TryCatch<TIn, TOut>(
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