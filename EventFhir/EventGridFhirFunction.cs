// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EventFhir
{
    public class EventGridFhirFunction
    {
        private readonly ILogger _logger;

        public EventGridFhirFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EventGridFhirFunction>();
        }

        [Function("EventGridFhirFunction")]
        public void ByEventGrid([EventGridTrigger] MyEvent input)
        {
            _logger.LogInformation($"{nameof(ByEventGrid)} - {input.Data.ToString()}");
        }
    }

    public class MyEvent
    {
        public string Id { get; set; }

        public string Topic { get; set; }

        public string Subject { get; set; }

        public string EventType { get; set; }

        public DateTime EventTime { get; set; }

        public object Data { get; set; }
    }
}
