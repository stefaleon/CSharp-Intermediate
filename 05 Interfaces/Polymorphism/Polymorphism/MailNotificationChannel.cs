using System;

namespace Polymorphism
{
    public class MailNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("MailNotificationChannel Send version called: Sending mail...");
        }
    }


}
