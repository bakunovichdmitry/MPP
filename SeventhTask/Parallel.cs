using System;
using System.Threading;

namespace SeventhTask
{
    class Parallel
    {
        public static void WaitAll(WaitCallback[] tasks)
        {
            if (tasks.Length == 0)
                return;

            foreach (var task in tasks)
                ThreadPool.QueueUserWorkItem(task);

            int maxThreads, availableThreads;
            ThreadPool.GetMaxThreads(out maxThreads, out _);
            do
            {
                ThreadPool.GetAvailableThreads(out availableThreads, out _);
            } while (maxThreads != availableThreads);
        }
    }
}
