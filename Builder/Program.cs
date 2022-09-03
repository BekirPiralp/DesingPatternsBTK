using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    /// <summary>
    /// Nesne örneği ortaya çıkarmayı hedefler
    /// if yazmak yerine nesneyi bu desenle çıkarmayı hedefler
    /// örnek hamburger nesnesi için
    /// vejeteryanlar için
    /// veya etsever için farklı olarak ortaya çıkarmak için kullanılır
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            ProductBuilder[] builders = { new NewCustomerProductBuilder(), new OldCustomerProductBuilder() };
            //director.GenerateProduct(builder); // yeni müşteri için

            //var model = builder.GetModel();

            foreach (var builder in builders)
            {
                director.GenerateProduct(builder); // yeni müşteri için

                var model = builder.GetModel();

                Console.WriteLine(model.id);
                Console.WriteLine(model.ProductName);
                Console.WriteLine(model.CategoryName);
                Console.WriteLine(model.DiscountedPrice);
                Console.WriteLine(model.DiscountApplied);
                Console.WriteLine(model.UnitPrice+"\n");
            }

            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    // daha önce alış veriş yapmış müşteri için ürün inşası
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            model.id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
