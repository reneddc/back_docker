using AquiEstoy_MongoDB.Data.Entities;
using AquiEstoy_MongoDB.Data.Repository;
using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AutoMapper;
using MongoDB.Bson;

namespace AquiEstoy_MongoDB.Services
{
    public class UserService:IUserService
    {
        private IAquiEstoyCollection _aquiEstoyCollection;
        private IMapper _mapper;
        public UserService(IAquiEstoyCollection aquiEstoyCollection, IMapper mapper)
        {
            _aquiEstoyCollection = aquiEstoyCollection;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            var userEntity = _mapper.Map<UserEntity>(userModel);
            _aquiEstoyCollection.CreateUser(userEntity);
            var newUserModel = _mapper.Map<UserModel>(userEntity);
            return newUserModel;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var usersEntityList = await _aquiEstoyCollection.GetAllUsersAsync();
            var usersModelList = _mapper.Map<IEnumerable<UserModel>>(usersEntityList);
            return usersModelList;
        }

        public async Task<UserModel> GetUserAsync(string userId)
        {
            var userEntity = await _aquiEstoyCollection.GetUserAsync(userId);
            if (userEntity == null)
            {
                throw new NotFoundOperationException($"The user id: {userId}, does not exist.");
            }
            var userModel = _mapper.Map<UserModel>(userEntity);
            return userModel;
        }

        public async Task UpdateUserAsync(string userId, UserModel userModel)
        {
            await GetUserAsync(userId);
            var userEntity = _mapper.Map<UserEntity>(userModel);
            await _aquiEstoyCollection.UpdateUser(userId, userEntity);
        }

        public async Task DeleteUserAsync(string userId)
        {
            await GetUserAsync(userId);
            await _aquiEstoyCollection.DeleteUserAsync(userId);
        }
    }
}
