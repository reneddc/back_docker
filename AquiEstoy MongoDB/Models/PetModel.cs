using AquiEstoy_MongoDB.Data.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace AquiEstoy_MongoDB.Models
{
    public class PetModel
    {
        public string Id { get; set; } = String.Empty;

        public string? NamePet { get; set; }
        public DateTime BirthDate { get; set; }//Revisar fechas

        public string? Gender { get; set; }
        public bool? HasNecklace { get; set; }
        public string? Specie { get; set; }
        public string? UserID { get; set; }
    }
}
