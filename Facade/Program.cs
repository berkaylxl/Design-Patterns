using System;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomerManager customerManager = new CustomerManager();
           customerManager.Save();
        }
        interface ICaching
        {
            void Cache();
        }
        interface IAuthorize
        {
            void CheckUser();
        }
        class Caching:ICaching
        {
            public void Cache()
            {
                Console.WriteLine("Cache işlemi Başarılı");
            }
        }
        class Authorize:IAuthorize
        {
            public void CheckUser()
            {
                Console.WriteLine("Başarılı");
            }
        }
        class CustomerManager
        {
            CCSFacade ccsFacade;
            public void Save()
            {
                ccsFacade = new CCSFacade();
                ccsFacade.Authorize.CheckUser();
                ccsFacade.Caching.Cache();
            }

        }
        class CCSFacade
        {
            public ICaching Caching;
            public IAuthorize Authorize;
            public CCSFacade()
            {
                Caching = new Caching();
                Authorize = new Authorize();

            }
        }
    }
}
