using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IStartVotingRepository
    {
        Task<IEnumerable<StartVoting>> GetAllAsync();
        Task<StartVoting> GetByIdAsync(int id);
        Task AddAsync(StartVoting startVoting);
        Task UpdateAsync(StartVoting startVoting);
        Task DeleteAsync(int id);
    }
}
