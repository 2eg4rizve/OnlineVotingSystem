using OnlineVotingSystem.Entities.RequestEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IApplyVoteManager
    {
        Task<string> ApplyVoteAsync(ApplyVoteRequest request);
    }
}
