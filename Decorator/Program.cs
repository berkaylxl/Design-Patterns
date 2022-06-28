using System;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Brand = "BMW", Model = "M30", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            Console.WriteLine("Hire Price:"+personelCar.HirePrice);
            Console.WriteLine("Special Offer: "+specialOffer.HirePrice);
        }
    
        abstract class CarBase
        {
            public abstract string Brand { get; set; }
            public abstract string  Model { get; set; }
            public abstract decimal  HirePrice { get; set; }
        }

        class PersonelCar : CarBase
        {
            public override string Brand { get ; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        class CommercialCar : CarBase
        {
            public override string Brand { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        abstract class CarDecoratorBase : CarBase
        {
            private CarBase _carBase;
            protected CarDecoratorBase(CarBase carBase)
            {
                _carBase = carBase;
            }
        }
        class SpecialOffer : CarDecoratorBase
        {
            private readonly CarBase _carBase;
            public SpecialOffer(CarBase carBase) : base(carBase)
            {
                _carBase = carBase;
            }

            public override string Brand { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice
            {
                get
                {
                    return _carBase.HirePrice * 90 / 100;
                }
                set { }
            }
        }



    }
    

}
