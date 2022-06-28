using System;
using System.Collections.Generic;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();
        }
        class ProductManager
        {
            List<Observer> _observers =new List<Observer>();

            public void UpdatePrice()
            {
                Console.WriteLine("Produc price changed");
                Notify();
            }
            public void Attach(Observer observer)
            {
                _observers.Add(observer);
            } 
            public void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }
            private void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update();
                }
            }
        }
        abstract class Observer
        {
            public abstract void Update();

        }

        class CustomerObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message To Customer : Price Changed");
            }
        }
        class EmployeeObserver : Observer
        {
            public override void Update()
            {
                Console.WriteLine("Message To Employee : Price Changed");
            }
        }
    }
}
