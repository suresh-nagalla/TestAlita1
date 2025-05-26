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
            Log.Information("Sending GET request to: {Endpoint}", endpoint);
            try
            {
                var response = _client.Execute(request);
                Log.Information("Received response: {StatusCode}", response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error("Error occurred while sending GET request: {Message}", ex.Message);
                throw;
            }
        }
    }
}
