using System;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================================");
            Console.WriteLine("The SmsNotificationChannel and MailNotificationChannel");
            Console.WriteLine("classes implement the INotificationChannel interface.\n");
            Console.WriteLine("While iterating on the channel list at runtime,");
            Console.WriteLine("different versions of the Send method are called.\n  ");
            Console.WriteLine("The interface provides a polymorphic behavior,");
            Console.WriteLine("with Send functionality depending on the channel type");
            Console.WriteLine("=======================================================");

            Console.ForegroundColor = ConsoleColor.Green;
            var notifier = new Notifier();
            notifier.RegisterNotificationChannel(new SmsNotificationChannel());
            notifier.RegisterNotificationChannel(new MailNotificationChannel());
            notifier.Notify();
        }
    }


}
