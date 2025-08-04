using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class ApplyVoteManager : IApplyVoteManager
    {
        private readonly IApplyVoteRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplyVoteManager(IApplyVoteRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> ApplyVoteAsync(ApplyVoteRequest request)
        {
            int userId = GetCurrentUserId();
            if (userId == 0)
                return "Unauthorized: Could not extract user ID from token.";

            bool alreadyVoted = await _repo.HasAlreadyVotedAsync(userId, request.VotingOccasionId, request.VotingOccasionsLevelId);
            if (alreadyVoted)
                return "You have already voted in this level of the occasion.";

            var vote = new ApplyVote
            {
                VotingOccasionId = request.VotingOccasionId,
                VotingOccasionsLevelId = request.VotingOccasionsLevelId,
                PersonId = request.PersonId,
                VoterId = userId
            };

            await _repo.AddAsync(vote);
            return "Vote cast successfully.";
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || string.IsNullOrWhiteSpace(userIdClaim.Value))
                return 0;

            return int.TryParse(userIdClaim.Value, out int id) ? id : 0;
        }
    }
}
