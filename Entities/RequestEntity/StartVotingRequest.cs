namespace OnlineVotingSystem.Entities.RequestEntity
{
    public class StartVotingRequest
    {
        public int VotingOccasionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
