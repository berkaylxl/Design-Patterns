using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Employee employee1 =new Employee { Name="Berkay"};
           Employee employee2 = new Employee { Name = "Ahmet" };
           Employee employee3 = new Employee { Name = "Murat" };
           employee1.AddSubOrdinate(employee2);
           employee2.AddSubOrdinate(employee3);
            foreach (var manager in employee1)
            {
                Console.WriteLine(employee1.Name);
                Console.WriteLine(" "+manager.Name);
                foreach (var person in employee2)
                {
                    Console.WriteLine("  "+ person.Name);
                }
            }
        }
        interface IPerson
        {
            string Name { get; }
        }

        class Employee : IPerson,IEnumerable<IPerson>
        {
            List<IPerson> _subOrdinates =new List<IPerson>();
            public void AddSubOrdinate(IPerson person)
            {
                _subOrdinates.Add(person);
            }
            public void RemoveSubOrdinate (IPerson person)
            {
                _subOrdinates.Remove(person);
            }
            public IPerson  GetSubOrdinate(int index)
            {
                return _subOrdinates[index];
            }
            public string Name { get; set; }

            public IEnumerator<IPerson> GetEnumerator()
            {
                foreach (var subordinate in _subOrdinates)
                {
                    yield return subordinate;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
              return GetEnumerator();
            }
        }
    }


}
