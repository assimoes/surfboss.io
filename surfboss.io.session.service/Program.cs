using surfboss.io.bus;
using surfboss.io.bus.interfaces;
using System;

namespace surfboss.io.service
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Configure();
            
            var _channel = Startup.Listener.Channel;
            
          

            foreach (var _queue in Startup.Queues)
            {
                var _handler = (Activator.CreateInstance(_queue.Value, _channel));
                Subscription.Subscribe(_channel, _queue.Key, (_handler as IQueueHandler).Handler);
            }

        }
    }
}
