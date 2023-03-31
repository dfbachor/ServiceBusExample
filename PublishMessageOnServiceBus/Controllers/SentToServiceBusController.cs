using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublishMessageOnServiceBus.Messages;
using ServiceBusCore.Integration;


namespace PublishMessageOnServiceBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentToServiceBusController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public SentToServiceBusController(IMessageBus messageBus) 
        {
            _messageBus = messageBus;
        }


        [HttpGet("PostToServiceBus/{message}")]
        public ActionResult<string> PostToServiceBus(string message)
        {
            ServiceBusMessage testServiceBusMessage = new ServiceBusMessage();
            testServiceBusMessage.Id = 1;
            testServiceBusMessage.Message = message;

            _messageBus.PublishMessage(testServiceBusMessage, "dfbTopic");

            return Ok(message);
        }
    }
}
