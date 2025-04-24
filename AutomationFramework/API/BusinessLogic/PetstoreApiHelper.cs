using System.Threading.Tasks;
using RestSharp;
using Serilog;

namespace AutomationFramework.API.BusinessLogic
{
    public class PetstoreApiHelper
    {
        private readonly RestClient _client;

        public PetstoreApiHelper()
        {
            _client = new RestClient("https://petstore.swagger.io/v2");
        }

        public async Task<RestResponse> CreatePetAsync(string payload)
        {
            var request = new RestRequest("/pet", Method.Post);
            request.AddJsonBody(payload);
            var response = await _client.ExecuteAsync(request);
            Log.Information("POST Request: {Endpoint}, Payload: {Payload}, Status Code: {StatusCode}, Response: {Response}",
                request.Resource, payload, response.StatusCode, response.Content);
            return response;
        }

        public async Task<RestResponse> GetPetAsync(string petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            Log.Information("GET Request: {Endpoint}, Status Code: {StatusCode}, Response: {Response}",
                request.Resource, response.StatusCode, response.Content);
            return response;
        }

        public async Task<RestResponse> UpdatePetAsync(string payload)
        {
            var request = new RestRequest("/pet", Method.Put);
            request.AddJsonBody(payload);
            var response = await _client.ExecuteAsync(request);
            Log.Information("PUT Request: {Endpoint}, Payload: {Payload}, Status Code: {StatusCode}, Response: {Response}",
                request.Resource, payload, response.StatusCode, response.Content);
            return response;
        }

        public async Task<RestResponse> DeletePetAsync(string petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            Log.Information("DELETE Request: {Endpoint}, Status Code: {StatusCode}, Response: {Response}",
                request.Resource, response.StatusCode, response.Content);
            return response;
        }
    }
}