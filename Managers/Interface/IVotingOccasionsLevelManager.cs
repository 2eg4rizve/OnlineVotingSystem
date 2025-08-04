using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IVotingOccasionsLevelManager
    {
        Task<List<VotingOccasionsLevelResponse>> GetAllAsync();
        Task<VotingOccasionsLevelResponse> GetByIdAsync(int id);
        Task<string> CreateAsync(VotingOccasionsLevelRequest request);
        Task<string> UpdateAsync(int id, VotingOccasionsLevelRequest request);
        Task<string> DeleteAsync(int id);
    }
}
