using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class VotingOccasionsLevelMapManager : IVotingOccasionsLevelMapManager
    {
        private readonly IVotingOccasionsLevelMapRepository _repo;

        public VotingOccasionsLevelMapManager(IVotingOccasionsLevelMapRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<VotingOccasionsLevelMapResponse>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(x => new VotingOccasionsLevelMapResponse
            {
                Id = x.Id,
                VotingOccasionId = x.VotingOccasionId,
                LevelName = x.LevelName,
                VotingOccasionsLevelId = x.VotingOccasionsLevelId,
                PersonId = x.PersonId
            }).ToList();
        }

        public async Task<VotingOccasionsLevelMapResponse> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            return new VotingOccasionsLevelMapResponse
            {
                Id = entity.Id,
                VotingOccasionId = entity.VotingOccasionId,
                LevelName = entity.LevelName,
                VotingOccasionsLevelId = entity.VotingOccasionsLevelId,
                PersonId = entity.PersonId
            };
        }

        public async Task<string> CreateAsync(VotingOccasionsLevelMapRequest request)
        {
            var entity = new VotingOccasionsLevelMap
            {
                VotingOccasionId = request.VotingOccasionId,
                LevelName = request.LevelName,
                VotingOccasionsLevelId = request.VotingOccasionsLevelId,
                PersonId = request.PersonId
            };

            await _repo.AddAsync(entity);
            return "Mapping created successfully";
        }

        public async Task<string> UpdateAsync(int id, VotingOccasionsLevelMapRequest request)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return "Not found";

            entity.VotingOccasionId = request.VotingOccasionId;
            entity.LevelName = request.LevelName;
            entity.VotingOccasionsLevelId = request.VotingOccasionsLevelId;
            entity.PersonId = request.PersonId;

            await _repo.UpdateAsync(entity);
            return "Mapping updated successfully";
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return "Mapping deleted successfully";
        }
    }
}
