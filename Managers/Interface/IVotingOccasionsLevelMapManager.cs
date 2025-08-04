using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IVotingOccasionsLevelMapManager
    {
        Task<List<VotingOccasionsLevelMapResponse>> GetAllAsync();
        Task<VotingOccasionsLevelMapResponse> GetByIdAsync(int id);
        Task<string> CreateAsync(VotingOccasionsLevelMapRequest request);
        Task<string> UpdateAsync(int id, VotingOccasionsLevelMapRequest request);
        Task<string> DeleteAsync(int id);
    }
}
