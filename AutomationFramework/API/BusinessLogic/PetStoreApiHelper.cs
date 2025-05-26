using RestSharp;
using Serilog;
using System;

namespace AutomationFramework.API.BusinessLogic
{
    public class PetStoreApiHelper
    {
        private readonly RestClient _client;

        public PetStoreApiHelper()
        {
            _client = new RestClient("https://petstore.swagger.io/v2");
        }

        public RestResponse SendGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET);
            Log.Information("Sending GET request to {Endpoint}", endpoint);
            return ExecuteRequest(request);
        }

        public RestResponse SendPostRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.POST);
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            Log.Information("Sending POST request to {Endpoint} with body {Body}", endpoint, body);
            return ExecuteRequest(request);
        }

        public RestResponse SendPutRequest(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.PUT);
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            Log.Information("Sending PUT request to {Endpoint} with body {Body}", endpoint, body);
            return ExecuteRequest(request);
        }

        public RestResponse SendDeleteRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.DELETE);
            Log.Information("Sending DELETE request to {Endpoint}", endpoint);
            return ExecuteRequest(request);
        }

        private RestResponse ExecuteRequest(RestRequest request)
        {
            try
            {
                var response = _client.Execute(request);
                Log.Information("Received response: {StatusCode} - {Content}", response.StatusCode, response.Content);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error executing request");
                throw;
            }
        }
    }
}