using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager { Name = "Osman", Salary = 25000 };
            Manager manager2 = new Manager { Name = "Batuhan", Salary = 14000 };
            Worker worker = new Worker { Name = "Ali", Salary = 10000 };

            manager.subOrdinates.Add(manager2);
            manager2.subOrdinates.Add(worker);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(manager);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);

            Console.ReadLine();

        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
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
            subOrdinates=new List<EmployeeBase>();
        }
        public List<EmployeeBase> subOrdinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in subOrdinates)
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

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("worker paid");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("Manager paid");
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("Worker salary increased");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("Manager salary increased");
        }
    }
}
