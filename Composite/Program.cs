using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee osman = new Employee {Name = "Osman" };
            Employee batu = new Employee { Name = "Batuhan" };

            osman.AddSubordinate(batu);

            Employee yaren = new Employee { Name = "Yaren" };
            osman.AddSubordinate(yaren);
            Employee fasil = new Employee { Name = "Fasıl" };
            batu.AddSubordinate(fasil);

            Console.WriteLine(osman.Name);
            foreach (Employee manager in osman)
            {
                Console.WriteLine("--- " + manager.Name);
                foreach (var employee in manager)
                {
                    
                    Console.WriteLine("------"  +employee.Name);
                  
                }

            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
         string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates=new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
