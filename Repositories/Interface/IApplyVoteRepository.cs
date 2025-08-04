using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IApplyVoteRepository
    {
        Task<bool> HasUserVotedAsync(int votingOccasionId, int userId);
        Task AddVoteAsync(ApplyVote vote);
    }
}
