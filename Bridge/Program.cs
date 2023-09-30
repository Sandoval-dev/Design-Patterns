using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }

        public abstract void Send(Body body);

    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }

    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("Sms Sender -> " + body.Title);
        }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("Email Sender -> " + body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Send(new Body {Title= "About the lesson"});
            Console.WriteLine("Customer updated");
        }

    }
}
