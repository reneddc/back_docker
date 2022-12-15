namespace AquiEstoy_MongoDB.Models
{
    public class LostPetPostModel
    {
        public string IdPublication { get; set; } = string.Empty;

        public string? NamePet { get; set; }
        public string? Species { get; set; }
        public DateTime? DatePublication { get; set; }
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public int? Reward { get; set; }
        public string? UserID { get; set; }

    }
}



