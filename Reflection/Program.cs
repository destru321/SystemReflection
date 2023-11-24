using System;
using System.Reflection;

namespace Reflection
{
    public class Reflection
    {
        private Type Type;
        private string? FullName { get; set; }
        private string? Name { get; set; }
        private int MethodCount { get; set; }
        private MethodInfo[] Methods { get; set; }

        Reflection(Type _type)
        {
            Type = _type;

            // Pobranie informacji o typie z uzyciem System.Reflection
            FullName = Type.FullName;
            Name = Type.Name;
            Methods = Type.GetMethods();
            MethodCount = Methods.Length;
        }

        public void DisplayInfo()
        {

            //Wyświetlenie informacji o typie
            Console.WriteLine($"Name - {Name}");
            Console.WriteLine($"Fullname - {FullName}");
            Console.WriteLine($"MethodCount - {MethodCount}");
            Console.WriteLine("Methods:");
            foreach(var method in Methods)
            {
                Console.Write($"Name - {method.Name}, type - {method.ReturnType.Name}, ");
                ParameterInfo[] Params = method.GetParameters();
                Console.Write("Parametry: ");
                foreach(var param in Params)
                {
                    Console.Write($"Name - {param.Name}, type - {param.ParameterType.Name} / ");
                }
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------");
            }
        }

        static void Main()
        {
            Type type = typeof(bool);
            Reflection instance = new Reflection(type);
            instance.DisplayInfo();
        }

    }
}