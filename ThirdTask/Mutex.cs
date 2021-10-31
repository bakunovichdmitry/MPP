using System.Threading;

namespace ThirdTask
{
    class Mutex
    {
        private int currentId;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref currentId, 1, 0) != 0)
                Thread.Sleep(1000);
        }

        public void Unlock()
        {
            while (Interlocked.CompareExchange(ref currentId, 0, 1) != 1) ;
        }
    }
}
