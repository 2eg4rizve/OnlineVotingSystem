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

        public async Task<bool> HasUserVotedAsync(int votingOccasionId, int userId)
        {
            return await _context.ApplyVotes
                .AnyAsync(v => v.VotingOccasionId == votingOccasionId && v.UserId == userId);
        }

        public async Task AddVoteAsync(ApplyVote vote)
        {
            _context.ApplyVotes.Add(vote);
            await _context.SaveChangesAsync();
        }
    }
}
