using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AquiEstoy_MongoDB.Data.Entities
{
    public class UserEntity
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [BsonElement("lastName")]
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [BsonElement("phone")]
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [BsonElement("address")]
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [BsonElement("photo")]
        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }
}
