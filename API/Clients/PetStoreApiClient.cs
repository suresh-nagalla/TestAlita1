using AutomationFramework.Core.Base;
using RestSharp;

namespace AutomationFramework.API.Clients
{
    public class PetStoreApiClient : BaseApiClient
    {
        public PetStoreApiClient(string baseUrl) : base(baseUrl) { }

        // Create a new pet
        public RestResponse CreatePet(object petPayload)
        {
            var request = new RestRequest("pet", Method.Post)
                .AddJsonBody(petPayload);
            return ExecuteRequest(request);
        }

        // Retrieve a pet by ID
        public RestResponse GetPetById(long petId)
        {
            var request = new RestRequest($"pet/{petId}", Method.Get);
            return ExecuteRequest(request);
        }

        // Update an existing pet
        public RestResponse UpdatePet(object petPayload)
        {
            var request = new RestRequest("pet", Method.Put)
                .AddJsonBody(petPayload);
            return ExecuteRequest(request);
        }

        // Delete a pet by ID
        public RestResponse DeletePet(long petId)
        {
            var request = new RestRequest($"pet/{petId}", Method.Delete);
            return ExecuteRequest(request);
        }
    }
}
