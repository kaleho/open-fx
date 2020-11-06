using System.Collections.Generic;

namespace System.Threading.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public class RetriableTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="attemptDelays"></param>
        /// <param name="throwsOnFailure"></param>
        public RetriableTask(
            Task task,
            IDictionary<int, int> attemptDelays = null,
            bool throwsOnFailure = true)
        {
            ThrowsOnFailure = throwsOnFailure;

            Completed = SyncRunner.Run(() => Run(task, 1, attemptDelays));
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Completed { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool ThrowsOnFailure { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="attemptCount"></param>
        /// <param name="attemptDelays"></param>
        /// <returns></returns>
        private async Task<bool> Run(
            Task task,
            int attemptCount,
            IDictionary<int, int> attemptDelays = null)
        {
            try
            {
                await task.ConfigureAwait(false);

                return true;
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

                    await Run(
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