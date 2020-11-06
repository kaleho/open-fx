namespace System.Threading.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public class SlimLock
        : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly struct ReadLockToken
            : IDisposable
        {
            private readonly ReaderWriterLockSlim _lock;

            public ReadLockToken(
                ReaderWriterLockSlim @lock)
            {
                _lock = @lock;

                @lock.EnterReadLock();
            }

            public void Dispose()
            {
                _lock.ExitReadLock();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly struct WriteLockToken
            : IDisposable
        {
            private readonly ReaderWriterLockSlim _lock;

            public WriteLockToken(
                ReaderWriterLockSlim @lock)
            {
                _lock = @lock;

                @lock.EnterWriteLock();
            }

            public void Dispose()
            {
                _lock.ExitWriteLock();
            }
        }

        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public void Dispose()
        {
            _lock.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReadLockToken ReadLock()
        {
            return new ReadLockToken(_lock);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WriteLockToken WriteLock()
        {
            return new WriteLockToken(_lock);
        }
    }
}