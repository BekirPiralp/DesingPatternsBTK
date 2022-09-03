using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer 
            { FirstName = "Bekir", LastName = "PİRALP", City = "Adana", Id = 1 };
            
            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Recep Şaban";
            customer2.Id = 2;

            Console.WriteLine(customer1.FirstName +" "+ customer1.LastName.ToUpper());
            Console.WriteLine(customer2.FirstName +" "+ customer2.LastName.ToUpper());

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employe : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
