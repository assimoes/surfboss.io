using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using surfboss.io.bus.interfaces;
using System;

namespace surfboss.io.bus
{
    public class Subscription: ISurfbossSubscription
    {

        public static void Subscribe(IModel channel, string _queue, EventHandler<BasicDeliverEventArgs> _handler)
        {
            channel.BasicQos(0, 1, false);
            EventingBasicConsumer _consumer = new EventingBasicConsumer(channel);
            _consumer.Received += _handler;
            channel.BasicConsume(_queue, false, _consumer);
        }
    }
}
