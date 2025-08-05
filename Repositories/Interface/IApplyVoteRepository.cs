using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IApplyVoteRepository
    {
        Task AddAsync(ApplyVote vote);
        Task<bool> HasAlreadyVotedAsync(int voterId, int votingOccasionId, int votingOccasionsLevelId);
        Task<bool> IsValidCandidateAsync(int votingOccasionId, int votingOccasionsLevelId, int personId);

        Task<(DateTime StartTime, DateTime EndTime)?> GetVotingTimeAsync(int votingOccasionId);

    }
}
