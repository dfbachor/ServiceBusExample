using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using ServiceBusCore.Integration;
using System.Diagnostics;
using System.Text;

namespace ConsumeServiceBusMessage.Messaging
{
    public class AzServiceBusConsumer : IAzServiceBusConsumer
    {
        private string connectionString = "Endpoint=sb://dfb-microservices-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QQfYF1ZfF3BNZGMYinmPX1JR2elaWvaob+ASbPUXZ9Q=";
        private readonly string subscriptionName = "getdfbTopic";
        private readonly string topic = "dfbTopic";
        private readonly IMessageBus _messageBus;
        private readonly IReceiverClient messageReceiverClient;

        public AzServiceBusConsumer(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            messageReceiverClient = new SubscriptionClient(connectionString, topic, subscriptionName);

        }
        public void Start()
        {
            var messageHandlerOptions = new MessageHandlerOptions(OnServiceBusException) { MaxConcurrentCalls = 4 };
            messageReceiverClient.RegisterMessageHandler(OnMessageReceived, messageHandlerOptions);
        }

        private Task OnMessageReceived(Message message, CancellationToken arg2)
        {

            var body = Encoding.UTF8.GetString(message.Body);//json from service bus

            //save order with status not paid
            // BasketCheckoutMessage basketCheckoutMessage = JsonConvert.DeserializeObject<BasketCheckoutMessage>(body);
            var dfb = body;
            Debug.WriteLine(dfb);
            return Task.CompletedTask;
        }


        private Task OnServiceBusException(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {

            return Task.CompletedTask;
        }

        public void Stop()
        {
        }
    }
}
