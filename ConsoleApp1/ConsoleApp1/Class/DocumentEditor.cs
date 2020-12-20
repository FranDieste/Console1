using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Class
{
  public  class DocumentEditor
    {
        public int Age { get; set; } = 42;

        private string address;
        public string Address { get => address; }

        public static readonly int s_maxDocuments;//Solo se pueden inicializar en el constructor
        static DocumentEditor()
        {
            s_maxDocuments = GetMaxDocuments();

            
            
        }


        public void SetAddress(string streat)
        {
           
           address  = streat;
        }

        private static int GetMaxDocuments()
        {
            const int maxDocuments = 10;

            return maxDocuments;
        }


        public void viewParamsArray(params int[] intArray)
        {
            foreach (var item in intArray)
            {
                Console.WriteLine("The current element of intArray is -->" + item);
            }
        }



    }
}
