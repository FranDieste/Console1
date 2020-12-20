using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
   public class Racer
    {
        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}

        public string Country { get;}

        public int Wins { get;}

        public Racer(int id,string firstName,string lastName,string country):this(id,firstName,lastName,country, wins: 0)
        {

        }

        public Racer(int id, string firstName, string lastName, string country,int wins)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }
    }
}
