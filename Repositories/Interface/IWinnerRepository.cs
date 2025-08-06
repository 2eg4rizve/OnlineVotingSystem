using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Repositories.Interface
{
    public interface IWinnerRepository
    {
        Task<List<WinnerDetailedResultDto>> GetWinnerDetailsAsync(int votingOccasionId, int votingOccasionsLevelId);
    }
}
