using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Program
    {
        static void Main(string[] args)
        {

            IKernel kernerl = new StandardKernel();
            kernerl.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();


            ProductManager productManager = new ProductManager(kernerl.Get<IProductDal>());
            productManager.Save();

            productManager = new ProductManager(new NhProductDal());
            productManager.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    class ProductManager
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save();
        }
    }
}
