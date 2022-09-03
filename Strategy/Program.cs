using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SavedCredit();
            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SavedCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SavedCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();
        }
    }
}
