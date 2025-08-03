using OnlineVotingSystem.Model;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IVotingCategoryRepository
    {
        Task<List<VotingCategory>> GetAllAsync();
        Task<VotingCategory> GetByIdAsync(int id);
        Task AddAsync(VotingCategory entity);
        Task UpdateAsync(VotingCategory entity);
        Task DeleteAsync(int id);
    }
}
