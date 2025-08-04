namespace OnlineVotingSystem.Model
{
    public class VotingOccasionsLevelMap
    {
        public int Id { get; set; }

        public int VotingOccasionId { get; set; }
        public string LevelName { get; set; }

        public int VotingOccasionsLevelId { get; set; }
        public int PersonId { get; set; }

        // Optional navigation properties
        public VotingOccasionsLevel VotingOccasionsLevel { get; set; }
        public User Person { get; set; }
    }
}
