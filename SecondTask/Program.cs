using System;
using System.Threading;


namespace SecondTask
{
    class Program
    {
        delegate void Operation(string sourceFieName, string destFileName);
        static void Main(string[] args) 
        {
            FileСopier fileСopier = new FileСopier();
            fileСopier.StartCopy();
        }
    }
}
