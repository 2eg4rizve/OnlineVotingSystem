using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class VotingCategoryRepository : IVotingCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public VotingCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VotingCategory>> GetAllAsync()
        {
            return await _context.VotingCategories
                .Include(v => v.VotingOccasion)
                .Include(v => v.User)
                .ToListAsync();
        }

        public async Task<VotingCategory> GetByIdAsync(int id)
        {
            return await _context.VotingCategories
                .Include(v => v.VotingOccasion)
                .Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(VotingCategory entity)
        {
            _context.VotingCategories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VotingCategory entity)
        {
            _context.VotingCategories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VotingCategories.FindAsync(id);
            if (entity != null)
            {
                _context.VotingCategories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
