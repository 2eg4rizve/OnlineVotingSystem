namespace OnlineVotingSystem.Entities.ResponseEntity
{
    public class VotingOccasionsLevelMapResponse
    {
        public int Id { get; set; }
        public int VotingOccasionId { get; set; }
        public string LevelName { get; set; }
        public int VotingOccasionsLevelId { get; set; }
        public int PersonId { get; set; }
    }
}
