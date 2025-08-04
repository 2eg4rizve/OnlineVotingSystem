namespace OnlineVotingSystem.Model
{
    public class ApplyVote
    {
        public int Id { get; set; }
        public int VotingOccasionId { get; set; }
        public int VotingOccasionsLevelId { get; set; } // ✅ Must exist in DB
        public int PersonId { get; set; }
        public int VoterId { get; set; } // ✅ Must exist in DB
    }
}
