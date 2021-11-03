using System.Threading;
using System;

namespace ThirdTask
{
    class Mutex
    {
        private int currentValue;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref currentValue, 1, 0) != 0) {
                Thread.Sleep(1000);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref currentValue, 0, 1);
        }
    }
}
