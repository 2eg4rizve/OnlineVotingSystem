using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IVotingOccasionManager
    {
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> CreateAsync(VotingOccasionRequest request);
        Task<CommonResponse> UpdateAsync(int id, VotingOccasionRequest request);
        Task<CommonResponse> DeleteAsync(int id);
    }
}
