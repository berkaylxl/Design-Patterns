using System;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.Save();
         
        }
        abstract class CreditCalculatorBase
        {
            public abstract void Calculate();
        }
        class Before2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine(" Credit calculated using before 2010 ");
            }
        }
        class After2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine("Credit calculated using before 2010");
            }
        }

        class CustomerManager
        {
            public CreditCalculatorBase CreditCalculatorBase { get; set; }
            public void Save()
            {
                CreditCalculatorBase.Calculate();
                Console.WriteLine("Saved");
            }
        }

    }
}
