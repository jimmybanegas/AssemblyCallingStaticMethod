using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Path de dll: ");

            var path = Console.ReadLine();

            var dll = Assembly.LoadFile(path);


            var list = dll.ExportedTypes;


            foreach (var tipo in list)
            {

                var methods = tipo.GetMethods();

                foreach (var m in methods)
                {
                    if (m.Name == "Ejecutar")
                    {
                        var method = tipo.GetMethod("Ejecutar",BindingFlags.Public|BindingFlags.Static);

                        method.Invoke(null,null); // assuming it doesn't take parameters
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
