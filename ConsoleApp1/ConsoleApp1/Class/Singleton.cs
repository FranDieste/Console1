using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
    internal class Singleton
    {
        private static Singleton _singleton;

        private Singleton()
        {

        }

        public static Singleton MySingleton { get => _singleton ?? (_singleton = new Singleton()); }


        internal string GetDescription(string description ="Default description") {


            return description;

        }
        
    }
}
