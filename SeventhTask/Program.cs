using System;
using System.Threading;

namespace SeventhTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback[] tasks = CreateTasks(10);
            Parallel.WaitAll(tasks);
        }

        private static WaitCallback[] CreateTasks(int taskNumber)
        {
            WaitCallback[] tasks = new WaitCallback[taskNumber];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = obj =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Task in {Thread.CurrentThread.ManagedThreadId} completed.");
                };
            }
            return tasks;
        }
    }
}
