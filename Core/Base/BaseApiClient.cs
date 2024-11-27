using RestSharp;
using Serilog;

namespace AutomationFramework.Core.Base
{
    public class BaseApiClient
    {
        protected RestClient Client;

        public BaseApiClient(string baseUrl)
        {
            Client = new RestClient(baseUrl);
            Log.Information("API Client initialized with base URL: {BaseUrl}", baseUrl);
        }

        public RestResponse ExecuteRequest(RestRequest request)
        {
            try
            {
                Log.Information("Executing API request: {Method} {Resource}", request.Method, request.Resource);
                var response = Client.Execute(request);
                Log.Information("Response: {StatusCode} {Content}", response.StatusCode, response.Content);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while executing API request.");
                throw;
            }
        }
    }
}
