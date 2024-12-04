using RestSharp;

public class PetStoreClient
{
    public string GetPetById(int id)
    {
        var client = new RestClient("http://example.com");
        var request = new RestRequest($"/pet/{id}", Method.GET);
        var response = client.Execute(request);

        return response.Content;
    }
}
