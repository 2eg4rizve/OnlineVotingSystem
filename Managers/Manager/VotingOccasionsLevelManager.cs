using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class VotingOccasionsLevelManager : IVotingOccasionsLevelManager
    {
        private readonly IVotingOccasionsLevelRepository _repo;

        public VotingOccasionsLevelManager(IVotingOccasionsLevelRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<VotingOccasionsLevelResponse>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(x => new VotingOccasionsLevelResponse
            {
                Id = x.Id,
                VotingOccasionId = x.VotingOccasionId,
                LevelName = x.LevelName
            }).ToList();
        }

        public async Task<VotingOccasionsLevelResponse> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            return new VotingOccasionsLevelResponse
            {
                Id = entity.Id,
                VotingOccasionId = entity.VotingOccasionId,
                LevelName = entity.LevelName
            };
        }

        public async Task<string> CreateAsync(VotingOccasionsLevelRequest request)
        {
            var entity = new VotingOccasionsLevel
            {
                VotingOccasionId = request.VotingOccasionId,
                LevelName = request.LevelName
            };

            await _repo.AddAsync(entity);
            return "Level added successfully";
        }

        public async Task<string> UpdateAsync(int id, VotingOccasionsLevelRequest request)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return "Not found";

            entity.VotingOccasionId = request.VotingOccasionId;
            entity.LevelName = request.LevelName;

            await _repo.UpdateAsync(entity);
            return "Updated successfully";
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            return "Deleted successfully";
        }
    }
}
