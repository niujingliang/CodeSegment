using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSegment
{
    /// <summary>
    /// 读写锁。操作完可以自动释放
    /// </summary>
    public class ReaderWriterLock
    {
        private static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        public static IDisposable GetReadLock()
        {
            _rwLock.EnterReadLock();
            return new ReadLockDisposable(_rwLock);
        }

        //使用方法
        //public void Test()
        //{
        //    using (GetReadLock())
        //    {
        //        /*
        //            Do Something
        //        */
        //    }
        //}

        private class ReadLockDisposable : IDisposable
        {
            private ReaderWriterLockSlim _rwLock;

            public ReadLockDisposable(ReaderWriterLockSlim rwLock)
            {
                _rwLock = rwLock;
            }

            void IDisposable.Dispose()
            {
                _rwLock.ExitReadLock();
            }
        }

        private class WriteLockDisposable : IDisposable
        {

            private ReaderWriterLockSlim _rwLock;

            public WriteLockDisposable(ReaderWriterLockSlim rwLock)
            {
                _rwLock = rwLock;
            }

            void IDisposable.Dispose()
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}
