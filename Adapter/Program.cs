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
            ProductManager product = new ProductManager(new EdLogger());
            product.Save();

            Console.WriteLine("---------------------------------------------------------------------" +
                "\nAdapter sayesinde hazır gelen Log4Net sınıfı Ilogger gibi yapıp." +
                "\nSOLİD'e uyarak ve bağımlılıkğı kaldırarak kullandık..." +
                "\n---------------------------------------------------------------------");
            product = new ProductManager(new Log4NetAdapter());
            product.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Veri tabanına kaydedildi. (Saved)");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }

    //Nugget den indirildiğini var sayıyoruz
    //ve içerisine dokunamadığımızı var sayıyoruz
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4Net, {0}", message);
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
