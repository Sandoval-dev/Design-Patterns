using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Authorized");
        }
    }

    internal interface IAuthorize
    {
       void CheckUser();
    }

    class CustomerManager
    {

        CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {

        }

        public void Save()
        {
            _concerns.caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.logging.Log();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttongConcernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public Authorize Authorize;

        public CrossCuttongConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
