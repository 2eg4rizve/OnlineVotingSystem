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

            //return await _context.ApplyVotes
            //.Where(v => v.VotingOccasionId == votingOccasionId &&
            //            v.VotingOccasionsLevelId == votingOccasionsLevelId)
            //.GroupBy(v => new { v.PersonId, v.VotingOccasionId, v.VotingOccasionsLevelId })
            //.Select(g => new WinnerDetailedResultDto
            //{
            //    VotingOccasionId = g.Key.VotingOccasionId,
            //    VotingOccasionName = _context.VotingOccasions
            //        .Where(vo => vo.Id == g.Key.VotingOccasionId)
            //        .Select(vo => vo.Name)
            //        .FirstOrDefault() ?? "Unknown",
            //    VotingOccasionsLevelId = g.Key.VotingOccasionsLevelId,
            //    LevelName = _context.VotingOccasionsLevels
            //        .Where(vol => vol.Id == g.Key.VotingOccasionsLevelId)
            //        .Select(vol => vol.LevelName)
            //        .FirstOrDefault() ?? "Unknown",
            //    PersonId = g.Key.PersonId,
            //    Name = _context.Users
            //        .Where(u => u.Id == g.Key.PersonId)
            //        .Select(u => u.Name)
            //        .FirstOrDefault() ?? "Unknown",
            //    Email = _context.Users
            //        .Where(u => u.Id == g.Key.PersonId)
            //        .Select(u => u.Email)
            //        .FirstOrDefault() ?? "Unknown",
            //    TotalVotes = g.Count()
            //})
            //.OrderByDescending(r => r.TotalVotes)
            //.ToListAsync();


            //var query = from vote in _context.ApplyVotes
            //            join user in _context.Users on vote.PersonId equals user.Id
            //            join occasion in _context.VotingOccasions on vote.VotingOccasionId equals occasion.Id
            //            join level in _context.VotingOccasionsLevels on vote.VotingOccasionsLevelId equals level.Id
            //            where vote.VotingOccasionId == votingOccasionId &&
            //                  vote.VotingOccasionsLevelId == votingOccasionsLevelId
            //            group new { vote, user, occasion, level } by vote.PersonId into grouped
            //            select new WinnerDetailedResultDto
            //            {
            //                VotingOccasionId = votingOccasionId,
            //                VotingOccasionName = grouped.First().occasion.Name,
            //                VotingOccasionsLevelId = votingOccasionsLevelId,
            //                LevelName = grouped.First().level.LevelName,
            //                PersonId = grouped.Key,
            //                Name = grouped.First().user.Name,
            //                Email = grouped.First().user.Email,
            //                TotalVotes = grouped.Count()
            //            };

            //return await query.OrderByDescending(x => x.TotalVotes).ToListAsync();



            //var query = _context.ApplyVotes
            //.Where(v => v.VotingOccasionId == votingOccasionId &&
            //            v.VotingOccasionsLevelId == votingOccasionsLevelId)
            //.Join(_context.Users, v => v.PersonId, u => u.Id, (v, u) => new { v, u })
            //.Join(_context.VotingOccasions, vu => vu.v.VotingOccasionId, o => o.Id, (vu, o) => new { vu.v, vu.u, o })
            //.Join(_context.VotingOccasionsLevels, vuo => vuo.v.VotingOccasionsLevelId, l => l.Id, (vuo, l) => new { vuo.v, vuo.u, vuo.o, l })
            //.GroupBy(x => x.v.PersonId)
            //.Select(g => new WinnerDetailedResultDto
            //{
            //    VotingOccasionId = votingOccasionId,
            //    VotingOccasionName = g.First().o.Name,
            //    VotingOccasionsLevelId = votingOccasionsLevelId,
            //    LevelName = g.First().l.LevelName,
            //    PersonId = g.Key,
            //    Name = g.First().u.Name,
            //    Email = g.First().u.Email,
            //    TotalVotes = g.Count()
            //})
            //.OrderByDescending(x => x.TotalVotes);

            //return await query.ToListAsync();

            var query = (
                from vote in _context.ApplyVotes
                join user in _context.Users on vote.PersonId equals user.Id
                join occasion in _context.VotingOccasions on vote.VotingOccasionId equals occasion.Id
                join level in _context.VotingOccasionsLevels on vote.VotingOccasionsLevelId equals level.Id
                where vote.VotingOccasionId == votingOccasionId &&
                      vote.VotingOccasionsLevelId == votingOccasionsLevelId
                group new { vote, user, occasion, level } by vote.PersonId into g
                orderby g.Count() descending
                select new WinnerDetailedResultDto
                {
                    PersonId = g.Key,
                    Name = g.First().user.Name,
                    Email = g.First().user.Email,
                    VotingOccasionId = votingOccasionId,
                    VotingOccasionName = g.First().occasion.Name,
                    VotingOccasionsLevelId = votingOccasionsLevelId,
                    LevelName = g.First().level.LevelName,
                    TotalVotes = g.Count()
                }
            );

            return await query.ToListAsync();



        }
    }
}
