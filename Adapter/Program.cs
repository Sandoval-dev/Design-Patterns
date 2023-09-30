using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EdLogger());
            productManager.Save();
            Console.ReadLine();

        }
    }

    public class ProductManager
    {
        ILogger _logger;
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Save");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    public class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, " + message);
        }
    }

    //Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net, " + message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
