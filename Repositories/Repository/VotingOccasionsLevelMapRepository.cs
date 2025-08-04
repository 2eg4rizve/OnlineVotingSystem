using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class VotingOccasionsLevelMapRepository : IVotingOccasionsLevelMapRepository
    {
        private readonly ApplicationDbContext _context;

        public VotingOccasionsLevelMapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VotingOccasionsLevelMap>> GetAllAsync() =>
            await _context.VotingOccasionsLevelMaps.ToListAsync();

        public async Task<VotingOccasionsLevelMap> GetByIdAsync(int id) =>
            await _context.VotingOccasionsLevelMaps.FindAsync(id);

        public async Task AddAsync(VotingOccasionsLevelMap entity)
        {
            _context.VotingOccasionsLevelMaps.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VotingOccasionsLevelMap entity)
        {
            _context.VotingOccasionsLevelMaps.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VotingOccasionsLevelMaps.FindAsync(id);
            if (entity != null)
            {
                _context.VotingOccasionsLevelMaps.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
