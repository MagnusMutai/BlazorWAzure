using System.Threading.Tasks;
using BlazorWAzure.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BlazorWAzure.Functions
{
    public class GetSharedData
    {
        [Function("GetSharedData")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetSharedData");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var sharedData = new SharedData
            {
                Message = "This message is from the shared class library, served by Azure Function."
            };

            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await response.WriteStringAsync(sharedData.Message);

            return response;
        }
    }
}