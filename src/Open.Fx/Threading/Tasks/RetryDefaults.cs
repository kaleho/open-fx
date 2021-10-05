using System.Collections.Generic;
using System.Collections.Immutable;

namespace System.Threading.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RetryDefaults
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly IDictionary<int, int> DefaultAttemptDelays =
            ImmutableDictionary.CreateRange(
                new Dictionary<int, int>
                {
                    { 1, 250 },
                    { 2, 500 },
                    { 3, 1000 },
                    { 4, 1000 },
                    { 5, 2000 }
                });
    }
}