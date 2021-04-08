using System;
using System.Reflection;

namespace HwReflectionAtribute
{
    class Program
    {
        static void ReflectionTest(object obj)
        {
            var type = obj.GetType();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Public);


            foreach (var prop in properties)// смотрим все св-ва чтоб узнать тип и имя
            {
                Console.WriteLine($"Имя св-ва:{prop.Name}\t\tтип св-ва:{prop.PropertyType}");
            }

            var propInfo = type.GetProperty("Helth");
            propInfo.SetValue(obj, -100 );

            var method = type.GetMethod("CheckStatus");


            Console.WriteLine(method.Invoke(obj, null));
            
        }


        static void Main(string[] args)
        {
            // просто для наглядности 1 часть
            Tank tank1 = new Tank(1000);

            tank1.GetDamage(25);
            Console.WriteLine(tank1.CheckStatus());

            tank1.GetDamage(99);
            Console.WriteLine(tank1.CheckStatus());

            // просто для наглядности 2 часть 
            Console.WriteLine("+++++++++++++");


            ReflectionTest(tank1);

        }
    }
}
