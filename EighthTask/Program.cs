using System;
using System.Linq;
using System.Reflection;
using ExportAtr;

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(
                Assembly.GetExecutingAssembly().Location
            );

            var types = assembly.GetTypes().Where(t => t.IsPublic).OrderBy(type => type.Namespace + type.FullName);
            foreach (var type in types)
            {
                if (Attribute.GetCustomAttribute(type, typeof(ExportClass)) != null)
                {
                    Console.WriteLine(type.FullName);
                }
            }

        }
    }
}

namespace Birds
{
    [ExportClass]
    public class Hummingbird
    { }

    [ExportClass]
    class Robin
    { }
}

namespace Pets
{
    [ExportClass]
    public class Dog
    { }

    public class Cat
    { }
}