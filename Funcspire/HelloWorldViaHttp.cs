using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Funcspire
{
    public class HelloWorldViaHttp
    {
        private readonly ILogger<HelloWorldViaHttp> _logger;

        public HelloWorldViaHttp(ILogger<HelloWorldViaHttp> logger)
        {
            _logger = logger;
        }

        [Function("helloworld")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to the exciting combination of .NET Aspire and Azure Functions!");
        }
    }
}
