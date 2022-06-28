using System;
using System.Diagnostics.CodeAnalysis;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(2000, "blue", true);
            Car car2 = (Car)car1.Clone();
            if (car1.Equals(car2))
            {
                Console.WriteLine("eşit");
            }
            else
            {
                Console.WriteLine("eşit değil");
            }
        }
        public class Car : CarPrototype, IEquatable<Car> // İki classı karşılaştırabilmemiz için implement ettik
        {
            public int model { get; set; }
            public string color { get; set; }
            public bool state { get; set; }
            public Car(int _model, string _color, bool _state)
            {
                model = _model;
                color = _color;
                state = _state;
            }

            public override CarPrototype Clone()
            {
                return (Car)MemberwiseClone() as CarPrototype;//Nesnenin o anki klonu oluşturulur.
            }

            public bool Equals(Car other)
            {
                return
                      this.model == other.model &&
                      this.color == other.color &&
                      this.state == other.state;
            }
        }
        public abstract class CarPrototype
        {
            public abstract CarPrototype Clone();
        }
    }
}
