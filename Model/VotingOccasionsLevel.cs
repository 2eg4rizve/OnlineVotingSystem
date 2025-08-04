namespace OnlineVotingSystem.Model
{
    public class VotingOccasionsLevel
    {
        public int Id { get; set; }
        public int VotingOccasionId { get; set; }
        public string LevelName { get; set; }

        // Optional: Navigation property
        public VotingOccasion VotingOccasion { get; set; }
    }
}
