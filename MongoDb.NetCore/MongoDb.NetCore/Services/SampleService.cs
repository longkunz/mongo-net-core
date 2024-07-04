using MongoDb.Core.Repository;
using MongoDb.NetCore.Models;
using RestSharp;

namespace MongoDb.NetCore.Services
{
    public class SampleService(IMongoRepository<Actor> actorRepository) : ISampleService
    {
        private readonly IMongoRepository<Actor> _actorRepository = actorRepository; // <1>

        public async Task MigrateData() // <2>
        {
            var client = new RestClient("https://freetestapi.com");
            var request = new RestRequest("api/v1/actors", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var actors = System.Text.Json.JsonSerializer.Deserialize<List<Actor>>(response.Content!);
                _actorRepository.SetCollectionName("actors");
                _actorRepository.InsertMany(actors!);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        public async Task<Actor> GetActor(int id) // <3>
        {
            return await _actorRepository.FindById(id);
        }
    }
}
