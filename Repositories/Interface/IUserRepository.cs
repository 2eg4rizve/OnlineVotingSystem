using OnlineVotingSystem.Model;


namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
