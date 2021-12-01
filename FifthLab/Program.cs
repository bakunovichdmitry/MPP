using System;
using System.Linq;
using System.Reflection;

namespace FifthLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom("C:\\Users\\37533\\Desktop\\MPP\\FifthLab\\MPP_lab1.dll");
            
            var types = assembly.GetTypes().Where(t => t.IsPublic).OrderBy(t => t.Namespace + t.Name);
            foreach (var type in types)
            {
                Console.Out.WriteLine(type.FullName);
            }
        }
    }
}
