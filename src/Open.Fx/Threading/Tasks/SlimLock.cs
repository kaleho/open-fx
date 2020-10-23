namespace System.Threading.Tasks
{
    public class SlimLock
        : IDisposable
    {
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

        public ReadLockToken ReadLock()
        {
            return new ReadLockToken(_lock);
        }

        public WriteLockToken WriteLock()
        {
            return new WriteLockToken(_lock);
        }
    }
}