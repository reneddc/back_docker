using AquiEstoy_MongoDB.Models;

namespace AquiEstoy_MongoDB.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> GetUserAsync(string userId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task UpdateUserAsync(string userId, UserModel userModel);
        Task DeleteUserAsync(string userId);
    }
}
