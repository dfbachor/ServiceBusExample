using ServiceBusCore.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusCore.Messages
{
    public class ServiceBusMessage : IntegrationBaseMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
