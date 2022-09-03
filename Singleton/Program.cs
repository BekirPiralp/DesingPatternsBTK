using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    //class CustomerManager
    //{
    //    private static CustomerManager _customerManager;
    //    private CustomerManager() { }

    //    public static CustomerManager CreateAsSingleton()
    //    {
    //        // ?? eğer null sa
    //        return _customerManager ??(_customerManager = new CustomerManager());
    //    }

    //    public override string ToString()
    //    {
    //        //return base.ToString();
    //        return "Customer manager a hoş geldiniz";
    //    }

    //    public void Save()
    //    {
    //        Console.WriteLine(this.ToString() + "Saved!!");
    //    }
    //}

    //Aynı anda iki kullanıcı isterse çok az bir durumda olsa nesne iki defa oluşturulur
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager() { }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (isNull())
                    _customerManager = new CustomerManager();
            }

            return _customerManager;
        }

        public override string ToString()
        {
            return "Customer manager a hoş geldiniz";
        }

        public void Save()
        {
            Console.WriteLine(this.ToString() + "Saved!!");
        }

        //bunu ben ekliyorum ;)
        /// <summary>
        /// Nesne eğerki null ise true değilse false döndürür
        /// </summary>
        /// <returns></returns>
        static bool isNull()
        {
            return _customerManager == null ? true : false;
        }
    }
}
