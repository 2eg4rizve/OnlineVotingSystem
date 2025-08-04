using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IVotingOccasionsLevelMapRepository
    {
        Task<List<VotingOccasionsLevelMap>> GetAllAsync();
        Task<VotingOccasionsLevelMap> GetByIdAsync(int id);
        Task AddAsync(VotingOccasionsLevelMap entity);
        Task UpdateAsync(VotingOccasionsLevelMap entity);
        Task DeleteAsync(int id);
    }
}
