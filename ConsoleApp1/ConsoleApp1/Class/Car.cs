using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
  public  class Car
    {
        private string _description;
        private uint _nWheels;

        public delegate string GetAString(string str1);
        public delegate void GetAStringWithoutParam();

        public enum Color
        {
            Red,
            Green,
            Blue  
        }

        public Car()
        {

        }

        public Car(string description, uint nWheels)
        {

            Console.WriteLine("Constructor with two param");
            _description = description;
            _nWheels = nWheels;
        }
        public Car(string description) : this(description, 4)
        {
            Console.WriteLine("Constructor with one param");
        }

        public void getDescription(GetAString methodDescription,string color)
        {
                      
            var mycolorDescription =   methodDescription(color);

            Console.WriteLine($"My color is {mycolorDescription}");
        }

        public string GetColorDescription(string color)
        {
            return $"My color is {color}";
        }

        //Ejecucion de un metodo utilizando Func<out,int> funciona como u delegado
        public void PrintColor(Func<string,string> action,string color)
        {
          Console.WriteLine(action(color));
        }

    }
}
