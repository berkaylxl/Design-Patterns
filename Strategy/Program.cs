using System;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomerManager customerManager = new CustomerManager();
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
                CreditCalculatorBase = StrategyControl("bank");
                CreditCalculatorBase.Calculate();
                Console.WriteLine("Saved");
            } 
            private CreditCalculatorBase StrategyControl(string strategy)
            {
                //örnek strategy bloğu
                if (strategy == "bank")
                {
                    return new Before2010CreditCalculator();
                    
                }
                else
                {
                    return new After2010CreditCalculator();
                }
            }
        }

        

    }
}
