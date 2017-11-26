using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using surfboss.io.bus.interfaces;
using surfboss.io.service.Entities;
using surfboss.io.service.Events;


namespace surfboss.io.service.EventHandlers
{
    public class SessionUpdatedEventHandler: IQueueHandler
    {
        private IModel _channel;
        public SessionUpdatedEventHandler(IModel channel)
        {
            _channel = channel;
        }

        public void Handler(object sender, BasicDeliverEventArgs e)
        {

            var _body = e.Body;
            var _content = System.Text.Encoding.UTF8.GetString(_body);
            var _jsonResult = JsonConvert.DeserializeObject<EventUpdate<QueueAEntity>>(_content);

            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
