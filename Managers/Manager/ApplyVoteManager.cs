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

            // 1️⃣ Check voting time
            var votingTime = await _repo.GetVotingTimeAsync(request.VotingOccasionId);
            if (votingTime == null)
                return "Invalid voting occasion.";

            DateTime now = DateTime.UtcNow; // Use UtcNow or Now depending on DB
            if (now < votingTime.Value.StartTime)
                return "Waiting for vote to start.";
            if (now > votingTime.Value.EndTime)
                return "Voting time finished.";

            // 2️⃣ Validate candidate
            bool isValidCandidate = await _repo.IsValidCandidateAsync(
                request.VotingOccasionId,
                request.VotingOccasionsLevelId,
                request.PersonId
            );
            if (!isValidCandidate)
                return "Invalid vote: This person is not a candidate for the selected level or occasion.";

            // 3️⃣ Check if already voted
            bool alreadyVoted = await _repo.HasAlreadyVotedAsync(userId, request.VotingOccasionId, request.VotingOccasionsLevelId);
            if (alreadyVoted)
                return "You have already voted in this level of the occasion.";

            // 4️⃣ Save vote
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
