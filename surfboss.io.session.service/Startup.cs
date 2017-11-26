using RabbitMQ.Client;
using surfboss.io.bus;
using surfboss.io.service.CommandHandlers;
using surfboss.io.service.EventHandlers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace surfboss.io.service
{
    public static class Startup
    {
        static Dictionary<string, Type> _queues;
        static Listener _listener;

        public static void Configure()
        {
            RegisterHandler(typeof(SessionCreateCommandHandler));
            RegisterHandler(typeof(SessionUpdateCommandHandler));
            RegisterHandler(typeof(SessionCreatedEventHandler));
            RegisterHandler(typeof(SessionUpdatedEventHandler));

            CreateExchangeAndQueues();
        }

        public static Dictionary<string, Type> Queues { get { return _queues; } }


        private static void RegisterHandler(Type handler)
        {
            var _suffixPattern = "(CommandHandler|EventHandler)";
            var _capitalized = @"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])";

            var r = new Regex(_suffixPattern);
            var _queuename = r.Replace(handler.Name, "");
            r = new Regex(_capitalized, RegexOptions.IgnorePatternWhitespace);
            _queuename = r.Replace(_queuename, ":");

            if (_queues == null) _queues = new Dictionary<string, Type>();

            _queues.Add(_queuename.ToLower(), handler);
        }

        private static void CreateExchangeAndQueues()
        {
            _listener = new Listener("microsvc", "test", "/", "localhost");
            var _channel = _listener.Channel;

            _channel.ExchangeDeclare("surfboss.io.session.service", ExchangeType.Topic, true, false, null);

            foreach (var _queue in Queues)
            {
                _channel.QueueDeclare(_queue.Key, true, false, false, null);
                _channel.QueueBind(_queue.Key, "surfboss.io.session.service", _queue.Key, null);
            }
        }

        public static Listener Listener { get { return _listener; } }
    }
}

