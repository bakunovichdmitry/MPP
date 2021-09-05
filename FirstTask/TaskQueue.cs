using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FirstTask
{
    class TaskQueue
    {
        private Thread[] threadPool;
        public int QuantityThread { get; set; }
        public TaskQueue(int quantityThread)
        {
            this.threadPool = new Thread[quantityThread];
            QuantityThread = quantityThread;
            for (int i = 0; i < quantityThread; i++)
            {
                threadPool[i] = new Thread(ThreadWork);
                threadPool[i].Start();
            }
        }

        public void ThreadWork()
        {
            Console.WriteLine("current proc id = " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
