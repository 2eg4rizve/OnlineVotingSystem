using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IVotingCategoryManager
    {
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> CreateAsync(VotingCategoryRequest request);
        Task<CommonResponse> UpdateAsync(int id, VotingCategoryRequest request);
        Task<CommonResponse> DeleteAsync(int id);
    }
}
