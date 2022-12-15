using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AquiEstoy_MongoDB.Data.Entities
{
    public class LostPetPostEntity
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPublication { get; set; }

        [BsonElement("namePet")]
        [JsonPropertyName("namePet")]
        public string? NamePet { get; set; }
        [BsonElement("species")]
        [JsonPropertyName("species")]
        public string? Species { get; set; }

        [BsonElement("datePublication")]
        [JsonPropertyName("datePublication")]
        public DateTime DatePublication { get; set; }//Revisar fechas

        [BsonElement("longitud")]
        [JsonPropertyName("longitud")]
        public double? Longitud { get; set; }

        [BsonElement("latitud")]
        [JsonPropertyName("latitud")]
        public double? Latitud { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [BsonElement("reward")]
        [JsonPropertyName("reward")]
        public int? Reward { get; set; }

        [BsonElement("userID")]
        [JsonPropertyName("userID")]
        public string? UserID { get; set; }
    }
}



