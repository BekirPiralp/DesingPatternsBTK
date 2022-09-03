using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager._messageSender = new EmailSender();
            customerManager.UpdateCustomer();

            customerManager._messageSender = new SmsSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    //adınıda base e çeviririz
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        //public void SendSms()
        //{

        //}

        //public void SendEmail()
        //{

        //}
        // tek tek yapmak yerine sınıfı abstract yapar...

        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"-----------------------------\n\t{Title.ToUpper()}\n  {Text}\n-----------------------------\n{Title}";
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body} was sent via EmailSender");
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body} was sent via SmsSender");
        }
    }
    //...

    class CustomerManager
    {
        public MessageSenderBase _messageSender { get; set; }

        public CustomerManager()
        {

        }
        public void UpdateCustomer()
        {
            _messageSender.Send(new Body { Title = "Başlık",Text ="Deneme mesajıdır." });
            Console.WriteLine("Customer updated");
            Console.WriteLine("=============================");
        }
    }
}
