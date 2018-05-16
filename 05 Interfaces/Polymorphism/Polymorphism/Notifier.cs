using System.Collections.Generic;

namespace Polymorphism
{
    public class Notifier
    {
        private readonly IList<INotificationChannel> 
            _notificationChannels = new List<INotificationChannel>();
        // initialized directly upon declaration, could as well be done with a constructor


        public void Notify()
        // main method, sends messages through all available channels
        {
            foreach (var channel in _notificationChannels)
            {
                channel.Send(new Message());
            }
        }
                
        public void RegisterNotificationChannel(INotificationChannel channel)
        // a public method to provide access to the _notificationChannels private field 
        {
            _notificationChannels.Add(channel);
        }

    }
}
