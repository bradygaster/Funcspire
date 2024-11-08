using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Funcspire.Functions
{
    public class BlobTriggeredFunction
    {
        private readonly ILogger<BlobTriggeredFunction> _logger;

        public BlobTriggeredFunction(ILogger<BlobTriggeredFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobTriggeredFunction))]
        public async Task Run([BlobTrigger("incoming/{name}", Connection = "blobs")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
