using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IVotingOccasionRepository
    {
        Task<List<VotingOccasion>> GetAllAsync();
        Task<VotingOccasion> GetByIdAsync(int id);
        Task AddAsync(VotingOccasion occasion);
        Task UpdateAsync(VotingOccasion occasion);
        Task DeleteAsync(int id);
    }
}
