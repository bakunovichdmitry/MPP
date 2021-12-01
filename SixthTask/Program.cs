using System;

namespace SixthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer logBuffer = new LogBuffer();
            for (var i = 0; i < 100; i++)
            {
                logBuffer.Add(i.ToString());
            }
            logBuffer.Close();
        }
    }
}
