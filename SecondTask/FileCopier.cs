using System;
using System.IO;
using System.Threading;
using FirstTask;

namespace SecondTask
{
    class FileCopier
    {
        private string sourcePath;
        private string targetPath;

        TaskQueue taskQueue = new TaskQueue(3);
        public FileCopier(
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
            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Source path don't exists");
                Environment.Exit(0);
            }

        }
        public void CheckTargetDirectory()
        {
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
        }

        public void Start()
        {
            CopyDirectories();
            CopyFiles();
            
            taskQueue.Finish();
        }

        public void CopyDirectories()
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void CopyFiles()
        {
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                taskQueue.EnqueueTask(
                    delegate
                    {
                        try
                        {
                            File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
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