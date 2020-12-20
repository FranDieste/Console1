using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
   public static class StringExtension
    {
        public static int GetWordCount(this string s) => s.Split().Length;
    }
}
