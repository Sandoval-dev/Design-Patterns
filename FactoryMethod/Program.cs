using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }

    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {

            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {

            return new AdLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Edlogger");
        }
    }

    public class AdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Adlogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = new LoggerFactory();
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = new LoggerFactory2().CreateLogger();
            logger.Log();
        }
    }
}
