using surfboss.io.bus.interfaces;

namespace surfboss.io.bus
{
    public class Queue<T> : ISurfbossQueue
    {
        private string _name = string.Empty;

        public Queue()
        {
            _name = typeof(T).Name;
        }

        public string Name { get { return _name; } }
    }
}
