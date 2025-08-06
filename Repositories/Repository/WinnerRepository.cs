using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class WinnerRepository : IWinnerRepository
    {
        private readonly ApplicationDbContext _context;

        public WinnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WinnerDetailedResultDto>> GetWinnerDetailsAsync(int votingOccasionId, int votingOccasionsLevelId)
        {
            //// Step 1: Get all matching votes from DB
            //var votes = await _context.ApplyVotes
            //    .Where(v => v.VotingOccasionId == votingOccasionId &&
            //                v.VotingOccasionsLevelId == votingOccasionsLevelId)
            //    .ToListAsync();

            //// Step 2: Group in-memory
            //var grouped = votes
            //    .GroupBy(v => v.PersonId)
            //    .Select(g => new
            //    {
            //        PersonId = g.Key,
            //        TotalVotes = g.Count()
            //    })
            //    .OrderByDescending(x => x.TotalVotes)
            //    .ToList();

            //// Step 3: Get required names
            //var users = await _context.Users.ToListAsync();
            //var occasion = await _context.VotingOccasions.FirstOrDefaultAsync(o => o.Id == votingOccasionId);
            //var level = await _context.VotingOccasionsLevels.FirstOrDefaultAsync(l => l.Id == votingOccasionsLevelId);

            //// Step 4: Join manually in memory
            //var result = grouped
            //    .Select(g =>
            //    {
            //        var user = users.FirstOrDefault(u => u.Id == g.PersonId);
            //        return new WinnerDetailedResultDto
            //        {
            //            VotingOccasionId = votingOccasionId,
            //            VotingOccasionName = occasion?.Name ?? "Unknown",
            //            VotingOccasionsLevelId = votingOccasionsLevelId,
            //            LevelName = level?.LevelName ?? "Unknown",
            //            PersonId = g.PersonId,
            //            Name = user?.Name ?? "Unknown",
            //            Email = user?.Email ?? "Unknown",
            //            TotalVotes = g.TotalVotes
            //        };
            //    })
            //    .ToList();

            //return result;

                return await _context.ApplyVotes
                .Where(v => v.VotingOccasionId == votingOccasionId &&
                            v.VotingOccasionsLevelId == votingOccasionsLevelId)
                .GroupBy(v => new { v.PersonId, v.VotingOccasionId, v.VotingOccasionsLevelId })
                .Select(g => new WinnerDetailedResultDto
                {
                    VotingOccasionId = g.Key.VotingOccasionId,
                    VotingOccasionName = _context.VotingOccasions
                        .Where(vo => vo.Id == g.Key.VotingOccasionId)
                        .Select(vo => vo.Name)
                        .FirstOrDefault() ?? "Unknown",
                    VotingOccasionsLevelId = g.Key.VotingOccasionsLevelId,
                    LevelName = _context.VotingOccasionsLevels
                        .Where(vol => vol.Id == g.Key.VotingOccasionsLevelId)
                        .Select(vol => vol.LevelName)
                        .FirstOrDefault() ?? "Unknown",
                    PersonId = g.Key.PersonId,
                    Name = _context.Users
                        .Where(u => u.Id == g.Key.PersonId)
                        .Select(u => u.Name)
                        .FirstOrDefault() ?? "Unknown",
                    Email = _context.Users
                        .Where(u => u.Id == g.Key.PersonId)
                        .Select(u => u.Email)
                        .FirstOrDefault() ?? "Unknown",
                    TotalVotes = g.Count()
                })
                .OrderByDescending(r => r.TotalVotes)
                .ToListAsync();
        }
    }
}
