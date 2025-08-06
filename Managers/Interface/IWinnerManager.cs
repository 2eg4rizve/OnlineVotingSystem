using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IWinnerManager
    {
        Task<List<WinnerDetailedResultDto>> GetWinnerDetailsAsync(int votingOccasionId, int votingOccasionsLevelId);
    }
}
