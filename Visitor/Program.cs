using System;
using System.Collections.Generic;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Manager manager = new Manager { Name="Berkay",Salary=10000};
           Manager manager2 = new Manager { Name = "Hasan", Salary = 8000 };

            Worker worker1 = new Worker { Name="Murat", Salary = 5000 };
            Worker worker2 = new Worker { Name = "Ahmet", Salary = 4000 };

            manager.SubOrdinates.Add(manager2);
            
            
        }
        class OrganisationStructure
        {
            public EmployeeBase Employee;
            public OrganisationStructure(EmployeeBase firstEmployee)
            {
                Employee = firstEmployee;
            }
            public void Accept(VisitorBase visitorBase)
            {
                Employee.Accept(visitorBase);
            }
        }
        abstract class EmployeeBase
        {
            public abstract void Accept(VisitorBase visitor);
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }
        class Manager : EmployeeBase
        {
            public Manager()
            {
                SubOrdinates=new List<EmployeeBase>();
            }
            public List<EmployeeBase> SubOrdinates { get; set; }
            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
                foreach (var employee in SubOrdinates)
                {
                    employee.Accept(visitor);
                }
            }
        }
        class Worker : EmployeeBase
        {
            public override void Accept(VisitorBase visitor)
            {
                visitor.Visit(this);
            }
        }
       abstract  class VisitorBase
        {
            public abstract void Visit(Worker worker);
            public abstract void Visit(Manager manager);
        }
        class PayrolVisitor : VisitorBase
        {
            public override void Visit(Worker worker)
            {
                Console.WriteLine(" {0} paid {1} ",worker.Name,worker.Salary);
            }

            public override void Visit(Manager manager)
            {
                Console.WriteLine(" {0} paid {1} ", manager.Name, manager.Salary);
            }
        }
        class Payrise : VisitorBase
        {
            public override void Visit(Worker worker)
            {
                Console.WriteLine(" {0} salary incrased to {1} ", worker.Name, worker.Salary*(decimal)1.1);
            }

            public override void Visit(Manager manager)
            {
                Console.WriteLine(" {0} salary incrased to {1} ", manager.Name, manager.Salary * (decimal)1.2);
            }
        }

    }
}
