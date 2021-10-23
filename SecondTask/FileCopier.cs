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

        public static int copyFileNumber = 0;

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
            if (!System.IO.Directory.Exists(sourcePath))
            {
                Console.WriteLine("Source path don't exists");
                System.Environment.Exit(0);
            }

        }
        public void CheckTargetDirectory()
        {
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
        }

        public void StartCopy()
        {
            CopyDirectories();
            CopyFiles();
            taskQueue.Finish();
            Console.WriteLine(copyFileNumber);
        }

        public void CopyDirectories()
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
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