using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Repositories.Repository
{
    public class StartVotingRepository : IStartVotingRepository
    {
        private readonly ApplicationDbContext _context;

        public StartVotingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StartVoting>> GetAllAsync() => await _context.StartVotings.ToListAsync();

        public async Task<StartVoting> GetByIdAsync(int id) => await _context.StartVotings.FindAsync(id);

        public async Task AddAsync(StartVoting startVoting)
        {
            _context.StartVotings.Add(startVoting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StartVoting startVoting)
        {
            _context.StartVotings.Update(startVoting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.StartVotings.FindAsync(id);
            if (existing != null)
            {
                _context.StartVotings.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
