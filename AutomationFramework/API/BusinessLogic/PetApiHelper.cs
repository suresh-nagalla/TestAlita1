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
            _client = new RestClient("https://petstore.swagger.io");
            Log.Information("RestClient initialized with base URL: {BaseUrl}", _client.BaseUrl);
        }

        public RestResponse SendGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            Log.Information("Sending GET request to: {Endpoint}", endpoint);

            var response = _client.Execute(request);
            Log.Information("Received response: {StatusCode}", response.StatusCode);
            return response;
        }

        public RestResponse SendPostRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            Log.Information("Sending POST request to: {Endpoint} with body: {RequestBody}", endpoint, JsonConvert.SerializeObject(body));
            var response = _client.Execute(request);

            Log.Information("Received response: {StatusCode}", response.StatusCode);
            return response;
        }

        public RestResponse SendPutRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);

            Log.Information("Sending PUT request to: {Endpoint} with body: {RequestBody}", endpoint, JsonConvert.SerializeObject(body));
            var response = _client.Execute(request);

            Log.Information("Received response: {StatusCode}", response.StatusCode);
            return response;
        }

        public RestResponse SendDeleteRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            Log.Information("Sending DELETE request to: {Endpoint}", endpoint);

            var response = _client.Execute(request);
            Log.Information("Received response: {StatusCode}", response.StatusCode);
            return response;
        }
    }
}