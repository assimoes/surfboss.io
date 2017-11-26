using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surfboss.io.service.Events
{
    public class EventUpdate<T>
    {
        public string Type { get; set; }
        public T Payload { get; set; }
    }
}
