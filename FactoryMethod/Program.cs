using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();

            customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    /* Loglama fabrikası*/
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            //İş geliştirip ona göre fabrikanın sonuç döndürmesi sağlanıyor.
            return new BpLogger();
        }
        
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
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

    public class BpLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with BpLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _factory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _factory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");

            //ILoggerFactory factory = new LoggerFactory();
            ILogger logger = _factory.CreateLogger();

            logger.Log();
        }
    }
}
