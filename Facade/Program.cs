using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
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
            Console.WriteLine("Logged!");
        } 
    }

    internal interface ILogging
    {
        void Log();
    }

    class Chaching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Chached!");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked!");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {
        //private ILogging _logging;
        //private ICaching _caching;
        //private IAuthorize _authorize;

        //public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
        //{
        //    _logging = logging;
        //    _caching = caching;
        //    _authorize = authorize;
        //}

        //public void Save()
        //{
        //    _authorize.CheckUser();
        //    _logging.Log();
        //    _caching.Cache();
        //    Console.WriteLine("Saved");
        //}
        CrossCuttongConcernsFacede _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacede();
        }
        public void Save()
        {
            _concerns.Authorize.CheckUser();
            _concerns.Validation.Validate();
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttongConcernsFacede
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;

        public CrossCuttongConcernsFacede()
        {
            Logging = new Logging();
            Caching = new Chaching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
