using System;
using System.Threading;
using FirstTask;

namespace SecondTask
{
    class FileСopier
    {
        private string sourcePath;
        private string targetPath;

        public int copyFileNumber = 0;

        TaskQueue taskQueue = new TaskQueue(3);
        public FileСopier(
            string sourcePath = @"C:\Users\37533\Desktop\TestCopy",
            string targetPath = @"C:\Users\37533\Desktop\TestCopyDest"
)
        {
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;

            CheckSourceDirectory();
            CheckTargetDirectory();
        }

        public void CheckSourceDirectory()
        {
            if (!System.IO.Directory.Exists(this.sourcePath))
            {
                Console.WriteLine("Source path don't exists");
                System.Environment.Exit(0);
            }

        }
        public void CheckTargetDirectory()
        {
            if (!System.IO.Directory.Exists(this.targetPath))
            {
                System.IO.Directory.CreateDirectory(this.targetPath);
            }
        }

        public void StartCopy()
        {
            string[] files = System.IO.Directory.GetFiles(this.sourcePath);
            foreach (string s in files)
            {
                Console.WriteLine(s);
                string fileName = System.IO.Path.GetFileName(s);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                taskQueue.EnqueueTask(
                    delegate
                    {
                        try
                        {
                            Console.WriteLine(fileName);
                            Console.WriteLine(destFile);
                            System.IO.File.Copy(s, destFile);
                            Console.WriteLine("current proc id = " + Thread.CurrentThread.ManagedThreadId);
                            copyFileNumber++;
                        }
                        catch (SystemException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                );
            }
        }
    }
}
