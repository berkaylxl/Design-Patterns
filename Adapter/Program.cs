using System;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager =new ProductManager(new BLoggerAdapter());
            productManager.Add();
        }
        class ProductManager
        {
            private ILogger _logger;
            public ProductManager(ILogger logger)
            {
                _logger=logger;
            }
            public void Add()
            {
                _logger.Log("Loglama Tamamlandı");
            }
        }
        interface ILogger
        {
            void Log(string message);
        }

        class ALogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("A -> Log Completed");
            }
        }
        class BLogger //Bir tool olarak gelebilir.Dokunamadığımız bir class olarak düşünmeliyiz
        {
            //işlemler
            public void LogB(){
                Console.WriteLine("B -> Log Completed");
            }
        }
        class BLoggerAdapter : ILogger
        {
            public void Log(string message)
            {
                BLogger blogger = new BLogger();
                blogger.LogB();
            }
        }
    }
}
