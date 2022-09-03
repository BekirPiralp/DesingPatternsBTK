using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ayır();
            CreditBase manager = new CreditManagerProxy();
            DateTime time = DateTime.Now;
            Console.WriteLine("Proxy: ");
            Console.WriteLine(manager.Caculate());
            Console.WriteLine(manager.Caculate());
            Console.WriteLine(manager.Caculate());
            Console.WriteLine($"Geçen zaman = {(DateTime.Now - time).TotalSeconds} saniye");
            ayır();
            manager = new CreditManager();
            time = DateTime.Now;
            Console.WriteLine("Normal: ");
            Console.WriteLine(manager.Caculate());
            Console.WriteLine(manager.Caculate());
            Console.WriteLine(manager.Caculate());
            Console.WriteLine($"Geçen zaman = {(DateTime.Now - time).TotalSeconds} saniye");
            ayır();

            Console.ReadLine();
        }

        private static void ayır()
        {
            Console.WriteLine("--------------------------------------------------------");
        }

    }

    abstract class CreditBase
    {
        public abstract int Caculate();
    }

    class CreditManager : CreditBase
    {
        public override int Caculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    /**
     * Boş yere aynı işi yaparken tekrar süre harcamasındiye bir proxy oluşturuyoruz
     */
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Caculate()
        {
            if(_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Caculate();
            }
            return _cachedValue;
        }
    }
}
