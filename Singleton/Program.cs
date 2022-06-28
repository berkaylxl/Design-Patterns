using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var productInstance =ProductService.CreateInstance();
            productInstance.TestMethod();
        }
        class ProductService
        {
            private static ProductService _product;
            public static object LockObject = new object();
            private ProductService()
            {
                
            }
            public static ProductService CreateInstance()
            {
                lock (LockObject) // Başka thread işlemleri durdurulur.
                {
                    if (_product == null)
                    {
                        _product = new ProductService();
                        Console.WriteLine("Instance Oluşturuldu");
                        return _product;
                    }
                    else
                    {
                        return _product;
                    } 
                }
            }
            public void TestMethod()
            {
                Console.WriteLine("Test Methodu Çalıştırıldı...");
            }
        }
    }
}
