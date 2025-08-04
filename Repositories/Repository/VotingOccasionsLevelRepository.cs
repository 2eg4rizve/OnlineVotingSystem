using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class VotingOccasionsLevelRepository : IVotingOccasionsLevelRepository
    {
        private readonly ApplicationDbContext _context;

        public VotingOccasionsLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VotingOccasionsLevel>> GetAllAsync() =>
            await _context.VotingOccasionsLevels.ToListAsync();

        public async Task<VotingOccasionsLevel> GetByIdAsync(int id) =>
            await _context.VotingOccasionsLevels.FindAsync(id);

        public async Task AddAsync(VotingOccasionsLevel entity)
        {
            _context.VotingOccasionsLevels.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VotingOccasionsLevel entity)
        {
            _context.VotingOccasionsLevels.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VotingOccasionsLevels.FindAsync(id);
            if (entity != null)
            {
                _context.VotingOccasionsLevels.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
