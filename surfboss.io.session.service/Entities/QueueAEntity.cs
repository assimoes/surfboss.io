using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surfboss.io.service.Entities
{
    public class QueueAEntity
    {
        public Guid Version { get { return _version; } }
        Guid _version;
        public QueueAEntity()
        {
            _version = Guid.NewGuid();
        }

        public string Name { get; set; }

    }
}
