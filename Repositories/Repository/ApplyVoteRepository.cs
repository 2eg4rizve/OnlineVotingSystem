using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class ApplyVoteRepository : IApplyVoteRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplyVoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ApplyVote vote)
        {
            _context.ApplyVotes.Add(vote);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasAlreadyVotedAsync(int voterId, int votingOccasionId, int votingOccasionsLevelId)
        {
            return await _context.ApplyVotes.AnyAsync(v =>
                v.VoterId == voterId &&
                v.VotingOccasionId == votingOccasionId &&
                v.VotingOccasionsLevelId == votingOccasionsLevelId);
        }

        public async Task<bool> IsValidCandidateAsync(int votingOccasionId, int votingOccasionsLevelId, int personId)
        {
            return await _context.VotingOccasionsLevelMaps.AnyAsync(map =>
                map.VotingOccasionId == votingOccasionId &&
                map.VotingOccasionsLevelId == votingOccasionsLevelId &&
                map.PersonId == personId);
        }
    }
}
