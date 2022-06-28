using System;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EmailSender();
            customerManager.AddCustomer();
           
        }
       public abstract class MessageBase
        {
            public abstract void Send(Body body);
            
        }
        public class Body
        {
            public string Title { get; set; }
            public string Text { get; set; }
        }
        class EmailSender : MessageBase
        {
            public override void Send(Body body)
            {
                Console.WriteLine("{0} was sent via Email", body.Title);
            }
        }
        class SmsSender : MessageBase
        {
            public override void Send(Body body)
            {
                Console.WriteLine($"{0} was sent via Sms", body.Title);
            }
        }
        class CustomerManager
        {
            public MessageBase MessageSenderBase { get; set; }

            public void AddCustomer()
            {
                MessageSenderBase.Send(new Body { Title = "Added Customer" });
            }
        }
    }
}

   
