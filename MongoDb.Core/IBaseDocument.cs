using MongoDB.Bson;

namespace MongoDb.Core
{
    public interface IBaseDocument
    {
        BsonValue Id { get; set; }
    }
}
