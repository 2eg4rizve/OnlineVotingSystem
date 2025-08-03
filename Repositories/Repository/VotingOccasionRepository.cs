using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class VotingOccasionRepository : IVotingOccasionRepository
    {
        private readonly ApplicationDbContext _context;

        public VotingOccasionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VotingOccasion>> GetAllAsync()
        {
            return await _context.VotingOccasions.ToListAsync();
        }

        public async Task<VotingOccasion> GetByIdAsync(int id)
        {
            return await _context.VotingOccasions.FindAsync(id);
        }

        public async Task AddAsync(VotingOccasion occasion)
        {
            _context.VotingOccasions.Add(occasion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VotingOccasion occasion)
        {
            _context.VotingOccasions.Update(occasion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VotingOccasions.FindAsync(id);
            if (entity != null)
            {
                _context.VotingOccasions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
