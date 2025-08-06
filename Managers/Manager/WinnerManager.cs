using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class WinnerManager : IWinnerManager
    {
        private readonly IWinnerRepository _repo;

        public WinnerManager(IWinnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<WinnerDetailedResultDto>> GetWinnerDetailsAsync(int votingOccasionId, int votingOccasionsLevelId)
        {
            return await _repo.GetWinnerDetailsAsync(votingOccasionId, votingOccasionsLevelId);
        }
    }
}
