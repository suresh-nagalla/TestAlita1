using RestSharp;
using Serilog;
using Newtonsoft.Json;

namespace AutomationFramework.API.BusinessLogic
{
    public class PetApiHelper
    {
        private readonly RestClient _client;

        public PetApiHelper()
        {
            _client = new RestClient();
        }

        public RestResponse SendPostRequest(string endpoint, object payload)
        {
            var request = new RestRequest(endpoint, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);
            Log.Information("Sending POST request to {Endpoint} with payload: {Payload}", endpoint, JsonConvert.SerializeObject(payload));
            var response = _client.Execute(request);
            Log.Information("Received response: {ResponseContent}", response.Content);
            return response;
        }

        public RestResponse SendGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            Log.Information("Sending GET request to {Endpoint}", endpoint);
            var response = _client.Execute(request);
            Log.Information("Received response: {ResponseContent}", response.Content);
            return response;
        }

        public RestResponse SendPutRequest(string endpoint, object payload)
        {
            var request = new RestRequest(endpoint, Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);
            Log.Information("Sending PUT request to {Endpoint} with payload: {Payload}", endpoint, JsonConvert.SerializeObject(payload));
            var response = _client.Execute(request);
            Log.Information("Received response: {ResponseContent}", response.Content);
            return response;
        }

        public RestResponse SendDeleteRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            Log.Information("Sending DELETE request to {Endpoint}", endpoint);
            var response = _client.Execute(request);
            Log.Information("Received response: {ResponseContent}", response.Content);
            return response;
        }
    }
}
