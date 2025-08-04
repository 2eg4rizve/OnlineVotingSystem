using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class ApplyVoteManager : IApplyVoteManager
    {
        private readonly IApplyVoteRepository _repo;

        public ApplyVoteManager(IApplyVoteRepository repo)
        {
            _repo = repo;
        }

        public async Task<CommonResponse> ApplyVoteAsync(ApplyVoteRequest request)
        {
            var alreadyVoted = await _repo.HasUserVotedAsync(request.VotingOccasionId, request.UserId);

            if (alreadyVoted)
            {
                return new CommonResponse
                {
                    status_code = 400,
                    status = "Error",
                    message = "User has already voted in this occasion."
                };
            }

            var vote = new ApplyVote
            {
                VotingOccasionId = request.VotingOccasionId,
                UserId = request.UserId
            };

            await _repo.AddVoteAsync(vote);

            return new CommonResponse
            {
                status_code = 200,
                status = "Success",
                message = "Vote successfully applied."
            };
        }
    }
}
