using System;

namespace ChangeOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Manager manager = new Manager();
           VicePresident vicePresident = new VicePresident();
           President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            Expense expense = new Expense { Detail="Traning",Amount=12};
            manager.HandleExpense(expense);
        }
        class Expense
        {
            public string Detail { get; set; }
            public int Amount { get; set; }
        }
        abstract class ExpenseHandlerBase
        {
            protected ExpenseHandlerBase Succesor;
            public abstract void HandleExpense(Expense expense);
            public void SetSuccessor(ExpenseHandlerBase successor)
            {
              Succesor = successor;
            }
        }
        class Manager : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {
                if (expense.Amount<=100)
                {
                    Console.WriteLine("Manager handled the expense");
                }
                else if (Succesor!=null)
                {
                    Succesor.HandleExpense(expense);
                }
            }
        }
        class VicePresident : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {

                if (expense.Amount> 100&& expense.Amount<=1000)
                {
                    Console.WriteLine("VicePresident handled the expense");
                }
                else if (Succesor != null)
                {
                    Succesor.HandleExpense(expense);
                }
            }
        }
        class President : ExpenseHandlerBase
        {
            public override void HandleExpense(Expense expense)
            {
                if (expense.Amount > 1000)
                {
                    Console.WriteLine("President handled the expense");
                }
            }
        }
    }
}
