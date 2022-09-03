using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            const int newDiscount=30;
            CarBase personelCar = new PersonelCar {Make = "BMW",Model ="3.20", HirePrice = 25000 };
            var specialOffer = new SpecialOffer (personelCar);

            Console.WriteLine($"Concrate : {personelCar.HirePrice}");
            Console.WriteLine($"Special offer : {specialOffer.HirePrice}");

            Console.WriteLine($"İndirim yüzdesini değiştiriyoruz. %{newDiscount}");

            specialOffer.DiscountPerce = newDiscount;
            Console.WriteLine($"Special offer : {specialOffer.HirePrice}");

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    /*Presonel araç*/
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    /*Ticari araç*/
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    //Özel teklif
    class SpecialOffer:CarDecoratorBase
    {
        private readonly CarBase _carBase;

        public int DiscountPerce { get; set; } = 10; //indirim mictarı
        public SpecialOffer(CarBase carBase):base(carBase) 
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice * (100-DiscountPerce)/100; } set { } }
    }
}
