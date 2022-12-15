using AquiEstoy_MongoDB.Models;

namespace AquiEstoy_MongoDB.Services
{
    public interface IPetService
    {
        Task<PetModel> CreatePetAsync(PetModel petModel, string userId);
        Task<PetModel> GetPetAsync(string userId, string petId);
        Task<IEnumerable<PetModel>> GetAllPetsAsync(string userId);
        Task UpdatePetAsync(string userId, string petId, PetModel petModel);
        Task DeletePetAsync(string userId, string petId);
    }
}
