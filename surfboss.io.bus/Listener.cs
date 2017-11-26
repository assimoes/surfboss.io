using RabbitMQ.Client;

namespace surfboss.io.bus
{
    public class Listener
    {
        IConnection _connection;
        IModel _channel;

        public Listener(string username, string pwd, string virtualHost, string hostName)
        {
            ConnectionFactory _factory = new ConnectionFactory();
            _factory.UserName = username;
            _factory.Password = pwd;
            _factory.VirtualHost = virtualHost;
            _factory.HostName = hostName;

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            
        }
        
        public IModel Channel { get { return _channel; } }


    }
}
