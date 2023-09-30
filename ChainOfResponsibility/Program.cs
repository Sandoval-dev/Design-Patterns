using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager=new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense=new Expense { Detail="Traning", Amount=120};
            manager.HandleExpence(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpence(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase succesor)
        {
            Successor = succesor;
        }

    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpence(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if(Successor!=null)
            {
                Successor.HandleExpence(expense);
            }
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpence(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpence(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpence(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpence(expense);
            }
        }
    }
}
