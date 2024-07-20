using MongoDb.NetCore.Dtos;

namespace MongoDb.NetCore.Services
{
    public interface ISampleService
    {
        Task MigrateData();

        Task<ActorDto?> GetActor(int id);
    }
}
