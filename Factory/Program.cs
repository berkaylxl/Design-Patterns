using System;

namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarFactory carfactory =new CarFactory();
            ICar car = carfactory.CreateCarInstance(CarType.Audi);
            car.GetColor();
            Console.ReadLine();

            
        }
        public enum CarType
        {
            Bmw=1,
            Audi=2        }

        public interface ICar
        {
            void GetColor();
            void GetModel();
        }

        public class Bmw : ICar
        {
            public void GetColor()
            {
                Console.WriteLine("BMW aracının renk bilgisi");
            }

            public void GetModel()
            {
                Console.WriteLine("BMW aracının renk bilgisi model");
            }
        }
        public class Audi : ICar
        {
            public void GetColor()
            {
                Console.WriteLine("Audi aracının renk bilgisi");
            }

            public void GetModel()
            {
                Console.WriteLine("Audi aracının modeli");
            }
        }

        public class CarFactory : IFactory
        {
            public ICar CreateCarInstance(CarType type)
            {
                ICar _car = null;
               switch (type)
                {
                    case CarType.Bmw:
                        Console.WriteLine("Bmw instance oluşturuldu");
                        return new Bmw();
                    case CarType.Audi:
                        Console.WriteLine("Audi instance oluşturuldu");
                        return new Audi();
                        break;
                }
                return _car;
            }
        }
        public interface IFactory {

            public ICar CreateCarInstance(CarType type);
        }


          
    }
}
