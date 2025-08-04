using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IApplyVoteManager
    {
        Task<CommonResponse> ApplyVoteAsync(ApplyVoteRequest request);
    }
}
