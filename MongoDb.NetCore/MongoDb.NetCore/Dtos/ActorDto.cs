using System.Text.Json.Serialization;

namespace MongoDb.NetCore.Dtos
{
    public class ActorDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birth_year")]
        public int BirthYear { get; set; }

        [JsonPropertyName("death_year")]
        public int DeathYear { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("known_for")]
        public List<string> KnownFor { get; set; }

        [JsonPropertyName("awards")]
        public List<string> Awards { get; set; }

        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
