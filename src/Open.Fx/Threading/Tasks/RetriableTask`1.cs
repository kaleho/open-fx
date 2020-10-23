using System.Collections.Generic;

namespace System.Threading.Tasks
{
    public class RetriableTask<TOutputType>
        where TOutputType : class
    {
        /// <summary>
        /// </summary>
        /// <param name="task"></param>
        /// <param name="attemptDelays">If not provided only a single attempt is made</param>
        /// <param name="throwsOnFailure"></param>
        public RetriableTask(
            Task<TOutputType> task,
            IDictionary<int, int> attemptDelays = null,
            bool throwsOnFailure = true)
        {
            ThrowsOnFailure = throwsOnFailure;

            Output = SyncRunner.Run(() => Run(task, 1, attemptDelays));
        }

        public TOutputType Output { get; }

        public bool ThrowsOnFailure { get; }

        private async Task<TOutputType> Run(
            Task<TOutputType> task,
            int attemptCount,
            IDictionary<int, int> attemptDelays = null)
        {
            try
            {
                var output = await task;

                return output;
            }
            catch
            {
                if (attemptDelays?.ContainsKey(attemptCount) == true)
                {
                    await Task.Delay(attemptDelays[attemptCount]).ConfigureAwait(false);

                    var nextAttempt =
                        attemptDelays.ContainsKey(attemptCount++)
                            ? attemptCount + 1
                            : -1;

                    return await Run(
                            task,
                            nextAttempt,
                            attemptDelays)
                        .ConfigureAwait(false);
                }

                if (ThrowsOnFailure)
                {
                    throw;
                }
            }

            return default;
        }
    }
}