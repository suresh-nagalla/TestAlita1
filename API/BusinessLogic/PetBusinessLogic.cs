using AutomationFramework.API.Clients;
using AutomationFramework.API.Builders;
using RestSharp;

namespace AutomationFramework.API.BusinessLogic
{
    public class PetBusinessLogic
    {
        private readonly PetStoreApiClient _client;

        public PetBusinessLogic(string baseUrl)
        {
            _client = new PetStoreApiClient(baseUrl);
        }

        // Create a new pet
        public RestResponse CreatePet(string name, string status, string category, string tags)
        {
            var petPayload = PetBuilder.BuildPetPayload(name, status, category, tags);
            return _client.CreatePet(petPayload);
        }

        // Retrieve a pet by ID
        public RestResponse GetPetById(long petId)
        {
            return _client.GetPetById(petId);
        }

        // Update an existing pet
        public RestResponse UpdatePet(long petId, string name, string status, string category, string tags)
        {
            var petPayload = PetBuilder.BuildPetPayload(name, status, category, tags);
            petPayload.Id = petId; // Ensure we're updating the correct pet by setting the ID
            return _client.UpdatePet(petPayload);
        }

        // Delete a pet by ID
        public RestResponse DeletePet(long petId)
        {
            return _client.DeletePet(petId);
        }
    }
}
