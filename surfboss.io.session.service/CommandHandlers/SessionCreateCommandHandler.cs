using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using surfboss.io.bus.interfaces;
using surfboss.io.service.Entities;
using surfboss.io.service.Events;
using System;

namespace surfboss.io.service.CommandHandlers
{
    public class SessionCreateCommandHandler : IQueueHandler
    {
        private IModel _channel;

        public SessionCreateCommandHandler(IModel channel)
        {
            _channel = channel;
        }

        public void Handler(object sender, BasicDeliverEventArgs e)
        {
            var _body = e.Body;
            var _content = System.Text.Encoding.UTF8.GetString(_body);
            var _jsonResult = JsonConvert.DeserializeObject<EventUpdate<QueueAEntity>>(_content);
            Console.WriteLine(_jsonResult);
            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
