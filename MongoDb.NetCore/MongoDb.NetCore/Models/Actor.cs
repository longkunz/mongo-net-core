using MongoDb.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.NetCore.Models
{
    public class Actor : IBaseDocument
    {
        [BsonId]
        //[BsonRepresentation(BsonType.Int32)]
        public BsonValue Id { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string Nationality { get; set; }

        public List<string> KnownFor { get; set; }

        public List<string> Awards { get; set; }

        public string Biography { get; set; }

        public string Image { get; set; }
    }
}
