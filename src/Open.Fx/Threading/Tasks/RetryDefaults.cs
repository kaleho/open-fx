using System.Collections.Generic;
using System.Collections.Immutable;

namespace System.Threading.Tasks
{
    public sealed class RetryDefaults
    {
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