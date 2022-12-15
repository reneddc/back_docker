namespace AquiEstoy_MongoDB.Models
{
    public class FoundPetPostModel
    {
        public string IdFoundPetPost { get; set; } = string.Empty;
        public string? NamePet { get; set; }
        public string? Species { get; set; }
        public DateTime? DatePublication { get; set; }
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }

        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? UserID { get; set; }
        public string? PersonWhoFound { get; set; }
    }
}



