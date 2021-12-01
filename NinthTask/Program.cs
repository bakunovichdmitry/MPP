using System;

namespace NinthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }

            Console.Write("[");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.Write("]\n");
            Console.WriteLine(list.Count);

            list.Remove(1);
            Console.Write("[");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.Write("]\n");
            Console.WriteLine(list.Count);

            list.Clear();

            Console.Write("[");
            foreach (int element in list)
            {
                Console.Write(element + ",");
            }
            Console.Write("]\n");
            Console.WriteLine(list.Count);
        }
    }
}
