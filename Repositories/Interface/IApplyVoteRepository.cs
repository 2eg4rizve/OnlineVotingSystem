using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IApplyVoteRepository
    {
        Task AddAsync(ApplyVote vote);
        Task<bool> HasAlreadyVotedAsync(int voterId, int votingOccasionId, int votingOccasionsLevelId);
    }
}
