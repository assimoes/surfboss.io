using RabbitMQ.Client.Events;

namespace surfboss.io.bus.interfaces
{
    public interface IQueueHandler
    {
        void Handler(object sender, BasicDeliverEventArgs e);
    }
}