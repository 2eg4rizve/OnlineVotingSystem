using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IVotingOccasionsLevelRepository
    {
        Task<List<VotingOccasionsLevel>> GetAllAsync();
        Task<VotingOccasionsLevel> GetByIdAsync(int id);
        Task AddAsync(VotingOccasionsLevel entity);
        Task UpdateAsync(VotingOccasionsLevel entity);
        Task DeleteAsync(int id);
    }
}
