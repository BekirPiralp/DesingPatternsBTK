using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    //Hiyerarşik nesne oluşturma olarak düşünebiliriz. Adı üstünde sorumluluk zinciri tasarım deseni
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense { Detail = "Training eğitim", Amount = 98 };
            Expense expense2 = new Expense { Detail = "Eğitim", Amount = 150 };
            Expense expense3 = new Expense { Detail = "EĞİTİM", Amount = 1500 };

            ayır();
            manager.HandleExpense(expense);
            ayır();
            manager.HandleExpense(expense2);
            ayır();
            manager.HandleExpense(expense3);
            ayır();

            Console.ReadLine();

            void ayır()
            {
                Console.WriteLine("----------------------------------------");
            }
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    //harcama kontrol ana
    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor; //üst
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    //müdür için
    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Manager handled the expense! \nDetail: {expense.Detail}\nAmount: {expense.Amount}");
            }else
            {
                if (this.Successor != null)
                {
                    Successor.HandleExpense(expense);
                }
                else
                    Console.WriteLine("Successor not found!");
            }

        }
    }

    //Başkan yardımcısı için
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"VicePresident handled the expense! \nDetail: {expense.Detail}\nAmount: {expense.Amount}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (this.Successor != null)
                {
                    Successor.HandleExpense(expense);
                }
                else
                    Console.WriteLine("Successor not found!");
            }
        }
    }

    //Başkan için
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"President handled the expense! \nDetail: {expense.Detail}\nAmount: {expense.Amount}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (this.Successor != null)
                {
                    Successor.HandleExpense(expense);
                }
                else
                    Console.WriteLine("");
            }
        }
    }
}
