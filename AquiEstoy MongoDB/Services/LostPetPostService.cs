using AquiEstoy_MongoDB.Data.Entities;
using AquiEstoy_MongoDB.Data.Repository;
using AquiEstoy_MongoDB.Exceptions;
using AquiEstoy_MongoDB.Models;
using AutoMapper;

namespace AquiEstoy_MongoDB.Services
{
    public class LostPetPostService : ILostPetPostService
    {
        private IAquiEstoyCollection _aquiEstoyCollection;
        private IMapper _mapper;
        public LostPetPostService(IAquiEstoyCollection aquiEstoyCollection, IMapper mapper)
        {
            _aquiEstoyCollection = aquiEstoyCollection;
            _mapper = mapper;
        }

        public async Task<LostPetPostModel> CreateLostPetPostAsync(LostPetPostModel publicationModel, string userId)
        {
            await ValidateUser(userId);
            var lostPetPostEntity = _mapper.Map<LostPetPostEntity>(publicationModel);
            _aquiEstoyCollection.CreateLostPetPost(lostPetPostEntity, userId);
            var newLostPetPostModel = _mapper.Map<LostPetPostModel>(lostPetPostEntity);
            return newLostPetPostModel;
        }


        public async Task<IEnumerable<LostPetPostModel>> GetAllLostPetsPostsAsync(string userId)
        {
            await ValidateUser(userId);
            var lostPetsPostsEntityList = await _aquiEstoyCollection.GetAllLostPetsPostsAsync(userId);
            var lostPetsPostsModelList = _mapper.Map<IEnumerable<LostPetPostModel>>(lostPetsPostsEntityList);
            return lostPetsPostsModelList;
        }

        public async Task<LostPetPostModel> GetLostPetPostAsync(string postId)
        {
            var lostPetPostEntity = await _aquiEstoyCollection.GetLostPetPostAsync(postId);
            if (lostPetPostEntity == null)
            {
                throw new NotFoundOperationException($"The lost pet post id: {postId}, does not exist.");
            }
            var lostPetPostModel = _mapper.Map<LostPetPostModel>(lostPetPostEntity);
            return lostPetPostModel;
        }

        public async Task DeleteLostPetPostAsync(string postId, string userId)
        {
            await ValidateUser(userId);
            await GetLostPetPostAsync(postId);
            await _aquiEstoyCollection.DeleteLostPetPostAsync(postId);
        }
        public async Task UpdateLostPetPostAsync(string userId, string lostPetPostId, LostPetPostModel lostPetPostModel)
        {
            await ValidateUser(userId);
            await GetLostPetPostAsync(lostPetPostId);
            var lostPetPostEntity = _mapper.Map<LostPetPostEntity>(lostPetPostModel);
            await _aquiEstoyCollection.UpdateLostPetPostAsync(lostPetPostId, lostPetPostEntity);
        }

        private async Task ValidateUser(string userId)
        {
            var user = await _aquiEstoyCollection.GetUserAsync(userId);
            if (user == null)
            {
                throw new NotFoundOperationException($"The user id: {userId}, does not exist.");
            }
        }

        public async Task<IEnumerable<LostPetPostModel>> GetAllLostPetsSUPostsAsync()
        {
            var lostPetPostEntityList = await _aquiEstoyCollection.GetAllLostPetsSUPostsAsync();
            var lostPetModelList = _mapper.Map<IEnumerable<LostPetPostModel>>(lostPetPostEntityList);
            return lostPetModelList;
        }
        public async Task<LostPetPostModel> GetLostPetSUPostAsync(string lostPetPostId)
        {
            var lostPetPostEntity = await _aquiEstoyCollection.GetLostPetPostAsync(lostPetPostId);
            if (lostPetPostEntity == null)
            {
                throw new NotFoundOperationException($"The Lost pet post id: {lostPetPostId}, does not exist.");
            }
            var lostPetPostModel = _mapper.Map<LostPetPostModel>(lostPetPostEntity);
            return lostPetPostModel;

        }
    }
}
