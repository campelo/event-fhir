using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EventFhir
{
    public class WebhookFhirFunction
    {
        private readonly ILogger _logger;

        public WebhookFhirFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WebhookFhirFunction>();
        }

        [Function("WebhookFhirFunction")]
        public async Task<HttpResponseData> WebhookFhir([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = $"webhook/fhir")] HttpRequestData req)
        {
            var data = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"{nameof(WebhookFhir)} - {data}");

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
