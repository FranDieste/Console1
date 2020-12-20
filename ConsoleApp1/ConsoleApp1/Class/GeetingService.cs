using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
    public class GeetingService : IGeetingService
    {
        public string Greet(string name) => $"Hello,{name}";
       
    }
}
