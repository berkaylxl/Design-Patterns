using System;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
        }
        class ProductManager
        {

        }

        interface ILogger
        {
            void Log(string message);
        }

        class ALogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("A -> Log İşlemi Tamamlandı");
            }
        }
    }
}
