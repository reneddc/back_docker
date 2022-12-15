using MongoDB.Bson;

namespace AquiEstoy_MongoDB.Models
{
    public class UserModel
    {
        public string Id { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
    }
}
