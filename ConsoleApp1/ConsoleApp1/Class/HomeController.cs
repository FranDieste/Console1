
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
   public class HomeController
    {
        private readonly IGeetingService _gettingService;
        public HomeController(IGeetingService gettingService)
        {
            _gettingService = gettingService?? throw new ArgumentNullException(nameof(gettingService));
        }

        public string Hello(string name)=>  _gettingService.Greet(name);


        
    }
}
