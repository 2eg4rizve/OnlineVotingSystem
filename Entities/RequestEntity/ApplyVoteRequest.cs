namespace OnlineVotingSystem.Entities.RequestEntity
{
    public class ApplyVoteRequest
    {
        public int VotingOccasionId { get; set; }
        public int VotingOccasionsLevelId { get; set; }
        public int PersonId { get; set; }
    }
}
