using ServiceBusCore.Integration;

namespace PublishMessageOnServiceBus.Messages
{
    public class ServiceBusMessage : IntegrationBaseMessage
    {
        public int Id { get; set; }
        public string? Message { get; set; }
    }
}
