using System;
using System.Threading;

namespace FirstTask
{
    class Program
    {

        static void Main()
        {
            TaskQueue taskQueue = new TaskQueue(3);
            for (int i = 0; i < 3; i++)
            {
                taskQueue.EnqueueTask(DoSmth);
            }

            Thread.Sleep(1000);
            taskQueue.Finish();
        }

        private static void DoSmth() {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("current proc id = " + Thread.CurrentThread.ManagedThreadId + " task = " + i);
            }
        }
    }
}
