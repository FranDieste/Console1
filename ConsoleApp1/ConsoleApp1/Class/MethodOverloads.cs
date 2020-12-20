using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
   public class MethodOverloads
    {
        public void Foo<T>(T obj) =>
             Console.WriteLine($"Foo<T>(T obj) ,obj Type:{obj.GetType().Name}");


        public void Foo(int x) =>
           Console.WriteLine($"Foo(int x)=>" + x.ToString());


        public void Foo<T1, T2>(T1 obj1, T2 obj2) =>
            Console.WriteLine($"Foo<T1,T2>(T1 obj1,T2 obj2);" + $"{obj1.GetType().Name} {obj2.GetType().Name}");

        public void Foo<T>(int obj1, T obj2) =>
        Console.WriteLine($"Foo<T>(int obj1, T obj2); obj1:{obj1} + {obj2.GetType().Name}");
        public void Bar<T>(T obj) => Foo(obj);


}
}
