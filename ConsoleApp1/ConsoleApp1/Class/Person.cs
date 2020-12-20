using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
    public  class Person
    {
        public Person(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get;}
        public string LastName { get;}

        public override string ToString() => $"{FirstName}{LastName}";

        public void WriteDescription()
        {
            int x = 0;

            int result = x / x;





        }
        
    }
}
