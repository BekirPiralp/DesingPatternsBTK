using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new Log4NetLogger());
            customerManager.Save();

            CustomerManagerTests customerManagerTests = new CustomerManagerTests();
            customerManagerTests.SaveTest();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }


    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }

    class StubLogger : ILogger // boş logger
    {
        /** 
         * Singleton dessing start
         * */
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {

        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }

            return _stubLogger;
        }

        /**
         * Singleton dessing finish
         */

        public void Log()
        {

        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());

            Console.WriteLine("Customer manager test");
            customerManager.Save();
        }
    }
}
