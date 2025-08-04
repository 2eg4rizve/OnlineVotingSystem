using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IStartVotingManager
    {
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> CreateAsync(StartVotingRequest request);
        Task<CommonResponse> UpdateAsync(int id, StartVotingRequest request);
        Task<CommonResponse> DeleteAsync(int id);
    }
}
