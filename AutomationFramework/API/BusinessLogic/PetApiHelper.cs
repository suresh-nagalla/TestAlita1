using RestSharp;
using Newtonsoft.Json;
using Serilog;

namespace AutomationFramework.API.BusinessLogic
{
    public class PetApiHelper
    {
        private readonly RestClient _client;

        public PetApiHelper()
        {
            _client = new RestClient("https://petstore.swagger.io/v2");
            Log.Information("RestClient initialized with base URL: {BaseUrl}", _client.BaseUrl);
        }

        // Methods for GET, POST, PUT, DELETE operations will be implemented here
    }
}