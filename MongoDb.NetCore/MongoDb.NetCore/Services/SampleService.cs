using AutoMapper;
using MongoDb.Core.Repository;
using MongoDb.NetCore.Dtos;
using MongoDb.NetCore.Models;
using RestSharp;

namespace MongoDb.NetCore.Services
{
    public class SampleService(IMongoRepository<Actor> actorRepository, IMapper mapper) : ISampleService
    {
        private readonly IMongoRepository<Actor> _actorRepository = actorRepository; // <1>
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Migrates the data.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public async Task MigrateData() // <2>
        {
            var client = new RestClient("https://freetestapi.com");
            var request = new RestRequest("api/v1/actors", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var actors = System.Text.Json.JsonSerializer.Deserialize<List<ActorDto>>(response.Content!);
                if (actors is not null && actors.Count > 0)
                {
                    var actorModels = _mapper.Map<List<Actor>>(actors);
                    _actorRepository.SetCollectionName("actors");
                    _actorRepository.InsertMany(actorModels);
                }

            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets the actor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActorDto?> GetActor(int id) // <3>
        {
            _actorRepository.SetCollectionName("actors");
            var result = await _actorRepository.FindById(id);
            if (result is null)
                return null;
            return _mapper.Map<ActorDto>(result);
        }
    }
}
