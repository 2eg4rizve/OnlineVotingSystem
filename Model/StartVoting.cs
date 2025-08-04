namespace OnlineVotingSystem.Model
{
    public class StartVoting
    {
        public int Id { get; set; }
        public int VotingOccasionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
