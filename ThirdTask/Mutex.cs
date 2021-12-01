using System.Threading;
using System;

namespace ThirdTask
{
    class Mutex
    {
        private int lockId;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref lockId, Thread.CurrentThread.ManagedThreadId, 0) != 0) {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref lockId, 0, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
