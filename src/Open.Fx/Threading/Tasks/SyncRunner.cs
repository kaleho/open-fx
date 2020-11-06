namespace System.Threading.Tasks
{
    /// <summary>
    ///     Credit: https://cpratt.co/async-tips-tricks/
    /// </summary>
    public static class SyncRunner
    {
        private static readonly TaskFactory TaskFactory =
            new TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        /// <summary>
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult Run<TResult>(
            Func<Task<TResult>> func)
        {
            return TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// </summary>
        /// <param name="func"></param>
        public static void Run(
            Func<Task> func)
        {
            TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }
    }
}